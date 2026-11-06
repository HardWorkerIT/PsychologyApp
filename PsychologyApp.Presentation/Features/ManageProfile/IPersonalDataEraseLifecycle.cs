namespace PsychologyApp.Presentation.Features.ManageProfile;

/// <summary>Clears screens that may still hold personal data when the app cannot restart its process.</summary>
public interface IPersonalDataEraseLifecycle
{
    Task PrepareForEraseAsync();
    Task CompleteEraseAsync();
}
