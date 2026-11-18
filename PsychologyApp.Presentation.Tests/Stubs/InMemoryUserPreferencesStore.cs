using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Models.Practice.Techniques;
using PsychologyApp.Presentation.Shared.Services.Preferences;

namespace PsychologyApp.Presentation.Tests;

/// <summary>The settings store without the device: what a test saves, the code under test reads back.</summary>
public sealed class InMemoryUserPreferencesStore : IUserPreferencesStore
{
    private UserPreferencesState _state = new();
    private TechniqueId? _pendingTechnique;
    private string? _pendingQuoteFeed;
    private bool _pendingOpenJournal;

    public event Action? Changed;

    public UserPreferencesState Load() => _state;

    public void Save(UserPreferencesState state)
    {
        _state = state;
        Changed?.Invoke();
    }

    public Task SaveAsync(UserPreferencesState state, CancellationToken cancellationToken = default)
    {
        Save(state);
        return Task.CompletedTask;
    }

    public void ApplyAll()
    {
    }

    public Task RestoreOnboardingConcernAsync(CancellationToken cancellationToken = default) => Task.CompletedTask;

    // Like the real store: the look changes and listeners hear of it, what is saved stays as it was.
    public void ApplyPreview(UserPreferencesState state) => Changed?.Invoke();

    public Task CompleteOnboardingAsync(
        string concern,
        bool? practiceRemindersEnabled = null,
        int? practiceReminderHour = null,
        CancellationToken cancellationToken = default)
    {
        Save(_state with
        {
            HasCompletedOnboarding = true,
            OnboardingConcern = concern,
            PracticeRemindersEnabled = practiceRemindersEnabled ?? _state.PracticeRemindersEnabled,
            PracticeReminderHour = practiceReminderHour ?? _state.PracticeReminderHour
        });
        return Task.CompletedTask;
    }

    public void ResetOnboardingCompletion() => Save(_state with { HasCompletedOnboarding = false });

    public void SetPendingTechnique(TechniqueId techniqueId) => _pendingTechnique = techniqueId;

    public TechniqueId? ConsumePendingTechnique()
    {
        TechniqueId? pending = _pendingTechnique;
        _pendingTechnique = null;
        return pending;
    }

    public void SetPendingOpenJournal() => _pendingOpenJournal = true;

    public bool ConsumePendingOpenJournal()
    {
        bool pending = _pendingOpenJournal;
        _pendingOpenJournal = false;
        return pending;
    }

    public string PersistedLanguage => _state.Language;

    public void SetPendingQuoteFeed(string feedKey) => _pendingQuoteFeed = feedKey;

    public string? ConsumePendingQuoteFeed()
    {
        string? pending = _pendingQuoteFeed;
        _pendingQuoteFeed = null;
        return pending;
    }
}
