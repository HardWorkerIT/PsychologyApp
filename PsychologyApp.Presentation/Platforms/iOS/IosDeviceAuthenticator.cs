#if IOS
using LocalAuthentication;
using Microsoft.Extensions.Logging;
using PsychologyApp.Presentation.Shared.Services.Security;

namespace PsychologyApp.Presentation.Platforms.iOS;

/// <summary>Uses the system's biometric prompt with the iPhone or iPad passcode as its fallback.</summary>
public sealed class IosDeviceAuthenticator(ILogger<IosDeviceAuthenticator> logger) : IDeviceAuthenticator
{
    public DeviceUnlockAvailability Availability
    {
        get
        {
            using LAContext context = new();
            return context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthentication, out _)
                ? DeviceUnlockAvailability.Available
                : DeviceUnlockAvailability.NoScreenLock;
        }
    }

    public async Task<DeviceUnlockResult> AuthenticateAsync(string title, string subtitle)
    {
        using LAContext context = new();
        if (!context.CanEvaluatePolicy(LAPolicy.DeviceOwnerAuthentication, out _))
        {
            return DeviceUnlockResult.CannotAsk;
        }

        try
        {
            (bool passed, _) = await context.EvaluatePolicyAsync(LAPolicy.DeviceOwnerAuthentication, subtitle);
            return passed ? DeviceUnlockResult.Passed : DeviceUnlockResult.NotPassed;
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "The system unlock prompt could not be shown");
            return DeviceUnlockResult.CannotAsk;
        }
    }
}
#endif
