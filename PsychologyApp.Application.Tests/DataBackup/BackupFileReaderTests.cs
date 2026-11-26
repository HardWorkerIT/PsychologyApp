using System.Text;
using PsychologyApp.Application.DataBackup;
using Xunit;

namespace PsychologyApp.Application.Tests.DataBackup;

public sealed class BackupFileReaderTests
{
    [Fact]
    public async Task Reads_remaining_utf8_and_skips_its_byte_order_mark()
    {
        const string json = "{\"note\":\"Запись из дневника\"}";
        byte[] bytes = [0xFF, .. Encoding.UTF8.GetPreamble(), .. Encoding.UTF8.GetBytes(json)];
        using MemoryStream stream = new(bytes);
        stream.Position = 1;

        Assert.Equal(json, await BackupFileReader.ReadAsync(stream, default));
    }

    [Fact]
    public async Task Rejects_invalid_utf8_even_when_the_picker_cannot_report_length()
    {
        using NonSeekableStream stream = new([0xC3, 0x28]);

        await Assert.ThrowsAsync<BackupFormatException>(() => BackupFileReader.ReadAsync(stream, default));
    }

    private sealed class NonSeekableStream(byte[] bytes) : MemoryStream(bytes)
    {
        public override bool CanSeek => false;
        public override long Length => throw new NotSupportedException();
    }
}
