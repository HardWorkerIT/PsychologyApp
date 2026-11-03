using System.Text;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using Xunit;

namespace PsychologyApp.Presentation.Tests;

public sealed class AtomicFileWriterTests
{
    [Fact]
    public async Task WriteAsync_PreservesExistingFileAndCleansTemporaryFile_WhenWriteFails()
    {
        string directory = CreateDirectory();
        try
        {
            string path = Path.Combine(directory, "export.json");
            await File.WriteAllTextAsync(path, "valid previous export");

            IOException error = await Assert.ThrowsAsync<IOException>(() => AtomicFileWriter.WriteAsync(
                path,
                async (stream, cancellationToken) =>
                {
                    await stream.WriteAsync(Encoding.UTF8.GetBytes("partial export"), cancellationToken);
                    throw new IOException("simulated interrupted write");
                }));

            Assert.Equal("simulated interrupted write", error.Message);
            Assert.Equal("valid previous export", await File.ReadAllTextAsync(path));
            Assert.Empty(Directory.GetFiles(directory, ".export.json.*.tmp"));
        }
        finally
        {
            Directory.Delete(directory, recursive: true);
        }
    }

    [Fact]
    public async Task WriteAsync_PreservesExistingFileAndCleansTemporaryFile_WhenCanceledAfterTemporaryWrite()
    {
        string directory = CreateDirectory();
        try
        {
            string path = Path.Combine(directory, "export.json");
            await File.WriteAllTextAsync(path, "valid previous export");
            using CancellationTokenSource cancellation = new();

            await Assert.ThrowsAnyAsync<OperationCanceledException>(() => AtomicFileWriter.WriteAsync(
                path,
                async (stream, cancellationToken) =>
                {
                    await stream.WriteAsync(Encoding.UTF8.GetBytes("complete temporary export"), cancellationToken);
                    cancellation.Cancel();
                },
                cancellation.Token));

            Assert.Equal("valid previous export", await File.ReadAllTextAsync(path));
            Assert.Empty(Directory.GetFiles(directory, ".export.json.*.tmp"));
        }
        finally
        {
            Directory.Delete(directory, recursive: true);
        }
    }

    [Fact]
    public async Task WriteAllTextAsync_ReplacesTargetWithCompleteContent()
    {
        string directory = CreateDirectory();
        try
        {
            string path = Path.Combine(directory, "export.csv");
            await File.WriteAllTextAsync(path, "old export");

            await AtomicFileWriter.WriteAllTextAsync(path, "complete export", Encoding.UTF8);

            Assert.Equal("complete export", await File.ReadAllTextAsync(path));
            Assert.Empty(Directory.GetFiles(directory, ".export.csv.*.tmp"));
        }
        finally
        {
            Directory.Delete(directory, recursive: true);
        }
    }

    [Fact]
    public async Task WriteAllTextAsync_PreservesTargetAndCleansTemporaryFile_WhenTargetIsLocked()
    {
        if (!OperatingSystem.IsWindows())
        {
            return;
        }

        string directory = CreateDirectory();
        try
        {
            string path = Path.Combine(directory, "export.json");
            await File.WriteAllTextAsync(path, "valid previous export");
            Exception? error;
            using (new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                error = await Record.ExceptionAsync(() =>
                    AtomicFileWriter.WriteAllTextAsync(path, "new export", Encoding.UTF8));
            }

            Assert.True(error is IOException or UnauthorizedAccessException, $"Unexpected error: {error}");
            Assert.Equal("valid previous export", await File.ReadAllTextAsync(path));
            Assert.Empty(Directory.GetFiles(directory, ".export.json.*.tmp"));
        }
        finally
        {
            Directory.Delete(directory, recursive: true);
        }
    }

    private static string CreateDirectory()
    {
        string directory = Path.Combine(Path.GetTempPath(), $"PsychologyApp.AtomicWrite.{Guid.NewGuid():N}");
        Directory.CreateDirectory(directory);
        return directory;
    }
}
