using System.Windows.Input;
using PsychologyApp.Presentation.Shared.Common;
using Microsoft.Maui.ApplicationModel;

namespace PsychologyApp.Presentation.Pages.ManageProfile.ProfileSettings;

public partial class SettingsViewModel
{
    private bool _adsDisabled;
    private bool _invalidAdCode;
    private string _adCode = string.Empty;
    private bool _adsConsentGranted;

    public string AdsTitle => AppStrings.AdsTitle;
    public string AdsHelp => AdvertisingConfiguration.CanOfferAds ? AppStrings.AdsHelpActive : AppStrings.AdsHelp;
    public string AdsConsentDetails => AppStrings.AdsConsentDetails;
    public string AdsConsentLabel => AppStrings.AdsConsentLabel;
    public string AdsPrivacyPolicyText => AppStrings.AdsPrivacyPolicy;
    public bool CanManageAdsConsent => AdvertisingConfiguration.CanOfferAds && !_adsDisabled;
    public bool AdsConsentGranted
    {
        get => _adsConsentGranted;
        set
        {
            if (_adsConsentGranted == value) return;
            _adsConsentGranted = value;
            OnPropertyChanged();
            OnSettingsChanged();
        }
    }
    public string AdCodePlaceholder => AppStrings.AdsCodePlaceholder;
    public string ApplyAdCodeText => AppStrings.AdsApplyCode;
    public bool AdsDisabled => _adsDisabled;
    public bool CanEnterAdCode => !_adsDisabled;
    public string AdCodeStatus => _adsDisabled ? AppStrings.AdsDisabledStatus : _invalidAdCode ? AppStrings.AdsInvalidCode : string.Empty;
    public string AdCode
    {
        get => _adCode;
        set => SetProperty(ref _adCode, value ?? string.Empty);
    }

    private void ApplyAdCode()
    {
        if (_adsDisabled) return;
        bool accepted = AdvertisingCode.IsValid(AdCode);
        AdCode = string.Empty;
        _invalidAdCode = !accepted;
        if (accepted)
        {
            _adsDisabled = true;
            _adsConsentGranted = false;
            OnPropertyChanged(nameof(AdsDisabled));
            OnPropertyChanged(nameof(CanEnterAdCode));
            OnPropertyChanged(nameof(CanManageAdsConsent));
            OnPropertyChanged(nameof(AdsConsentGranted));
            OnSettingsChanged();
        }
        OnPropertyChanged(nameof(AdCodeStatus));
    }

    private async Task OpenAdsPrivacyPolicyAsync()
    {
        if (!AdvertisingConfiguration.IsPrivacyPolicyConfigured)
        {
            return;
        }

        await Browser.Default.OpenAsync(AdvertisingConfiguration.PrivacyPolicyUrl, BrowserLaunchMode.SystemPreferred);
    }
}
