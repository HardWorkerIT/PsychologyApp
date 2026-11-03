using Microsoft.Maui.ApplicationModel.DataTransfer;
using Microsoft.Maui.Storage;
using PsychologyApp.Application.Models;
using PsychologyApp.Presentation.Features.ManageJournal;
using Xunit;

namespace PsychologyApp.Presentation.Tests;

[Collection("StaticShims")]
public sealed class JournalCsvExporterTests
{
    [Theory]
    [InlineData("=1+1")]
    [InlineData("  =1+1")]
    [InlineData("\t=1+1")]
    [InlineData("+SUM(A1:A2)")]
    [InlineData("-1+2")]
    [InlineData("@SUM(A1:A2)")]
    [InlineData("=HYPERLINK(\"https://example.invalid\",\"open\")")]
    public void BuildCsv_PrefixesSpreadsheetFormulasInUserNotes(string note)
    {
        string csv = JournalCsvExporter.BuildCsv([new MoodEntryDTO
        {
            MoodLevel = 3,
            Note = note,
            RecordedAt = DateTime.UtcNow
        }]);

        string normalized = note.TrimStart().Replace("\"", "\"\"", StringComparison.Ordinal);
        Assert.Contains("'" + normalized, csv, StringComparison.Ordinal);
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task Sharing_removes_the_temporary_file_containing_private_notes(bool shareFails)
    {
        string directory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        string previous = FileSystem.CacheDirectory;
        FileSystem.CacheDirectory = directory;
        Share.FileShareError = shareFails ? new IOException("Share unavailable") : null;
        try
        {
            Task sharing = JournalCsvExporter.ShareAsync([new MoodEntryDTO
            {
                MoodLevel = 3, Note = "private journal note", RecordedAt = DateTime.UtcNow
            }]);
            if (shareFails)
            {
                await Assert.ThrowsAsync<IOException>(() => sharing);
            }
            else
            {
                await sharing;
                Assert.Contains("private journal note", Share.Shared[^1].Content);
            }
            Assert.Empty(Directory.EnumerateFiles(directory));
        }
        finally
        {
            FileSystem.CacheDirectory = previous;
            Share.FileShareError = null;
            Directory.Delete(directory, recursive: true);
        }
    }

    [Fact]
    public async Task Sharing_does_not_open_the_share_sheet_when_cancelled_before_publish()
    {
        string directory = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(directory);
        string previous = FileSystem.CacheDirectory;
        FileSystem.CacheDirectory = directory;
        int previousShareCount = Share.Shared.Count;
        using CancellationTokenSource cancellation = new();
        cancellation.Cancel();

        try
        {
            await Assert.ThrowsAnyAsync<OperationCanceledException>(() => JournalCsvExporter.ShareAsync(
                [new MoodEntryDTO { MoodLevel = 3, Note = "private journal note", RecordedAt = DateTime.UtcNow }],
                cancellation.Token));

            Assert.Equal(previousShareCount, Share.Shared.Count);
            Assert.Empty(Directory.EnumerateFiles(directory));
        }
        finally
        {
            FileSystem.CacheDirectory = previous;
            Directory.Delete(directory, recursive: true);
        }
    }
}
