using System.Collections.ObjectModel;
using System.Windows.Input;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Services.Clipboard;
using PsychologyApp.Presentation.Shared.Services.Security;
using PsychologyApp.Presentation.Shared.ViewModels;

namespace PsychologyApp.Presentation.Pages.ManageProfile.AppLock;

/// <summary>
/// Keeps personal content behind an app PIN. The system credential is only used to recover a forgotten PIN; an emergency call
/// remains available without unlocking.
/// </summary>
public sealed class AppLockViewModel : BaseViewModel
{
    private readonly IDeviceAuthenticator _authenticator;
    private readonly IAppPinCredentialStore _pinCredentialStore;
    private readonly TimeProvider _clock;
    private readonly TaskCompletionSource _unlocked = new(TaskCreationOptions.RunContinuationsAsynchronously);
    private Task? _initialization;
    private EntryState _state;
    private string _pinInput = string.Empty;
    private string? _pendingPin;
    private string? _statusText;
    private bool _isBusy;
    private bool _checkingPin;
    private bool _isResetting;
    private bool _showDialFailure;
    private long _cooldownStarted;
    private TimeSpan _cooldownDuration;
    private int _cooldownSeconds;

    private enum EntryState
    {
        Uninitialized,
        Create,
        Confirm,
        Unlock,
        RecoveryRequired
    }

    public AppLockViewModel(IDeviceAuthenticator authenticator, IAppPinCredentialStore pinCredentialStore,
        IAppClipboardService clipboard, TimeProvider? clock = null)
    {
        _authenticator = authenticator;
        _pinCredentialStore = pinCredentialStore;
        _clock = clock ?? TimeProvider.System;
        SubmitPinCommand = new AsyncCommand(SubmitPinAsync);
        AddPinDigitCommand = new Command<string?>(AppendPinDigit);
        DeletePinDigitCommand = new Command(DeletePinDigit);
        RecoverPinCommand = new AsyncCommand(RecoverPinAsync);
        RetryPinStorageCommand = new AsyncCommand(RetryPinStorageAsync);
        OpenSecuritySettingsCommand = new AsyncCommand(OpenSecuritySettingsAsync);
        CallEmergencyCommand = new AsyncCommand(CallEmergencyAsync);
        CopyNumberCommand = new AsyncCommand(() => ShowDialFailure
            ? clipboard.CopyWithFeedbackAsync(Lines.Emergency, AppStrings.QuoteCopied)
            : Task.CompletedTask);
    }

    // The same numbers as the crisis screen: those of the country the phone is in.
    private readonly string? _country = DeviceCountry.Code;
    private CrisisLines.Lines Lines => CrisisLines.For(_country);

    /// <summary>Completes once a PIN is verified or created.</summary>
    public Task Unlocked => _unlocked.Task;

    public string TitleText => _state is EntryState.Create or EntryState.Confirm
        ? AppStrings.AppLockSetupTitle
        : AppStrings.AppLockTitle;

    public string LeadText => _state switch
    {
        EntryState.Create => _isResetting ? AppStrings.AppLockPinResetLead : AppStrings.AppLockSetupLead,
        EntryState.Confirm => AppStrings.AppLockConfirmLead,
        EntryState.Unlock => AppStrings.AppLockLead,
        EntryState.RecoveryRequired => AppStrings.AppLockStorageRetryLead,
        _ => AppStrings.SkeletonLoadingLabel
    };

    public string PinPromptText => AppStrings.AppLockPinPrompt;
    public string PinProgressText => AppStrings.AppLockPinProgress(_pinInput.Length, AppPinPolicy.Length);
    public string RecoveryText => AppStrings.AppLockForgotPin;
    public string RetryStorageText => AppStrings.RetryQuestion;
    public string OpenSecuritySettingsText => AppStrings.AppLockOpenSecuritySettings;
    public string RecoveryUnavailableText => _authenticator.Availability == DeviceUnlockAvailability.NoScreenLock
        ? AppStrings.AppLockNoScreenLock : AppStrings.AppLockRecoveryUnsupported;
    public string PinEntryDescription => AppStrings.AppLockPinEntry;
    public string DeletePinDigitText => AppStrings.AppLockDeletePinDigit;
    public string? StatusText => _checkingPin ? AppStrings.AppLockCheckingPin
        : IsPinCoolingDown ? AppStrings.AppLockPinLockedOut(_cooldownSeconds) : _statusText;
    public bool HasStatus => !string.IsNullOrWhiteSpace(StatusText);
    public bool IsCheckingPin => _checkingPin;
    public bool IsPinCoolingDown => _cooldownSeconds > 0;
    public bool IsInitialized => _state != EntryState.Uninitialized;
    public bool IsPinEntryVisible => _state is EntryState.Create or EntryState.Confirm or EntryState.Unlock;
    public bool CanEnterPin => IsPinEntryVisible && !_isBusy && !IsPinCoolingDown;
    public bool CanDeletePin => CanEnterPin && _pinInput.Length > 0;
    public ObservableCollection<bool> PinCells { get; } = new(Enumerable.Repeat(false, AppPinPolicy.Length));
    public bool HasSystemRecovery =>
        _authenticator.Availability == DeviceUnlockAvailability.Available
        && _state is EntryState.Unlock or EntryState.RecoveryRequired;
    public bool ShowRecoveryUnavailable => _state is EntryState.Unlock or EntryState.RecoveryRequired
        && _authenticator.Availability != DeviceUnlockAvailability.Available;
    public bool CanOpenSecuritySettings => ShowRecoveryUnavailable
        && _authenticator.Availability == DeviceUnlockAvailability.NoScreenLock
        && _authenticator.CanOpenSecuritySettings;
    public bool ShowRetryStorage => _state == EntryState.RecoveryRequired;
    public bool CanUseRecoveryActions => !_isBusy;
    public bool CanSubmitPin => CanEnterPin && AppPinPolicy.IsValid(_pinInput);

    public string PinInput
    {
        get => _pinInput;
        set
        {
            string digits = new((value ?? string.Empty).Where(char.IsAsciiDigit).Take(AppPinPolicy.Length).ToArray());
            if (_pinInput == digits)
            {
                return;
            }

            _pinInput = digits;
            for (int index = 0; index < PinCells.Count; index++)
            {
                PinCells[index] = index < digits.Length;
            }

            OnPropertyChanged();
            OnPropertyChanged(nameof(PinProgressText));
            OnPropertyChanged(nameof(CanDeletePin));
            OnPropertyChanged(nameof(CanSubmitPin));
        }
    }

    public string CallEmergencyText => AppStrings.CrisisHubCallEmergency(Lines.Emergency);
    public bool ShowDialFailure => _showDialFailure;
    public string DialFailureText => AppStrings.CrisisDialUnavailable(Lines.Emergency);
    public string CopyNumberText => AppStrings.DonateCopyNumber;

    public ICommand SubmitPinCommand { get; }
    public ICommand AddPinDigitCommand { get; }
    public ICommand DeletePinDigitCommand { get; }
    public ICommand RecoverPinCommand { get; }
    public ICommand RetryPinStorageCommand { get; }
    public ICommand OpenSecuritySettingsCommand { get; }
    public ICommand CallEmergencyCommand { get; }
    public ICommand CopyNumberCommand { get; }

    public Task InitializeAsync() => _initialization ??= InitializeCoreAsync();

    protected override void RefreshLocalizedProperties() =>
        Notify(
            nameof(TitleText),
            nameof(LeadText),
            nameof(PinPromptText),
            nameof(PinProgressText),
            nameof(RecoveryText),
            nameof(RetryStorageText),
            nameof(OpenSecuritySettingsText),
            nameof(RecoveryUnavailableText),
            nameof(PinEntryDescription),
            nameof(DeletePinDigitText),
            nameof(CallEmergencyText),
            nameof(DialFailureText),
            nameof(CopyNumberText),
            nameof(StatusText));

    internal void RefreshPinCooldown()
    {
        int seconds = _state == EntryState.Unlock && _cooldownDuration > TimeSpan.Zero
            ? (int)Math.Ceiling(Math.Max(0, (_cooldownDuration - _clock.GetElapsedTime(_cooldownStarted)).TotalSeconds))
            : 0;
        if (seconds == _cooldownSeconds)
        {
            return;
        }

        bool wasCoolingDown = IsPinCoolingDown;
        _cooldownSeconds = seconds;
        Notify(nameof(StatusText), nameof(HasStatus));
        if (IsPinCoolingDown != wasCoolingDown)
        {
            Notify(nameof(IsPinCoolingDown), nameof(CanEnterPin), nameof(CanDeletePin), nameof(CanSubmitPin));
        }
    }

    private async Task CallEmergencyAsync()
    {
        bool opened = await PhoneCall.TryDialAsync(Lines.Emergency);
        SetProperty(ref _showDialFailure, !opened, nameof(ShowDialFailure));
    }

    private async Task InitializeCoreAsync()
    {
        try
        {
            _state = await _pinCredentialStore.HasPinAsync() ? EntryState.Unlock : EntryState.Create;
        }
        catch (Exception ex)
        {
            BestEffort.Report(ex);
            _state = EntryState.RecoveryRequired;
        }

        RefreshEntryState();
    }

    internal void RefreshRecoveryAvailability() =>
        Notify(nameof(HasSystemRecovery), nameof(ShowRecoveryUnavailable), nameof(CanOpenSecuritySettings), nameof(RecoveryUnavailableText));

    private void RefreshEntryState()
    {
        Notify(nameof(IsInitialized), nameof(TitleText), nameof(LeadText), nameof(IsPinEntryVisible));
        RefreshRecoveryAvailability();
        RefreshInteractionState();
    }

    private void RefreshInteractionState() =>
        Notify(nameof(CanEnterPin), nameof(CanDeletePin), nameof(CanSubmitPin), nameof(CanUseRecoveryActions),
            nameof(IsCheckingPin), nameof(StatusText), nameof(HasStatus));

    private void AppendPinDigit(string? digit)
    {
        if (!CanEnterPin
            || digit is not { Length: 1 } value
            || !char.IsAsciiDigit(value[0])
            || _pinInput.Length >= AppPinPolicy.Length)
        {
            return;
        }

        ClearStatus();
        PinInput = _pinInput + value;
        if (_pinInput.Length == AppPinPolicy.Length)
        {
            SubmitPinCommand.Execute(null);
        }
    }

    private void DeletePinDigit()
    {
        if (!CanDeletePin)
        {
            return;
        }

        ClearStatus();
        PinInput = _pinInput[..^1];
    }

    private void ClearStatus()
    {
        if (_statusText is null)
        {
            return;
        }

        _statusText = null;
        OnPropertyChanged(nameof(StatusText));
        OnPropertyChanged(nameof(HasStatus));
    }

    private async Task SubmitPinAsync()
    {
        if (!CanSubmitPin)
        {
            return;
        }

        string pin = _pinInput;
        _isBusy = true;
        _checkingPin = _state != EntryState.Create;
        _statusText = null;
        RefreshInteractionState();

        try
        {
            if (_state == EntryState.Create)
            {
                _pendingPin = pin;
                _state = EntryState.Confirm;
                Notify(nameof(TitleText), nameof(LeadText));
                return;
            }

            if (_state == EntryState.Confirm)
            {
                if (!string.Equals(_pendingPin, pin, StringComparison.Ordinal))
                {
                    _pendingPin = null;
                    _state = EntryState.Create;
                    _statusText = AppStrings.AppLockPinMismatch;
                    Notify(nameof(TitleText), nameof(LeadText));
                    return;
                }

                await _pinCredentialStore.SetPinAsync(pin);
                _pendingPin = null;
                _unlocked.TrySetResult();
                return;
            }

            if (_state == EntryState.Unlock)
            {
                AppPinVerificationResult result = await _pinCredentialStore.VerifyPinAsync(pin);
                if (result.IsValid)
                {
                    _unlocked.TrySetResult();
                    return;
                }

                if (result.IsLockedOut)
                {
                    _cooldownStarted = _clock.GetTimestamp();
                    _cooldownDuration = result.RetryAfter;
                    RefreshPinCooldown();
                }
                else
                {
                    _statusText = AppStrings.AppLockPinIncorrect;
                }
            }
        }
        catch (Exception ex)
        {
            BestEffort.Report(ex);
            _pendingPin = null;
            _state = EntryState.RecoveryRequired;
            RefreshEntryState();
        }
        finally
        {
            PinInput = string.Empty;
            _isBusy = false;
            _checkingPin = false;
            RefreshInteractionState();
        }
    }

    private async Task RetryPinStorageAsync()
    {
        if (_isBusy || !ShowRetryStorage)
        {
            return;
        }

        _isBusy = _checkingPin = true;
        _statusText = null;
        RefreshInteractionState();
        try
        {
            // A missing record after a read failure is ambiguous. A retry may restore PIN entry, never authorize a new PIN.
            if (await _pinCredentialStore.HasPinAsync())
            {
                _state = EntryState.Unlock;
                RefreshEntryState();
            }
            else
            {
                _statusText = AppStrings.AppLockStorageStillUnavailable;
            }
        }
        catch (Exception ex)
        {
            BestEffort.Report(ex);
            _statusText = AppStrings.AppLockStorageStillUnavailable;
        }
        finally
        {
            _isBusy = _checkingPin = false;
            RefreshInteractionState();
        }
    }

    private async Task OpenSecuritySettingsAsync()
    {
        if (!_isBusy && CanOpenSecuritySettings && !await _authenticator.TryOpenSecuritySettingsAsync())
        {
            _statusText = AppStrings.AppLockPhoneUnlockUnavailable;
            Notify(nameof(StatusText), nameof(HasStatus));
        }
    }

    private async Task RecoverPinAsync()
    {
        RefreshRecoveryAvailability();
        if (_isBusy || !HasSystemRecovery)
        {
            return;
        }

        _isBusy = true;
        RefreshInteractionState();
        try
        {
            DeviceUnlockResult result = await _authenticator.AuthenticateAsync(
                AppStrings.AppLockPromptTitle,
                AppStrings.AppLockPromptSubtitle);
            if (result == DeviceUnlockResult.Passed)
            {
                _pendingPin = null;
                _isResetting = true;
                _state = EntryState.Create;
                _statusText = null;
                _cooldownDuration = TimeSpan.Zero;
                RefreshPinCooldown();
                PinInput = string.Empty;
                RefreshEntryState();
            }
            else if (result == DeviceUnlockResult.CannotAsk)
            {
                _statusText = AppStrings.AppLockPhoneUnlockUnavailable;
                Notify(nameof(StatusText), nameof(HasStatus));
            }
        }
        finally
        {
            _isBusy = false;
            RefreshInteractionState();
        }
    }
}
