namespace PsychologyApp.Presentation.Common;

/// <summary>Validates the locally entered code before recording the ad-free preference.</summary>
/// <remarks>
/// A value checked by the client is inspectable in the app package and cannot provide a secret entitlement.
/// Use signed invitations or server-side redemption before relying on exclusivity.
/// </remarks>
public static class AdvertisingCode
{
    public static bool IsValid(string? code) =>
        string.Equals(code?.Trim(), "EISBRECHER", StringComparison.OrdinalIgnoreCase);
}
