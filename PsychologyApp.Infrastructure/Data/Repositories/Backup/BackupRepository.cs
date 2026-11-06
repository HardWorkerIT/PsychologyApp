using System.Reflection;
using System.Text;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using PsychologyApp.Application.Abstractions.Persistence;
using PsychologyApp.Application.Chat;
using PsychologyApp.Application.Configuration;
using PsychologyApp.Application.DataBackup;
using PsychologyApp.Application.Models;
using PsychologyApp.Infrastructure.Data.Repositories.Base;
using PsychologyApp.Infrastructure.Data.Repositories.Quots;
using PsychologyApp.Infrastructure.Data.Sql;
using PsychologyApp.Application.Body;
using PsychologyApp.Infrastructure.Data.Repositories.UserProgress;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace PsychologyApp.Infrastructure.Data.Repositories.Backup;

public sealed class BackupRepository(IDbConnectionFactory connectionFactory, IOptions<AppSettings> settings)
    : SqliteRepositoryBase(connectionFactory, settings), IBackupRepository
{
    private const int ImportCommandBatchSize = 100;
    private const int ChatMessageCountBatchSize = 50;
    private const string FavouriteTextsKey = "FavoriteQuoteTexts";

    public async Task<BackupExportMetrics> GetExportMetricsAsync(CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenReadConnectionAsync(cancellationToken);
        return await connection.QuerySingleAsync<BackupExportMetrics>(DapperCommandFactory.Create(
            BackupSql.SelectExportMetrics,
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task<IReadOnlyList<BackupTechniqueDTO>> GetTechniquesAsync(int limit, CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenReadConnectionAsync(cancellationToken);
        IEnumerable<BackupTechniqueDTO> rows = await connection.QueryAsync<BackupTechniqueDTO>(DapperCommandFactory.Create(
            BackupSql.SelectTechniques,
            new { Limit = Math.Max(1, limit) },
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);
        return rows.ToList();
    }

    public async Task<BackupImportResult> ImportAsync(AppBackupDTO backup, CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenConnectionAsync(cancellationToken);
        await using SqliteTransaction transaction =
            (SqliteTransaction)await connection.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);

        // Any failure leaves the transaction uncommitted, so disposing it rolls everything back: no half-restored database.
        Dictionary<Type, PropertyInfo[]> parameterProperties = new();

        async Task<int> RunBatchAsync(string sql, IReadOnlyList<object> batch)
        {
            StringBuilder batchSql = new(sql.Length * batch.Count);
            DynamicParameters batchParameters = new();
            for (int rowIndex = 0; rowIndex < batch.Count; rowIndex++)
            {
                object row = batch[rowIndex];
                Type rowType = row.GetType();
                if (!parameterProperties.TryGetValue(rowType, out PropertyInfo[]? properties) || properties is null)
                {
                    properties = rowType.GetProperties(BindingFlags.Instance | BindingFlags.Public);
                    parameterProperties.Add(rowType, properties);
                }

                string rowSql = sql;
                foreach (PropertyInfo property in properties)
                {
                    string parameterName = property.Name + "_" + rowIndex;
                    rowSql = rowSql.Replace("@" + property.Name, "@" + parameterName, StringComparison.Ordinal);
                    batchParameters.Add(parameterName, property.GetValue(row));
                }

                batchSql.AppendLine(rowSql);
            }

            return await connection.ExecuteAsync(DapperCommandFactory.Create(
                batchSql.ToString(), batchParameters, transaction, CommandTimeoutSeconds, cancellationToken)).ConfigureAwait(false);
        }

        async Task<int> RunManyAsync(string sql, System.Collections.IEnumerable rows)
        {
            List<object> batch = new(ImportCommandBatchSize);
            int affected = 0;
            foreach (object? row in rows)
            {
                cancellationToken.ThrowIfCancellationRequested();
                batch.Add(row ?? throw new InvalidOperationException("A backup import row is missing."));
                if (batch.Count == ImportCommandBatchSize)
                {
                    affected += await RunBatchAsync(sql, batch).ConfigureAwait(false);
                    batch.Clear();
                }
            }

            if (batch.Count > 0)
            {
                affected += await RunBatchAsync(sql, batch).ConfigureAwait(false);
            }

            return affected;
        }

        Func<string, object, Task<int>> run = (sql, parameters) => parameters is System.Collections.IEnumerable rows && parameters is not string
            ? RunManyAsync(sql, rows)
            : connection.ExecuteAsync(DapperCommandFactory.Create(sql, parameters, transaction, CommandTimeoutSeconds, cancellationToken));

        int moods = await run(BackupSql.InsertMood, backup.MoodEntries.Select(mood => new
        {
            mood.MoodLevel,
            mood.Note,
            RecordedAt = SqliteTime.ToIso(mood.RecordedAt)
        })).ConfigureAwait(false);
        // The journal streak counts mood check-ins as completions; RecordMoodAsync writes both, so a restore must too.
        await run(BackupSql.InsertMoodCompletion, backup.MoodEntries.Select(mood => new
        {
            RecordedAt = SqliteTime.ToIso(mood.RecordedAt)
        })).ConfigureAwait(false);

        int tests = await run(BackupSql.InsertTestResult, backup.TestResults.Select(result => new
        {
            result.TestId,
            result.Score,
            result.Summary,
            result.DetailJson,
            CompletedAt = SqliteTime.ToIso(result.CompletedAt)
        })).ConfigureAwait(false);

        int completions = await run(BackupSql.InsertCompletion, backup.Completions.Select(completion => new
        {
            completion.CompletionKind,
            completion.ItemKey,
            completion.ModuleName,
            completion.PageName,
            CompletedAt = SqliteTime.ToIso(completion.CompletedAt),
            completion.DurationSeconds
        })).ConfigureAwait(false);

        int sessionResults = await run(BackupSql.InsertSessionResult, backup.SessionResults.Select(result => new
        {
            result.ItemKey,
            CompletedAt = SqliteTime.ToIso(result.CompletedAt),
            result.DurationSeconds,
            result.PayloadJson,
            result.PreIntensity,
            result.PostIntensity,
            result.ProgramType,
            result.ProgramWeek,
            result.Note
        })).ConfigureAwait(false);

        List<(BackupChatSessionDTO Chat, string Key)> chatImports = backup.ChatSessions
            .Select(chat => (chat, GetBackupKey(chat.Session)))
            .ToList();
        int chats = await run(BackupSql.InsertChatSession, chatImports.Select(item => new
        {
            item.Chat.Session.Title,
            CreatedAt = SqliteTime.ToIso(item.Chat.Session.CreatedAt),
            UpdatedAt = SqliteTime.ToIso(item.Chat.Session.UpdatedAt == default ? item.Chat.Session.CreatedAt : item.Chat.Session.UpdatedAt),
            item.Chat.Session.Emotion,
            item.Chat.Session.Theme,
            item.Chat.Session.FirstIntensity,
            item.Chat.Session.LastIntensity,
            item.Chat.Session.StateJson,
            BackupKey = item.Key
        })).ConfigureAwait(false);

        Dictionary<string, long> sessionIds = new(StringComparer.Ordinal);
        foreach (string[] keys in chatImports.Select(item => item.Key).Chunk(500))
        {
            IEnumerable<ChatSessionKeyRow> rows = await connection.QueryAsync<ChatSessionKeyRow>(DapperCommandFactory.Create(
                "SELECT BackupKey, SessionId FROM ChatSessions WHERE BackupKey IN @BackupKeys;",
                new { BackupKeys = keys },
                transaction,
                CommandTimeoutSeconds,
                cancellationToken)).ConfigureAwait(false);
            foreach (ChatSessionKeyRow row in rows)
            {
                sessionIds[row.BackupKey] = row.SessionId;
            }
        }

        await run(BackupSql.UpdateChatSessionIfNewer, chatImports.Select(item => new
        {
            SessionId = sessionIds[item.Key],
            UpdatedAt = SqliteTime.ToIso(item.Chat.Session.UpdatedAt == default ? item.Chat.Session.CreatedAt : item.Chat.Session.UpdatedAt),
            item.Chat.Session.Emotion,
            item.Chat.Session.Theme,
            item.Chat.Session.FirstIntensity,
            item.Chat.Session.LastIntensity,
            item.Chat.Session.StateJson
        })).ConfigureAwait(false);

        await connection.ExecuteAsync(DapperCommandFactory.Create(
            "DROP TABLE IF EXISTS temp.BackupChatMessageImportKeys;",
            transaction: transaction,
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            BackupSql.CreateChatMessageImportKeys,
            transaction: transaction,
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);

        try
        {
            foreach (var chatBatchItems in chatImports.Chunk(ChatMessageCountBatchSize))
            {
                BackupChatSessionDTO[] chatBatch = chatBatchItems.Select(item => item.Chat).ToArray();
                string[] keyBatch = chatBatchItems.Select(item => item.Key).ToArray();
                ChatMessageDTO[][] orderedMessages = chatBatch
                    .Select(chat => chat.Messages.OrderBy(item => item.Id).ToArray())
                    .ToArray();
                long[] batchSessionIds = keyBatch.Select(key => sessionIds[key]).Distinct().ToArray();
                Dictionary<(long SessionId, int Role, string Text, string CreatedAt), int> keyIds = new();

                IEnumerable<ChatMessageKeyImportParameters> GetMessageKeys()
                {
                    for (int index = 0; index < chatBatch.Length; index++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        BackupChatSessionDTO chat = chatBatch[index];
                        long sessionId = sessionIds[keyBatch[index]];
                        foreach (ChatMessageDTO message in orderedMessages[index])
                        {
                            (long SessionId, int Role, string Text, string CreatedAt) messageKey = (
                                sessionId,
                                (int)message.Role,
                                message.Text,
                                SqliteTime.ToIso(message.CreatedAt));
                            if (keyIds.ContainsKey(messageKey))
                            {
                                continue;
                            }

                            int keyId = keyIds.Count + 1;
                            keyIds.Add(messageKey, keyId);
                            yield return new ChatMessageKeyImportParameters(
                                keyId,
                                messageKey.SessionId,
                                messageKey.Role,
                                messageKey.Text,
                                messageKey.CreatedAt);
                        }
                    }
                }

                await run(BackupSql.InsertChatMessageImportKey, GetMessageKeys()).ConfigureAwait(false);
                IEnumerable<ChatMessageCountRow> countRows = await connection.QueryAsync<ChatMessageCountRow>(DapperCommandFactory.Create(
                    BackupSql.SelectChatMessageCounts,
                    new { SessionIds = batchSessionIds },
                    transaction,
                    CommandTimeoutSeconds,
                    cancellationToken)).ConfigureAwait(false);
                Dictionary<int, long> existingMessageCounts = countRows.ToDictionary(row => row.KeyId, row => row.MessageCount);

                IEnumerable<ChatMessageImportParameters> GetMissingMessages()
                {
                    for (int index = 0; index < chatBatch.Length; index++)
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        BackupChatSessionDTO chat = chatBatch[index];
                        long sessionId = sessionIds[keyBatch[index]];
                        Dictionary<int, int> occurrences = new();
                        foreach (ChatMessageDTO message in orderedMessages[index])
                        {
                            (long SessionId, int Role, string Text, string CreatedAt) messageKey = (
                                sessionId,
                                (int)message.Role,
                                message.Text,
                                SqliteTime.ToIso(message.CreatedAt));
                            int keyId = keyIds[messageKey];
                            occurrences.TryGetValue(keyId, out int occurrence);
                            occurrence++;
                            occurrences[keyId] = occurrence;

                            if (existingMessageCounts.TryGetValue(keyId, out long existingCount)
                                && occurrence <= existingCount)
                            {
                                continue;
                            }

                            yield return new ChatMessageImportParameters(
                                sessionId,
                                messageKey.Role,
                                messageKey.Text,
                                messageKey.CreatedAt,
                                ChatQuickReplyJson.Serialize(message.QuickReplies));
                        }
                    }
                }

                await run(BackupSql.InsertChatMessage, GetMissingMessages()).ConfigureAwait(false);
                await connection.ExecuteAsync(DapperCommandFactory.Create(
                    BackupSql.ClearChatMessageImportKeys,
                    transaction: transaction,
                    commandTimeout: CommandTimeoutSeconds,
                    cancellationToken: cancellationToken)).ConfigureAwait(false);
            }
        }
        catch
        {
            try
            {
                await connection.ExecuteAsync(DapperCommandFactory.Create(
                    BackupSql.DropChatMessageImportKeys,
                    transaction: transaction,
                    commandTimeout: CommandTimeoutSeconds,
                    cancellationToken: CancellationToken.None)).ConfigureAwait(false);
            }
            catch
            {
                // The import transaction will roll back, removing its temporary staging table if cleanup also fails.
            }

            throw;
        }

        await connection.ExecuteAsync(DapperCommandFactory.Create(
            BackupSql.DropChatMessageImportKeys,
            transaction: transaction,
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);

        // What the companion already learned on this device wins over the backup: only missing keys are filled.
        await run(BackupSql.InsertChatMemoryIfMissing, backup.ChatMemory.Select(pair => new { Key = pair.Key, Value = pair.Value }))
            .ConfigureAwait(false);

        await MergeFavouriteTextsAsync(connection, transaction, backup.FavoriteQuoteTexts, cancellationToken).ConfigureAwait(false);

        int techniques = await run(BackupSql.InsertTechnique, backup.Techniques.Select(technique => new
        {
            technique.Number,
            technique.Date,
            technique.Header,
            technique.Description,
            technique.Subject,
            technique.Author,
            technique.Algorithm,
            technique.Image,
            technique.IsCompleted
        })).ConfigureAwait(false);

        // "Latest" is decided by row id, so an older assessment must never be inserted after a newer local one.
        if (backup.LatestRiskAssessment is { } risk)
        {
            await run(BackupSql.InsertRiskAssessmentIfNewest, new
            {
                AssessedAt = SqliteTime.ToIso(risk.AssessedAt),
                risk.Source,
                risk.Notes,
                risk.HasSelfHarmThoughts,
                risk.HasSevereDisorientation,
                risk.HasSubstanceRisk,
                risk.HasSevereInsomnia,
                RiskLevel = risk.RiskLevel.ToString().ToLowerInvariant()
            }).ConfigureAwait(false);
        }

        if (backup.TherapyProgram is { } program)
        {
            await run(BackupSql.InsertProgramIfNoneActive, new
            {
                ProgramKey = program.ProgramType.ToString(),
                StartedAt = SqliteTime.ToIso(program.StartedAt),
                program.CurrentWeek,
                IsActive = program.IsActive ? 1 : 0
            }).ConfigureAwait(false);
        }

        await run(BackupSql.InsertEscalation, backup.Escalations.Select(escalation => new
        {
            CreatedAt = SqliteTime.ToIso(escalation.CreatedAt),
            RiskLevel = escalation.RiskLevel.ToString().ToLowerInvariant(),
            escalation.TriggerSource,
            escalation.Action,
            escalation.Notes
        })).ConfigureAwait(false);

        // Documents belong to the same restore transaction as the rows.
        async Task WriteDocument<T>(string key, T value, JsonTypeInfo<T> type) =>
            await run("INSERT INTO AppMetadata (Key, Value) VALUES (@key, @value) ON CONFLICT(Key) DO UPDATE SET Value = excluded.Value;",
                new { key, value = JsonSerializer.Serialize(value, type) }).ConfigureAwait(false);

        async Task<T?> ReadDocument<T>(string key, JsonTypeInfo<T> type) where T : class
        {
            string? json = await connection.ExecuteScalarAsync<string?>(DapperCommandFactory.Create(
                "SELECT Value FROM AppMetadata WHERE Key = @key;", new { key }, transaction,
                CommandTimeoutSeconds, cancellationToken)).ConfigureAwait(false);
            if (string.IsNullOrWhiteSpace(json)) return null;
            try { return JsonSerializer.Deserialize(json, type); }
            catch (JsonException)
            {
                await run("INSERT INTO AppMetadata (Key, Value) VALUES (@key, @value) ON CONFLICT(Key) DO UPDATE SET Value = excluded.Value;",
                    new { key = key + ".unreadable", value = json }).ConfigureAwait(false);
                return null;
            }
        }

        bool safetyPlanImported = false;
        if (backup.SafetyPlan is { IsEmpty: false } plan)
        {
            var local = await ReadDocument("SafetyPlan", BackupJsonContext.Default.SafetyPlanDTO);
            bool localIsNewer = local is { IsEmpty: false }
                && (plan.UpdatedAt is null || (local.UpdatedAt is { } localAt && localAt >= plan.UpdatedAt));
            if (!localIsNewer)
            {
                await WriteDocument("SafetyPlan", plan, BackupJsonContext.Default.SafetyPlanDTO);
                safetyPlanImported = true;
            }
        }
        if (backup.ExposurePlan is { } exposure
            && await ReadDocument(ExposureRepository.MetadataKey, ExposureJsonContext.Default.ExposurePlan) is null)
            await WriteDocument(ExposureRepository.MetadataKey, exposure, ExposureJsonContext.Default.ExposurePlan);
        if (backup.Reading is { IsEmpty: false } reading
            && await ReadDocument(ReadingRepository.MetadataKey, ReadingJsonContext.Default.ReadingState) is not { IsEmpty: false })
            await WriteDocument(ReadingRepository.MetadataKey, reading, ReadingJsonContext.Default.ReadingState);
        if (backup.Body is { Entries.Count: > 0 } body)
        {
            var local = await ReadDocument(BodyRepository.MetadataKey, BodyJsonContext.Default.BodyLog);
            await WriteDocument(BodyRepository.MetadataKey, BodyService.Merge(local, body), BodyJsonContext.Default.BodyLog);
        }

        await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
        return new BackupImportResult(moods, tests, completions, sessionResults, chats, safetyPlanImported, techniques);
    }

    private static string GetBackupKey(BackupChatSessionInfoDTO session)
    {
        if (!string.IsNullOrWhiteSpace(session.BackupKey))
        {
            return session.BackupKey!;
        }

        // Older format-2 backups have no stable key. The source id and creation timestamp match the migration key and keep
        // same-named sessions distinct across repeat restores.
        return "legacy:" + session.Id.ToString(System.Globalization.CultureInfo.InvariantCulture) + ":" + SqliteTime.ToIso(session.CreatedAt);
    }

    private async Task MergeFavouriteTextsAsync(
        SqliteConnection connection,
        SqliteTransaction transaction,
        IReadOnlyList<string> imported,
        CancellationToken cancellationToken)
    {
        if (imported.Count == 0)
        {
            return;
        }

        string? existing = await connection.ExecuteScalarAsync<string?>(DapperCommandFactory.Create(
            "SELECT Value FROM AppMetadata WHERE Key = @key;",
            new { key = FavouriteTextsKey },
            transaction,
            CommandTimeoutSeconds,
            cancellationToken)).ConfigureAwait(false);

        HashSet<string> texts = FavoriteQuoteTextsCodec.Decode(existing);

        int before = texts.Count;
        foreach (string text in imported)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                texts.Add(text.Trim());
            }
        }

        if (texts.Count == before)
        {
            return;
        }

        await connection.ExecuteAsync(DapperCommandFactory.Create(
            """
            INSERT INTO AppMetadata (Key, Value) VALUES (@key, @value)
            ON CONFLICT(Key) DO UPDATE SET Value = excluded.Value;
            """,
            new { key = FavouriteTextsKey, value = FavoriteQuoteTextsCodec.Encode(texts) },
            transaction,
            CommandTimeoutSeconds,
            cancellationToken)).ConfigureAwait(false);
    }

    private sealed class ChatSessionKeyRow
    {
        public string BackupKey { get; set; } = string.Empty;
        public long SessionId { get; set; }
    }

    private sealed class ChatMessageCountRow
    {
        public int KeyId { get; set; }
        public long MessageCount { get; set; }
    }

    private sealed record ChatMessageKeyImportParameters(
        int KeyId,
        long SessionId,
        int Role,
        string Text,
        string CreatedAt);

    private sealed record ChatMessageImportParameters(
        long SessionId,
        int Role,
        string Text,
        string CreatedAt,
        string? QuickRepliesJson);
}
