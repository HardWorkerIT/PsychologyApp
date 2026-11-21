using PsychologyApp.Domain.Tests;

namespace PsychologyApp.Domain.Tests.UnitTests;

public sealed class PreferenceProfile16Tests
{
    [Theory]
    [InlineData("ISTJ")]
    [InlineData("ISFJ")]
    [InlineData("INFJ")]
    [InlineData("INTJ")]
    [InlineData("ISTP")]
    [InlineData("ISFP")]
    [InlineData("INFP")]
    [InlineData("INTP")]
    [InlineData("ESTP")]
    [InlineData("ESFP")]
    [InlineData("ENFP")]
    [InlineData("ENTP")]
    [InlineData("ESTJ")]
    [InlineData("ESFJ")]
    [InlineData("ENFJ")]
    [InlineData("ENTJ")]
    public void DecodeTypeCode_CanRepresentAllSixteenProfiles(string expected)
    {
        int score =
            (expected[0] == 'I' ? 3 : 0)
            + (expected[1] == 'N' ? 18 : 0)
            + (expected[2] == 'F' ? 108 : 0)
            + (expected[3] == 'P' ? 648 : 0);

        Assert.Equal(expected, PreferenceProfile16.DecodeTypeCode(score));
    }

    [Theory]
    [InlineData(0, "ESTJ")]
    [InlineData(1295, "INFP")]
    [InlineData(3, "ISTJ")]
    [InlineData(18, "ENTJ")]
    [InlineData(108, "ESFJ")]
    [InlineData(647, "INFJ")]
    [InlineData(648, "ESTP")]
    public void DecodeTypeCode_UsesIndependentPreferenceAxes(int score, string expected)
    {
        Assert.Equal(expected, PreferenceProfile16.DecodeTypeCode(score));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(1296)]
    public void DecodeTypeCode_RejectsScoresOutsideTheQuestionnaireRange(int score)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => PreferenceProfile16.DecodeTypeCode(score));
    }
}
