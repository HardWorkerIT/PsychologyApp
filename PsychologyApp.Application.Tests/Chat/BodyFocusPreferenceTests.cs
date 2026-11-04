using PsychologyApp.Application.Chat;
using PsychologyApp.Application.Conversation;
using PsychologyApp.Application.Conversation.Companion;
using PsychologyApp.Domain.Practice;
using Xunit;

namespace PsychologyApp.Application.Tests.Chat;

public sealed class BodyFocusPreferenceTests
{
    [Theory]
    [InlineData("Я не хочу дыхательные упражнения")]
    [InlineData("Я не хочу делать дыхательную практику")]
    [InlineData("Не предлагай дыхательные практики, пожалуйста")]
    [InlineData("Не хочу фокусироваться на теле")]
    [InlineData("Мне хуже от дыхания")]
    [InlineData("I don't want breathing exercises")]
    [InlineData("I don't want a breathing exercise")]
    [InlineData("Don't suggest breathwork")]
    [InlineData("I'd rather not focus on my body")]
    [InlineData("I don't like breathing exercises")]
    [InlineData("I don't want to focus on my body")]
    [InlineData("Breathing makes it worse")]
    public void Recognises_explicit_requests_to_avoid_body_focused_practices(string text)
    {
        SituationAnalysis analysis = new LexiconSituationAnalyzer().Analyze(text);

        Assert.True(analysis.AvoidsBodyFocus);
    }

    [Theory]
    [InlineData("Паника, но дыхательная практика иногда помогает")]
    [InlineData("I want a breathing exercise")]
    [InlineData("I have no breathing problems")]
    public void Does_not_treat_mentions_or_requests_as_a_body_focus_refusal(string text)
    {
        SituationAnalysis analysis = new LexiconSituationAnalyzer().Analyze(text);

        Assert.False(analysis.AvoidsBodyFocus);
    }

    [Theory]
    [InlineData("Я хочу дыхательное упражнение")]
    [InlineData("Давай дыхательную практику")]
    [InlineData("I want a breathing exercise")]
    [InlineData("I'm open to breathing exercises")]
    public void Recognises_an_explicit_request_or_permission_to_use_breathing(string text)
    {
        SituationAnalysis analysis = new LexiconSituationAnalyzer().Analyze(text);

        Assert.True(analysis.AllowsBodyFocus);
        Assert.False(analysis.AvoidsBodyFocus);
    }

    [Theory]
    [InlineData(CompanionEmotion.Panic, false, TechniqueSuggestionReasonCode.Panic, TechniqueId.Grounding, TechniqueId.SensoryComfort)]
    [InlineData(CompanionEmotion.Anger, true, TechniqueSuggestionReasonCode.Anger, TechniqueId.Grounding, TechniqueId.SensoryComfort)]
    [InlineData(CompanionEmotion.Exhaustion, false, TechniqueSuggestionReasonCode.Exhaustion, TechniqueId.SmallStep, TechniqueId.SensoryComfort)]
    [InlineData(CompanionEmotion.Unknown, false, TechniqueSuggestionReasonCode.General, TechniqueId.ThoughtDefusion, TechniqueId.SensoryComfort)]
    public void Recommendations_respect_an_explicit_body_focus_refusal(
        CompanionEmotion emotion,
        bool hasBodySymptoms,
        TechniqueSuggestionReasonCode reason,
        TechniqueId first,
        TechniqueId second)
    {
        SituationAnalysis analysis = new(emotion, 0.8, hasBodySymptoms, false, []) { AvoidsBodyFocus = true };

        IReadOnlyList<TechniqueRecommendation> result = TechniqueSuggester.Recommend(analysis);

        Assert.Equal([first, second], result.Select(item => item.Technique));
        Assert.All(result, item => Assert.Equal(reason, item.ReasonCode));
        Assert.DoesNotContain(TechniqueId.Breathing, result.Select(item => item.Technique));
        Assert.DoesNotContain(TechniqueId.MuscleRelax, result.Select(item => item.Technique));
    }

    [Fact]
    public void A_panic_message_with_an_explicit_refusal_does_not_offer_breathing()
    {
        SituationAnalysis analysis = new LexiconSituationAnalyzer().Analyze("Паника, не хочу дыхательные упражнения");

        Assert.Equal(CompanionEmotion.Panic, analysis.Emotion);
        Assert.True(analysis.AvoidsBodyFocus);
        Assert.Equal(
            [TechniqueId.Grounding, TechniqueId.SensoryComfort],
            TechniqueSuggester.Suggest(analysis));
    }

    [Fact]
    public void Explicit_avoidance_is_kept_in_the_chat_state_until_the_person_changes_it()
    {
        CompanionDialogue dialogue = new(new LexiconSituationAnalyzer(), new KeywordCrisisDetector(), english: false, new Random(3));

        CompanionReply first = Say(dialogue, new CompanionState(), "Я вымотался и не хочу дыхательных упражнений");
        Assert.True(first.State.AvoidsBodyFocus);

        CompanionState restored = CompanionState.Deserialize(first.State.Serialize());
        Assert.True(restored.AvoidsBodyFocus);

        CompanionReply second = Say(dialogue, restored, "Всё равно переживаю из-за работы");
        Assert.True(second.State.AvoidsBodyFocus);

        CompanionReply reset = Say(dialogue, second.State, "Я хочу дыхательное упражнение");
        Assert.False(reset.State.AvoidsBodyFocus);
    }

    [Fact]
    public void Explicit_body_practice_selection_clears_the_conversation_opt_out()
    {
        CompanionDialogue dialogue = new(new LexiconSituationAnalyzer(), new KeywordCrisisDetector(), english: false, new Random(3));
        CompanionState state = new() { Emotion = nameof(CompanionEmotion.Guilt), AvoidsBodyFocus = true, Turns = 2 };

        CompanionReply reply = dialogue.Respond(
            state,
            new CompanionInput.QuickReply(new ChatQuickReply(ChatQuickReplyKinds.Act, "Практика для тела", "body")));

        Assert.False(reply.State.AvoidsBodyFocus);
        Assert.Contains(reply.QuickReplies, item => item.Payload == TechniqueId.Breathing.ToString());
    }

    private static CompanionReply Say(CompanionDialogue dialogue, CompanionState state, string text) =>
        dialogue.Respond(state, new CompanionInput.FreeText(text));
}
