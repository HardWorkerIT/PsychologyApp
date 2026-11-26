using System.Buffers;
using System.Text;

namespace PsychologyApp.Application.DataBackup;

public static class BackupFileReader
{
    private const int ReadBufferSize = 64 * 1024;
    private const int MaxInitialCapacity = 1024 * 1024;
    private static readonly UTF8Encoding StrictUtf8 = new(false, throwOnInvalidBytes: true);

    public static async Task<string> ReadAsync(Stream source, CancellationToken cancellationToken)
    {
        int initialCapacity = 0;
        if (source.CanSeek)
        {
            long length = source.Length;
            if (length > BackupService.MaxImportFileBytes)
            {
                throw TooLarge();
            }

            initialCapacity = (int)Math.Clamp(length - source.Position, 0, MaxInitialCapacity);
        }

        using MemoryStream content = new(initialCapacity);
        byte[] buffer = ArrayPool<byte>.Shared.Rent(ReadBufferSize);
        try
        {
            while (true)
            {
                // A picker stream can be non-seekable. Read at most one byte past the limit to detect overflow.
                int requested = (int)Math.Min(ReadBufferSize, BackupService.MaxImportFileBytes - content.Length + 1);
                int read = await source.ReadAtLeastAsync(buffer.AsMemory(0, requested), requested, throwOnEndOfStream: false, cancellationToken)
                    .ConfigureAwait(false);
                if (content.Length + read > BackupService.MaxImportFileBytes)
                {
                    throw TooLarge();
                }

                content.Write(buffer, 0, read);
                if (read < requested)
                {
                    break;
                }
            }
        }
        finally
        {
            // The scratch buffer can contain journal and chat text.
            ArrayPool<byte>.Shared.Return(buffer, clearArray: true);
        }

        cancellationToken.ThrowIfCancellationRequested();
        return Decode(content);
    }

    private static string Decode(MemoryStream content)
    {
        ReadOnlySpan<byte> utf8 = content.GetBuffer().AsSpan(0, (int)content.Length);
        if (utf8.StartsWith(Encoding.UTF8.Preamble))
        {
            utf8 = utf8[Encoding.UTF8.Preamble.Length..];
        }

        try
        {
            return StrictUtf8.GetString(utf8);
        }
        catch (DecoderFallbackException ex)
        {
            throw new BackupFormatException("The backup file is not valid UTF-8.", ex);
        }
    }

    private static BackupFormatException TooLarge() => new("The file is too large to be a backup.");
}
