namespace PsychologyApp.Presentation.Shared.Navigation;

public enum NavigationRunStatus
{
    Completed,
    DroppedBusy,
    DroppedTimeout,
    Failed,

    /// <summary>The same destination was already opening or had only just opened (a double tap), so this call did nothing.</summary>
    DroppedDuplicate,

    /// <summary>The originating page was no longer at the top of its stack.</summary>
    DroppedInactiveSource
}
