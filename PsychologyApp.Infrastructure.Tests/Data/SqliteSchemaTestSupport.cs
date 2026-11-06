using Dapper;
using Microsoft.Data.Sqlite;

namespace PsychologyApp.Infrastructure.Tests.Data;

internal static class SqliteSchemaTestSupport
{
    /// <summary>
    /// Migration tests start from the latest schema and rewind its version rows. Remove version 16's actual schema changes too,
    /// or replaying the migration tries to add BackupKey a second time.
    /// </summary>
    public static async Task RevertBackupKeyMigrationAsync(SqliteConnection connection)
    {
        await connection.ExecuteAsync("DROP INDEX IF EXISTS UX_ChatSessions_BackupKey;");
        await connection.ExecuteAsync("ALTER TABLE ChatSessions DROP COLUMN BackupKey;");
    }
}
