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
        ("feedback-example-specific", AnchorTheme.OthersWords, ArticleIds.Feedback),
        ("opinion-not-whole", AnchorTheme.OthersWords, ArticleIds.SelfEsteem),
        ("choose-advice-source", AnchorTheme.OthersWords, ArticleIds.SelfEsteem),
        ("disagree-with-respect", AnchorTheme.OthersWords, ArticleIds.Boundaries),
        ("short-boundary", AnchorTheme.OthersWords, ArticleIds.Boundaries),
        ("take-in-praise", AnchorTheme.OthersWords, ArticleIds.SelfEsteem),
        ("one-slip-not-identity", AnchorTheme.OthersWords, ArticleIds.SelfEsteem),
        ("time-before-answer", AnchorTheme.OthersWords, ArticleIds.Boundaries),
        ("awkward-moment-passes", AnchorTheme.OthersWords, ArticleIds.SocialAnxiety),
        ("check-before-infer", AnchorTheme.OthersWords, ArticleIds.SocialAnxiety),
        ("my-own-success-scale", AnchorTheme.OthersWords, ArticleIds.SelfEsteem),
        ("end-unsafe-conversation", AnchorTheme.OthersWords, ArticleIds.EmotionalAbuse),
        ("choose-what-to-share", AnchorTheme.OthersWords, ArticleIds.Boundaries),
        ("not-every-note-needs-action", AnchorTheme.OthersWords, ArticleIds.Feedback),
        ("ask-for-calm", AnchorTheme.OthersWords, ArticleIds.Boundaries),
        ("respect-not-earned", AnchorTheme.OthersWords, ArticleIds.EmotionalAbuse),
        ("values-without-approval", AnchorTheme.OthersWords, ArticleIds.ValuesAction),
        ("impression-not-whole", AnchorTheme.OthersWords, ArticleIds.SocialAnxiety),
        ("start-contact-small", AnchorTheme.OthersWords, ArticleIds.Loneliness),
        ("forgiveness-my-choice", AnchorTheme.OthersWords, ArticleIds.EmotionalAbuse),

        ("draft-before-polish", AnchorTheme.Mistakes, ArticleIds.Procrastination),
        ("revision-is-work", AnchorTheme.Mistakes, ArticleIds.Feedback),
        ("shrink-task", AnchorTheme.Mistakes, ArticleIds.Procrastination),
        ("practice-not-perfect", AnchorTheme.Mistakes, ArticleIds.Perfectionism),
        ("change-method", AnchorTheme.Mistakes, ArticleIds.ProblemPlanning),
        ("learn-at-own-speed", AnchorTheme.Mistakes, ArticleIds.Perfectionism),
        ("not-all-today", AnchorTheme.Mistakes, ArticleIds.Overwhelm),
        ("ask-what-done-means", AnchorTheme.Mistakes, ArticleIds.Feedback),
        ("setback-shows-context", AnchorTheme.Mistakes, ArticleIds.HabitFormation),
        ("practice-without-confidence", AnchorTheme.Mistakes, ArticleIds.SocialAnxiety),
        ("repair-one-part", AnchorTheme.Mistakes, ArticleIds.ShameAndGuilt),
        ("grade-is-not-worth", AnchorTheme.Mistakes, ArticleIds.SelfEsteem),
        ("repeat-builds-skill", AnchorTheme.Mistakes, ArticleIds.HabitFormation),
        ("resume-without-catching-up", AnchorTheme.Mistakes, ArticleIds.HabitFormation),
        ("goal-can-change", AnchorTheme.Mistakes, ArticleIds.ValuesAction),
        ("effort-within-control", AnchorTheme.Mistakes, ArticleIds.SelfCriticism),
        ("pause-then-return", AnchorTheme.Mistakes, ArticleIds.WorkRecovery),
        ("use-external-cue", AnchorTheme.Mistakes, ArticleIds.AttentionAssessment),
        ("next-try-can-differ", AnchorTheme.Mistakes, ArticleIds.HabitFormation),
        ("kindness-after-slip", AnchorTheme.Mistakes, ArticleIds.SelfCriticism),

        ("name-feeling-without-obeying", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Emotions),
        ("mixed-feelings-can-coexist", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Emotions),
        ("repeated-not-proven", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Rumination),
        ("unknown-not-doomed", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Uncertainty),
        ("known-versus-guessed", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Thoughts),
        ("body-curiosity", AnchorTheme.ThoughtsAndFeelings, ArticleIds.BodyAndStress),
        ("not-everything-now", AnchorTheme.ThoughtsAndFeelings, ArticleIds.WorryTime),
        ("next-known-step", AnchorTheme.ThoughtsAndFeelings, ArticleIds.ProblemPlanning),
        ("leave-question-open", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Uncertainty),
        ("mind-need-not-empty", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Mindfulness),
        ("returning-attention", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Mindfulness),
        ("pause-with-anxiety", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Anxiety),
        ("one-sound-anchor", AnchorTheme.ThoughtsAndFeelings, ArticleIds.TraumaGrounding),
        ("feeling-not-my-whole-life", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Emotions),
        ("worry-action-check", AnchorTheme.ThoughtsAndFeelings, ArticleIds.WorryTime),
        ("tension-is-not-forecast", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Anxiety),
        ("update-with-new-facts", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Thoughts),
        ("describe-without-judging", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Mindfulness),
        ("focus-on-nearby", AnchorTheme.ThoughtsAndFeelings, ArticleIds.TraumaGrounding),
        ("check-new-symptoms", AnchorTheme.ThoughtsAndFeelings, ArticleIds.Anxiety),

        ("ask-one-specific-thing", AnchorTheme.Relationships, ArticleIds.SupportRequest),
        ("listen-or-suggest", AnchorTheme.Relationships, ArticleIds.SupportRequest),
        ("boundary-before-resentment", AnchorTheme.Relationships, ArticleIds.Boundaries),
        ("two-versions-can-exist", AnchorTheme.Relationships, ArticleIds.Conflicts),
        ("pause-and-resume-time", AnchorTheme.Relationships, ArticleIds.Anger),
        ("apology-without-self-attack", AnchorTheme.Relationships, ArticleIds.Conflicts),
        ("trust-takes-observed-time", AnchorTheme.Relationships, ArticleIds.EmotionalAbuse),
        ("support-without-taking-over", AnchorTheme.Relationships, ArticleIds.SupportRequest),
        ("clear-kind-no", AnchorTheme.Relationships, ArticleIds.Boundaries),
        ("check-if-good-time", AnchorTheme.Relationships, ArticleIds.Conflicts),
        ("help-keeps-choice", AnchorTheme.Relationships, ArticleIds.SupportRequest),
        ("connection-not-perfect", AnchorTheme.Relationships, ArticleIds.Conflicts),
        ("distance-can-protect", AnchorTheme.Relationships, ArticleIds.EmotionalAbuse),
        ("decline-private-topic", AnchorTheme.Relationships, ArticleIds.Boundaries),
        ("listen-without-agreeing", AnchorTheme.Relationships, ArticleIds.Conflicts),
        ("return-to-talk-gradually", AnchorTheme.Relationships, ArticleIds.ConversationRepair),
        ("respect-other-no", AnchorTheme.Relationships, ArticleIds.Boundaries),
        ("ask-support-directly", AnchorTheme.Relationships, ArticleIds.SupportRequest),
        ("small-agreement", AnchorTheme.Relationships, ArticleIds.Conflicts),
        ("choose-safe-listener", AnchorTheme.Relationships, ArticleIds.SupportRequest),

        ("energy-is-a-condition", AnchorTheme.HardTimes, ArticleIds.WorkRecovery),
        ("basics-affect-capacity", AnchorTheme.HardTimes, ArticleIds.LowMood),
        ("one-day-not-whole-week", AnchorTheme.HardTimes, ArticleIds.LowMood),
        ("one-priority-today", AnchorTheme.HardTimes, ArticleIds.Overwhelm),
        ("small-task-has-value", AnchorTheme.HardTimes, ArticleIds.LowMood),
        ("grief-can-return", AnchorTheme.HardTimes, ArticleIds.Grief),
        ("grief-has-no-deadline", AnchorTheme.HardTimes, ArticleIds.Grief),
        ("help-with-one-errand", AnchorTheme.HardTimes, ArticleIds.SupportRequest),
        ("review-current-load", AnchorTheme.HardTimes, ArticleIds.WorkRecovery),
        ("transition-takes-time", AnchorTheme.HardTimes, ArticleIds.WorkRecovery),
        ("short-plan-for-hard-day", AnchorTheme.HardTimes, ArticleIds.MoodSupportPlan),
        ("check-before-restarting", AnchorTheme.HardTimes, ArticleIds.SmallStepReview),
        ("share-care-work", AnchorTheme.HardTimes, ArticleIds.CaregiverWellbeing),
        ("hard-feeling-not-failure", AnchorTheme.HardTimes, ArticleIds.Emotions),
        ("support-before-crisis", AnchorTheme.HardTimes, ArticleIds.Specialist),
        ("rest-before-finished", AnchorTheme.HardTimes, ArticleIds.Burnout),
        ("nearest-hour-is-enough", AnchorTheme.HardTimes, ArticleIds.Depression),
        ("plans-after-loss-can-shift", AnchorTheme.HardTimes, ArticleIds.Grief),
        ("care-capacity-can-be-stated", AnchorTheme.HardTimes, ArticleIds.CaregiverWellbeing),
        ("notice-what-helps", AnchorTheme.HardTimes, ArticleIds.MoodSupportPlan),

        ("shared-activity-can-connect", AnchorTheme.Relationships, ArticleIds.Loneliness),

        ("exp-call-can-be-short", AnchorTheme.ThoughtsAndFeelings, ArticleIds.CallNerves),
        ("exp-silence-is-not-answer", AnchorTheme.OthersWords, ArticleIds.WaitingForReply),
        ("exp-replay-is-not-proof", AnchorTheme.OthersWords, ArticleIds.AfterSocialEvent),
        ("exp-mistake-can-be-repaired", AnchorTheme.Mistakes, ArticleIds.FearOfMistakes),
        ("exp-unknown-can-wait", AnchorTheme.ThoughtsAndFeelings, ArticleIds.ChangeAnxiety),
        ("exp-start-before-certain", AnchorTheme.ThoughtsAndFeelings, ArticleIds.WorryBeforeTask),
        ("exp-two-minute-start-counts", AnchorTheme.Mistakes, ArticleIds.AvoidedFirstStep),
        ("exp-checking-has-a-limit", AnchorTheme.ThoughtsAndFeelings, ArticleIds.CheckingLoop),
        ("exp-i-can-leave", AnchorTheme.HardTimes, ArticleIds.PublicPlaceAnxiety),
        ("exp-not-whole-week", AnchorTheme.HardTimes, ArticleIds.MorningWorry),
        ("exp-less-input-is-okay", AnchorTheme.HardTimes, ArticleIds.SensoryOverload),
        ("exp-evening-not-decision-time", AnchorTheme.ThoughtsAndFeelings, ArticleIds.EveningTension),
        ("exp-after-anxiety-rest", AnchorTheme.HardTimes, ArticleIds.AnxietyComedown),
        ("exp-practice-with-choice", AnchorTheme.HardTimes, ArticleIds.SafePractice),

        ("exp-thought-not-command", AnchorTheme.ThoughtsAndFeelings, ArticleIds.ThoughtLabel),
        ("exp-assumption-not-fact", AnchorTheme.OthersWords, ArticleIds.MindReading),
        ("exp-worst-not-likeliest", AnchorTheme.ThoughtsAndFeelings, ArticleIds.WorstVsLikely),
        ("exp-facts-and-gaps", AnchorTheme.ThoughtsAndFeelings, ArticleIds.EvidenceAndUnknown),
        ("exp-one-negative-not-whole", AnchorTheme.ThoughtsAndFeelings, ArticleIds.NegativityFilter),
        ("exp-replay-can-stop", AnchorTheme.ThoughtsAndFeelings, ArticleIds.ConversationReplay),
        ("exp-fewer-decisions-help", AnchorTheme.HardTimes, ArticleIds.DecisionFatigue),
        ("exp-enough-can-be-defined", AnchorTheme.Mistakes, ArticleIds.GoodEnough),
        ("exp-influence-not-control", AnchorTheme.ThoughtsAndFeelings, ArticleIds.ControlInfluence),
        ("exp-kind-self-talk", AnchorTheme.Mistakes, ArticleIds.SelfTalkReset),
        ("exp-worry-about-worry", AnchorTheme.ThoughtsAndFeelings, ArticleIds.WorryAboutWorry),
        ("exp-highlight-not-whole", AnchorTheme.OthersWords, ArticleIds.CompareHighlightReel),
        ("exp-uninvited-thoughts", AnchorTheme.ThoughtsAndFeelings, ArticleIds.IntrusiveThoughts),
        ("exp-one-thing-next", AnchorTheme.HardTimes, ArticleIds.OneThingAtATime),

        ("exp-movement-not-test", AnchorTheme.HardTimes, ArticleIds.MoodMovement),
        ("exp-small-pleasure-counts", AnchorTheme.HardTimes, ArticleIds.PleasureMastery),
        ("exp-energy-has-limits", AnchorTheme.HardTimes, ArticleIds.EnergyBudget),
        ("exp-rest-is-in-plan", AnchorTheme.HardTimes, ArticleIds.RestBreak),
        ("exp-start-friction-not-laziness", AnchorTheme.Mistakes, ArticleIds.StartFriction),
        ("exp-transitions-need-space", AnchorTheme.HardTimes, ArticleIds.TransitionRitual),
        ("exp-action-before-motivation", AnchorTheme.Mistakes, ArticleIds.TaskActivation),
        ("exp-routine-can-be-gentle", AnchorTheme.HardTimes, ArticleIds.GentleRoutine),
        ("exp-waking-not-failure", AnchorTheme.HardTimes, ArticleIds.WakeAtNight),
        ("exp-one-day-plan", AnchorTheme.HardTimes, ArticleIds.SmallDayPlan),
        ("exp-ask-for-task-help", AnchorTheme.Relationships, ArticleIds.AskForHelpTask),
        ("exp-meaning-can-be-small", AnchorTheme.HardTimes, ArticleIds.MeaningfulActivity),
        ("exp-goals-can-flex", AnchorTheme.Mistakes, ArticleIds.FlexibleGoals),
        ("exp-completion-is-enough", AnchorTheme.Mistakes, ArticleIds.CelebrateCompletion),

        ("exp-name-not-identity", AnchorTheme.ThoughtsAndFeelings, ArticleIds.NameEmotion),
        ("exp-mixed-feelings-are-real", AnchorTheme.ThoughtsAndFeelings, ArticleIds.MixedFeelings),
        ("exp-pause-makes-choice", AnchorTheme.Relationships, ArticleIds.AngerPause),
        ("exp-shame-needs-kindness", AnchorTheme.Mistakes, ArticleIds.ShameKindness),
        ("exp-guilt-can-guide-repair", AnchorTheme.Mistakes, ArticleIds.GuiltRepair),
        ("exp-envy-shows-a-wish", AnchorTheme.Relationships, ArticleIds.EnvyInformation),
        ("exp-sadness-no-deadline", AnchorTheme.HardTimes, ArticleIds.AllowSadness),
        ("exp-numbness-not-fault", AnchorTheme.HardTimes, ArticleIds.Numbness),
        ("exp-feelings-shift", AnchorTheme.ThoughtsAndFeelings, ArticleIds.EmotionWave),
        ("exp-body-check-optional", AnchorTheme.ThoughtsAndFeelings, ArticleIds.BodyNoticingChoice),
        ("exp-pause-before-reaction", AnchorTheme.Relationships, ArticleIds.PauseBeforeReact),
        ("exp-boundary-can-protect", AnchorTheme.Relationships, ArticleIds.EmotionalBoundary),
        ("exp-feeling-not-action", AnchorTheme.ThoughtsAndFeelings, ArticleIds.PauseBeforeReact),
        ("exp-tears-not-failure", AnchorTheme.HardTimes, ArticleIds.AfterCrying),

        ("exp-specific-request-helps", AnchorTheme.Relationships, ArticleIds.SpecificRequest),
        ("exp-listening-is-help", AnchorTheme.Relationships, ArticleIds.ListenReflect),
        ("exp-boundary-can-be-simple", AnchorTheme.Relationships, ArticleIds.BoundarySentence),
        ("exp-no-needs-no-essay", AnchorTheme.Relationships, ArticleIds.NoWithoutEssay),
        ("exp-opening-sets-tone", AnchorTheme.Relationships, ArticleIds.DifficultTalkOpening),
        ("exp-repair-can-be-small", AnchorTheme.Relationships, ArticleIds.RepairAfterConflict),
        ("exp-apology-names-action", AnchorTheme.Relationships, ArticleIds.ApologyResponsibility),
        ("exp-feedback-not-worth", AnchorTheme.OthersWords, ArticleIds.FeedbackAsInformation),
        ("exp-their-no-not-my-worth", AnchorTheme.OthersWords, ArticleIds.ReceiveNo),
        ("exp-check-assumption", AnchorTheme.OthersWords, ArticleIds.CheckAssumption),
        ("exp-asking-not-demand", AnchorTheme.Relationships, ArticleIds.AskSupport),
        ("exp-support-not-fixing", AnchorTheme.Relationships, ArticleIds.SupportWithoutFixing),
        ("exp-disagreement-not-failure", AnchorTheme.Relationships, ArticleIds.ConflictNotFailure),
        ("exp-clarity-reduces-guessing", AnchorTheme.Relationships, ArticleIds.MakeExpectationsClear),
        ("exp-digital-boundaries-count", AnchorTheme.Relationships, ArticleIds.DigitalBoundaries),
        ("exp-family-pressure-not-capacity", AnchorTheme.Relationships, ArticleIds.FamilyPressure),
        ("exp-invitation-can-be-small", AnchorTheme.Relationships, ArticleIds.FriendshipInvitation),
        ("exp-connection-no-performance", AnchorTheme.Relationships, ArticleIds.SmallConnection),

        ("exp-present-not-past", AnchorTheme.ThoughtsAndFeelings, ArticleIds.OrientNow),
        ("exp-grounding-has-options", AnchorTheme.ThoughtsAndFeelings, ArticleIds.GroundingChoice),
        ("exp-nightmare-is-memory", AnchorTheme.HardTimes, ArticleIds.AfterNightmare),
        ("exp-anniversary-reaction-makes-sense", AnchorTheme.ThoughtsAndFeelings, ArticleIds.AnniversaryReaction),
        ("exp-recovery-at-own-pace", AnchorTheme.HardTimes, ArticleIds.PaceRecovery),
        ("exp-safety-before-exercise", AnchorTheme.HardTimes, ArticleIds.SafetyFirst),
        ("exp-choose-trusted-person", AnchorTheme.Relationships, ArticleIds.ChooseTrustedPerson),
        ("exp-rest-after-stress", AnchorTheme.HardTimes, ArticleIds.AfterStressRecovery),
        ("exp-flashback-no-forcing", AnchorTheme.ThoughtsAndFeelings, ArticleIds.FlashbackGrounding),
        ("exp-recovery-not-linear", AnchorTheme.HardTimes, ArticleIds.RecoveryNotLinear),

        ("exp-breathing-is-optional", AnchorTheme.ThoughtsAndFeelings, ArticleIds.BreathIsOptional),
        ("exp-grounding-can-adapt", AnchorTheme.ThoughtsAndFeelings, ArticleIds.GroundingCanChange),
        ("exp-movement-as-anchor", AnchorTheme.HardTimes, ArticleIds.MovementAnchor),
        ("exp-senses-can-be-chosen", AnchorTheme.ThoughtsAndFeelings, ArticleIds.SensesAnchor),
        ("exp-early-signs-are-info", AnchorTheme.ThoughtsAndFeelings, ArticleIds.EarlyStressSigns),
        ("exp-relaxation-not-performance", AnchorTheme.HardTimes, ArticleIds.RelaxWithoutForce),
        ("exp-basic-care-no-rules", AnchorTheme.HardTimes, ArticleIds.BasicCareWithoutRules),
        ("exp-new-symptoms-deserve-care", AnchorTheme.HardTimes, ArticleIds.NewSymptomsCare),
        ("exp-therapist-fit-can-be-discussed", AnchorTheme.HardTimes, ArticleIds.FindTherapist),
        ("exp-first-appointment-can-start-small", AnchorTheme.HardTimes, ArticleIds.FirstAppointment),
        ("exp-describing-is-enough", AnchorTheme.HardTimes, ArticleIds.DescribeSymptoms),
        ("exp-self-help-has-limits", AnchorTheme.HardTimes, ArticleIds.SelfHelpLimits),

        ("exp-screen-not-diagnosis", AnchorTheme.ThoughtsAndFeelings, ArticleIds.ScreeningNotDiagnosis),
        ("exp-support-plan-simple", AnchorTheme.HardTimes, ArticleIds.SupportPlan),
        ("exp-immediate-safety-first", AnchorTheme.HardTimes, ArticleIds.CrisisSteps),
        ("exp-medication-with-clinician", AnchorTheme.HardTimes, ArticleIds.MedicationWithClinician)
    ];

    private static class ExpandedTranslations
    {
        internal static readonly IReadOnlyDictionary<string, (string Text, string Why)> Russian = Merge(Ru, AdditionalRu);
        internal static readonly IReadOnlyDictionary<string, (string Text, string Why)> English = Merge(En, AdditionalEn);
        internal static readonly IReadOnlyDictionary<string, (string Text, string Why)> French = Merge(Fr, AdditionalFr);
        internal static readonly IReadOnlyDictionary<string, (string Text, string Why)> German = Merge(De, AdditionalDe);
        internal static readonly IReadOnlyDictionary<string, (string Text, string Why)> Spanish = Merge(Es, AdditionalEs);
        internal static readonly IReadOnlyDictionary<string, (string Text, string Why)> Portuguese = Merge(Pt, AdditionalPt);
        internal static readonly IReadOnlyDictionary<string, (string Text, string Why)> Chinese = Merge(Zh, AdditionalZh);

        private static IReadOnlyDictionary<string, (string Text, string Why)> Merge(
            Dictionary<string, (string Text, string Why)> current,
            Dictionary<string, (string Text, string Why)> additional)
        {
            var merged = new Dictionary<string, (string Text, string Why)>(current);
            foreach (KeyValuePair<string, (string Text, string Why)> thought in additional)
                merged.Add(thought.Key, thought.Value);

            return merged;
        }
    }

    /// <summary>The thoughts in a language by its key ("ru", "en", "fr"…); a language without its own gets the English ones.</summary>
    public static IReadOnlyList<AnchorThought> All(string? language)
    {
        IReadOnlyDictionary<string, (string Text, string Why)> texts = language?.ToLowerInvariant() switch
        {
            "ru" => ExpandedTranslations.Russian,
            "fr" => ExpandedTranslations.French,
            "de" => ExpandedTranslations.German,
            "es" => ExpandedTranslations.Spanish,
            "pt" => ExpandedTranslations.Portuguese,
            "zh" => ExpandedTranslations.Chinese,
            _ => ExpandedTranslations.English
        };

        return [.. Entries.Select(entry => new AnchorThought(entry.Id, entry.Theme, texts[entry.Id].Text, texts[entry.Id].Why, entry.ArticleId))];
    }
}
