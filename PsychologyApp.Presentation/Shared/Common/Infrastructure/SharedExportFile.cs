using System.Text;
using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.Maui.Storage;

namespace PsychologyApp.Presentation.Shared.Common.Infrastructure;

internal static class SharedExportFile
{
    private static readonly TimeSpan Retention = TimeSpan.FromMinutes(15);

    private static string CacheRoot => Path.Combine(FileSystem.CacheDirectory, "shared-exports");

    internal static Task ShareAsync(string fileName, string content, string title, CancellationToken cancellationToken) =>
        DeliverAsync(fileName, content,
            path => Share.Default.RequestAsync(new ShareFileRequest { Title = title, File = new ShareFile(path) }), cancellationToken);

    internal static async Task DeliverAsync(string fileName, string content, Func<string, Task> handOff, CancellationToken cancellationToken)
    {
        // Independent paths keep a second export from replacing a file a recipient has yet to read.
        string directory = Path.Combine(CacheRoot, Guid.NewGuid().ToString("N"));
        string path = Path.Combine(directory, fileName);
        bool handedOff = false;
        try
        {
            Directory.CreateDirectory(directory);
            await AtomicFileWriter.WriteAllTextAsync(path, content, Encoding.UTF8, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            await handOff(path);
            // Android may report handoff before the receiving app has opened the file.
            handedOff = true;
            RemoveAfterDelayAsync(directory, Retention).FireAndForget();
        }
        finally
        {
            if (!handedOff)
            {
                TryRemove(directory);
            }
        }
    }

    internal static void ResumeCleanup()
    {
        string root = CacheRoot;
        if (!Directory.Exists(root))
        {
            return;
        }

        DateTime now = DateTime.UtcNow;
        foreach (DirectoryInfo directory in new DirectoryInfo(root).EnumerateDirectories())
        {
            if (!Guid.TryParseExact(directory.Name, "N", out _)
                || (directory.Attributes & FileAttributes.ReparsePoint) != 0)
            {
                continue;
            }

            TimeSpan delay = Retention - (now - directory.LastWriteTimeUtc);
            if (delay <= TimeSpan.Zero)
            {
                TryRemove(directory.FullName);
            }
            else
            {
                // A process that restarted before expiry must still remove the export when its time is up.
                RemoveAfterDelayAsync(directory.FullName, delay > Retention ? Retention : delay).FireAndForget();
            }
        }
    }

    private static async Task RemoveAfterDelayAsync(string directory, TimeSpan delay)
    {
        await Task.Delay(delay).ConfigureAwait(false);
        TryRemove(directory);
    }

    private static void TryRemove(string directory)
    {
        try
        {
            Directory.Delete(directory, recursive: true);
        }
        catch (DirectoryNotFoundException)
        {
        }
        catch (Exception ex) when (ex is IOException or UnauthorizedAccessException)
        {
            BestEffort.Report(ex);
        }
    }
}
