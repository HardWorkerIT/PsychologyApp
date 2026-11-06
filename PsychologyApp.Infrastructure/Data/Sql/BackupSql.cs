namespace PsychologyApp.Infrastructure.Data.Sql;

/// <summary>
/// Every insert is "INSERT … SELECT … WHERE NOT EXISTS (same moment, same content)": it reports 0 affected rows for a row the
/// database already has, which is what makes importing a backup twice harmless.
/// </summary>
internal static class BackupSql
{
    internal const string SelectTechniques = """
        SELECT Number, Date, Header, Description, Subject, Author, Algorithm, Image, IsCompleted
        FROM Techniques
        ORDER BY TechniqueId
        LIMIT @Limit;
        """;

    internal const string SelectExportMetrics = """
        SELECT
            (SELECT COUNT(*) FROM MoodEntries) AS MoodEntryCount,
            (SELECT COUNT(*) FROM TestResults) AS TestResultCount,
            (SELECT COUNT(*) FROM Completions WHERE CompletionKind = 'technique') AS CompletionCount,
            (SELECT COUNT(*) FROM SessionResults) AS SessionResultCount,
            (SELECT COUNT(*) FROM Techniques) AS TechniqueCount,
            (SELECT COUNT(*) FROM EscalationEvents) AS EscalationCount,
            COALESCE((SELECT SUM(COALESCE(length(CAST(Note AS BLOB)), 0)) FROM MoodEntries), 0)
            + COALESCE((SELECT SUM(
                COALESCE(length(CAST(TestId AS BLOB)), 0)
                + COALESCE(length(CAST(Summary AS BLOB)), 0)
                + COALESCE(length(CAST(DetailJson AS BLOB)), 0)
            ) FROM TestResults), 0)
            + COALESCE((SELECT SUM(
                COALESCE(length(CAST(CompletionKind AS BLOB)), 0)
                + COALESCE(length(CAST(ItemKey AS BLOB)), 0)
                + COALESCE(length(CAST(ModuleName AS BLOB)), 0)
                + COALESCE(length(CAST(PageName AS BLOB)), 0)
            ) FROM Completions WHERE CompletionKind = 'technique'), 0)
            + COALESCE((SELECT SUM(
                COALESCE(length(CAST(ItemKey AS BLOB)), 0)
                + COALESCE(length(CAST(PayloadJson AS BLOB)), 0)
                + COALESCE(length(CAST(ProgramType AS BLOB)), 0)
                + COALESCE(length(CAST(Note AS BLOB)), 0)
            ) FROM SessionResults), 0)
            + COALESCE((SELECT SUM(
                COALESCE(length(CAST(Number AS BLOB)), 0)
                + COALESCE(length(CAST(Date AS BLOB)), 0)
                + COALESCE(length(CAST(Header AS BLOB)), 0)
                + COALESCE(length(CAST(Description AS BLOB)), 0)
                + COALESCE(length(CAST(Subject AS BLOB)), 0)
                + COALESCE(length(CAST(Author AS BLOB)), 0)
                + COALESCE(length(CAST(Algorithm AS BLOB)), 0)
                + COALESCE(length(CAST(Image AS BLOB)), 0)
            ) FROM Techniques), 0)
            + COALESCE((SELECT SUM(
                COALESCE(length(CAST(RiskLevel AS BLOB)), 0)
                + COALESCE(length(CAST(TriggerSource AS BLOB)), 0)
                + COALESCE(length(CAST(Action AS BLOB)), 0)
                + COALESCE(length(CAST(Notes AS BLOB)), 0)
            ) FROM EscalationEvents), 0)
            + COALESCE((SELECT
                COALESCE(length(CAST(Source AS BLOB)), 0)
                + COALESCE(length(CAST(Notes AS BLOB)), 0)
                + COALESCE(length(CAST(RiskLevel AS BLOB)), 0)
                FROM RiskAssessments
                ORDER BY RiskAssessmentId DESC
                LIMIT 1), 0)
            + COALESCE((SELECT SUM(length(CAST(Value AS BLOB)))
                FROM AppMetadata
                WHERE Key IN ('FavoriteQuoteTexts', 'BodyLog', 'ReadingState', 'ExposurePlan', 'SafetyPlan')), 0)
            AS Utf8PayloadBytes;
        """;

    internal const string InsertMood = """
        INSERT INTO MoodEntries (MoodLevel, Note, RecordedAt)
        SELECT @MoodLevel, @Note, @RecordedAt
        WHERE NOT EXISTS (
            SELECT 1 FROM MoodEntries
            WHERE RecordedAt = @RecordedAt AND MoodLevel = @MoodLevel AND IFNULL(Note, '') = IFNULL(@Note, ''));
        """;

    internal const string InsertMoodCompletion = """
        INSERT INTO Completions (CompletionKind, ItemKey, ModuleName, PageName, CompletedAt, DurationSeconds)
        SELECT 'mood', 'mood', 'Practice', 'Mood', @RecordedAt, 0
        WHERE NOT EXISTS (SELECT 1 FROM Completions WHERE CompletionKind = 'mood' AND CompletedAt = @RecordedAt);
        """;

    internal const string InsertTestResult = """
        INSERT INTO TestResults (TestId, Score, Summary, DetailJson, CompletedAt)
        SELECT @TestId, @Score, @Summary, @DetailJson, @CompletedAt
        WHERE NOT EXISTS (SELECT 1 FROM TestResults WHERE TestId = @TestId AND CompletedAt = @CompletedAt);
        """;

    internal const string InsertCompletion = """
        INSERT INTO Completions (CompletionKind, ItemKey, ModuleName, PageName, CompletedAt, DurationSeconds)
        SELECT @CompletionKind, @ItemKey, @ModuleName, @PageName, @CompletedAt, @DurationSeconds
        WHERE NOT EXISTS (
            SELECT 1 FROM Completions
            WHERE CompletionKind = @CompletionKind AND ItemKey = @ItemKey AND CompletedAt = @CompletedAt);
        """;

    internal const string InsertSessionResult = """
        INSERT INTO SessionResults (
            ItemKey, CompletedAt, DurationSeconds, PayloadJson, PreIntensity, PostIntensity, ProgramType, ProgramWeek, Note)
        SELECT
            @ItemKey, @CompletedAt, @DurationSeconds, @PayloadJson, @PreIntensity, @PostIntensity, @ProgramType, @ProgramWeek, @Note
        WHERE NOT EXISTS (SELECT 1 FROM SessionResults WHERE ItemKey = @ItemKey AND CompletedAt = @CompletedAt);
        """;

    internal const string InsertChatSession = """
        INSERT INTO ChatSessions (Title, CreatedAt, UpdatedAt, Emotion, Theme, FirstIntensity, LastIntensity, StateJson, BackupKey)
        SELECT @Title, @CreatedAt, @UpdatedAt, @Emotion, @Theme, @FirstIntensity, @LastIntensity, @StateJson, @BackupKey
        WHERE NOT EXISTS (SELECT 1 FROM ChatSessions WHERE BackupKey = @BackupKey);
        """;

    internal const string UpdateChatSessionIfNewer = """
        UPDATE ChatSessions SET UpdatedAt = @UpdatedAt, Emotion = @Emotion, Theme = @Theme,
            FirstIntensity = @FirstIntensity, LastIntensity = @LastIntensity, StateJson = @StateJson
        WHERE SessionId = @SessionId AND UpdatedAt < @UpdatedAt;
        """;

    internal const string CreateChatMessageImportKeys = """
        CREATE TEMP TABLE BackupChatMessageImportKeys (
            KeyId INTEGER NOT NULL PRIMARY KEY,
            SessionId INTEGER NOT NULL,
            Role INTEGER NOT NULL,
            Text TEXT NOT NULL,
            CreatedAt TEXT NOT NULL
        );
        CREATE INDEX temp.IX_BackupChatMessageImportKeys_Lookup
            ON BackupChatMessageImportKeys (SessionId, Role, CreatedAt);
        """;

    internal const string InsertChatMessageImportKey = """
        INSERT INTO temp.BackupChatMessageImportKeys (KeyId, SessionId, Role, Text, CreatedAt)
        VALUES (@KeyId, @SessionId, @Role, @Text, @CreatedAt);
        """;

    internal const string SelectChatMessageCounts = """
        SELECT keys.KeyId, COUNT(messages.MessageId) AS MessageCount
        FROM ChatMessages AS messages INDEXED BY IX_ChatMessages_Session_Role_MessageId
        CROSS JOIN temp.BackupChatMessageImportKeys AS keys
        WHERE messages.SessionId IN @SessionIds
            AND keys.SessionId = messages.SessionId
            AND keys.Role = messages.Role
            AND keys.Text = messages.Text
            AND keys.CreatedAt = messages.CreatedAt
        GROUP BY keys.KeyId;
        """;

    internal const string ClearChatMessageImportKeys = "DELETE FROM temp.BackupChatMessageImportKeys;";
    internal const string DropChatMessageImportKeys = "DROP TABLE temp.BackupChatMessageImportKeys;";

    internal const string InsertChatMessage = """
        INSERT INTO ChatMessages (SessionId, Role, Text, CreatedAt, QuickRepliesJson)
        VALUES (@SessionId, @Role, @Text, @CreatedAt, @QuickRepliesJson);
        """;

    internal const string InsertChatMemoryIfMissing = """
        INSERT INTO ChatMemory (MemoryKey, MemoryValue) VALUES (@Key, @Value)
        ON CONFLICT(MemoryKey) DO NOTHING;
        """;

    internal const string InsertTechnique = """
        INSERT INTO Techniques (Number, Date, Header, Description, Subject, Author, Algorithm, Image, IsCompleted)
        SELECT @Number, @Date, @Header, @Description, @Subject, @Author, @Algorithm, @Image, @IsCompleted
        WHERE NOT EXISTS (
            SELECT 1 FROM Techniques WHERE Number = @Number AND Date = @Date AND Header = @Header AND Algorithm = @Algorithm);
        """;

    internal const string InsertRiskAssessmentIfNewest = """
        INSERT INTO RiskAssessments (
            AssessedAt, Source, Notes, HasSelfHarmThoughts, HasSevereDisorientation, HasSubstanceRisk, HasSevereInsomnia, RiskLevel)
        SELECT
            @AssessedAt, @Source, @Notes, @HasSelfHarmThoughts, @HasSevereDisorientation, @HasSubstanceRisk, @HasSevereInsomnia, @RiskLevel
        WHERE @AssessedAt > IFNULL((SELECT MAX(AssessedAt) FROM RiskAssessments), '');
        """;

    internal const string InsertProgramIfNoneActive = """
        INSERT INTO TherapyPrograms (ProgramKey, StartedAt, CurrentWeek, IsActive)
        SELECT @ProgramKey, @StartedAt, @CurrentWeek, @IsActive
        WHERE NOT EXISTS (SELECT 1 FROM TherapyPrograms WHERE IsActive = 1)
        ON CONFLICT(ProgramKey) DO NOTHING;
        """;

    internal const string InsertEscalation = """
        INSERT INTO EscalationEvents (CreatedAt, RiskLevel, TriggerSource, Action, Notes)
        SELECT @CreatedAt, @RiskLevel, @TriggerSource, @Action, @Notes
        WHERE NOT EXISTS (
            SELECT 1 FROM EscalationEvents WHERE CreatedAt = @CreatedAt AND TriggerSource = @TriggerSource AND Action = @Action);
        """;
}
