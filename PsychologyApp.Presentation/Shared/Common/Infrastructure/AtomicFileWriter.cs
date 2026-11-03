using System.Text;

namespace PsychologyApp.Presentation.Shared.Common.Infrastructure;

/// <summary>Publishes complete generated files without truncating a previously valid target on write failure.</summary>
public static class AtomicFileWriter
{
    public static Task WriteAllTextAsync(
        string path,
        string content,
        Encoding encoding,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(encoding);
        cancellationToken.ThrowIfCancellationRequested();
        byte[] bytes = encoding.GetBytes(content);
        return WriteAsync(
            path,
            (stream, token) => stream.WriteAsync(bytes, token).AsTask(),
            cancellationToken);
    }

    public static async Task WriteAsync(
        string path,
        Func<Stream, CancellationToken, Task> writeContentAsync,
        CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(path);
        ArgumentNullException.ThrowIfNull(writeContentAsync);
        cancellationToken.ThrowIfCancellationRequested();

        string fullPath = Path.GetFullPath(path);
        string directory = Path.GetDirectoryName(fullPath)!;
        Directory.CreateDirectory(directory);
        string temporaryPath = Path.Combine(
            directory,
            $".{Path.GetFileName(fullPath)}.{Guid.NewGuid():N}.tmp");

        try
        {
            await using (FileStream stream = new(
                temporaryPath,
                new FileStreamOptions
                {
                    Mode = FileMode.CreateNew,
                    Access = FileAccess.Write,
                    Share = FileShare.None,
                    BufferSize = 16 * 1024,
                    Options = FileOptions.Asynchronous
                }))
            {
                await writeContentAsync(stream, cancellationToken).ConfigureAwait(false);
                await stream.FlushAsync(cancellationToken).ConfigureAwait(false);
                stream.Flush(flushToDisk: true);
            }

            cancellationToken.ThrowIfCancellationRequested();
            File.Move(temporaryPath, fullPath, overwrite: true);
        }
        finally
        {
            TryDelete(temporaryPath);
        }
    }

    private static void TryDelete(string path)
    {
        try
        {
            File.Delete(path);
        }
        catch (IOException)
        {
            // A failed export must not be reported as successful because temporary cleanup also failed.
        }
        catch (UnauthorizedAccessException)
        {
        }
    }
}
