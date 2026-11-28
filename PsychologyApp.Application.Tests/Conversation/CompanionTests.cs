using PsychologyApp.Application.Conversation;
using PsychologyApp.Application.Conversation.Companion;
using PsychologyApp.Application.Practice;
using Xunit;

namespace PsychologyApp.Application.Tests.Conversation;

public class LexiconSituationAnalyzerTests
{
    private readonly LexiconSituationAnalyzer _analyzer = new();

    [Theory]
    [InlineData("У меня паническая атака, не могу дышать, сердце колотится", CompanionEmotion.Panic)]
    [InlineData("Очень тревожно из-за завтрашнего собеседования, боюсь провалиться", CompanionEmotion.Anxiety)]
    [InlineData("Не могу перестать думать об этом разговоре, мысли крутятся по кругу", CompanionEmotion.Overthinking)]
    [InlineData("Меня бесит начальник, так злюсь что руки трясутся", CompanionEmotion.Anger)]
    [InlineData("Мне так обидно, что меня проигнорировали и не ценят", CompanionEmotion.Resentment)]
    [InlineData("Чувствую вину и стыд за то, что подвела команду", CompanionEmotion.Guilt)]
    [InlineData("Грустно и пусто, ничего не радует", CompanionEmotion.Sadness)]
    [InlineData("Я очень устал, нет сил, полное выгорание", CompanionEmotion.Exhaustion)]
    [InlineData("Мне одиноко, никому не нужна", CompanionEmotion.Loneliness)]
    [InlineData("Опять откладываю отчёт, не могу начать", CompanionEmotion.Procrastination)]
    [InlineData("I feel so anxious and worried about tomorrow", CompanionEmotion.Anxiety)]
    [InlineData("I'm furious at my brother, I hate this", CompanionEmotion.Anger)]
    [InlineData("I feel exhausted and burned out, no energy", CompanionEmotion.Exhaustion)]
    [InlineData("I keep overthinking what I said, can't stop thinking about it", CompanionEmotion.Overthinking)]
    [InlineData("В груди всё сжалось, кажется, сейчас отключусь", CompanionEmotion.Panic)]
    [InlineData("Не могу избавиться от ощущения, что жду какого-то подвоха", CompanionEmotion.Anxiety)]
    [InlineData("Заело на одной мысли, снова пережёвываю этот разговор", CompanionEmotion.Overthinking)]
    [InlineData("Меня распирает от злости, уже вскипаю с пол-оборота", CompanionEmotion.Anger)]
    [InlineData("Чувствую себя использованной, со мной не считаются", CompanionEmotion.Resentment)]
    [InlineData("Занимаюсь самоедством из-за того, как поступила", CompanionEmotion.Guilt)]
    [InlineData("Внутри будто всё погасло, ничто не радует", CompanionEmotion.Sadness)]
    [InlineData("Я уже не вывожу даже простые дела, просыпаюсь уставшей", CompanionEmotion.Exhaustion)]
    [InlineData("Среди людей всё равно одиноко, будто меня никто не замечает", CompanionEmotion.Loneliness)]
    [InlineData("Смотрю на задачу и замираю, не могу выбрать с чего начать", CompanionEmotion.Procrastination)]
    [InlineData("I keep waiting for something to go wrong and cannot settle", CompanionEmotion.Anxiety)]
    [InlineData("I keep chewing on the same thought after that conversation", CompanionEmotion.Overthinking)]
    [InlineData("I feel taken advantage of and dismissed", CompanionEmotion.Resentment)]
    [InlineData("I keep beating myself up over one mistake", CompanionEmotion.Guilt)]
    [InlineData("Everything feels muted and nothing seems to reach me", CompanionEmotion.Sadness)]
    [InlineData("I cannot manage even simple tasks anymore", CompanionEmotion.Exhaustion)]
    [InlineData("I feel invisible even around people", CompanionEmotion.Loneliness)]
    [InlineData("I freeze when I look at the task and cannot pick a first step", CompanionEmotion.Procrastination)]
    public void Recognises_dominant_state(string text, CompanionEmotion expected)
    {
        Assert.Equal(expected, _analyzer.Analyze(text).Emotion);
    }

    [Theory]
    [InlineData("Мама очень тревожится из-за переезда", CompanionEmotion.Unknown, true)]
    [InlineData("Он меня разозлил своим поступком", CompanionEmotion.Anger, false)]
    [InlineData("My mother is anxious about the move", CompanionEmotion.Unknown, true)]
    [InlineData("He made me angry with what he said", CompanionEmotion.Anger, false)]
    public void Attributes_emotion_to_the_correct_person(string text, CompanionEmotion expectedEmotion, bool attributedToOther)
    {
        SituationAnalysis analysis = _analyzer.Analyze(text);

        Assert.Equal(expectedEmotion, analysis.Emotion);
        Assert.Equal(attributedToOther, analysis.EmotionAttributedToOther);
    }

    [Fact]
    public void Asks_instead_of_picking_between_the_users_and_another_persons_emotions()
    {
        SituationAnalysis analysis = _analyzer.Analyze("Мама тревожится, а я злюсь");

        Assert.Equal(CompanionEmotion.Unknown, analysis.Emotion);
        Assert.True(analysis.EmotionAttributedToOther);
    }

    [Theory]
    [InlineData("")]
    [InlineData("   ")]
    [InlineData("Сегодня был дождь и я купил хлеб")]
    [InlineData("Ну как-то так, не знаю")]
    public void Unrecognised_text_is_unknown(string text)
    {
        Assert.Equal(CompanionEmotion.Unknown, _analyzer.Analyze(text).Emotion);
    }

    [Theory]
    [InlineData("Я совсем не злюсь на него")]
    [InlineData("Мне не грустно, всё нормально")]
    public void Simple_negation_is_respected(string text)
    {
        Assert.Equal(CompanionEmotion.Unknown, _analyzer.Analyze(text).Emotion);
    }

    [Fact]
    public void Detects_theme_body_and_intensity()
    {
        SituationAnalysis result = _analyzer.Analyze("Очень тревожно из-за начальника, давит в груди");

        Assert.Equal(CompanionEmotion.Anxiety, result.Emotion);
        Assert.Contains(CompanionTheme.Work, result.Themes);
        Assert.True(result.HasBodySymptoms);
        Assert.True(result.IsIntense);
    }

    [Fact]
    public void Anxiety_with_body_symptoms_leans_towards_panic_when_strong()
    {
        SituationAnalysis result = _analyzer.Analyze("Тревога такая, что сердце выскакивает и трясёт");

        Assert.Equal(CompanionEmotion.Panic, result.Emotion);
    }

    [Fact]
    public void Yo_is_treated_like_ye()
    {
        Assert.Equal(CompanionEmotion.Sadness, _analyzer.Analyze("мне тяжело на душе").Emotion);
        Assert.Equal(CompanionEmotion.Anger, _analyzer.Analyze("Всё ЗЛОСТЬ").Emotion);
    }

    [Theory]
    [InlineData("у меня тревжусь весь день")]
    [InlineData("тревоожусь без причины")]
    public void Tolerates_one_typo_in_a_stem(string text) =>
        Assert.Equal(CompanionEmotion.Anxiety, _analyzer.Analyze(text).Emotion);

    [Fact]
    public void Does_not_fuzzy_match_an_unrelated_word()
    {
        // "тренировка" (workout) must not be pulled toward Anxiety just because it shares a prefix shape with "тревога".
        SituationAnalysis result = _analyzer.Analyze("у меня сегодня тренировка");

        Assert.NotEqual(CompanionEmotion.Anxiety, result.Emotion);
    }

    [Fact]
    public void Negation_reaches_across_one_intensity_modifier()
    {
        SituationAnalysis result = _analyzer.Analyze("я не сильно тревожусь из-за этого");

        Assert.NotEqual(CompanionEmotion.Anxiety, result.Emotion);
    }

    [Fact]
    public void Two_separate_sentences_are_not_treated_as_one_negated_clause()
    {
        // Regression guard: normalization drops the period, so "тревожусь. Не могу спать" and
        // "тревожусь не могу спать" tokenize identically — negation must not reach backward across it.
        SituationAnalysis result = _analyzer.Analyze("Я очень тревожусь. Не могу нормально спать");

        Assert.Equal(CompanionEmotion.Anxiety, result.Emotion);
    }

    [Fact]
    public void Phrase_matches_with_an_inserted_word()
    {
        SituationAnalysis result = _analyzer.Analyze("не могу нормально дышать, всё сжалось");

        Assert.Equal(CompanionEmotion.Panic, result.Emotion);
    }

    [Fact]
    public void Negated_phrase_is_skipped()
    {
        // "крутятся мысли" is a listed Overthinking phrase; negated right before its first word it must not fire.
        SituationAnalysis result = _analyzer.Analyze("уже не крутятся мысли, стало гораздо спокойнее");

        Assert.NotEqual(CompanionEmotion.Overthinking, result.Emotion);
    }

    [Theory]
    [InlineData("Меня больше не распирает от злости")]
    [InlineData("Я больше не чувствую себя невидимкой")]
    public void New_colloquial_phrases_respect_negation(string text)
    {
        SituationAnalysis result = _analyzer.Analyze(text);

        Assert.NotEqual(CompanionEmotion.Anger, result.Emotion);
        Assert.NotEqual(CompanionEmotion.Loneliness, result.Emotion);
    }

    [Theory]
    [InlineData("Моя подруга чувствует себя невидимкой среди людей")]
    [InlineData("My friend says they feel lonely even around people")]
    public void A_new_loneliness_phrase_is_not_attributed_to_the_user_when_it_describes_a_friend(string text)
    {
        SituationAnalysis result = _analyzer.Analyze(text);

        Assert.Equal(CompanionEmotion.Unknown, result.Emotion);
        Assert.True(result.EmotionAttributedToOther);
    }
}


public class CompanionContentCatalogTests
{
    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task Titles_used_by_the_companion_match_the_technique_catalog(bool english)
    {
        ITechniqueCatalogService catalog = new TechniqueCatalogService(new BuiltInTechniqueCatalogProvider(() => english ? "en" : "ru"));
        TechniqueId[] ids = Enum.GetValues<TechniqueId>()
            .Where(id => id == TechniqueId.Grounding
                || Enum.GetValues<CompanionEmotion>().Any(e => TechniqueSuggester.Suggest(new SituationAnalysis(e, 1, false, false, [])).Contains(id)))
            .ToArray();

        foreach (TechniqueId id in ids)
        {
            Assert.Equal((await catalog.GetAsync(id)).PageName, CompanionContent.TechniqueTitle(id, english));
            Assert.False(string.IsNullOrWhiteSpace(CompanionContent.TechniqueWhy(id, english)));
        }
    }
}
