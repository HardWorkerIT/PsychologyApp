using System.Globalization;

namespace PsychologyApp.Presentation.Common;

/// <summary>
/// The names of the files the app writes to its cache to share them (an exported journal, a backup, a summary for a specialist,
/// the error log). They hold the person's records, so "delete all my data" removes them by these names: one place decides both,
/// and a file renamed here is still found by the eraser.
/// </summary>
public static class SharedFileNames
{
    private const string JournalPrefix = "journal-";
    private const string AppPrefix = "psychologyapp-";
    private const string SummaryPrefix = "specialist-summary-";
    // MAUI Essentials 11.0.10 stages Android picker copies in this cache folder, under a unique directory per file.
    private const string MauiPickerFolder = "2203693cc04e0be7f4f024d5f9499e13";

    public static string JournalExport(DateTime localNow) => $"{JournalPrefix}{Stamp(localNow)}.csv";

    public static string Backup(bool passphraseProtected, DateTime localNow) =>
        $"{AppPrefix}backup{(passphraseProtected ? "-protected" : string.Empty)}-{Stamp(localNow)}.json";

    public static string SpecialistSummary(DateTime localNow) => $"{SummaryPrefix}{Stamp(localNow)}.txt";

    public static string ErrorLog(DateTime localNow) => $"{AppPrefix}errors-{Stamp(localNow)}.log";

    public static bool IsMauiPickerCopy(string cacheDirectory, string path)
    {
        if (!Path.IsPathFullyQualified(path) || Path.GetDirectoryName(path) is not string stagingDirectory)
        {
            return false;
        }

        string expectedRoot = Path.Combine(cacheDirectory, MauiPickerFolder);
        return string.Equals(Path.GetDirectoryName(stagingDirectory), expectedRoot, StringComparison.Ordinal)
            && Guid.TryParseExact(Path.GetFileName(stagingDirectory), "N", out _);
    }

    /// <summary>
    /// Includes the temporary files left when an atomic export is interrupted by process termination.
    /// </summary>
    public static bool IsOwn(string fileName)
    {
        ReadOnlySpan<char> name = fileName.AsSpan();
        if (!name.IsEmpty && name[0] == '.' && name.EndsWith(".tmp", StringComparison.OrdinalIgnoreCase))
        {
            // AtomicFileWriter stages exports as .{originalName}.{guid:N}.tmp.
            const int guidLength = 32;
            int separator = name.Length - ".tmp".Length - guidLength - 1;
            return separator > 1 && name[separator] == '.'
                && Guid.TryParseExact(name.Slice(separator + 1, guidLength), "N", out _)
                && HasSharedPrefix(name[1..separator]);
        }

        return HasSharedPrefix(name);
    }

    private static bool HasSharedPrefix(ReadOnlySpan<char> fileName) =>
        fileName.StartsWith(JournalPrefix, StringComparison.OrdinalIgnoreCase)
        || fileName.StartsWith(AppPrefix, StringComparison.OrdinalIgnoreCase)
        || fileName.StartsWith(SummaryPrefix, StringComparison.OrdinalIgnoreCase);

    private static string Stamp(DateTime localNow) => localNow.ToString("yyyyMMdd-HHmm", CultureInfo.InvariantCulture);
}
