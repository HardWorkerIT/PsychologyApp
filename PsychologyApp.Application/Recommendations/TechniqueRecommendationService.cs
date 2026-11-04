using PsychologyApp.Application.ClinicalCare;
using PsychologyApp.Application.Models;
using PsychologyApp.Application.Models.Tests;
using PsychologyApp.Application.Tests;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Recommendations;

public interface ITechniqueRecommendationService
{
    TechniqueId ResolveFromOnboardingConcern(string concern);

    TodayRecommendationDecision ResolveTodayTechnique(TodayRecommendationContext context);

    TechniqueId ResolveNextAfterCompletion(TodayRecommendationContext context, TechniqueId completedTechniqueId);

}

public sealed class TechniqueRecommendationService : ITechniqueRecommendationService
{
    // A newcomer gets the first entry that was never tried, so the list opens with the gentlest practices.
    private static readonly TechniqueId[] ExploreRotation =
    [
        TechniqueId.Grounding,
        TechniqueId.Breathing,
        TechniqueId.SmallStep,
        TechniqueId.ImplementationIntention,
        TechniqueId.ThoughtDefusion,
        TechniqueId.SelfCompassion,
        TechniqueId.ThoughtRecord,
        TechniqueId.PauseBeforeReaction,
        TechniqueId.OppositeAction,
        TechniqueId.ProblemSolving,
        TechniqueId.CheckTheFacts,
        TechniqueId.WorryTime,
        TechniqueId.MuscleRelax,
        TechniqueId.BusyMind,
        TechniqueId.SensoryComfort,
        TechniqueId.UrgeSurfing,
        TechniqueId.Observer

    ];

    private static readonly TechniqueId[] AnxietyPool =
    [
        TechniqueId.Grounding,
        TechniqueId.Breathing,
        TechniqueId.ThoughtDefusion,
        TechniqueId.ThoughtRecord,
        TechniqueId.ProblemSolving,
        TechniqueId.CheckTheFacts,
        TechniqueId.WorryTime,
        TechniqueId.SensoryComfort,
        TechniqueId.Observer
    ];

    private static readonly TechniqueId[] BodyPool =
    [
        TechniqueId.Grounding,
        TechniqueId.Breathing,
        TechniqueId.ThoughtDefusion,
        TechniqueId.MuscleRelax,
        TechniqueId.SensoryComfort
    ];

    private static readonly TechniqueId[] MoodPool =
    [
        TechniqueId.SmallStep,
        TechniqueId.ImplementationIntention,
        TechniqueId.ThoughtRecord,
        TechniqueId.SelfCompassion,
        TechniqueId.ThoughtDefusion,
        TechniqueId.ProblemSolving
    ];

    private static readonly TechniqueId[] LowMoodPool =
    [
        TechniqueId.Breathing,
        TechniqueId.Grounding,
        TechniqueId.SmallStep,
        TechniqueId.SelfCompassion,
        TechniqueId.ThoughtDefusion
    ];

    public TechniqueId ResolveFromOnboardingConcern(string concern) => concern switch
    {
        OnboardingConcernKeys.Anxiety => TechniqueId.Grounding,
        // Grounding: when the body signals stress, the first step is back to the senses, not into a painful experience.
        OnboardingConcernKeys.Body => TechniqueId.Grounding,
        OnboardingConcernKeys.Mood => TechniqueId.SmallStep,
        // The very first practice is the gentlest, whatever the day: rotating by date could open with a painful memory.
        _ => ExploreRotation[0]
    };

    public TodayRecommendationDecision ResolveTodayTechnique(TodayRecommendationContext context)
    {
        if (context.DraftTechniqueId is TechniqueId draftId)
        {
            return new TodayRecommendationDecision(draftId, TodayRecommendationSource.SessionDraft);
        }

        if (context.RecentTestResult is { Score: not null } test &&
            test.CompletedAt >= DateTime.UtcNow.AddDays(-7))
        {
            TechniqueId fromTest = test.TestId == TestIds.LuscherStandard
                ? LuscherScoreRecommendation.RecommendTechnique(test.Score.Value)
                : TestScoreRecommendation.RecommendTechnique(test.TestId, test.Score.Value)
                    ?? TechniqueId.Grounding;

            TechniqueId picked = PickFromPool([fromTest], context.LastPracticeDatesUtc, context.TechniqueEffectiveness);
            return new TodayRecommendationDecision(picked, TodayRecommendationSource.RecentTest, test.TestId);
        }

        if (context.TodayMoodLevel is int mood && mood <= 2)
        {
            TechniqueId picked = PickFromPool(LowMoodPool, context.LastPracticeDatesUtc, context.TechniqueEffectiveness);
            return new TodayRecommendationDecision(picked, TodayRecommendationSource.LowMood);
        }

        if (context.ActiveProgramType is TherapyProgramType programType && context.ActiveProgramWeek > 0)
        {
            IReadOnlyList<TechniqueId> programPool =
                TherapyProgramCatalog.ResolvePool(programType, context.ActiveProgramWeek);
            TechniqueId fromProgram = PickFromPool(programPool, context.LastPracticeDatesUtc, context.TechniqueEffectiveness);
            return new TodayRecommendationDecision(fromProgram, TodayRecommendationSource.OnboardingConcern);
        }

        TechniqueId[] pool = ResolveConcernPool(context.Concern);
        TechniqueId fromPool = PickFromPool(pool, context.LastPracticeDatesUtc, context.TechniqueEffectiveness);
        TodayRecommendationSource source = context.Concern == OnboardingConcernKeys.Explore
            ? TodayRecommendationSource.Explore
            : TodayRecommendationSource.OnboardingConcern;
        return new TodayRecommendationDecision(fromPool, source);
    }

    public TechniqueId ResolveNextAfterCompletion(
        TodayRecommendationContext context,
        TechniqueId completedTechniqueId)
    {
        TechniqueId[] pool;
        if (context.TodayMoodLevel is int mood && mood <= 2)
        {
            pool = LowMoodPool;
        }
        else if (context.ActiveProgramType is TherapyProgramType programType && context.ActiveProgramWeek > 0)
        {
            pool = TherapyProgramCatalog.ResolvePool(programType, context.ActiveProgramWeek).ToArray();
        }
        else
        {
            pool = ResolveConcernPool(context.Concern);
        }

        TechniqueId[] filtered = pool
            .Where(id => id != completedTechniqueId)
            .ToArray();

        if (filtered.Length == 0)
        {
            filtered = ExploreRotation
                .Where(id => id != completedTechniqueId)
                .ToArray();
        }

        return PickFromPool(filtered, context.LastPracticeDatesUtc, context.TechniqueEffectiveness);
    }


    private static TechniqueId[] ResolveConcernPool(string concern) => concern switch
    {
        OnboardingConcernKeys.Anxiety => AnxietyPool,
        OnboardingConcernKeys.Body => BodyPool,
        OnboardingConcernKeys.Mood => MoodPool,
        _ => ExploreRotation
    };

    /// <summary>
    /// Prefers techniques that have measurably helped this person before (higher average SUDS drop);
    /// among ties or unproven techniques, prefers never/least-recently practiced. Avoids yesterday's or
    /// today's pick when an alternative exists.
    /// </summary>
    public static TechniqueId PickFromPool(
        IReadOnlyList<TechniqueId> pool,
        IReadOnlyDictionary<string, DateTime>? lastPracticeDatesUtc,
        IReadOnlyDictionary<string, double>? effectiveness = null)
    {
        if (pool.Count == 0)
        {
            return TechniqueId.Grounding;
        }

        if (pool.Count == 1)
        {
            return pool[0];
        }

        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        DateOnly yesterday = today.AddDays(-1);

        List<(TechniqueId Id, int Index)> ranked = pool
            .Select((id, index) => (Id: id, Index: index))
            .OrderByDescending(item => GetEffectivenessScore(item.Id, effectiveness))
            .ThenBy(item => GetLastLocalDate(item.Id, lastPracticeDatesUtc) ?? DateOnly.MinValue)
            .ThenBy(item => item.Index)
            .ToList();

        TechniqueId best = ranked[0].Id;
        DateOnly? bestDate = GetLastLocalDate(best, lastPracticeDatesUtc);
        if (bestDate is null || (bestDate != yesterday && bestDate != today))
        {
            return best;
        }

        foreach ((TechniqueId candidate, _) in ranked.Skip(1))
        {
            DateOnly? date = GetLastLocalDate(candidate, lastPracticeDatesUtc);
            if (date is null || (date != yesterday && date != today))
            {
                return candidate;
            }
        }

        return ranked[1].Id;
    }

    /// <summary>0 (neutral) for techniques with no trustworthy history, so a proven helper (positive average
    /// SUDS drop) ranks above the unknowns and a proven non-helper (average drop at or below zero) ranks
    /// below them, without either drowning out the recency-based fallback.</summary>
    private static double GetEffectivenessScore(
        TechniqueId techniqueId,
        IReadOnlyDictionary<string, double>? effectiveness)
    {
        if (effectiveness is null || !effectiveness.TryGetValue(techniqueId.ToString(), out double score))
        {
            return 0;
        }

        return score;
    }

    private static DateOnly? GetLastLocalDate(
        TechniqueId techniqueId,
        IReadOnlyDictionary<string, DateTime>? lastPracticeDatesUtc)
    {
        if (lastPracticeDatesUtc is null
            || !lastPracticeDatesUtc.TryGetValue(techniqueId.ToString(), out DateTime utc))
        {
            return null;
        }

        return DateOnly.FromDateTime(utc.ToLocalTime());
    }
}
