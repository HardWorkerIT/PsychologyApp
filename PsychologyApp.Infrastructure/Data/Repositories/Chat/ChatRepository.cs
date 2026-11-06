using System.Globalization;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using PsychologyApp.Application.Abstractions.Persistence;
using PsychologyApp.Application.Chat;
using PsychologyApp.Application.Configuration;
using PsychologyApp.Infrastructure.Data.Repositories.Base;
using PsychologyApp.Infrastructure.Data.Sql;

namespace PsychologyApp.Infrastructure.Data.Repositories.Chat;

public sealed class ChatRepository(IDbConnectionFactory connectionFactory, IOptions<AppSettings> settings)
    : SqliteRepositoryBase(connectionFactory, settings), IChatRepository
{
    public async Task<long> CreateSessionAsync(string title, DateTime nowUtc, CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenConnectionAsync(cancellationToken);
        return await connection.ExecuteScalarAsync<long>(DapperCommandFactory.Create(
            ChatSql.InsertSession,
            new { Title = title, Now = ToIso(nowUtc), BackupKey = Guid.NewGuid().ToString("N") },
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task<IReadOnlyList<ChatSessionDTO>> GetSessionsAsync(CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenReadConnectionAsync(cancellationToken);
        IEnumerable<SessionRow> rows = await connection.QueryAsync<SessionRow>(DapperCommandFactory.Create(
            ChatSql.SelectSessions,
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);
        return rows.Select(ToDto).ToList();
    }

    public async Task<ChatExportMetrics> GetExportMetricsAsync(CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenReadConnectionAsync(cancellationToken);
        return await connection.QuerySingleAsync<ChatExportMetrics>(DapperCommandFactory.Create(
            ChatSql.SelectExportMetrics,
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task<ChatSessionDTO?> GetSessionAsync(long sessionId, CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenReadConnectionAsync(cancellationToken);
        SessionRow? row = await connection.QuerySingleOrDefaultAsync<SessionRow>(DapperCommandFactory.Create(
            ChatSql.SelectSession,
            new { SessionId = sessionId },
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);
        return row is null ? null : ToDto(row);
    }

    public async Task UpdateSessionAsync(ChatSessionDTO session, CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenConnectionAsync(cancellationToken);
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            ChatSql.UpdateSession,
            new
            {
                SessionId = session.Id,
                session.Title,
                UpdatedAt = ToIso(session.UpdatedAt),
                session.Emotion,
                session.Theme,
                session.FirstIntensity,
                session.LastIntensity,
                session.StateJson
            },
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task DeleteSessionAsync(long sessionId, CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenConnectionAsync(cancellationToken);
        await using SqliteTransaction transaction = (SqliteTransaction)await connection.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            ChatSql.DeleteMessages, new { SessionId = sessionId }, transaction, CommandTimeoutSeconds, cancellationToken)).ConfigureAwait(false);
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            ChatSql.DeleteSession, new { SessionId = sessionId }, transaction, CommandTimeoutSeconds, cancellationToken)).ConfigureAwait(false);
        await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAllSessionsAsync(CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenConnectionAsync(cancellationToken);
        await using SqliteTransaction transaction = (SqliteTransaction)await connection.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            ChatSql.DeleteAllMessages, transaction: transaction, commandTimeout: CommandTimeoutSeconds, cancellationToken: cancellationToken)).ConfigureAwait(false);
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            ChatSql.DeleteAllSessions, transaction: transaction, commandTimeout: CommandTimeoutSeconds, cancellationToken: cancellationToken)).ConfigureAwait(false);
        await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task DeleteAllChatsAndMemoryExceptAsync(
        IReadOnlyCollection<string> retainedMemoryKeys,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(retainedMemoryKeys);
        await using SqliteConnection connection = await OpenConnectionAsync(cancellationToken);
        await using SqliteTransaction transaction = (SqliteTransaction)await connection.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            ChatSql.DeleteAllMessages,
            transaction: transaction,
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            ChatSql.DeleteAllSessions,
            transaction: transaction,
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);

        string memorySql = retainedMemoryKeys.Count == 0 ? ChatSql.ClearMemory : ChatSql.DeleteMemoryExceptKeys;
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            memorySql,
            retainedMemoryKeys.Count == 0 ? null : new { RetainedMemoryKeys = retainedMemoryKeys },
            transaction,
            CommandTimeoutSeconds,
            cancellationToken)).ConfigureAwait(false);

        await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<IReadOnlyDictionary<string, string>> GetMemoryAsync(CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenReadConnectionAsync(cancellationToken);
        IEnumerable<MemoryRow> rows = await connection.QueryAsync<MemoryRow>(DapperCommandFactory.Create(
            ChatSql.SelectMemory, commandTimeout: CommandTimeoutSeconds, cancellationToken: cancellationToken)).ConfigureAwait(false);
        return rows.ToDictionary(r => r.Key, r => r.Value);
    }

    public async Task SetMemoryAsync(string key, string value, CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenConnectionAsync(cancellationToken);
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            ChatSql.UpsertMemory, new { Key = key, Value = value }, commandTimeout: CommandTimeoutSeconds, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task IncrementMemoryAsync(string key, CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenConnectionAsync(cancellationToken);
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            ChatSql.IncrementMemory, new { Key = key }, commandTimeout: CommandTimeoutSeconds, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task DeleteMemoryAsync(string key, CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenConnectionAsync(cancellationToken);
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            ChatSql.DeleteMemoryKey, new { Key = key }, commandTimeout: CommandTimeoutSeconds, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task ClearMemoryAsync(CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenConnectionAsync(cancellationToken);
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            ChatSql.ClearMemory, commandTimeout: CommandTimeoutSeconds, cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    public async Task<long> AddMessageAsync(ChatMessageDTO message, CancellationToken cancellationToken = default) =>
        (await AddMessagesAsync([message], cancellationToken).ConfigureAwait(false))[0];

    public async Task<IReadOnlyList<long>> AddMessagesAsync(IReadOnlyList<ChatMessageDTO> messages, CancellationToken cancellationToken = default)
    {
        if (messages.Count == 0)
        {
            return [];
        }

        await using SqliteConnection connection = await OpenConnectionAsync(cancellationToken);
        await using SqliteTransaction transaction = (SqliteTransaction)await connection.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
        List<long> ids = new(messages.Count);
        foreach (ChatMessageDTO message in messages)
        {
            ids.Add(await connection.ExecuteScalarAsync<long>(DapperCommandFactory.Create(
                ChatSql.InsertMessage,
                new
                {
                    message.SessionId,
                    Role = (int)message.Role,
                    message.Text,
                    CreatedAt = ToIso(message.CreatedAt),
                    QuickRepliesJson = ChatQuickReplyJson.Serialize(message.QuickReplies)
                },
                transaction,
                CommandTimeoutSeconds,
                cancellationToken)).ConfigureAwait(false));
        }

        await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
        return ids;
    }

    public async Task<IReadOnlyList<long>> SaveTurnAsync(
        ChatSessionDTO session,
        IReadOnlyList<ChatMessageDTO> messages,
        IReadOnlyList<ChatMemoryChange> memory,
        CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenConnectionAsync(cancellationToken);
        await using SqliteTransaction transaction = (SqliteTransaction)await connection.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);

        foreach (ChatMemoryChange change in memory)
        {
            (string sql, object parameters) = change switch
            {
                { Increment: true } => (ChatSql.IncrementMemory, (object)new { change.Key }),
                { Value: null } => (ChatSql.DeleteMemoryKey, new { change.Key }),
                _ => (ChatSql.UpsertMemory, new { change.Key, change.Value })
            };
            await connection.ExecuteAsync(DapperCommandFactory.Create(
                sql, parameters, transaction, CommandTimeoutSeconds, cancellationToken)).ConfigureAwait(false);
        }

        List<long> ids = new(messages.Count);
        foreach (ChatMessageDTO message in messages)
        {
            ids.Add(await connection.ExecuteScalarAsync<long>(DapperCommandFactory.Create(
                ChatSql.InsertMessage,
                new
                {
                    message.SessionId,
                    Role = (int)message.Role,
                    message.Text,
                    CreatedAt = ToIso(message.CreatedAt),
                    QuickRepliesJson = ChatQuickReplyJson.Serialize(message.QuickReplies)
                },
                transaction,
                CommandTimeoutSeconds,
                cancellationToken)).ConfigureAwait(false));
        }

        await connection.ExecuteAsync(DapperCommandFactory.Create(
            ChatSql.UpdateSession,
            new
            {
                SessionId = session.Id,
                session.Title,
                UpdatedAt = ToIso(session.UpdatedAt),
                session.Emotion,
                session.Theme,
                session.FirstIntensity,
                session.LastIntensity,
                session.StateJson
            },
            transaction,
            CommandTimeoutSeconds,
            cancellationToken)).ConfigureAwait(false);

        await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
        return ids;
    }

    public async Task<IReadOnlyList<ChatMessageDTO>> GetMessagesAsync(long sessionId, CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenReadConnectionAsync(cancellationToken);
        IEnumerable<MessageRow> rows = await connection.QueryAsync<MessageRow>(DapperCommandFactory.Create(
            ChatSql.SelectMessages,
            new { SessionId = sessionId },
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);
        return rows.Select(ToMessageDto).ToList();
    }

    public async Task<ChatExportSnapshot> GetExportSnapshotAsync(int limit, CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenReadConnectionAsync(cancellationToken);
        await using SqliteTransaction transaction = (SqliteTransaction)await connection.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
        int cap = Math.Max(1, limit);
        IEnumerable<SessionRow> sessionRows = await connection.QueryAsync<SessionRow>(DapperCommandFactory.Create(
            ChatSql.SelectExportSessions,
            new { Limit = cap },
            transaction,
            CommandTimeoutSeconds,
            cancellationToken)).ConfigureAwait(false);
        IEnumerable<MessageRow> messageRows = await connection.QueryAsync<MessageRow>(DapperCommandFactory.Create(
            ChatSql.SelectMessagesForExport,
            new { Limit = cap },
            transaction,
            CommandTimeoutSeconds,
            cancellationToken)).ConfigureAwait(false);
        IEnumerable<MemoryRow> memoryRows = await connection.QueryAsync<MemoryRow>(DapperCommandFactory.Create(
            ChatSql.SelectMemory,
            transaction: transaction,
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);
        await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
        Dictionary<string, string> memory = memoryRows.ToDictionary(row => row.Key, row => row.Value, StringComparer.Ordinal);
        return new ChatExportSnapshot(sessionRows.Select(ToDto).ToList(), messageRows.Select(ToMessageDto).ToList(), memory);
    }

    public async Task<ChatMessagePage> GetMessagesPageAsync(
        long sessionId,
        long? beforeMessageId,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        int limit = Math.Clamp(pageSize, 1, 500);
        string sql = beforeMessageId is null ? ChatSql.SelectLatestMessages : ChatSql.SelectMessagesBefore;
        await using SqliteConnection connection = await OpenReadConnectionAsync(cancellationToken);
        IEnumerable<MessageRow> rows = await connection.QueryAsync<MessageRow>(DapperCommandFactory.Create(
            sql,
            new { SessionId = sessionId, BeforeMessageId = beforeMessageId, Limit = limit + 1 },
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);
        List<MessageRow> newestFirst = rows.Take(limit + 1).ToList();
        bool hasOlder = newestFirst.Count > limit;
        return new ChatMessagePage(newestFirst.Take(limit).Reverse().Select(ToMessageDto).ToList(), hasOlder);
    }

    private static ChatMessageDTO ToMessageDto(MessageRow row) => new()
    {
        Id = row.MessageId,
        SessionId = row.SessionId,
        Role = (ChatRole)row.Role,
        Text = row.Text,
        CreatedAt = FromIso(row.CreatedAt),
        QuickReplies = ChatQuickReplyJson.Deserialize(row.QuickRepliesJson)
    };

    private static ChatSessionDTO ToDto(SessionRow r) => new()
    {
        Id = r.SessionId,
        Title = r.Title,
        CreatedAt = FromIso(r.CreatedAt),
        UpdatedAt = FromIso(r.UpdatedAt),
        Emotion = r.Emotion,
        Theme = r.Theme,
        FirstIntensity = r.FirstIntensity,
        LastIntensity = r.LastIntensity,
        StateJson = r.StateJson,
        BackupKey = r.BackupKey,
        Preview = r.Preview,
        MessageCount = r.MessageCount,
        UserMessageCount = r.UserMessageCount
    };

    private static string ToIso(DateTime value) => SqliteTime.ToIso(value);

    private static DateTime FromIso(string value) => SqliteTime.FromIso(value);

    private sealed class SessionRow
    {
        public long SessionId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string UpdatedAt { get; set; } = string.Empty;
        public string? Emotion { get; set; }
        public string? Theme { get; set; }
        public int? FirstIntensity { get; set; }
        public int? LastIntensity { get; set; }
        public string? StateJson { get; set; }
        public string? BackupKey { get; set; }
        public string? Preview { get; set; }
        public int MessageCount { get; set; }
        public int UserMessageCount { get; set; }
    }

    private sealed class MemoryRow
    {
        public string Key { get; set; } = string.Empty;
        public string Value { get; set; } = string.Empty;
    }

    private sealed class MessageRow
    {
        public long MessageId { get; set; }
        public long SessionId { get; set; }
        public int Role { get; set; }
        public string Text { get; set; } = string.Empty;
        public string CreatedAt { get; set; } = string.Empty;
        public string? QuickRepliesJson { get; set; }
    }
}
