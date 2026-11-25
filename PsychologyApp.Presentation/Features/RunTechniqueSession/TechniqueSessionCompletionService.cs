using PsychologyApp.Application.ClinicalCare;
using PsychologyApp.Application.Models;
using PsychologyApp.Application.UserProgress;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.Services.Notifications;

namespace PsychologyApp.Presentation.Features.RunTechniqueSession;

public sealed class PracticeSessionCompletionState
{
    internal long? ResultId { get; set; }

    public bool HasSavedResult => ResultId.HasValue;
}

public sealed class TechniqueSessionCompletionService(
    IPracticeReminderCoordinator practiceReminderCoordinator,
    IClinicalCareService clinicalCareService)
{
    public async Task CompleteStandardSessionAsync(
        IUserProgressService progress,
        INavigationService navigation,
        string itemKey,
        string moduleName,
        string pageName,
        DateTime sessionStartedAt,
        PracticeSessionCompletionState completion,
        int? preIntensity = null,
        bool deleteDraft = true,
        int? postIntensity = null,
        CancellationToken cancellationToken = default,
        Func<Task>? onSaved = null)
    {
        if (!completion.HasSavedResult)
        {
            completion.ResultId = await SaveSessionAsync(progress, itemKey, moduleName, pageName, sessionStartedAt,
                preIntensity, deleteDraft, postIntensity, cancellationToken);

            if (onSaved is not null)
            {
                await onSaved();
            }
        }

        await PracticeCompletionNavigator.NavigateAfterCompletionAsync(navigation, progress, itemKey, completion.ResultId);
        SyncReminderAsync(cancellationToken).FireAndForget();
    }

    private async Task<long> SaveSessionAsync(
        IUserProgressService progress,
        string itemKey,
        string moduleName,
        string pageName,
        DateTime sessionStartedAt,
        int? preIntensity,
        bool deleteDraft,
        int? postIntensity,
        CancellationToken cancellationToken)
    {
        int durationSeconds = Math.Max(0, (int)(DateTime.UtcNow - sessionStartedAt).TotalSeconds);
        string? draftJson = await progress.GetSessionDraftAsync(itemKey, cancellationToken);

        string? programType = null;
        int? programWeek = null;
        try
        {
            TherapyProgramStateDTO? program = await clinicalCareService.GetActiveProgramAsync(cancellationToken);
            if (program is { IsActive: true })
            {
                programType = program.ProgramType.ToString();
                programWeek = program.CurrentWeek;
            }
        }
        catch (Exception bestEffortError)
        {
            // Program context is optional for session results.
            BestEffort.Report(bestEffortError);
        }

        return await progress.RecordSessionOutcomeAsync(
            new SessionOutcomeRequest
            {
                ItemKey = itemKey,
                ModuleName = moduleName,
                PageName = pageName,
                DurationSeconds = durationSeconds,
                PayloadJson = draftJson,
                PreIntensity = preIntensity,
                PostIntensity = postIntensity is >= 0 and <= 10 ? postIntensity : null,
                ProgramType = programType,
                ProgramWeek = programWeek,
                DeleteDraft = deleteDraft
            },
            cancellationToken);
    }

    private async Task SyncReminderAsync(CancellationToken cancellationToken)
    {
        try
        {
            await practiceReminderCoordinator.SyncAsync(cancellationToken);
        }
        catch (Exception error)
        {
            BestEffort.Report(error);
        }
    }
}
