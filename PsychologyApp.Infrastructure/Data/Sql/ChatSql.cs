namespace PsychologyApp.Infrastructure.Data.Sql;

internal static class ChatSql
{
    internal const string InsertSession = """
        INSERT INTO ChatSessions (Title, CreatedAt, UpdatedAt, BackupKey)
        VALUES (@Title, @Now, @Now, @BackupKey);
        SELECT last_insert_rowid();
        """;

    // One grouped pass over ChatMessages for the counts (it was three correlated subqueries per session); the preview stays an
    // index seek on (SessionId, MessageId).
    private const string SessionColumns = """
        s.SessionId, s.Title, s.CreatedAt, s.UpdatedAt, s.Emotion, s.Theme, s.FirstIntensity, s.LastIntensity, s.StateJson, s.BackupKey,
        (SELECT m.Text FROM ChatMessages m WHERE m.SessionId = s.SessionId ORDER BY m.MessageId DESC LIMIT 1) AS Preview,
        COALESCE(c.MessageCount, 0) AS MessageCount,
        COALESCE(c.UserMessageCount, 0) AS UserMessageCount
        """;

    internal const string SelectSessions = $"""
        SELECT
            {SessionColumns}
        FROM ChatSessions s
        LEFT JOIN (
            SELECT SessionId, COUNT(*) AS MessageCount, SUM(CASE WHEN Role = 0 THEN 1 ELSE 0 END) AS UserMessageCount
            FROM ChatMessages
            GROUP BY SessionId
        ) c ON c.SessionId = s.SessionId
        ORDER BY s.UpdatedAt DESC, s.SessionId DESC;
        """;

    internal const string SelectExportSessions = $"""
        SELECT
            {SessionColumns}
        FROM ChatSessions s
        LEFT JOIN (
            SELECT SessionId, COUNT(*) AS MessageCount, SUM(CASE WHEN Role = 0 THEN 1 ELSE 0 END) AS UserMessageCount
            FROM ChatMessages
            GROUP BY SessionId
        ) c ON c.SessionId = s.SessionId
        ORDER BY s.UpdatedAt DESC, s.SessionId DESC
        LIMIT @Limit;
        """;

    internal const string SelectSession = $"""
        SELECT
            {SessionColumns}
        FROM ChatSessions s
        LEFT JOIN (
            SELECT SessionId, COUNT(*) AS MessageCount, SUM(CASE WHEN Role = 0 THEN 1 ELSE 0 END) AS UserMessageCount
            FROM ChatMessages
            WHERE SessionId = @SessionId
            GROUP BY SessionId
        ) c ON c.SessionId = s.SessionId
        WHERE s.SessionId = @SessionId;
        """;

    internal const string SelectExportMetrics = """
        SELECT
            (SELECT COUNT(*) FROM ChatSessions) AS SessionCount,
            (SELECT COUNT(*) FROM ChatMessages) AS MessageCount,
            (SELECT COUNT(*) FROM ChatMemory) AS MemoryCount,
            COALESCE((
                SELECT SUM(
                    length(CAST(Text AS BLOB))
                    + COALESCE(length(CAST(QuickRepliesJson AS BLOB)), 0)
                )
                FROM ChatMessages
            ), 0)
            + COALESCE((
                SELECT SUM(
                    COALESCE(length(CAST(s.Title AS BLOB)), 0)
                    + COALESCE(length(CAST(s.Emotion AS BLOB)), 0)
                    + COALESCE(length(CAST(s.Theme AS BLOB)), 0)
                    + COALESCE(length(CAST(s.StateJson AS BLOB)), 0)
                    + COALESCE(length(CAST(s.BackupKey AS BLOB)), 0)
                )
                FROM ChatSessions s
            ), 0)
            + COALESCE((
                SELECT SUM(
                    COALESCE(length(CAST(MemoryKey AS BLOB)), 0)
                    + COALESCE(length(CAST(MemoryValue AS BLOB)), 0)
                )
                FROM ChatMemory
            ), 0) AS Utf8PayloadBytes;
        """;


    internal const string UpdateSession = """
        UPDATE ChatSessions
        SET Title = @Title, UpdatedAt = @UpdatedAt, Emotion = @Emotion, Theme = @Theme,
            FirstIntensity = @FirstIntensity, LastIntensity = @LastIntensity, StateJson = @StateJson
        WHERE SessionId = @SessionId;
        """;

    internal const string DeleteMessages = "DELETE FROM ChatMessages WHERE SessionId = @SessionId;";

    internal const string DeleteSession = "DELETE FROM ChatSessions WHERE SessionId = @SessionId;";

    internal const string InsertMessage = """
        INSERT INTO ChatMessages (SessionId, Role, Text, CreatedAt, QuickRepliesJson)
        VALUES (@SessionId, @Role, @Text, @CreatedAt, @QuickRepliesJson);
        SELECT last_insert_rowid();
        """;

    internal const string SelectMessages = """
        SELECT MessageId, SessionId, Role, Text, CreatedAt, QuickRepliesJson
        FROM ChatMessages
        WHERE SessionId = @SessionId
        ORDER BY MessageId ASC;
        """;

    internal const string SelectMessagesForExport = """
        SELECT m.MessageId, m.SessionId, m.Role, m.Text, m.CreatedAt, m.QuickRepliesJson
        FROM ChatMessages m
        INNER JOIN ChatSessions s ON s.SessionId = m.SessionId
        ORDER BY s.UpdatedAt DESC, s.SessionId DESC, m.MessageId ASC
        LIMIT @Limit;
        """;

    internal const string SelectLatestMessages = """
        SELECT MessageId, SessionId, Role, Text, CreatedAt, QuickRepliesJson
        FROM ChatMessages
        WHERE SessionId = @SessionId
        ORDER BY MessageId DESC
        LIMIT @Limit;
        """;

    internal const string SelectMessagesBefore = """
        SELECT MessageId, SessionId, Role, Text, CreatedAt, QuickRepliesJson
        FROM ChatMessages
        WHERE SessionId = @SessionId AND MessageId < @BeforeMessageId
        ORDER BY MessageId DESC
        LIMIT @Limit;
        """;

    internal const string SelectMemory = "SELECT MemoryKey AS Key, MemoryValue AS Value FROM ChatMemory;";

    internal const string UpsertMemory = """
        INSERT INTO ChatMemory (MemoryKey, MemoryValue) VALUES (@Key, @Value)
        ON CONFLICT(MemoryKey) DO UPDATE SET MemoryValue = excluded.MemoryValue;
        """;

    internal const string IncrementMemory = """
        INSERT INTO ChatMemory (MemoryKey, MemoryValue) VALUES (@Key, '1')
        ON CONFLICT(MemoryKey) DO UPDATE SET MemoryValue = CAST(CAST(MemoryValue AS INTEGER) + 1 AS TEXT);
        """;

    internal const string DeleteMemoryKey = "DELETE FROM ChatMemory WHERE MemoryKey = @Key;";

    internal const string ClearMemory = "DELETE FROM ChatMemory;";

    internal const string DeleteAllMessages = "DELETE FROM ChatMessages;";

    internal const string DeleteAllSessions = "DELETE FROM ChatSessions;";

    internal const string DeleteMemoryExceptKeys = "DELETE FROM ChatMemory WHERE MemoryKey NOT IN @RetainedMemoryKeys;";
}
