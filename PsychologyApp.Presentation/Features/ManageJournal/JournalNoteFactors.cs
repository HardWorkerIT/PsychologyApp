using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Features.ManageJournal;

/// <summary>
/// Activity/factor lines in journal notes use stable prefixes so toggles can add/remove without duplicates.
/// </summary>
public static class JournalNoteFactors
{
    public const string SleepKey = "sleep";
    public const string PeopleKey = "people";
    public const string PracticeKey = "practice";
    public const string WalkKey = "walk";
    public const string WorkKey = "work";
    public const string SportKey = "sport";
    public const string RestKey = "rest";
    public const string StressKey = "stress";
    public const string HomeKey = "home";

    public static readonly string[] AllKeys =
    [
        SleepKey,
        PeopleKey,
        PracticeKey,
        WalkKey,
        WorkKey,
        SportKey,
        RestKey,
        StressKey,
        HomeKey
    ];

    /// <summary>Hub ritual shows a short primary set; full set remains for Overview/share.</summary>
    public static readonly string[] PrimaryKeys =
    [
        SleepKey,
        PeopleKey,
        PracticeKey,
        WalkKey,
        SportKey,
        RestKey
    ];

    public static string GetPrefix(string key) => key switch
    {
        SleepKey => AppStrings.JournalFactorSleep,
        PeopleKey => AppStrings.JournalFactorPeople,
        PracticeKey => AppStrings.JournalFactorPractice,
        WalkKey => AppStrings.JournalFactorWalk,
        WorkKey => AppStrings.JournalFactorWork,
        SportKey => AppStrings.JournalFactorSport,
        RestKey => AppStrings.JournalFactorRest,
        StressKey => AppStrings.JournalFactorStress,
        HomeKey => AppStrings.JournalFactorHome,
        _ => string.Empty
    };

    public static string GetLabel(string key) => key switch
    {
        SleepKey => AppStrings.JournalFactorSleepLabel,
        PeopleKey => AppStrings.JournalFactorPeopleLabel,
        PracticeKey => AppStrings.JournalFactorPracticeLabel,
        WalkKey => AppStrings.JournalFactorWalkLabel,
        WorkKey => AppStrings.JournalFactorWorkLabel,
        SportKey => AppStrings.JournalFactorSportLabel,
        RestKey => AppStrings.JournalFactorRestLabel,
        StressKey => AppStrings.JournalFactorStressLabel,
        HomeKey => AppStrings.JournalFactorHomeLabel,
        _ => string.Empty
    };

    public static bool HasFactor(string? note, string key)
    {
        string prefix = GetPrefix(key);
        if (string.IsNullOrEmpty(prefix) || string.IsNullOrWhiteSpace(note))
        {
            return false;
        }

        return ContainsFactorLine(note.AsSpan(), prefix.AsSpan().TrimEnd());
    }

    private static bool ContainsFactorLine(ReadOnlySpan<char> note, ReadOnlySpan<char> prefix)
    {
        foreach (Range line in note.SplitAny("\r\n"))
        {
            if (note[line].Trim().StartsWith(prefix, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }
        }

        return false;
    }

    public static string ToggleFactor(string? note, string key)
    {
        string prefix = GetPrefix(key);
        if (string.IsNullOrEmpty(prefix))
        {
            return note?.Trim() ?? string.Empty;
        }

        List<string> lines = string.IsNullOrWhiteSpace(note)
            ? []
            : note.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
                .ToList();

        if (!lines.Any(line => IsFactorLine(line, prefix)))
        {
            lines.Add(prefix);
            return string.Join(Environment.NewLine, lines);
        }

        // Every line of this factor loses its label, which also heals notes that the old matching saved with duplicate bare lines.
        return string.Join(Environment.NewLine, WithoutLabels(lines, [prefix]));
    }

    public static IReadOnlyList<string> ExtractActiveLabels(string? note)
    {
        List<string> labels = [];
        foreach (string key in AllKeys)
        {
            if (HasFactor(note, key))
            {
                labels.Add(GetLabel(key));
            }
        }

        return labels;
    }

    public static string StripFactorLines(string? note)
    {
        if (string.IsNullOrWhiteSpace(note))
        {
            return string.Empty;
        }

        string[] prefixes = AllKeys
            .Select(GetPrefix)
            .Where(prefix => !string.IsNullOrEmpty(prefix))
            .ToArray();

        string[] lines = note.Split(['\r', '\n'], StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
        return string.Join(Environment.NewLine, WithoutLabels(lines, prefixes));
    }

    /// <summary>
    /// Takes the factor labels off the lines and keeps what the person wrote after them ("Сон: woke up three times" becomes
    /// "woke up three times"); a line with nothing but the label goes. The person's words are never dropped: this text is shown
    /// in the journal and exported to CSV.
    /// </summary>
    private static IEnumerable<string> WithoutLabels(IEnumerable<string> lines, IReadOnlyCollection<string> prefixes)
    {
        foreach (string line in lines)
        {
            string? prefix = prefixes.FirstOrDefault(candidate => IsFactorLine(line, candidate));
            string words = prefix is null ? line : line[prefix.TrimEnd().Length..].Trim();
            if (words.Length > 0)
            {
                yield return words;
            }
        }
    }

    // Prefixes end with a space ("Сон: ") but note lines are trimmed, so a bare factor line reads "Сон:".
    private static bool IsFactorLine(string line, string prefix) =>
        line.StartsWith(prefix.TrimEnd(), StringComparison.OrdinalIgnoreCase);

    public static string FormatDisplayNote(string? note)
    {
        string body = StripFactorLines(note);
        IReadOnlyList<string> labels = ExtractActiveLabels(note);
        if (labels.Count == 0)
        {
            return body;
        }

        string factorsLine = AppStrings.JournalFactorsSummaryLine(string.Join(", ", labels));
        return string.IsNullOrWhiteSpace(body)
            ? factorsLine
            : $"{body}{Environment.NewLine}{factorsLine}";
    }

    public static IReadOnlyList<JournalActivityInsight> Analyze(
        IEnumerable<(string? Note, int MoodLevel)> entries)
    {
        string[] prefixes = AllKeys.Select(key => GetPrefix(key).TrimEnd()).ToArray();
        Span<int> counts = stackalloc int[prefixes.Length];
        Span<long> totals = stackalloc long[prefixes.Length];
        counts.Clear();
        totals.Clear();
        foreach ((string? note, int moodLevel) in entries)
        {
            if (string.IsNullOrWhiteSpace(note))
            {
                continue;
            }

            for (int index = 0; index < prefixes.Length; index++)
            {
                string prefix = prefixes[index];
                if (prefix.Length != 0 && ContainsFactorLine(note.AsSpan(), prefix.AsSpan()))
                {
                    counts[index]++;
                    totals[index] += moodLevel;
                }
            }
        }

        List<JournalActivityInsight> insights = [];
        for (int index = 0; index < AllKeys.Length; index++)
        {
            int count = counts[index];
            if (count == 0)
            {
                continue;
            }

            string key = AllKeys[index];
            string? average = count >= 2
                ? AppStrings.FormatAverageMood((double)totals[index] / count)
                : null;
            insights.Add(new JournalActivityInsight(
                key,
                GetLabel(key),
                count,
                average));
        }

        return insights;
    }
}

public sealed record JournalActivityInsight(
    string Key,
    string Label,
    int Count,
    string? AverageMoodDisplay)
{
    public string DisplayPill => AverageMoodDisplay is null
        ? AppStrings.JournalFactorCountPill(Label, Count)
        : AppStrings.JournalActivityCorrelationPill(Label, Count, AverageMoodDisplay);
}
