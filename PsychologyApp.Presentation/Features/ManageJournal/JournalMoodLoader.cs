using PsychologyApp.Application.Conversation;
using PsychologyApp.Application.Models;
using PsychologyApp.Application.UserProgress;
using PsychologyApp.Domain.UserProgress;
using PsychologyApp.Presentation.Core.Charts;
using PsychologyApp.Presentation.Entities.Journal;
using PsychologyApp.Presentation.Entities.Profile;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Features.ManageJournal;

public sealed record JournalMoodStats(
    int CheckInCount,
    string AverageMoodDisplay,
    string CheckInDaysDisplay,
    string MoodTrendLabel,
    string BestWorstLabel,
    bool HasStats);

public sealed record JournalMoodSnapshot(
    IReadOnlyList<MoodChartPoint> ChartPoints,
    bool HasTrendChart,
    string ChartSubtitle,
    IReadOnlyList<MoodNoteItem> TimelineEntries,
    IReadOnlyList<JournalTimelineDayGroup> TimelineGroups,
    IReadOnlyList<JournalDayChip> WeekDays,
    IReadOnlyList<JournalMonthCell> MonthCells,
    DateOnly MonthCursor,
    string MonthTitle,
    IReadOnlyList<JournalYearCell> YearCells,
    int YearCursor,
    string YearTitle,
    JournalCalendarScale CalendarScale,
    long? EditorEntryId,
    DateOnly EditorDay,
    JournalCheckInSlot EditorSlot,
    bool HasMorningEntry,
    bool HasEveningEntry,
    string? EditorNote,
    bool EditorNoteLooksLikeCrisis,
    int SelectedMoodLevel,
    string EditorMoodDisplay,
    string MoodHistorySummary,
    string RangeSubtitle,
    JournalMoodStats Stats,
    string PracticeMoodInsight,
    string OnThisDayLastYearText,
    DateOnly WeekStripEnd,
    IReadOnlyList<JournalActivityInsight> ActivityInsights,
    IReadOnlyList<TrendAnnotation> PracticeMarks,
    bool HasEarlierEntries,
    JournalSlotPreview? Morning,
    JournalSlotPreview? Evening);

/// <summary>A check-in of the editor's day as its morning or evening row shows it: the mood and the note as the history shows it.</summary>
public sealed record JournalSlotPreview(int MoodLevel, string? Note);

/// <summary>The persisted row id is needed by the next autosave so it updates this check-in instead of inserting a duplicate.</summary>

public sealed class JournalMoodLoader(IUserProgressService userProgressService, ICrisisDetector crisisDetector)
{
    private const int TimelineLimit = 500;
    private const int MaxWeekLookbackDays = 84;
    private const int MaxMonthLookbackMonths = 12;
    private const int MaxYearLookbackYears = 2;

    // Off the UI thread: building the snapshot after each query would otherwise run there.
    public Task<JournalMoodSnapshot> LoadAsync(
        int rangeDays = 7,
        DateOnly? filterDay = null,
        DateOnly? editorDay = null,
        DateOnly? weekStripEnd = null,
        DateOnly? monthCursor = null,
        int? yearCursor = null,
        JournalCheckInSlot editorSlot = JournalCheckInSlot.Morning,
        JournalCalendarScale calendarScale = JournalCalendarScale.Week,
        CancellationToken cancellationToken = default) =>
        Task.Run(() => LoadCoreAsync(rangeDays, filterDay, editorDay, weekStripEnd, monthCursor, yearCursor, editorSlot, calendarScale, cancellationToken), cancellationToken);

    private async Task<JournalMoodSnapshot> LoadCoreAsync(
        int rangeDays = 7,
        DateOnly? filterDay = null,
        DateOnly? editorDay = null,
        DateOnly? weekStripEnd = null,
        DateOnly? monthCursor = null,
        int? yearCursor = null,
        JournalCheckInSlot editorSlot = JournalCheckInSlot.Morning,
        JournalCalendarScale calendarScale = JournalCalendarScale.Week,
        CancellationToken cancellationToken = default)
    {
        int clampedRange = Math.Clamp(rangeDays, 1, 90);
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        DateOnly rangeStart = today.AddDays(-(clampedRange - 1));
        DateOnly resolvedEditorDay = editorDay ?? filterDay ?? today;
        DateOnly stripEnd = ClampStripEnd(weekStripEnd ?? today, today);
        DateOnly stripStart = stripEnd.AddDays(-6);
        DateOnly resolvedMonth = ClampMonth(monthCursor ?? new DateOnly(today.Year, today.Month, 1), today);
        DateOnly monthStart = new(resolvedMonth.Year, resolvedMonth.Month, 1);
        int resolvedYear = ClampYear(yearCursor ?? today.Year, today);
        DateOnly yearStart = new(resolvedYear, 1, 1);
        DateOnly lastYearSameDay = resolvedEditorDay.AddYears(-1);
        DateOnly fetchStart = stripStart < rangeStart ? stripStart : rangeStart;
        if (calendarScale == JournalCalendarScale.Month && monthStart < fetchStart)
        {
            fetchStart = monthStart;
        }

        if (calendarScale == JournalCalendarScale.Year && yearStart < fetchStart)
        {
            fetchStart = yearStart;
        }

        if ((editorDay is not null || filterDay is not null) && lastYearSameDay < fetchStart)
        {
            fetchStart = lastYearSameDay;
        }

        DateTime fromUtc = fetchStart.ToDateTime(TimeOnly.MinValue).ToUniversalTime();
        DateTime toUtcExclusive = today.AddDays(1).ToDateTime(TimeOnly.MinValue).ToUniversalTime();

        IReadOnlyList<MoodEntryDTO> moods =
            await userProgressService.GetMoodsAsync(fromUtc, toUtcExclusive, TimelineLimit, cancellationToken);
        IReadOnlyList<MoodEntryDTO> orderedNewestFirst = moods
            .OrderByDescending(entry => entry.RecordedAt)
            .ToList();

        Dictionary<DateOnly, int> moodLevelByDay = [];
        List<MoodEntryDTO> editorDayEntries = [];
        List<MoodNoteItem> timeline = filterDay is null ? new(orderedNewestFirst.Count) : [];
        List<MoodChartPoint> points = [];
        List<MoodEntryDTO> statsSource = [];
        string noNoteCaption = AppStrings.JournalNoNoteCaption;
        MoodEntryDTO? lastYearEntry = null;
        DateTime chartTimestamp = default;
        int sameTimestampStart = 0;
        int daysWithMood = 0;
        foreach (MoodEntryDTO entry in orderedNewestFirst)
        {
            DateTime local = entry.RecordedAt.ToLocalTime();
            DateOnly day = DateOnly.FromDateTime(local);
            bool inRange = day >= rangeStart && day <= today;
            if (moodLevelByDay.TryAdd(day, entry.MoodLevel) && inRange)
            {
                daysWithMood++;
            }

            if (inRange)
            {
                statsSource.Add(entry);
            }

            if (day == resolvedEditorDay)
            {
                editorDayEntries.Add(entry);
            }

            if (day == lastYearSameDay)
            {
                lastYearEntry ??= entry;
            }

            if (filterDay is not null && day != filterDay)
            {
                continue;
            }

            timeline.Add(ToTimelineItem(entry, local, day, today, noNoteCaption));
            // The wider calendar query does not extend the chart range unless a specific day was selected.
            if (filterDay is null && day < rangeStart)
            {
                continue;
            }

            if (entry.RecordedAt != chartTimestamp)
            {
                // Reverse each tie now so the final reversal keeps the source order for identical timestamps.
                points.Reverse(sameTimestampStart, points.Count - sameTimestampStart);
                sameTimestampStart = points.Count;
                chartTimestamp = entry.RecordedAt;
            }

            points.Add(new MoodChartPoint(local, entry.MoodLevel));
        }

        points.Reverse(sameTimestampStart, points.Count - sameTimestampStart);
        points.Reverse();

        List<JournalTimelineDayGroup> groups = BuildTimelineGroups(timeline);
        DateOnly? selectedCalendarDay = filterDay ?? editorDay;
        List<JournalDayChip> weekDays = calendarScale == JournalCalendarScale.Week
            ? JournalCalendarBuilder.BuildWeekDays(stripEnd, moodLevelByDay, selectedCalendarDay)
            : [];
        List<JournalMonthCell> monthCells = calendarScale == JournalCalendarScale.Month
            ? JournalCalendarBuilder.BuildMonthCells(monthStart, today, moodLevelByDay, selectedCalendarDay)
            : [];
        List<JournalYearCell> yearCells = calendarScale == JournalCalendarScale.Year
            ? JournalCalendarBuilder.BuildYearCells(resolvedYear, today, moodLevelByDay, selectedCalendarDay)
            : [];

        (MoodEntryDTO? morningEntry, MoodEntryDTO? eveningEntry) = SplitDaySlots(editorDayEntries);
        JournalCheckInSlot resolvedSlot = JournalEditorSlotResolver.Resolve(
            editorSlot,
            morningEntry,
            eveningEntry,
            DateTime.Now.Hour);
        MoodEntryDTO? editorEntry = resolvedSlot == JournalCheckInSlot.Morning ? morningEntry : eveningEntry;

        long? editorEntryId = editorEntry?.MoodEntryId;
        string? editorNote = string.IsNullOrWhiteSpace(editorEntry?.Note) ? null : editorEntry!.Note!.Trim();
        int selectedLevel = editorEntry?.MoodLevel ?? 0;
        string editorDisplay = editorEntry is null
            ? (resolvedEditorDay == today ? string.Empty : AppStrings.JournalDayEmptyHint(resolvedEditorDay))
            : resolvedEditorDay == today
                ? AppStrings.TodayMoodLine(editorEntry.MoodLevel, 5)
                : AppStrings.JournalDayMoodLine(resolvedEditorDay, editorEntry.MoodLevel, 5);

        IEnumerable<MoodEntryDTO> summarySource = editorEntry is null
            ? orderedNewestFirst
            : orderedNewestFirst.Where(entry => entry.MoodEntryId != editorEntry.MoodEntryId);
        string[] historyEntries = summarySource
            .Take(2)
            .Select(mood => AppStrings.MoodHistoryEntry(mood.RecordedAt.ToLocalTime().ToString("d"), mood.MoodLevel, 5))
            .ToArray();

        JournalMoodStats stats = BuildStats(statsSource, daysWithMood, clampedRange);

        // A quiet week hides the week's line that leads to the overview; earlier check-ins are then the only reason to offer it.
        bool hasEarlierEntries = stats.HasStats
            || (await userProgressService.GetRecentMoodsAsync(1, cancellationToken))?.Count > 0;
        IReadOnlyList<JournalActivityInsight> activityInsights = JournalNoteFactors.Analyze(
            statsSource.Select(entry => (entry.Note, entry.MoodLevel)));

        (string practiceInsight, IReadOnlyList<TrendAnnotation> practiceMarks) = await BuildPracticeMoodDetailsAsync(
            points,
            rangeStart,
            today,
            moodLevelByDay,
            cancellationToken);

        string onThisDay = BuildOnThisDayLastYear(lastYearEntry);

        return new JournalMoodSnapshot(
            points,
            points.Count >= 2,
            AppStrings.ResolveChartSubtitle(points.Count),
            timeline,
            groups,
            weekDays,
            monthCells,
            monthStart,
            AppStrings.JournalMonthTitle(monthStart),
            yearCells,
            resolvedYear,
            AppStrings.JournalYearTitle(resolvedYear),
            calendarScale,
            editorEntryId,
            resolvedEditorDay,
            resolvedSlot,
            morningEntry is not null,
            eveningEntry is not null,
            editorNote,
            crisisDetector.IsCrisis(editorNote),
            selectedLevel,
            editorDisplay,
            historyEntries.Length == 0 ? string.Empty : string.Join(" · ", historyEntries),
            AppStrings.WeekRangeLabel(rangeStart, today),
            stats,
            practiceInsight,
            onThisDay,
            stripEnd,
            activityInsights,
            practiceMarks,
            hasEarlierEntries,
            ToSlotPreview(morningEntry),
            ToSlotPreview(eveningEntry));
    }

    /// <summary>Backwards-compatible save API for callers that only need crisis classification.</summary>
    internal bool NoteLooksLikeCrisis(string? note) => crisisDetector.IsCrisis(note);

    internal Task SaveNoteAsync(long entryId, string? note) => userProgressService.UpdateMoodNoteAsync(entryId, note);

    public async Task<long> SaveMoodAsync(
        int moodLevel,
        string? note,
        long? entryId,
        DateOnly day,
        JournalCheckInSlot slot,
        CancellationToken cancellationToken = default)
    {
        if (entryId is > 0)
        {
            await userProgressService.UpdateMoodEntryAsync(entryId.Value, moodLevel, note, cancellationToken);
            return entryId.Value;
        }

        return await userProgressService.SaveJournalSlotAsync(
            new MoodEntryDTO { MoodLevel = moodLevel, Note = note, RecordedAt = ResolveSlotTimestamp(day, slot) },
            day, slot == JournalCheckInSlot.Morning, preserveNote: false, cancellationToken);
    }

    /// <summary>
    /// A check-in "now" from outside the journal (the home-screen widget): it fills or replaces today's current slot, as
    /// tapping a face in the journal does, and keeps a note already written there.
    /// </summary>
    public Task SaveNowAsync(int moodLevel, CancellationToken cancellationToken = default)
    {
        DateTimeOffset now = DateTimeOffset.Now;
        return userProgressService.SaveJournalSlotAsync(
            new MoodEntryDTO { MoodLevel = moodLevel, RecordedAt = now.UtcDateTime },
            DateOnly.FromDateTime(now.DateTime), MoodCheckInSlotPolicy.IsMorningLocalHour(now.Hour),
            preserveNote: true, cancellationToken);
    }

    public async Task<IReadOnlyList<MoodEntryDTO>> GetExportMoodsAsync(
        CancellationToken cancellationToken = default)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        DateOnly from = today.AddYears(-1);
        DateTime fromUtc = from.ToDateTime(TimeOnly.MinValue).ToUniversalTime();
        DateTime toUtcExclusive = today.AddDays(1).ToDateTime(TimeOnly.MinValue).ToUniversalTime();
        return await userProgressService.GetMoodsAsync(fromUtc, toUtcExclusive, TimelineLimit, cancellationToken);
    }

    public static DateOnly ClampStripEnd(DateOnly stripEnd, DateOnly today)
    {
        DateOnly earliest = today.AddDays(-(MaxWeekLookbackDays - 1));
        if (stripEnd > today)
        {
            return today;
        }

        return stripEnd < earliest ? earliest : stripEnd;
    }

    public static DateOnly ClampMonth(DateOnly month, DateOnly today)
    {
        DateOnly currentMonth = new(today.Year, today.Month, 1);
        DateOnly earliest = currentMonth.AddMonths(-(MaxMonthLookbackMonths - 1));
        DateOnly normalized = new(month.Year, month.Month, 1);
        if (normalized > currentMonth)
        {
            return currentMonth;
        }

        return normalized < earliest ? earliest : normalized;
    }

    public static int ClampYear(int year, DateOnly today)
    {
        int current = today.Year;
        int earliest = current - (MaxYearLookbackYears - 1);
        if (year > current)
        {
            return current;
        }

        return year < earliest ? earliest : year;
    }

    public static IReadOnlyList<JournalTimelineDayGroup> FilterGroupsByNoteSearch(
        IReadOnlyList<JournalTimelineDayGroup> groups,
        string? query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return groups;
        }

        string needle = query.Trim();
        return groups
            .Select(group =>
            {
                List<MoodNoteItem> matched = group.Entries
                    .Where(entry => entry.HasNote &&
                                    entry.NoteText.Contains(needle, StringComparison.OrdinalIgnoreCase))
                    .ToList();
                return matched.Count == 0
                    ? null
                    : group with { Entries = matched };
            })
            .Where(group => group is not null)
            .Select(group => group!)
            .ToList();
    }

    /// <summary>Load recent practices once for both the chart markers and the mood insight.</summary>
    private async Task<(string Insight, IReadOnlyList<TrendAnnotation> Marks)> BuildPracticeMoodDetailsAsync(
        IReadOnlyList<MoodChartPoint> points,
        DateOnly rangeStart,
        DateOnly today,
        IReadOnlyDictionary<DateOnly, int> moodLevelByDay,
        CancellationToken cancellationToken)
    {
        IReadOnlyList<CompletionDTO> completions;
        try
        {
            completions = await userProgressService.GetRecentTechniqueCompletionsAsync(50, cancellationToken)
                ?? Array.Empty<CompletionDTO>();
        }
        catch (OperationCanceledException) when (points.Count < 2)
        {
            return (string.Empty, []);
        }
        catch (Exception ex) when (ex is not OperationCanceledException)
        {
            return (string.Empty, []);
        }

        if (points.Count >= 2)
        {
            cancellationToken.ThrowIfCancellationRequested();
        }

        IReadOnlyList<TrendAnnotation> marks = [];
        if (points.Count >= 2)
        {
            DateTime first = points[0].RecordedAtLocal;
            DateTime last = points[^1].RecordedAtLocal;
            marks = [.. completions
                .Select(completion => completion.CompletedAt.ToLocalTime())
                .Where(at => at >= first && at <= last)
                .Select(at => new TrendAnnotation(at))];
        }

        return (BuildPracticeMoodInsight(completions, rangeStart, today, moodLevelByDay), marks);
    }

    private static string BuildPracticeMoodInsight(
        IReadOnlyList<CompletionDTO> completions,
        DateOnly rangeStart,
        DateOnly today,
        IReadOnlyDictionary<DateOnly, int> moodLevelByDay)
    {
        HashSet<DateOnly> practiceDays = completions
            .Select(completion => DateOnly.FromDateTime(completion.CompletedAt.ToLocalTime()))
            .ToHashSet();
        JournalPracticeMoodInsightResult insight = JournalPracticeMoodInsightBuilder.Build(
            rangeStart,
            today,
            practiceDays,
            moodLevelByDay);
        if (!insight.HasInsight || insight.AverageMoodOnPracticeDays is null)
        {
            return string.Empty;
        }

        string averageOnPractice = AppStrings.FormatAverageMood(insight.AverageMoodOnPracticeDays.Value);
        if (insight.AverageMoodWithoutPractice is not null)
        {
            return AppStrings.JournalPracticeMoodCompareInsight(
                insight.PracticeDayCount,
                averageOnPractice,
                AppStrings.FormatAverageMood(insight.AverageMoodWithoutPractice.Value));
        }

        return AppStrings.JournalPracticeMoodInsight(insight.PracticeDayCount, averageOnPractice);
    }

    private static string BuildOnThisDayLastYear(MoodEntryDTO? entry)
    {
        if (entry is null)
        {
            return string.Empty;
        }

        string snippet = JournalNoteFactors.StripFactorLines(entry.Note);
        return AppStrings.JournalOnThisDayLastYear(entry.MoodLevel, snippet);
    }

    private static List<JournalTimelineDayGroup> BuildTimelineGroups(IReadOnlyList<MoodNoteItem> timeline)
    {
        Dictionary<DateOnly, List<MoodNoteItem>> entriesByDay = [];
        foreach (MoodNoteItem entry in timeline)
        {
            if (!entriesByDay.TryGetValue(entry.Day, out List<MoodNoteItem>? dayEntries))
            {
                dayEntries = new(capacity: 2);
                entriesByDay.Add(entry.Day, dayEntries);
            }

            dayEntries.Add(entry);
        }

        List<JournalTimelineDayGroup> groups = new(entriesByDay.Count);
        foreach ((DateOnly day, List<MoodNoteItem> entries) in entriesByDay.OrderByDescending(group => group.Key))
        {
            groups.Add(new JournalTimelineDayGroup(day, AppStrings.JournalEditorDayTitle(day), entries));
        }

        return groups;
    }

    private static JournalMoodStats BuildStats(IReadOnlyList<MoodEntryDTO> newestFirst, int daysWithMood, int periodDays)
    {
        if (newestFirst.Count == 0)
        {
            return new JournalMoodStats(
                0,
                AppStrings.MetricEmptyValue,
                AppStrings.MetricEmptyValue,
                string.Empty,
                string.Empty,
                false);
        }

        MoodEntryDTO newest = newestFirst[0];
        MoodEntryDTO oldest = newest;
        int best = newest.MoodLevel;
        int worst = newest.MoodLevel;
        long sum = newest.MoodLevel;
        for (int index = 1; index < newestFirst.Count; index++)
        {
            MoodEntryDTO entry = newestFirst[index];
            sum += entry.MoodLevel;
            best = Math.Max(best, entry.MoodLevel);
            worst = Math.Min(worst, entry.MoodLevel);

            // Match the endpoints of a stable chronological sort, including equal timestamps.
            if (entry.RecordedAt == newest.RecordedAt)
            {
                newest = entry;
            }

            if (entry.RecordedAt < oldest.RecordedAt)
            {
                oldest = entry;
            }
        }

        double average = (double)sum / newestFirst.Count;
        JournalMoodTrend trend = JournalMoodTrendResolver.Resolve([oldest.MoodLevel, newest.MoodLevel]);
        // "Best 4 · worst 4" says nothing: the pill shows only when the moods of the period differ.
        string bestWorst = best == worst ? string.Empty : AppStrings.JournalBestWorstPill(best, worst);

        return new JournalMoodStats(
            newestFirst.Count,
            AppStrings.FormatAverageMood(average),
            AppStrings.JournalCheckInDays(daysWithMood, periodDays),
            FormatMoodTrend(trend),
            bestWorst,
            true);
    }

    private static string FormatMoodTrend(JournalMoodTrend trend) => trend switch
    {
        JournalMoodTrend.Up => AppStrings.MoodTrendUp,
        JournalMoodTrend.Down => AppStrings.MoodTrendDown,
        JournalMoodTrend.Flat => AppStrings.MoodTrendFlat,
        _ => string.Empty
    };

    private static JournalSlotPreview? ToSlotPreview(MoodEntryDTO? entry) =>
        entry is null
            ? null
            : new JournalSlotPreview(entry.MoodLevel, string.IsNullOrWhiteSpace(entry.Note) ? null : JournalNoteFactors.FormatDisplayNote(entry.Note));

    internal static (MoodEntryDTO? Morning, MoodEntryDTO? Evening) SplitDaySlots(
        IReadOnlyList<MoodEntryDTO> dayEntries)
    {
        if (dayEntries.Count == 0)
        {
            return (null, null);
        }

        MoodEntryDTO earliest = dayEntries[0];
        if (dayEntries.Count == 1)
        {
            int hour = earliest.RecordedAt.ToLocalTime().Hour;
            return MoodCheckInSlotPolicy.IsMorningLocalHour(hour)
                ? (earliest, null)
                : (null, earliest);
        }

        MoodEntryDTO latest = earliest;
        for (int i = 1; i < dayEntries.Count; i++)
        {
            MoodEntryDTO entry = dayEntries[i];
            if (entry.RecordedAt < earliest.RecordedAt)
            {
                earliest = entry;
            }

            // For equal timestamps, preserve the first and last positions of a stable sort.
            if (entry.RecordedAt >= latest.RecordedAt)
            {
                latest = entry;
            }
        }

        return (earliest, latest);
    }

    private static DateTime ResolveSlotTimestamp(DateOnly day, JournalCheckInSlot slot)
    {
        DateOnly today = DateOnly.FromDateTime(DateTime.Today);
        int hourNow = DateTime.Now.Hour;
        if (day == today)
        {
            if (slot == JournalCheckInSlot.Morning && MoodCheckInSlotPolicy.IsMorningLocalHour(hourNow))
            {
                return DateTime.UtcNow;
            }

            if (slot == JournalCheckInSlot.Evening && MoodCheckInSlotPolicy.IsEveningLocalHour(hourNow))
            {
                return DateTime.UtcNow;
            }
        }

        TimeOnly time = slot == JournalCheckInSlot.Morning
            ? new TimeOnly(9, 0)
            : new TimeOnly(21, 0);
        return day.ToDateTime(time).ToUniversalTime();
    }

    private static MoodNoteItem ToTimelineItem(
        MoodEntryDTO entry,
        DateTime local,
        DateOnly day,
        DateOnly today,
        string noNoteCaption)
    {
        bool hasNote = !string.IsNullOrWhiteSpace(entry.Note);
        string formattedNote = hasNote
            ? JournalNoteFactors.FormatDisplayNote(entry.Note)
            : noNoteCaption;
        return new MoodNoteItem(
            entry.MoodEntryId,
            day,
            local.ToString("d"),
            local.ToString("t"),
            formattedNote,
            hasNote,
            entry.MoodLevel,
            day == today);
    }
}
