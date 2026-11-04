using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Application.Practice;
using PsychologyApp.Domain.Practice;
using Xunit;

namespace PsychologyApp.Application.Tests.Practice;

public class TechniqueCatalogTests
{
    private static ITechniqueCatalogService CreateCatalog() =>
        new TechniqueCatalogService(new BuiltInTechniqueCatalogProvider(() => "ru"));

    [Theory]
    [InlineData(TechniqueId.Spin, TechniqueUiKind.Entry, "Крутилка")]
    [InlineData(TechniqueId.Polarity, TechniqueUiKind.Polarity, "Полярности")]
    [InlineData(TechniqueId.Paper, TechniqueUiKind.Paper, "Лист бумаги")]
    [InlineData(TechniqueId.Hack, TechniqueUiKind.Entry, "Белое пятно")]
    [InlineData(TechniqueId.Copied, TechniqueUiKind.Copied, "Повтори это")]
    [InlineData(TechniqueId.Observer, TechniqueUiKind.Entry, "Разговор с собой со стороны")]
    [InlineData(TechniqueId.Anchor, TechniqueUiKind.Entry, "Воспоминание об опоре")]
    [InlineData(TechniqueId.Grounding, TechniqueUiKind.Entry, "Заземление 5-4-3-2-1")]
    [InlineData(TechniqueId.Breathing, TechniqueUiKind.Entry, "Мягкое дыхание")]
    [InlineData(TechniqueId.SmallStep, TechniqueUiKind.Entry, "Один маленький шаг")]
    [InlineData(TechniqueId.ThoughtRecord, TechniqueUiKind.Entry, "Запись мысли")]
    [InlineData(TechniqueId.SelfCompassion, TechniqueUiKind.Entry, "Добрые слова себе")]
    [InlineData(TechniqueId.SensoryComfort, TechniqueUiKind.Entry, "Сенсорная пауза")]
    [InlineData(TechniqueId.UrgeSurfing, TechniqueUiKind.Entry, "Волна импульса")]

    public async Task GetAsync_returns_expected_ui_kind_and_page_name(TechniqueId id, TechniqueUiKind kind, string pageName)
    {
        BuiltInTechniqueDefinition definition = await CreateCatalog().GetAsync(id);

        Assert.Equal(kind, definition.UiKind);
        Assert.Equal(pageName, definition.PageName);
        Assert.Equal("Практик", definition.ModuleName);
    }

    [Fact]
    public async Task GetAllAsync_contains_every_builtin_technique()
    {
        IReadOnlyList<BuiltInTechniqueDefinition> all = await CreateCatalog().GetAllAsync();
        Assert.Equal(Enum.GetValues<TechniqueId>().Length, all.Count);
    }

    [Fact]
    public async Task GetBuiltInListEntriesAsync_aligns_with_catalog()
    {
        ITechniqueCatalogService catalog = CreateCatalog();
        IReadOnlyList<BuiltInTechniqueDefinition> all = await catalog.GetAllAsync();
        IReadOnlyList<TechniqueListEntry> entries = await catalog.GetBuiltInListEntriesAsync();

        TechniqueId[] archivedIds =
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
        Assert.Equal(all.Count - archivedIds.Length, entries.Count);
        Assert.Contains(entries, entry => entry.TechniqueId == TechniqueId.ThoughtDefusion);
        Assert.Contains(entries, entry => entry.TechniqueId == TechniqueId.Observer);

        foreach (TechniqueId archivedId in archivedIds)
        {
            Assert.DoesNotContain(entries, entry => entry.TechniqueId == archivedId);
            Assert.NotNull(await catalog.GetAsync(archivedId));
        }

        foreach (TechniqueListEntry entry in entries)
        {
            BuiltInTechniqueDefinition definition = await catalog.GetAsync(entry.TechniqueId);
            Assert.Equal(definition.ListTitle, entry.Title);
            Assert.Equal(definition.ListSubtitle, entry.Subtitle);
            Assert.Equal(definition.ListNumber, entry.Number);
            Assert.False(string.IsNullOrWhiteSpace(definition.ListIcon));
            Assert.True(definition.ListDurationMinutes > 0);
            Assert.Equal(definition.ListIcon, entry.Icon);
            Assert.Equal(definition.ListDurationMinutes, entry.DurationMinutes);
        }
    }

    [Fact]
    public async Task All_builtin_techniques_have_theory_sections()
    {
        foreach (BuiltInTechniqueDefinition definition in await CreateCatalog().GetAllAsync())
        {
            Assert.NotNull(definition.TheorySections);
            Assert.Equal(4, definition.TheorySections!.Count);
        }
    }

    [Theory]
    [InlineData(TechniqueId.Spin, EntryFieldKind.Rating0To10)]
    [InlineData(TechniqueId.Future, EntryFieldKind.Rating0To10)]
    [InlineData(TechniqueId.Experience, EntryFieldKind.RatingNeg10To10)]
    [InlineData(TechniqueId.Observer, EntryFieldKind.Rating0To10)]
    [InlineData(TechniqueId.Anchor, EntryFieldKind.Rating0To10)]
    public async Task Entry_techniques_include_rating_fields(TechniqueId id, EntryFieldKind expectedKind)
    {
        BuiltInTechniqueDefinition definition = await CreateCatalog().GetAsync(id);
        Assert.Contains(definition.Entries!, entry => entry.Kind == expectedKind);
    }

    [Fact]
    public async Task Distanced_self_talk_is_short_safe_and_keeps_the_saved_entry_shape()
    {
        BuiltInTechniqueDefinition definition = await CreateCatalog().GetAsync(TechniqueId.Observer);
        IReadOnlyList<TechniqueEntrySeed> fields = definition.Entries!;

        Assert.Equal(1, definition.ListDurationMinutes);
        Assert.Equal(4, definition.Algorithm.Count);
        Assert.Equal(
            new[] { EntryFieldRole.Problem, EntryFieldRole.Emotion, EntryFieldRole.None, EntryFieldRole.None },
            fields.Select(field => field.Role));
        Assert.Equal(
            new[] { EntryFieldKind.Text, EntryFieldKind.Text, EntryFieldKind.Text, EntryFieldKind.Rating0To10 },
            fields.Select(field => field.Kind));
        Assert.Contains("Не оправдывайте вред", definition.Algorithm[2], StringComparison.OrdinalIgnoreCase);
        Assert.Contains("может снизиться, не измениться или усилиться", definition.Algorithm[3], StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public async Task Comparison_includes_reflection_field()
    {
        BuiltInTechniqueDefinition definition = await CreateCatalog().GetAsync(TechniqueId.Comparison);
        Assert.Contains(definition.Entries!, entry => entry.Title.Contains("изменилось", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task ThoughtRecord_includes_cbt_fields()
    {
        BuiltInTechniqueDefinition definition = await CreateCatalog().GetAsync(TechniqueId.ThoughtRecord);

        Assert.Contains(definition.Entries!, entry => entry.Title.Contains("Ситуация", StringComparison.OrdinalIgnoreCase));
        Assert.Contains(definition.Entries!, entry => entry.Title.Contains("Автоматическая мысль", StringComparison.OrdinalIgnoreCase));
        Assert.Contains(definition.Entries!, entry => entry.Title.Contains("Альтернативная мысль", StringComparison.OrdinalIgnoreCase));
    }

    [Fact]
    public async Task Breathing_includes_before_after_ratings()
    {
        BuiltInTechniqueDefinition definition = await CreateCatalog().GetAsync(TechniqueId.Breathing);

        Assert.Equal(2, definition.Entries!.Count(entry => entry.Kind == EntryFieldKind.Rating0To10));
    }

    [Fact]
    public async Task SensoryComfort_uses_optional_cue_and_before_after_distress_ratings()
    {
        BuiltInTechniqueDefinition definition = await CreateCatalog().GetAsync(TechniqueId.SensoryComfort);
        IReadOnlyList<TechniqueEntrySeed> entries = definition.Entries!;

        Assert.Equal(3, entries.Count);
        Assert.Equal(EntryFieldKind.Rating0To10, entries[0].Kind);
        Assert.Equal(EntryFieldRole.IntensityBefore, entries[0].Role);
        Assert.NotEmpty(entries[1].Suggestions!);
        Assert.Equal(EntryFieldRole.IntensityAfter, entries[2].Role);
        Assert.Equal(EntryFieldKind.Rating0To10, entries[2].Kind);
        Assert.Contains("не обещает снизить напряжение", definition.TheoryInfo);
    }

    [Fact]
    public async Task UrgeSurfing_is_optional_and_records_before_after_urge_ratings()
    {
        BuiltInTechniqueDefinition definition = await CreateCatalog().GetAsync(TechniqueId.UrgeSurfing);
        IReadOnlyList<TechniqueEntrySeed> entries = definition.Entries!;

        Assert.Equal(1, definition.ListDurationMinutes);
        Assert.Equal(5, definition.Algorithm.Count);
        Assert.Equal(3, entries.Count);
        Assert.Equal(EntryFieldRole.IntensityBefore, entries[0].Role);
        Assert.Equal(EntryFieldRole.IntensityAfter, entries[2].Role);
        Assert.NotEmpty(entries[1].Suggestions!);
        Assert.Contains("отдельно не проверялся", definition.TheoryInfo, StringComparison.OrdinalIgnoreCase);
    }



    [Theory]

    [InlineData("ru")]
    [InlineData("en")]
    [InlineData("de")]
    [InlineData("fr")]
    [InlineData("es")]
    [InlineData("pt")]
    [InlineData("zh")]
    public async Task Every_supported_language_has_complete_catalog_content(string language)
    {
        ITechniqueCatalogService catalog = new TechniqueCatalogService(new BuiltInTechniqueCatalogProvider(() => language));
        IReadOnlyList<BuiltInTechniqueDefinition> all = await catalog.GetAllAsync();
        TechniqueId[] techniqueIds = Enum.GetValues<TechniqueId>();

        Assert.Equal(techniqueIds.Length, all.Count);

        foreach (TechniqueId id in techniqueIds)
        {
            BuiltInTechniqueDefinition definition = await catalog.GetAsync(id);
            Assert.False(string.IsNullOrWhiteSpace(definition.ModuleName), $"{language} {id}: missing module name");
            Assert.False(string.IsNullOrWhiteSpace(definition.PageName), $"{language} {id}: missing page name");
            Assert.False(string.IsNullOrWhiteSpace(definition.TheoryInfo), $"{language} {id}: missing theory summary");
            Assert.NotEmpty(definition.Algorithm);
            Assert.NotNull(definition.TheorySections);
            Assert.Equal(4, definition.TheorySections!.Count);

            foreach (string step in definition.Algorithm)
            {
                Assert.False(string.IsNullOrWhiteSpace(step), $"{language} {id}: empty instruction step");
            }
        }

        foreach (TechniqueListEntry entry in await catalog.GetBuiltInListEntriesAsync())
        {
            Assert.False(string.IsNullOrWhiteSpace(entry.Title), $"{language} {entry.TechniqueId}: missing list title");
            Assert.False(string.IsNullOrWhiteSpace(entry.Subtitle), $"{language} {entry.TechniqueId}: missing list subtitle");
            Assert.False(string.IsNullOrWhiteSpace(entry.Icon), $"{language} {entry.TechniqueId}: missing list icon");
            Assert.True(entry.DurationMinutes > 0, $"{language} {entry.TechniqueId}: invalid list duration");
        }
    }

    [Theory]
    [InlineData("ru")]
    [InlineData("fr")]
    [InlineData("de")]
    [InlineData("es")]
    [InlineData("pt")]
    [InlineData("zh")]
    public async Task Every_language_offers_the_same_fields_and_help_as_english(string language)
    {
        ITechniqueCatalogService translated = new TechniqueCatalogService(new BuiltInTechniqueCatalogProvider(() => language));
        ITechniqueCatalogService english = new TechniqueCatalogService(new BuiltInTechniqueCatalogProvider(() => "en"));

        foreach (TechniqueId id in Enum.GetValues<TechniqueId>())
        {
            BuiltInTechniqueDefinition other = await translated.GetAsync(id);
            BuiltInTechniqueDefinition en = await english.GetAsync(id);
            IReadOnlyList<TechniqueEntrySeed> otherFields = other.Entries ?? [];
            IReadOnlyList<TechniqueEntrySeed> enFields = en.Entries ?? [];

            Assert.Equal(en.UiKind, other.UiKind);
            Assert.Equal(enFields.Count, otherFields.Count);
            for (int i = 0; i < enFields.Count; i++)
            {
                Assert.True(enFields[i].Role == otherFields[i].Role, $"{language} {id} field {i}: role differs");
                Assert.True(enFields[i].Kind == otherFields[i].Kind, $"{language} {id} field {i}: kind differs");
                Assert.True((enFields[i].Suggestions?.Count ?? 0) == (otherFields[i].Suggestions?.Count ?? 0), $"{language} {id} field {i}: suggestion count differs");
            }
        }
    }

    [Theory]
    [InlineData("fr", TechniqueId.Grounding, "Ancrage 5-4-3-2-1")]
    [InlineData("de", TechniqueId.Breathing, "Sanftes Atemtempo")]
    [InlineData("zh", TechniqueId.SmallStep, "一小步")]
    [InlineData("ja", TechniqueId.SmallStep, "One small step")]
    public async Task A_language_shows_its_own_practice_names_and_an_unknown_one_gets_english(string language, TechniqueId id, string pageName)
    {
        ITechniqueCatalogService catalog = new TechniqueCatalogService(new BuiltInTechniqueCatalogProvider(() => language));

        Assert.Equal(pageName, (await catalog.GetAsync(id)).PageName);
    }

    [Fact]
    public async Task Every_text_field_offers_some_help_besides_the_keyboard()
    {
        ITechniqueCatalogService catalog = CreateCatalog();
        string[] free = ["Негативный опыт"];

        foreach (BuiltInTechniqueDefinition definition in await catalog.GetAllAsync())
        {
            foreach (TechniqueEntrySeed entry in (definition.Entries ?? []).Where(e => e.Kind == EntryFieldKind.Text && !free.Contains(e.Title)))
            {
                bool helped = entry.Suggestions is { Count: > 0 } || entry.Role is not EntryFieldRole.None;
                Assert.True(helped, $"{definition.PageName}: \"{entry.Title}\" has neither chips nor a role");
            }
        }
    }

    [Fact]
    public async Task Problem_fields_come_first_so_stages_and_dialogues_can_find_the_problem()
    {
        foreach (TechniqueId id in new[] { TechniqueId.Resize, TechniqueId.Hack, TechniqueId.Check, TechniqueId.Future, TechniqueId.Spin, TechniqueId.Extend })
        {
            BuiltInTechniqueDefinition definition = await CreateCatalog().GetAsync(id);
            Assert.Equal(EntryFieldRole.Problem, definition.Entries![0].Role);
        }
    }

    [Fact]
    public async Task GetAllAsync_fails_fast_when_provider_catalog_is_incomplete()
    {
        ITechniqueCatalogService catalog = new TechniqueCatalogService(new IncompleteCatalogProvider());

        InvalidOperationException error = await Assert.ThrowsAsync<InvalidOperationException>(() => catalog.GetAllAsync());

        Assert.Contains("returned 0 definitions", error.Message, StringComparison.Ordinal);
    }

    [Theory]
    [InlineData("ru", "Пауза перед реакцией", "Действие вместо импульса", "Разобрать решаемую задачу", "Проверить факты", "Время для тревоги", "План «если—то»")]
    [InlineData("en", "Pause Before Reacting", "Choose a Different Action", "Solve One Practical Problem", "Check the Facts", "Schedule Worry Time", "If–Then Action Plan")]
    [InlineData("de", "Pause vor der Reaktion", "Anders handeln als der Impuls", "Ein lösbares Problem angehen", "Fakten prüfen", "Sorgenzeit einplanen", "Wenn-dann-Plan")]
    [InlineData("fr", "Faire une pause avant de réagir", "Choisir une autre action", "Résoudre un problème concret", "Vérifier les faits", "Planifier un temps pour les inquiétudes", "Plan « si… alors… »")]
    [InlineData("es", "Pausa antes de reaccionar", "Elegir otra acción", "Resolver un problema concreto", "Comprobar los hechos", "Programar un tiempo para preocuparse", "Plan «si… entonces…»")]
    [InlineData("pt", "Pausa antes de reagir", "Escolha outra ação", "Resolver um problema prático", "Conferir os fatos", "Agendar um tempo para as preocupações", "Plano «se… então…»")]
    [InlineData("zh", "反应前暂停", "选择不同的行动", "解决一个具体问题", "核对事实", "安排担忧时间", "如果—那么行动计划")]
    public async Task New_skills_have_localized_short_flows_in_every_supported_language(
        string language,
        string pauseTitle,
        string oppositeActionTitle,
        string problemSolvingTitle,
        string checkFactsTitle,
        string worryTimeTitle,
        string implementationIntentionTitle)
    {
        ITechniqueCatalogService catalog = new TechniqueCatalogService(new BuiltInTechniqueCatalogProvider(() => language));
        (TechniqueId Id, string Title)[] expected =
        [
            (TechniqueId.PauseBeforeReaction, pauseTitle),
            (TechniqueId.OppositeAction, oppositeActionTitle),
            (TechniqueId.ProblemSolving, problemSolvingTitle),
            (TechniqueId.CheckTheFacts, checkFactsTitle),
            (TechniqueId.WorryTime, worryTimeTitle),
            (TechniqueId.ImplementationIntention, implementationIntentionTitle)
        ];

        foreach ((TechniqueId id, string title) in expected)
        {
            BuiltInTechniqueDefinition definition = await catalog.GetAsync(id);

            Assert.Equal(title, definition.PageName);
            Assert.Equal(TechniqueUiKind.Entry, definition.UiKind);
            Assert.Equal(4, definition.Algorithm.Count);
            Assert.Equal(3, definition.Entries?.Count);
            Assert.Equal(1, definition.ListDurationMinutes);
        }

        IReadOnlyList<TechniqueListEntry> entries = await catalog.GetBuiltInListEntriesAsync();
        Assert.All(expected, technique => Assert.Contains(entries, entry => entry.TechniqueId == technique.Id));
    }
    [Fact]
    public async Task New_skills_preserve_safety_and_do_not_force_a_positive_or_unsolvable_response()
    {
        ITechniqueCatalogService catalog = CreateCatalog();
        BuiltInTechniqueDefinition oppositeAction = await catalog.GetAsync(TechniqueId.OppositeAction);
        BuiltInTechniqueDefinition problemSolving = await catalog.GetAsync(TechniqueId.ProblemSolving);
        BuiltInTechniqueDefinition checkFacts = await catalog.GetAsync(TechniqueId.CheckTheFacts);
        BuiltInTechniqueDefinition worryTime = await catalog.GetAsync(TechniqueId.WorryTime);
        BuiltInTechniqueDefinition implementationIntention = await catalog.GetAsync(TechniqueId.ImplementationIntention);
        BuiltInTechniqueDefinition briefAttentionShift = await catalog.GetAsync(TechniqueId.BusyMind);

        Assert.Contains("реальная опасность", oppositeAction.Algorithm[1], StringComparison.OrdinalIgnoreCase);
        Assert.Contains("не заставляйте себя", oppositeAction.Algorithm[3], StringComparison.OrdinalIgnoreCase);
        Assert.Contains("Если нет", problemSolving.Algorithm[1], StringComparison.OrdinalIgnoreCase);
        Assert.Contains("опасность", checkFacts.Algorithm[3], StringComparison.OrdinalIgnoreCase);
        Assert.Contains("не заставляйте себя думать позитивно", checkFacts.Algorithm[2], StringComparison.OrdinalIgnoreCase);
        Assert.Contains("Если вопрос срочный", worryTime.Algorithm[1], StringComparison.OrdinalIgnoreCase);
        Assert.Contains("10–15 минут", worryTime.Algorithm[2], StringComparison.OrdinalIgnoreCase);
        Assert.Contains("Если [сигнал]", implementationIntention.Algorithm[2], StringComparison.OrdinalIgnoreCase);
        Assert.Contains("небезопасно", implementationIntention.Algorithm[3], StringComparison.OrdinalIgnoreCase);
        Assert.Equal(1, briefAttentionShift.ListDurationMinutes);
        Assert.Contains("30–60 секунд", briefAttentionShift.Algorithm[1], StringComparison.OrdinalIgnoreCase);
        Assert.Contains("остановитесь", briefAttentionShift.Algorithm[3], StringComparison.OrdinalIgnoreCase);
    }

    private sealed class IncompleteCatalogProvider : PsychologyApp.Application.Abstractions.Integration.ITechniqueCatalogProvider
    {
        public Task<IReadOnlyList<BuiltInTechniqueDefinition>> LoadAllAsync(CancellationToken cancellationToken = default)
        {
            cancellationToken.ThrowIfCancellationRequested();
            return Task.FromResult<IReadOnlyList<BuiltInTechniqueDefinition>>(Array.Empty<BuiltInTechniqueDefinition>());
        }
    }
}
