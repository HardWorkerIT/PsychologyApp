using System.Globalization;
using PsychologyApp.Application.Models;
using PsychologyApp.Presentation.Common;
using PsychologyApp.Presentation.Entities.Journal;
using PsychologyApp.Presentation.Features.ManageJournal;
using Xunit;

namespace PsychologyApp.Presentation.Tests;

[Collection("Localization")]
public sealed class JournalHelpersTests
{
    [Theory]
    [InlineData(JournalCheckInSlot.Morning, true, false, 10, JournalCheckInSlot.Morning)]
    [InlineData(JournalCheckInSlot.Evening, false, true, 10, JournalCheckInSlot.Evening)]
    [InlineData(JournalCheckInSlot.Morning, false, false, 10, JournalCheckInSlot.Morning)]
    [InlineData(JournalCheckInSlot.Evening, false, false, 20, JournalCheckInSlot.Evening)]
    [InlineData(JournalCheckInSlot.Morning, false, true, 20, JournalCheckInSlot.Morning)]
    public void JournalEditorSlotResolver_RespectsRequestAndClock(
        JournalCheckInSlot requested,
        bool hasMorning,
        bool hasEvening,
        int hour,
        JournalCheckInSlot expected)
    {
        MoodEntryDTO? morning = hasMorning ? new MoodEntryDTO { MoodEntryId = 1 } : null;
        MoodEntryDTO? evening = hasEvening ? new MoodEntryDTO { MoodEntryId = 2 } : null;

        Assert.Equal(
            expected,
            JournalEditorSlotResolver.Resolve(requested, morning, evening, hour));
    }

    [Theory]
    [InlineData(new int[] { }, JournalMoodTrend.None)]
    [InlineData(new[] { 3 }, JournalMoodTrend.Flat)]
    [InlineData(new[] { 2, 4 }, JournalMoodTrend.Up)]
    [InlineData(new[] { 4, 2 }, JournalMoodTrend.Down)]
    [InlineData(new[] { 3, 3 }, JournalMoodTrend.Flat)]
    public void JournalMoodTrendResolver_ReturnsExpected(int[] levels, JournalMoodTrend expected)
    {
        Assert.Equal(expected, JournalMoodTrendResolver.Resolve(levels));
    }

    [Fact]
    public void JournalPracticeMoodInsightBuilder_ComparesPracticeAndNonPracticeDays()
    {
        DateOnly today = DateOnly.Parse("2026-07-26");
        DateOnly start = today.AddDays(-6);
        HashSet<DateOnly> practiceDays = [today.AddDays(-1), today.AddDays(-2)];
        Dictionary<DateOnly, int> moods = new()
        {
            [today.AddDays(-1)] = 4,
            [today.AddDays(-2)] = 5,
            [today.AddDays(-3)] = 2
        };

        JournalPracticeMoodInsightResult result = JournalPracticeMoodInsightBuilder.Build(
            start,
            today,
            practiceDays,
            moods);

        Assert.True(result.HasInsight);
        Assert.Equal(2, result.PracticeDayCount);
        Assert.Equal(4.5, result.AverageMoodOnPracticeDays);
        Assert.Equal(2.0, result.AverageMoodWithoutPractice);
    }

    [Fact]
    public void JournalCalendarBuilder_BuildWeekDays_ReturnsSevenChips()
    {
        DateOnly stripEnd = DateOnly.Parse("2026-07-26");
        Dictionary<DateOnly, int> moods = new()
        {
            [stripEnd] = 4,
            [stripEnd.AddDays(-2)] = 2
        };

        List<JournalDayChip> chips = JournalCalendarBuilder.BuildWeekDays(
            stripEnd,
            moods,
            stripEnd,
            CultureInfo.InvariantCulture);

        Assert.Equal(7, chips.Count);
        Assert.Equal(stripEnd.AddDays(-6), chips[0].Date);
        Assert.Equal(stripEnd, chips[^1].Date);
        Assert.True(chips[^1].IsSelected);
        Assert.True(chips[^1].HasEntry);
        Assert.Equal(4, chips[^1].MoodLevel);
        Assert.True(chips[4].HasEntry);
        Assert.Equal(2, chips[4].MoodLevel);
        Assert.False(chips[0].HasEntry);
        Assert.Equal("20", chips[0].DayNumber);
        Assert.Equal("26", chips[^1].DayNumber);
    }

    [Fact]
    public void JournalCalendarBuilder_BuildMonthCells_UsesMondayFirstLeading()
    {
        // 2026-07-01 is Wednesday → Monday-first leading = 2
        DateOnly monthStart = DateOnly.Parse("2026-07-01");
        DateOnly today = DateOnly.Parse("2026-07-26");
        Assert.Equal(2, JournalCalendarBuilder.MondayFirstLeadingDays(monthStart));

        List<JournalMonthCell> cells = JournalCalendarBuilder.BuildMonthCells(
            monthStart,
            today,
            new Dictionary<DateOnly, int> { [DateOnly.Parse("2026-07-15")] = 5 },
            DateOnly.Parse("2026-07-15"));

        Assert.Equal(2, cells.Count(cell => cell.IsPlaceholder));
        Assert.Equal(31 + 2, cells.Count);
        JournalMonthCell selected = cells.Single(cell => cell.IsSelected);
        Assert.Equal(DateOnly.Parse("2026-07-15"), selected.Date);
        Assert.True(selected.HasEntry);
        Assert.Equal("15", selected.DayNumber);
    }

    [Fact]
    public void JournalCalendarBuilder_BuildYearCells_CoversFullYearWithLeading()
    {
        DateOnly today = DateOnly.Parse("2026-07-26");
        // 2026-01-01 is Thursday → Monday-first leading = 3
        Assert.Equal(3, JournalCalendarBuilder.MondayFirstLeadingDays(new DateOnly(2026, 1, 1)));

        List<JournalYearCell> cells = JournalCalendarBuilder.BuildYearCells(
            2026,
            today,
            new Dictionary<DateOnly, int> { [today] = 3 },
            today);

        Assert.Equal(3 + 365, cells.Count); // 2026 is not a leap year
        Assert.Equal(3, cells.Count(cell => cell.IsPlaceholder));
        JournalYearCell selected = cells.Single(cell => cell.IsSelected);
        Assert.Equal(today, selected.Date);
        Assert.True(selected.HasEntry);
        Assert.Equal(3, selected.MoodLevel);
        Assert.Contains(cells, cell => cell.Date == DateOnly.Parse("2026-12-31") && !cell.IsEnabled);
    }

    [Theory]
    [InlineData("ru", ", выбрано", "настроение не отмечено")]
    [InlineData("en", ", selected", "no mood recorded")]
    [InlineData("de", ", ausgewählt", "keine Stimmung eingetragen")]
    [InlineData("es", ", seleccionado", "sin estado de ánimo registrado")]
    [InlineData("fr", ", sélectionné", "aucune humeur enregistrée")]
    [InlineData("pt", ", selecionado", "humor não registrado")]
    [InlineData("zh", "，已选中", "未记录心情")]
    public void JournalCalendarDayAccessibility_AnnouncesDateMoodAndSelectionInEveryLanguage(
        string language,
        string selectedSuffix,
        string noMoodPhrase)
    {
        string? previousLanguage = AppStrings.LanguageOverride;
        AppStrings.LanguageOverride = language;

        try
        {
            DateOnly date = new(2026, 7, 26);
            string expectedDate = date.ToDateTime(TimeOnly.MinValue)
                .ToString("D", CultureInfo.GetCultureInfo(AppLanguages.CultureName(language)));

            string description = AppStrings.JournalCalendarDayAccessibility(date, 4, isSelected: true);

            Assert.Contains(expectedDate, description);
            Assert.Contains(AppStrings.MoodLevelName(4), description);
            Assert.EndsWith(selectedSuffix, description);

            string noMoodDescription = AppStrings.JournalCalendarDayAccessibility(date, null, isSelected: false);

            Assert.Contains(expectedDate, noMoodDescription);
            Assert.Contains(noMoodPhrase, noMoodDescription);
            Assert.DoesNotContain(selectedSuffix.TrimStart(',', '，', ' '), noMoodDescription);
        }
        finally
        {
            AppStrings.LanguageOverride = previousLanguage;
        }
    }

    [Fact]
    public void JournalDayChip_NotifiesBindingsWhenAccessibleSelectionStateChanges()
    {
        string? previousLanguage = AppStrings.LanguageOverride;
        AppStrings.LanguageOverride = "en";

        try
        {
            JournalDayChip chip = new()
            {
                Date = new DateOnly(2026, 7, 26),
                MoodLevel = 2,
                HasEntry = true
            };
            string before = chip.AccessibilityDescription;
            bool descriptionChanged = false;
            chip.PropertyChanged += (_, args) =>
                descriptionChanged |= args.PropertyName == nameof(JournalDayChip.AccessibilityDescription);

            chip.IsSelected = true;

            Assert.NotEqual(before, chip.AccessibilityDescription);
            Assert.EndsWith(", selected", chip.AccessibilityDescription);
            Assert.True(descriptionChanged);
        }
        finally
        {
            AppStrings.LanguageOverride = previousLanguage;
        }
    }
}
