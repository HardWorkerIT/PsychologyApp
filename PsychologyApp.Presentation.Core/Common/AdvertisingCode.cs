namespace PsychologyApp.Presentation.Common;

/// <summary>Validates the locally entered code before recording the ad-free preference.</summary>
public static class AdvertisingCode
{
    public static bool IsValid(string? code) =>
        string.Equals(code?.Trim(), "EISBRECHER", StringComparison.OrdinalIgnoreCase);
}
