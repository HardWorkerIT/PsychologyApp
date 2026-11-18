using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Recommendations;

public enum PracticeFinderNeed
{
    Quick,
    EyesOpen,
    NoBreathFocus,
    NoTyping,
    Public,
    BeforeConversation,
    PassengerCommute,
    BeforeSleep,
    AfterConflict,
    Connection
}

public static class PracticeFinderRecommendation
{
    private static readonly IReadOnlyDictionary<PracticeFinderNeed, TechniqueId[]> PracticeIdsByNeed =
        new Dictionary<PracticeFinderNeed, TechniqueId[]>
        {
            [PracticeFinderNeed.EyesOpen] =
            [
                TechniqueId.ExternalOrientation, TechniqueId.Grounding, TechniqueId.BusyMind, TechniqueId.ThoughtDefusion,
                TechniqueId.Balloons, TechniqueId.CheckTheFacts
            ],
            [PracticeFinderNeed.NoBreathFocus] =
            [
                TechniqueId.ExternalOrientation, TechniqueId.BusyMind, TechniqueId.ThoughtDefusion,
                TechniqueId.CheckTheFacts, TechniqueId.Observer
            ],
            // Put the practice that explicitly works silently first; longer answer flows stay later.
            [PracticeFinderNeed.NoTyping] =
            [TechniqueId.ThoughtDefusion, TechniqueId.BusyMind, TechniqueId.Balloons, TechniqueId.Grounding],
            [PracticeFinderNeed.Public] =
            [TechniqueId.ExternalOrientation, TechniqueId.ThoughtDefusion, TechniqueId.BusyMind, TechniqueId.Grounding],
            [PracticeFinderNeed.BeforeConversation] =
            [TechniqueId.PauseBeforeReaction, TechniqueId.ImplementationIntention, TechniqueId.CheckTheFacts],
            [PracticeFinderNeed.PassengerCommute] =
            [TechniqueId.Grounding, TechniqueId.BusyMind, TechniqueId.ThoughtDefusion],
            [PracticeFinderNeed.BeforeSleep] = [TechniqueId.MuscleRelax, TechniqueId.SelfCompassion],
            [PracticeFinderNeed.AfterConflict] =
            [TechniqueId.PauseBeforeReaction, TechniqueId.Grounding, TechniqueId.CheckTheFacts],
            [PracticeFinderNeed.Connection] = [TechniqueId.ConnectionStepPlan]
        };

    // Start with an optional-writing prompt so the short-time path has minimal interaction.
    private static readonly TechniqueId[] QuickPracticeIds =
        [TechniqueId.ThoughtDefusion, TechniqueId.BusyMind, TechniqueId.Observer];

    public static IReadOnlyList<TechniqueListEntry> FindSuitablePractices(
        PracticeFinderNeed need,
        IReadOnlyList<TechniqueListEntry> entries)
    {
        ArgumentNullException.ThrowIfNull(entries);

        IReadOnlyList<TechniqueId> preferredIds = need switch
        {
            PracticeFinderNeed.Quick => QuickPracticeIds,
            _ when PracticeIdsByNeed.TryGetValue(need, out TechniqueId[]? ids) && ids is not null => ids,
            _ => []
        };

        Dictionary<TechniqueId, TechniqueListEntry> entriesById = entries.ToDictionary(entry => entry.TechniqueId);
        List<TechniqueListEntry> results = [];

        foreach (TechniqueId techniqueId in preferredIds)
        {
            if (entriesById.TryGetValue(techniqueId, out TechniqueListEntry? entry)
                && entry is not null
                && (need != PracticeFinderNeed.Quick || entry.DurationMinutes <= 2))
            {
                results.Add(entry);
            }
        }

        return results;
    }
}
