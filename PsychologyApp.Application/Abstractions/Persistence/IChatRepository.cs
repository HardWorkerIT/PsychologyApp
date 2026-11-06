using System.Text;
using PsychologyApp.Application.Chat;

namespace PsychologyApp.Application.Abstractions.Persistence;

public interface IChatRepository
{
    Task<long> CreateSessionAsync(string title, DateTime nowUtc, CancellationToken cancellationToken = default);

    /// <summary>Newest activity first, each with its last message as <see cref="ChatSessionDTO.Preview"/>.</summary>
    Task<IReadOnlyList<ChatSessionDTO>> GetSessionsAsync(CancellationToken cancellationToken = default);

    Task<ChatSessionDTO?> GetSessionAsync(long sessionId, CancellationToken cancellationToken = default);

    Task UpdateSessionAsync(ChatSessionDTO session, CancellationToken cancellationToken = default);

    Task DeleteSessionAsync(long sessionId, CancellationToken cancellationToken = default);

    Task<long> AddMessageAsync(ChatMessageDTO message, CancellationToken cancellationToken = default);

    /// <summary>Stores the messages in order in one transaction. Returns their ids in the same order.</summary>
    Task<IReadOnlyList<long>> AddMessagesAsync(IReadOnlyList<ChatMessageDTO> messages, CancellationToken cancellationToken = default);

    Task<IReadOnlyList<ChatMessageDTO>> GetMessagesAsync(long sessionId, CancellationToken cancellationToken = default);

    /// <summary>Loads bounded chat data for export; database implementations should read both collections from one snapshot.</summary>
    async Task<ChatExportSnapshot> GetExportSnapshotAsync(int limit, CancellationToken cancellationToken = default)
    {
        int cap = Math.Max(1, limit);
        List<ChatMessageDTO> messages = new(cap);
        IReadOnlyList<ChatSessionDTO> sessions = await GetSessionsAsync(cancellationToken).ConfigureAwait(false);
        foreach (ChatSessionDTO session in sessions)
        {
            IReadOnlyList<ChatMessageDTO> sessionMessages = await GetMessagesAsync(session.Id, cancellationToken).ConfigureAwait(false);
            int remaining = cap - messages.Count;
            messages.AddRange(sessionMessages.Take(remaining));
            if (messages.Count == cap)
            {
                break;
            }
        }

        IReadOnlyDictionary<string, string> memory = await GetMemoryAsync(cancellationToken).ConfigureAwait(false);
        return new ChatExportSnapshot(sessions, messages, memory);
    }

    /// <summary>Returns chat volume without retaining the full history; SQLite implementations should aggregate in the database.</summary>
    async Task<ChatExportMetrics> GetExportMetricsAsync(CancellationToken cancellationToken = default)
    {
        static long Utf8Length(string? value) => value is null ? 0 : Encoding.UTF8.GetByteCount(value);

        IReadOnlyList<ChatSessionDTO> sessions = await GetSessionsAsync(cancellationToken).ConfigureAwait(false);
        long messageCount = 0;
        long payloadBytes = 0;
        foreach (ChatSessionDTO session in sessions)
        {
            payloadBytes += Utf8Length(session.Title) + Utf8Length(session.Emotion) + Utf8Length(session.Theme)
                + Utf8Length(session.StateJson);
            IReadOnlyList<ChatMessageDTO> messages = await GetMessagesAsync(session.Id, cancellationToken).ConfigureAwait(false);
            messageCount += messages.Count;
            foreach (ChatMessageDTO message in messages)
            {
                payloadBytes += Utf8Length(message.Text);
                foreach (ChatQuickReply reply in message.QuickReplies)
                {
                    payloadBytes += Utf8Length(reply.Kind) + Utf8Length(reply.Label) + Utf8Length(reply.Payload);
                }
            }
        }

        IReadOnlyDictionary<string, string> memory = await GetMemoryAsync(cancellationToken).ConfigureAwait(false);
        long memoryCount = 0;
        foreach ((string key, string value) in memory)
        {
            memoryCount++;
            payloadBytes += Utf8Length(key) + Utf8Length(value);
        }

        return new ChatExportMetrics
        {
            SessionCount = sessions.Count,
            MessageCount = messageCount,
            MemoryCount = memoryCount,
            Utf8PayloadBytes = payloadBytes
        };
    }

    /// <summary>Loads a bounded page efficiently when supported; older repositories can use the full history as a fallback.</summary>
    async Task<ChatMessagePage> GetMessagesPageAsync(
        long sessionId,
        long? beforeMessageId,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        int limit = Math.Clamp(pageSize, 1, 500);
        IReadOnlyList<ChatMessageDTO> all = await GetMessagesAsync(sessionId, cancellationToken).ConfigureAwait(false);
        IEnumerable<ChatMessageDTO> candidates = beforeMessageId is { } before
            ? all.Where(message => message.Id < before)
            : all;
        List<ChatMessageDTO> newestFirst = candidates.OrderByDescending(message => message.Id).Take(limit + 1).ToList();
        bool hasOlder = newestFirst.Count > limit;
        return new ChatMessagePage(newestFirst.Take(limit).Reverse().ToList(), hasOlder);
    }

    /// <summary>Removes every chat and message. The memory is left to the caller (<see cref="Chat.ChatMemoryKeys.OutlivesChats"/>).</summary>
    Task DeleteAllSessionsAsync(CancellationToken cancellationToken = default);

    /// <summary>Atomically removes all chats and every memory key not in <paramref name="retainedMemoryKeys"/>.</summary>
    Task DeleteAllChatsAndMemoryExceptAsync(IReadOnlyCollection<string> retainedMemoryKeys, CancellationToken cancellationToken = default);

    /// <summary>Everything the companion remembers between chats, by key.</summary>
    Task<IReadOnlyDictionary<string, string>> GetMemoryAsync(CancellationToken cancellationToken = default);

    Task SetMemoryAsync(string key, string value, CancellationToken cancellationToken = default);

    /// <summary>Adds one to a counter kept under <paramref name="key"/> (created at 1).</summary>
    Task IncrementMemoryAsync(string key, CancellationToken cancellationToken = default);

    Task DeleteMemoryAsync(string key, CancellationToken cancellationToken = default);

    Task ClearMemoryAsync(CancellationToken cancellationToken = default);

    /// <summary>
    /// Everything one turn changes, saved together: the memory it revealed, the messages (user and companion) and the session
    /// (state, title, activity time). Either all of it is stored or none of it, so a chat can never show messages whose state was
    /// lost, or counters for a turn that was not saved. Returns the message ids in order. Implementations should make it one
    /// transaction; this default applies the steps one after another.
    /// </summary>
    async Task<IReadOnlyList<long>> SaveTurnAsync(
        ChatSessionDTO session,
        IReadOnlyList<ChatMessageDTO> messages,
        IReadOnlyList<ChatMemoryChange> memory,
        CancellationToken cancellationToken = default)
    {
        foreach (ChatMemoryChange change in memory)
        {
            if (change.Increment)
            {
                await IncrementMemoryAsync(change.Key, cancellationToken).ConfigureAwait(false);
            }
            else if (change.Value is null)
            {
                await DeleteMemoryAsync(change.Key, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                await SetMemoryAsync(change.Key, change.Value, cancellationToken).ConfigureAwait(false);
            }
        }

        IReadOnlyList<long> ids = await AddMessagesAsync(messages, cancellationToken).ConfigureAwait(false);
        await UpdateSessionAsync(session, cancellationToken).ConfigureAwait(false);
        return ids;
    }
}

/// <summary>One change to what the companion remembers: set a value, add one to a counter, or (null value, no increment) forget a key.</summary>
public sealed record ChatMemoryChange(string Key, string? Value = null, bool Increment = false);
