using PsychologyApp.Application.UserProgress;
using PsychologyApp.Presentation.Shared.Navigation;

namespace PsychologyApp.Presentation.Shared.Common;

public static class PracticeCompletionNavigator
{
    public static async Task NavigateAfterCompletionAsync(
        INavigationService navigation,
        IUserProgressService progress,
        string? completedItemKey = null,
        long? sessionResultId = null)
    {
        int activeDays = 0;
        try
        {
            activeDays = await progress.GetActiveDaysThisWeekAsync();
        }
        catch (Exception error)
        {
            // The weekly summary is optional; the saved result can still be shown.
            BestEffort.Report(error);
        }

        bool opened = await NavigationRetry.TryExecuteWithRetryAsync(
            () => navigation.GoToPracticeCompletionAsync(activeDays, completedItemKey, sessionResultId),
            status => status is NavigationRunStatus.Completed or NavigationRunStatus.DroppedDuplicate);

        if (!opened)
        {
            throw new InvalidOperationException("The saved practice result could not be opened.");
        }
    }
}
