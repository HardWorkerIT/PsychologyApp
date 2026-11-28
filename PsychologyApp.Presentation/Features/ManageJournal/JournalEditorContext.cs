namespace PsychologyApp.Presentation.Features.ManageJournal;

public sealed class JournalEditorContext
{
    public (DateOnly Day, long? EntryId)? PendingTarget { get; set; }

    public (DateOnly Day, long? EntryId)? ConsumePendingTarget()
    {
        var target = PendingTarget;
        PendingTarget = null;
        return target;
    }
}
