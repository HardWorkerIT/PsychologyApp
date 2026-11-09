using System.Windows.Input;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Pages.ManageProfile.ProfileSettings;

public partial class SettingsViewModel
{
    private bool _adsDisabled;
    private bool _invalidAdCode;
    private string _adCode = string.Empty;

    public string AdsTitle => AppStrings.AdsTitle;
    public string AdsHelp => AppStrings.AdsHelp;
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
            OnPropertyChanged(nameof(AdsDisabled));
            OnPropertyChanged(nameof(CanEnterAdCode));
            OnSettingsChanged();
        }
        OnPropertyChanged(nameof(AdCodeStatus));
    }
}
