using Microsoft.Extensions.Logging;
using PsychologyApp.Presentation.Pages.ManageProfile.AppLock;
using PsychologyApp.Presentation.Shared.Services.Security;

namespace PsychologyApp.Presentation.Features.ManageProfile;

/// <summary>
/// Puts the lock screen in front of the app at start and after an absence (<see cref="AppLockPolicy"/>), and takes it away once the
/// app PIN is passed. The switch is kept under its own preference key, apart from the visual settings: saving a theme
/// rewrites those as a whole, and the lock must never be turned off as a side effect.
/// </summary>
public sealed class AppLockCoordinator(
    IDeviceAuthenticator authenticator,
    IAppPinCredentialStore pinCredentialStore,
    ILogger<AppLockCoordinator> logger) : IAppLock
{
    private const string EnabledKey = "AppLockEnabled";
    private static readonly TimeSpan WindowRetryDelay = TimeSpan.FromMilliseconds(250);

    private bool _unlocked;
    private long? _leftAtMs;

    // The check in progress. The start-up check and a return to the app can overlap (both wait for the window), and two of them
    // would put two lock screens on top of each other.
    private Task? _guard;

    public bool IsEnabled => Preferences.Default.Get(EnabledKey, Availability == DeviceUnlockAvailability.Available);

    public DeviceUnlockAvailability Availability => authenticator.Availability;

    public async Task<bool> TryEnableAsync()
    {
        if (Availability != DeviceUnlockAvailability.Available
            || await authenticator.AuthenticateAsync(AppStrings.AppLockEnableTitle, AppStrings.AppLockPromptSubtitle) != DeviceUnlockResult.Passed)
        {
            return false;
        }

        Preferences.Default.Set(EnabledKey, true);
        _unlocked = true;
        ApplyRecentsPreview();
        return true;
    }

    public void Disable()
    {
        Preferences.Default.Set(EnabledKey, false);
        ApplyRecentsPreview();
    }

    /// <summary>The app went to the background.</summary>
    public void OnLeft()
    {
        if (_unlocked)
        {
            _leftAtMs = SinceBootMs();
        }
    }

    /// <summary>
    /// True while the app's own content must stay out of sight: from the moment the lock is found due (before the first frame of a
    /// start or a return) until it is passed. The shell hides its content then, so nothing flashes before the lock screen.
    /// </summary>
    public bool IsCovering { get; private set; }

    public event EventHandler? CoveringChanged;

    /// <summary>At start and on every return: shows the lock screen when it is due and waits until it is passed.</summary>
    public Task GuardAsync()
    {
        // Runs on the UI thread (the shell's constructor, App.OnResume), so this check and the assignment cannot interleave.
        if (_guard is { IsCompleted: false } running)
        {
            return running;
        }

        // Decided here, synchronously, so the content is covered before the next frame is drawn.
        TimeSpan? awayFor = _leftAtMs is long left ? TimeSpan.FromMilliseconds(SinceBootMs() - left) : null;
        bool mustCheckLegacyPin = !Preferences.Default.ContainsKey(EnabledKey) && !IsEnabled;
        bool due = AppLockPolicy.NeedsUnlock(IsEnabled, _unlocked, awayFor);
        if (due || mustCheckLegacyPin)
        {
            SetCovering(true);
        }

        return _guard = GuardCoreAsync(due, mustCheckLegacyPin);
    }

    private async Task GuardCoreAsync(bool due, bool mustCheckLegacyPin)
    {
        if (mustCheckLegacyPin)
        {
            try
            {
                due = await pinCredentialStore.HasPinAsync();
            }
            catch (Exception ex)
            {
                logger.LogWarning(ex, "Could not check the existing app PIN");
                due = true;
            }
        }

        if (!due)
        {
            _leftAtMs = null;
            SetCovering(false);
            ApplyRecentsPreview();
            return;
        }

        (Window window, Page root) = await WaitForWindowAsync();
        ApplyRecentsPreview();

        AppLockPage page = new(new AppLockViewModel(authenticator, pinCredentialStore));
        bool useRootFallback = false;
        try
        {
            await root.Navigation.PushModalAsync(page, animated: false);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Could not present the app lock as a modal");
            useRootFallback = true;
            page = new AppLockPage(new AppLockViewModel(authenticator, pinCredentialStore));
            // The dedicated lock page also works without a modal navigation stack.
            window.Page = page;
        }

        await page.Unlocked;
        try
        {
            if (useRootFallback)
            {
                window.Page = root;
            }
            else if (root.Navigation.ModalStack.LastOrDefault() == page)
            {
                await root.Navigation.PopModalAsync(animated: false);
            }
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Could not dismiss the authenticated app lock");
        }
        finally
        {
            // The lock flow must complete before modal navigation can release the cover.
            if (!Preferences.Default.ContainsKey(EnabledKey))
            {
                Preferences.Default.Set(EnabledKey, true);
            }
            _unlocked = true;
            _leftAtMs = null;
            SetCovering(false);
        }
    }

    private void SetCovering(bool covering)
    {
        if (IsCovering == covering)
        {
            return;
        }

        IsCovering = covering;
        CoveringChanged?.Invoke(this, EventArgs.Empty);
    }

    /// <summary>
    /// Time since the phone started, counting deep sleep. The wall clock can be set back by whoever holds the phone, and a plain
    /// monotonic clock stops while the phone sleeps (two hours in a pocket would read as seconds); this one does neither.
    /// </summary>
    private static long SinceBootMs()
    {
#if ANDROID
        return global::Android.OS.SystemClock.ElapsedRealtime();
#else
        return Environment.TickCount64;
#endif
    }

    /// <summary>
    /// Startup can reach the lock before MAUI attaches the window. Keep the content covered until a lock can be presented.
    /// </summary>
    private static async Task<(Window Window, Page Root)> WaitForWindowAsync()
    {
        while (true)
        {
            if (Microsoft.Maui.Controls.Application.Current?.Windows.FirstOrDefault() is { Page: { Handler: not null } root } window)
            {
                return (window, root);
            }

            await Task.Delay(WindowRetryDelay);
        }
    }

    /// <summary>With the lock on, the recent-apps list shows no picture of the last screen (Android 13+; screenshots still work).</summary>
    private void ApplyRecentsPreview()
    {
#if ANDROID
        if (OperatingSystem.IsAndroidVersionAtLeast(33))
        {
            try
            {
                Platform.CurrentActivity?.SetRecentsScreenshotEnabled(!IsEnabled);
            }
            catch (Exception ex)
            {
                // A failed recents-preview update must not block the lock screen or leave the app covered.
                logger.LogWarning(ex, "Could not update the recent-apps preview");
            }
        }
#endif
    }
}
