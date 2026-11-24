using System.Data.Common;
using Dapper;
using Microsoft.Data.Sqlite;
using PsychologyApp.Application.Abstractions.Persistence;
using PsychologyApp.Infrastructure.Data.Context;
using PsychologyApp.Testing.Data;
using Xunit;

namespace PsychologyApp.Infrastructure.Tests.Data;

public sealed class SqliteDatabaseInitializerTests : IDisposable
{
    private readonly string _path = Path.Combine(Path.GetTempPath(), $"reset;{Guid.NewGuid():N}.db");

    [Fact]
    public async Task ResetClearsTheConfiguredDatabaseAndItsRecoveryCopy()
    {
        SqliteConnectionFactory factory = new(new FixedKeyProvider(), _path);
        SqliteDatabaseInitializer initializer = new(factory);
        await initializer.InitializeAsync();
        await using (DbConnection connection = await factory.CreateOpenConnectionAsync())
        {
            await InsertQuoteAsync(connection);
        }
        string recoveryCopy = _path + SqliteEncryption.PlainCopySuffix;
        await File.WriteAllTextAsync(recoveryCopy, "residual recovery data");

        await initializer.RecreateDatabaseAsync();

        await using DbConnection reopened = await factory.CreateOpenConnectionAsync();
        Assert.Equal(0, await reopened.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Quots;"));
        Assert.False(File.Exists(recoveryCopy));
    }

    [Fact]
    public async Task ASharedMemoryDatabaseCannotTriggerFileDeletion()
    {
        await using SharedMemoryConnectionFactory factory = new();
        await using DbConnection connection = await factory.CreateOpenConnectionAsync();
        await InsertQuoteAsync(connection);
        SqliteDatabaseInitializer initializer = new(factory);

        await Assert.ThrowsAsync<NotSupportedException>(() => initializer.RecreateDatabaseAsync());

        Assert.Equal(1, await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Quots;"));
    }

    [Fact]
    public async Task AReaderBlockingTheWalCheckpointPreventsDeletion()
    {
        SqliteConnectionFactory factory = new(new FixedKeyProvider(), _path);
        SqliteDatabaseInitializer initializer = new(new ResetConnectionFactory(factory, open => open.DefaultTimeout = 1));
        await initializer.InitializeAsync();
        await using SqliteConnection reader = (SqliteConnection)await factory.CreateOpenConnectionAsync();
        await using SqliteTransaction snapshot = reader.BeginTransaction(deferred: true);
        Assert.Equal(0, await reader.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Quots;", transaction: snapshot));
        await using (DbConnection writer = await factory.CreateOpenConnectionAsync())
        {
            await InsertQuoteAsync(writer);
        }

        await Assert.ThrowsAsync<IOException>(() => initializer.RecreateDatabaseAsync());

        await snapshot.RollbackAsync();
        Assert.Equal(1, await reader.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Quots;"));
    }

    [Fact]
    public async Task CancellationAfterDeletionStillRecreatesTheSchemaAndCompletesCleanup()
    {
        SqliteConnectionFactory factory = new(new FixedKeyProvider(), _path);
        await new SqliteDatabaseInitializer(factory).InitializeAsync();
        using CancellationTokenSource cancellation = new();
        SqliteDatabaseInitializer initializer = new(new ResetConnectionFactory(factory, beforeOpen: () =>
        {
            if (!File.Exists(_path))
            {
                cancellation.Cancel();
            }
        }));
        bool cleanupCompleted = false;

        await initializer.RecreateDatabaseAsync(() =>
        {
            cleanupCompleted = true;
            return Task.CompletedTask;
        }, cancellation.Token);

        Assert.True(cancellation.IsCancellationRequested);
        Assert.True(cleanupCompleted);
        await using DbConnection reopened = await factory.CreateOpenConnectionAsync();
        Assert.Equal(0, await reopened.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM Quots;"));
    }

    private static Task InsertQuoteAsync(DbConnection connection) => connection.ExecuteAsync(
        "INSERT INTO Quots (Title, Text, Theme, IsReaded, IsFavourite) VALUES ('title', 'record to erase', 'theme', 0, 0);");

    public void Dispose()
    {
        using SqliteConnection connection = new(new SqliteConnectionStringBuilder { DataSource = _path }.ToString());
        SqliteConnection.ClearPool(connection);
        foreach (string suffix in new[] { "-wal", "-shm", "-journal", SqliteEncryption.PlainCopySuffix, string.Empty })
        {
            File.Delete(_path + suffix);
        }
    }

    private sealed class FixedKeyProvider : IDatabaseKeyProvider
    {
        public Task<string?> GetKeyAsync(CancellationToken cancellationToken = default) => Task.FromResult<string?>(new string('a', 64));

        public Task<string?> CreateKeyAsync(CancellationToken cancellationToken = default) => GetKeyAsync(cancellationToken);
    }

    private sealed class ResetConnectionFactory(SqliteConnectionFactory factory, Action<SqliteConnection>? afterOpen = null, Action? beforeOpen = null)
        : IDbConnectionFactory
    {
        public string DatabasePath => factory.DatabasePath;

        public async Task<DbConnection> CreateOpenConnectionAsync(CancellationToken cancellationToken = default)
        {
            beforeOpen?.Invoke();
            SqliteConnection connection = (SqliteConnection)await factory.CreateOpenConnectionAsync(cancellationToken);
            afterOpen?.Invoke(connection);
            return connection;
        }
    }
}
