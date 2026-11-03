namespace PsychologyApp.Application.Abstractions.Startup;

public interface IAppStartupService
{
    Task InitializeAsync(CancellationToken cancellationToken = default);

    /// <summary>Runs optional catalog warmups and maintenance after the app has signalled that its database is ready.</summary>
    Task WarmupAsync();
}
