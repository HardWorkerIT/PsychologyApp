using Dapper;
using Xunit;
using Microsoft.Data.Sqlite;
using PsychologyApp.Infrastructure.Data.Context;

namespace PsychologyApp.Infrastructure.Tests.Data;

public class SqliteSchemaTests
{
    private sealed class QueryPlanRow
    {
        public string Detail { get; init; } = string.Empty;
    }

    private static async Task<SqliteConnection> CreateSchemaConnectionAsync()
    {
        SqliteConnection connection = new("Data Source=:memory:");
        await connection.OpenAsync();
        await SqliteSchema.EnsureSchemaAsync(connection);
        return connection;
    }

    private static async Task AssertQueryUsesIndexAsync(SqliteConnection connection, string query, string indexName)
    {
        IEnumerable<QueryPlanRow> plan = await connection.QueryAsync<QueryPlanRow>("EXPLAIN QUERY PLAN " + query);
        Assert.Contains(plan, row => row.Detail.Contains(indexName, StringComparison.Ordinal));
    }
    [Fact]
    public async Task EnsureSchema_CreatesAllTables()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        await SqliteSchema.EnsureSchemaAsync(connection);

        int techniques = await connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='Techniques';");
        int schemaVersion = await connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name='SchemaVersion';");

        Assert.Equal(1, techniques);
        Assert.Equal(1, schemaVersion);
    }

    [Fact]
    public async Task EnsureSchema_AppliesVersion2Index()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        await SqliteSchema.EnsureSchemaAsync(connection);

        int version = await connection.ExecuteScalarAsync<int>("SELECT MAX(Version) FROM SchemaVersion;");
        int indexCount = await connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM sqlite_master WHERE type='index' AND name='IX_Statistics_PageName';");

        Assert.Equal(SqliteSchema.CurrentVersion, version);
        Assert.Equal(1, indexCount);
    }

    [Fact]
    public async Task ChatHistoryQuery_usesTheSessionIndex()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();
        await SqliteSchema.EnsureSchemaAsync(connection);

        IEnumerable<QueryPlanRow> plan = await connection.QueryAsync<QueryPlanRow>("""
            EXPLAIN QUERY PLAN
            SELECT MessageId, SessionId, Role, Text, CreatedAt, QuickRepliesJson
            FROM ChatMessages
            WHERE SessionId = @SessionId
            ORDER BY MessageId ASC;
            """, new { SessionId = 1 });

        Assert.Contains(plan, row => row.Detail.Contains("IX_ChatMessages_Session", StringComparison.Ordinal));
    }

    [Fact]
    public async Task MoodHistoryQuery_usesRecordedAtIndex()
    {
        await using SqliteConnection connection = await CreateSchemaConnectionAsync();
        await AssertQueryUsesIndexAsync(connection, """
            SELECT MoodEntryId, MoodLevel, Note, RecordedAt
            FROM MoodEntries
            WHERE RecordedAt >= '2025-01-01' AND RecordedAt < '2026-01-01'
            ORDER BY RecordedAt DESC
            LIMIT 50;
            """, "IX_MoodEntries_RecordedAt");
    }

    [Fact]
    public async Task TestHistoryQuery_usesTestIdIndex()
    {
        await using SqliteConnection connection = await CreateSchemaConnectionAsync();
        await AssertQueryUsesIndexAsync(connection, """
            SELECT TestResultId, TestId, Score, Summary, DetailJson, CompletedAt
            FROM TestResults
            WHERE TestId = 'GAD-7'
            ORDER BY TestResultId DESC
            LIMIT 20;
            """, "IX_TestResults_TestId");
    }

    [Fact]
    public async Task LastPracticeNoteQuery_usesItemKeyIndex()
    {
        await using SqliteConnection connection = await CreateSchemaConnectionAsync();
        await AssertQueryUsesIndexAsync(connection, """
            SELECT Note
            FROM SessionResults
            WHERE ItemKey = 'grounding' AND Note IS NOT NULL AND Note != ''
            ORDER BY SessionResultId DESC
            LIMIT 1;
            """, "IX_SessionResults_ItemKey");
    }

    [Fact]
    public async Task QuoteLookupQuery_usesUniqueTextIndex()
    {
        await using SqliteConnection connection = await CreateSchemaConnectionAsync();
        await AssertQueryUsesIndexAsync(connection, """
            SELECT *
            FROM Quots
            WHERE Text = 'sample quote'
            ORDER BY QuotId DESC
            LIMIT 1;
            """, "UX_Quots_Text");
    }

    [Fact]
    public async Task ChatListQuery_usesUpdatedAtOrderingIndex()
    {
        await using SqliteConnection connection = await CreateSchemaConnectionAsync();
        await AssertQueryUsesIndexAsync(connection, """
            SELECT SessionId
            FROM ChatSessions
            ORDER BY UpdatedAt DESC, SessionId DESC
            LIMIT 50;
            """, "IX_ChatSessions_UpdatedAt");
    }
    [Fact]
    public async Task MigrationTo15_dropsRedundantChatOrderingIndexAndPreservesSessions()
    {
        await using SqliteConnection connection = await CreateSchemaConnectionAsync();
        await connection.ExecuteAsync("INSERT INTO ChatSessions (Title, CreatedAt, UpdatedAt) VALUES ('saved', '2025-01-01', '2025-01-02');");
        await connection.ExecuteAsync("CREATE INDEX IX_ChatSessions_UpdatedAt_SessionId ON ChatSessions(UpdatedAt DESC, SessionId DESC);");
        await SqliteSchemaTestSupport.RevertBackupKeyMigrationAsync(connection);
        await connection.ExecuteAsync("DELETE FROM SchemaVersion WHERE Version > 14;");

        await SqliteSchema.EnsureSchemaAsync(connection);

        Assert.Equal(1, await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM ChatSessions WHERE Title = 'saved';"));
        Assert.Equal(0, await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM sqlite_master WHERE type='index' AND name='IX_ChatSessions_UpdatedAt_SessionId';"));
        Assert.Equal(1, await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM sqlite_master WHERE type='index' AND name='IX_ChatSessions_UpdatedAt';"));

        IEnumerable<QueryPlanRow> plan = await connection.QueryAsync<QueryPlanRow>("""
            EXPLAIN QUERY PLAN
            SELECT SessionId
            FROM ChatSessions
            ORDER BY UpdatedAt DESC, SessionId DESC
            LIMIT 50;
            """);
        Assert.Contains(plan, row => row.Detail.Contains("IX_ChatSessions_UpdatedAt", StringComparison.Ordinal));
        Assert.DoesNotContain(plan, row => row.Detail.Contains("TEMP B-TREE", StringComparison.OrdinalIgnoreCase));
    }
    [Fact]
    public async Task EnsureSchema_CreatesAppMetadataTableForVersion6()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        await SqliteSchema.EnsureSchemaAsync(connection);

        Assert.Equal(1, await TableExistsAsync(connection, "AppMetadata"));
        int version = await connection.ExecuteScalarAsync<int>("SELECT MAX(Version) FROM SchemaVersion;");
        Assert.Equal(SqliteSchema.CurrentVersion, version);
    }

    [Fact]
    public async Task EnsureSchema_CreatesClinicalCareTablesForVersion7()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        await SqliteSchema.EnsureSchemaAsync(connection);

        Assert.Equal(1, await TableExistsAsync(connection, "RiskAssessments"));
        Assert.Equal(1, await TableExistsAsync(connection, "TherapyPrograms"));
        Assert.Equal(1, await TableExistsAsync(connection, "EscalationEvents"));
        int version = await connection.ExecuteScalarAsync<int>("SELECT MAX(Version) FROM SchemaVersion;");
        Assert.Equal(SqliteSchema.CurrentVersion, version);
    }

    [Fact]
    public async Task EnsureSchema_CreatesSessionResultsTableForVersion8()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        await SqliteSchema.EnsureSchemaAsync(connection);

        Assert.Equal(1, await TableExistsAsync(connection, "SessionResults"));
        int version = await connection.ExecuteScalarAsync<int>("SELECT MAX(Version) FROM SchemaVersion;");
        Assert.Equal(SqliteSchema.CurrentVersion, version);
    }


    [Fact]
    public async Task EnsureSchema_CreatesChatTablesForVersions9And10()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        await SqliteSchema.EnsureSchemaAsync(connection);

        Assert.Equal(1, await TableExistsAsync(connection, "ChatSessions"));
        Assert.Equal(1, await TableExistsAsync(connection, "ChatMessages"));
        Assert.Equal(1, await TableExistsAsync(connection, "ChatMemory"));
    }

    [Fact]
    public async Task EnsureSchema_AddsSessionResultsNoteColumnForVersion11()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        await SqliteSchema.EnsureSchemaAsync(connection);

        int columnExists = await connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM pragma_table_info('SessionResults') WHERE name = 'Note';");
        Assert.Equal(1, columnExists);
        int version = await connection.ExecuteScalarAsync<int>("SELECT MAX(Version) FROM SchemaVersion;");
        Assert.Equal(SqliteSchema.CurrentVersion, version);
    }

    [Fact]
    public async Task EnsureSchema_CreatesProgressTablesForVersion4()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        await SqliteSchema.EnsureSchemaAsync(connection);

        Assert.Equal(1, await TableExistsAsync(connection, "TestResults"));
        Assert.Equal(1, await TableExistsAsync(connection, "Completions"));
        Assert.Equal(1, await TableExistsAsync(connection, "SessionDrafts"));
        Assert.Equal(1, await TableExistsAsync(connection, "MoodEntries"));
    }

    [Fact]
    public async Task EnsureSchema_UsesDescriptionColumnAtVersion5()
    {
        await using var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        await SqliteSchema.EnsureSchemaAsync(connection);

        int descriptionColumn = await connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM pragma_table_info('Techniques') WHERE name = 'Description';");
        int legacyColumn = await connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM pragma_table_info('Techniques') WHERE name = 'Describtion';");

        Assert.Equal(1, descriptionColumn);
        Assert.Equal(0, legacyColumn);
    }

    private static Task<int> TableExistsAsync(SqliteConnection connection, string tableName) =>
        connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM sqlite_master WHERE type='table' AND name=@tableName;",
            new { tableName });
}
