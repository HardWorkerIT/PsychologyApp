namespace PsychologyApp.Domain.Tests;

/// <summary>
/// Decodes the four preference counts packed into a base-six questionnaire score.
/// Five questions contribute to each axis, so base six keeps the axes independent.
/// This is a result format for an informal reflection quiz, not a validated measure.
/// </summary>
public static class PreferenceProfile16
{
    public const string AnalyzerId = "preferences16";
    public const int MaximumScore = 1295;

    public static string DecodeTypeCode(int score)
    {
        ArgumentOutOfRangeException.ThrowIfNegative(score);
        ArgumentOutOfRangeException.ThrowIfGreaterThan(score, MaximumScore);

        int introversion = score % 6;
        int intuition = score / 6 % 6;
        int feeling = score / 36 % 6;
        int perceiving = score / 216 % 6;

        char[] typeCode =
        [
            introversion >= 3 ? 'I' : 'E',
            intuition >= 3 ? 'N' : 'S',
            feeling >= 3 ? 'F' : 'T',
            perceiving >= 3 ? 'P' : 'J'
        ];
        return new string(typeCode);
    }

    public static IReadOnlyList<char> DecodePreferences(string typeCode)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(typeCode);
        if (typeCode.Length != 4
            || typeCode[0] is not ('E' or 'I')
            || typeCode[1] is not ('S' or 'N')
            || typeCode[2] is not ('T' or 'F')
            || typeCode[3] is not ('J' or 'P'))
        {
            throw new ArgumentException("The profile code must contain one choice from each preference axis.", nameof(typeCode));
        }

        return [typeCode[0], typeCode[1], typeCode[2], typeCode[3]];
    }
}
