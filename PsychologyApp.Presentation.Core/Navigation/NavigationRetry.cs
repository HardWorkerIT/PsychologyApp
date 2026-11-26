namespace PsychologyApp.Presentation.Shared.Navigation;

public static class NavigationRetry
{
    public static async Task CompleteWithRecoveryAsync(Func<Task> attempt, Func<Exception, Task> waitForRetry)
    {
        while (true)
        {
            try
            {
                await attempt();
                return;
            }
            catch (Exception ex)
            {
                await waitForRetry(ex);
            }
        }
    }

    public static Task<bool> TryOpenPageAsync(Func<bool> isVisible, Func<Task> open) =>
        TryExecuteWithRetryAsync(
            // Deduplicate against the visible page after waiting for the actual navigation in progress.
            () => NavigationCoordinator.RunPushAsync(() => isVisible() ? Task.CompletedTask : open(), destination: null),
            status => status == NavigationRunStatus.Completed);

    public static async Task<bool> TryExecuteWithRetryAsync<TStatus>(
        Func<Task<TStatus>> operation,
        Func<TStatus, bool> isCompleted,
        int maxAttempts = 3,
        TimeSpan? delay = null,
        CancellationToken cancellationToken = default)
        where TStatus : struct, Enum
    {
        delay ??= TimeSpan.FromMilliseconds(150);

        for (int attempt = 1; attempt <= maxAttempts; attempt++)
        {
            TStatus status = await operation().ConfigureAwait(false);
            if (isCompleted(status))
            {
                return true;
            }

            if (attempt < maxAttempts)
            {
                await Task.Delay(delay.Value, cancellationToken).ConfigureAwait(false);
            }
        }

        return false;
    }
}
