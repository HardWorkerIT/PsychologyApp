using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Entities.Technique;
using PsychologyApp.Presentation.Models.Practice.Techniques;

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
    private bool _adsConsentPromptDismissed;

    public bool IsPracticeAdPlacementAvailable => OperatingSystem.IsAndroid()
        && AdvertisingConfiguration.CanOfferAds
        && IsDone
        && _clinicalDashboardLoaded
        && !HasClinicalRiskBanner
        && TechniqueGroups.Any(group => group.Count > 0)
        && !UserPreferencesStore.Load().AdsDisabled;

    public bool IsPracticeAdEligible => IsPracticeAdPlacementAvailable
        && AdvertisingConfiguration.CanRequestAds(UserPreferencesStore.Load());

    public bool IsPracticeAdConsentPromptVisible => IsPracticeAdPlacementAvailable
        && !UserPreferencesStore.Load().AdsConsentGranted
        && !_adsConsentPromptDismissed;

    public bool IsPracticeAdPlacementVisible => IsPracticeAdEligible || IsPracticeAdConsentPromptVisible;

    public string AdsConsentPromptTitle => AppStrings.AdsConsentPromptTitle;
    public string AdsConsentPromptAllowText => AppStrings.AdsConsentPromptAllow;
    public string AdsConsentPromptNotNowText => AppStrings.AdsConsentPromptNotNow;
    public string AdsConsentDetails => AppStrings.AdsConsentDetails;
    public string AdsPrivacyPolicyText => AppStrings.AdsPrivacyPolicy;

    private void NotifyPracticeAdProperties()
    {
        OnPropertyChanged(nameof(IsPracticeAdPlacementAvailable));
        OnPropertyChanged(nameof(IsPracticeAdEligible));
        OnPropertyChanged(nameof(IsPracticeAdConsentPromptVisible));
        OnPropertyChanged(nameof(IsPracticeAdPlacementVisible));
    }

    public void RefreshPracticeAdEligibility()
    {
        _clinicalDashboardLoaded = false;
        NotifyPracticeAdProperties();
    }

    public string ClinicalRiskBanner
    {
        get => _clinicalRiskBanner;
        private set
        {
            if (SetProperty(ref _clinicalRiskBanner, value))
            {
                OnPropertyChanged(nameof(HasClinicalRiskBanner));
                NotifyPracticeAdProperties();
            }
        }
    }

    public bool HasClinicalRiskBanner => !string.IsNullOrWhiteSpace(ClinicalRiskBanner);

    private void NotifyEngagementNudge()
    {
        OnPropertyChanged(nameof(ShowComebackBanner));
        OnPropertyChanged(nameof(ShowEngagementNudge));
        OnPropertyChanged(nameof(EngagementNudgeText));
    }

    private TechniqueId _todayTechniqueId = TechniqueId.Grounding;
}
