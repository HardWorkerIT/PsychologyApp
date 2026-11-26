using System.Globalization;
using System.Text;
using PsychologyApp.Application.Models;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;

namespace PsychologyApp.Presentation.Features.ManageJournal;

public static class JournalCsvExporter
{
    public static string BuildCsv(IEnumerable<MoodEntryDTO> entries)
    {
        StringBuilder builder = new();
        builder.AppendLine("Date,Time,Mood,Factors,Note");
        foreach (MoodEntryDTO entry in entries.OrderBy(item => item.RecordedAt))
        {
            DateTime local = entry.RecordedAt.ToLocalTime();
            string factors = string.Join(
                ';',
                JournalNoteFactors.ExtractActiveLabels(entry.Note));
            string note = JournalNoteFactors.StripFactorLines(entry.Note);
            builder.Append(Csv(local.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture))).Append(',');
            builder.Append(Csv(local.ToString("HH:mm", CultureInfo.InvariantCulture))).Append(',');
            builder.Append(entry.MoodLevel.ToString(CultureInfo.InvariantCulture)).Append(',');
            builder.Append(Csv(factors)).Append(',');
            builder.Append(Csv(note));
            builder.AppendLine();
        }

        return builder.ToString();
    }

    public static Task ShareAsync(
        IReadOnlyList<MoodEntryDTO> entries,
        CancellationToken cancellationToken = default)
    {
        string fileName = SharedFileNames.JournalExport(DateTime.Now);
        return SharedExportFile.ShareAsync(fileName, BuildCsv(entries), AppStrings.JournalExportTitle, cancellationToken);
    }

    private static string Csv(string? value)
    {
        string text = value ?? string.Empty;
        int firstMeaningfulCharacter = 0;
        while (firstMeaningfulCharacter < text.Length
            && (char.IsWhiteSpace(text[firstMeaningfulCharacter]) || char.IsControl(text[firstMeaningfulCharacter])))
        {
            firstMeaningfulCharacter++;
        }

        // Notes and factor labels are user supplied. Prefix spreadsheet formulas with an apostrophe so a shared CSV
        // cannot execute them when opened in Excel or another spreadsheet application.
        if (firstMeaningfulCharacter < text.Length
            && text[firstMeaningfulCharacter] is '=' or '+' or '-' or '@')
        {
            text = "'" + text;
        }

        if (text.Contains('"') || text.Contains(',') || text.Contains('\n') || text.Contains('\r'))
        {
            return $"\"{text.Replace("\"", "\"\"", StringComparison.Ordinal)}\"";
        }

        return text;
    }
}
