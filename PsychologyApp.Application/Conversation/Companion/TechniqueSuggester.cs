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
        ? [new(TechniqueId.Flashback, TechniqueSuggestionReasonCode.Flashback), new(TechniqueId.Grounding, TechniqueSuggestionReasonCode.Flashback)]
        : analysis.Emotion switch
    {
        CompanionEmotion.Panic => Pair(TechniqueSuggestionReasonCode.Panic, TechniqueId.Grounding, TechniqueId.Breathing),
        CompanionEmotion.Anxiety when analysis.HasBodySymptoms => Pair(TechniqueSuggestionReasonCode.AnxietyWithBodySymptoms, TechniqueId.Grounding, TechniqueId.Breathing),
        CompanionEmotion.Anxiety => Pair(TechniqueSuggestionReasonCode.Anxiety, TechniqueId.Observer, TechniqueId.ThoughtRecord),
        CompanionEmotion.Overthinking => Pair(TechniqueSuggestionReasonCode.Overthinking, TechniqueId.Observer, TechniqueId.ThoughtRecord),
        CompanionEmotion.Anger => Pair(TechniqueSuggestionReasonCode.Anger, TechniqueId.Observer, TechniqueId.Breathing),
        CompanionEmotion.Resentment => Pair(TechniqueSuggestionReasonCode.Resentment, TechniqueId.Observer, TechniqueId.Spin),
        CompanionEmotion.Guilt => Pair(TechniqueSuggestionReasonCode.Guilt, TechniqueId.SelfCompassion, TechniqueId.ThoughtRecord),
        CompanionEmotion.Sadness => Pair(TechniqueSuggestionReasonCode.Sadness, TechniqueId.SelfCompassion, TechniqueId.SmallStep),
        CompanionEmotion.Exhaustion => Pair(TechniqueSuggestionReasonCode.Exhaustion, TechniqueId.Breathing, TechniqueId.SmallStep),
        CompanionEmotion.Loneliness => Pair(TechniqueSuggestionReasonCode.Loneliness, TechniqueId.SelfCompassion, TechniqueId.Anchor),
        CompanionEmotion.Procrastination => Pair(TechniqueSuggestionReasonCode.Procrastination, TechniqueId.SmallStep, TechniqueId.Observer),
        _ => Pair(TechniqueSuggestionReasonCode.General, TechniqueId.Breathing, TechniqueId.Grounding)
    };

    private static IReadOnlyList<TechniqueRecommendation> Pair(
        TechniqueSuggestionReasonCode reason,
        TechniqueId first,
        TechniqueId second) => [new(first, reason), new(second, reason)];
}
