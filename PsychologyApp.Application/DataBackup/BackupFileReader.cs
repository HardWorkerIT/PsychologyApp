using System.Text;

namespace PsychologyApp.Application.DataBackup;

public static class BackupFileReader
{
    private static readonly UTF8Encoding StrictUtf8 = new(false, throwOnInvalidBytes: true);

    public static async Task<string> ReadAsync(Stream source, CancellationToken cancellationToken)
    {
        if (source.CanSeek && source.Length > BackupService.MaxImportFileBytes)
        {
            throw TooLarge();
        }

        using MemoryStream content = new();
        byte[] buffer = new byte[64 * 1024];
        while (true)
        {
            // A picker stream can be non-seekable. Read at most one byte past the limit to detect overflow.
            int requested = (int)Math.Min(buffer.Length, BackupService.MaxImportFileBytes - content.Length + 1);
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
