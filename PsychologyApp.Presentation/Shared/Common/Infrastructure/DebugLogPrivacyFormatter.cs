using Microsoft.Extensions.Logging;

namespace PsychologyApp.Presentation.Shared.Common.Infrastructure;

internal static class DebugLogPrivacyFormatter
{
    internal static string Format<TState>(
        string categoryName,
        LogLevel logLevel,
        EventId eventId,
        TState state,
        Exception? exception)
    {
        string messageTemplate = state is IReadOnlyList<KeyValuePair<string, object?>> values
            ? values.FirstOrDefault(static value => value.Key == "{OriginalFormat}").Value as string ?? $"Event {eventId.Id}"
            : eventId.Name ?? $"Event {eventId.Id}";
        string line = $"[{DateTimeOffset.Now:yyyy-MM-dd HH:mm:ss.fff}] {logLevel} {categoryName}: {messageTemplate}";

        // Rendered values and exception messages can contain a person's text; keep only the template and exception type.
        if (exception is not null)
        {
            line += $" [{exception.GetType().Name}]";
        }

        return line;
    }
}
