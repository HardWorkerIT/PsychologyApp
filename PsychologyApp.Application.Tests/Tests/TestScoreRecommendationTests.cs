using PsychologyApp.Application.Models;
using PsychologyApp.Application.Tests;
using Xunit;

namespace PsychologyApp.Application.Tests.Tests;

public sealed class TestScoreRecommendationTests
{
    private static readonly TechniqueId[] ArchivedTechniqueIds =
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

    [Theory]
    [InlineData("beck", 10, TechniqueId.ThoughtDefusion)]
    [InlineData("beck", 5, TechniqueId.ThoughtRecord)]
    [InlineData("heck_hess", 25, TechniqueId.CheckTheFacts)]
    [InlineData("haer", 29, TechniqueId.SmallStep)]
    [InlineData("gad7", 10, TechniqueId.CheckTheFacts)]
    [InlineData("gad7", 5, TechniqueId.Breathing)]
    [InlineData("k10", 22, TechniqueId.Grounding)]
    [InlineData("k10", 16, TechniqueId.Breathing)]
    [InlineData("k10", 12, TechniqueId.ThoughtDefusion)]
    [InlineData("who5", 12, TechniqueId.SmallStep)]
    [InlineData("who5", 20, TechniqueId.SmallStep)]
    [InlineData("phq9", 10, TechniqueId.Grounding)]
    [InlineData("phq9", 5, TechniqueId.SmallStep)]
    [InlineData("isi", 22, TechniqueId.Grounding)]
    [InlineData("isi", 15, TechniqueId.Breathing)]
    [InlineData("isi", 10, TechniqueId.WorryTime)]
    [InlineData("ess", 16, TechniqueId.Grounding)]
    [InlineData("ess", 11, TechniqueId.Breathing)]
    [InlineData("ess", 8, TechniqueId.Grounding)]
    [InlineData("phq15", 15, TechniqueId.Grounding)]
    [InlineData("phq15", 10, TechniqueId.Breathing)]
    [InlineData("phq15", 5, TechniqueId.Grounding)]
    [InlineData("scoff", 2, TechniqueId.SelfCompassion)]
    [InlineData("scoff", 1, TechniqueId.SelfCompassion)]
    [InlineData("swls", 20, TechniqueId.SmallStep)]
    [InlineData("swls", 25, TechniqueId.SelfCompassion)]
    [InlineData("pss10", 30, TechniqueId.Grounding)]
    [InlineData("pss10", 20, TechniqueId.Breathing)]
    [InlineData("pss10", 10, TechniqueId.ProblemSolving)]
    [InlineData("phq2", 4, TechniqueId.SmallStep)]
    [InlineData("phq2", 1, TechniqueId.ThoughtRecord)]
    [InlineData("gad2", 4, TechniqueId.Breathing)]
    [InlineData("gad2", 1, TechniqueId.Grounding)]
    [InlineData("hads_a", 12, TechniqueId.Grounding)]
    [InlineData("hads_a", 9, TechniqueId.Breathing)]
    [InlineData("hads_a", 5, TechniqueId.Grounding)]
    [InlineData("hads_d", 12, TechniqueId.SmallStep)]
    [InlineData("hads_d", 9, TechniqueId.SelfCompassion)]
    [InlineData("hads_d", 5, TechniqueId.ThoughtRecord)]
    [InlineData("rses", 10, TechniqueId.SelfCompassion)]
    [InlineData("rses", 20, TechniqueId.SmallStep)]
    [InlineData("rses", 28, TechniqueId.SelfCompassion)]
    [InlineData("pcptsd5", 3, TechniqueId.Grounding)]
    [InlineData("pcl5", 33, TechniqueId.Grounding)]
    [InlineData("pcl5", 15, TechniqueId.Grounding)]
    [InlineData("unknown", 0, TechniqueId.Grounding)]
    public void RecommendTechnique_ReturnsExpected(string analyzerId, int score, TechniqueId expected)
    {
        TechniqueId? result = TestScoreRecommendation.RecommendTechnique(analyzerId, score);

        Assert.Equal(expected, result);
        if (result is TechniqueId techniqueId)
        {
            Assert.DoesNotContain(techniqueId, ArchivedTechniqueIds);
        }
    }
}
