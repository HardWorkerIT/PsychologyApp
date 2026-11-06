using System.Text.Json;

namespace PsychologyApp.Infrastructure.Data.Repositories.Quots;

internal static class FavoriteQuoteTextsCodec
{
    private const string SerializedTextsPrefix = "json:v1:";

    public static HashSet<string> Decode(string? value)
    {
        HashSet<string> texts = new(StringComparer.Ordinal);
        if (string.IsNullOrWhiteSpace(value))
        {
            return texts;
        }

        if (value.StartsWith(SerializedTextsPrefix, StringComparison.Ordinal))
        {
            try
            {
                string[]? savedTexts = JsonSerializer.Deserialize<string[]>(value[SerializedTextsPrefix.Length..]);
                if (savedTexts is not null)
                {
                    return savedTexts
                        .Where(text => !string.IsNullOrWhiteSpace(text))
                        .ToHashSet(StringComparer.Ordinal);
                }
            }
            catch (JsonException)
            {
                // Keep the legacy parser as a fallback for damaged or pre-JSON values.
            }
        }

        foreach (string part in value.Split('\n', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries))
        {
            texts.Add(part);
        }

        return texts;
    }

    public static string Encode(IEnumerable<string> texts) => SerializedTextsPrefix
        + JsonSerializer.Serialize(texts
            .Where(text => !string.IsNullOrWhiteSpace(text))
            .Distinct(StringComparer.Ordinal)
            .OrderBy(text => text, StringComparer.Ordinal)
            .ToArray());
}
