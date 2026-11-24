using Dapper;
using Microsoft.Data.Sqlite;
using PsychologyApp.Application.Abstractions.Persistence;

namespace PsychologyApp.Infrastructure.Data.Context;

public sealed class SqliteDatabaseInitializer(IDbConnectionFactory connectionFactory) : IDatabaseInitializer
{
    // The factory already applies the connection PRAGMAs, so neither path repeats them.
    public Task InitializeAsync(CancellationToken cancellationToken = default) =>
        SqliteOperationLane.RunAsync(connectionFactory, () => EnsureSchemaAsync(cancellationToken), cancellationToken);

    // One lane slot for the whole sequence: no other operation may run against the database while its files are deleted.
    public Task RecreateDatabaseAsync(Func<Task>? whileExclusive = null, CancellationToken cancellationToken = default) =>
        SqliteOperationLane.RunAsync(connectionFactory, async () =>
        {
            string path;
            await using (System.Data.Common.DbConnection checkpointConnection =
                         await connectionFactory.CreateOpenConnectionAsync(cancellationToken).ConfigureAwait(false))
            {
                if (checkpointConnection is not SqliteConnection sqlite
                    || !Path.IsPathFullyQualified(sqlite.DataSource)
                    || new SqliteConnectionStringBuilder(sqlite.ConnectionString).Mode != SqliteOpenMode.ReadWriteCreate)
                {
                    throw new NotSupportedException("Database recreation requires a SQLite file connection that can create the database.");
                }

                // SQLite resolves the open file's path, including directory aliases used by Android.
                path = sqlite.DataSource;

                // SQLite returns a nonzero first column when another connection prevents truncation.
                long busy = await sqlite.ExecuteScalarAsync<long>(new CommandDefinition(
                    "PRAGMA wal_checkpoint(TRUNCATE);", cancellationToken: cancellationToken)).ConfigureAwait(false);
                if (busy != 0)
                {
                    throw new IOException("The database is busy and could not be reset.");
                }

                SqliteConnection.ClearPool(sqlite);
            }

            cancellationToken.ThrowIfCancellationRequested();
            SqliteSchema.DeleteDatabaseFiles(path);

            // Finish the reset once the original database has been removed, even if the caller cancels.
            await EnsureSchemaAsync(CancellationToken.None).ConfigureAwait(false);

            if (whileExclusive is not null)
            {
                await whileExclusive().ConfigureAwait(false);
            }
        }, cancellationToken);

    public Task ApplyMigrationsForAppVersionAsync(string appVersion, CancellationToken cancellationToken = default)
    {
        // Schema migrations are version-based (SchemaVersion table), not tied to app display version.
        return InitializeAsync(cancellationToken);
    }

    private async Task EnsureSchemaAsync(CancellationToken cancellationToken)
    {
        await using System.Data.Common.DbConnection connection =
            await connectionFactory.CreateOpenConnectionAsync(cancellationToken).ConfigureAwait(false);

        await SqliteSchema.EnsureSchemaAsync(connection, cancellationToken).ConfigureAwait(false);
    }
}
