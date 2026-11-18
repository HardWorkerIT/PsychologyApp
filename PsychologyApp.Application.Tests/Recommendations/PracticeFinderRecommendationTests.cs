using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Application.Recommendations;
using PsychologyApp.Domain.Practice;
using Xunit;

namespace PsychologyApp.Application.Tests.Recommendations;

public sealed class PracticeFinderRecommendationTests
{
    [Fact]
    public void ConnectionNeedOffersTheDedicatedConnectionPractice()
    {
        TechniqueListEntry[] entries =
        [
            Entry(TechniqueId.ConnectionStepPlan),
            Entry(TechniqueId.Grounding)
        ];

        IReadOnlyList<TechniqueListEntry> matches = PracticeFinderRecommendation.FindSuitablePractices(
            PracticeFinderNeed.Connection,
            entries);

        Assert.Equal([TechniqueId.ConnectionStepPlan], matches.Select(entry => entry.TechniqueId));
    }

    [Fact]
    public void NoBreathFocusNeedOffersExternalOrientationFirst()
    {
        TechniqueListEntry[] entries =
        [
            Entry(TechniqueId.ExternalOrientation),
            Entry(TechniqueId.BusyMind)
        ];

        IReadOnlyList<TechniqueListEntry> matches = PracticeFinderRecommendation.FindSuitablePractices(
            PracticeFinderNeed.NoBreathFocus,
            entries);

        Assert.Equal(TechniqueId.ExternalOrientation, matches[0].TechniqueId);
        Assert.Contains(matches, entry => entry.TechniqueId == TechniqueId.BusyMind);
    }

    private static TechniqueListEntry Entry(TechniqueId id) =>
        new(id, "1", string.Empty, id.ToString(), string.Empty, string.Empty, string.Empty, 3, string.Empty);
}
