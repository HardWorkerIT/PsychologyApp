namespace PsychologyApp.Presentation.Shared.Services.Security;

public readonly record struct AppPinVerificationResult(bool IsValid, TimeSpan RetryAfter)
{
    public bool IsLockedOut => RetryAfter > TimeSpan.Zero;
}

public interface IAppPinCredentialStore
{
    Task<bool> HasPinAsync();

    Task SetPinAsync(string pin);

    Task ClearPinAsync();

    Task<AppPinVerificationResult> VerifyPinAsync(string pin);
}

public static class AppPinPolicy
{
    public const int Length = 6;

    public static bool IsValid(string? pin) =>
        pin is { Length: Length } && pin.All(char.IsAsciiDigit);
}
