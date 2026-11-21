namespace PsychologyApp.Domain.Tests;

public enum BigFiveTrait
{
    Extraversion,
    Agreeableness,
    Conscientiousness,
    EmotionalStability,
    IntellectImagination
}

public readonly record struct BigFiveTraitScore(BigFiveTrait Trait, int Score);

public static class BigFiveProfile
{
    public const string AnalyzerId = "bigfive";
    public const int ItemsPerTrait = 10;
    public const int MaximumTraitScore = ItemsPerTrait * 4;
    public const int Radix = MaximumTraitScore + 1;
    public const int MaximumScore = Radix * Radix * Radix * Radix * Radix - 1;

    // The 50 items are interleaved so each scale is not presented as a block.
    private static readonly (BigFiveTrait Trait, bool ReverseKeyed)[] ItemKeys =
    [
        (BigFiveTrait.Extraversion, false),
        (BigFiveTrait.Agreeableness, true),
        (BigFiveTrait.Conscientiousness, false),
        (BigFiveTrait.EmotionalStability, true),
        (BigFiveTrait.IntellectImagination, false),
        (BigFiveTrait.Extraversion, true),
        (BigFiveTrait.Agreeableness, false),
        (BigFiveTrait.Conscientiousness, true),
        (BigFiveTrait.EmotionalStability, false),
        (BigFiveTrait.IntellectImagination, true),
        (BigFiveTrait.Extraversion, false),
        (BigFiveTrait.Agreeableness, true),
        (BigFiveTrait.Conscientiousness, false),
        (BigFiveTrait.EmotionalStability, true),
        (BigFiveTrait.IntellectImagination, false),
        (BigFiveTrait.Extraversion, true),
        (BigFiveTrait.Agreeableness, false),
        (BigFiveTrait.Conscientiousness, true),
        (BigFiveTrait.EmotionalStability, false),
        (BigFiveTrait.IntellectImagination, true),
        (BigFiveTrait.Extraversion, false),
        (BigFiveTrait.Agreeableness, true),
        (BigFiveTrait.Conscientiousness, false),
        (BigFiveTrait.EmotionalStability, true),
        (BigFiveTrait.IntellectImagination, false),
        (BigFiveTrait.Extraversion, true),
        (BigFiveTrait.Agreeableness, false),
        (BigFiveTrait.Conscientiousness, true),
        (BigFiveTrait.EmotionalStability, true),
        (BigFiveTrait.IntellectImagination, true),
        (BigFiveTrait.Extraversion, false),
        (BigFiveTrait.Agreeableness, true),
        (BigFiveTrait.Conscientiousness, false),
        (BigFiveTrait.EmotionalStability, true),
        (BigFiveTrait.IntellectImagination, false),
        (BigFiveTrait.Extraversion, true),
        (BigFiveTrait.Agreeableness, false),
        (BigFiveTrait.Conscientiousness, true),
        (BigFiveTrait.EmotionalStability, true),
        (BigFiveTrait.IntellectImagination, false),
        (BigFiveTrait.Extraversion, false),
        (BigFiveTrait.Agreeableness, false),
        (BigFiveTrait.Conscientiousness, false),
        (BigFiveTrait.EmotionalStability, true),
        (BigFiveTrait.IntellectImagination, false),
        (BigFiveTrait.Extraversion, true),
        (BigFiveTrait.Agreeableness, false),
        (BigFiveTrait.Conscientiousness, false),
        (BigFiveTrait.EmotionalStability, true),
        (BigFiveTrait.IntellectImagination, false)
    ];

    public static int CalculateScore(IReadOnlyList<int> itemScores)
    {
        ArgumentNullException.ThrowIfNull(itemScores);
        if (itemScores.Count != ItemKeys.Length)
        {
            throw new ArgumentException("The Big Five profile requires exactly 50 responses.", nameof(itemScores));
        }

        int[] traitScores = new int[Enum.GetValues<BigFiveTrait>().Length];
        for (int itemIndex = 0; itemIndex < ItemKeys.Length; itemIndex++)
        {
            int response = itemScores[itemIndex];
            ArgumentOutOfRangeException.ThrowIfNegative(response);
            ArgumentOutOfRangeException.ThrowIfGreaterThan(response, 4);

            (BigFiveTrait trait, bool reverseKeyed) = ItemKeys[itemIndex];
            traitScores[(int)trait] += reverseKeyed ? 4 - response : response;
        }

        int packedScore = 0;
        int placeValue = 1;
        foreach (int traitScore in traitScores)
        {
            packedScore += traitScore * placeValue;
            placeValue *= Radix;
        }

        return packedScore;
    }

    public static IReadOnlyList<BigFiveTraitScore> Decode(int score)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(score);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(score, MaximumScore);

        BigFiveTrait[] traits = Enum.GetValues<BigFiveTrait>();
        List<BigFiveTraitScore> result = new(traits.Length);
        int remaining = score;

        foreach (BigFiveTrait trait in traits)
        {
            result.Add(new BigFiveTraitScore(trait, remaining % Radix));
            remaining /= Radix;
        }

        return result;
    }
}
