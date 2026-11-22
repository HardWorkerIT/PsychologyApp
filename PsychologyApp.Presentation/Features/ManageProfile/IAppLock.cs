using PsychologyApp.Presentation.Shared.Services.Security;

namespace PsychologyApp.Presentation.Features.ManageProfile;

/// <summary>The switch for asking for an app PIN before showing personal content, as the data screen offers it.</summary>
public interface IAppLock
{
    bool IsEnabled { get; }

    DeviceUnlockAvailability Availability { get; }

    /// <summary>Turns the lock on after the person confirms the phone's system credential once; false when it could not be confirmed.</summary>
    Task<bool> TryEnableAsync();

    void Disable();
}
