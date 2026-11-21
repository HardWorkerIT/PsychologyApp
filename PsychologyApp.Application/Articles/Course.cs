namespace PsychologyApp.Application.Articles;

/// <param name="Task">What to try before the next day: guided self-help works through practice between readings, not reading alone.</param>
/// <param name="Reflection">A question the person answers in their own words when they close the day.</param>
public sealed record CourseDay(string Title, int Minutes, IReadOnlyList<ArticleBlock> Blocks, string Task, string Reflection);

/// <param name="Id">Stable: progress is stored by it.</param>
/// <param name="TestId">An existing general self-report questionnaire shown alongside the course; it does not measure course-specific skills or establish course effectiveness.</param>
/// <param name="TestName">How the questionnaire is called on the Tests tab.</param>
public sealed record Course(string Id, string Title, string Summary, string Icon, string TestId, string TestName, IReadOnlyList<CourseDay> Days);

public static class CourseIds
{
    public const string Sleep = "sleep";
    public const string Anxiety = "anxiety";
    public const string ProblemPlanning = "problem-planning";
    public const string Overwhelm = "overwhelm";
    public const string Mood = "mood";
    public const string Trauma = "trauma";
    public const string MoneyStress = "money-stress";
    /// <summary>Build small actions around what matters, with room to adjust when life gets hard.</summary>
    public const string ValuesAction = "values-action";
    public const string NewsBoundaries = "news-boundaries";
    public const string HabitMaintenance = "habit-maintenance";
    public const string FeedbackResponse = "feedback-response";
    public const string ConnectionWithoutPressure = "connection-without-pressure";
    public const string Boundaries = "boundaries";
    public const string WorkRecovery = "work-recovery";
    public const string SelfCompassion = "self-compassion";
    public const string SupportSomeone = "support-someone";
    public const string TaskStart = "task-start";
    public const string FlexibleStandards = "flexible-standards";
    public const string ThoughtLoops = "thought-loops";
    public const string UncertainDecisions = "uncertain-decisions";
    public const string PauseBeforeReply = "pause-before-reply";
    public const string IrritationSignals = "irritation-signals";
    public const string ConflictRepair = "conflict-repair";
    public const string LifeTransitions = "life-transitions";
    public const string GriefAtYourPace = "grief-at-your-pace";
    public const string ReturnToFocus = "return-to-focus";
    public const string StudyBlocks = "study-blocks";
    public const string BodyNeutrality = "body-neutrality";
    public const string SelfWorth = "self-worth";
    public const string SocialSteps = "social-steps";
    public const string AppointmentPreparation = "appointment-preparation";
    public const string WaitingForAnswer = "waiting-for-answer";
    public const string AskForHelp = "ask-for-help";
    public const string CaregiverLimits = "caregiver-limits";
    public const string LowEnergyRoutine = "low-energy-routine";
    public const string AfterDifficultTalk = "after-difficult-talk";

}

public static partial class ArticleContent
{
    /// <summary>The courses in a language by its key; a language without its own gets the English ones.</summary>
    public static IReadOnlyList<Course> Courses(string? language) => InLanguage(language, CoursesRu, CoursesEn, CoursesFr, CoursesDe, CoursesEs, CoursesPt, CoursesZh);

    public static Course? FindCourse(string id, string? language) => Courses(language).FirstOrDefault(course => course.Id == id);
}
