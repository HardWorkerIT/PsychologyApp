using PsychologyApp.Application.Models;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.ClinicalCare;

public sealed record TherapyProgramWeekPlan(
    TherapyProgramType ProgramType,
    int Week,
    IReadOnlyList<TechniqueId> TechniquePool,
    string GoalKey);

public static class TherapyProgramCatalog
{
    public const int TotalWeeks = 4;

    public static TherapyProgramWeekPlan GetWeekPlan(TherapyProgramType programType, int week)
    {
        int normalizedWeek = Math.Clamp(week, 1, TotalWeeks);
        return new TherapyProgramWeekPlan(
            programType,
            normalizedWeek,
            ResolvePool(programType, normalizedWeek),
            $"week_{normalizedWeek}");
    }

    public static IReadOnlyList<TechniqueId> ResolvePool(TherapyProgramType programType, int week) =>
        (programType, Math.Clamp(week, 1, TotalWeeks)) switch
        {
            (TherapyProgramType.Anxiety, 1) => [TechniqueId.Grounding, TechniqueId.Breathing, TechniqueId.ThoughtDefusion],
            (TherapyProgramType.Anxiety, 2) => [TechniqueId.ThoughtRecord, TechniqueId.ThoughtDefusion, TechniqueId.SelfCompassion],
            (TherapyProgramType.Anxiety, 3) => [TechniqueId.Breathing, TechniqueId.ThoughtRecord, TechniqueId.SmallStep],
            (TherapyProgramType.Anxiety, _) => [TechniqueId.CheckTheFacts, TechniqueId.WorryTime, TechniqueId.ProblemSolving],

            (TherapyProgramType.Mood, 1) => [TechniqueId.SmallStep, TechniqueId.SelfCompassion, TechniqueId.Breathing],
            (TherapyProgramType.Mood, 2) => [TechniqueId.ThoughtRecord, TechniqueId.SmallStep, TechniqueId.SelfCompassion],
            (TherapyProgramType.Mood, 3) => [TechniqueId.ThoughtDefusion, TechniqueId.ProblemSolving, TechniqueId.ImplementationIntention],
            (TherapyProgramType.Mood, _) => [TechniqueId.SelfCompassion, TechniqueId.SmallStep, TechniqueId.ThoughtDefusion],

            // Breathing first: this is also the programme of someone who only came to look around, and their first practice
            // should not be rewriting a painful experience.
            (TherapyProgramType.Stress, 1) => [TechniqueId.Breathing, TechniqueId.Grounding, TechniqueId.SmallStep],
            (TherapyProgramType.Stress, 2) => [TechniqueId.Grounding, TechniqueId.ThoughtDefusion, TechniqueId.MuscleRelax],
            (TherapyProgramType.Stress, 3) => [TechniqueId.WorryTime, TechniqueId.ThoughtRecord, TechniqueId.Breathing],
            _ => [TechniqueId.Grounding, TechniqueId.ThoughtDefusion, TechniqueId.SmallStep]
        };
}
