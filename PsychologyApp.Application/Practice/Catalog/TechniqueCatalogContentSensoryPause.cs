using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Practice.Catalog;

/// <summary>A brief, optional adaptation of DBT self-soothing through the senses; it makes no outcome promise.</summary>
internal static class TechniqueCatalogContentSensoryPause
{
    private sealed record Copy(
        string ModuleName, string Author, string WhatHeading, string WhenHeading, string HowHeading, string ExampleHeading,
        string Title, string Subtitle, string Theme, string Summary, string When, string How, string Example, string Icon,
        string BeforeTitle, string CueTitle, string CueHint, string AfterTitle,
        string[] Steps, string[] Suggestions);

    private static readonly IReadOnlyDictionary<string, Copy> Languages =
        new Dictionary<string, Copy>(StringComparer.Ordinal)
        {
            ["ru"] = new(
                "Практик", "Навык самопомощи", "Что это", "Когда применять", "Как пройти", "Пример",
                "Сенсорная пауза", "На минуту переключите внимание на один комфортный сигнал", "Мягкая опора",
                "Это короткая адаптация DBT-навыка самоуспокоения через органы чувств. Выберите один нейтральный или приятный сигнал рядом и спокойно отметьте несколько его деталей. Такой перерыв может помочь пережить трудный момент, но не обещает снизить напряжение и не решает саму проблему.",
                "Когда хочется сделать небольшую паузу и в окружении есть безопасный сигнал, который вам подходит. Не нужно специально искать запах, вкус, звук или прикосновение. Если сенсорный фокус неприятен, пропустите практику.",
                "Сначала оцените дискомфорт от 0 до 10. Выберите один доступный сигнал: например, цвет или форму, привычный звук на комфортной громкости, фактуру только если прикосновение приятно, или опору под стопами. Замечайте одну-две детали 30–60 секунд, затем оцените дискомфорт снова. Не заставляйте себя успокаиваться. Если стало хуже или некомфортно — остановитесь. После паузы при необходимости выберите один практический шаг.",
                "Вы замечаете прохладный свет на стене и его мягкие границы. Через полминуты дискомфорт может остаться прежним — это допустимый результат; вы просто возвращаетесь к выбранному делу или поддержке.",
                "Eye", "Дискомфорт до (0–10)", "На что я обращу внимание?", "Выберите один уже доступный безопасный сигнал или пропустите выбор.", "Дискомфорт после (0–10)",
                [
                    "1. Оцените текущий дискомфорт от 0 до 10. Это ориентир, а не оценка того, насколько хорошо вы справляетесь.",
                    "2. Выберите один безопасный нейтральный или приятный сигнал, который уже есть рядом. Например: цвет или контур, знакомый звук на комфортной громкости, приятная фактура или ощущение опоры под стопами.",
                    "3. Замечайте одну-две конкретные детали около 30–60 секунд. Если внимание отвлеклось, спокойно верните его к сигналу; менять своё состояние не обязательно.",
                    "4. Оцените дискомфорт ещё раз. Он может уменьшиться, не измениться или усилиться — любой ответ полезен для выбора следующего шага.",
                    "5. Если сигнал вызывает неприятные ощущения или становится хуже, остановитесь и переключитесь на то, что сейчас безопаснее. Если проблема требует действия, после паузы выберите один небольшой практический шаг или поддержку."
                ],
                ["Цвет или контур", "Знакомый звук", "Приятная фактура", "Опора под стопами", "Пока пропущу"]),
            ["en"] = new(
                "Practice", "Self-help skill", "What it is", "When to use it", "How to do it", "Example",
                "A Sensory Pause", "Give one comfortable cue your attention for a minute", "Gentle support",
                "This is a brief adaptation of the DBT self-soothing skill using the senses. Choose one neutral or pleasant cue already nearby and notice a few details. A pause may help you get through a difficult moment, but it does not promise to reduce distress or solve the problem itself.",
                "When you want a short pause and there is a safe cue around you that feels suitable. You do not need to seek out a smell, taste, sound, or touch. Skip the practice if focusing on sensation feels unpleasant.",
                "First rate your distress from 0 to 10. Choose one available cue: a color or shape, a familiar sound at a comfortable volume, a texture only if touch feels pleasant, or support under your feet. Notice one or two details for 30–60 seconds, then rate distress again. Do not force yourself to feel calm. Stop if you feel worse or uncomfortable. After the pause, choose a practical next step if one is needed.",
                "You notice cool light on a wall and its soft edges. After half a minute, distress may be unchanged; that is a valid result. You can return to the task or support you chose.",
                "Eye", "Distress before (0–10)", "What will I notice?", "Choose one safe cue already available, or skip this choice.", "Distress after (0–10)",
                [
                    "1. Rate your current distress from 0 to 10. This is a reference point, not a score of how well you are coping.",
                    "2. Choose one safe, neutral or pleasant cue already nearby, such as a color or outline, a familiar sound at a comfortable volume, a pleasant texture, or support under your feet.",
                    "3. Notice one or two specific details for about 30–60 seconds. If your attention wanders, gently return to the cue; you do not have to change how you feel.",
                    "4. Rate distress again. It may decrease, stay the same, or increase; any answer can help you choose what to do next.",
                    "5. If the cue feels unpleasant or distress increases, stop and switch to what feels safer. If the situation needs action, choose one small practical step or support after the pause."
                ],
                ["A color or outline", "A familiar sound", "A pleasant texture", "Support under my feet", "Skip for now"]),
            ["de"] = new(
                "Übung", "Selbsthilfe", "Was ist das?", "Wann anwenden?", "So geht es", "Beispiel",
                "Eine Sinnespause", "Richte eine Minute lang die Aufmerksamkeit auf einen angenehmen Reiz", "Sanfte Unterstützung",
                "Dies ist eine kurze Anpassung der DBT-Fertigkeit Selbstberuhigung mit den Sinnen. Wähle einen neutralen oder angenehmen Reiz in deiner Nähe und nimm einige Details wahr. Eine Pause kann helfen, einen schwierigen Moment auszuhalten, verspricht aber weder weniger Belastung noch eine Lösung des Problems.",
                "Wenn du kurz innehalten möchtest und ein sicherer Reiz in deiner Umgebung passend ist. Du musst keinen Geruch, Geschmack, Klang oder Berührung suchen. Lass die Übung aus, wenn der Sinnesfokus unangenehm ist.",
                "Bewerte zuerst deine Belastung von 0 bis 10. Wähle einen verfügbaren Reiz: eine Farbe oder Form, einen vertrauten Klang in angenehmer Lautstärke, eine angenehme Oberfläche nur wenn Berührung sich gut anfühlt, oder den Halt unter den Füßen. Nimm 30–60 Sekunden ein oder zwei Details wahr und bewerte danach erneut. Erzwinge keine Ruhe. Wenn es schlechter oder unangenehm wird, hör auf. Wähle anschließend bei Bedarf einen praktischen Schritt.",
                "Du bemerkst kühles Licht an der Wand und seine weichen Ränder. Nach einer halben Minute kann die Belastung unverändert sein. Das ist ein gültiges Ergebnis; du kannst zur Aufgabe oder Unterstützung zurückkehren.",
                "Eye", "Belastung vorher (0–10)", "Worauf achte ich?", "Wähle einen sicheren, bereits vorhandenen Reiz oder überspringe die Auswahl.", "Belastung nachher (0–10)",
                [
                    "1. Bewerte deine aktuelle Belastung von 0 bis 10. Das ist ein Ausgangspunkt, keine Bewertung deiner Bewältigung.",
                    "2. Wähle einen sicheren, neutralen oder angenehmen Reiz in deiner Nähe, etwa eine Farbe oder Kontur, einen vertrauten Klang in angenehmer Lautstärke, eine angenehme Oberfläche oder Halt unter den Füßen.",
                    "3. Nimm etwa 30–60 Sekunden lang ein oder zwei konkrete Details wahr. Wenn deine Aufmerksamkeit abschweift, kehre sanft zum Reiz zurück; dein Gefühl muss sich nicht ändern.",
                    "4. Bewerte die Belastung erneut. Sie kann sinken, gleich bleiben oder steigen. Jede Antwort kann bei der nächsten Entscheidung helfen.",
                    "5. Ist der Reiz unangenehm oder steigt die Belastung, hör auf und wechsle zu etwas Sichererem. Wenn die Situation eine Handlung erfordert, wähle danach einen kleinen praktischen Schritt oder Unterstützung."
                ],
                ["Eine Farbe oder Kontur", "Ein vertrauter Klang", "Eine angenehme Oberfläche", "Halt unter den Füßen", "Jetzt überspringen"]),
            ["es"] = new(
                "Práctica", "Autocuidado", "Qué es", "Cuándo usarla", "Cómo hacerlo", "Ejemplo",
                "Una pausa sensorial", "Dedica un minuto a una señal que te resulte cómoda", "Apoyo suave",
                "Es una adaptación breve de la habilidad DBT de calmarse mediante los sentidos. Elige una señal neutra o agradable que ya esté cerca y observa algunos detalles. La pausa puede ayudarte a atravesar un momento difícil, pero no promete reducir el malestar ni resolver el problema.",
                "Cuando quieras hacer una pausa breve y haya cerca una señal segura que te resulte adecuada. No hace falta buscar un olor, sabor, sonido o contacto. Omite la práctica si centrarte en las sensaciones te resulta desagradable.",
                "Primero valora tu malestar de 0 a 10. Elige una señal disponible: un color o una forma, un sonido conocido a un volumen cómodo, una textura solo si tocarla resulta agradable o el apoyo bajo los pies. Observa uno o dos detalles durante 30–60 segundos y vuelve a valorar el malestar. No te obligues a calmarte. Detente si empeora o te incomoda. Después, si hace falta, elige un paso práctico.",
                "Notas la luz fresca en una pared y sus bordes suaves. Tras medio minuto, el malestar puede seguir igual. Es un resultado válido; puedes volver a la tarea o al apoyo que elegiste.",
                "Eye", "Malestar antes (0–10)", "¿En qué me fijaré?", "Elige una señal segura que ya esté disponible o sáltate esta elección.", "Malestar después (0–10)",
                [
                    "1. Valora el malestar actual de 0 a 10. Es un punto de referencia, no una nota sobre cómo lo estás haciendo.",
                    "2. Elige una señal segura, neutra o agradable que ya esté cerca: un color o contorno, un sonido conocido a un volumen cómodo, una textura agradable o el apoyo bajo los pies.",
                    "3. Observa uno o dos detalles concretos durante unos 30–60 segundos. Si te distraes, vuelve suavemente a la señal; no tienes que cambiar cómo te sientes.",
                    "4. Vuelve a valorar el malestar. Puede bajar, quedarse igual o subir; cualquier respuesta puede ayudarte a decidir qué hacer.",
                    "5. Si la señal te resulta desagradable o aumenta el malestar, detente y cambia a algo más seguro. Si la situación requiere actuar, después elige un pequeño paso práctico o apoyo."
                ],
                ["Un color o contorno", "Un sonido conocido", "Una textura agradable", "Apoyo bajo los pies", "Lo omito por ahora"]),
            ["fr"] = new(
                "Pratique", "Aide personnelle", "De quoi s’agit-il ?", "Quand l’utiliser ?", "Comment faire", "Exemple",
                "Une pause sensorielle", "Pendant une minute, remarquez un repère qui vous convient", "Un appui doux",
                "Il s’agit d’une brève adaptation de la compétence DBT d’auto-apaisement par les sens. Choisissez un repère neutre ou agréable déjà présent et remarquez quelques détails. Cette pause peut aider à traverser un moment difficile, mais ne promet ni de réduire la détresse ni de résoudre le problème.",
                "Quand vous souhaitez faire une courte pause et qu’un repère sûr de votre environnement vous convient. Inutile de chercher une odeur, un goût, un son ou un contact. Passez l’exercice si l’attention aux sensations vous déplaît.",
                "Évaluez d’abord votre détresse de 0 à 10. Choisissez un repère disponible : une couleur ou une forme, un son familier à volume confortable, une texture seulement si le contact est agréable, ou l’appui sous vos pieds. Remarquez un ou deux détails pendant 30–60 secondes, puis réévaluez votre détresse. Ne vous forcez pas à vous calmer. Arrêtez si cela empire ou vous gêne. Ensuite, choisissez si besoin une action concrète.",
                "Vous remarquez la lumière fraîche sur un mur et ses contours doux. Après une demi-minute, la détresse peut rester identique. C’est un résultat valable ; vous pouvez revenir à la tâche ou au soutien choisi.",
                "Eye", "Détresse avant (0–10)", "Sur quoi vais-je porter mon attention ?", "Choisissez un repère sûr déjà présent, ou passez ce choix.", "Détresse après (0–10)",
                [
                    "1. Évaluez votre détresse actuelle de 0 à 10. C’est un repère, pas une note sur votre façon de faire.",
                    "2. Choisissez un repère sûr, neutre ou agréable déjà présent : une couleur ou un contour, un son familier à volume confortable, une texture agréable ou l’appui sous vos pieds.",
                    "3. Remarquez un ou deux détails concrets pendant environ 30–60 secondes. Si votre attention s’éloigne, revenez doucement au repère ; vous n’avez pas à changer votre état.",
                    "4. Évaluez à nouveau la détresse. Elle peut diminuer, rester stable ou augmenter ; chaque réponse aide à choisir la suite.",
                    "5. Si le repère vous déplaît ou augmente la détresse, arrêtez et choisissez quelque chose de plus sûr. Si la situation demande une action, choisissez ensuite un petit pas concret ou du soutien."
                ],
                ["Une couleur ou un contour", "Un son familier", "Une texture agréable", "L’appui sous mes pieds", "Je passe pour l’instant"]),
            ["pt"] = new(
                "Prática", "Autocuidado", "O que é", "Quando usar", "Como fazer", "Exemplo",
                "Uma pausa sensorial", "Dedique um minuto a um estímulo confortável", "Apoio suave",
                "Esta é uma adaptação breve da habilidade DBT de autoacalmar-se pelos sentidos. Escolha um estímulo neutro ou agradável que já esteja por perto e observe alguns detalhes. A pausa pode ajudar a atravessar um momento difícil, mas não promete reduzir o sofrimento nem resolver o problema.",
                "Quando quiser fazer uma pausa breve e houver por perto um estímulo seguro que lhe pareça adequado. Não precisa procurar cheiro, sabor, som ou toque. Pule a prática se focar nas sensações for desagradável.",
                "Primeiro, avalie seu sofrimento de 0 a 10. Escolha um estímulo disponível: uma cor ou forma, um som familiar em volume confortável, uma textura apenas se o toque for agradável ou o apoio sob os pés. Observe um ou dois detalhes por 30–60 segundos e avalie novamente. Não se force a ficar calmo. Pare se piorar ou incomodar. Depois, se necessário, escolha um passo prático.",
                "Você percebe a luz fria na parede e seus contornos suaves. Após meio minuto, o sofrimento pode continuar igual. Esse é um resultado válido; você pode voltar à tarefa ou ao apoio escolhido.",
                "Eye", "Sofrimento antes (0–10)", "No que vou prestar atenção?", "Escolha um estímulo seguro que já esteja disponível ou pule esta escolha.", "Sofrimento depois (0–10)",
                [
                    "1. Avalie o sofrimento atual de 0 a 10. É apenas uma referência, não uma nota sobre seu desempenho.",
                    "2. Escolha um estímulo seguro, neutro ou agradável que já esteja por perto: uma cor ou contorno, um som familiar em volume confortável, uma textura agradável ou o apoio sob os pés.",
                    "3. Observe um ou dois detalhes concretos por cerca de 30–60 segundos. Se sua atenção se desviar, volte gentilmente ao estímulo; não precisa mudar como se sente.",
                    "4. Avalie o sofrimento novamente. Pode diminuir, permanecer igual ou aumentar; qualquer resposta pode ajudar na próxima escolha.",
                    "5. Se o estímulo for desagradável ou o sofrimento aumentar, pare e escolha algo mais seguro. Se a situação exigir ação, depois escolha um pequeno passo prático ou apoio."
                ],
                ["Uma cor ou contorno", "Um som familiar", "Uma textura agradável", "Apoio sob os pés", "Vou pular por enquanto"]),
            ["zh"] = new(
                "练习", "自我照护", "这是什么", "适用时机", "练习方法", "示例",
                "感官暂停", "用一分钟留意一个让你感觉舒适的线索", "温和的支持",
                "这是对 DBT 感官自我安抚技能的简短改编。选择一个已经在身边、中性或令人愉快的线索，留意几个细节。暂停可能帮助你度过困难时刻，但不保证减轻不适，也不能解决问题本身。",
                "当你想短暂停一下，而且周围有安全、适合你的线索时使用。不必特意寻找气味、味道、声音或触感。如果关注感官让你不舒服，就跳过练习。",
                "先将当前不适程度评为 0 到 10。选择一个现成的线索：一种颜色或形状、音量舒适的熟悉声音、只有在触摸令人愉快时才选择的质感，或脚下的支撑感。留意一两个细节 30–60 秒，然后再次评分。不要强迫自己平静下来。如果感觉更糟或不舒服，就停下。暂停后，如有需要，选择一个实际可行的下一步。",
                "你留意墙面上清凉的光线和柔和的边缘。半分钟后，不适程度可能没有变化；这也是有效的观察结果。你可以回到原来的任务或寻求支持。",
                "Eye", "练习前的不适程度（0–10）", "我会留意什么？", "选择一个身边已有的安全线索，或跳过此项。", "练习后的不适程度（0–10）",
                [
                    "1. 将当前的不适程度评为 0 到 10。这只是参考，不是对你应对能力的打分。",
                    "2. 选择一个身边已有的安全、中性或令人愉快的线索，例如颜色或轮廓、音量舒适的熟悉声音、令人愉快的质感，或脚下的支撑感。",
                    "3. 用约 30–60 秒留意一两个具体细节。如果注意力转移，就轻轻回到这个线索；你不必改变自己的感受。",
                    "4. 再次评估不适程度。它可能下降、保持不变或上升；任何答案都能帮助你决定下一步。",
                    "5. 如果这个线索令人不适，或不适加重，就停止并换成更安全的方式。如果情况需要行动，暂停后选择一个小的实际步骤或寻求支持。"
                ],
                ["一种颜色或轮廓", "熟悉的声音", "令人愉快的质感", "脚下的支撑感", "暂时跳过"])
        };

    internal static IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> For(string? language)
    {
        string key = language?.ToLowerInvariant() ?? "en";
        Copy copy = Languages.TryGetValue(key, out Copy? localized) ? localized : Languages["en"];
        return new Dictionary<TechniqueId, BuiltInTechniqueDefinition>
        {
            [TechniqueId.SensoryComfort] = Create(copy)
        };
    }

    private static BuiltInTechniqueDefinition Create(Copy copy) => new(
        copy.ModuleName,
        copy.Title,
        copy.Steps,
        copy.Summary,
        TechniqueUiKind.Entry,
        copy.ModuleName,
        "2026-11-04",
        copy.Title,
        copy.Subtitle,
        copy.Theme,
        copy.Author,
        1,
        copy.Icon,
        [
            new TechniqueEntrySeed(copy.BeforeTitle, Kind: EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed(copy.CueTitle, copy.CueHint, Suggestions: copy.Suggestions),
            new TechniqueEntrySeed(copy.AfterTitle, Kind: EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        [
            new TheorySection(copy.WhatHeading, copy.Summary),
            new TheorySection(copy.WhenHeading, copy.When),
            new TheorySection(copy.HowHeading, copy.How),
            new TheorySection(copy.ExampleHeading, copy.Example)
        ]);
}
