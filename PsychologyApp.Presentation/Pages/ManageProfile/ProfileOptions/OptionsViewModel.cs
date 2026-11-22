using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.Services.Donations;
using System.Windows.Input;

namespace PsychologyApp.Presentation.Pages.ManageProfile.ProfileOptions;

public class OptionsViewModel : BaseViewModel
{
    private readonly IDonationSupportService _donationSupportService;

    public ICommand OpenAboutPageCommand { get; private set; } = default!;
    public ICommand OpenFeedbackPageCommand { get; private set; } = default!;
    public ICommand OpenSettingsPageCommand { get; private set; } = default!;
    public ICommand OpenCrisisHubCommand { get; private set; } = default!;
    public ICommand OpenDataBackupCommand { get; private set; } = default!;
    public ICommand OpenDonationCommand { get; private set; } = default!;

    public ICommand BackCommand { get; private set; } = default!;

    public string PageTitle => AppStrings.OptionsTitle;
    public string AppSectionTitle => AppStrings.OptionsAppSection;
    public string SafetySectionTitle => AppStrings.OptionsSafetySection;
    public string SupportSectionTitle => AppStrings.OptionsSupportSection;
    public string SettingsTitle => AppStrings.OptionsSettingsTitle;
    public string SettingsSubtitle => AppStrings.OptionsSettingsSubtitle;
    public string DataBackupSubtitle => AppStrings.OptionsDataSubtitle;
    public string CrisisTitle => AppStrings.OptionsCrisisTitle;
    public string CrisisSubtitle => AppStrings.OptionsCrisisSubtitle;
    public string DonationTitle => AppStrings.OptionsDonateTitle;
    public string DonationSubtitle => AppStrings.DonateBody;
    public bool CanSupportProject => _donationSupportService.CanSupportProject;
    public string AboutTitle => AppStrings.OptionsAboutTitle;
    public string FeedbackTitle => AppStrings.OptionsFeedbackTitle;
    public string FeedbackSubtitle => AppStrings.OptionsFeedbackSubtitle;
    public string PrivacyNote => AppStrings.OptionsPrivacyNote;

    public string DataBackupTitle => AppStrings.DataBackupTitle;

    public OptionsViewModel(INavigationService navigationService, IDonationSupportService donationSupportService)
    {
        _donationSupportService = donationSupportService;
        BindNavigation(navigationService);

        OpenAboutPageCommand = new AsyncCommand(() => navigationService.GoToInfoAsync());
        OpenFeedbackPageCommand = new AsyncCommand(() => navigationService.GoToFormAsync());
        OpenSettingsPageCommand = new AsyncCommand(() => navigationService.GoToSettingsAsync());
        OpenCrisisHubCommand = new AsyncCommand(() => navigationService.GoToCrisisHubAsync());
        OpenDataBackupCommand = new AsyncCommand(() => navigationService.GoToDataBackupAsync());
        BackCommand = new AsyncCommand(() => navigationService.GoBackAsync());
        OpenDonationCommand = new AsyncCommand(_donationSupportService.ShowTransferInstructionsAsync);
    }

    protected override void RefreshLocalizedProperties()
    {
        Notify(
            nameof(PageTitle),
            nameof(AppSectionTitle),
            nameof(SafetySectionTitle),
            nameof(SupportSectionTitle),
            nameof(SettingsTitle),
            nameof(SettingsSubtitle),
            nameof(DataBackupSubtitle),
            nameof(CrisisTitle),
            nameof(CrisisSubtitle),
            nameof(AboutTitle),
            nameof(FeedbackTitle),
            nameof(FeedbackSubtitle),
            nameof(PrivacyNote),
            nameof(DonationTitle),
            nameof(DonationSubtitle),
            nameof(DataBackupTitle));
    }
}
