using System.Text;
using System.Text.RegularExpressions;
using PsychologyApp.Application.Conversation.Companion;

namespace PsychologyApp.Application.Chat;

/// <summary>
/// Picks the sentence that carries the feeling so the companion can quote it back verbatim. Quoting avoids the grammar
/// mistakes of rephrasing Russian ("Я устал" -> "Вы устали") and shows the person that their own words were heard.
/// </summary>
public static partial class QuoteExtractor
{
    private const int MinLength = 8;

    [GeneratedRegex(@"(?<=[.!?…][""'’”»)\]])\s+|(?<=[.!?…])\s+|(?<=[。！？][""'’”»」』）)\]])|(?<=[。！？])|\n+", RegexOptions.CultureInvariant)]
    private static partial Regex SentenceSplit();

    public static string? Pick(string text, ISituationAnalyzer analyzer, CompanionEmotion emotion, int maxLength = 110)
    {
        List<string> sentences = SentenceSplit().Split(text)
            .Select(s => s.Trim().TrimEnd('.', '!', '?', '…', '。', '！', '？', ' '))
            .Where(s => s.Length >= MinLength)
            .ToList();
        if (sentences.Count == 0)
        {
            return null;
        }

        string? latestMatching = null;
        string? latestRecognized = null;
        string longest = sentences[0];
        foreach (string sentence in sentences)
        {
            if (sentence.Length > longest.Length)
            {
                longest = sentence;
            }

            CompanionEmotion sentenceEmotion = analyzer.Analyze(sentence).Emotion;
            if (emotion != CompanionEmotion.Unknown && sentenceEmotion == emotion)
            {
                latestMatching = sentence;
            }

            if (sentenceEmotion != CompanionEmotion.Unknown)
            {
                latestRecognized = sentence;
            }
        }

        string chosen = (emotion == CompanionEmotion.Unknown ? null : latestMatching) ?? latestRecognized ?? longest;
        return Truncate(chosen, maxLength);
    }

    private static string? Truncate(string sentence, int maxLength)
    {
        if (sentence.Length <= maxLength)
        {
            return sentence;
        }

        if (maxLength < MinLength)
        {
            return null;
        }

        int cut = sentence.LastIndexOf(' ', maxLength);
        if (cut < MinLength)
        {
            cut = maxLength;
            if (char.IsHighSurrogate(sentence[cut - 1]) && char.IsLowSurrogate(sentence[cut]))
            {
                cut--;
            }

            if (!ContainsCjk(sentence[..cut]))
            {
                return null;
            }

            // CJK text normally has no spaces between words; cut at a Unicode scalar boundary instead.
        }

        string excerpt = sentence[..cut].TrimEnd(',', ';', ':', ' ', '，', '；', '：', '、', '　');
        return excerpt.Length >= MinLength ? excerpt + "…" : null;
    }

    private static bool ContainsCjk(string text) => text.EnumerateRunes().Any(rune =>
        rune.Value is >= 0x2E80 and <= 0x9FFF
            or >= 0xAC00 and <= 0xD7AF
            or >= 0xF900 and <= 0xFAFF
            or >= 0x20000 and <= 0x323AF);
}
