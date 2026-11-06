using System.Runtime.CompilerServices;
using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using PsychologyApp.Application.Abstractions.Persistence;
using PsychologyApp.Application.Configuration;
using PsychologyApp.Infrastructure.Data;
using PsychologyApp.Infrastructure.Data.Context;
using PsychologyApp.Infrastructure.Data.Sql;

namespace PsychologyApp.Infrastructure.Data.Repositories.Quots;

public sealed class FavoriteQuoteTextStore(
    IDbConnectionFactory connectionFactory,
    IOptions<AppSettings> settings) : IFavoriteQuoteTextStore
{
    private const string TextsKey = "FavoriteQuoteTexts";
    private const string LegacyIndicesKey = "FavoriteQuoteIndices";
    private int CommandTimeoutSeconds => settings.Value.DbCommandTimeoutSeconds;

    public async Task<IReadOnlySet<string>> GetTextsAsync(CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenReadConnectionAsync(cancellationToken);
        string? value = await connection.ExecuteScalarAsync<string?>(DapperCommandFactory.Create(
            "SELECT Value FROM AppMetadata WHERE Key = @key;",
            new { key = TextsKey },
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);

        return ParseTexts(value);
    }

    public async Task AddTextAsync(string text, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return;
        }

        await MutateTextAsync(text, add: true, cancellationToken).ConfigureAwait(false);
    }

    public async Task RemoveTextAsync(string text, CancellationToken cancellationToken = default)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return;
        }

        await MutateTextAsync(text, add: false, cancellationToken).ConfigureAwait(false);
    }

    public async Task SaveTextsAsync(IReadOnlySet<string> texts, CancellationToken cancellationToken = default)
    {
        HashSet<string> normalized = new(StringComparer.Ordinal);
        foreach (string text in texts)
        {
            if (!string.IsNullOrWhiteSpace(text))
            {
                normalized.Add(text);
            }
        }

        await using SqliteConnection connection = await OpenConnectionAsync(cancellationToken);
        await using SqliteTransaction transaction = (SqliteTransaction)await connection.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
        HashSet<string> merged = await ReadTextsAsync(connection, transaction, cancellationToken).ConfigureAwait(false);
        merged.UnionWith(normalized);
        await SaveTextsInternalAsync(connection, transaction, merged, cancellationToken).ConfigureAwait(false);
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            "DELETE FROM AppMetadata WHERE Key = @key;",
            new { key = LegacyIndicesKey },
            transaction,
            CommandTimeoutSeconds,
            cancellationToken)).ConfigureAwait(false);
        await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
    }

    public async Task<IReadOnlySet<int>> GetLegacyIndicesAsync(CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenReadConnectionAsync(cancellationToken);
        string? value = await connection.ExecuteScalarAsync<string?>(DapperCommandFactory.Create(
            "SELECT Value FROM AppMetadata WHERE Key = @key;",
            new { key = LegacyIndicesKey },
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);

        return ParseIndices(value);
    }

    public async Task ClearLegacyIndicesAsync(CancellationToken cancellationToken = default)
    {
        await using SqliteConnection connection = await OpenConnectionAsync(cancellationToken);
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            "DELETE FROM AppMetadata WHERE Key = @key;",
            new { key = LegacyIndicesKey },
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    private async Task MutateTextAsync(string text, bool add, CancellationToken cancellationToken)
    {
        await using SqliteConnection connection = await OpenConnectionAsync(cancellationToken);
        await using SqliteTransaction transaction = (SqliteTransaction)await connection.BeginTransactionAsync(cancellationToken).ConfigureAwait(false);
        HashSet<string> texts = await ReadTextsAsync(connection, transaction, cancellationToken).ConfigureAwait(false);
        bool changed = add ? texts.Add(text) : texts.Remove(text);
        if (changed)
        {
            await SaveTextsInternalAsync(connection, transaction, texts, cancellationToken).ConfigureAwait(false);
        }

        await transaction.CommitAsync(cancellationToken).ConfigureAwait(false);
    }

    private async Task<HashSet<string>> ReadTextsAsync(
        SqliteConnection connection,
        SqliteTransaction? transaction,
        CancellationToken cancellationToken)
    {
        string? value = await connection.ExecuteScalarAsync<string?>(DapperCommandFactory.Create(
            "SELECT Value FROM AppMetadata WHERE Key = @key;",
            new { key = TextsKey },
            transaction,
            CommandTimeoutSeconds,
            cancellationToken)).ConfigureAwait(false);
        return FavoriteQuoteTextsCodec.Decode(value);
    }

    private async Task SaveTextsInternalAsync(
        SqliteConnection connection,
        SqliteTransaction? transaction,
        HashSet<string> texts,
        CancellationToken cancellationToken)
    {
        string serialized = FavoriteQuoteTextsCodec.Encode(texts);
        await connection.ExecuteAsync(DapperCommandFactory.Create(
            """
            INSERT INTO AppMetadata (Key, Value)
            VALUES (@key, @value)
            ON CONFLICT(Key) DO UPDATE SET Value = excluded.Value;
            """,
            new { key = TextsKey, value = serialized },
            transaction,
            commandTimeout: CommandTimeoutSeconds,
            cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    private static HashSet<string> ParseTexts(string? value) => FavoriteQuoteTextsCodec.Decode(value);

    private static HashSet<int> ParseIndices(string? value)
    {
        HashSet<int> indices = [];
        if (string.IsNullOrWhiteSpace(value))
        {
            return indices;
        }

        foreach (string part in value.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            if (int.TryParse(part, out int index))
            {
                indices.Add(index);
            }
        }

        return indices;
    }

    private ConfiguredTaskAwaitable<SqliteConnection> OpenConnectionAsync(CancellationToken cancellationToken) =>
        SqliteOperationLane.OpenAsync(connectionFactory, cancellationToken);

    private ConfiguredTaskAwaitable<SqliteConnection> OpenReadConnectionAsync(CancellationToken cancellationToken) =>
        SqliteOperationLane.OpenAsync(connectionFactory, cancellationToken, readOnly: true);
}
