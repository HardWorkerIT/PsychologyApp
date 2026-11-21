namespace PsychologyApp.Domain.Tests;

public enum SelfReflectionBand
{
    Explore,
    Building,
    Available
}

public static class SelfReflectionProfile
{
    public const int MaximumScore = 24;

    public const string Coping = "reflection_coping";
    public const string Boundaries = "reflection_boundaries";
    public const string Values = "reflection_values";
    public const string Conflict = "reflection_conflict";
    public const string Recovery = "reflection_recovery";
    public const string Support = "reflection_support";
    public const string Strengths = "reflection_strengths";
    public const string Focus = "reflection_focus";

    public static bool IsAnalyzer(string? analyzerId) => analyzerId is
        Coping or Boundaries or Values or Conflict or Recovery or Support or Strengths or Focus;

    public static SelfReflectionBand Classify(int score)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(score);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(score, MaximumScore);

        return score switch
        {
            <= 8 => SelfReflectionBand.Explore,
            <= 16 => SelfReflectionBand.Building,
            _ => SelfReflectionBand.Available
        };
    }
}
