using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Application.Models;
using PsychologyApp.Application.Conversation.Companion;

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.Techniques;

public partial class TechniquesViewModel
{
    public string PageTitle => AppStrings.PracticeHomeTitle;
    public string MyTechniquesLabel => AppStrings.PracticeMyTechniques;
    public string PracticeCatalogLabel => AppStrings.PracticeCatalog;
    public string PracticeCatalogHint => AppStrings.PracticeCatalogHint;
    public string PracticeFinderButtonText => AppStrings.PracticeFinderButton;
    public string PracticeFinderShortActionText => AppStrings.PracticeFinderShortAction;
    public string PracticeFinderAccessibilityHint => AppStrings.PracticeFinderAccessibilityHint;
    public string CreateButtonText => AppStrings.PracticeCreate;
    public string TodayForYouLabel => AppStrings.TodayForYou;
    public string PracticeEmptyTitle => AppStrings.PracticeEmptyTitle;
    public string PracticeEmptyBody => AppStrings.PracticeEmptyBody;
    public string LoadingText => AppStrings.PracticeLoadingText;
    public string LoadingMoreText => AppStrings.PracticeLoadingMoreText;
    public string FailedText => AppStrings.LoadFailed;
    public string RetryText => AppStrings.RetryQuestion;

    protected override void RefreshLocalizedProperties()
    {
        RebuildSections();
        Notify(
            nameof(PageTitle),
            nameof(MyTechniquesLabel),
            nameof(PracticeCatalogLabel),
            nameof(PracticeCatalogHint),
            nameof(PracticeFinderButtonText),
            nameof(PracticeFinderShortActionText),
            nameof(PracticeFinderAccessibilityHint),
            nameof(CreateButtonText),
            nameof(TodayForYouLabel),
            nameof(TodayReasonText),
            nameof(TodayActionText),
            nameof(EngagementNudgeText),
            nameof(ShowEngagementNudge),
            nameof(TherapyProgramBanner),
            nameof(HasTherapyProgramBanner),
            nameof(ClinicalRiskBanner),
            nameof(HasClinicalRiskBanner),
            nameof(IsPracticeAdPlacementAvailable),
            nameof(IsPracticeAdEligible),
            nameof(PracticeEmptyTitle),
            nameof(PracticeEmptyBody),
            nameof(LoadingText),
            nameof(LoadingMoreText),
            nameof(FailedText),
            nameof(RetryText));
        UpdateTodayRecommendation();
        ReloadLocalizedContent();
    }

    private static string GetNextStepLabel(SavedNextStep step)
    {
        if (step == SavedNextStep.MoodCheckIn)
        {
            return AppStrings.NextStepMood;
        }

        return GetTechniqueId(step) is { } techniqueId
            ? CompanionContent.TechniqueTitle(techniqueId, AppStrings.Language)
            : string.Empty;
    }

    private static TechniqueId? GetTechniqueId(SavedNextStep step) => step switch
    {
        SavedNextStep.Grounding => TechniqueId.Grounding,
        SavedNextStep.Breathing => TechniqueId.Breathing,
        SavedNextStep.SmallStep => TechniqueId.SmallStep,
        SavedNextStep.ThoughtRecord => TechniqueId.ThoughtRecord,
        SavedNextStep.ThoughtDefusion => TechniqueId.ThoughtDefusion,
        SavedNextStep.SelfCompassion => TechniqueId.SelfCompassion,
        SavedNextStep.BodyScan => TechniqueId.BodyScan,
        SavedNextStep.MuscleRelax => TechniqueId.MuscleRelax,
        SavedNextStep.BusyMind => TechniqueId.BusyMind,
        SavedNextStep.PauseBeforeReaction => TechniqueId.PauseBeforeReaction,
        SavedNextStep.ProblemSolving => TechniqueId.ProblemSolving,
        SavedNextStep.CheckTheFacts => TechniqueId.CheckTheFacts,
        SavedNextStep.WorryTime => TechniqueId.WorryTime,
        SavedNextStep.ImplementationIntention => TechniqueId.ImplementationIntention,
        SavedNextStep.SensoryComfort => TechniqueId.SensoryComfort,
        SavedNextStep.Balloons => TechniqueId.Balloons,
        _ => null
    };
}
