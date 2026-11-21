namespace PsychologyApp.Application.Articles;

/// <summary>
/// The articles of the app in every language, matched one to one with English (tested). Clinical health copy needs review by
/// a psychologist (and a physician for the “when to see a doctor” lists) before release.
/// </summary>
public static partial class ArticleContent
{
    /// <summary>The articles in a language by its key ("ru", "en", "fr"…); a language without its own gets the English ones.</summary>
    public static IReadOnlyList<Article> All(string? language) => InLanguage(
        language,
        ExpandedCatalogs.Russian,
        ExpandedCatalogs.English,
        ExpandedCatalogs.French,
        ExpandedCatalogs.German,
        ExpandedCatalogs.Spanish,
        ExpandedCatalogs.Portuguese,
        ExpandedCatalogs.Chinese);

    public static Article? Find(string id, string? language) => All(language).FirstOrDefault(article => article.Id == id);

    private static T InLanguage<T>(string? language, T russian, T english, T french, T german, T spanish, T portuguese, T chinese) =>
        language?.ToLowerInvariant() switch
        {
            "ru" => russian,
            "fr" => french,
            "de" => german,
            "es" => spanish,
            "pt" => portuguese,
            "zh" => chinese,
            _ => english
        };

    // Keep a stable catalog instance per language: search indexes and unknown-language fallback both rely on it.
    private static class ExpandedCatalogs
    {
        internal static readonly IReadOnlyList<Article> Russian = [.. ArticlesRu, .. AdditionalArticlesRu];
        internal static readonly IReadOnlyList<Article> English = [.. ArticlesEn, .. AdditionalArticlesEn];
        internal static readonly IReadOnlyList<Article> French = [.. ArticlesFr, .. AdditionalArticlesFr];
        internal static readonly IReadOnlyList<Article> German = [.. ArticlesDe, .. AdditionalArticlesDe];
        internal static readonly IReadOnlyList<Article> Spanish = [.. ArticlesEs, .. AdditionalArticlesEs];
        internal static readonly IReadOnlyList<Article> Portuguese = [.. ArticlesPt, .. AdditionalArticlesPt];
        internal static readonly IReadOnlyList<Article> Chinese = [.. ArticlesZh, .. AdditionalArticlesZh];
    }

    private static Article MiniArticle(string id, string title, string summary, string text) =>
        new(id, title, summary, "TipsAndUpdates", 2, [P(text)]);

    private static ArticleBlock P(string text) => new(ArticleBlockKind.Paragraph, text);

    private static ArticleBlock H(string text) => new(ArticleBlockKind.Heading, text);

    private static ArticleBlock Warning(string text) => new(ArticleBlockKind.Warning, text);

    private static ArticleBlock List(params string[] items) => new(ArticleBlockKind.Bullets, Items: items);

    private static ArticleBlock Practice(Domain.Practice.TechniqueId technique, string title) => new(ArticleBlockKind.Practice, title, Technique: technique);

    private static ArticleBlock Ladder(string title) => new(ArticleBlockKind.FearLadder, title);

    private static ArticleBlock Crisis(string title) => new(ArticleBlockKind.CrisisHelp, title);

    private static ArticleBlock TestsTab(string text, string testId) => new(ArticleBlockKind.Tests, text, TestId: testId);

    private static ArticleBlock See(string articleId, string title) => new(ArticleBlockKind.Article, title, ArticleId: articleId);

    private static ArticleBlock Check(string title, int threshold, string verdict, string verdictLow, params string[] items) =>
        new(ArticleBlockKind.Checklist, title, items, Threshold: threshold, Verdict: verdict, VerdictLow: verdictLow);

    private static ArticleBlock Quiz(string question, int correct, string explanation, params string[] options) =>
        new(ArticleBlockKind.Quiz, question, options, Correct: correct, Explanation: explanation);

    private static ArticleBlock Breathe(string caption) => new(ArticleBlockKind.Breathe, caption);

    private static ArticleBlock Cycle(string caption, params string[] steps) => new(ArticleBlockKind.Cycle, caption, steps);

    private static ArticleBlock TraumaChat(string title) => new(ArticleBlockKind.TraumaChat, title);
}

/// <summary>What is read aloud: the text a person reads, in order, without the links and buttons around it.</summary>
public static class ArticleSpeech
{
    public static IReadOnlyList<string> Parts(string title, IEnumerable<ArticleBlock> blocks)
    {
        List<string> parts = [title];
        foreach (ArticleBlock block in blocks)
        {
            switch (block.Kind)
            {
                case ArticleBlockKind.Paragraph or ArticleBlockKind.Heading or ArticleBlockKind.Warning or ArticleBlockKind.Task or ArticleBlockKind.Breathe:
                    parts.Add(block.Text);
                    break;
                case ArticleBlockKind.Bullets or ArticleBlockKind.Checklist or ArticleBlockKind.Quiz or ArticleBlockKind.Cycle:
                    if (block.Kind != ArticleBlockKind.Bullets)
                    {
                        parts.Add(block.Text);
                    }

                    parts.AddRange(block.Items ?? []);
                    break;
            }
        }

        return parts.Where(part => !string.IsNullOrWhiteSpace(part)).ToList();
    }
}

/// <summary>Search over the articles on the device: every word of the query must be found; title matches come first.</summary>
public static class ArticleSearch
{
    public const int MinQueryLength = 2;
    private static readonly System.Collections.Concurrent.ConcurrentDictionary<string, SearchEntry[]> SearchIndex = new(StringComparer.Ordinal);

    public static IReadOnlyList<Article> Find(string? query, string? language)
    {
        string[] words = Normalize(query).Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (words.Sum(word => word.Length) < MinQueryLength)
        {
            return [];
        }

        string languageKey = NormalizeLanguage(language);
        return SearchIndex.GetOrAdd(languageKey, BuildSearchIndex)
            .Where(entry => words.All(word => entry.Head.Contains(word, StringComparison.Ordinal) || entry.Body.Contains(word, StringComparison.Ordinal)))
            .OrderByDescending(entry => words.Count(word => entry.Title.Contains(word, StringComparison.Ordinal)))
            .ThenByDescending(entry => words.Count(word => entry.Head.Contains(word, StringComparison.Ordinal)))
            .Select(entry => entry.Article)
            .ToList();
    }

    private static SearchEntry[] BuildSearchIndex(string language) =>
        ArticleContent.All(language)
            .Select(article => new SearchEntry(
                article,
                Normalize(article.Title),
                Normalize($"{article.Title} {article.Summary}"),
                Normalize(BodyText(article))))
            .ToArray();

    private static string NormalizeLanguage(string? language) => language?.ToLowerInvariant() switch
    {
        "ru" => "ru",
        "fr" => "fr",
        "de" => "de",
        "es" => "es",
        "pt" => "pt",
        "zh" => "zh",
        _ => "en"
    };

    private static string BodyText(Article article) =>
        string.Join(' ', article.Blocks.SelectMany(block => (block.Items ?? []).Prepend(block.Text)));

    private static string Normalize(string? text) =>
        string.Join(' ', new string((text ?? string.Empty).ToLowerInvariant().Replace('ё', 'е')
            .Select(c => char.IsLetterOrDigit(c) ? c : ' ').ToArray())
            .Split(' ', StringSplitOptions.RemoveEmptyEntries));

    private sealed record SearchEntry(Article Article, string Title, string Head, string Body);
}
