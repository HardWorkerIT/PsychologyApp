using PsychologyApp.Application.Conversation.Companion;
using PsychologyApp.Application.Practice;
using PsychologyApp.Application.Practice.Catalog;
using PsychologyApp.Domain.Practice;
using Xunit;

namespace PsychologyApp.Application.Tests.Conversation;

public sealed class TechniqueSuggesterContextTests
{
    [Fact]
    public void LonelinessCanOfferTheLowPressureConnectionPlan()
    {
        SituationAnalysis analysis = new(CompanionEmotion.Loneliness, 0.9, false, false, []);

        Assert.Equal(
            [TechniqueId.SelfCompassion, TechniqueId.ConnectionStepPlan],
            TechniqueSuggester.Suggest(analysis));
    }

    [Fact]
    public void MoneyAnxietyCanOfferTheMoneySpecificPlan()
    {
        SituationAnalysis analysis = new(CompanionEmotion.Anxiety, 0.9, false, false, [CompanionTheme.Money]);

        Assert.Equal(
            [TechniqueId.MoneyWorryPlan, TechniqueId.ProblemSolving],
            TechniqueSuggester.Suggest(analysis));
    }

    [Fact]
    public void MoneySpecificSuggestionDoesNotReplaceBodySupportWhenBodySymptomsArePresent()
    {
        SituationAnalysis analysis = new(CompanionEmotion.Anxiety, 0.9, true, false, [CompanionTheme.Money]);

        Assert.Equal(
            [TechniqueId.Grounding, TechniqueId.SensoryComfort],
            TechniqueSuggester.Suggest(analysis));
    }

    [Theory]
    [InlineData("Тревожусь из-за новостей", TechniqueId.NewsCheckPlan)]
    [InlineData("I'm anxious about the news", TechniqueId.NewsCheckPlan)]
    [InlineData("Мне тревожно из-за критики на работе", TechniqueId.FeedbackReview)]
    [InlineData("I'm anxious about the feedback at work", TechniqueId.FeedbackReview)]
    public void Recognized_news_and_feedback_contexts_use_the_matching_practice(string message, TechniqueId expected)
    {
        SituationAnalysis analysis = new LexiconSituationAnalyzer().Analyze(message);

        Assert.Contains(expected, TechniqueSuggester.Suggest(analysis));
    }

    [Fact]
    public void ProcrastinationOffersAPlanForReturningAfterAMissedRoutine()
    {
        SituationAnalysis analysis = new(CompanionEmotion.Procrastination, 0.9, false, false, []);

        Assert.Equal(
            [TechniqueId.ImplementationIntention, TechniqueId.HabitRestartPlan],
            TechniqueSuggester.Suggest(analysis));
    }

    [Fact]
    public void AvoidingBodyFocusOffersExternalOrientation()
    {
        SituationAnalysis analysis = new(CompanionEmotion.Unknown, 0.9, false, false, [])
        {
            AvoidsBodyFocus = true
        };

        Assert.Contains(TechniqueId.ExternalOrientation, TechniqueSuggester.Suggest(analysis));
    }
}

public sealed class SuggestedTechniquePresentationTests
{
    [Theory]
    [InlineData(TechniqueId.ExternalOrientation, false)]
    [InlineData(TechniqueId.ExternalOrientation, true)]
    [InlineData(TechniqueId.MoneyWorryPlan, false)]
    [InlineData(TechniqueId.MoneyWorryPlan, true)]
    [InlineData(TechniqueId.NewsCheckPlan, false)]
    [InlineData(TechniqueId.NewsCheckPlan, true)]
    [InlineData(TechniqueId.HabitRestartPlan, false)]
    [InlineData(TechniqueId.HabitRestartPlan, true)]
    [InlineData(TechniqueId.FeedbackReview, false)]
    [InlineData(TechniqueId.FeedbackReview, true)]
    [InlineData(TechniqueId.ConnectionStepPlan, false)]
    [InlineData(TechniqueId.ConnectionStepPlan, true)]
    public async Task New_suggestions_have_a_localized_title_and_explanation(TechniqueId id, bool english)
    {
        ITechniqueCatalogService catalog = new TechniqueCatalogService(
            new BuiltInTechniqueCatalogProvider(() => english ? "en" : "ru"));

        Assert.Equal((await catalog.GetAsync(id)).PageName, CompanionContent.TechniqueTitle(id, english));
        Assert.False(string.IsNullOrWhiteSpace(CompanionContent.TechniqueWhy(id, english)));
    }
}
