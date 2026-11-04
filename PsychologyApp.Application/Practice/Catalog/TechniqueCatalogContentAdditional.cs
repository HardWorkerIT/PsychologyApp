using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Practice.Catalog;

/// <summary>Short, localized adaptations of evidence-informed skills for the built-in practice flow.</summary>
internal static class TechniqueCatalogContentAdditional
{
    private sealed record TechniqueCopy(
        string Title,
        string Subtitle,
        string Theme,
        string Summary,
        string When,
        string How,
        string Example,
        string Icon,
        string[] Steps,
        (string Title, string Hint)[] Fields);

    private sealed record LanguageCopy(
        string ModuleName,
        string Author,
        string WhatHeading,
        string WhenHeading,
        string HowHeading,
        string ExampleHeading,
        string[] SafetyCheckSuggestions,
        string[] OptionSuggestions,
        string[] NextStepSuggestions,
        TechniqueCopy Pause,
        TechniqueCopy OppositeAction,
        TechniqueCopy ProblemSolving);

    private static readonly IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> Russian = Build(new(
        "Короткая практика", "Навык самопомощи", "Что это", "Когда применять", "Как пройти", "Пример",
        ["Есть конкретная угроза", "Прямой угрозы не вижу", "Мне нужны пауза или отдых"],
        ["Уточнить факты", "Попросить поддержки", "Разбить задачу на шаги", "Выбрать время и вернуться к вопросу"],
        ["Собрать нужную информацию", "Попросить поддержки", "Выбрать первый небольшой шаг", "Назначить время, чтобы вернуться к вопросу"],
        new(
            "Пауза перед реакцией", "Верните себе выбор за одну минуту", "Сделать паузу",
            "Навык STOP помогает прервать автоматическую реакцию, заметить факты и выбрать безопасный следующий шаг.",
            "Когда эмоция подталкивает резко ответить, написать, уйти или принять решение.",
            "Не подавляйте чувство: остановитесь, назовите импульс и выберите ответ с учётом важного для вас результата.",
            "Вместо резкого сообщения — отложить отправку, перечитать текст и задать один спокойный вопрос.", "PauseCircle",
            ["1. Стоп: на секунду остановитесь; пока не отправляйте сообщение и не принимайте решение.", "2. Сделайте шаг назад: почувствуйте опору ног и медленно выдохните.", "3. Заметьте факт ситуации, чувство и импульс («хочу резко ответить»).", "4. Спросите, какой результат важен; выберите самый маленький безопасный ответ. Если есть непосредственная опасность, сначала позаботьтесь о безопасности."],
            [("Что произошло?", "Только наблюдаемый факт"), ("Чувство и импульс", "Например: злость — резко ответить"), ("Мой следующий шаг", "Самый безопасный и полезный сейчас")] ),
        new(
            "Действие вместо импульса", "Проверьте факты, прежде чем избегать", "Выбрать безопасное действие",
            "Противоположное действие уместно, только если импульс не соответствует фактам или его сила чрезмерна. Оно не требует игнорировать опасность или нарушать границы.",
            "Когда страх, стыд или уныние толкают избегать шага, который важен для вас.",
            "Сначала проверьте факты и безопасность. Если тревога предупреждает о реальной угрозе или вам нужен отдых, не идите против неё. Иначе выберите маленькое действие в сторону своей цели.",
            "Если безопасно отправить рабочее письмо, но вы откладываете из-за тревоги, можно написать черновик и перечитать его.", "Route",
            ["1. Назовите чувство и импульс: «мне страшно, хочется отменить встречу».", "2. Проверьте факты: есть ли реальная опасность, нарушаются ли мои границы, нужен ли мне отдых? Если да — защитите себя или отдохните.", "3. Если импульс избегать не подтверждается фактами или слишком силён, вспомните свою цель.", "4. Выберите один небольшой, безопасный шаг в сторону цели. Не заставляйте себя прощать, сближаться или входить в опасную ситуацию."],
            [("Чувство и импульс", "Что хочется сделать или избежать?"), ("Что говорят факты?", "Есть ли реальная угроза или нужна пауза?"), ("Маленький безопасный шаг", "Действие в сторону моей цели")] ),
        new(
            "Разобрать решаемую задачу", "Найдите один следующий шаг", "Перейти от тупика к плану",
            "Короткое структурированное решение проблем помогает сузить расплывчатую тревогу до одного практического действия. Не каждую проблему можно решить прямо сейчас.",
            "Когда беспокоит конкретная бытовая, рабочая или учебная задача, на которую можно повлиять.",
            "Опишите задачу без самооценки, проверьте, можно ли повлиять на неё сейчас, придумайте два варианта и выберите небольшой первый шаг. Если нельзя — определите, какая информация или поддержка нужна и когда вернуться к вопросу.",
            "Вместо «у меня всё плохо» — «счёт нужно оплатить до пятницы»: проверить сумму и поставить напоминание.", "Checklist",
            ["1. Сформулируйте одну конкретную задачу, без оценки себя («я безнадёжен»).", "2. Можно ли повлиять на неё сейчас? Если нет, выберите нужную информацию, поддержку или время для возвращения к ней.", "3. Придумайте два возможных действия; не оценивайте их, пока перечисляете.", "4. Выберите небольшой выполнимый шаг и укажите, когда начнёте. Если задача связана с безопасностью или здоровьем, обратитесь за подходящей помощью."],
            [("Одна конкретная задача", "Что именно нужно решить?"), ("Два возможных действия", "Можно ли на это повлиять?"), ("Первый шаг и время", "Что сделаю и когда начну?")] )
    ));

    private static readonly IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> English = Build(new(
        "Quick practice", "Self-help skill", "What it is", "When to use it", "How to do it", "Example",
        ["There is a specific risk", "I do not see a direct threat", "I need a pause or rest"],
        ["Check the facts", "Ask for support", "Break it into smaller steps", "Set a time to return to it"],
        ["Gather one needed detail", "Ask for support", "Choose a small first step", "Set a time to revisit it"],
        new(
            "Pause Before Reacting", "Create room to choose in one minute", "Pause before acting",
            "The STOP skill interrupts an automatic reaction long enough to notice the facts and choose a safer next step.",
            "When an emotion urges you to reply, send a message, leave, or decide immediately.",
            "Do not push the feeling away. Pause, name the urge, and choose a response that serves what matters to you.",
            "Instead of sending an angry text, save it as a draft, reread it, and ask one calm question.", "PauseCircle",
            ["1. Stop: pause for a moment; do not send or decide just yet.", "2. Step back: feel your feet on the floor and slowly breathe out.", "3. Observe the facts, your feeling, and the urge (for example, “I want to snap back”).", "4. Ask what outcome matters, then choose the smallest safe response. If anyone is in immediate danger, focus on safety first."],
            [("What happened?", "A fact you could observe"), ("Feeling and urge", "For example: anger — snap back"), ("My next step", "The safest useful step right now")] ),
        new(
            "Choose a Different Action", "Check the facts before avoiding", "Take a safe step toward your goal",
            "Opposite action is appropriate only when an urge does not fit the facts or is too intense. It never means ignoring danger or giving up a boundary.",
            "When fear, shame, or low mood urges you to avoid a step that matters to you.",
            "Check the facts and your safety first. If fear signals real danger, or you need rest, do not push against it. Otherwise choose a small action toward your goal.",
            "If sending a work email is safe but anxiety makes you put it off, write a draft and review it.", "Route",
            ["1. Name the feeling and urge: “I feel nervous and want to cancel the meeting.”", "2. Check the facts: is there real danger, a boundary at stake, or a need for rest? If so, protect yourself or rest.", "3. If avoidance is not supported by the facts or feels too strong, remember the goal you chose.", "4. Choose one small, safe step toward that goal. Do not force forgiveness, closeness, or entering an unsafe situation."],
            [("Feeling and urge", "What do you want to do or avoid?"), ("What do the facts say?", "Is there danger or a need to pause?"), ("One safe small step", "An action toward your goal")] ),
        new(
            "Solve One Practical Problem", "Find one next step", "Turn a stuck point into a plan",
            "Brief structured problem-solving can turn a vague worry into one practical action. Some problems cannot be solved right now.",
            "When you are dealing with a specific practical issue you can influence.",
            "Describe the issue without judging yourself, check whether you can influence it now, list two options, and pick a small first step. If not, decide what information or support you need and when to revisit it.",
            "Instead of “everything is a mess,” define “the bill is due Friday,” check the amount, and set a reminder.", "Checklist",
            ["1. Describe one specific problem without judging yourself (“I am hopeless”).", "2. Can you influence it now? If not, identify information, support, or a time to return to it.", "3. List two possible actions without judging them yet.", "4. Choose a small doable step and say when you will start. For safety or health concerns, seek appropriate help."],
            [("One specific problem", "What exactly needs attention?"), ("Two possible actions", "Can you influence this?"), ("First step and time", "What will I do, and when?")] )
    ));

    private static readonly IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> German = Build(new(
        "Kurzübung", "Selbsthilfe-Fertigkeit", "Was es ist", "Wann es hilft", "So geht es", "Beispiel",
        ["Es gibt ein konkretes Risiko", "Ich sehe keine direkte Gefahr", "Ich brauche eine Pause oder Erholung"],
        ["Fakten klären", "Um Unterstützung bitten", "In kleinere Schritte teilen", "Einen Zeitpunkt zum Wiederaufgreifen festlegen"],
        ["Eine nötige Information sammeln", "Um Unterstützung bitten", "Einen kleinen ersten Schritt wählen", "Einen Zeitpunkt zum Wiederaufgreifen festlegen"],
        new(
            "Pause vor der Reaktion", "In einer Minute wieder wählen können", "Erst pausieren",
            "Die STOP-Fertigkeit unterbricht eine automatische Reaktion kurz, damit Sie Fakten wahrnehmen und einen sichereren nächsten Schritt wählen können.",
            "Wenn ein Gefühl Sie zu einer sofortigen Antwort, Nachricht, Flucht oder Entscheidung drängt.",
            "Unterdrücken Sie das Gefühl nicht. Halten Sie inne, benennen Sie den Impuls und wählen Sie eine Antwort, die Ihrem Ziel dient.",
            "Statt eine wütende Nachricht zu senden: als Entwurf speichern, erneut lesen und eine ruhige Frage stellen.", "PauseCircle",
            ["1. Stopp: Halten Sie kurz inne; senden oder entscheiden Sie noch nicht.", "2. Treten Sie innerlich zurück: Spüren Sie Ihre Füße und atmen Sie langsam aus.", "3. Nehmen Sie Fakten, Gefühl und Impuls wahr («Ich möchte scharf antworten»).", "4. Fragen Sie sich, welches Ergebnis wichtig ist, und wählen Sie die kleinste sichere Antwort. Bei unmittelbarer Gefahr hat Sicherheit Vorrang."],
            [("Was ist passiert?", "Eine beobachtbare Tatsache"), ("Gefühl und Impuls", "Zum Beispiel: Ärger — scharf antworten"), ("Mein nächster Schritt", "Der sicherste hilfreiche Schritt jetzt")] ),
        new(
            "Anders handeln als der Impuls", "Erst Fakten prüfen, dann vermeiden", "Sicher auf Ihr Ziel zugehen",
            "Eine entgegengesetzte Handlung passt nur, wenn der Impuls nicht zu den Fakten passt oder übermäßig stark ist. Gefahr und Grenzen dürfen nicht ignoriert werden.",
            "Wenn Angst, Scham oder Niedergeschlagenheit Sie einen wichtigen Schritt vermeiden lässt.",
            "Prüfen Sie zuerst Fakten und Sicherheit. Bei echter Gefahr oder nötiger Erholung gehen Sie nicht dagegen an. Andernfalls wählen Sie einen kleinen Schritt zu Ihrem Ziel.",
            "Wenn eine Arbeitsmail sicher ist, Sie sie aus Angst aber aufschieben, schreiben Sie einen Entwurf und prüfen ihn.", "Route",
            ["1. Benennen Sie Gefühl und Impuls: «Ich bin nervös und möchte das Treffen absagen.»", "2. Prüfen Sie die Fakten: Gibt es Gefahr, eine verletzte Grenze oder brauche ich Erholung? Dann schützen Sie sich oder ruhen Sie sich aus.", "3. Wenn die Vermeidung nicht durch Fakten gestützt wird oder übermäßig stark ist, erinnern Sie sich an Ihr Ziel.", "4. Wählen Sie einen kleinen, sicheren Schritt zum Ziel. Erzwingen Sie weder Vergebung noch Nähe oder eine unsichere Situation."],
            [("Gefühl und Impuls", "Was möchten Sie tun oder vermeiden?"), ("Was sagen die Fakten?", "Gefahr oder Bedarf an einer Pause?"), ("Ein kleiner sicherer Schritt", "Eine Handlung in Richtung Ihres Ziels")] ),
        new(
            "Ein lösbares Problem angehen", "Finden Sie den nächsten Schritt", "Aus einer Sackgasse wird ein Plan",
            "Strukturiertes Problemlösen kann diffuse Sorgen in eine konkrete Handlung verwandeln. Manche Probleme sind jetzt nicht lösbar.",
            "Bei einer konkreten praktischen Aufgabe, auf die Sie Einfluss haben.",
            "Beschreiben Sie die Aufgabe ohne Selbstkritik, prüfen Sie Ihren Einfluss, sammeln Sie zwei Möglichkeiten und wählen Sie einen kleinen ersten Schritt. Sonst klären Sie, welche Information oder Unterstützung fehlt und wann Sie es erneut angehen.",
            "Statt «Alles läuft schief»: «Die Rechnung ist am Freitag fällig» — Betrag prüfen und Erinnerung einstellen.", "Checklist",
            ["1. Beschreiben Sie ein konkretes Problem, ohne sich selbst abzuwerten («Ich bin unfähig»).", "2. Können Sie jetzt etwas beeinflussen? Wenn nicht, notieren Sie Information, Unterstützung oder einen Zeitpunkt zum Wiederaufgreifen.", "3. Sammeln Sie zwei mögliche Schritte, ohne sie sofort zu bewerten.", "4. Wählen Sie einen kleinen machbaren Schritt und legen Sie den Start fest. Bei Sicherheits- oder Gesundheitsfragen holen Sie passende Hilfe."],
            [("Ein konkretes Problem", "Was genau muss gelöst werden?"), ("Zwei mögliche Schritte", "Können Sie etwas beeinflussen?"), ("Erster Schritt und Zeitpunkt", "Was tun Sie, und wann?")] )
    ));

    private static readonly IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> French = Build(new(
        "Pratique courte", "Compétence d’auto-aide", "De quoi s’agit-il ?", "Quand l’utiliser", "Comment faire", "Exemple",
        ["Il existe un risque concret", "Je ne vois pas de danger direct", "J’ai besoin d’une pause ou de repos"],
        ["Vérifier les faits", "Demander du soutien", "Découper en petites étapes", "Fixer un moment pour y revenir"],
        ["Recueillir une information utile", "Demander du soutien", "Choisir une petite première étape", "Fixer un moment pour reprendre le sujet"],
        new(
            "Faire une pause avant de réagir", "Retrouvez le choix en une minute", "Faire une pause",
            "La compétence STOP interrompt brièvement une réaction automatique pour observer les faits et choisir la prochaine étape la plus sûre.",
            "Quand une émotion vous pousse à répondre, écrire, partir ou décider immédiatement.",
            "Ne repoussez pas l’émotion. Faites une pause, nommez l’impulsion et choisissez une réponse qui sert votre objectif.",
            "Au lieu d’envoyer un message en colère, gardez-le en brouillon, relisez-le et posez une question calme.", "PauseCircle",
            ["1. Stop : arrêtez-vous un instant ; n’envoyez rien et ne décidez pas tout de suite.", "2. Prenez du recul : sentez vos pieds au sol et expirez lentement.", "3. Observez les faits, l’émotion et l’impulsion (« j’ai envie de répondre sèchement »).", "4. Demandez-vous quel résultat compte, puis choisissez la plus petite réponse sûre. En cas de danger immédiat, privilégiez d’abord la sécurité."],
            [("Que s’est-il passé ?", "Un fait observable"), ("Émotion et impulsion", "Par exemple : colère — répondre sèchement"), ("Ma prochaine étape", "L’étape la plus sûre et utile maintenant")] ),
        new(
            "Choisir une autre action", "Vérifiez les faits avant d’éviter", "Avancer sans vous mettre en danger",
            "L’action opposée convient seulement si l’impulsion ne correspond pas aux faits ou si elle est trop intense. Elle ne consiste jamais à ignorer un danger ou une limite.",
            "Quand la peur, la honte ou le découragement vous pousse à éviter une étape importante.",
            "Vérifiez d’abord les faits et votre sécurité. S’il y a un danger réel ou si vous avez besoin de repos, n’allez pas contre cela. Sinon, choisissez une petite action vers votre objectif.",
            "Si envoyer un courriel professionnel est sûr mais que l’anxiété vous freine, rédigez un brouillon et relisez-le.", "Route",
            ["1. Nommez l’émotion et l’impulsion : « Je suis nerveux et je veux annuler le rendez-vous. »", "2. Vérifiez les faits : y a-t-il un danger, une limite à protéger ou un besoin de repos ? Dans ce cas, protégez-vous ou reposez-vous.", "3. Si les faits ne justifient pas l’évitement ou si l’impulsion est trop forte, rappelez-vous votre objectif.", "4. Choisissez une petite étape sûre vers cet objectif. Ne vous forcez ni à pardonner, ni à vous rapprocher, ni à entrer dans une situation dangereuse."],
            [("Émotion et impulsion", "Que voulez-vous faire ou éviter ?"), ("Que disent les faits ?", "Danger ou besoin de pause ?"), ("Une petite étape sûre", "Une action vers votre objectif")] ),
        new(
            "Résoudre un problème concret", "Trouvez la prochaine étape", "Transformer un blocage en plan",
            "Une résolution structurée peut transformer une inquiétude vague en action concrète. Certains problèmes ne peuvent pas être résolus maintenant.",
            "Pour une difficulté pratique précise sur laquelle vous pouvez agir.",
            "Décrivez le problème sans vous juger, vérifiez si vous pouvez agir maintenant, listez deux options et choisissez une première étape. Sinon, identifiez l’information ou le soutien nécessaire et le moment pour y revenir.",
            "Au lieu de « tout va mal », formulez « la facture est due vendredi », vérifiez le montant et programmez un rappel.", "Checklist",
            ["1. Décrivez un problème précis sans vous juger (« je suis incapable »).", "2. Pouvez-vous agir maintenant ? Sinon, notez l’information, le soutien ou le moment nécessaire pour y revenir.", "3. Trouvez deux actions possibles sans les évaluer tout de suite.", "4. Choisissez une petite étape réalisable et fixez son début. Pour la sécurité ou la santé, demandez une aide adaptée."],
            [("Un problème précis", "Que faut-il résoudre exactement ?"), ("Deux actions possibles", "Pouvez-vous agir dessus ?"), ("Première étape et moment", "Que ferez-vous et quand ?")] )
    ));

    private static readonly IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> Spanish = Build(new(
        "Práctica breve", "Habilidad de autocuidado", "Qué es", "Cuándo usarla", "Cómo hacerla", "Ejemplo",
        ["Hay un riesgo concreto", "No veo una amenaza directa", "Necesito una pausa o descansar"],
        ["Comprobar los hechos", "Pedir apoyo", "Dividirlo en pasos pequeños", "Elegir un momento para retomarlo"],
        ["Buscar un dato necesario", "Pedir apoyo", "Elegir un primer paso pequeño", "Fijar cuándo volver al tema"],
        new(
            "Pausa antes de reaccionar", "Recupera la capacidad de elegir en un minuto", "Haz una pausa",
            "La habilidad STOP interrumpe por un momento una reacción automática para observar los hechos y elegir el siguiente paso más seguro.",
            "Cuando una emoción te impulsa a responder, escribir, irte o decidir de inmediato.",
            "No rechaces lo que sientes. Haz una pausa, nombra el impulso y elige una respuesta que te acerque al resultado que te importa.",
            "En vez de enviar un mensaje enfadado, guárdalo como borrador, léelo de nuevo y haz una pregunta tranquila.", "PauseCircle",
            ["1. Para: detente un instante; no envíes el mensaje ni decidas todavía.", "2. Toma distancia: siente los pies en el suelo y suelta el aire despacio.", "3. Observa los hechos, la emoción y el impulso («quiero contestar mal»).", "4. Pregúntate qué resultado importa y elige la respuesta segura más pequeña. Si hay peligro inmediato, prioriza la seguridad."],
            [("¿Qué ocurrió?", "Un hecho que se pueda observar"), ("Emoción e impulso", "Por ejemplo: enfado — contestar mal"), ("Mi siguiente paso", "El paso más seguro y útil ahora")] ),
        new(
            "Elegir otra acción", "Comprueba los hechos antes de evitar", "Avanza de forma segura hacia tu objetivo",
            "La acción opuesta solo conviene si el impulso no encaja con los hechos o es demasiado intenso. Nunca significa ignorar un peligro o renunciar a un límite.",
            "Cuando el miedo, la vergüenza o el desánimo te llevan a evitar un paso importante.",
            "Comprueba primero los hechos y tu seguridad. Si hay un peligro real o necesitas descansar, no vayas en contra. Si no, elige una acción pequeña hacia tu objetivo.",
            "Si enviar un correo de trabajo es seguro, pero la ansiedad te frena, redacta un borrador y revísalo.", "Route",
            ["1. Nombra la emoción y el impulso: «Estoy nervioso y quiero cancelar la reunión».", "2. Comprueba los hechos: ¿hay peligro, un límite que proteger o necesito descansar? Si es así, protégete o descansa.", "3. Si los hechos no respaldan la evitación o el impulso es demasiado intenso, recuerda tu objetivo.", "4. Elige un paso pequeño y seguro hacia ese objetivo. No te obligues a perdonar, acercarte o entrar en una situación insegura."],
            [("Emoción e impulso", "¿Qué quieres hacer o evitar?"), ("¿Qué dicen los hechos?", "¿Hay peligro o necesitas parar?"), ("Un paso pequeño y seguro", "Una acción hacia tu objetivo")] ),
        new(
            "Resolver un problema concreto", "Encuentra un siguiente paso", "Convierte un bloqueo en un plan",
            "La resolución estructurada puede convertir una preocupación vaga en una acción práctica. Algunos problemas no se pueden resolver ahora.",
            "Cuando tienes un problema práctico concreto en el que puedes influir.",
            "Describe el problema sin juzgarte, comprueba si puedes influir ahora, anota dos opciones y elige un primer paso. Si no, decide qué información o apoyo necesitas y cuándo volver al tema.",
            "En vez de «todo va mal», define «la factura vence el viernes», comprueba el importe y programa un recordatorio.", "Checklist",
            ["1. Describe un problema concreto sin juzgarte («no valgo para nada»).", "2. ¿Puedes influir ahora? Si no, identifica la información, el apoyo o el momento para retomarlo.", "3. Anota dos acciones posibles sin evaluarlas todavía.", "4. Elige un paso pequeño y posible y decide cuándo empezar. Si afecta a tu salud o seguridad, busca ayuda adecuada."],
            [("Un problema concreto", "¿Qué hay que resolver exactamente?"), ("Dos acciones posibles", "¿Puedes influir en ello?"), ("Primer paso y momento", "¿Qué harás y cuándo?")] )
    ));

    private static readonly IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> Portuguese = Build(new(
        "Prática breve", "Habilidade de autocuidado", "O que é", "Quando usar", "Como fazer", "Exemplo",
        ["Há um risco específico", "Não vejo uma ameaça direta", "Preciso de uma pausa ou descanso"],
        ["Conferir os fatos", "Pedir apoio", "Dividir em etapas menores", "Definir quando retomar o assunto"],
        ["Buscar uma informação necessária", "Pedir apoio", "Escolher um primeiro passo pequeno", "Definir quando voltar ao assunto"],
        new(
            "Pausa antes de reagir", "Recupere a capacidade de escolher em um minuto", "Faça uma pausa",
            "A habilidade STOP interrompe por um instante uma reação automática para observar os fatos e escolher o próximo passo mais seguro.",
            "Quando uma emoção leva você a responder, escrever, sair ou decidir imediatamente.",
            "Não tente afastar o sentimento. Faça uma pausa, nomeie o impulso e escolha uma resposta que sirva ao que importa para você.",
            "Em vez de enviar uma mensagem irritada, salve como rascunho, releia e faça uma pergunta tranquila.", "PauseCircle",
            ["1. Pare: faça uma pausa; ainda não envie a mensagem nem tome a decisão.", "2. Afaste-se um pouco: sinta os pés no chão e solte o ar devagar.", "3. Observe os fatos, o sentimento e o impulso («quero responder com rispidez»).", "4. Pergunte qual resultado importa e escolha a menor resposta segura. Se houver perigo imediato, priorize a segurança."],
            [("O que aconteceu?", "Um fato que possa ser observado"), ("Sentimento e impulso", "Por exemplo: raiva — responder com rispidez"), ("Meu próximo passo", "O passo mais seguro e útil agora")] ),
        new(
            "Escolha outra ação", "Confira os fatos antes de evitar", "Avance com segurança em direção ao seu objetivo",
            "A ação oposta só é adequada quando o impulso não corresponde aos fatos ou é intenso demais. Ela nunca significa ignorar o perigo ou abrir mão de limites.",
            "Quando o medo, a vergonha ou o desânimo levam você a evitar um passo importante.",
            "Confira primeiro os fatos e sua segurança. Se houver perigo real ou você precisar descansar, não force o contrário. Caso contrário, escolha uma pequena ação em direção ao seu objetivo.",
            "Se enviar um e-mail de trabalho é seguro, mas a ansiedade faz você adiar, escreva um rascunho e revise-o.", "Route",
            ["1. Nomeie o sentimento e o impulso: «Estou nervoso e quero cancelar a reunião».", "2. Confira os fatos: há perigo, um limite a proteger ou preciso descansar? Se sim, proteja-se ou descanse.", "3. Se os fatos não justificam evitar ou o impulso é forte demais, lembre-se do seu objetivo.", "4. Escolha um pequeno passo seguro em direção ao objetivo. Não se force a perdoar, aproximar-se ou entrar em uma situação insegura."],
            [("Sentimento e impulso", "O que você quer fazer ou evitar?"), ("O que dizem os fatos?", "Há perigo ou necessidade de pausa?"), ("Um pequeno passo seguro", "Uma ação em direção ao seu objetivo")] ),
        new(
            "Resolver um problema prático", "Encontre o próximo passo", "Transforme o bloqueio em um plano",
            "A resolução estruturada pode transformar uma preocupação vaga em uma ação prática. Alguns problemas não podem ser resolvidos agora.",
            "Quando há uma questão prática específica sobre a qual você pode agir.",
            "Descreva o problema sem se julgar, confira se pode influenciá-lo agora, liste duas opções e escolha um primeiro passo pequeno. Caso contrário, identifique a informação ou o apoio necessário e quando retomar o assunto.",
            "Em vez de «está tudo dando errado», defina «a conta vence na sexta», confira o valor e programe um lembrete.", "Checklist",
            ["1. Descreva um problema específico sem se julgar («não sirvo para nada»).", "2. Você pode influenciá-lo agora? Se não, anote a informação, o apoio ou o momento para retomá-lo.", "3. Liste duas ações possíveis sem avaliá-las ainda.", "4. Escolha um passo pequeno e viável e defina quando começar. Para questões de saúde ou segurança, procure ajuda adequada."],
            [("Um problema específico", "O que exatamente precisa ser resolvido?"), ("Duas ações possíveis", "Você pode influenciar isso?"), ("Primeiro passo e horário", "O que fará e quando?")] )
    ));

    private static readonly IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> Chinese = Build(new(
        "快速练习", "自助调节技能", "这是什么", "适用时机", "练习方法", "示例",
        ["存在具体风险", "我没有发现直接威胁", "我需要暂停或休息"],
        ["核实事实", "寻求支持", "拆分成更小的步骤", "设定时间再回来处理"],
        ["收集一条必要信息", "寻求支持", "选择一个小的第一步", "设定之后重新处理的时间"],
        new(
            "反应前暂停", "用一分钟重新找回选择", "先暂停一下",
            "STOP 技能让自动反应短暂停下来，帮助你观察事实并选择更安全的下一步。",
            "当情绪促使你立刻回复、发消息、离开或做决定时。",
            "不要压下感受。先暂停，辨认冲动，再选择有助于实现重要结果的回应。",
            "不要马上发送生气的信息；先保存为草稿、重新阅读，再提出一个平静的问题。", "PauseCircle",
            ["1. 停：暂停片刻，先不要发送信息或做决定。", "2. 退一步：感受双脚接触地面，慢慢呼气。", "3. 观察事实、感受和冲动（例如“我想立刻顶回去”）。", "4. 想想什么结果最重要，选择最小且安全的回应。如有紧急危险，先确保安全。"],
            [("发生了什么？", "可以观察到的事实"), ("感受和冲动", "例如：愤怒——想立刻回击"), ("我的下一步", "现在最安全且有帮助的一步")] ),
        new(
            "选择不同的行动", "先核对事实，再决定是否回避", "安全地迈向目标",
            "只有当冲动与事实不符或强烈过度时，才适合采用相反行动。这不意味着忽视危险或放弃自己的界限。",
            "当恐惧、羞耻或低落让你回避重要的一步时。",
            "先核对事实和安全。如果确有危险或你需要休息，不要勉强自己反着做。否则，选择一个朝目标前进的小行动。",
            "如果发送工作邮件是安全的，但焦虑使你拖延，可以先写草稿再检查。", "Route",
            ["1. 说出感受和冲动：“我很紧张，想取消这次会面。”", "2. 核对事实：是否有现实危险、需要保护的界限，或需要休息？如果有，先保护自己或休息。", "3. 如果事实并不支持回避，或冲动强度过高，想起你选择的目标。", "4. 选择一个朝目标前进的小而安全的步骤。不要强迫自己原谅、亲近他人或进入不安全的情境。"],
            [("感受和冲动", "你想做什么，或想回避什么？"), ("事实是什么？", "有危险或需要暂停吗？"), ("一个安全的小步骤", "朝目标前进的行动")] ),
        new(
            "解决一个具体问题", "找到下一步", "把卡住的事情变成计划",
            "结构化的问题解决可以把模糊担忧转成具体行动。有些问题现在无法解决。",
            "当你面对一个具体、并且可以采取行动的实际问题时。",
            "不评判自己，先描述问题并确认现在能否影响它；列出两个选项，选一个小的第一步。如果现在无法解决，确定还需要什么信息或支持，以及何时再处理。",
            "不要只说“什么都不顺”，而是明确“账单周五到期”，核对金额并设置提醒。", "Checklist",
            ["1. 描述一个具体问题，不要评价自己（如“我一无是处”）。", "2. 现在能影响它吗？如果不能，写下需要的信息、支持或重新处理的时间。", "3. 列出两个可能的行动，暂时不评判。", "4. 选一个可完成的小步骤并确定开始时间。涉及健康或安全时，请寻求适当帮助。"],
            [("一个具体问题", "究竟需要解决什么？"), ("两个可能的行动", "你能影响这件事吗？"), ("第一步和时间", "你会做什么，什么时候开始？")] )
    ));

    internal static IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> For(string? language) =>
        (language?.ToLowerInvariant() switch
        {
            "ru" => Russian,
            "de" => German,
            "fr" => French,
            "es" => Spanish,
            "pt" => Portuguese,
            "zh" => Chinese,
            _ => English
        });

    private static IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> Build(LanguageCopy language) =>
        new Dictionary<TechniqueId, BuiltInTechniqueDefinition>
        {
            [TechniqueId.PauseBeforeReaction] = Create(language, language.Pause, EntryFieldRole.Problem, EntryFieldRole.Emotion, null),
            [TechniqueId.OppositeAction] = Create(language, language.OppositeAction, EntryFieldRole.Emotion, EntryFieldRole.Problem, language.SafetyCheckSuggestions),
            [TechniqueId.ProblemSolving] = Create(language, language.ProblemSolving, EntryFieldRole.Problem, EntryFieldRole.None, language.OptionSuggestions)
        };

    private static BuiltInTechniqueDefinition Create(
        LanguageCopy language,
        TechniqueCopy copy,
        EntryFieldRole firstRole,
        EntryFieldRole secondRole,
        IReadOnlyList<string>? secondSuggestions) => new(
        language.ModuleName,
        copy.Title,
        copy.Steps,
        copy.Summary,
        TechniqueUiKind.Entry,
        language.ModuleName,
        "03.11.2026",
        copy.Title,
        copy.Subtitle,
        copy.Theme,
        language.Author,
        1,
        copy.Icon,
        [
            new TechniqueEntrySeed(copy.Fields[0].Title, copy.Fields[0].Hint, Role: firstRole),
            new TechniqueEntrySeed(copy.Fields[1].Title, copy.Fields[1].Hint, Suggestions: secondSuggestions, Role: secondRole),
            new TechniqueEntrySeed(copy.Fields[2].Title, copy.Fields[2].Hint, Suggestions: language.NextStepSuggestions)
        ],
        [
            new TheorySection(language.WhatHeading, copy.Summary),
            new TheorySection(language.WhenHeading, copy.When),
            new TheorySection(language.HowHeading, copy.How),
            new TheorySection(language.ExampleHeading, copy.Example)
        ]);
}
