using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Practice.Catalog;

/// <summary>Localized one-minute adaptation of an if-then implementation intention.</summary>
internal static class TechniqueCatalogContentImplementationIntention
{
    private sealed record LanguageCopy(
        string ModuleName,
        string Author,
        string WhatHeading,
        string WhenHeading,
        string HowHeading,
        string ExampleHeading,
        string Title,
        string Subtitle,
        string Theme,
        string Summary,
        string When,
        string How,
        string Example,
        string Icon,
        string[] Steps,
        (string Title, string Hint)[] Fields,
        string[] CueSuggestions,
        string[] PlanSuggestions);

    private static readonly IReadOnlyDictionary<string, LanguageCopy> Languages =
        new Dictionary<string, LanguageCopy>(StringComparer.Ordinal)
        {
            ["ru"] = new(
                "Короткая практика", "Психея", "Что это", "Когда применять", "Как пройти", "Пример",
                "План «если—то»", "Свяжите конкретный сигнал с первым действием", "Действие",
                "План «если—то» заранее связывает конкретный сигнал с выбранным действием: «Если произойдёт X, я сделаю Y». Он помогает заранее решить, с чего начать, но не гарантирует выполнение задачи или снижение тревоги.",
                "Если вы хотите начать важное для себя дело, но откладываете его, и можете выбрать безопасный посильный первый шаг. Не используйте план, чтобы заставлять себя работать через болезнь, истощение или небезопасную ситуацию.",
                "Выберите вероятный, наблюдаемый сигнал и действие под вашим контролем. Сделайте действие небольшим; заранее придумайте запасной вариант. Если сигнал не наступил или шаг сейчас невыполним, скорректируйте план или попросите поддержки — это не провал.",
                "«Если после завтрака я сяду за стол, то открою документ и напишу заголовок. Если застряну, просто открою файл и попрошу коллегу помочь с первым пунктом».",
                "Checklist",
                [
                    "1. Выберите одну важную для вас задачу и самое маленькое первое действие — примерно на две минуты.",
                    "2. Назовите конкретный сигнал: когда и где он обычно происходит, например «после завтрака, когда сяду за стол».",
                    "3. Составьте фразу: «Если [сигнал], то я [первое действие]». Действие должно быть понятным и под вашим контролем.",
                    "4. Предусмотрите помеху: какой ещё меньший шаг или чья помощь пригодятся? Если действовать небезопасно или невозможно, остановитесь и выберите другое время или поддержку."
                ],
                [
                    ("Одна задача", "Что вы сами хотите сдвинуть?"),
                    ("Сигнал: когда и где?", "Наблюдаемый момент, который вероятно наступит"),
                    ("Мой план «если—то»", "Если [сигнал], то я [шаг]. Если застряну — [план Б].")
                ],
                ["После завтрака", "Когда сяду за стол", "В назначенное время"],
                ["Если [сигнал], то я [первый шаг]", "Если застряну, то я [план Б]"]),
            ["en"] = new(
                "Quick practice", "Psyche", "What it is", "When to use it", "How to do it", "Example",
                "If–Then Action Plan", "Link a clear cue to one first action", "Action",
                "An if–then plan links a specific cue to an action you choose: “If X happens, I will do Y.” It helps decide in advance how to start; it does not guarantee task completion or less anxiety.",
                "When you want to begin something that matters to you but keep putting it off, and can choose a safe, doable first step. Do not use a plan to push through illness, exhaustion, or an unsafe situation.",
                "Choose a likely, observable cue and an action within your control. Keep the action small and name a backup. If the cue does not happen or the step is not doable now, adjust the plan or ask for support; that is not failure.",
                "“If I sit at my desk after breakfast, I will open the document and write the heading. If I get stuck, I will just open the file and ask a colleague for help with the first item.”",
                "Checklist",
                [
                    "1. Choose one task that matters to you and the smallest first action, about two minutes long.",
                    "2. Name a clear cue: when and where it usually happens, such as “after breakfast, when I sit at my desk.”",
                    "3. Make the plan: “If [cue], then I will [first action].” The action should be clear and within your control.",
                    "4. Plan for one obstacle: what smaller step or support could help? If acting is unsafe or impossible, stop and choose another time or support."
                ],
                [
                    ("One task", "What do you want to move forward?"),
                    ("Cue: when and where?", "An observable moment that is likely to happen"),
                    ("My if–then plan", "If [cue], then I will [step]. If I get stuck: [backup].")
                ],
                ["After breakfast", "When I sit at my desk", "At a set time"],
                ["If [cue], then I will [first step]", "If I get stuck, then I will [backup]"]),
            ["de"] = new(
                "Kurzübung", "Psyche", "Was es ist", "Wann es hilft", "So geht es", "Beispiel",
                "Wenn-dann-Plan", "Ein klares Signal mit einem ersten Schritt verbinden", "Handeln",
                "Ein Wenn-dann-Plan verknüpft ein konkretes Signal vorab mit einer selbst gewählten Handlung: „Wenn X eintritt, mache ich Y.“ Er erleichtert den Start, garantiert aber weder die Erledigung noch weniger Angst.",
                "Wenn Sie mit etwas beginnen möchten, das Ihnen wichtig ist, es aber aufschieben und einen sicheren, machbaren ersten Schritt wählen können. Nutzen Sie den Plan nicht, um trotz Krankheit, Erschöpfung oder einer unsicheren Lage weiterzumachen.",
                "Wählen Sie ein wahrscheinliches, beobachtbares Signal und eine Handlung, die Sie selbst steuern können. Halten Sie sie klein und überlegen Sie eine Alternative. Tritt das Signal nicht ein oder ist der Schritt gerade nicht machbar, passen Sie den Plan an oder bitten Sie um Unterstützung — das ist kein Versagen.",
                "„Wenn ich nach dem Frühstück am Tisch sitze, öffne ich das Dokument und schreibe die Überschrift. Wenn ich feststecke, öffne ich nur die Datei und bitte eine Kollegin um Hilfe beim ersten Punkt.“",
                "Checkliste",
                [
                    "1. Wählen Sie eine wichtige Aufgabe und die kleinste erste Handlung — etwa für zwei Minuten.",
                    "2. Benennen Sie ein klares Signal: wann und wo es meist auftritt, zum Beispiel „nach dem Frühstück, wenn ich am Tisch sitze“.",
                    "3. Formulieren Sie: „Wenn [Signal], dann mache ich [ersten Schritt].“ Die Handlung sollte klar und selbst steuerbar sein.",
                    "4. Planen Sie ein Hindernis ein: Welcher kleinere Schritt oder welche Unterstützung könnte helfen? Ist Handeln unsicher oder unmöglich, stoppen Sie und wählen Sie einen anderen Zeitpunkt oder Unterstützung."
                ],
                [
                    ("Eine Aufgabe", "Was möchten Sie selbst voranbringen?"),
                    ("Signal: wann und wo?", "Ein beobachtbarer, wahrscheinlicher Moment"),
                    ("Mein Wenn-dann-Plan", "Wenn [Signal], dann [Schritt]. Wenn ich feststecke: [Alternative].")
                ],
                ["Nach dem Frühstück", "Wenn ich am Schreibtisch sitze", "Zur vereinbarten Zeit"],
                ["Wenn [Signal], dann [erster Schritt]", "Wenn ich feststecke, dann [Alternative]"]),
            ["fr"] = new(
                "Pratique courte", "Psyche", "De quoi s’agit-il ?", "Quand l’utiliser", "Comment faire", "Exemple",
                "Plan « si… alors… »", "Reliez un signal précis à une première action", "Action",
                "Un plan « si… alors… » relie à l’avance un signal précis à une action choisie : « Si X arrive, je ferai Y. » Il aide à décider comment commencer, sans garantir la réalisation de la tâche ni une baisse de l’anxiété.",
                "Quand vous souhaitez commencer quelque chose d’important pour vous mais le remettez à plus tard, et pouvez choisir une première étape faisable et sûre. N’utilisez pas ce plan pour vous pousser à agir malgré une maladie, l’épuisement ou une situation dangereuse.",
                "Choisissez un signal observable et probable, puis une action qui dépend de vous. Gardez-la petite et prévoyez une solution de repli. Si le signal ne survient pas ou si l’étape est impossible maintenant, adaptez le plan ou demandez du soutien : ce n’est pas un échec.",
                "« Si je m’assois à mon bureau après le petit-déjeuner, j’ouvre le document et j’écris le titre. Si je bloque, j’ouvre simplement le fichier et demande de l’aide pour le premier point. »",
                "Liste",
                [
                    "1. Choisissez une tâche qui compte pour vous et la plus petite première action — environ deux minutes.",
                    "2. Définissez un signal concret : quand et où il survient généralement, par exemple « après le petit-déjeuner, quand je m’assois au bureau ».",
                    "3. Formulez : « Si [signal], alors je [première action]. » L’action doit être claire et dépendre de vous.",
                    "4. Anticipez un obstacle : quelle étape plus petite ou quelle aide pourrait vous servir ? Si agir est dangereux ou impossible, arrêtez-vous et choisissez un autre moment ou du soutien."
                ],
                [
                    ("Une tâche", "Qu’aimeriez-vous faire avancer ?"),
                    ("Signal : quand et où ?", "Un moment observable et probable"),
                    ("Mon plan « si… alors… »", "Si [signal], alors [action]. Si je bloque : [solution de repli].")
                ],
                ["Après le petit-déjeuner", "Quand je m’assois à mon bureau", "À l’heure prévue"],
                ["Si [signal], alors [première action]", "Si je bloque, alors [solution de repli]"]),
            ["es"] = new(
                "Práctica breve", "Psyche", "Qué es", "Cuándo usarla", "Cómo hacerla", "Ejemplo",
                "Plan «si… entonces…»", "Une una señal concreta con una primera acción", "Acción",
                "Un plan «si… entonces…» vincula de antemano una señal concreta con una acción que eliges: «Si ocurre X, haré Y». Ayuda a decidir cómo empezar, pero no garantiza completar la tarea ni reducir la ansiedad.",
                "Cuando quieres empezar algo importante para ti, pero lo vas posponiendo, y puedes elegir un primer paso seguro y posible. No uses el plan para obligarte a trabajar con enfermedad, agotamiento o en una situación insegura.",
                "Elige una señal observable y probable y una acción que dependa de ti. Hazla pequeña y prepara una alternativa. Si la señal no aparece o ahora no puedes dar el paso, ajusta el plan o pide apoyo: no es un fracaso.",
                "«Si me siento a la mesa después del desayuno, abriré el documento y escribiré el título. Si me bloqueo, abriré el archivo y pediré ayuda para el primer punto».",
                "Lista",
                [
                    "1. Elige una tarea que te importe y la acción inicial más pequeña, de unos dos minutos.",
                    "2. Define una señal concreta: cuándo y dónde suele ocurrir, por ejemplo «después de desayunar, al sentarme en la mesa».",
                    "3. Formula: «Si [señal], entonces [acción inicial]». La acción debe ser clara y depender de ti.",
                    "4. Anticipa un obstáculo: ¿qué paso más pequeño o qué ayuda podría servirte? Si actuar no es seguro o posible, detente y elige otro momento o apoyo."
                ],
                [
                    ("Una tarea", "¿Qué quieres impulsar tú?"),
                    ("Señal: ¿cuándo y dónde?", "Un momento observable y probable"),
                    ("Mi plan «si… entonces…»", "Si [señal], entonces [paso]. Si me bloqueo: [alternativa].")
                ],
                ["Después del desayuno", "Al sentarme a la mesa", "A la hora acordada"],
                ["Si [señal], entonces [primer paso]", "Si me bloqueo, entonces [alternativa]"]),
            ["pt"] = new(
                "Prática breve", "Psyche", "O que é", "Quando usar", "Como fazer", "Exemplo",
                "Plano «se… então…»", "Ligue um sinal claro à primeira ação", "Ação",
                "Um plano «se… então…» liga antecipadamente um sinal específico a uma ação escolhida: «Se X acontecer, farei Y». Ele ajuda a decidir como começar, mas não garante a conclusão da tarefa nem a redução da ansiedade.",
                "Quando você quer começar algo importante para si, mas vem adiando, e pode escolher um primeiro passo seguro e possível. Não use o plano para se obrigar a trabalhar durante uma doença, exaustão ou situação insegura.",
                "Escolha um sinal observável e provável e uma ação que dependa de você. Deixe-a pequena e pense numa alternativa. Se o sinal não acontecer ou o passo não for possível agora, ajuste o plano ou peça apoio — isso não é fracasso.",
                "«Se eu me sentar à mesa depois do café da manhã, vou abrir o documento e escrever o título. Se eu travar, vou apenas abrir o arquivo e pedir ajuda com o primeiro item».",
                "Lista",
                [
                    "1. Escolha uma tarefa importante para você e a menor primeira ação, de cerca de dois minutos.",
                    "2. Defina um sinal concreto: quando e onde costuma acontecer, por exemplo «depois do café, quando eu me sentar à mesa».",
                    "3. Formule: «Se [sinal], então vou [primeira ação]». A ação deve ser clara e depender de você.",
                    "4. Pense num obstáculo: que passo menor ou apoio pode ajudar? Se agir não for seguro ou possível, pare e escolha outro horário ou apoio."
                ],
                [
                    ("Uma tarefa", "O que você quer fazer avançar?"),
                    ("Sinal: quando e onde?", "Um momento observável e provável"),
                    ("Meu plano «se… então…»", "Se [sinal], então vou [passo]. Se eu travar: [alternativa].")
                ],
                ["Depois do café da manhã", "Quando eu me sentar à mesa", "No horário combinado"],
                ["Se [sinal], então [primeiro passo]", "Se eu travar, então [alternativa]"]),
            ["zh"] = new(
                "快速练习", "Psyche", "这是什么", "适用时机", "练习方法", "示例",
                "如果—那么行动计划", "把明确的信号和第一个行动连起来", "行动",
                "“如果—那么”计划会提前把一个具体信号和你选择的行动联系起来：“如果发生 X，我就做 Y。”它帮助你预先决定如何开始，但不保证任务一定完成，也不保证焦虑减轻。",
                "当你想开始一件对自己重要的事，却一直拖延，并且能选出一个安全、可行的第一步时。不要用计划逼自己在生病、精疲力竭或处境不安全时继续工作。",
                "选择一个可能出现、可以观察到的信号，以及一个由你掌控的行动。把行动缩小，并想好备选方案。如果信号没有出现，或现在做不到，就调整计划或寻求支持；这不代表失败。",
                "“如果我吃完早饭坐到桌前，我就打开文档并写下标题。如果卡住，我就先打开文件，并请同事帮我处理第一项。”",
                "清单",
                [
                    "1. 选择一件对你重要的事，以及最小的第一步——大约两分钟可以开始的行动。",
                    "2. 说清楚一个具体信号：通常何时、何地会发生，例如“早饭后坐到桌前”。",
                    "3. 写下：“如果 [信号]，那么我就 [第一步行动]。”行动要清楚，并且由你掌控。",
                    "4. 想到一个可能的障碍：更小的一步或谁的帮助会有用？如果行动不安全或做不到，就停下来，改选时间或寻求支持。"
                ],
                [
                    ("一件事", "你自己想推进什么？"),
                    ("信号：何时、何地？", "一个看得见且可能出现的时刻"),
                    ("我的“如果—那么”计划", "如果 [信号]，那么我 [行动]。如果卡住：[备选方案]。")
                ],
                ["早餐后", "坐到桌前时", "到约定时间时"],
                ["如果 [信号]，那么我 [第一步]", "如果卡住，那么我 [备选方案]"])
        };

    internal static IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> For(string? language)
    {
        string key = language?.ToLowerInvariant() ?? "en";
        LanguageCopy copy = Languages.TryGetValue(key, out LanguageCopy? localized) ? localized : Languages["en"];
        return new Dictionary<TechniqueId, BuiltInTechniqueDefinition>
        {
            [TechniqueId.ImplementationIntention] = Create(copy)
        };
    }

    private static BuiltInTechniqueDefinition Create(LanguageCopy copy) => new(
        copy.ModuleName,
        copy.Title,
        copy.Steps,
        copy.Summary,
        TechniqueUiKind.Entry,
        copy.ModuleName,
        "2026-11-03",
        copy.Title,
        copy.Subtitle,
        copy.Theme,
        copy.Author,
        1,
        copy.Icon,
        [
            new TechniqueEntrySeed(copy.Fields[0].Title, copy.Fields[0].Hint, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed(copy.Fields[1].Title, copy.Fields[1].Hint, Suggestions: copy.CueSuggestions),
            new TechniqueEntrySeed(copy.Fields[2].Title, copy.Fields[2].Hint, Suggestions: copy.PlanSuggestions)
        ],
        [
            new TheorySection(copy.WhatHeading, copy.Summary),
            new TheorySection(copy.WhenHeading, copy.When),
            new TheorySection(copy.HowHeading, copy.How),
            new TheorySection(copy.ExampleHeading, copy.Example)
        ]);
}
