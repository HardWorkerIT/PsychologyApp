namespace PsychologyApp.Application.Articles;

/// <param name="Key">Stable, language-neutral: the filter chips use it.</param>
public sealed record ArticleSection(string Key, string Title, IReadOnlyList<Article> Articles);

public static partial class ArticleContent
{
    /// <summary>The sections of the Articles tab and the order of articles in them; every article is in exactly one (tested).</summary>
    private static readonly (string Key, string Russian, string English, string[] Ids)[] Layout =
    [
        ("anxiety", "Тревога и страх", "Anxiety and fear",
            [ArticleIds.Anxiety, ArticleIds.Panic, ArticleIds.Avoidance, ArticleIds.ExamAnxiety, ArticleIds.SocialAnxiety, ArticleIds.HealthAnxiety, ArticleIds.Ocd,
             ArticleIds.CallNerves, ArticleIds.WaitingForReply, ArticleIds.AfterSocialEvent, ArticleIds.FearOfMistakes, ArticleIds.ChangeAnxiety, ArticleIds.WorryBeforeTask, ArticleIds.AvoidedFirstStep, ArticleIds.CheckingLoop, ArticleIds.PublicPlaceAnxiety, ArticleIds.MorningWorry, ArticleIds.SensoryOverload, ArticleIds.EveningTension, ArticleIds.AnxietyComedown, ArticleIds.SafePractice]),
        ("thoughts", "Мысли", "Thoughts",
            [ArticleIds.Thoughts, ArticleIds.Rumination, ArticleIds.WorryTime, ArticleIds.Uncertainty, ArticleIds.MoneyStress, ArticleIds.NewsLoop, ArticleIds.ProblemPlanning, ArticleIds.Overwhelm, ArticleIds.ValuesAction, ArticleIds.Perfectionism, ArticleIds.Procrastination, ArticleIds.HabitFormation,
             ArticleIds.ThoughtLabel, ArticleIds.MindReading, ArticleIds.WorstVsLikely, ArticleIds.EvidenceAndUnknown, ArticleIds.NegativityFilter, ArticleIds.ConversationReplay, ArticleIds.DecisionFatigue, ArticleIds.GoodEnough, ArticleIds.ControlInfluence, ArticleIds.SelfTalkReset, ArticleIds.WorryAboutWorry, ArticleIds.CompareHighlightReel, ArticleIds.IntrusiveThoughts, ArticleIds.OneThingAtATime]),
        ("energy", "Силы и настроение", "Energy and mood",
            [ArticleIds.Depression, ArticleIds.LowMood, ArticleIds.MoodSupportPlan, ArticleIds.SmallStepReview, ArticleIds.Burnout, ArticleIds.WorkRecovery, ArticleIds.Sleep, ArticleIds.Loneliness,
             ArticleIds.MoodMovement, ArticleIds.PleasureMastery, ArticleIds.EnergyBudget, ArticleIds.RestBreak, ArticleIds.StartFriction, ArticleIds.TransitionRitual, ArticleIds.TaskActivation, ArticleIds.GentleRoutine, ArticleIds.WakeAtNight, ArticleIds.SmallDayPlan, ArticleIds.AskForHelpTask, ArticleIds.MeaningfulActivity, ArticleIds.FlexibleGoals, ArticleIds.CelebrateCompletion]),
        ("feelings", "Чувства", "Feelings",
            [ArticleIds.Emotions, ArticleIds.Anger, ArticleIds.SelfCriticism, ArticleIds.Feedback, ArticleIds.SelfEsteem, ArticleIds.ShameAndGuilt, ArticleIds.JealousyAndEnvy, ArticleIds.Grief, ArticleIds.Numbing,
             ArticleIds.NameEmotion, ArticleIds.MixedFeelings, ArticleIds.AngerPause, ArticleIds.ShameKindness, ArticleIds.GuiltRepair, ArticleIds.EnvyInformation, ArticleIds.AllowSadness, ArticleIds.Numbness, ArticleIds.EmotionWave, ArticleIds.BodyNoticingChoice, ArticleIds.PauseBeforeReact, ArticleIds.EmotionalBoundary, ArticleIds.AfterCrying]),
        ("trauma", "Травма", "Trauma",
            [ArticleIds.TraumaStart, ArticleIds.TraumaReaction, ArticleIds.TraumaFlashbacks, ArticleIds.TraumaNightmares, ArticleIds.TraumaTreatment, ArticleIds.TraumaGrounding,
             ArticleIds.OrientNow, ArticleIds.GroundingChoice, ArticleIds.AfterNightmare, ArticleIds.AnniversaryReaction, ArticleIds.PaceRecovery, ArticleIds.SafetyFirst, ArticleIds.ChooseTrustedPerson, ArticleIds.AfterStressRecovery, ArticleIds.FlashbackGrounding, ArticleIds.RecoveryNotLinear]),
        ("relationships", "Отношения", "Relationships",
            [ArticleIds.Boundaries, ArticleIds.Conflicts, ArticleIds.ConversationRepair, ArticleIds.Breakup, ArticleIds.Narcissism, ArticleIds.EmotionalAbuse, ArticleIds.ParentStress, ArticleIds.HelpingLovedOne, ArticleIds.CaregiverWellbeing, ArticleIds.SupportRequest,
             ArticleIds.SpecificRequest, ArticleIds.ListenReflect, ArticleIds.BoundarySentence, ArticleIds.NoWithoutEssay, ArticleIds.DifficultTalkOpening, ArticleIds.RepairAfterConflict, ArticleIds.ApologyResponsibility, ArticleIds.FeedbackAsInformation, ArticleIds.ReceiveNo, ArticleIds.CheckAssumption, ArticleIds.AskSupport, ArticleIds.SupportWithoutFixing, ArticleIds.ConflictNotFailure, ArticleIds.MakeExpectationsClear, ArticleIds.DigitalBoundaries, ArticleIds.FamilyPressure, ArticleIds.FriendshipInvitation, ArticleIds.SmallConnection,
             ArticleIds.DeadlineConversation, ArticleIds.DifficultMessageReply, ArticleIds.CancelPlans]),
        ("help", "Тело и помощь", "Body and help",
            [ArticleIds.BodyAndStress, ArticleIds.Mindfulness, ArticleIds.ChronicPain, ArticleIds.Specialist, ArticleIds.SupportInCrisis,
             ArticleIds.BreathIsOptional, ArticleIds.GroundingCanChange, ArticleIds.MovementAnchor, ArticleIds.SensesAnchor, ArticleIds.EarlyStressSigns, ArticleIds.RelaxWithoutForce, ArticleIds.BasicCareWithoutRules, ArticleIds.NewSymptomsCare, ArticleIds.FindTherapist, ArticleIds.FirstAppointment, ArticleIds.DescribeSymptoms, ArticleIds.SelfHelpLimits]),
        ("recognise", "Распознать и обратиться", "Recognise and get help",
            [ArticleIds.EatingDisorders, ArticleIds.Bipolar, ArticleIds.Psychosis, ArticleIds.AttentionAssessment,
             ArticleIds.ScreeningNotDiagnosis, ArticleIds.SupportPlan, ArticleIds.CrisisSteps, ArticleIds.MedicationWithClinician])
    ];

    /// <summary>The section titles of the other languages, in the order of <see cref="Layout"/>.</summary>
    private static readonly string[] SectionsFr =
        ["Anxiété et peur", "Pensées", "Énergie et humeur", "Émotions", "Traumatisme", "Relations", "Corps et aide", "Reconnaître et se faire aider"];

    private static readonly string[] SectionsDe =
        ["Angst und Furcht", "Gedanken", "Kraft und Stimmung", "Gefühle", "Trauma", "Beziehungen", "Körper und Hilfe", "Erkennen und Hilfe holen"];

    private static readonly string[] SectionsEs =
        ["Ansiedad y miedo", "Pensamientos", "Energía y ánimo", "Emociones", "Trauma", "Relaciones", "Cuerpo y ayuda", "Reconocer y pedir ayuda"];

    private static readonly string[] SectionsPt =
        ["Ansiedade e medo", "Pensamentos", "Energia e humor", "Emoções", "Trauma", "Relacionamentos", "Corpo e ajuda", "Reconhecer e buscar ajuda"];

    private static readonly string[] SectionsZh =
        ["焦虑与恐惧", "想法", "精力与情绪", "情绪感受", "创伤", "人际关系", "身体与求助", "识别与求助"];

    public static IReadOnlyList<ArticleSection> Sections(string? language) =>
        Layout
            .Select((section, index) => new ArticleSection(
                section.Key,
                InLanguage(language, section.Russian, section.English, SectionsFr[index], SectionsDe[index], SectionsEs[index], SectionsPt[index], SectionsZh[index]),
                section.Ids.Select(id => Find(id, language)).OfType<Article>().ToList()))
            .ToList();
}
