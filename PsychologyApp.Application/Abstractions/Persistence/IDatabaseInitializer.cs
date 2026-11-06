namespace PsychologyApp.Application.Abstractions.Persistence;

public interface IDatabaseInitializer
{
    Task InitializeAsync(CancellationToken cancellationToken = default);
    /// <summary>
    /// Replaces the database with an empty one. <paramref name="whileExclusive"/> runs after the new schema is ready but before the
    /// exclusive database lane is released, so callers can clear related files and preferences before queued operations resume.
    /// </summary>
    Task RecreateDatabaseAsync(Func<Task>? whileExclusive = null, CancellationToken cancellationToken = default);
    Task ApplyMigrationsForAppVersionAsync(string appVersion, CancellationToken cancellationToken = default);
}
