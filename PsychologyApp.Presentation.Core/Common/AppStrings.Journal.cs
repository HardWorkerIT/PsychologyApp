using System.Globalization;

namespace PsychologyApp.Presentation.Common;

public static partial class AppStrings
{
    /// <summary>Spoken label for a day in the journal calendar, including information otherwise conveyed by colour.</summary>
    public static string JournalCalendarDayAccessibility(DateOnly date, int? moodLevel, bool isSelected)
    {
        CultureInfo culture = CultureInfo.GetCultureInfo(AppLanguages.CultureName(Language));
        string dateLabel = date.ToDateTime(TimeOnly.MinValue).ToString("D", culture);
        string selectedSuffix = isSelected ? R("JournalCalendarDaySelectedSuffix") : string.Empty;

        return moodLevel is int level
            ? F("JournalCalendarDayWithMood", dateLabel, MoodLevelName(level), selectedSuffix)
            : F("JournalCalendarDayWithoutMood", dateLabel, selectedSuffix);
    }
}
