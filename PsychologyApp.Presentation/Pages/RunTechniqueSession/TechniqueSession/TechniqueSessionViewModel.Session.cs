using PsychologyApp.Domain.Practice;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Models.Practice.Techniques;

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.TechniqueSession;

public partial class TechniqueSessionViewModel
{
    private Task _draftLoadTask = Task.CompletedTask;

    internal Task WaitForDraftLoadAsync() => _draftLoadTask;

    /// <summary>The practice has its own "tension before" step (breathing, thought record): the separate scale above is not shown.</summary>
    public bool AsksPreIntensity => !Entries.Any(e => e.Role == EntryFieldRole.IntensityBefore);

    protected override void OnTechniqueContentChanged()
    {
        WatchEntries();
        if (IsTechniqueLocalizationRefresh)
        {
            OnPropertyChanged(nameof(AsksPreIntensity));
            if (AppliedUiKind == TechniqueUiKind.Entry)
            {
                _entryDraftCoordinator.WireHandlers();
                ResumeWhereLeft();
                Notify(nameof(NextStepText), nameof(CanFinish), nameof(IsCurrentEmpty), nameof(NextStepVariant));
            }

            return;
        }

        ResetWizardStep();
        OnPropertyChanged(nameof(AsksPreIntensity));

        if (AppliedUiKind == TechniqueUiKind.Entry)
        {
            _entryDraftCoordinator.WireHandlers();
            _draftLoadTask = LoadEntryDraftAsync();
            _draftLoadTask.FireAndForget();
        }

        LoadLastNoteAsync();
        OfferRecentProblemAsync().FireAndForget();
    }

    private async Task LoadEntryDraftAsync()
    {
        try
        {
            await _entryDraftCoordinator.LoadAsync(() =>
            {
                OnPropertyChanged(nameof(Entries));
                ResumeWhereLeft();
                Notify(nameof(NextStepText), nameof(CanFinish), nameof(IsCurrentEmpty), nameof(NextStepVariant));
            });
        }
        catch (Exception error)
        {
            BestEffort.Report(error);
        }
    }

    public void SaveEntryDraftIfNeeded() => _entryDraftCoordinator.SaveIfNeeded();

    /// <summary>A practice left half-way opens again at its first unanswered step, not at the start.</summary>
    private void ResumeWhereLeft()
    {
        if (!IsWizardMode)
        {
            return;
        }

        int step = PracticeAnswers.ResumeStep(Entries.Select(e => (string?)e.Text).ToList());
        if (step > 0)
        {
            CurrentStepIndex = step;
        }
    }

    private async Task CompleteSessionAsync()
    {
        if (!_sessionHelper.HasSavedResult)
        {
            // The result is built from the persisted draft; do not let the debounce omit the user's last answer.
            await _entryDraftCoordinator.SaveAsync();
            await RememberProblemAsync();
            RememberTypedAnswers();
        }

        await _sessionHelper.CompleteAsync(
            _techniqueId.ToString(),
            ModuleName,
            PageName,
            _sessionStartedAt,
            RatingOf(EntryFieldRole.IntensityBefore) ?? TryGetPreIntensity(),
            RatingOf(EntryFieldRole.IntensityAfter),
            onSaved: _entryDraftCoordinator.MarkSessionCompletedAsync);
    }

    /// <summary>The 0..10 answer of the step with this role, when the practice has one and it was answered.</summary>
    private int? RatingOf(EntryFieldRole role) =>
        Entries.FirstOrDefault(e => e.Role == role) is { } entry && int.TryParse(entry.Text, out int value) && value is >= 0 and <= 10
            ? value
            : null;
}
