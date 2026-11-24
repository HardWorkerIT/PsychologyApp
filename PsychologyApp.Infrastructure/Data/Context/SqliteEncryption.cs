using System.Text.RegularExpressions;
using Dapper;
using Microsoft.Data.Sqlite;

namespace PsychologyApp.Infrastructure.Data.Context;

/// <summary>
/// Encrypts the database file at rest (SQLite3 Multiple Ciphers, ChaCha20-Poly1305) and moves a database written by an older,
/// unencrypted build over to it. The original is kept until the encrypted file has been opened again and every table has the same
/// number of rows as before; if that check fails the original is put back.
/// </summary>
public static partial class SqliteEncryption
{
    internal const string PlainCopySuffix = ".plain.bak";

    public static bool IsValidKey(string key) => KeyPattern().IsMatch(key);

    [GeneratedRegex("\\A[0-9a-fA-F]{64}\\z")]
    private static partial Regex KeyPattern();

    /// <summary>Applies the key to an open connection; must be the first statement on it.</summary>
    public static async Task ApplyKeyAsync(SqliteConnection connection, string key, CancellationToken cancellationToken = default)
    {
        ValidateKey(key);

        await UseDirectKeyAsync(connection, cancellationToken).ConfigureAwait(false);
        await connection.ExecuteAsync(new CommandDefinition($"PRAGMA hexkey = '{key}';", cancellationToken: cancellationToken)).ConfigureAwait(false);
    }

    /// <summary>
    /// The key is 256 random bits, so stretching it adds no security, and the default stretching (about 33 ms on a desktop, several
    /// times that on a phone) would be paid on every connection that is opened. One iteration keeps the derivation but makes it free.
    /// Must be set the same way when the key is applied and when the file is re-keyed.
    /// </summary>
    private static Task UseDirectKeyAsync(SqliteConnection connection, CancellationToken cancellationToken) =>
        connection.ExecuteAsync(new CommandDefinition("PRAGMA kdf_iter = 1;", cancellationToken: cancellationToken));

    /// <summary>
    /// Makes the file at <paramref name="path"/> encrypted with <paramref name="key"/>. Returns false (and leaves the
    /// original, readable file in place) when the move could not be verified. Callers must refuse access until encryption succeeds.
    /// </summary>
    public static async Task<bool> EnsureEncryptedAsync(string path, string key, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        ValidateKey(key);
        SqliteProvider.EnsureInitialized();
        string plainCopy = path + PlainCopySuffix;
        if (!File.Exists(path) || new FileInfo(path).Length == 0)
        {
            if (!await TryRestorePlainCopyAsync(path, plainCopy, cancellationToken).ConfigureAwait(false))
            {
                // An unreadable backup may be the only remaining copy of the user's data: refuse to initialize a fresh database.
                return !File.Exists(plainCopy);
            }
        }

        if (!await IsPlainAsync(path, cancellationToken).ConfigureAwait(false))
        {
            // An existing encrypted database must open with this key; a missing or corrupted secure-store value must not be accepted.
            if (await CanOpenWithKeyAsync(path, key, cancellationToken).ConfigureAwait(false))
            {
                // A copy left behind by an interrupted move is removed only after the encrypted file opens with its key.
                if (File.Exists(plainCopy))
                {
                    File.Delete(plainCopy);
                }

                return true;
            }

            // Rekeying may have been interrupted after the main file became unreadable.
            if (!await TryRestorePlainCopyAsync(path, plainCopy, cancellationToken).ConfigureAwait(false))
            {
                return false;
            }
        }

        // Fold committed WAL frames into the main file before taking the rollback copy.
        // If another connection prevents this, abort without replacing files or deleting its WAL.
        await using (SqliteConnection connection = Open(path))
        {
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
            string? mode = await connection.ExecuteScalarAsync<string>(new CommandDefinition(
                "PRAGMA journal_mode=DELETE;", cancellationToken: cancellationToken)).ConfigureAwait(false);
            if (!string.Equals(mode, "delete", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException("The database could not leave WAL mode for encryption.");
            }
            File.Copy(path, plainCopy, overwrite: true);
        }
        try
        {
            IReadOnlyDictionary<string, long> before = await CountRowsAsync(path, null, cancellationToken).ConfigureAwait(false);
            await RekeyAsync(path, key, cancellationToken).ConfigureAwait(false);
            IReadOnlyDictionary<string, long> after = await CountRowsAsync(path, key, cancellationToken).ConfigureAwait(false);

            if (before.Count != after.Count || before.Any(kv => !after.TryGetValue(kv.Key, out long n) || n != kv.Value))
            {
                throw new InvalidOperationException("The encrypted database does not have the same rows as the original.");
            }
        }
        catch (SqliteException ex) when (ex.SqliteErrorCode is SQLitePCL.raw.SQLITE_BUSY or SQLitePCL.raw.SQLITE_LOCKED)
        {
            // Another connection may still be using the original file. Keep both copies for a retry.
            throw;
        }
        catch (OperationCanceledException)
        {
            RestorePlainCopy(path, plainCopy);
            throw;
        }
        catch (Exception)
        {
            RestorePlainCopy(path, plainCopy);
            return false;
        }

        File.Delete(plainCopy);
        return true;
    }

    /// <summary>
    /// A replacement key is safe only before a database exists or while an existing database is still plaintext.
    /// An encrypted or unreadable file may contain the user's only copy of their data and must not get a new key.
    /// </summary>
    public static async Task<bool> CanCreateKeyAsync(string path, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        SqliteProvider.EnsureInitialized();
        if (!File.Exists(path) || new FileInfo(path).Length == 0)
        {
            string plainCopy = path + PlainCopySuffix;
            return !File.Exists(plainCopy) || await IsRecoveryCopyValidAsync(plainCopy, cancellationToken).ConfigureAwait(false);
        }

        return await IsPlainAsync(path, cancellationToken).ConfigureAwait(false);
    }

    private static async Task<bool> TryRestorePlainCopyAsync(string path, string plainCopy, CancellationToken cancellationToken)
    {
        if (!await IsRecoveryCopyValidAsync(plainCopy, cancellationToken).ConfigureAwait(false))
        {
            return false;
        }

        cancellationToken.ThrowIfCancellationRequested();
        RestorePlainCopy(path, plainCopy);
        return true;
    }

    private static async Task<bool> IsRecoveryCopyValidAsync(string plainCopy, CancellationToken cancellationToken)
    {
        // SQLite accepts a zero-byte file as a new database. It is not a usable recovery copy.
        if (!File.Exists(plainCopy) || new FileInfo(plainCopy).Length == 0)
        {
            return false;
        }

        try
        {
            await using SqliteConnection connection = Open(plainCopy, SqliteOpenMode.ReadOnly);
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
            string? status = await connection.ExecuteScalarAsync<string>(new CommandDefinition(
                "PRAGMA quick_check;", cancellationToken: cancellationToken)).ConfigureAwait(false);
            return string.Equals(status, "ok", StringComparison.Ordinal);
        }
        catch (SqliteException ex) when (IsUnreadable(ex))
        {
            return false;
        }
    }

    private static void RestorePlainCopy(string path, string plainCopy)
    {
        SqliteConnection.ClearAllPools();
        // A journal from the failed migration must not be replayed against the restored snapshot.
        File.Delete(path + "-wal");
        File.Delete(path + "-shm");
        File.Delete(path + "-journal");
        File.Move(plainCopy, path, overwrite: true);
    }

    private static async Task RekeyAsync(string path, string key, CancellationToken cancellationToken)
    {
        await using (SqliteConnection connection = Open(path))
        {
            await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
            // The key cannot be changed while the file is in WAL mode, and this also folds the WAL into the main file.
            await connection.ExecuteAsync(new CommandDefinition("PRAGMA journal_mode=DELETE;", cancellationToken: cancellationToken)).ConfigureAwait(false);
            await UseDirectKeyAsync(connection, cancellationToken).ConfigureAwait(false);
            await connection.ExecuteAsync(new CommandDefinition($"PRAGMA hexrekey = '{key}';", cancellationToken: cancellationToken)).ConfigureAwait(false);
        }

        SqliteConnection.ClearAllPools();
        TryDelete(path + "-wal");
        TryDelete(path + "-shm");
    }

    private static async Task<bool> IsPlainAsync(string path, CancellationToken cancellationToken)
    {
        try
        {
            await CountRowsAsync(path, null, cancellationToken).ConfigureAwait(false);
            return true;
        }
        catch (SqliteException ex) when (IsUnreadable(ex))
        {
            return false;
        }
    }

    private static async Task<bool> CanOpenWithKeyAsync(string path, string key, CancellationToken cancellationToken)
    {
        try
        {
            await CountRowsAsync(path, key, cancellationToken).ConfigureAwait(false);
            return true;
        }
        catch (SqliteException ex) when (IsUnreadable(ex))
        {
            return false;
        }
    }

    private static async Task<IReadOnlyDictionary<string, long>> CountRowsAsync(string path, string? key, CancellationToken cancellationToken)
    {
        await using SqliteConnection connection = Open(path);
        await connection.OpenAsync(cancellationToken).ConfigureAwait(false);
        if (key is not null)
        {
            await ApplyKeyAsync(connection, key, cancellationToken).ConfigureAwait(false);
        }

        IEnumerable<string> tables = await connection.QueryAsync<string>(new CommandDefinition(
            "SELECT name FROM sqlite_master WHERE type = 'table' AND name NOT LIKE 'sqlite_%' ORDER BY name;",
            cancellationToken: cancellationToken)).ConfigureAwait(false);

        Dictionary<string, long> counts = [];
        foreach (string table in tables)
        {
            counts[table] = await connection.ExecuteScalarAsync<long>(new CommandDefinition(
                $"SELECT COUNT(*) FROM \"{table.Replace("\"", "\"\"")}\";",
                cancellationToken: cancellationToken)).ConfigureAwait(false);
        }

        return counts;
    }

    private static bool IsUnreadable(SqliteException ex) => ex.SqliteErrorCode is SQLitePCL.raw.SQLITE_NOTADB or SQLitePCL.raw.SQLITE_CORRUPT;

    private static void ValidateKey(string key)
    {
        if (!IsValidKey(key))
        {
            throw new ArgumentException("The database key must be 64 hexadecimal characters.", nameof(key));
        }
    }

    private static SqliteConnection Open(string path, SqliteOpenMode mode = SqliteOpenMode.ReadWriteCreate) => new(new SqliteConnectionStringBuilder
    {
        DataSource = path,
        Mode = mode,
        Pooling = false
    }.ToString());

    private static void TryDelete(string file)
    {
        try
        {
            File.Delete(file);
        }
        catch (IOException)
        {
        }
    }
}
