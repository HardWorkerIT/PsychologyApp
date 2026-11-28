using Microsoft.Maui.Storage;
using Microsoft.Maui.ApplicationModel.Communication;
using PsychologyApp.Application.DataBackup;
using PsychologyApp.Application.ClinicalCare;
using PsychologyApp.Domain.Base.Constants;
using PsychologyApp.Presentation.Features.ManageProfile;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using PsychologyApp.Presentation.Shared.Services.Toasts;
using PsychologyApp.Presentation.Shared.Services.Preferences;
using PsychologyApp.Presentation.Shared.Services.Security;
using PsychologyApp.Presentation.Shared.UI.Overlays;
using PsychologyApp.Presentation.Shared.ViewModels;
using System.Text;
using System.Windows.Input;

namespace PsychologyApp.Presentation.Pages.ManageProfile.ProfileDataBackup;

public sealed class DataBackupViewModel : BaseViewModel
{
    private readonly IBackupService _backupService;
    private readonly ISpecialistSummaryService _specialistSummaryService;
    private readonly IToastService _toastService;
    private readonly IUserPreferencesStore _preferences;
    private readonly IDialogService _dialogService;
    private readonly IPersonalDataEraser _eraser;
    private readonly IAppLock _appLock;
    private readonly IAppPinCredentialStore _appPinCredentialStore;
    private readonly object _operationCancellationSync = new();
    private readonly HashSet<CancellationTokenSource> _activeOperationCancellations = [];

    // A second tap while the system prompt is open would put a second prompt behind it.
    private bool _enablingAppLock;

    public ICommand BackCommand { get; }
    public ICommand ExportBackupCommand { get; }
    public ICommand ImportBackupCommand { get; }
    public ICommand ExportSummaryCommand { get; }
    public ICommand ShareErrorLogCommand { get; }
    public ICommand EraseAllCommand { get; }
    public ICommand ChangeAppPinCommand { get; }

    public string EraseTitle => AppStrings.DataEraseTitle;
    public string EraseSubtitle => AppStrings.DataEraseSubtitle;

    public string AppLockLabel => AppStrings.AppLockLabel;
    public string AppLockHint => _appLock.Availability == DeviceUnlockAvailability.NoScreenLock
        ? AppStrings.AppLockNoScreenLock
        : AppStrings.AppLockHint;
    public string ChangeAppPinText => AppStrings.AppLockChangePin;
    public bool IsAppPinManagementVisible => _appLock.IsEnabled;

    /// <summary>Hidden where the system prompt does not exist (before Android 10): there is nothing to offer.</summary>
    public bool IsAppLockOffered => _appLock.Availability != DeviceUnlockAvailability.Unsupported;

    /// <summary>
    /// Turning it on asks for the phone's unlock once, so a lock is never set on a phone that cannot open it; when that does not
    /// happen the switch springs back. Turning it off needs nothing: whoever does it is already inside the app.
    /// </summary>
    public bool AppLockEnabled
    {
        get => _appLock.IsEnabled;
        set
        {
            if (value == _appLock.IsEnabled)
            {
                return;
            }

            if (value)
            {
                EnableAppLockAsync().FireAndForget();
                return;
            }

            _appLock.Disable();
            OnPropertyChanged();
            OnPropertyChanged(nameof(IsAppPinManagementVisible));
        }
    }

    public string ErrorLogTitle => AppStrings.ErrorLogTitle;
    public string ErrorLogSubtitle => AppStrings.ErrorLogSubtitle(Constants.ReviewEmailAddress);

    public string PageTitle => AppStrings.DataBackupTitle;
    public string LeadText => AppStrings.DataBackupLead;
    public string ProtectionSectionTitle => AppStrings.DataBackupProtectionSection;
    public string BackupSectionTitle => AppStrings.DataBackupSection;
    public string ShareSectionTitle => AppStrings.DataBackupShareSection;
    public string IrreversibleSectionTitle => AppStrings.DataBackupIrreversibleSection;
    public string ExportTitle => AppStrings.DataBackupExportTitle;
    public string ExportSubtitle => AppStrings.DataBackupExportSubtitle;
    public string ImportTitle => AppStrings.DataBackupImportTitle;
    public string ImportSubtitle => AppStrings.DataBackupImportSubtitle;
    public string SummaryTitle => AppStrings.DataBackupSummaryTitle;
    public string SummarySubtitle => AppStrings.DataBackupSummarySubtitle;

    public DataBackupViewModel(
        INavigationService navigationService,
        IBackupService backupService,
        ISpecialistSummaryService specialistSummaryService,
        IToastService toastService,
        IUserPreferencesStore preferences,
        IDialogService dialogService,
        IPersonalDataEraser eraser,
        IAppLock appLock,
        IAppPinCredentialStore appPinCredentialStore)
    {
        BindNavigation(navigationService);
        _backupService = backupService;
        _specialistSummaryService = specialistSummaryService;
        _toastService = toastService;
        _preferences = preferences;
        _dialogService = dialogService;
        _eraser = eraser;
        _appLock = appLock;
        _appPinCredentialStore = appPinCredentialStore;

        BackCommand = new AsyncCommand(() => navigationService.GoBackAsync());
        ExportBackupCommand = new AsyncCommand(() => RunCancelableAsync(ExportBackupAsync));
        ImportBackupCommand = new AsyncCommand(() => RunCancelableAsync(ImportBackupAsync));
        ExportSummaryCommand = new AsyncCommand(() => RunCancelableAsync(ExportSummaryAsync));
        ShareErrorLogCommand = new AsyncCommand(() => RunCancelableAsync(ShareErrorLogAsync));
        EraseAllCommand = new AsyncCommand(EraseAllAsync);
        ChangeAppPinCommand = new AsyncCommand(ChangeAppPinAsync);
    }

    public void CancelPendingOperations()
    {
        lock (_operationCancellationSync)
        {
            foreach (CancellationTokenSource cancellation in _activeOperationCancellations)
            {
                cancellation.Cancel();
            }
        }
    }

    private async Task RunCancelableAsync(Func<CancellationToken, Task> operation)
    {
        using CancellationTokenSource cancellation = new();
        lock (_operationCancellationSync)
        {
            _activeOperationCancellations.Add(cancellation);
        }

        try
        {
            await operation(cancellation.Token);
        }
        catch (OperationCanceledException) when (cancellation.IsCancellationRequested)
        {
        }
        finally
        {
            lock (_operationCancellationSync)
            {
                _activeOperationCancellations.Remove(cancellation);
            }
        }
    }

    protected override void RefreshLocalizedProperties()
    {
        Notify(
            nameof(PageTitle),
            nameof(LeadText),
            nameof(ProtectionSectionTitle),
            nameof(BackupSectionTitle),
            nameof(ShareSectionTitle),
            nameof(IrreversibleSectionTitle),
            nameof(ExportTitle),
            nameof(ExportSubtitle),
            nameof(ImportTitle),
            nameof(ImportSubtitle),
            nameof(SummaryTitle),
            nameof(SummarySubtitle),
            nameof(ErrorLogTitle),
            nameof(ErrorLogSubtitle),
            nameof(EraseTitle),
            nameof(EraseSubtitle),
            nameof(AppLockLabel),
            nameof(AppLockHint),
            nameof(ChangeAppPinText));
    }

    private async Task ChangeAppPinAsync()
    {
        if (!_appLock.IsEnabled)
        {
            return;
        }

        string? currentPin = await _dialogService.PromptPasswordSheetAsync(
            AppStrings.AppLockChangePin,
            AppStrings.AppLockPinPrompt,
            AppStrings.AppLockPinPrompt,
            AppStrings.AppLockCreatePin,
            AppStrings.Cancel);
        if (currentPin is null)
        {
            return;
        }

        try
        {
            AppPinVerificationResult verification = await _appPinCredentialStore.VerifyPinAsync(currentPin);
            currentPin = null;
            if (!verification.IsValid)
            {
                string message = verification.IsLockedOut
                    ? AppStrings.AppLockPinLockedOut(Math.Max(1, (int)Math.Ceiling(verification.RetryAfter.TotalSeconds)))
                    : AppStrings.AppLockPinIncorrect;
                await _dialogService.ShowAsync(AppStrings.AppLockChangePin, message);
                return;
            }

            string? newPin = await _dialogService.PromptPasswordSheetAsync(
                AppStrings.AppLockChangePin,
                AppStrings.AppLockSetupLead,
                AppStrings.AppLockPinPrompt,
                AppStrings.AppLockCreatePin,
                AppStrings.Cancel);
            if (newPin is null)
            {
                return;
            }

            if (!AppPinPolicy.IsValid(newPin))
            {
                await _dialogService.ShowAsync(AppStrings.AppLockChangePin, AppStrings.AppLockSetupLead);
                return;
            }

            string? confirmation = await _dialogService.PromptPasswordSheetAsync(
                AppStrings.AppLockChangePin,
                AppStrings.AppLockConfirmLead,
                AppStrings.AppLockPinPrompt,
                AppStrings.AppLockConfirmPin,
                AppStrings.Cancel);
            if (confirmation is null)
            {
                return;
            }

            if (!string.Equals(newPin, confirmation, StringComparison.Ordinal))
            {
                await _dialogService.ShowAsync(AppStrings.AppLockChangePin, AppStrings.AppLockPinMismatch);
                return;
            }

            await _appPinCredentialStore.SetPinAsync(newPin);
            await _dialogService.ShowAsync(AppStrings.AppLockChangePin, AppStrings.AppLockPinChanged);
        }
        catch (Exception ex)
        {
            BestEffort.Report(ex);
            await _dialogService.ShowAsync(AppStrings.AppLockChangePin, AppStrings.AppLockPinStorageError);
        }
    }

    private async Task EnableAppLockAsync()
    {
        if (_enablingAppLock)
        {
            return;
        }

        _enablingAppLock = true;
        try
        {
            if (_appLock.Availability == DeviceUnlockAvailability.NoScreenLock)
            {
                await _dialogService.ShowAsync(AppStrings.AppLockLabel, AppStrings.AppLockNoScreenLock);
            }
            else
            {
                await _appLock.TryEnableAsync();
            }
        }
        finally
        {
            _enablingAppLock = false;

            // On or not, the switch shows what is really set.
            OnPropertyChanged(nameof(AppLockEnabled));
            OnPropertyChanged(nameof(IsAppPinManagementVisible));
        }
    }

    /// <summary>
    /// Nothing can be brought back after this, so it is asked twice: first what goes (and that a backup is the only way back),
    /// then a last "are you sure". On success the app restarts and this method does not return.
    /// </summary>
    private async Task EraseAllAsync()
    {
        if (!await _dialogService.AskSheetAsync(AppStrings.DataEraseConfirmTitle, AppStrings.DataEraseConfirmBody, AppStrings.DataEraseConfirmAccept, AppStrings.Cancel, isDestructive: true)
            || !await _dialogService.AskSheetAsync(AppStrings.DataEraseFinalTitle, AppStrings.DataEraseFinalBody, AppStrings.DataEraseConfirmAccept, AppStrings.Cancel, isDestructive: true))
        {
            return;
        }

        try
        {
            await _eraser.EraseAllAsync();
        }
        catch (Exception ex)
        {
            BestEffort.Report(ex);
            _toastService.LongToast(AppStrings.DataEraseFailedToast, AppToastKind.Error);
        }
    }

    private async Task ExportBackupAsync(CancellationToken cancellationToken)
    {
        try
        {
            string? choice = await _dialogService.PickOptionWithConfirmationAsync(
                AppStrings.BackupProtectTitle,
                [AppStrings.BackupProtectWith, AppStrings.BackupProtectWithout],
                AppStrings.DataBackupExportTitle,
                AppStrings.Cancel);
            if (choice is null)
            {
                return;
            }

            cancellationToken.ThrowIfCancellationRequested();
            string json;
            bool passphraseProtected = false;
            if (choice == AppStrings.BackupProtectWith)
            {
                string? passphrase = await AskNewPassphraseAsync(cancellationToken);
                if (passphrase is null)
                {
                    return;
                }

                json = await _backupService.ExportEncryptedAsync(passphrase, cancellationToken);
                passphraseProtected = true;
            }
            else
            {
                json = await _backupService.ExportAsync(cancellationToken);
            }

            string fileName = SharedFileNames.Backup(passphraseProtected, DateTime.Now);
            await SharedExportFile.ShareAsync(fileName, json, AppStrings.DataBackupExportTitle, cancellationToken);
        }
        catch (BackupFormatException)
        {
            _toastService.LongToast(AppStrings.DataBackupExportTooLargeToast, AppToastKind.Error);
        }
    }

    private async Task ImportBackupAsync(CancellationToken cancellationToken)
    {
        try
        {
            string? json;
            try
            {
#if ANDROID
                json = await PsychologyApp.Presentation.Platforms.Android.BackupDocumentPicker.ReadAsync(
                    AppStrings.DataBackupImportTitle, cancellationToken);
#else
                FileResult? file = await FilePicker.Default.PickAsync(new PickOptions
                {
                    PickerTitle = AppStrings.DataBackupImportTitle
                });
                if (file is null)
                {
                    return;
                }

                cancellationToken.ThrowIfCancellationRequested();
                await using Stream stream = await file.OpenReadAsync();
                json = await Task.Run(() => BackupFileReader.ReadAsync(stream, cancellationToken), cancellationToken);
#endif
            }
            catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
            {
                throw new BackupFormatException("The selected backup file could not be read.", ex);
            }
            if (json is null)
            {
                return;
            }

            bool isEncrypted = await Task.Run(() => _backupService.IsEncrypted(json), cancellationToken);
            BackupImportResult? imported = isEncrypted
                ? await ImportProtectedAsync(json, cancellationToken)
                : await _backupService.ImportAsync(json, cancellationToken);
            // A returned result means the import committed. A later cancellation cannot undo it.
            if (imported is not BackupImportResult result)
            {
                return;
            }

            _toastService.LongToast(
                AppStrings.DataBackupImportedToast(
                    result.MoodEntries,
                    result.TestResults,
                    result.Completions + result.SessionResults,
                    result.ChatSessions,
                    result.SkippedDuplicates));
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
        catch (BackupFormatException)
        {
            // Nothing was written: the import is a single transaction and the file was rejected before it.
            _toastService.LongToast(AppStrings.DataBackupImportFailedToast, AppToastKind.Error);
        }
        catch (Exception)
        {
            // The transaction rolled back, so the database is exactly as it was before the attempt.
            _toastService.LongToast(AppStrings.DataBackupImportRolledBackToast, AppToastKind.Error);
        }
    }

    /// <summary>Asks for a new passphrase twice; null when cancelled or when it is too short or the two differ (a toast says which).</summary>
    private async Task<string?> AskNewPassphraseAsync(CancellationToken cancellationToken)
    {
        string? first = await _dialogService.PromptPasswordSheetAsync(
            AppStrings.BackupPassphraseTitle, AppStrings.BackupPassphraseNewBody, AppStrings.BackupPassphrasePlaceholder, AppStrings.Ok, AppStrings.Cancel);
        cancellationToken.ThrowIfCancellationRequested();
        if (first is null)
        {
            return null;
        }

        if (first.Length < BackupEncryption.MinPassphraseLength)
        {
            _toastService.LongToast(AppStrings.BackupPassphraseTooShortToast, AppToastKind.Error);
            return null;
        }

        string? second = await _dialogService.PromptPasswordSheetAsync(
            AppStrings.BackupPassphraseTitle, AppStrings.BackupPassphraseConfirmBody, AppStrings.BackupPassphrasePlaceholder, AppStrings.Ok, AppStrings.Cancel);
        cancellationToken.ThrowIfCancellationRequested();
        if (second is null)
        {
            return null;
        }

        if (!string.Equals(first, second, StringComparison.Ordinal))
        {
            _toastService.LongToast(AppStrings.BackupPassphraseMismatchToast, AppToastKind.Error);
            return null;
        }

        return first;
    }

    /// <summary>Three tries at the passphrase; null when cancelled or when all of them were wrong.</summary>
    private async Task<BackupImportResult?> ImportProtectedAsync(string file, CancellationToken cancellationToken)
    {
        for (int attempt = 0; attempt < 3; attempt++)
        {
            string? passphrase = await _dialogService.PromptPasswordSheetAsync(
                AppStrings.BackupPassphraseTitle, AppStrings.BackupPassphraseOpenBody, AppStrings.BackupPassphrasePlaceholder, AppStrings.Ok, AppStrings.Cancel);
            cancellationToken.ThrowIfCancellationRequested();
            if (passphrase is null)
            {
                return null;
            }

            try
            {
                return await _backupService.ImportEncryptedAsync(file, passphrase, cancellationToken);
            }
            catch (BackupPassphraseException)
            {
                _toastService.ShortToast(AppStrings.BackupPassphraseWrongToast, AppToastKind.Error);
            }
        }

        return null;
    }

    private async Task ShareErrorLogAsync(CancellationToken cancellationToken)
    {
        string text;
        try
        {
            string path = Shared.Common.Infrastructure.DebugFileLoggerProvider.ErrorLogPath;
            text = File.Exists(path) ? await File.ReadAllTextAsync(path, Encoding.UTF8, cancellationToken) : string.Empty;
        }
        catch (IOException)
        {
            text = string.Empty;
        }

        cancellationToken.ThrowIfCancellationRequested();
        if (string.IsNullOrWhiteSpace(text))
        {
            _toastService.ShortToast(AppStrings.ErrorLogEmptyToast);
            return;
        }

        try
        {
            await EmailTemporaryFileAsync(
                SharedFileNames.ErrorLog(DateTime.Now),
                text,
                AppStrings.ErrorLogTitle,
                Constants.ReviewEmailAddress,
                cancellationToken);
        }
        catch (FeatureNotSupportedException)
        {
            _toastService.LongToast(AppStrings.ReviewEmailNotSupported, AppToastKind.Error);
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
        catch (Exception)
        {
            _toastService.LongToast(AppStrings.ReviewEmailFailed, AppToastKind.Error);
        }
    }

    private static Task EmailTemporaryFileAsync(
        string fileName,
        string content,
        string subject,
        string recipient,
        CancellationToken cancellationToken) =>
        SharedExportFile.DeliverAsync(fileName, content, path => Email.Default.ComposeAsync(new EmailMessage
        {
            Subject = subject,
            Body = AppStrings.ErrorLogEmailBody,
            To = [recipient],
            Attachments = [new EmailAttachment(path)]
        }), cancellationToken);

    private async Task ExportSummaryAsync(CancellationToken cancellationToken)
    {
        string language = UserPreferences.NormalizeLanguageKey(_preferences.Load().Language);
        string summary = await _specialistSummaryService.BuildSummaryAsync(language, cancellationToken);
        string fileName = SharedFileNames.SpecialistSummary(DateTime.Now);
        await SharedExportFile.ShareAsync(fileName, summary, AppStrings.DataBackupSummaryTitle, cancellationToken);
    }
}
