using PsychologyApp.Domain.Tests;

namespace PsychologyApp.Domain.Tests.Tests;

public sealed class BigFiveProfileTests
{
    [Fact]
    public void CalculateScore_MapsNeutralAnswersToTheMidpointOfEveryTrait()
    {
        int[] answers = Enumerable.Repeat(2, 50).ToArray();

        IReadOnlyList<BigFiveTraitScore> profile = BigFiveProfile.Decode(BigFiveProfile.CalculateScore(answers));

        Assert.Equal(Enum.GetValues<BigFiveTrait>(), profile.Select(item => item.Trait));
        Assert.All(profile, item => Assert.Equal(20, item.Score));
    }

    [Fact]
    public void CalculateScore_RespectsForwardAndReverseKeyedAnswers()
    {
        int[] answers = Enumerable.Repeat(2, 50).ToArray();
        answers[0] = 4; // Forward-keyed Extraversion item.
        answers[1] = 4; // Reverse-keyed Agreeableness item.

        IReadOnlyList<BigFiveTraitScore> profile = BigFiveProfile.Decode(BigFiveProfile.CalculateScore(answers));

        Assert.Equal(22, profile.Single(item => item.Trait == BigFiveTrait.Extraversion).Score);
        Assert.Equal(18, profile.Single(item => item.Trait == BigFiveTrait.Agreeableness).Score);
        Assert.All(
            profile.Where(item => item.Trait is not (BigFiveTrait.Extraversion or BigFiveTrait.Agreeableness)),
            item => Assert.Equal(20, item.Score));
    }

    [Fact]
    public void CalculateScore_RequiresExactlyFiftyResponses()
    {
        Assert.Throws<ArgumentNullException>(() => BigFiveProfile.CalculateScore(null!));
        Assert.Throws<ArgumentException>(() => BigFiveProfile.CalculateScore(new int[49]));
        Assert.Throws<ArgumentException>(() => BigFiveProfile.CalculateScore(new int[51]));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(5)]
    public void CalculateScore_RejectsAnAnswerOutsideTheScale(int invalidAnswer)
    {
        int[] answers = new int[50];
        answers[17] = invalidAnswer;

        Assert.Throws<ArgumentOutOfRangeException>(() => BigFiveProfile.CalculateScore(answers));
    }

    [Fact]
    public void Decode_RoundTripsPackedTraitScores()
    {
        int[] traitScores = [0, 1, 17, 39, 40];
        int packedScore = 0;
        int placeValue = 1;
        foreach (int traitScore in traitScores)
        {
            packedScore += traitScore * placeValue;
            placeValue *= BigFiveProfile.Radix;
        }

        IReadOnlyList<BigFiveTraitScore> profile = BigFiveProfile.Decode(packedScore);

        Assert.Equal(traitScores, profile.Select(item => item.Score));
    }

    [Fact]
    public void Decode_MapsTheMaximumScoreToTheMaximumOfEveryTrait()
    {
        IReadOnlyList<BigFiveTraitScore> profile = BigFiveProfile.Decode(BigFiveProfile.MaximumScore);

        Assert.All(profile, item => Assert.Equal(BigFiveProfile.MaximumTraitScore, item.Score));
    }

    [Theory]
    [InlineData(-1)]
    [InlineData(BigFiveProfile.MaximumScore + 1)]
    public void Decode_RejectsScoresOutsideThePackedRange(int score)
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => BigFiveProfile.Decode(score));
    }
}
