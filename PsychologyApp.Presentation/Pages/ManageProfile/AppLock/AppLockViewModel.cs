using System.Collections.ObjectModel;
using System.Windows.Input;
using PsychologyApp.Presentation.Shared.Common;
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
    private readonly TaskCompletionSource _unlocked = new(TaskCreationOptions.RunContinuationsAsynchronously);
    private Task? _initialization;
    private EntryState _state;
    private string _pinInput = string.Empty;
    private string? _pendingPin;
    private string? _statusText;
    private bool _isBusy;
    private bool _isResetting;

    private enum EntryState
    {
        Uninitialized,
        Create,
        Confirm,
        Unlock,
        RecoveryRequired
    }

    public AppLockViewModel(IDeviceAuthenticator authenticator, IAppPinCredentialStore pinCredentialStore)
    {
        _authenticator = authenticator;
        _pinCredentialStore = pinCredentialStore;
        SubmitPinCommand = new AsyncCommand(SubmitPinAsync);
        AddPinDigitCommand = new Command<string?>(AppendPinDigit);
        DeletePinDigitCommand = new Command(DeletePinDigit);
        RecoverPinCommand = new AsyncCommand(RecoverPinAsync);
        CallEmergencyCommand = new AsyncCommand(() => PhoneCall.DialAsync(Lines.Emergency));
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
        EntryState.RecoveryRequired => AppStrings.AppLockPinStorageError,
        _ => string.Empty
    };

    public string PinPromptText => AppStrings.AppLockPinPrompt;
    public string PinProgressText => AppStrings.AppLockPinProgress(_pinInput.Length, AppPinPolicy.Length);
    public string RecoveryText => AppStrings.AppLockForgotPin;
    public string PinEntryDescription => AppStrings.AppLockPinEntry;
    public string DeletePinDigitText => AppStrings.AppLockDeletePinDigit;
    public string? StatusText => _statusText;
    public bool HasStatus => !string.IsNullOrWhiteSpace(_statusText);
    public bool IsInitialized => _state != EntryState.Uninitialized;
    public bool IsPinEntryVisible => _state is EntryState.Create or EntryState.Confirm or EntryState.Unlock;
    public bool CanEnterPin => IsPinEntryVisible && !_isBusy;
    public bool CanDeletePin => CanEnterPin && _pinInput.Length > 0;
    public ObservableCollection<bool> PinCells { get; } = new(Enumerable.Repeat(false, AppPinPolicy.Length));
    public bool HasSystemRecovery =>
        _authenticator.Availability != DeviceUnlockAvailability.Unsupported
        && _state is EntryState.Unlock or EntryState.RecoveryRequired;
    public bool CanSubmitPin => IsPinEntryVisible && !_isBusy && AppPinPolicy.IsValid(_pinInput);

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

    public string CallEmergencyText => AppStrings.AppLockEmergencyCall;

    public ICommand SubmitPinCommand { get; }
    public ICommand AddPinDigitCommand { get; }
    public ICommand DeletePinDigitCommand { get; }
    public ICommand RecoverPinCommand { get; }
    public ICommand CallEmergencyCommand { get; }

    public Task InitializeAsync() => _initialization ??= InitializeCoreAsync();

    protected override void RefreshLocalizedProperties() =>
        Notify(
            nameof(TitleText),
            nameof(LeadText),
            nameof(PinPromptText),
            nameof(PinProgressText),
            nameof(RecoveryText),
            nameof(PinEntryDescription),
            nameof(DeletePinDigitText),
            nameof(CallEmergencyText));

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
            _statusText = AppStrings.AppLockPinStorageError;
        }

        OnPropertyChanged(nameof(IsInitialized));
        Notify(
            nameof(TitleText),
            nameof(LeadText),
            nameof(IsPinEntryVisible),
            nameof(CanEnterPin),
            nameof(CanDeletePin),
            nameof(HasSystemRecovery),
            nameof(StatusText),
            nameof(HasStatus));
    }

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
        PinInput = string.Empty;
        _isBusy = true;
        OnPropertyChanged(nameof(CanEnterPin));
        OnPropertyChanged(nameof(CanDeletePin));
        OnPropertyChanged(nameof(CanSubmitPin));
        _statusText = null;
        OnPropertyChanged(nameof(StatusText));
        OnPropertyChanged(nameof(HasStatus));

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
                    Notify(nameof(TitleText), nameof(LeadText), nameof(StatusText), nameof(HasStatus));
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

                _statusText = result.IsLockedOut
                    ? AppStrings.AppLockPinLockedOut(Math.Max(1, (int)Math.Ceiling(result.RetryAfter.TotalSeconds)))
                    : AppStrings.AppLockPinIncorrect;
                OnPropertyChanged(nameof(StatusText));
                OnPropertyChanged(nameof(HasStatus));
            }
        }
        catch (Exception ex)
        {
            BestEffort.Report(ex);
            _state = EntryState.RecoveryRequired;
            _statusText = AppStrings.AppLockPinStorageError;
            Notify(nameof(TitleText), nameof(LeadText), nameof(IsPinEntryVisible), nameof(CanEnterPin), nameof(CanDeletePin), nameof(HasSystemRecovery), nameof(StatusText), nameof(HasStatus));
        }
        finally
        {
            _isBusy = false;
            OnPropertyChanged(nameof(CanEnterPin));
            OnPropertyChanged(nameof(CanDeletePin));
            OnPropertyChanged(nameof(CanSubmitPin));
            PinInput = string.Empty;
        }
    }

    private async Task RecoverPinAsync()
    {
        if (_isBusy || !HasSystemRecovery)
        {
            return;
        }

        _isBusy = true;
        OnPropertyChanged(nameof(CanEnterPin));
        OnPropertyChanged(nameof(CanDeletePin));
        OnPropertyChanged(nameof(CanSubmitPin));
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
                Notify(
                    nameof(TitleText),
                    nameof(LeadText),
                    nameof(IsPinEntryVisible),
                    nameof(CanEnterPin),
                    nameof(CanDeletePin),
                    nameof(HasSystemRecovery),
                    nameof(StatusText),
                    nameof(HasStatus));
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
            OnPropertyChanged(nameof(CanEnterPin));
            OnPropertyChanged(nameof(CanDeletePin));
            OnPropertyChanged(nameof(CanSubmitPin));
        }
    }
}
