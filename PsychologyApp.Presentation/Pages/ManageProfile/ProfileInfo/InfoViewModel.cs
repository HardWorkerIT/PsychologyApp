using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.ViewModels;
using System.Windows.Input;
using Microsoft.Maui.ApplicationModel;

namespace PsychologyApp.Presentation.Pages.ManageProfile.ProfileInfo;

public class InfoViewModel : BaseViewModel
{
    public string PageTitle => AppStrings.OptionsAboutTitle;
    public string AboutBody => AppStrings.InfoAboutBody;
    public string Tagline => AppStrings.InfoTagline;
    public string PurposeTitle => AppStrings.InfoPurposeTitle;
    public string Disclaimer => AppStrings.InfoDisclaimer;
    public string PrivacyPolicyTitle => AppStrings.AdsPrivacyPolicy;
    public string AppVersionText => AppStrings.InfoAppVersion(AppInfo.Current.VersionString);

    public InfoViewModel(INavigationService navigationService)
    {
        ModuleName = AppStrings.ShellTabPractice;
        PageName = AppStrings.OptionsAboutTitle;
        BindNavigation(navigationService);
        BackCommand = new AsyncCommand(() => navigationService.GoBackAsync());
        OpenPrivacyPolicyCommand = new AsyncCommand(OpenPrivacyPolicyAsync);
    }

    public ICommand BackCommand { get; }
    public ICommand OpenPrivacyPolicyCommand { get; }

    private static async Task OpenPrivacyPolicyAsync()
    {
        if (AdvertisingConfiguration.IsPrivacyPolicyConfigured)
        {
            await Browser.Default.OpenAsync(AdvertisingConfiguration.PrivacyPolicyUrl, BrowserLaunchMode.SystemPreferred);
        }
    }

    protected override void RefreshLocalizedProperties()
    {
        Notify(
            nameof(PageTitle),
            nameof(AboutBody),
            nameof(Tagline),
            nameof(PurposeTitle),
            nameof(Disclaimer),
            nameof(PrivacyPolicyTitle),
            nameof(AppVersionText));
    }
}
