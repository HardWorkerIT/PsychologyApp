using System.Runtime.CompilerServices;
using Microsoft.Extensions.Logging;

namespace PsychologyApp.Presentation.Shared.Navigation;

public static class NavigationCoordinator
{
    private static readonly SemaphoreSlim Gate = new(1, 1);
    private static ILogger? _logger;

    /// <summary>How long after a page opened a call for the same destination still counts as the same tap.</summary>
    private static readonly TimeSpan DuplicateWindow = TimeSpan.FromMilliseconds(600);

    private static readonly object DuplicateLock = new();
    private static readonly HashSet<string> InFlight = new(StringComparer.Ordinal);
    private static readonly Dictionary<string, long> LastOpenedTicks = new(StringComparer.Ordinal);

    private static readonly TimeSpan PushGateWait = TimeSpan.FromSeconds(4);
    private static readonly TimeSpan CompletionGateWait = TimeSpan.FromSeconds(8);

    public static void SetLogger(ILogger logger) => _logger = logger;

    internal static void ResetForTests()
    {
        while (Gate.CurrentCount == 0)
        {
            try
            {
                Gate.Release();
            }
            catch (SemaphoreFullException)
            {
                break;
            }
        }

        while (Gate.CurrentCount > 1)
        {
            Gate.Wait(0);
        }

        lock (DuplicateLock)
        {
            InFlight.Clear();
            LastOpenedTicks.Clear();
        }
    }

    public static async Task RunAsync(Func<Task> navigate)
    {
        _ = await RunCoreAsync(navigate).ConfigureAwait(false);
    }

    /// <summary>
    /// Opens a page. <paramref name="destination"/> names where it goes (by default the calling method, e.g. "GoToUserProfileAsync");
    /// a second call for the same destination while the first is still opening, or within <see cref="DuplicateWindow"/> after it
    /// opened, is a double tap and is dropped. Without this the gate only *queued* it, and the page opened twice, one after the other.
    /// Calls for different destinations are still queued in order (code that pushes two pages in a row keeps working).
    /// </summary>
    public static Task<NavigationRunStatus> RunPushAsync(Func<Task> navigate, [CallerMemberName] string? destination = null) =>
        RunGuardedAsync(
            destination,
            () => RunCoreAsync(navigate, waitForGate: true, gateWait: PushGateWait));

    /// <summary>
    /// Single-shot push for test completion: longer gate wait, same double-tap guard.
    /// </summary>
    public static Task<NavigationRunStatus> RunCompletionPushAsync(Func<Task> navigate, [CallerMemberName] string? destination = null) =>
        RunGuardedAsync(
            destination,
            () => RunCoreAsync(navigate, waitForGate: true, gateWait: CompletionGateWait));

    public static Task<NavigationRunStatus> RunCompletionPushAsync(
        Func<Task<NavigationRunStatus>> navigate,
        [CallerMemberName] string? destination = null) =>
        RunGuardedAsync(
            destination,
            () => RunCoreAsync(navigate, waitForGate: true, gateWait: CompletionGateWait));

    private static async Task<NavigationRunStatus> RunGuardedAsync(string? destination, Func<Task<NavigationRunStatus>> run)
    {
        if (destination is null)
        {
            return await run().ConfigureAwait(false);
        }

        if (!TryBeginPush(destination))
        {
            _logger?.LogInformation("Navigation dropped: {Destination} is already opening (double tap).", destination);
            return NavigationRunStatus.DroppedDuplicate;
        }

        NavigationRunStatus status = NavigationRunStatus.Failed;
        try
        {
            status = await run().ConfigureAwait(false);
            return status;
        }
        finally
        {
            EndPush(destination, opened: status == NavigationRunStatus.Completed);
        }
    }

    private static bool TryBeginPush(string destination)
    {
        lock (DuplicateLock)
        {
            long now = Environment.TickCount64;
            // Dictionary removals do not invalidate its enumerator on .NET.
            foreach ((string key, long opened) in LastOpenedTicks)
            {
                if (now - opened >= DuplicateWindow.TotalMilliseconds)
                {
                    LastOpenedTicks.Remove(key);
                }
            }

            if (InFlight.Contains(destination))
            {
                return false;
            }

            if (LastOpenedTicks.ContainsKey(destination))
            {
                return false;
            }

            InFlight.Add(destination);
            return true;
        }
    }

    private static void EndPush(string destination, bool opened)
    {
        lock (DuplicateLock)
        {
            InFlight.Remove(destination);

            // A failed or dropped push must not block the retry that follows it.
            if (opened)
            {
                LastOpenedTicks[destination] = Environment.TickCount64;
            }
            else
            {
                LastOpenedTicks.Remove(destination);
            }
        }
    }

    private static Task<NavigationRunStatus> RunCoreAsync(
        Func<Task> navigate,
        bool waitForGate = false,
        TimeSpan? gateWait = null) =>
        RunCoreAsync(async () =>
        {
            await navigate();
            return NavigationRunStatus.Completed;
        }, waitForGate, gateWait);

    private static async Task<NavigationRunStatus> RunCoreAsync(
        Func<Task<NavigationRunStatus>> navigate,
        bool waitForGate,
        TimeSpan? gateWait)
    {
        TimeSpan gateWaitDuration = gateWait ?? PushGateWait;

        bool acquired = waitForGate
            ? await Gate.WaitAsync(gateWaitDuration).ConfigureAwait(false)
            : await Gate.WaitAsync(0).ConfigureAwait(false);

        if (!acquired)
        {
            string message = waitForGate
                ? "Navigation dropped: coordinator gate timeout."
                : "Navigation dropped: coordinator gate busy.";
            _logger?.LogWarning(message);
            return waitForGate ? NavigationRunStatus.DroppedTimeout : NavigationRunStatus.DroppedBusy;
        }

        try
        {
            // The status is assigned inside the UI delegate so both the source check and the push run under the gate.
            NavigationRunStatus status = NavigationRunStatus.Failed;
            await NavigationThread.InvokeAsync(async () => { status = await navigate(); }).ConfigureAwait(false);
            return status;
        }
        catch (Exception ex)
        {
            _logger?.LogWarning(ex, "Navigation operation failed.");
            return NavigationRunStatus.Failed;
        }
        finally
        {
            Gate.Release();
        }
    }
}
