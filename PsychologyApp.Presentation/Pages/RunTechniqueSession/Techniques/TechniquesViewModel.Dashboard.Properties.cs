using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Entities.Technique;
using PsychologyApp.Presentation.Models.Practice.Techniques;
using PsychologyApp.Application.Models;

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.Techniques;

public partial class TechniquesViewModel
{
    public string TodayReasonText { get; private set; } = string.Empty;

    private bool _isReturning;
    /// <summary>Back after three days or more without a practice or a check-in. There is no "keep your streak" nudge: a count to
    /// lose is pressure, and pressure is the last thing a hard day needs.</summary>
    public bool IsReturning
    {
        get => _isReturning;
        private set
        {
            if (SetProperty(ref _isReturning, value))
            {
                NotifyEngagementNudge();
            }
        }
    }

    private bool _hasTodayDraft;
    public bool HasTodayDraft
    {
        get => _hasTodayDraft;
        private set
        {
            if (SetProperty(ref _hasTodayDraft, value))
            {
                OnPropertyChanged(nameof(TodayActionText));
            }
        }
    }

    public bool ShowComebackBanner => IsReturning;
    public bool ShowEngagementNudge => ShowComebackBanner;

    // The card above already names the practice, so the line does not repeat it.
    public string EngagementNudgeText => AppStrings.ComebackBanner;

    public string TodayActionText =>
        HasTodayDraft ? AppStrings.TechniqueContinueBadge : AppStrings.TodayStartPractice;

    private TechniqueItem? _todayTechniqueItem;
    public TechniqueItem? TodayTechniqueItem
    {
        get => _todayTechniqueItem;
        private set
        {
            if (SetProperty(ref _todayTechniqueItem, value))
            {
                NotifyEngagementNudge();
            }
        }
    }

    private int _streakDays;
    public int StreakDays
    {
        get => _streakDays;
        set
        {
            if (SetProperty(ref _streakDays, value))
            {
                UpdateTodayRecommendation();
            }
        }
    }

    private string _therapyProgramBanner = string.Empty;
    public string TherapyProgramBanner
    {
        get => _therapyProgramBanner;
        private set
        {
            if (SetProperty(ref _therapyProgramBanner, value))
            {
                OnPropertyChanged(nameof(HasTherapyProgramBanner));
            }
        }
    }

    public bool HasTherapyProgramBanner => !string.IsNullOrWhiteSpace(TherapyProgramBanner);

    private string _clinicalRiskBanner = string.Empty;
    private bool _clinicalDashboardLoaded;
    private bool _hasAnyActivity;
    private SavedNextStep? _selectedNextStep;
    private IReadOnlyList<SavedNextStep> _savedNextSteps = [];
    private bool _isNextStepChooserExpanded;

    public bool IsNextStepVisible =>
        _clinicalDashboardLoaded &&
        !HasClinicalRiskBanner &&
        (_hasAnyActivity || HasSavedNextStep);
    public bool IsPracticeFinderVisible => _clinicalDashboardLoaded && !HasClinicalRiskBanner;
    public bool HasNextStepSelection => _selectedNextStep.HasValue;
    public bool HasSavedNextStep => _savedNextSteps.Count > 0;
    public bool IsNextStepChooserExpanded => _isNextStepChooserExpanded;
    public bool IsNextStepPrimaryActionVisible =>
        (!_isNextStepChooserExpanded && !HasSavedNextStep) || (_isNextStepChooserExpanded && HasNextStepSelection);
    public bool IsNextStepChoiceToggleVisible =>
        _isNextStepChooserExpanded || HasNextStepSelection || HasSavedNextStep;
    public bool IsNextStepSaveActionEnabled => _selectedNextStep is { } selected
        && (_savedNextSteps.Contains(selected) || _savedNextSteps.Count < SavedNextStepCollection.MaximumCount);
    public bool IsNextStepLimitMessageVisible => _savedNextSteps.Count >= SavedNextStepCollection.MaximumCount
        && _selectedNextStep is { } selected
        && !_savedNextSteps.Contains(selected);

    public bool IsPracticeAdPlacementAvailable => OperatingSystem.IsAndroid()
        && AdvertisingConfiguration.CanOfferAds
        && IsDone
        && _clinicalDashboardLoaded
        && !HasClinicalRiskBanner
        && TechniqueGroups.Any(group => group.Count > 0)
        && !UserPreferencesStore.Load().AdsDisabled;

    public bool IsPracticeAdEligible => IsPracticeAdPlacementAvailable
        && AdvertisingConfiguration.CanRequestAds(UserPreferencesStore.Load());

    private void NotifyPracticeAdProperties()
    {
        OnPropertyChanged(nameof(IsPracticeAdPlacementAvailable));
        OnPropertyChanged(nameof(IsPracticeAdEligible));
    }

    public void RefreshPracticeAdEligibility()
    {
        _clinicalDashboardLoaded = false;
        OnPropertyChanged(nameof(IsPracticeFinderVisible));
        NotifyPracticeAdProperties();
        NotifyNextStepProperties();
    }

    public string ClinicalRiskBanner
    {
        get => _clinicalRiskBanner;
        private set
        {
            if (SetProperty(ref _clinicalRiskBanner, value))
            {
                OnPropertyChanged(nameof(HasClinicalRiskBanner));
                OnPropertyChanged(nameof(IsPracticeFinderVisible));
                NotifyPracticeAdProperties();
                NotifyNextStepProperties();
            }
        }
    }

    public bool HasClinicalRiskBanner => !string.IsNullOrWhiteSpace(ClinicalRiskBanner);

    private void NotifyNextStepProperties()
    {
        OnPropertyChanged(nameof(IsNextStepVisible));
        OnPropertyChanged(nameof(HasNextStepSelection));
        OnPropertyChanged(nameof(HasSavedNextStep));
        OnPropertyChanged(nameof(IsNextStepChooserExpanded));
        OnPropertyChanged(nameof(IsNextStepPrimaryActionVisible));
        OnPropertyChanged(nameof(IsNextStepChoiceToggleVisible));
        OnPropertyChanged(nameof(IsNextStepSaveActionEnabled));
        OnPropertyChanged(nameof(IsNextStepLimitMessageVisible));
        OnPropertyChanged(nameof(SavedQuickActions));
        OnPropertyChanged(nameof(NextStepCapacityText));
        OnPropertyChanged(nameof(NextStepLimitReachedText));
        OnPropertyChanged(nameof(NextStepSummaryText));
        OnPropertyChanged(nameof(NextStepPrimaryActionText));
        OnPropertyChanged(nameof(NextStepPrimaryActionHint));
        OnPropertyChanged(nameof(NextStepChoiceToggleText));
        OnPropertyChanged(nameof(NextStepSaveActionText));
        OnPropertyChanged(nameof(NextStepSaveActionHint));
        OnPropertyChanged(nameof(NextStepGroundingVariant));
        OnPropertyChanged(nameof(NextStepThoughtVariant));
        OnPropertyChanged(nameof(NextStepSmallStepVariant));
        OnPropertyChanged(nameof(NextStepMoodVariant));
        OnPropertyChanged(nameof(NextStepGroundingAccessibilityLabel));
        OnPropertyChanged(nameof(NextStepThoughtAccessibilityLabel));
        OnPropertyChanged(nameof(NextStepSmallStepAccessibilityLabel));
        OnPropertyChanged(nameof(NextStepMoodAccessibilityLabel));
    }

    private void NotifyEngagementNudge()
    {
        OnPropertyChanged(nameof(ShowComebackBanner));
        OnPropertyChanged(nameof(ShowEngagementNudge));
        OnPropertyChanged(nameof(EngagementNudgeText));
    }

    private TechniqueId _todayTechniqueId = TechniqueId.Grounding;
}
