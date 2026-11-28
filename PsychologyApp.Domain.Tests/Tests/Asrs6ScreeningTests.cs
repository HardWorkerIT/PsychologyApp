using PsychologyApp.Domain.Tests;

namespace PsychologyApp.Domain.Tests.Tests;

public sealed class Asrs6ScreeningTests
{
    [Theory]
    [InlineData(0, 0, Asrs6AnswerShade.None)]
    [InlineData(0, 1, Asrs6AnswerShade.Light)]
    [InlineData(0, 2, Asrs6AnswerShade.Dark)]
    [InlineData(2, 4, Asrs6AnswerShade.Dark)]
    [InlineData(3, 1, Asrs6AnswerShade.None)]
    [InlineData(3, 2, Asrs6AnswerShade.Light)]
    [InlineData(3, 3, Asrs6AnswerShade.Dark)]
    [InlineData(5, 4, Asrs6AnswerShade.Dark)]
    public void GetAnswerShade_UsesTheQuestionGroupThreshold(
        int questionIndex,
        int answerIndex,
        Asrs6AnswerShade expected)
    {
        Assert.Equal(expected, Asrs6Screening.GetAnswerShade(questionIndex, answerIndex));
    }

    [Theory]
    [InlineData(-1, 0)]
    [InlineData(6, 0)]
    [InlineData(0, -1)]
    [InlineData(0, 5)]
    public void GetAnswerShade_RejectsIndicesOutsideTheQuestionnaire(int questionIndex, int answerIndex)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Asrs6Screening.GetAnswerShade(questionIndex, answerIndex));
    }

    [Theory]
    [InlineData(0, Asrs6Band.BelowScreeningThreshold)]
    [InlineData(3, Asrs6Band.BelowScreeningThreshold)]
    [InlineData(4, Asrs6Band.ScreeningThresholdReached)]
    [InlineData(6, Asrs6Band.ScreeningThresholdReached)]
    public void Classify_AppliesTheScreeningCutoff(int score, Asrs6Band expected)
    {
        Assert.Equal(expected, Asrs6Screening.Classify(score));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(7)]
    public void Classify_RejectsScoresOutsideTheQuestionnaireRange(int score)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => Asrs6Screening.Classify(score));
    }
}
