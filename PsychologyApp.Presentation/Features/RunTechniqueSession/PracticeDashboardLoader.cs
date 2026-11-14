using PsychologyApp.Application.ClinicalCare;
using PsychologyApp.Application.Models;
using PsychologyApp.Application.Recommendations;
using PsychologyApp.Application.UserProgress;
using PsychologyApp.Domain.UserProgress;
using PsychologyApp.Presentation.Models.Practice.Techniques;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.Services.Preferences;

namespace PsychologyApp.Presentation.Features.RunTechniqueSession;

public sealed class PracticeDashboardLoader(
    IUserProgressService userProgressService,
    IUserPreferencesStore userPreferencesStore,
    TodayRecommendationResolver todayRecommendationResolver,
    IClinicalCareService clinicalCareService)
{
    public async Task<int> LoadStreakDaysAsync(CancellationToken cancellationToken = default) =>
        await userProgressService.GetStreakDaysAsync(cancellationToken);

    public async Task<(bool HasAnyActivity, bool IsReturning)> LoadEngagementStateAsync(
        CancellationToken cancellationToken = default)
    {
        DateOnly? lastActiveDay = await userProgressService.GetLastActiveDayAsync(cancellationToken);
        return (
            lastActiveDay.HasValue,
            ComebackPolicy.IsReturning(lastActiveDay, DateOnly.FromDateTime(DateTime.Today)));
    }

    public async Task<bool> HasSessionDraftAsync(TechniqueId techniqueId, CancellationToken cancellationToken = default)
    {
        string? draft = await userProgressService.GetSessionDraftAsync(techniqueId.ToString(), cancellationToken);
        return !string.IsNullOrWhiteSpace(draft);
    }

    public Task<IReadOnlyList<SavedNextStep>> GetSavedNextStepsAsync(CancellationToken cancellationToken = default) =>
        userProgressService.GetSavedNextStepsAsync(cancellationToken);

    public Task SetSavedNextStepsAsync(IReadOnlyList<SavedNextStep> nextSteps, CancellationToken cancellationToken = default) =>
        userProgressService.SetSavedNextStepsAsync(nextSteps, cancellationToken);

    public async Task<TodayRecommendationResult> ResolveTodayRecommendationAsync(
        INavigationService navigationService,
        CancellationToken cancellationToken = default)
    {
        string concern = userPreferencesStore.Load().OnboardingConcern;
        TodayRecommendationContext context =
            await TodayRecommendationContextBuilder.BuildAsync(
                userProgressService,
                concern,
                clinicalCareService,
                cancellationToken);
        return await todayRecommendationResolver.ResolveAsync(
            context,
            navigationService,
            cancellationToken);
    }

    public TechniqueId? ConsumePendingTechnique() => userPreferencesStore.ConsumePendingTechnique();
}
