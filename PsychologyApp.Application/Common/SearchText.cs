namespace PsychologyApp.Application.Common;

/// <summary>
/// Forgiving text search for a Russian-language catalogue: case-insensitive, "ё" is "е", and a word matches its other forms
/// ("тревога" finds "тревоги", "тревогу", "тревожный" does not, but "тревож" does). Every word of the query must be found.
/// Not a morphology engine: each query word is cut by its likely ending, so short words are matched exactly as typed.
/// </summary>
public static class SearchText
{
    private const int StackBufferLimit = 256;
    private static readonly char[] Separators = [' ', ',', '.', ';', ':', '!', '?', '-', '—', '"', '«', '»', '(', ')'];

    public static string Normalize(string? text) =>
        string.IsNullOrEmpty(text) ? string.Empty : text.ToLowerInvariant().Replace('ё', 'е');

    /// <summary>The parts of the query that must all occur in the text.</summary>
    public static IReadOnlyList<string> Stems(string query)
    {
        string[] words = Normalize(query).Split(Separators, StringSplitOptions.RemoveEmptyEntries);
        for (int i = 0; i < words.Length; i++)
        {
            words[i] = Stem(words[i]);
        }

        return words;
    }

    public static bool Matches(string? text, IReadOnlyList<string> stems)
    {
        if (stems.Count == 0 || string.IsNullOrEmpty(text))
        {
            return false;
        }

        if (text.Length > StackBufferLimit)
        {
            return ContainsAll(Normalize(text), stems);
        }

        Span<char> normalized = stackalloc char[text.Length];
        text.AsSpan().ToLowerInvariant(normalized);
        normalized.Replace('ё', 'е');
        return ContainsAll(normalized, stems);
    }

    private static bool ContainsAll(ReadOnlySpan<char> text, IReadOnlyList<string> stems)
    {
        for (int i = 0; i < stems.Count; i++)
        {
            if (!text.Contains(stems[i], StringComparison.Ordinal))
            {
                return false;
            }
        }

        return true;
    }

    private static string Stem(string word) => word.Length switch
    {
        >= 7 => word[..^2],
        >= 5 => word[..^1],
        _ => word
    };
}
