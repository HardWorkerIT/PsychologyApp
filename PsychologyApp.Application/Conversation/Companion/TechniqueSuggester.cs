namespace PsychologyApp.Application.Conversation.Companion;

public enum TechniqueSuggestionReasonCode
{
    Flashback,
    Panic,
    AnxietyWithBodySymptoms,
    Anxiety,
    Overthinking,
    Anger,
    Resentment,
    Guilt,
    Sadness,
    Exhaustion,
    Loneliness,
    Procrastination,
    General
}

public sealed record TechniqueRecommendation(TechniqueId Technique, TechniqueSuggestionReasonCode ReasonCode);

/// <summary>Closed, hand-reviewed mapping from a recognised state to practices.</summary>
public static class TechniqueSuggester
{
    public static IReadOnlyList<TechniqueId> Suggest(SituationAnalysis analysis) => [.. Recommend(analysis).Select(item => item.Technique)];

    public static IReadOnlyList<TechniqueRecommendation> Recommend(SituationAnalysis analysis) => analysis.IsFlashback
        ? analysis.AvoidsBodyFocus
            ? Pair(TechniqueSuggestionReasonCode.Flashback, TechniqueId.SensoryComfort, TechniqueId.ThoughtDefusion)
            : [new(TechniqueId.Flashback, TechniqueSuggestionReasonCode.Flashback), new(TechniqueId.Grounding, TechniqueSuggestionReasonCode.Flashback)]
        : analysis.Emotion switch
    {
        CompanionEmotion.Panic when analysis.HasBodySymptoms || analysis.AvoidsBodyFocus => Pair(TechniqueSuggestionReasonCode.Panic, TechniqueId.Grounding, TechniqueId.SensoryComfort),
        CompanionEmotion.Panic => Pair(TechniqueSuggestionReasonCode.Panic, TechniqueId.Grounding, TechniqueId.Breathing),
        CompanionEmotion.Anxiety when analysis.HasBodySymptoms => Pair(TechniqueSuggestionReasonCode.AnxietyWithBodySymptoms, TechniqueId.Grounding, TechniqueId.SensoryComfort),
        CompanionEmotion.Anxiety when CanSuggestDistancedSelfTalk(analysis) => Pair(TechniqueSuggestionReasonCode.Anxiety, TechniqueId.CheckTheFacts, TechniqueId.Observer),
        CompanionEmotion.Anxiety => Pair(TechniqueSuggestionReasonCode.Anxiety, TechniqueId.CheckTheFacts, TechniqueId.ProblemSolving),
        CompanionEmotion.Overthinking => Pair(TechniqueSuggestionReasonCode.Overthinking, TechniqueId.ThoughtDefusion, TechniqueId.WorryTime),
        CompanionEmotion.Anger when analysis.HasBodySymptoms => Pair(TechniqueSuggestionReasonCode.Anger, TechniqueId.Grounding, analysis.AvoidsBodyFocus ? TechniqueId.SensoryComfort : TechniqueId.MuscleRelax),
        CompanionEmotion.Anger when analysis.AvoidsBodyFocus => Pair(TechniqueSuggestionReasonCode.Anger, TechniqueId.CheckTheFacts, TechniqueId.ProblemSolving),
        CompanionEmotion.Anger when analysis.HasDelayableActionUrge && !analysis.HasBodySymptoms && !analysis.IsIntense && !analysis.MentionsTrauma && !analysis.HasLoss && !analysis.EmotionAttributedToOther => Pair(TechniqueSuggestionReasonCode.Anger, TechniqueId.UrgeSurfing, TechniqueId.CheckTheFacts),
        CompanionEmotion.Anger => Pair(TechniqueSuggestionReasonCode.Anger, TechniqueId.PauseBeforeReaction, TechniqueId.CheckTheFacts),
        CompanionEmotion.Resentment when CanSuggestDistancedSelfTalk(analysis) => Pair(TechniqueSuggestionReasonCode.Resentment, TechniqueId.CheckTheFacts, TechniqueId.Observer),
        CompanionEmotion.Resentment => Pair(TechniqueSuggestionReasonCode.Resentment, TechniqueId.ThoughtDefusion, TechniqueId.CheckTheFacts),
        CompanionEmotion.Guilt => Pair(TechniqueSuggestionReasonCode.Guilt, TechniqueId.SelfCompassion, TechniqueId.ThoughtRecord),
        CompanionEmotion.Sadness => Pair(TechniqueSuggestionReasonCode.Sadness, TechniqueId.SelfCompassion, TechniqueId.SmallStep),
        CompanionEmotion.Exhaustion when analysis.AvoidsBodyFocus => Pair(TechniqueSuggestionReasonCode.Exhaustion, TechniqueId.SmallStep, TechniqueId.SensoryComfort),
        CompanionEmotion.Exhaustion => Pair(TechniqueSuggestionReasonCode.Exhaustion, TechniqueId.Breathing, TechniqueId.SmallStep),
        CompanionEmotion.Loneliness => Pair(TechniqueSuggestionReasonCode.Loneliness, TechniqueId.SelfCompassion, TechniqueId.SmallStep),
        CompanionEmotion.Procrastination => Pair(TechniqueSuggestionReasonCode.Procrastination, TechniqueId.ImplementationIntention, TechniqueId.SmallStep),
        _ when analysis.AvoidsBodyFocus => Pair(TechniqueSuggestionReasonCode.General, TechniqueId.ThoughtDefusion, TechniqueId.SensoryComfort),
        _ => Pair(TechniqueSuggestionReasonCode.General, TechniqueId.Breathing, TechniqueId.Grounding)
    };

    private static bool CanSuggestDistancedSelfTalk(SituationAnalysis analysis) =>
        !analysis.HasBodySymptoms &&
        !analysis.IsIntense &&
        !analysis.MentionsTrauma &&
        !analysis.HasLoss &&
        !analysis.EmotionAttributedToOther &&
        (analysis.Event is CompanionEvent.Conflict or CompanionEvent.Humiliation or CompanionEvent.Performance);

    private static IReadOnlyList<TechniqueRecommendation> Pair(
        TechniqueSuggestionReasonCode reason,
        TechniqueId first,
        TechniqueId second) => [new(first, reason), new(second, reason)];
}
