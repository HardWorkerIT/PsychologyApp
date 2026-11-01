using PsychologyApp.Application.Conversation.Companion;
using Xunit;

namespace PsychologyApp.Application.Tests.Chat;

public class CompanionPromptBuilderTests
{
    [Theory]
    [InlineData(false, CompanionTheme.Study, CompanionEmotion.Anxiety, "экзамен", "Партнёр часто отменяет")]
    [InlineData(true, CompanionTheme.Study, CompanionEmotion.Anxiety, "exam", "My partner keeps cancelling")]
    [InlineData(false, CompanionTheme.Work, CompanionEmotion.Exhaustion, "срочные задачи", "Завтра экзамен")]
    [InlineData(true, CompanionTheme.Work, CompanionEmotion.Exhaustion, "urgent tasks", "exam tomorrow")]
    [InlineData(false, CompanionTheme.Relationships, CompanionEmotion.Sadness, "Мы расстались", "После сокращения")]
    [InlineData(true, CompanionTheme.Relationships, CompanionEmotion.Sadness, "We broke up", "I was laid off")]
    [InlineData(false, CompanionTheme.Family, CompanionEmotion.Loneliness, "Родные живут далеко", "Подруга постоянно")]
    [InlineData(true, CompanionTheme.Family, CompanionEmotion.Loneliness, "My family lives far away", "My friend keeps asking")]
    [InlineData(false, CompanionTheme.Health, CompanionEmotion.Exhaustion, "постоянной боли", "срочные задачи")]
    [InlineData(true, CompanionTheme.Health, CompanionEmotion.Exhaustion, "constant pain", "urgent tasks")]
    [InlineData(false, CompanionTheme.Money, CompanionEmotion.Guilt, "Набрала долгов", "контрольную")]
    [InlineData(true, CompanionTheme.Money, CompanionEmotion.Guilt, "got into debt", "failed a test")]
    [InlineData(false, CompanionTheme.Work, CompanionEmotion.Resentment, "Коллега представил мою идею", "Завтра экзамен")]
    [InlineData(true, CompanionTheme.Work, CompanionEmotion.Resentment, "A coworker presented my idea", "I have an exam")]
    [InlineData(false, CompanionTheme.Work, CompanionEmotion.Guilt, "Пропустил важную цифру", "Родные живут далеко")]
    [InlineData(true, CompanionTheme.Work, CompanionEmotion.Guilt, "I missed an important number", "My family lives far away")]
    [InlineData(false, CompanionTheme.Relationships, CompanionEmotion.Anger, "Партнёр прочитал моё сообщение", "мама часто")]
    [InlineData(true, CompanionTheme.Relationships, CompanionEmotion.Anger, "My partner read my message", "My mom is often")]
    [InlineData(false, CompanionTheme.Relationships, CompanionEmotion.Loneliness, "Мы почти не разговариваем", "Пропустил важную цифру")]
    [InlineData(true, CompanionTheme.Relationships, CompanionEmotion.Loneliness, "We barely talk in the evenings", "I missed an important number")]
    [InlineData(false, CompanionTheme.Family, CompanionEmotion.Anxiety, "Мама часто болеет", "Партнёр прочитал моё сообщение")]
    [InlineData(true, CompanionTheme.Family, CompanionEmotion.Anxiety, "My mom is often unwell", "My partner read my message")]
    [InlineData(false, CompanionTheme.Health, CompanionEmotion.Overthinking, "После приёма снова и снова", "каждую покупку")]
    [InlineData(true, CompanionTheme.Health, CompanionEmotion.Overthinking, "After the appointment, I keep replaying", "count every purchase")]
    [InlineData(false, CompanionTheme.Money, CompanionEmotion.Exhaustion, "Каждый месяц приходится считать", "Готовлюсь к сессии")]
    [InlineData(true, CompanionTheme.Money, CompanionEmotion.Exhaustion, "Every month I have to count", "studying for exams")]
    [InlineData(false, CompanionTheme.Study, CompanionEmotion.Exhaustion, "Готовлюсь к сессии", "Каждый месяц приходится считать")]
    [InlineData(true, CompanionTheme.Study, CompanionEmotion.Exhaustion, "studying for exams for weeks", "count every purchase")]
    public void PromptSelectsRelevantExamplesInRussianAndEnglish(
        bool english,
        CompanionTheme theme,
        CompanionEmotion emotion,
        string relevantExample,
        string unrelatedExample)
    {
        SituationAnalysis analysis = new(emotion, 0.9, false, false, [theme]);

        LlmRequest request = CompanionPromptBuilder.Build(english, [], analysis);
        string examples = string.Join("\n", request.Messages.Select(message => message.Content));

        Assert.Contains(relevantExample, examples, StringComparison.OrdinalIgnoreCase);
        Assert.DoesNotContain(unrelatedExample, examples, StringComparison.OrdinalIgnoreCase);
        Assert.InRange(request.Messages.Count, 2, 6);
        Assert.Contains(english ? "different areas of life" : "разные темы жизни", request.SystemPrompt, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void PromptKeepsRecentDialogueAndAddsOnlySmallGenericFallbackForUnknownState()
    {
        LlmMessage[] turns =
        [
            new(LlmRole.User, "Сначала было много задач."),
            new(LlmRole.Assistant, "Похоже, нагрузка вас утомила."),
            new(LlmRole.User, "А теперь ещё и учёба навалилась.")
        ];

        LlmRequest request = CompanionPromptBuilder.Build(false, turns, SituationAnalysis.Empty);

        Assert.Equal(turns, request.Messages.TakeLast(turns.Length));
        Assert.Contains(request.Messages, message => message.Content.Contains("дел слишком много", StringComparison.OrdinalIgnoreCase));
        Assert.True(request.Messages.Count <= 5);
    }
}
