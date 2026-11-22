using PsychologyApp.Application.Abstractions.Persistence;
using PsychologyApp.Application.Models;
using PsychologyApp.Application.UserProgress;
using PsychologyApp.Domain.ClinicalCare;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.ClinicalCare;

public sealed class ClinicalCareService(
    IClinicalCareRepository repository,
    IUserProgressService userProgressService,
    TimeProvider? timeProvider = null) : IClinicalCareService
{
    public static readonly TimeSpan DefaultRiskCheckInterval = TimeSpan.FromDays(30);

    private static readonly TimeSpan ElevatedRiskCheckInterval = TimeSpan.FromDays(7);
    private static readonly TimeSpan CurrentRedRiskWindow = TimeSpan.FromDays(7);

    /// <summary>How long a "weekly_scorecard" escalation of one kind is remembered before another may be recorded.</summary>
    private static readonly TimeSpan ScorecardEscalationCooldown = TimeSpan.FromDays(7);

    private const string ScorecardTriggerSource = "weekly_scorecard";

    private readonly TimeProvider time = timeProvider ?? TimeProvider.System;

    private DateTime UtcNow => time.GetUtcNow().UtcDateTime;

    /// <summary>An explicit red check-in is time-sensitive; after a week it no longer describes today's risk.</summary>
    private bool IsCurrent(RiskAssessmentDTO assessment)
    {
        TimeSpan age = UtcNow - assessment.AssessedAt;
        return age >= TimeSpan.Zero && age <= CurrentRedRiskWindow;
    }

    public async Task<RiskAssessmentDTO> AssessRiskAsync(
        RiskAssessmentInput input,
        CancellationToken cancellationToken = default)
    {
        RiskLevel riskLevel = RiskClassifier.Classify(new RiskAssessmentSignals(
            input.HasSelfHarmThoughts,
            input.HasSevereDisorientation,
            input.HasSubstanceRisk,
            input.HasSevereInsomnia));
        RiskAssessmentDTO assessment = new()
        {
            AssessedAt = UtcNow,
            Source = string.IsNullOrWhiteSpace(input.Source) ? "unknown" : input.Source,
            Notes = input.Notes ?? string.Empty,
            HasSelfHarmThoughts = input.HasSelfHarmThoughts,
            HasSevereDisorientation = input.HasSevereDisorientation,
            HasSubstanceRisk = input.HasSubstanceRisk,
            HasSevereInsomnia = input.HasSevereInsomnia,
            RiskLevel = riskLevel
        };

        await repository.SaveRiskAssessmentAsync(assessment, cancellationToken).ConfigureAwait(false);

        if (riskLevel is RiskLevel.Red)
        {
            await repository.SaveEscalationEventAsync(
                new EscalationEventDTO
                {
                    CreatedAt = UtcNow,
                    RiskLevel = riskLevel,
                    TriggerSource = assessment.Source,
                    Action = EscalationActions.RouteToCrisisHub,
                    Notes = assessment.Notes
                },
                cancellationToken).ConfigureAwait(false);
        }
        else if (riskLevel is RiskLevel.Amber)
        {
            await repository.SaveEscalationEventAsync(
                new EscalationEventDTO
                {
                    CreatedAt = UtcNow,
                    RiskLevel = riskLevel,
                    TriggerSource = assessment.Source,
                    Action = EscalationActions.OfferSpecialistHelp,
                    Notes = assessment.Notes
                },
                cancellationToken).ConfigureAwait(false);
        }

        return assessment;
    }

    public Task<RiskAssessmentDTO?> GetLatestRiskAssessmentAsync(CancellationToken cancellationToken = default) =>
        repository.GetLatestRiskAssessmentAsync(cancellationToken);

    public async Task<bool> IsRiskCheckDueAsync(TimeSpan maxAge, CancellationToken cancellationToken = default)
    {
        RiskAssessmentDTO? latest = await repository.GetLatestRiskAssessmentAsync(cancellationToken).ConfigureAwait(false);
        if (latest is null)
        {
            return true;
        }

        // Elevated results keep a weekly follow-up; a green result uses the less frequent routine interval.
        TimeSpan effectiveMaxAge = latest.RiskLevel is RiskLevel.Green || maxAge <= ElevatedRiskCheckInterval
            ? maxAge
            : ElevatedRiskCheckInterval;

        // A restored timestamp or a clock correction must not defer a check indefinitely.
        DateTime now = UtcNow;
        return latest.AssessedAt > now || now - latest.AssessedAt > effectiveMaxAge;
    }

    public async Task<bool> ShouldRouteToCrisisHubAsync(CancellationToken cancellationToken = default)
    {
        // Only a recent Red routes to the crisis hub. An old one must not trap the person there: the weekly follow-up asks them
        // to check in again instead (IsRiskCheckDueAsync), independently from the monthly routine interval.
        RiskAssessmentDTO? latest = await repository.GetLatestRiskAssessmentAsync(cancellationToken).ConfigureAwait(false);
        return latest is { RiskLevel: RiskLevel.Red } && IsCurrent(latest);
    }

    public async Task<TherapyProgramStateDTO> EnsureProgramAsync(
        string onboardingConcern,
        CancellationToken cancellationToken = default)
    {
        TherapyProgramStateDTO? existing = await repository.GetActiveProgramAsync(cancellationToken).ConfigureAwait(false);
        if (existing is not null)
        {
            return await AdvanceProgramWeekIfDueAsync(cancellationToken).ConfigureAwait(false) ?? existing;
        }

        TherapyProgramStateDTO program = new()
        {
            ProgramType = ResolveProgram(onboardingConcern),
            StartedAt = UtcNow,
            CurrentWeek = 1,
            IsActive = true
        };
        await repository.UpsertActiveProgramAsync(program, cancellationToken).ConfigureAwait(false);
        return program;
    }

    public Task<TherapyProgramStateDTO?> GetActiveProgramAsync(CancellationToken cancellationToken = default) =>
        repository.GetActiveProgramAsync(cancellationToken);

    public async Task<TherapyProgramStateDTO?> AdvanceProgramWeekIfDueAsync(CancellationToken cancellationToken = default)
    {
        TherapyProgramStateDTO? existing = await repository.GetActiveProgramAsync(cancellationToken).ConfigureAwait(false);
        if (existing is null)
        {
            return null;
        }

        int elapsedWeeks = Math.Max(0, (UtcNow.Date - existing.StartedAt.ToUniversalTime().Date).Days / 7) + 1;
        int targetWeek = Math.Clamp(elapsedWeeks, 1, TherapyProgramCatalog.TotalWeeks);
        if (targetWeek == existing.CurrentWeek)
        {
            return existing;
        }

        TherapyProgramStateDTO advanced = new()
        {
            ProgramType = existing.ProgramType,
            StartedAt = existing.StartedAt,
            CurrentWeek = targetWeek,
            IsActive = existing.IsActive
        };
        await repository.UpsertActiveProgramAsync(advanced, cancellationToken).ConfigureAwait(false);
        return advanced;
    }

    public async Task<TherapyProgramWeekPlan?> GetActiveWeekPlanAsync(CancellationToken cancellationToken = default)
    {
        TherapyProgramStateDTO? program = await AdvanceProgramWeekIfDueAsync(cancellationToken).ConfigureAwait(false);
        if (program is null || !program.IsActive)
        {
            return null;
        }

        return TherapyProgramCatalog.GetWeekPlan(program.ProgramType, program.CurrentWeek);
    }

    public async Task<TherapyProgramAdherence?> GetActiveWeekAdherenceAsync(CancellationToken cancellationToken = default)
    {
        TherapyProgramStateDTO? program = await AdvanceProgramWeekIfDueAsync(cancellationToken).ConfigureAwait(false);
        if (program is null || !program.IsActive)
        {
            return null;
        }

        TherapyProgramWeekPlan weekPlan = TherapyProgramCatalog.GetWeekPlan(program.ProgramType, program.CurrentWeek);
        DateTime weekStartUtc = program.StartedAt.ToUniversalTime().Date.AddDays((program.CurrentWeek - 1) * 7);
        DateTime weekEndUtc = weekStartUtc.AddDays(7);
        IReadOnlyList<string> poolKeys = weekPlan.TechniquePool
            .Select(technique => technique.ToString())
            .ToList();
        int completed = await userProgressService.CountDistinctTechniqueCompletionsForItemsBetweenAsync(
            poolKeys,
            weekStartUtc,
            weekEndUtc,
            cancellationToken).ConfigureAwait(false);

        return new TherapyProgramAdherence(program, weekPlan, completed);
    }

    public async Task<ClinicalScorecardDTO> BuildWeeklyScorecardAsync(CancellationToken cancellationToken = default)
    {
        DateOnly today = DateOnly.FromDateTime(time.GetLocalNow().DateTime);
        DateOnly weekStart = today.AddDays(-6);
        DateTime localWeekStart = weekStart.ToDateTime(TimeOnly.MinValue, DateTimeKind.Unspecified);
        DateTime weekStartUtc = TimeZoneInfo.ConvertTimeToUtc(localWeekStart, time.LocalTimeZone);
        DateTime nowUtc = UtcNow;

        int practiceCount = await userProgressService.CountTechniqueCompletionsBetweenAsync(
            weekStartUtc,
            nowUtc.AddTicks(1),
            cancellationToken).ConfigureAwait(false);

        IReadOnlyList<MoodEntryDTO> moods = await userProgressService.GetMoodsAsync(
            weekStartUtc,
            nowUtc.AddTicks(1),
            60,
            cancellationToken).ConfigureAwait(false);
        IReadOnlyList<MoodEntryDTO> weekMoods = moods
            .Where(entry => entry.RecordedAt <= nowUtc
                && DateOnly.FromDateTime(entry.RecordedAt.ToLocalTime()) >= weekStart
                && DateOnly.FromDateTime(entry.RecordedAt.ToLocalTime()) <= today)
            .ToList();
        double avgMood = weekMoods.Count == 0 ? 0 : weekMoods.Average(entry => entry.MoodLevel);

        long testCountTotal = await userProgressService.CountTestResultsAsync(cancellationToken).ConfigureAwait(false);
        int testCount = (int)Math.Min(int.MaxValue, testCountTotal);

        RiskAssessmentDTO? latestRisk = await repository.GetLatestRiskAssessmentAsync(cancellationToken).ConfigureAwait(false);
        // A months-old "green" must not hide a bad week, so only a current explicit check overrides the weekly signals.
        RiskLevel riskLevel = latestRisk is not null && IsCurrent(latestRisk)
            ? latestRisk.RiskLevel
            : RiskClassifier.DeriveFromMoodPracticeSignals(avgMood, practiceCount);

        return new ClinicalScorecardDTO
        {
            WeekStart = weekStart,
            WeekEnd = today,
            PracticeCount = practiceCount,
            MoodEntriesCount = weekMoods.Count,
            TestCount = testCount,
            AverageMoodLevel = avgMood,
            RiskLevel = riskLevel,
            Summary = BuildSummary(practiceCount, weekMoods.Count, avgMood, riskLevel)
        };
    }

    /// <summary>
    /// Records an escalation when the weekly signals are Amber or Red and otherwise moves the program on by the calendar.
    /// The program's week is derived from its start date, so this does not (and cannot) "hold" a week; it also does not write on
    /// every call: one escalation per kind is recorded per <see cref="ScorecardEscalationCooldown"/>, however often a screen refreshes.
    /// </summary>
    public async Task<TherapyProgramStateDTO?> AdjustProgramFromScorecardAsync(CancellationToken cancellationToken = default)
    {
        ClinicalScorecardDTO scorecard = await BuildWeeklyScorecardAsync(cancellationToken).ConfigureAwait(false);
        TherapyProgramStateDTO? program = await repository.GetActiveProgramAsync(cancellationToken).ConfigureAwait(false);
        if (program is null)
        {
            return null;
        }

        if (scorecard.RiskLevel is RiskLevel.Red or RiskLevel.Amber)
        {
            string action = scorecard.RiskLevel is RiskLevel.Red
                ? EscalationActions.RouteToCrisisHub
                : EscalationActions.OfferSpecialistHelp;
            await RecordScorecardEscalationOnceAsync(scorecard, action, cancellationToken).ConfigureAwait(false);
            return program;
        }

        return await AdvanceProgramWeekIfDueAsync(cancellationToken).ConfigureAwait(false);
    }

    private async Task RecordScorecardEscalationOnceAsync(
        ClinicalScorecardDTO scorecard,
        string action,
        CancellationToken cancellationToken)
    {
        IReadOnlyList<EscalationEventDTO> recent = await repository.GetRecentEscalationsAsync(20, cancellationToken).ConfigureAwait(false);
        DateTime now = UtcNow;
        bool alreadyRecorded = recent.Any(e =>
        {
            TimeSpan age = now - e.CreatedAt;
            return e.TriggerSource == ScorecardTriggerSource
                && e.Action == action
                && age >= TimeSpan.Zero
                && age < ScorecardEscalationCooldown;
        });
        if (alreadyRecorded)
        {
            return;
        }

        await repository.SaveEscalationEventAsync(
            new EscalationEventDTO
            {
                CreatedAt = now,
                RiskLevel = scorecard.RiskLevel,
                TriggerSource = ScorecardTriggerSource,
                Action = action,
                Notes = scorecard.Summary
            },
            cancellationToken).ConfigureAwait(false);
    }


    public Task<IReadOnlyList<EscalationEventDTO>> GetRecentEscalationsAsync(
        int limit = 20,
        CancellationToken cancellationToken = default) =>
        repository.GetRecentEscalationsAsync(limit, cancellationToken);

    public async Task<SafetyPlanDTO> GetSafetyPlanAsync(CancellationToken cancellationToken = default) =>
        await repository.GetSafetyPlanAsync(cancellationToken).ConfigureAwait(false) ?? new SafetyPlanDTO();

    public Task SaveSafetyPlanAsync(SafetyPlanDTO plan, CancellationToken cancellationToken = default) =>
        repository.SaveSafetyPlanAsync(
            new SafetyPlanDTO
            {
                WarningSigns = plan.WarningSigns,
                CopingStrategies = plan.CopingStrategies,
                Contacts = plan.Contacts,
                Reasons = plan.Reasons,
                UpdatedAt = UtcNow
            },
            cancellationToken);

    private static TherapyProgramType ResolveProgram(string concern) =>
        concern switch
        {
            OnboardingConcernKeys.Anxiety => TherapyProgramType.Anxiety,
            OnboardingConcernKeys.Mood => TherapyProgramType.Mood,
            _ => TherapyProgramType.Stress
        };

    private static string BuildSummary(int practiceCount, int moodCount, double avgMood, RiskLevel riskLevel)
    {
        string moodText = moodCount == 0 ? "no mood check-ins" : $"avg mood {avgMood:F1}";
        return $"Week: {practiceCount} practices, {moodText}, risk {riskLevel}.";
    }
}

public static class EscalationActions
{
    public const string RouteToCrisisHub = "route_to_crisis_hub";
    public const string OfferSpecialistHelp = "offer_specialist_help";
}
