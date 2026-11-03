using PsychologyApp.Application.Conversation.Companion;
using PsychologyApp.Domain.Practice;
using Xunit;

namespace PsychologyApp.Application.Tests.Conversation;

public sealed class TechniqueSuggesterTests
{
    [Theory]
    [InlineData(CompanionEmotion.Anxiety, false, TechniqueSuggestionReasonCode.Anxiety, TechniqueId.Observer, TechniqueId.ThoughtRecord)]
    [InlineData(CompanionEmotion.Anxiety, true, TechniqueSuggestionReasonCode.AnxietyWithBodySymptoms, TechniqueId.Grounding, TechniqueId.Breathing)]
    [InlineData(CompanionEmotion.Panic, false, TechniqueSuggestionReasonCode.Panic, TechniqueId.Grounding, TechniqueId.Breathing)]
    [InlineData(CompanionEmotion.Guilt, false, TechniqueSuggestionReasonCode.Guilt, TechniqueId.SelfCompassion, TechniqueId.ThoughtRecord)]
    [InlineData(CompanionEmotion.Overthinking, false, TechniqueSuggestionReasonCode.Overthinking, TechniqueId.Observer, TechniqueId.BusyMind)]
    [InlineData(CompanionEmotion.Anger, true, TechniqueSuggestionReasonCode.Anger, TechniqueId.Observer, TechniqueId.MuscleRelax)]
    [InlineData(CompanionEmotion.Anger, false, TechniqueSuggestionReasonCode.Anger, TechniqueId.Observer, TechniqueId.Breathing)]
    [InlineData(CompanionEmotion.Resentment, false, TechniqueSuggestionReasonCode.Resentment, TechniqueId.Observer, TechniqueId.Paper)]
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
        Assert.Equal(TechniqueSuggester.Suggest(analysis), recommendations.Select(item => item.Technique));
    }
}
