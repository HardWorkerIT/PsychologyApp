using PsychologyApp.Application.Conversation.Companion;
using PsychologyApp.Domain.Practice;
using Xunit;

namespace PsychologyApp.Application.Tests.Conversation;

public sealed class TechniqueSuggesterTests
{
    private static readonly TechniqueId[] ArchivedTechniqueIds =
    [
        TechniqueId.Spin,
        TechniqueId.Hack,
        TechniqueId.Experience,
        TechniqueId.Copied,
        TechniqueId.Resize,
        TechniqueId.Check,
        TechniqueId.Anchor,
        TechniqueId.Comparison,
        TechniqueId.Polarity,
        TechniqueId.Paper,
        TechniqueId.Future
    ];

    [Theory]
    [InlineData(CompanionEmotion.Anxiety, false, TechniqueSuggestionReasonCode.Anxiety, TechniqueId.CheckTheFacts, TechniqueId.ProblemSolving)]
    [InlineData(CompanionEmotion.Anxiety, true, TechniqueSuggestionReasonCode.AnxietyWithBodySymptoms, TechniqueId.Grounding, TechniqueId.SensoryComfort)]
    [InlineData(CompanionEmotion.Panic, false, TechniqueSuggestionReasonCode.Panic, TechniqueId.Grounding, TechniqueId.Breathing)]
    [InlineData(CompanionEmotion.Guilt, false, TechniqueSuggestionReasonCode.Guilt, TechniqueId.SelfCompassion, TechniqueId.ThoughtRecord)]
    [InlineData(CompanionEmotion.Overthinking, false, TechniqueSuggestionReasonCode.Overthinking, TechniqueId.ThoughtDefusion, TechniqueId.WorryTime)]
    [InlineData(CompanionEmotion.Anger, true, TechniqueSuggestionReasonCode.Anger, TechniqueId.Grounding, TechniqueId.MuscleRelax)]
    [InlineData(CompanionEmotion.Anger, false, TechniqueSuggestionReasonCode.Anger, TechniqueId.PauseBeforeReaction, TechniqueId.CheckTheFacts)]
    [InlineData(CompanionEmotion.Resentment, false, TechniqueSuggestionReasonCode.Resentment, TechniqueId.ThoughtDefusion, TechniqueId.CheckTheFacts)]
    [InlineData(CompanionEmotion.Loneliness, false, TechniqueSuggestionReasonCode.Loneliness, TechniqueId.SelfCompassion, TechniqueId.SmallStep)]
    [InlineData(CompanionEmotion.Procrastination, false, TechniqueSuggestionReasonCode.Procrastination, TechniqueId.ImplementationIntention, TechniqueId.SmallStep)]
    public void Each_recommendation_has_a_reason_matching_the_rules_that_selected_it(
        CompanionEmotion emotion,
        bool hasBodySymptoms,
        TechniqueSuggestionReasonCode reason,
        TechniqueId firstTechnique,
        TechniqueId secondTechnique)
    {
        SituationAnalysis analysis = new(emotion, 0.8, hasBodySymptoms, false, []);

        IReadOnlyList<TechniqueRecommendation> recommendations = TechniqueSuggester.Recommend(analysis);

        Assert.Equal(firstTechnique, recommendations[0].Technique);
        Assert.Equal(secondTechnique, recommendations[1].Technique);
        Assert.Equal(2, recommendations.Select(item => item.Technique).Distinct().Count());
        Assert.All(recommendations, recommendation => Assert.Equal(reason, recommendation.ReasonCode));
        Assert.All(recommendations, recommendation => Assert.DoesNotContain(recommendation.Technique, ArchivedTechniqueIds));
        Assert.Equal(TechniqueSuggester.Suggest(analysis), recommendations.Select(item => item.Technique));
    }

    [Theory]
    [InlineData("После того как мы поссорились, мне тревожно", CompanionEvent.Conflict, CompanionEmotion.Anxiety)]
    [InlineData("Меня унизили при всех, мне тревожно", CompanionEvent.Humiliation, CompanionEmotion.Resentment)]
    [InlineData("Перед выступлением мне тревожно", CompanionEvent.Performance, CompanionEmotion.Anxiety)]
    public void Mild_social_stress_messages_offer_distanced_self_talk(
        string message,
        CompanionEvent expectedSituation,
        CompanionEmotion expectedEmotion)
    {
        SituationAnalysis analysis = new LexiconSituationAnalyzer().Analyze(message);

        Assert.Equal(expectedEmotion, analysis.Emotion);
        Assert.Equal(expectedSituation, analysis.Event);
        Assert.Equal(
            new[] { TechniqueId.CheckTheFacts, TechniqueId.Observer },
            TechniqueSuggester.Suggest(analysis));
    }

    [Theory]
    [InlineData(CompanionEvent.Conflict)]
    [InlineData(CompanionEvent.Humiliation)]
    [InlineData(CompanionEvent.Performance)]
    public void Mild_social_anxiety_offers_distanced_self_talk(CompanionEvent situation)
    {
        SituationAnalysis analysis = new(CompanionEmotion.Anxiety, 0.8, false, false, [])
        {
            Event = situation
        };

        Assert.Equal(
            new[] { TechniqueId.CheckTheFacts, TechniqueId.Observer },
            TechniqueSuggester.Suggest(analysis));
    }

    [Theory]
    [InlineData(true, false, false, false, false)]
    [InlineData(false, true, false, false, false)]
    [InlineData(false, false, true, false, false)]
    [InlineData(false, false, false, true, false)]
    [InlineData(false, false, false, false, true)]
    public void Distanced_self_talk_is_not_suggested_for_body_or_higher_risk_states(
        bool hasBodySymptoms,
        bool isIntense,
        bool mentionsTrauma,
        bool hasLoss,
        bool emotionAttributedToOther)
    {
        SituationAnalysis analysis = new(CompanionEmotion.Anxiety, 0.8, hasBodySymptoms, isIntense, [])
        {
            Event = CompanionEvent.Conflict,
            MentionsTrauma = mentionsTrauma,
            HasLoss = hasLoss,
            EmotionAttributedToOther = emotionAttributedToOther
        };

        Assert.DoesNotContain(TechniqueId.Observer, TechniqueSuggester.Suggest(analysis));
    }

    [Fact]
    public void Trauma_related_humiliation_keeps_the_standard_resentment_support()
    {
        SituationAnalysis analysis = new(CompanionEmotion.Resentment, 0.8, false, false, [])
        {
            Event = CompanionEvent.Humiliation,
            MentionsTrauma = true
        };

        Assert.Equal(
            new[] { TechniqueId.ThoughtDefusion, TechniqueId.CheckTheFacts },
            TechniqueSuggester.Suggest(analysis));
    }

    [Theory]
    [InlineData(CompanionEvent.Breakup)]
    [InlineData(CompanionEvent.HealthWorry)]
    public void Distanced_self_talk_is_limited_to_social_or_performance_stress(CompanionEvent situation)
    {
        SituationAnalysis analysis = new(CompanionEmotion.Anxiety, 0.8, false, false, [])
        {
            Event = situation
        };

        Assert.DoesNotContain(TechniqueId.Observer, TechniqueSuggester.Suggest(analysis));
    }

    [Fact]
    public void A_mild_delayable_action_urge_uses_urge_surfing_and_check_the_facts()
    {
        SituationAnalysis analysis = new(CompanionEmotion.Anger, 0.8, false, false, [])
        {
            HasDelayableActionUrge = true
        };

        Assert.Equal(
            new[] { TechniqueId.UrgeSurfing, TechniqueId.CheckTheFacts },
            TechniqueSuggester.Suggest(analysis));
    }

    [Fact]
    public void Intense_or_trauma_related_anger_does_not_route_to_urge_surfing()
    {
        SituationAnalysis[] analyses =
        [
            new(CompanionEmotion.Anger, 0.8, false, true, []) { HasDelayableActionUrge = true },
            new(CompanionEmotion.Anger, 0.8, false, false, []) { HasDelayableActionUrge = true, MentionsTrauma = true },
            new(CompanionEmotion.Anger, 0.8, false, false, []) { HasDelayableActionUrge = true, EmotionAttributedToOther = true }
        ];

        Assert.All(analyses, analysis => Assert.DoesNotContain(TechniqueId.UrgeSurfing, TechniqueSuggester.Suggest(analysis)));
    }

}
