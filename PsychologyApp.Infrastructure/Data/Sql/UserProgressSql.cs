namespace PsychologyApp.Infrastructure.Data.Sql;

internal static class UserProgressSql
{
    internal const string InsertTestResult = """
        INSERT INTO TestResults (TestId, Score, Summary, DetailJson, CompletedAt)
        VALUES (@TestId, @Score, @Summary, @DetailJson, @CompletedAt);
        """;

    internal const string SelectLatestTestResult = """
        SELECT TestResultId, TestId, Score, Summary, DetailJson, CompletedAt
        FROM TestResults
        WHERE TestId = @testId AND CompletedAt < @beforeUtc
        ORDER BY CompletedAt DESC, TestResultId DESC
        LIMIT 1;
        """;

    internal const string SelectMostRecentTestResultSince = """
        SELECT TestResultId, TestId, Score, Summary, DetailJson, CompletedAt
        FROM TestResults
        WHERE CompletedAt >= @sinceUtc AND CompletedAt < @beforeUtc
        ORDER BY CompletedAt DESC, TestResultId DESC
        LIMIT 1;
        """;

    internal const string SelectTestResultHistory = """
        SELECT TestResultId, TestId, Score, Summary, DetailJson, CompletedAt
        FROM TestResults
        WHERE TestId = @testId AND CompletedAt < @beforeUtc
        ORDER BY CompletedAt DESC, TestResultId DESC
        LIMIT @limit;
        """;

    internal const string SelectTestResultsInRange = """
        SELECT TestResultId, TestId, Score, Summary, DetailJson, CompletedAt
        FROM TestResults
        WHERE CompletedAt >= @sinceUtc AND CompletedAt < @beforeUtc
        ORDER BY CompletedAt DESC, TestResultId DESC
        LIMIT @limit;
        """;

    internal const string SelectAllTestResults = """
        SELECT TestResultId, TestId, Score, Summary, DetailJson, CompletedAt
        FROM TestResults
        ORDER BY CompletedAt DESC, TestResultId DESC
        LIMIT @limit;
        """;

    internal const string SelectLatestTestResults = """
        SELECT tr.TestResultId, tr.TestId, tr.Score, tr.Summary, tr.DetailJson, tr.CompletedAt
        FROM TestResults tr
        WHERE tr.TestId IN @testIds
          AND tr.CompletedAt < @beforeUtc
          AND NOT EXISTS (
              SELECT 1
              FROM TestResults newer
              WHERE newer.TestId = tr.TestId
                AND newer.CompletedAt < @beforeUtc
                AND (newer.CompletedAt > tr.CompletedAt
                    OR (newer.CompletedAt = tr.CompletedAt AND newer.TestResultId > tr.TestResultId))
          );
        """;

    internal const string SelectTestResultCounts = """
        SELECT TestId, COUNT(*) AS Count
        FROM TestResults
        WHERE TestId IN @testIds AND CompletedAt < @beforeUtc
        GROUP BY TestId;
        """;

    internal const string SelectLastTechniqueCompletionDate = """
        SELECT CompletedAt
        FROM Completions
        WHERE CompletionKind = 'technique' AND CompletedAt < @beforeUtc
        ORDER BY CompletedAt DESC, CompletionId DESC
        LIMIT 1;
        """;

    internal const string CountTestResults = "SELECT COUNT(*) FROM TestResults WHERE CompletedAt < @beforeUtc;";

    internal const string InsertCompletion = """
        INSERT INTO Completions (CompletionKind, ItemKey, ModuleName, PageName, CompletedAt, DurationSeconds)
        VALUES (@CompletionKind, @ItemKey, @ModuleName, @PageName, @CompletedAt, @DurationSeconds);
        """;

    internal const string CountTechniqueCompletions =
        "SELECT COUNT(*) FROM Completions WHERE CompletionKind = 'technique' AND CompletedAt < @beforeUtc;";

    internal const string CountTechniqueCompletionsBetween = """
        SELECT COUNT(*)
        FROM Completions
        WHERE CompletionKind = 'technique'
          AND CompletedAt >= @sinceUtc
          AND CompletedAt < @beforeUtc;
        """;

    internal const string SelectRecentTechniqueCompletions = """
        SELECT CompletionId, CompletionKind, ItemKey, ModuleName, PageName, CompletedAt, DurationSeconds
        FROM Completions
        WHERE CompletionKind = 'technique' AND CompletedAt < @beforeUtc
        ORDER BY CompletedAt DESC, CompletionId DESC
        LIMIT @limit;
        """;

    internal const string SelectCompletionDates = """
        SELECT DISTINCT substr(CompletedAt, 1, 16) AS Day
        FROM Completions
        WHERE CompletedAt < @beforeUtc
        ORDER BY Day DESC;
        """;

    internal const string SelectLastCompletionForItem = """
        SELECT CompletedAt
        FROM Completions
        WHERE CompletionKind = 'technique' AND ItemKey = @itemKey AND CompletedAt < @beforeUtc
        ORDER BY CompletedAt DESC, CompletionId DESC
        LIMIT 1;
        """;

    internal const string SelectLastPracticeDates = """
        SELECT c.ItemKey, c.CompletedAt
        FROM Completions c
        WHERE c.CompletionKind = 'technique'
          AND c.ItemKey IN @itemKeys
          AND c.CompletedAt < @beforeUtc
          AND NOT EXISTS (
              SELECT 1
              FROM Completions newer
              WHERE newer.CompletionKind = 'technique'
                AND newer.ItemKey = c.ItemKey
                AND newer.CompletedAt < @beforeUtc
                AND (newer.CompletedAt > c.CompletedAt
                    OR (newer.CompletedAt = c.CompletedAt AND newer.CompletionId > c.CompletionId))
          );
        """;

    internal const string UpsertSessionDraft = """
        INSERT INTO SessionDrafts (TechniqueKey, PayloadJson, UpdatedAt)
        VALUES (@techniqueKey, @payloadJson, @updatedAt)
        ON CONFLICT(TechniqueKey) DO UPDATE SET
            PayloadJson = excluded.PayloadJson,
            UpdatedAt = excluded.UpdatedAt;
        """;

    internal const string SelectSessionDraft =
        "SELECT PayloadJson FROM SessionDrafts WHERE TechniqueKey = @techniqueKey;";

    internal const string SelectSessionDraftKeys =
        "SELECT TechniqueKey FROM SessionDrafts WHERE TechniqueKey IN @techniqueKeys;";

    internal const string DeleteSessionDraft =
        "DELETE FROM SessionDrafts WHERE TechniqueKey = @techniqueKey;";

    internal const string SavedNextStepMetadataKey = "SavedNextStep";

    internal const string SelectSavedNextStep =
        "SELECT Value FROM AppMetadata WHERE Key = @key;";

    internal const string UpsertSavedNextStep = """
        INSERT INTO AppMetadata (Key, Value)
        VALUES (@key, @value)
        ON CONFLICT(Key) DO UPDATE SET Value = excluded.Value;
        """;

    internal const string DeleteSavedNextStep =
        "DELETE FROM AppMetadata WHERE Key = @key;";

    internal const string InsertMoodEntry = """
        INSERT INTO MoodEntries (MoodLevel, Note, RecordedAt)
        VALUES (@MoodLevel, @Note, @RecordedAt);
        SELECT last_insert_rowid();
        """;

    internal const string InsertMoodCompletion = """
        INSERT INTO Completions (CompletionKind, ItemKey, ModuleName, PageName, CompletedAt, DurationSeconds)
        VALUES ('mood', 'mood', @moduleName, @pageName, @completedAt, 0);
        """;

    internal const string SelectRecentMoods = """
        SELECT MoodEntryId, MoodLevel, Note, RecordedAt
        FROM MoodEntries
        WHERE RecordedAt < @beforeUtc
        ORDER BY RecordedAt DESC, MoodEntryId DESC
        LIMIT @limit;
        """;

    internal const string SelectMoodsInRange = """
        SELECT MoodEntryId, MoodLevel, Note, RecordedAt
        FROM MoodEntries
        WHERE (@fromUtc IS NULL OR RecordedAt >= @fromUtc)
          AND (@toUtc IS NULL OR RecordedAt < @toUtc)
        ORDER BY RecordedAt DESC, MoodEntryId DESC
        LIMIT @limit;
        """;

    internal const string SelectJournalSlot = """
        SELECT MoodEntryId
        FROM (
            SELECT MoodEntryId, RecordedAt, COUNT(*) OVER () AS DayCount
            FROM MoodEntries
            WHERE RecordedAt >= @fromUtc AND RecordedAt < @toUtc
        )
        WHERE DayCount > 1 OR (RecordedAt < @cutoffUtc) = @morning
        ORDER BY CASE WHEN @morning THEN RecordedAt END ASC, RecordedAt DESC,
                 CASE WHEN @morning THEN MoodEntryId END DESC, MoodEntryId ASC
        LIMIT 1;
        """;

    internal const string UpdateMoodEntry = """
        UPDATE MoodEntries
        SET MoodLevel = COALESCE(@MoodLevel, MoodLevel),
            Note = CASE WHEN @preserveNote THEN Note ELSE @Note END
        WHERE MoodEntryId = @MoodEntryId;
        """;

    internal const string DeleteMoodEntry =
        "DELETE FROM MoodEntries WHERE MoodEntryId = @MoodEntryId;";

    internal const string InsertSessionResult = """
        INSERT INTO SessionResults (
            ItemKey,
            CompletedAt,
            DurationSeconds,
            PayloadJson,
            PreIntensity,
            PostIntensity,
            ProgramType,
            ProgramWeek)
        VALUES (
            @ItemKey,
            @CompletedAt,
            @DurationSeconds,
            @PayloadJson,
            @PreIntensity,
            @PostIntensity,
            @ProgramType,
            @ProgramWeek);
        """;

    internal const string SelectLastInsertRowId = "SELECT last_insert_rowid();";

    internal const string UpdateSessionResultPostIntensity = """
        UPDATE SessionResults
        SET PostIntensity = @postIntensity
        WHERE SessionResultId = @sessionResultId;
        """;

    internal const string UpdateSessionResultNote = """
        UPDATE SessionResults
        SET Note = @note
        WHERE SessionResultId = @sessionResultId;
        """;

    internal const string SelectSessionResultById = """
        SELECT
            SessionResultId,
            ItemKey,
            CompletedAt,
            DurationSeconds,
            PayloadJson,
            PreIntensity,
            PostIntensity,
            ProgramType,
            ProgramWeek,
            Note
        FROM SessionResults
        WHERE SessionResultId = @sessionResultId
        LIMIT 1;
        """;

    internal const string SelectRecentSessionResults = """
        SELECT
            SessionResultId,
            ItemKey,
            CompletedAt,
            DurationSeconds,
            PayloadJson,
            PreIntensity,
            PostIntensity,
            ProgramType,
            ProgramWeek,
            Note
        FROM SessionResults
        WHERE CompletedAt < @beforeUtc
        ORDER BY CompletedAt DESC, SessionResultId DESC
        LIMIT @limit;
        """;

    internal const string SelectRecentPracticeIntensity = """
        SELECT ItemKey, PreIntensity, PostIntensity
        FROM SessionResults
        WHERE CompletedAt < @beforeUtc
        ORDER BY CompletedAt DESC, SessionResultId DESC
        LIMIT @limit;
        """;

    internal const string SelectLastSessionNoteForItem = """
        SELECT Note
        FROM SessionResults
        WHERE ItemKey = @itemKey AND Note IS NOT NULL AND Note != '' AND CompletedAt < @beforeUtc
        ORDER BY CompletedAt DESC, SessionResultId DESC
        LIMIT 1;
        """;

    internal const string CountDistinctTechniqueCompletionsForItemsBetween = """
        SELECT COUNT(DISTINCT ItemKey)
        FROM Completions
        WHERE CompletionKind = 'technique'
          AND ItemKey IN @itemKeys
          AND CompletedAt >= @sinceUtc
          AND CompletedAt < @beforeUtc;
        """;
}
