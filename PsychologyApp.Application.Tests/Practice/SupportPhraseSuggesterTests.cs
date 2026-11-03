using PsychologyApp.Application.Conversation;
using PsychologyApp.Application.Practice;
using PsychologyApp.Domain.Practice;
using Xunit;

namespace PsychologyApp.Application.Tests.Practice;

public class SupportPhraseSuggesterTests
{
    private static SupportPhraseSuggester Create() => new(new KeywordCrisisDetector());

    [Theory]
    [InlineData(EntryFieldRole.None)]
    [InlineData(EntryFieldRole.Problem)]
    [InlineData(EntryFieldRole.Emotion)]
    public async Task Other_fields_get_no_phrases(EntryFieldRole role)
    {
        Assert.Empty(await Create().SuggestAsync(role, "что угодно", "ru"));
    }

    [Fact]
    public async Task A_reframe_fits_the_trap_in_the_thought()
    {
        IReadOnlyList<string> phrases = await Create().SuggestAsync(EntryFieldRole.Reframe, "Они подумают, что я некомпетентен", "ru");

        Assert.Equal(SupportPhraseSuggester.MaxSuggestions, phrases.Count);
        Assert.Contains(phrases, p => p.Contains("что думают другие", StringComparison.Ordinal));
    }

    [Fact]
    public async Task A_thought_without_a_known_trap_still_gets_general_balanced_phrases()
    {
        IReadOnlyList<string> phrases = await Create().SuggestAsync(EntryFieldRole.Reframe, "Мне грустно", "en");

        Assert.Contains("This is a thought, not a fact", phrases);
    }

    [Theory]
    [InlineData(EntryFieldRole.Kindness, "ru", "Ошибаться — по-человечески")]
    [InlineData(EntryFieldRole.SelfKindness, "ru", "Я делаю всё, что могу")]
    [InlineData(EntryFieldRole.SelfKindness, "en", "I'm doing the best I can")]
    public async Task Kind_words_are_offered_in_the_language_of_the_app(EntryFieldRole role, string language, string expected)
    {
        IReadOnlyList<string> phrases = await Create().SuggestAsync(role, "опять всё испортил", language);

        Assert.Contains(expected, phrases);
    }

    [Theory]
    [InlineData("fr", "Je ne sais pas avec certitude ce que pensent les autres", "Ils vont penser que je suis nul")]
    [InlineData("de", "Ich weiß nicht sicher, was andere denken", "Die Kollegen denken, ich bin unfähig")]
    [InlineData("es", "No sé con seguridad lo que piensan los demás", "Van a pensar que soy un inútil")]
    [InlineData("pt", "Não sei com certeza o que os outros pensam", "Eles vão pensar que eu sou burro")]
    [InlineData("zh", "我并不确定别人在想什么", "同事们会觉得我很笨")]
    public async Task A_reframe_fits_the_trap_in_every_language(string language, string expected, string thought)
    {
        IReadOnlyList<string> phrases = await Create().SuggestAsync(EntryFieldRole.Reframe, thought, language);

        Assert.Contains(expected, phrases);
    }

    [Theory]
    [InlineData("fr", "Je fais de mon mieux")]
    [InlineData("de", "Ich tue, was ich kann")]
    [InlineData("es", "Hago lo que puedo")]
    [InlineData("pt", "Estou fazendo o melhor que posso")]
    [InlineData("zh", "我已经尽力了")]
    [InlineData("it", "I'm doing the best I can")]
    public async Task Kind_words_to_oneself_come_in_the_interface_language_or_english(string language, string expected) =>
        Assert.Contains(expected, await Create().SuggestAsync(EntryFieldRole.SelfKindness, "encore raté", language));

    [Fact]
    public async Task Nothing_is_offered_when_the_context_reads_as_a_crisis()
    {
        Assert.Empty(await Create().SuggestAsync(EntryFieldRole.SelfKindness, "не хочу жить", "ru"));
    }

}
