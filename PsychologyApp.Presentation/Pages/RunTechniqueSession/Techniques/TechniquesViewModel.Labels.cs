using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Application.Models;

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.Techniques;

public partial class TechniquesViewModel
{
    public string PageTitle => AppStrings.PracticeHomeTitle;
    public string MyTechniquesLabel => AppStrings.PracticeMyTechniques;
    public string PracticeCatalogLabel => AppStrings.PracticeCatalog;
    public string PracticeCatalogHint => AppStrings.PracticeCatalogHint;
    public string PracticeFinderButtonText => AppStrings.PracticeFinderButton;
    public string PracticeFinderAccessibilityHint => AppStrings.PracticeFinderAccessibilityHint;
    public string CreateButtonText => AppStrings.PracticeCreate;
    public string TodayForYouLabel => AppStrings.TodayForYou;
    public string NextStepTitle => AppStrings.NextStepTitle;
    public string NextStepPrompt => AppStrings.NextStepPrompt;
    public string NextStepSummaryText => HasSavedNextStep
        ? AppStrings.NextStepSavedSummary(_savedNextSteps.Count)
        : NextStepPrompt;
    public IReadOnlyList<SavedNextStepQuickAction> SavedQuickActions => _savedNextSteps
        .Select(step => new SavedNextStepQuickAction(step, GetNextStepLabel(step), GetNextStepLabel(step), AppStrings.NextStepOpenHint))
        .ToArray();
    public string NextStepCapacityText => AppStrings.NextStepCapacity(_savedNextSteps.Count);
    public string NextStepLimitReachedText => AppStrings.NextStepLimitReached;
    public string NextStepGroundingLabel => AppStrings.NextStepGrounding;
    public string NextStepThoughtLabel => AppStrings.NextStepThought;
    public string NextStepSmallStepLabel => AppStrings.NextStepSmallStep;
    public string NextStepMoodLabel => AppStrings.NextStepMood;
    public string NextStepPrimaryActionText => HasNextStepSelection ? AppStrings.NextStepStart : AppStrings.NextStepChoose;
    public string NextStepPrimaryActionHint => HasNextStepSelection ? AppStrings.NextStepOpenHint : AppStrings.NextStepChooseHint;
    public string NextStepChoiceToggleText => IsNextStepChooserExpanded ? AppStrings.NextStepCollapse : AppStrings.NextStepChange;
    public string NextStepSelectionHint => AppStrings.NextStepSelectHint;
    public string NextStepToggleHint => AppStrings.NextStepToggleHint;
    public string NextStepSaveActionHint => _selectedNextStep is { } selected && _savedNextSteps.Contains(selected)
        ? AppStrings.NextStepRemoveHint
        : IsNextStepLimitMessageVisible ? AppStrings.NextStepLimitReached : AppStrings.NextStepSaveHint;
    public string NextStepSaveActionText => _selectedNextStep is { } selected && _savedNextSteps.Contains(selected)
        ? AppStrings.NextStepRemove
        : AppStrings.NextStepSave;
    public string NextStepGroundingVariant => _selectedNextStep == SavedNextStep.Grounding ? "Primary" : "Secondary";
    public string NextStepThoughtVariant => _selectedNextStep == SavedNextStep.ThoughtRecord ? "Primary" : "Secondary";
    public string NextStepSmallStepVariant => _selectedNextStep == SavedNextStep.SmallStep ? "Primary" : "Secondary";
    public string NextStepMoodVariant => _selectedNextStep == SavedNextStep.MoodCheckIn ? "Primary" : "Secondary";
    public string NextStepGroundingAccessibilityLabel => GetNextStepAccessibilityLabel(SavedNextStep.Grounding);
    public string NextStepThoughtAccessibilityLabel => GetNextStepAccessibilityLabel(SavedNextStep.ThoughtRecord);
    public string NextStepSmallStepAccessibilityLabel => GetNextStepAccessibilityLabel(SavedNextStep.SmallStep);
    public string NextStepMoodAccessibilityLabel => GetNextStepAccessibilityLabel(SavedNextStep.MoodCheckIn);
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
            nameof(PracticeFinderAccessibilityHint),
            nameof(CreateButtonText),
            nameof(TodayForYouLabel),
            nameof(NextStepTitle),
            nameof(NextStepPrompt),
            nameof(NextStepSummaryText),
            nameof(SavedQuickActions),
            nameof(NextStepCapacityText),
            nameof(NextStepLimitReachedText),
            nameof(NextStepGroundingLabel),
            nameof(NextStepThoughtLabel),
            nameof(NextStepSmallStepLabel),
            nameof(NextStepMoodLabel),
            nameof(NextStepPrimaryActionText),
            nameof(NextStepPrimaryActionHint),
            nameof(NextStepChoiceToggleText),
            nameof(NextStepSelectionHint),
            nameof(NextStepToggleHint),
            nameof(NextStepSaveActionHint),
            nameof(NextStepSaveActionText),
            nameof(NextStepGroundingAccessibilityLabel),
            nameof(NextStepThoughtAccessibilityLabel),
            nameof(NextStepSmallStepAccessibilityLabel),
            nameof(NextStepMoodAccessibilityLabel),
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

    private static string GetNextStepLabel(SavedNextStep step) => step switch
    {
        SavedNextStep.Grounding => AppStrings.NextStepGrounding,
        SavedNextStep.ThoughtRecord => AppStrings.NextStepThought,
        SavedNextStep.SmallStep => AppStrings.NextStepSmallStep,
        SavedNextStep.MoodCheckIn => AppStrings.NextStepMood,
        _ => string.Empty
    };

    private string GetNextStepAccessibilityLabel(SavedNextStep step)
    {
        string label = GetNextStepLabel(step);
        return _selectedNextStep == step ? AppStrings.NextStepChoiceSelected(label) : label;
    }
}

public sealed record SavedNextStepQuickAction(
    SavedNextStep Step,
    string Label,
    string AccessibilityLabel,
    string AccessibilityHint);
