using Microsoft.Extensions.Logging;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using Xunit;

namespace PsychologyApp.Presentation.Tests;

public sealed class DebugLogPrivacyFormatterTests
{
    [Fact]
    public void Format_ExcludesStructuredValuesAndExceptionMessages()
    {
        const string privateText = "private journal text should never appear in logs";
        KeyValuePair<string, object?>[] state =
        [
            new("UserText", privateText),
            new("{OriginalFormat}", "Operation failed for {UserText}")
        ];

        string line = DebugLogPrivacyFormatter.Format(
            "PrivacyTest",
            LogLevel.Error,
            new EventId(42),
            state,
            new InvalidOperationException(privateText));

        Assert.Contains("Operation failed for {UserText}", line, StringComparison.Ordinal);
        Assert.Contains(nameof(InvalidOperationException), line, StringComparison.Ordinal);
        Assert.DoesNotContain(privateText, line, StringComparison.Ordinal);
    }
}
