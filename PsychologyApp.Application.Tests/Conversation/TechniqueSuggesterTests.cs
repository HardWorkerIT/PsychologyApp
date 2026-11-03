using PsychologyApp.Application.Conversation.Companion;
using PsychologyApp.Domain.Practice;
using Xunit;

namespace PsychologyApp.Application.Tests.Conversation;

public sealed class TechniqueSuggesterTests
{
    [Theory]
    [InlineData(CompanionEmotion.Anxiety, false, TechniqueSuggestionReasonCode.Anxiety, TechniqueId.Observer)]
    [InlineData(CompanionEmotion.Anxiety, true, TechniqueSuggestionReasonCode.AnxietyWithBodySymptoms, TechniqueId.Grounding)]
    [InlineData(CompanionEmotion.Panic, false, TechniqueSuggestionReasonCode.Panic, TechniqueId.Grounding)]
    [InlineData(CompanionEmotion.Guilt, false, TechniqueSuggestionReasonCode.Guilt, TechniqueId.SelfCompassion)]
    public void Each_recommendation_has_a_reason_matching_the_rules_that_selected_it(
        CompanionEmotion emotion,
        bool hasBodySymptoms,
        TechniqueSuggestionReasonCode reason,
        TechniqueId firstTechnique)
    {
        SituationAnalysis analysis = new(emotion, 0.8, hasBodySymptoms, false, []);

        IReadOnlyList<TechniqueRecommendation> recommendations = TechniqueSuggester.Recommend(analysis);

        Assert.Equal(firstTechnique, recommendations[0].Technique);
        Assert.All(recommendations, recommendation => Assert.Equal(reason, recommendation.ReasonCode));
        Assert.Equal(TechniqueSuggester.Suggest(analysis), recommendations.Select(item => item.Technique));
    }
}
