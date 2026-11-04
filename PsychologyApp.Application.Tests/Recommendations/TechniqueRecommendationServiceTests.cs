using PsychologyApp.Application.Models;
using PsychologyApp.Application.Models.Tests;
using PsychologyApp.Application.Recommendations;
using PsychologyApp.Application.ClinicalCare;
using PsychologyApp.Domain.Practice;
using Xunit;

namespace PsychologyApp.Application.Tests.Recommendations;

public sealed class TechniqueRecommendationServiceTests
{
    private readonly TechniqueRecommendationService _service = new();

    [Theory]
    [InlineData(OnboardingConcernKeys.Anxiety, TechniqueId.Grounding)]
    [InlineData(OnboardingConcernKeys.Body, TechniqueId.Grounding)]
    [InlineData(OnboardingConcernKeys.Mood, TechniqueId.SmallStep)]
    [InlineData(OnboardingConcernKeys.Explore, TechniqueId.Grounding)]
    public void ResolveFromOnboardingConcern_MapsKnownConcerns(string concern, TechniqueId expected) =>
        Assert.Equal(expected, _service.ResolveFromOnboardingConcern(concern));

    [Fact]
    public void Therapy_program_pools_do_not_offer_archived_practices()
    {
        TechniqueId[] archivedIds =
        [
            TechniqueId.Spin,
            TechniqueId.Hack,
            TechniqueId.Experience,
            TechniqueId.Copied,
            TechniqueId.Resize,
            TechniqueId.Check,
            TechniqueId.Anchor,
            TechniqueId.Comparison,
            TechniqueId.Polarity,
            TechniqueId.Paper,
            TechniqueId.Future
        ];

        foreach (TherapyProgramType programType in Enum.GetValues<TherapyProgramType>())
        {
            for (int week = 1; week <= TherapyProgramCatalog.TotalWeeks; week++)
            {
                IReadOnlyList<TechniqueId> pool = TherapyProgramCatalog.ResolvePool(programType, week);
                Assert.All(pool, techniqueId => Assert.DoesNotContain(techniqueId, archivedIds));
            }
        }
    }

    // "Just exploring" starts with a short sensory-orientation practice before any reflection.
    [Fact]
    public void A_newcomer_in_the_stress_programme_starts_with_breathing()
    {
        TodayRecommendationDecision decision = _service.ResolveTodayTechnique(new TodayRecommendationContext(
            OnboardingConcernKeys.Explore,
            ActiveProgramType: TherapyProgramType.Stress,
            ActiveProgramWeek: 1));

        Assert.Equal(TechniqueId.Breathing, decision.TechniqueId);
    }

    [Fact]
    public void A_newcomer_who_is_just_exploring_starts_with_grounding()
    {
        TodayRecommendationDecision decision = _service.ResolveTodayTechnique(new TodayRecommendationContext(OnboardingConcernKeys.Explore));

        Assert.Equal(TechniqueId.Grounding, decision.TechniqueId);
    }

    [Fact]
    public void ResolveTodayTechnique_UsesRecentTestWithinSevenDays()
    {
        TodayRecommendationDecision decision = _service.ResolveTodayTechnique(new TodayRecommendationContext(
            OnboardingConcernKeys.Explore,
            RecentTestResult: new PsychologyApp.Application.Models.TestResultDTO
            {
                TestId = "beck",
                Score = 12,
                CompletedAt = DateTime.UtcNow.AddDays(-2)
            }));

        Assert.Equal(TechniqueId.ThoughtDefusion, decision.TechniqueId);
        Assert.Equal(TodayRecommendationSource.RecentTest, decision.Source);
    }

    [Fact]
    public void ResolveTodayTechnique_UsesLuscherCoWhenRecentStandardTest()
    {
        TodayRecommendationDecision decision = _service.ResolveTodayTechnique(new TodayRecommendationContext(
            OnboardingConcernKeys.Explore,
            RecentTestResult: new TestResultDTO
            {
                TestId = TestIds.LuscherStandard,
                Score = 25,
                CompletedAt = DateTime.UtcNow.AddDays(-1)
            }));

        Assert.Equal(TechniqueId.Grounding, decision.TechniqueId);
        Assert.Equal(TodayRecommendationSource.RecentTest, decision.Source);
        Assert.Equal(TestIds.LuscherStandard, decision.TestId);
    }

    [Fact]
    public void ResolveTodayTechnique_UsesLowMoodWhenNoRecentTest()
    {
        TodayRecommendationDecision decision = _service.ResolveTodayTechnique(new TodayRecommendationContext(
            OnboardingConcernKeys.Body,
            TodayMoodLevel: 2));

        Assert.Equal(TechniqueId.Breathing, decision.TechniqueId);
        Assert.Equal(TodayRecommendationSource.LowMood, decision.Source);
    }

    [Fact]
    public void ResolveTodayTechnique_FallsBackToConcern()
    {
        TodayRecommendationDecision decision = _service.ResolveTodayTechnique(new TodayRecommendationContext(
            OnboardingConcernKeys.Anxiety));

        Assert.Equal(TechniqueId.Grounding, decision.TechniqueId);
        Assert.Equal(TodayRecommendationSource.OnboardingConcern, decision.Source);
    }

    [Fact]
    public void ResolveTodayTechnique_PrefersDraftOverTestAndMood()
    {
        TodayRecommendationDecision decision = _service.ResolveTodayTechnique(new TodayRecommendationContext(
            OnboardingConcernKeys.Anxiety,
            RecentTestResult: new TestResultDTO
            {
                TestId = "beck",
                Score = 12,
                CompletedAt = DateTime.UtcNow
            },
            TodayMoodLevel: 1,
            DraftTechniqueId: TechniqueId.Paper));

        Assert.Equal(TechniqueId.Paper, decision.TechniqueId);
        Assert.Equal(TodayRecommendationSource.SessionDraft, decision.Source);
    }

    [Fact]
    public void ResolveTodayTechnique_RotatesAwayFromYesterdayConcernPick()
    {
        Dictionary<string, DateTime> dates = new(StringComparer.Ordinal)
        {
            [TechniqueId.Spin.ToString()] = DateTime.Today.AddDays(-1).ToUniversalTime()
        };

        TodayRecommendationDecision decision = _service.ResolveTodayTechnique(new TodayRecommendationContext(
            OnboardingConcernKeys.Anxiety,
            LastPracticeDatesUtc: dates));

        Assert.NotEqual(TechniqueId.Spin, decision.TechniqueId);
        Assert.Equal(TodayRecommendationSource.OnboardingConcern, decision.Source);
    }

    [Fact]
    public void PickFromPool_PrefersNeverPracticed()
    {
        Dictionary<string, DateTime> dates = new(StringComparer.Ordinal)
        {
            [TechniqueId.Breathing.ToString()] = DateTime.UtcNow.AddDays(-10),
            [TechniqueId.Grounding.ToString()] = DateTime.UtcNow.AddDays(-3)
        };

        TechniqueId picked = TechniqueRecommendationService.PickFromPool(
            [TechniqueId.Breathing, TechniqueId.Grounding, TechniqueId.SmallStep],
            dates);

        Assert.Equal(TechniqueId.SmallStep, picked);
    }

    [Fact]
    public void PickFromPool_PrefersTechniqueWithProvenHigherEffectiveness()
    {
        Dictionary<string, double> effectiveness = new(StringComparer.Ordinal)
        {
            [TechniqueId.Breathing.ToString()] = 4.5,
            [TechniqueId.Grounding.ToString()] = 1.0
        };

        TechniqueId picked = TechniqueRecommendationService.PickFromPool(
            [TechniqueId.Breathing, TechniqueId.Grounding, TechniqueId.SmallStep],
            lastPracticeDatesUtc: null,
            effectiveness);

        Assert.Equal(TechniqueId.Breathing, picked);
    }

    [Fact]
    public void PickFromPool_RanksUnprovenTechniqueAboveOneProvenNotToHelp()
    {
        Dictionary<string, double> effectiveness = new(StringComparer.Ordinal)
        {
            [TechniqueId.Grounding.ToString()] = -1.0
        };

        TechniqueId picked = TechniqueRecommendationService.PickFromPool(
            [TechniqueId.Grounding, TechniqueId.SmallStep],
            lastPracticeDatesUtc: null,
            effectiveness);

        Assert.Equal(TechniqueId.SmallStep, picked);
    }

    [Fact]
    public void PickFromPool_FallsBackToRecencyWithoutEffectivenessData()
    {
        Dictionary<string, DateTime> dates = new(StringComparer.Ordinal)
        {
            [TechniqueId.Breathing.ToString()] = DateTime.UtcNow.AddDays(-10),
            [TechniqueId.Grounding.ToString()] = DateTime.UtcNow.AddDays(-3)
        };

        TechniqueId picked = TechniqueRecommendationService.PickFromPool(
            [TechniqueId.Breathing, TechniqueId.Grounding, TechniqueId.SmallStep],
            dates,
            effectiveness: null);

        Assert.Equal(TechniqueId.SmallStep, picked);
    }

    [Fact]
    public void ResolveNextAfterCompletion_ExcludesCompletedTechnique()
    {
        TodayRecommendationContext context = new(OnboardingConcernKeys.Anxiety);

        TechniqueId next = _service.ResolveNextAfterCompletion(context, TechniqueId.Spin);

        Assert.NotEqual(TechniqueId.Spin, next);
        Assert.Contains(next, new[] { TechniqueId.Breathing, TechniqueId.Grounding, TechniqueId.ThoughtRecord });
    }

    [Fact]
    public void ResolveNextAfterCompletion_UsesLowMoodPoolWhenMoodLow()
    {
        TodayRecommendationContext context = new(
            OnboardingConcernKeys.Anxiety,
            TodayMoodLevel: 1);

        TechniqueId next = _service.ResolveNextAfterCompletion(context, TechniqueId.Breathing);

        Assert.NotEqual(TechniqueId.Breathing, next);
        Assert.Contains(next, new[] { TechniqueId.Grounding, TechniqueId.SmallStep });
    }

    [Fact]
    public void ResolveNextAfterCompletion_FallsBackToExploreWhenConcernPoolFullyCompleted()
    {
        Dictionary<string, DateTime> dates = new(StringComparer.Ordinal)
        {
            [TechniqueId.Breathing.ToString()] = DateTime.UtcNow.AddDays(-5),
            [TechniqueId.Grounding.ToString()] = DateTime.UtcNow.AddDays(-4),
            [TechniqueId.ThoughtRecord.ToString()] = DateTime.UtcNow.AddDays(-3)
        };
        TodayRecommendationContext context = new(
            OnboardingConcernKeys.Anxiety,
            LastPracticeDatesUtc: dates);

        TechniqueId next = _service.ResolveNextAfterCompletion(context, TechniqueId.Spin);

        Assert.NotEqual(TechniqueId.Spin, next);
        Assert.Contains(next, ExploreRotationExcept(TechniqueId.Spin));
    }

    [Fact]
    public void Explore_rotation_reaches_more_wellbeing_practices_after_the_core_set_was_used()
    {
        TechniqueId[] corePractices =
        [
            TechniqueId.Grounding,
            TechniqueId.Breathing,
            TechniqueId.SmallStep,
            TechniqueId.ImplementationIntention,
            TechniqueId.ThoughtDefusion,
            TechniqueId.SelfCompassion,
            TechniqueId.ThoughtRecord,
            TechniqueId.BusyMind,
            TechniqueId.MuscleRelax,
            TechniqueId.CheckTheFacts,
            TechniqueId.WorryTime
        ];
        Dictionary<string, DateTime> dates = corePractices.ToDictionary(
            id => id.ToString(),
            _ => DateTime.UtcNow.AddDays(-3),
            StringComparer.Ordinal);

        TechniqueId next = _service.ResolveNextAfterCompletion(
            new TodayRecommendationContext(OnboardingConcernKeys.Explore, LastPracticeDatesUtc: dates),
            TechniqueId.Breathing);

        Assert.Contains(next, new[]
        {
            TechniqueId.PauseBeforeReaction,
            TechniqueId.OppositeAction,
            TechniqueId.ProblemSolving,
            TechniqueId.ThoughtRecord,
            TechniqueId.SelfCompassion,
            TechniqueId.BusyMind,
            TechniqueId.MuscleRelax,
            TechniqueId.CheckTheFacts,
            TechniqueId.WorryTime
        });
    }

    [Fact]
    public void Anxiety_recommendations_prioritize_practical_skills_before_attention_shift()
    {
        TechniqueId[] existingOptions =
        [
            TechniqueId.Breathing,
            TechniqueId.Grounding,
            TechniqueId.ThoughtRecord,
            TechniqueId.ThoughtDefusion
        ];
        Dictionary<string, DateTime> dates = existingOptions.ToDictionary(
            id => id.ToString(),
            _ => DateTime.UtcNow.AddDays(-3),
            StringComparer.Ordinal);

        TechniqueId next = _service.ResolveNextAfterCompletion(
            new TodayRecommendationContext(OnboardingConcernKeys.Anxiety, LastPracticeDatesUtc: dates),
            TechniqueId.Spin);

        Assert.Equal(TechniqueId.ProblemSolving, next);
    }

    [Fact]
    public void Anxiety_pool_reaches_distanced_self_talk_after_other_options_were_used()
    {
        TechniqueId[] previouslyUsed =
        [
            TechniqueId.Grounding,
            TechniqueId.Breathing,
            TechniqueId.ThoughtDefusion,
            TechniqueId.ThoughtRecord,
            TechniqueId.ProblemSolving,
            TechniqueId.CheckTheFacts,
            TechniqueId.WorryTime,
            TechniqueId.SensoryComfort
        ];
        Dictionary<string, DateTime> dates = previouslyUsed.ToDictionary(
            id => id.ToString(),
            _ => DateTime.UtcNow.AddDays(-3),
            StringComparer.Ordinal);

        TechniqueId next = _service.ResolveNextAfterCompletion(
            new TodayRecommendationContext(OnboardingConcernKeys.Anxiety, LastPracticeDatesUtc: dates),
            TechniqueId.SensoryComfort);

        Assert.Equal(TechniqueId.Observer, next);
    }

    [Fact]
    public void Explore_rotation_reaches_distanced_self_talk_after_earlier_practices()
    {
        Dictionary<string, DateTime> dates = ExploreRotationExcept(TechniqueId.Observer).ToDictionary(
            id => id.ToString(),
            _ => DateTime.UtcNow.AddDays(-3),
            StringComparer.Ordinal);

        TechniqueId next = _service.ResolveNextAfterCompletion(
            new TodayRecommendationContext(OnboardingConcernKeys.Explore, LastPracticeDatesUtc: dates),
            TechniqueId.UrgeSurfing);

        Assert.Equal(TechniqueId.Observer, next);
    }

    [Fact]
    public void Body_recommendations_can_include_muscle_relaxation_after_the_other_options_were_used()
    {
        TechniqueId[] existingOptions =
        [
            TechniqueId.Grounding,
            TechniqueId.Breathing,
            TechniqueId.ThoughtDefusion
        ];
        Dictionary<string, DateTime> dates = existingOptions.ToDictionary(
            id => id.ToString(),
            _ => DateTime.UtcNow.AddDays(-3),
            StringComparer.Ordinal);

        TechniqueId next = _service.ResolveNextAfterCompletion(
            new TodayRecommendationContext(OnboardingConcernKeys.Body, LastPracticeDatesUtc: dates),
            TechniqueId.Grounding);

        Assert.Equal(TechniqueId.MuscleRelax, next);
    }

    [Fact]
    public void Explore_rotation_surfaces_fact_checking_and_worry_time_after_existing_practices_are_used()
    {
        TechniqueId[] previouslyUsed =
        [
            TechniqueId.Grounding,
            TechniqueId.Breathing,
            TechniqueId.SmallStep,
            TechniqueId.ImplementationIntention,
            TechniqueId.ThoughtDefusion,
            TechniqueId.SelfCompassion,
            TechniqueId.ThoughtRecord,
            TechniqueId.BusyMind,
            TechniqueId.PauseBeforeReaction,
            TechniqueId.OppositeAction,
            TechniqueId.ProblemSolving,
            TechniqueId.MuscleRelax
        ];
        Dictionary<string, DateTime> dates = previouslyUsed.ToDictionary(
            id => id.ToString(),
            _ => DateTime.UtcNow.AddDays(-3),
            StringComparer.Ordinal);
        TodayRecommendationContext context = new(OnboardingConcernKeys.Explore, LastPracticeDatesUtc: dates);

        TechniqueId checkFacts = _service.ResolveNextAfterCompletion(context, TechniqueId.ProblemSolving);

        Assert.Equal(TechniqueId.CheckTheFacts, checkFacts);

        dates[TechniqueId.CheckTheFacts.ToString()] = DateTime.UtcNow.AddDays(-2);
        TechniqueId worryTime = _service.ResolveNextAfterCompletion(context, checkFacts);

        Assert.Equal(TechniqueId.WorryTime, worryTime);
    }

    [Fact]
    public void Mood_program_week_three_offers_the_if_then_plan_after_earlier_skills()
    {
        Dictionary<string, DateTime> dates = new(StringComparer.Ordinal)
        {
            [TechniqueId.ThoughtDefusion.ToString()] = DateTime.UtcNow.AddDays(-3),
            [TechniqueId.ProblemSolving.ToString()] = DateTime.UtcNow.AddDays(-3)
        };

        TodayRecommendationDecision decision = _service.ResolveTodayTechnique(new TodayRecommendationContext(
            OnboardingConcernKeys.Mood,
            ActiveProgramType: TherapyProgramType.Mood,
            ActiveProgramWeek: 3,
            LastPracticeDatesUtc: dates));

        Assert.Equal(TechniqueId.ImplementationIntention, decision.TechniqueId);
    }


    private static IEnumerable<TechniqueId> ExploreRotationExcept(TechniqueId exclude) =>
        new[]
        {
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
        }.Where(id => id != exclude);
}
