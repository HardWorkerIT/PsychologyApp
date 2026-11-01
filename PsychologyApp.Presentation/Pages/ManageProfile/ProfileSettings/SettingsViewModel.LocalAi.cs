using PsychologyApp.Application.Conversation.Companion;
using PsychologyApp.Presentation.Common;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using System.Windows.Input;

namespace PsychologyApp.Presentation.Pages.ManageProfile.ProfileSettings;

public partial class SettingsViewModel
{
    private readonly ILocalModelInstaller _localModelInstaller;
    private readonly IDeviceCapabilities _deviceCapabilities;
    private readonly ILanguageModel _languageModel;
    private readonly IDialogService? _dialogService;
    private string? _localModelStatusOverride;
    private bool _isLocalModelBusy;
    private CancellationTokenSource? _localModelInstallCancellation;

    public ICommand LocalModelActionCommand { get; }

    public bool IsOnDeviceAiSettingsVisible =>
        _localModelInstaller is not NullLocalModelInstaller;

    public bool IsLocalModelBusy
    {
        get => _isLocalModelBusy;
        private set
        {
            if (_isLocalModelBusy == value) return;
            _isLocalModelBusy = value;
            OnPropertyChanged(nameof(IsLocalModelBusy));
            OnPropertyChanged(nameof(LocalModelButtonText));
        }
    }

    public string LocalModelStatusText => _localModelStatusOverride ??
        (_localModelInstaller.IsInstalled ? AppStrings.SettingsLocalAiInstalled : AppStrings.SettingsLocalAiNotInstalled);

    public string LocalModelButtonText => _isLocalModelBusy
        ? _localModelInstallCancellation is null ? AppStrings.SettingsLocalAiDownloading : AppStrings.SettingsLocalAiCancel
        : _localModelInstaller.IsInstalled ? AppStrings.SettingsLocalAiDelete : AppStrings.SettingsLocalAiDownload;

    public string LocalModelSectionTitle => AppStrings.SettingsLocalAiSection;
    public string LocalModelDescription => AppStrings.SettingsLocalAiDescription;

    private async Task ManageLocalModelAsync()
    {
        if (_localModelInstallCancellation is not null)
        {
            _localModelInstallCancellation.Cancel();
            return;
        }

        if (IsLocalModelBusy || _dialogService is null)
        {
            return;
        }

        if (_localModelInstaller.IsInstalled)
        {
            bool confirmed = await _dialogService.AskAsync(
                AppStrings.SettingsLocalAiDeleteTitle,
                AppStrings.SettingsLocalAiDeleteMessage,
                AppStrings.Remove,
                AppStrings.Back);
            if (!confirmed) return;

            IsLocalModelBusy = true;
            try
            {
                await _languageModel.ReleaseAsync();
                await _localModelInstaller.DeleteAsync();
                _localModelStatusOverride = null;
                OnPropertyChanged(nameof(LocalModelStatusText));
                OnPropertyChanged(nameof(LocalModelButtonText));
            }
            catch
            {
                _localModelStatusOverride = AppStrings.SettingsLocalAiNotInstalled;
                OnPropertyChanged(nameof(LocalModelStatusText));
            }
            finally
            {
                IsLocalModelBusy = false;
            }

            return;
        }

        LocalModelEligibility eligibility = LocalModelEligibilityChecker.Check(
            _localModelInstaller.Manifest, _deviceCapabilities, _localModelInstaller.ExistingBytes);
        if (eligibility != LocalModelEligibility.Eligible)
        {
            _localModelStatusOverride = eligibility == LocalModelEligibility.NotEnoughMemory
                ? AppStrings.SettingsLocalAiNotEnoughMemory
                : AppStrings.SettingsLocalAiNotEnoughStorage;
            OnPropertyChanged(nameof(LocalModelStatusText));
            return;
        }

        string sizeGb = (_localModelInstaller.Manifest.TotalBytes / (1024d * 1024 * 1024)).ToString("0.0");
        bool accepted = await _dialogService.AskAsync(
            AppStrings.SettingsLocalAiConsentTitle,
            AppStrings.SettingsLocalAiConsentMessageFor(
                _localModelInstaller.Manifest.DisplayName,
                sizeGb,
                _localModelInstaller.Manifest.LicenseUrl),
            AppStrings.SettingsLocalAiDownload,
            AppStrings.Back);
        if (!accepted) return;

        using CancellationTokenSource installCancellation = new();
        _localModelInstallCancellation = installCancellation;
        IsLocalModelBusy = true;
        _localModelStatusOverride = AppStrings.SettingsLocalAiDownloading;
        OnPropertyChanged(nameof(LocalModelStatusText));
        try
        {
            Progress<ModelInstallProgress> progress = new(value =>
            {
                _localModelStatusOverride = AppStrings.SettingsLocalAiProgress((int)Math.Round(value.Fraction * 100));
                OnPropertyChanged(nameof(LocalModelStatusText));
            });
            await _localModelInstaller.InstallAsync(progress, installCancellation.Token);
            _localModelStatusOverride = null;
            OnPropertyChanged(nameof(LocalModelStatusText));
        }
        catch (OperationCanceledException) when (installCancellation.IsCancellationRequested)
        {
            _localModelStatusOverride = AppStrings.SettingsLocalAiNotInstalled;
            OnPropertyChanged(nameof(LocalModelStatusText));
        }
        catch
        {
            _localModelStatusOverride = AppStrings.SettingsLocalAiNotInstalled;
            OnPropertyChanged(nameof(LocalModelStatusText));
        }
        finally
        {
            _localModelInstallCancellation = null;
            IsLocalModelBusy = false;
            OnPropertyChanged(nameof(LocalModelButtonText));
        }
    }
}
