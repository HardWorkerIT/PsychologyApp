namespace PsychologyApp.Presentation.Features.ManageProfile;

/// <summary>"Delete all my data": everything the person has entered goes, as after a fresh install.</summary>
public interface IPersonalDataEraser
{
    /// <summary>Deletes saved personal data, clears screens that may retain it, and returns the app to its first-run flow.</summary>
    Task EraseAllAsync(CancellationToken cancellationToken = default);
}
