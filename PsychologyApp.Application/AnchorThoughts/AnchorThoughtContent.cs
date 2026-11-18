using PsychologyApp.Application.Articles;

namespace PsychologyApp.Application.AnchorThoughts;

/// <summary>What a thought is about; the page offers one theme at a time or all of them.</summary>
public enum AnchorTheme
{
    /// <summary>Other people's words, judgements and how they treat me.</summary>
    OthersWords,

    /// <summary>Mistakes, self-criticism and the demand to be perfect.</summary>
    Mistakes,

    /// <summary>Thoughts, feelings, anxiety.</summary>
    ThoughtsAndFeelings,

    /// <summary>Boundaries, needs and close relationships.</summary>
    Relationships,

    /// <summary>Low energy, loss, a long hard stretch.</summary>
    HardTimes
}

/// <param name="Id">The same in every language: the languages are matched by it (tested).</param>
/// <param name="Text">The thought itself, short enough to remember in a hard minute.</param>
/// <param name="Why">Why it holds, so the thought can be checked against experience instead of taken as a rule.</param>
/// <param name="ArticleId">The article that explains it more fully (<see cref="ArticleIds"/>).</param>
public sealed record AnchorThought(string Id, AnchorTheme Theme, string Text, string Why, string ArticleId);

/// <summary>
/// Short thoughts to lean on: about one's worth, mistakes, other people's words, feelings and hard times. Each speaks about an action
/// or about oneself, never labels the other person, and says why it holds. Clinical copy needs psychologist review before release.
/// </summary>
public static partial class AnchorThoughtContent
{
    /// <summary>The theme and the article of each thought, in the order they are shown; one place for every language.</summary>
    private static readonly (string Id, AnchorTheme Theme, string ArticleId)[] Entries =
    [
        ("humiliation", AnchorTheme.OthersWords, ArticleIds.Boundaries),
        ("others-words", AnchorTheme.OthersWords, ArticleIds.SelfEsteem),
        ("criticism", AnchorTheme.OthersWords, ArticleIds.SelfEsteem),
        ("how-treated", AnchorTheme.OthersWords, ArticleIds.EmotionalAbuse),
        ("comparison", AnchorTheme.OthersWords, ArticleIds.SelfEsteem),
        ("not-everyone", AnchorTheme.OthersWords, ArticleIds.SocialAnxiety),
        ("mind-reading", AnchorTheme.OthersWords, ArticleIds.SocialAnxiety),
        ("refusal", AnchorTheme.OthersWords, ArticleIds.Loneliness),
        ("silence", AnchorTheme.OthersWords, ArticleIds.Loneliness),
        ("not-my-shame", AnchorTheme.OthersWords, ArticleIds.ShameAndGuilt),
        ("loud-not-true", AnchorTheme.OthersWords, ArticleIds.Boundaries),

        ("mistake", AnchorTheme.Mistakes, ArticleIds.ShameAndGuilt),
        ("kind-voice", AnchorTheme.Mistakes, ArticleIds.SelfCriticism),
        ("good-enough", AnchorTheme.Mistakes, ArticleIds.Perfectionism),
        ("learning", AnchorTheme.Mistakes, ArticleIds.Perfectionism),
        ("past-decisions", AnchorTheme.Mistakes, ArticleIds.ShameAndGuilt),
        ("worth-not-output", AnchorTheme.Mistakes, ArticleIds.Burnout),
        ("repair-is-enough", AnchorTheme.Mistakes, ArticleIds.ShameAndGuilt),
        ("start-imperfect", AnchorTheme.Mistakes, ArticleIds.Procrastination),
        ("failure-is-information", AnchorTheme.Mistakes, ArticleIds.Perfectionism),
        ("habit-cue", AnchorTheme.Mistakes, ArticleIds.HabitFormation),
        ("habit-lapse", AnchorTheme.Mistakes, ArticleIds.HabitFormation),
        ("exam-plan", AnchorTheme.ThoughtsAndFeelings, ArticleIds.ExamAnxiety),
        ("exam-anxiety-not-failure", AnchorTheme.ThoughtsAndFeelings, ArticleIds.ExamAnxiety),
        ("exam-practice-is-learning", AnchorTheme.Mistakes, ArticleIds.ExamAnxiety),

        ("thought-not-fact", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Thoughts),
        ("feeling-wave", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Emotions),
        ("any-feeling", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Emotions),
        ("anxiety-signal", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Anxiety),
        ("panic-passes", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Panic),
        ("plan-adjustable", AnchorTheme.ThoughtsAndFeelings, ArticleIds.ProblemPlanning),
        ("one-step-choice", AnchorTheme.HardTimes, ArticleIds.ProblemPlanning),
        ("try-adjust", AnchorTheme.HardTimes, ArticleIds.ProblemPlanning),
        ("rest-not-task", AnchorTheme.HardTimes, ArticleIds.WorkRecovery),
        ("choose-recovery", AnchorTheme.HardTimes, ArticleIds.WorkRecovery),
        ("care-can-be-shared", AnchorTheme.Relationships, ArticleIds.CaregiverWellbeing),
        ("care-is-not-perfect", AnchorTheme.Relationships, ArticleIds.CaregiverWellbeing),
        ("care-needs-pause", AnchorTheme.HardTimes, ArticleIds.CaregiverWellbeing),
        ("values-direction", AnchorTheme.HardTimes, ArticleIds.ValuesAction),
        ("values-not-checklist", AnchorTheme.Mistakes, ArticleIds.ValuesAction),
        ("values-small-step", AnchorTheme.HardTimes, ArticleIds.ValuesAction),
        ("values-can-change", AnchorTheme.ThoughtsAndFeelings, ArticleIds.ValuesAction),
        ("values-rest-counts", AnchorTheme.HardTimes, ArticleIds.ValuesAction),
        ("mood-early-signal", AnchorTheme.HardTimes, ArticleIds.MoodSupportPlan),
        ("mood-skills-stay", AnchorTheme.Mistakes, ArticleIds.MoodSupportPlan),
        ("mood-plan-is-care", AnchorTheme.HardTimes, ArticleIds.MoodSupportPlan),
        ("mood-ask-early", AnchorTheme.Relationships, ArticleIds.MoodSupportPlan),
        ("mood-not-alone", AnchorTheme.HardTimes, ArticleIds.MoodSupportPlan),
        ("attention-not-laziness", AnchorTheme.Mistakes, ArticleIds.AttentionAssessment),
        ("attention-checklist-not-diagnosis", AnchorTheme.ThoughtsAndFeelings, ArticleIds.AttentionAssessment),
        ("attention-support-before-label", AnchorTheme.HardTimes, ArticleIds.AttentionAssessment),
        ("attention-history-without-blame", AnchorTheme.ThoughtsAndFeelings, ArticleIds.AttentionAssessment),
        ("attention-needs-individual", AnchorTheme.HardTimes, ArticleIds.AttentionAssessment),
        ("not-right-now", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Rumination),
        ("worry-not-safety", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Rumination),
        ("worry-is-prediction", AnchorTheme.ThoughtsAndFeelings, ArticleIds.WorryTime),
        ("time-not-suppression", AnchorTheme.ThoughtsAndFeelings, ArticleIds.WorryTime),
        ("urgent-action-now", AnchorTheme.HardTimes, ArticleIds.WorryTime),
        ("one-question-at-time", AnchorTheme.HardTimes, ArticleIds.WorryTime),

        ("small-steps-to-fear", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Avoidance),
        ("calm-body-first", AnchorTheme.ThoughtsAndFeelings, ArticleIds.BodyAndStress),
        ("uncertainty-bearable", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Uncertainty),
        ("let-thoughts-pass", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Mindfulness),
        ("news-checking", AnchorTheme.ThoughtsAndFeelings, ArticleIds.NewsLoop),

        ("saying-no", AnchorTheme.Relationships, ArticleIds.Boundaries),
        ("my-needs", AnchorTheme.Relationships, ArticleIds.Boundaries),
        ("anger-timeout", AnchorTheme.Relationships, ArticleIds.Anger),
        ("others-feelings", AnchorTheme.Relationships, ArticleIds.Conflicts),
        ("say-what-i-need", AnchorTheme.Relationships, ArticleIds.Conflicts),
        ("repair", AnchorTheme.Relationships, ArticleIds.Conflicts),
        ("loneliness-feeling", AnchorTheme.Relationships, ArticleIds.Loneliness),
        ("envy-shows-wants", AnchorTheme.Relationships, ArticleIds.JealousyAndEnvy),
        ("breakup-not-worth", AnchorTheme.Relationships, ArticleIds.Breakup),
        ("different-not-wrong", AnchorTheme.Relationships, ArticleIds.Conflicts),
        ("ask-for-support", AnchorTheme.Relationships, ArticleIds.SupportRequest),

        ("small-step", AnchorTheme.HardTimes, ArticleIds.LowMood),
        ("adjust-the-step", AnchorTheme.HardTimes, ArticleIds.SmallStepReview),
        ("one-day", AnchorTheme.HardTimes, ArticleIds.LowMood),
        ("rest", AnchorTheme.HardTimes, ArticleIds.Burnout),
        ("not-a-straight-line", AnchorTheme.HardTimes, ArticleIds.Depression),
        ("grief-love", AnchorTheme.HardTimes, ArticleIds.Grief),
        ("reasonable-decision", AnchorTheme.HardTimes, ArticleIds.Uncertainty),
        ("basic-care", AnchorTheme.HardTimes, ArticleIds.LowMood),
        ("small-hope", AnchorTheme.HardTimes, ArticleIds.Depression),
        ("not-forever", AnchorTheme.HardTimes, ArticleIds.Depression),
        ("asking-for-help", AnchorTheme.HardTimes, ArticleIds.Specialist),
        ("grounding-choice", AnchorTheme.ThoughtsAndFeelings, ArticleIds.TraumaGrounding),
        ("loud-is-not-urgent", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Overwhelm),
        ("list-is-a-tool", AnchorTheme.HardTimes, ArticleIds.Overwhelm),
        ("ask-for-specific-help", AnchorTheme.Relationships, ArticleIds.Overwhelm),
        ("news-on-my-schedule", AnchorTheme.ThoughtsAndFeelings, ArticleIds.NewsLoop),
        ("pause-from-feed", AnchorTheme.HardTimes, ArticleIds.NewsLoop),
        ("keep-essential-alerts", AnchorTheme.HardTimes, ArticleIds.NewsLoop),
        ("repair-is-a-choice", AnchorTheme.Relationships, ArticleIds.ConversationRepair),
        ("apology-keeps-a-boundary", AnchorTheme.Relationships, ArticleIds.ConversationRepair),
        ("small-request-after-conflict", AnchorTheme.Relationships, ArticleIds.ConversationRepair),
        ("habit-can-be-small", AnchorTheme.HardTimes, ArticleIds.HabitFormation),
        ("one-cue-is-enough", AnchorTheme.ThoughtsAndFeelings, ArticleIds.HabitFormation),
        ("starting-is-a-step", AnchorTheme.HardTimes, ArticleIds.HabitFormation),
        ("missed-day-is-data", AnchorTheme.HardTimes, ArticleIds.HabitFormation),
        ("next-cue-is-enough", AnchorTheme.ThoughtsAndFeelings, ArticleIds.HabitFormation),
        ("plan-can-change", AnchorTheme.HardTimes, ArticleIds.HabitFormation),
        ("feedback-is-about-action", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Feedback),
        ("pause-before-reply", AnchorTheme.HardTimes, ArticleIds.Feedback),
        ("i-can-ask-for-example", AnchorTheme.Relationships, ArticleIds.Feedback),
        ("one-useful-point-is-enough", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Feedback),
        ("clarity-is-a-fair-request", AnchorTheme.Relationships, ArticleIds.Feedback),
        ("respect-is-part-of-feedback", AnchorTheme.HardTimes, ArticleIds.Feedback),
        ("connection-can-be-small", AnchorTheme.Relationships, ArticleIds.Loneliness),
        ("pause-is-allowed", AnchorTheme.HardTimes, ArticleIds.Loneliness),
        ("i-can-invite-without-pressure", AnchorTheme.Relationships, ArticleIds.Loneliness),
        ("no-is-not-a-verdict", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Loneliness),
        ("safe-format-comes-first", AnchorTheme.HardTimes, ArticleIds.Loneliness),
        ("shared-activity-can-connect", AnchorTheme.Relationships, ArticleIds.Loneliness)
    ];

    /// <summary>The thoughts in a language by its key ("ru", "en", "fr"…); a language without its own gets the English ones.</summary>
    public static IReadOnlyList<AnchorThought> All(string? language)
    {
        IReadOnlyDictionary<string, (string Text, string Why)> texts = language?.ToLowerInvariant() switch
        {
            "ru" => Ru,
            "fr" => Fr,
            "de" => De,
            "es" => Es,
            "pt" => Pt,
            "zh" => Zh,
            _ => En
        };

        return [.. Entries.Select(entry => new AnchorThought(entry.Id, entry.Theme, texts[entry.Id].Text, texts[entry.Id].Why, entry.ArticleId))];
    }
}
