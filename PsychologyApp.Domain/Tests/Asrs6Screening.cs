namespace PsychologyApp.Domain.Tests;

public enum Asrs6Band
{
    BelowScreeningThreshold,
    ScreeningThresholdReached
}

public enum Asrs6AnswerShade
{
    None,
    Light,
    Dark
}

public static class Asrs6Screening
{
    public const string AnalyzerId = "asrs6";
    public const int MaximumScore = 6;
    public const int PositiveScreenThreshold = 4;

    public static Asrs6AnswerShade GetAnswerShade(int questionIndex, int answerIndex)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(questionIndex);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(questionIndex, MaximumScore);
        ArgumentOutOfRangeException.ThrowIfNegative(answerIndex);
        ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(answerIndex, 5);

        int thresholdAnswerIndex = questionIndex < 3 ? 2 : 3;
        return answerIndex >= thresholdAnswerIndex
            ? Asrs6AnswerShade.Dark
            : answerIndex == thresholdAnswerIndex - 1
                ? Asrs6AnswerShade.Light
                : Asrs6AnswerShade.None;
    }

    public static Asrs6Band Classify(int score)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(score);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(score, MaximumScore);

        return score >= PositiveScreenThreshold
            ? Asrs6Band.ScreeningThresholdReached
            : Asrs6Band.BelowScreeningThreshold;
    }
}
