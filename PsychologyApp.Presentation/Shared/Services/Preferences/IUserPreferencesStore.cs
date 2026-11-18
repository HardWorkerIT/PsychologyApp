using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Models.Practice.Techniques;

namespace PsychologyApp.Presentation.Shared.Services.Preferences;

public interface IUserPreferencesStore
{
    event Action? Changed;

    UserPreferencesState Load();
    Task SaveAsync(UserPreferencesState state, CancellationToken cancellationToken = default);
    void ApplyAll();
    void ApplyPreview(UserPreferencesState state);
    Task RestoreOnboardingConcernAsync(CancellationToken cancellationToken = default);
    Task CompleteOnboardingAsync(
        string concern,
        bool? practiceRemindersEnabled = null,
        int? practiceReminderHour = null,
        CancellationToken cancellationToken = default);
    void ResetOnboardingCompletion();
    void SetPendingTechnique(TechniqueId techniqueId);
    TechniqueId? ConsumePendingTechnique();
    void SetPendingOpenJournal();
    bool ConsumePendingOpenJournal();
    string PersistedLanguage { get; }
    void SetPendingQuoteFeed(string feedKey);
    string? ConsumePendingQuoteFeed();
}
