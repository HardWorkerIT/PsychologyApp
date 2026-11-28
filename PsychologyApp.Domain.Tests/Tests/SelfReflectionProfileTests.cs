using PsychologyApp.Domain.Tests;

namespace PsychologyApp.Domain.Tests.Tests;

public sealed class SelfReflectionProfileTests
{
    [Theory]
    [InlineData(SelfReflectionProfile.Coping)]
    [InlineData(SelfReflectionProfile.Boundaries)]
    [InlineData(SelfReflectionProfile.Values)]
    [InlineData(SelfReflectionProfile.Conflict)]
    [InlineData(SelfReflectionProfile.Recovery)]
    [InlineData(SelfReflectionProfile.Support)]
    [InlineData(SelfReflectionProfile.Strengths)]
    [InlineData(SelfReflectionProfile.Focus)]
    public void IsAnalyzer_RecognizesEveryReflectionQuestionnaire(string analyzerId)
    {
        Assert.True(SelfReflectionProfile.IsAnalyzer(analyzerId));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("reflection_unknown")]
    [InlineData("Reflection_coping")]
    public void IsAnalyzer_RejectsUnknownIds(string? analyzerId)
    {
        Assert.False(SelfReflectionProfile.IsAnalyzer(analyzerId));
    }

    [Theory]
    [InlineData(0, SelfReflectionBand.Explore)]
    [InlineData(8, SelfReflectionBand.Explore)]
    [InlineData(9, SelfReflectionBand.Building)]
    [InlineData(16, SelfReflectionBand.Building)]
    [InlineData(17, SelfReflectionBand.Available)]
    [InlineData(24, SelfReflectionBand.Available)]
    public void Classify_UsesTheDocumentedScoreBands(int score, SelfReflectionBand expected)
    {
        Assert.Equal(expected, SelfReflectionProfile.Classify(score));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(25)]
    public void Classify_RejectsScoresOutsideTheQuestionnaireRange(int score)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => SelfReflectionProfile.Classify(score));
    }
}
