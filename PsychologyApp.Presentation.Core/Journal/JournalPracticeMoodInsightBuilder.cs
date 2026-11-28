namespace PsychologyApp.Presentation.Features.ManageJournal;

public sealed record JournalPracticeMoodInsightResult(
    bool HasInsight,
    int PracticeDayCount,
    double? AverageMoodOnPracticeDays,
    double? AverageMoodWithoutPractice);

public static class JournalPracticeMoodInsightBuilder
{
    public static JournalPracticeMoodInsightResult Build(
        DateOnly rangeStart,
        DateOnly today,
        IReadOnlySet<DateOnly> practiceDays,
        IReadOnlyDictionary<DateOnly, int> moodLevelByDay)
    {
        int practiceDayCount = 0;
        int recordedPracticeDayCount = 0;
        long practiceMoodTotal = 0;
        foreach (DateOnly day in practiceDays)
        {
            if (day < rangeStart || day > today)
            {
                continue;
            }

            practiceDayCount++;
            if (moodLevelByDay.TryGetValue(day, out int mood))
            {
                recordedPracticeDayCount++;
                practiceMoodTotal += mood;
            }
        }

        if (recordedPracticeDayCount == 0)
        {
            return new JournalPracticeMoodInsightResult(false, practiceDayCount, null, null);
        }

        int otherDayCount = 0;
        long otherMoodTotal = 0;
        foreach ((DateOnly day, int mood) in moodLevelByDay)
        {
            if (day >= rangeStart && day <= today && !practiceDays.Contains(day))
            {
                otherDayCount++;
                otherMoodTotal += mood;
            }
        }

        return new JournalPracticeMoodInsightResult(
            true,
            practiceDayCount,
            (double)practiceMoodTotal / recordedPracticeDayCount,
            otherDayCount > 0 ? (double)otherMoodTotal / otherDayCount : null);
    }
}
