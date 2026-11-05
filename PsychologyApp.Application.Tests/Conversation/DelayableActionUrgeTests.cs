using PsychologyApp.Application.Conversation.Companion;
using PsychologyApp.Domain.Practice;
using Xunit;

namespace PsychologyApp.Application.Tests.Conversation;

public sealed class DelayableActionUrgeTests
{
    private static readonly LexiconSituationAnalyzer Analyzer = new();

    [Theory]
    [InlineData("Злюсь, и тянет написать ему прямо сейчас")]
    [InlineData("I'm angry and want to text him now")]
    public void Recognized_mild_anger_with_a_delayable_action_urge_offers_the_optional_practice(string text)
    {
        SituationAnalysis analysis = Analyzer.Analyze(text);

        Assert.Equal(CompanionEmotion.Anger, analysis.Emotion);
        Assert.True(analysis.HasDelayableActionUrge);
        Assert.Equal(TechniqueId.UrgeSurfing, TechniqueSuggester.Recommend(analysis)[0].Technique);
    }

    [Theory]
    [InlineData("Я злюсь, но не хочется написать ему")]
    [InlineData("I'm angry but don't want to text him")]
    public void A_negated_action_urge_does_not_offer_urge_surfing(string text)
    {
        SituationAnalysis analysis = Analyzer.Analyze(text);

        Assert.False(analysis.HasDelayableActionUrge);
        Assert.DoesNotContain(TechniqueId.UrgeSurfing, TechniqueSuggester.Suggest(analysis));
    }

    [Theory]
    [InlineData("Я злюсь, тянет написать ему, прежде чем ударить его")]
    [InlineData("I'm angry and want to text him before I hit him")]
    [InlineData("Злюсь и тянет написать, но боюсь навредить себе")]
    [InlineData("I'm angry and want to text, but might hurt myself")]
    public void A_detected_harm_urge_suppresses_the_practice(string text)
    {
        SituationAnalysis analysis = Analyzer.Analyze(text);

        Assert.False(analysis.HasDelayableActionUrge);
        Assert.DoesNotContain(TechniqueId.UrgeSurfing, TechniqueSuggester.Suggest(analysis));
    }
}
