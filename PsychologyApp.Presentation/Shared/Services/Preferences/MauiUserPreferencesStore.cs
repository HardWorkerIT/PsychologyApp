using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Models.Practice.Techniques;
using PsychologyApp.Application.Abstractions.Persistence;


namespace PsychologyApp.Presentation.Shared.Services.Preferences;

public sealed class MauiUserPreferencesStore(IOnboardingConcernRepository? onboardingConcernRepository = null) : IUserPreferencesStore
{
    private IOnboardingConcernRepository ConcernRepository => onboardingConcernRepository
        ?? throw new InvalidOperationException("Onboarding concern persistence requires the registered encrypted repository.");

    public event Action? Changed
    {
        add => UserPreferences.Changed += value;
        remove => UserPreferences.Changed -= value;
    }

    public UserPreferencesState Load() => UserPreferences.Load();

    public async Task SaveAsync(UserPreferencesState state, CancellationToken cancellationToken = default)
    {
        string concern = UserPreferences.NormalizeOnboardingConcernKey(state.OnboardingConcern);
        if (!string.Equals(concern, UserPreferences.Load().OnboardingConcern, StringComparison.Ordinal))
        {
            await ConcernRepository.SaveAsync(concern, cancellationToken).ConfigureAwait(false);
        }

        UserPreferences.Save(state with { OnboardingConcern = concern });
    }

    public void ApplyAll() => UserPreferences.ApplyAll();

    public void ApplyPreview(UserPreferencesState state) => UserPreferences.ApplyPreview(state);

    public async Task RestoreOnboardingConcernAsync(CancellationToken cancellationToken = default)
    {
        string? storedConcern = await ConcernRepository.GetAsync(cancellationToken).ConfigureAwait(false);
        string? legacyConcern = UserPreferences.GetLegacyOnboardingConcern();
        string concern = UserPreferences.NormalizeOnboardingConcernKey(storedConcern ?? legacyConcern ?? UserPreferences.DefaultOnboardingConcern);

        if (storedConcern is null && legacyConcern is not null)
        {
            await ConcernRepository.SaveAsync(concern, cancellationToken).ConfigureAwait(false);
        }

        UserPreferences.SetOnboardingConcernFromEncryptedStore(concern);
        UserPreferences.RemoveLegacyOnboardingConcern();
    }

    public async Task CompleteOnboardingAsync(
        string concern,
        bool? practiceRemindersEnabled = null,
        int? practiceReminderHour = null,
        CancellationToken cancellationToken = default)
    {
        string normalizedConcern = UserPreferences.NormalizeOnboardingConcernKey(concern);
        await ConcernRepository.SaveAsync(normalizedConcern, cancellationToken).ConfigureAwait(false);
        UserPreferences.CompleteOnboarding(normalizedConcern, practiceRemindersEnabled, practiceReminderHour);
        UserPreferences.RemoveLegacyOnboardingConcern();
    }

    public void ResetOnboardingCompletion() => UserPreferences.ResetOnboardingCompletion();

    public void SetPendingTechnique(TechniqueId techniqueId) => UserPreferences.SetPendingTechnique(techniqueId);

    public TechniqueId? ConsumePendingTechnique() => UserPreferences.ConsumePendingTechnique();


    public void SetPendingOpenJournal() => UserPreferences.SetPendingOpenJournal();

    public bool ConsumePendingOpenJournal() => UserPreferences.ConsumePendingOpenJournal();

    public string PersistedLanguage => UserPreferences.GetPersistedLanguage();

    public void SetPendingQuoteFeed(string feedKey) => UserPreferences.SetPendingQuoteFeed(feedKey);

    public string? ConsumePendingQuoteFeed() => UserPreferences.ConsumePendingQuoteFeed();
}
