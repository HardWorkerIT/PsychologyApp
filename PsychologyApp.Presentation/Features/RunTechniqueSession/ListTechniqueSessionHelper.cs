using PsychologyApp.Application.UserProgress;
using PsychologyApp.Presentation.Shared.Navigation;

namespace PsychologyApp.Presentation.Features.RunTechniqueSession;

public sealed class ListTechniqueSessionHelper(
    TechniqueSessionCompletionService sessionCompletionService,
    IUserProgressService progress,
    INavigationService navigation)
{
    private readonly PracticeSessionCompletionState _completion = new();

    public bool HasSavedResult => _completion.HasSavedResult;

    public Task CompleteAsync(
        string techniqueKey,
        string moduleName,
        string pageName,
        DateTime sessionStartedAt,
        int? preIntensity = null,
        int? postIntensity = null,
        Func<Task>? onSaved = null) =>
        sessionCompletionService.CompleteStandardSessionAsync(
            progress,
            navigation,
            techniqueKey,
            moduleName,
            pageName,
            sessionStartedAt,
            _completion,
            preIntensity,
            postIntensity: postIntensity,
            onSaved: onSaved);
}
