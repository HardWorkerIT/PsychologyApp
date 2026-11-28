using PsychologyApp.Presentation.Shared.Navigation;

namespace PsychologyApp.Presentation.Features.ManageJournal;

public interface IJournalHubPage;

public sealed class JournalScreenCoordinator(JournalEditorContext editorContext)
{
    public Task OpenEditorDayAsync(DateOnly day, INavigationService navigation)
    {
        IReadOnlyList<Page> stack = navigation.Navigation.NavigationStack;
        bool hubBelowCurrent = stack.Count >= 2
            && stack.Take(stack.Count - 1).Any(static page => page is IJournalHubPage);

        if (hubBelowCurrent)
        {
            return ReturnToEditorAsync(day, navigation);
        }

        editorContext.PendingTarget = (day, null);
        return navigation.GoToJournalAsync();
    }

    // Timeline and overview are pushed from the editor. Shell can omit the tab root from NavigationStack.
    public Task ReturnToEditorAsync(DateOnly day, INavigationService navigation, long? entryId = null)
    {
        editorContext.PendingTarget = (day, entryId);
        return navigation.GoBackAsync();
    }
}
