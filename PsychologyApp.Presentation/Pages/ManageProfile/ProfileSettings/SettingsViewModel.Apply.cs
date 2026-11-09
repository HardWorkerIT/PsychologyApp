using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Services.Notifications;
using PsychologyApp.Presentation.Shared.Services.Preferences;

namespace PsychologyApp.Presentation.Pages.ManageProfile.ProfileSettings;

public partial class SettingsViewModel
{
    /// <summary>
    /// Every choice shows at once and is kept; leaving keeps a change still waiting for its save. Leaving used to undo it, so a theme
    /// picked just before going back was lost, and the separate "Apply" button and its dialog only repeated what had happened.
    /// </summary>
    private async Task SaveAndGoBackAsync()
    {
        bool pending = _autoSaveDebounceCts is not null;
        CancelPendingAutoSave();
        if (pending)
        {
            await PersistSettingsAsync(CancellationToken.None);
        }

        await _navigationService.GoBackAsync();
    }

    private async Task ReplayOnboardingAsync()
    {
        _userPreferencesStore.ResetOnboardingCompletion();
        await _navigationService.ShowOnboardingAsync();
    }

    private void QueueAutoSave()
    {
        CancelPendingAutoSave();
        CancellationTokenSource debounce = new();
        _autoSaveDebounceCts = debounce;
        _ = AutoSaveAsync(debounce.Token);
    }

    private void CancelPendingAutoSave()
    {
        _autoSaveDebounceCts?.Cancel();
        _autoSaveDebounceCts?.Dispose();
        _autoSaveDebounceCts = null;
    }

    private async Task AutoSaveAsync(CancellationToken cancellationToken)
    {
        try
        {
            await Task.Delay(AutoSaveDebounceDelay, cancellationToken);
            await PersistSettingsAsync(cancellationToken);
        }
        catch (OperationCanceledException)
        {
            // Debounce canceled by next change or explicit manual save.
        }
    }

    private async Task PersistSettingsAsync(CancellationToken cancellationToken)
    {
        await _saveLock.WaitAsync(cancellationToken);
        try
        {
            _userPreferencesStore.Save(BuildCurrentState());
            _savedState = _userPreferencesStore.Load();
            _userPreferencesStore.ApplyAll();
            await _languageContentReloader.EnsureReloadedAsync();

            if (_practiceReminderState.PracticeRemindersEnabled != _savedState.PracticeRemindersEnabled)
                await _practiceReminderCoordinator.SyncAsync();
            else if (_practiceReminderState.Language != _savedState.Language || _practiceReminderState.PracticeReminderHour != _savedState.PracticeReminderHour || _practiceReminderState.OnboardingConcern != _savedState.OnboardingConcern)
                await _practiceReminderCoordinator.RescheduleAsync();
            _practiceReminderState = _savedState;

            if (_quoteReminderState.QuoteRemindersEnabled != _savedState.QuoteRemindersEnabled)
                await _quoteReminderCoordinator.SyncAsync();
            else if (_quoteReminderState.Language != _savedState.Language || _quoteReminderState.QuoteReminderHour != _savedState.QuoteReminderHour)
                await _quoteReminderCoordinator.RescheduleAsync();
            _quoteReminderState = _savedState;

            if (_moodReminderState.MoodRemindersEnabled != _savedState.MoodRemindersEnabled)
                await _moodReminderCoordinator.SyncAsync();
            else if (_moodReminderState.Language != _savedState.Language || _moodReminderState.MoodReminderHour != _savedState.MoodReminderHour)
                await _moodReminderCoordinator.RescheduleAsync();
            _moodReminderState = _savedState;

            if (_chatReminderState.ChatRemindersEnabled != _savedState.ChatRemindersEnabled)
                await _chatReminderCoordinator.SyncAsync();
            else if (_chatReminderState.Language != _savedState.Language || _chatReminderState.ChatReminderHour != _savedState.ChatReminderHour)
                await _chatReminderCoordinator.RescheduleAsync();
            _chatReminderState = _savedState;
        }
        finally
        {
            _saveLock.Release();
        }
    }
}
