using System.Windows.Input;
using PsychologyApp.Presentation.Shared.Common;
using Microsoft.Maui.ApplicationModel;

namespace PsychologyApp.Presentation.Pages.ManageProfile.ProfileSettings;

public partial class SettingsViewModel
{
    private bool _adsDisabled;
    private bool _personalizedAdsConsent;
    private bool _invalidAdCode;
    private string _adCode = string.Empty;

    public string AdsTitle => AppStrings.AdsTitle;
    public string AdsPersonalizationLabel => AppStrings.AdsPersonalizationLabel;
    public string AdsPersonalizationHelp => AppStrings.AdsPersonalizationHelp;
    public string AdsHelp => CanOfferAds ? AppStrings.AdsHelpActive : AppStrings.AdsHelp;
    public string AdsDisclosure => AppStrings.AdsDisclosure;
    public string AdsPrivacyPolicyText => AppStrings.AdsPrivacyPolicy;
    public bool CanOfferAds => OperatingSystem.IsAndroid() && AdvertisingConfiguration.CanOfferAds;
    public string AdCodePlaceholder => AppStrings.AdsCodePlaceholder;
    public string ApplyAdCodeText => AppStrings.AdsApplyCode;
    public bool AdsDisabled => _adsDisabled;
    public bool PersonalizedAdsConsent
    {
        get => _personalizedAdsConsent;
        set
        {
            if (_personalizedAdsConsent == value)
            {
                return;
            }

            _personalizedAdsConsent = value;
            OnPropertyChanged(nameof(PersonalizedAdsConsent));
            // Persist and notify immediately so the SDK cannot keep using a stale consent choice.
            UserPreferences.SetPersonalizedAdsConsent(value);
            OnSettingsChanged();
        }
    }
    public bool CanEnterAdCode => !_adsDisabled;
    public string AdCodeStatus => _adsDisabled ? AppStrings.AdsDisabledStatus : _invalidAdCode ? AppStrings.AdsInvalidCode : string.Empty;
    public bool HasAdCodeStatus => !string.IsNullOrEmpty(AdCodeStatus);
    public string AdCode
    {
        get => _adCode;
        set
        {
            if (SetProperty(ref _adCode, value ?? string.Empty) && _invalidAdCode)
            {
                _invalidAdCode = false;
                OnPropertyChanged(nameof(AdCodeStatus));
                OnPropertyChanged(nameof(HasAdCodeStatus));
            }
        }
    }

    private async Task ApplyAdCodeAsync()
    {
        if (_adsDisabled)
        {
            return;
        }

        string? code = AdCode;
        AdCode = string.Empty;
        if (string.IsNullOrWhiteSpace(code))
        {
            code = await _dialogService.PromptPasswordAsync(
                AdsTitle,
                string.Empty,
                AdCodePlaceholder,
                ApplyAdCodeText,
                AppStrings.Cancel);
        }

        if (code is null)
        {
            return;
        }

        bool accepted = AdvertisingCode.IsValid(code);
        _invalidAdCode = !accepted;
        if (accepted)
        {
            _adsDisabled = true;
            OnPropertyChanged(nameof(AdsDisabled));
            OnPropertyChanged(nameof(CanEnterAdCode));
            OnSettingsChanged();
        }
        OnPropertyChanged(nameof(AdCodeStatus));
        OnPropertyChanged(nameof(HasAdCodeStatus));
    }

    private Task ShowAdsDisclosureAsync() => _dialogService.ShowAsync(AdsTitle, AdsDisclosure);

    private async Task OpenAdsPrivacyPolicyAsync()
    {
        if (!AdvertisingConfiguration.IsPrivacyPolicyConfigured)
        {
            return;
        }

        await Browser.Default.OpenAsync(AdvertisingConfiguration.PrivacyPolicyUrl, BrowserLaunchMode.SystemPreferred);
    }
}
