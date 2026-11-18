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

    internal static IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> For(string? language)
    {
        string languageCode = language?.ToLowerInvariant() ?? string.Empty;
        IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> catalog = languageCode switch
        {
            "ru" => Russian,
            "de" => German,
            "fr" => French,
            "es" => Spanish,
            "pt" => Portuguese,
            "zh" => Chinese,
            _ => English
        };
        Dictionary<TechniqueId, BuiltInTechniqueDefinition> complete = catalog.ToDictionary(entry => entry.Key, entry => entry.Value);
        complete.Add(TechniqueId.ExternalOrientation, CreateExternalOrientation(languageCode));
        complete.Add(TechniqueId.NewsCheckPlan, CreateNewsCheckPlan(languageCode));
        complete.Add(TechniqueId.HabitRestartPlan, CreateHabitRestartPlan(languageCode));
        complete.Add(TechniqueId.FeedbackReview, CreateFeedbackReview(languageCode));
        complete.Add(TechniqueId.ConnectionStepPlan, CreateConnectionStepPlan(languageCode));
        return complete;
    }

    private static BuiltInTechniqueDefinition CreateExternalOrientation(string language)
    {
        if (language is not ("ru" or "en" or "de" or "fr" or "es" or "pt" or "zh"))
        {
            language = "en";
        }


        (string ModuleName, string Author, string WhatHeading, string WhenHeading, string HowHeading, string ExampleHeading, TechniqueCopy Copy) localized =
            language switch
            {
                "ru" => ("Короткая практика", "PsychologyApp", "Что это", "Когда помогает", "Как пройти", "Пример",
                    new("Три нейтральные детали", "Сориентироваться в окружающей обстановке", "Трудный момент",
                        "Короткая практика внимания к внешней обстановке. Может помочь заметить, где вы сейчас; она не обязана уменьшить тревогу.",
                        "Когда мысли разбегаются или фокус на дыхании и теле не подходит. Это не замена практической помощи при опасности.",
                        "Назовите три нейтральных предмета, заметьте один звук или деталь и выберите следующий безопасный шаг. Остановитесь, если становится хуже.",
                        "Назовите цвет стены, форму чашки и положение окна; затем решите, что сделать дальше.", "Visibility",
                        ["1. Найдите вокруг три нейтральных предмета и назовите их про себя.", "2. Заметьте один звук или деталь обстановки; не заставляйте себя следить за телом или дыханием.", "3. Назовите место, где вы находитесь, и один безопасный следующий шаг. Если становится неприятнее, остановитесь."],
                        [("Три предмета", "Цвет, форма или положение"), ("Звук или деталь", "Можно пропустить, если не подходит"), ("Мой следующий шаг", "Один небольшой и безопасный")])),
                "en" => ("Short practice", "PsychologyApp", "What it is", "When it may help", "How to try it", "Example",
                    new("Three neutral details", "Orient to the space around you", "Hard moment",
                        "A brief practice of noticing the surroundings. It may help you notice where you are; it does not have to reduce worry.",
                        "When thoughts race or focusing on breath and body does not feel right. It is not a substitute for practical help in danger.",
                        "Name three neutral objects, notice one sound or detail, and choose a safe next step. Stop if you feel worse.",
                        "Name a wall color, the shape of a cup, and where a window is; then choose what to do next.", "Visibility",
                        ["1. Find three neutral objects nearby and name them silently.", "2. Notice one sound or detail around you; you do not have to focus on your body or breathing.", "3. Name where you are and one safe next step. Stop if this feels worse."],
                        [("Three objects", "Color, shape, or position"), ("A sound or detail", "Skip it if it does not feel right"), ("My next step", "One small, safe action")])),
                "de" => ("Kurze Übung", "PsychologyApp", "Was es ist", "Wann es helfen kann", "So geht es", "Beispiel",
                    new("Drei neutrale Details", "Sich an der Umgebung orientieren", "Schwieriger Moment",
                        "Eine kurze Übung, um die Umgebung wahrzunehmen. Sie kann helfen, den aktuellen Ort bewusster zu bemerken; sie muss die Sorge nicht verringern.",
                        "Wenn Gedanken kreisen oder die Konzentration auf Atem und Körper nicht passt. Bei Gefahr ersetzt sie keine praktische Hilfe.",
                        "Nennen Sie drei neutrale Gegenstände, bemerken Sie ein Geräusch oder Detail und wählen Sie einen sicheren nächsten Schritt. Hören Sie auf, wenn es Ihnen schlechter geht.",
                        "Nennen Sie die Wandfarbe, die Form einer Tasse und die Position des Fensters; wählen Sie dann den nächsten Schritt.", "Visibility",
                        ["1. Finden Sie drei neutrale Gegenstände in Ihrer Nähe und benennen Sie sie leise für sich.", "2. Achten Sie auf ein Geräusch oder ein Detail der Umgebung; Sie müssen nicht auf Körper oder Atmung achten.", "3. Benennen Sie Ihren Aufenthaltsort und einen sicheren nächsten Schritt. Hören Sie auf, wenn es unangenehmer wird."],
                        [("Drei Gegenstände", "Farbe, Form oder Position"), ("Ein Geräusch oder Detail", "Lassen Sie es aus, wenn es nicht passt"), ("Mein nächster Schritt", "Eine kleine, sichere Handlung")])),
                "fr" => ("Exercice bref", "PsychologyApp", "De quoi s’agit-il", "Quand cela peut aider", "Comment essayer", "Exemple",
                    new("Trois détails neutres", "Se repérer dans son environnement", "Moment difficile",
                        "Un bref exercice d’attention à l’environnement. Il peut aider à remarquer où vous êtes ; il n’a pas à faire baisser l’inquiétude.",
                        "Quand les pensées s’emballent ou que se concentrer sur le souffle et le corps ne convient pas. En cas de danger, cela ne remplace pas une aide pratique.",
                        "Nommez trois objets neutres, remarquez un son ou un détail, puis choisissez une prochaine étape sûre. Arrêtez si vous vous sentez moins bien.",
                        "Nommez la couleur du mur, la forme d’une tasse et la place d’une fenêtre ; choisissez ensuite la suite.", "Visibility",
                        ["1. Repérez trois objets neutres autour de vous et nommez-les en silence.", "2. Remarquez un son ou un détail de l’environnement ; vous n’avez pas à vous concentrer sur votre corps ou votre respiration.", "3. Nommez l’endroit où vous êtes et une prochaine étape sûre. Arrêtez si cela devient plus difficile."],
                        [("Trois objets", "Couleur, forme ou position"), ("Un son ou un détail", "Vous pouvez l’omettre si cela ne convient pas"), ("Ma prochaine étape", "Une petite action sûre")])),
                "es" => ("Práctica breve", "PsychologyApp", "Qué es", "Cuándo puede ayudar", "Cómo probarla", "Ejemplo",
                    new("Tres detalles neutros", "Ubícate en el entorno", "Momento difícil",
                        "Una práctica breve para notar el entorno. Puede ayudarte a reconocer dónde estás; no tiene que reducir la preocupación.",
                        "Cuando los pensamientos se aceleran o no te viene bien centrarte en la respiración y el cuerpo. No sustituye la ayuda práctica ante un peligro.",
                        "Nombra tres objetos neutros, observa un sonido o detalle y elige un siguiente paso seguro. Para si te sientes peor.",
                        "Nombra el color de la pared, la forma de una taza y dónde está la ventana; después elige qué hacer.", "Visibility",
                        ["1. Busca tres objetos neutros a tu alrededor y nómbralos en silencio.", "2. Nota un sonido o detalle del entorno; no tienes que centrarte en el cuerpo ni en la respiración.", "3. Di dónde estás y elige un siguiente paso seguro. Para si esto te hace sentir peor."],
                        [("Tres objetos", "Color, forma o posición"), ("Un sonido o detalle", "Puedes omitirlo si no te va bien"), ("Mi siguiente paso", "Una acción pequeña y segura")])),
                "pt" => ("Prática breve", "PsychologyApp", "O que é", "Quando pode ajudar", "Como experimentar", "Exemplo",
                    new("Três detalhes neutros", "Perceba o ambiente ao redor", "Momento difícil",
                        "Uma prática breve para notar o ambiente. Ela pode ajudar você a perceber onde está; não precisa diminuir a preocupação.",
                        "Quando os pensamentos aceleram ou focar na respiração e no corpo não combina com você. Não substitui ajuda prática em caso de perigo.",
                        "Nomeie três objetos neutros, perceba um som ou detalhe e escolha o próximo passo seguro. Pare se você se sentir pior.",
                        "Nomeie a cor da parede, o formato de uma xícara e onde fica a janela; depois escolha o que fazer.", "Visibility",
                        ["1. Encontre três objetos neutros ao seu redor e nomeie-os em silêncio.", "2. Perceba um som ou detalhe do ambiente; você não precisa focar no corpo ou na respiração.", "3. Diga onde está e escolha um próximo passo seguro. Pare se isso piorar seu desconforto."],
                        [("Três objetos", "Cor, forma ou posição"), ("Um som ou detalhe", "Você pode pular se não for adequado"), ("Meu próximo passo", "Uma ação pequena e segura")])),
                _ => ("短暂练习", "PsychologyApp", "这是什么", "什么时候可能有帮助", "如何尝试", "示例",
                    new("三个中性细节", "注意周围的环境", "困难时刻",
                        "这是一个短暂留意周围环境的练习，可能帮助你觉察自己所在的位置；它不一定能减轻担忧。",
                        "当思绪飞快，或关注呼吸和身体不适合你时。面对危险时，它不能替代实际帮助。",
                        "说出三个中性的物品，留意一个声音或细节，再选择一个安全的下一步。如果感觉更糟，请停止。",
                        "说出墙的颜色、杯子的形状和窗户的位置，然后决定下一步做什么。", "Visibility",
                        ["1. 找到身边三个中性的物品，在心里说出它们的名称。", "2. 留意一个声音或环境细节；不必关注身体或呼吸。", "3. 说出你所在的位置，并选择一个安全的下一步。如果不舒服加重，请停止。"],
                        [("三个物品", "颜色、形状或位置"), ("一个声音或细节", "不适合时可以跳过"), ("我的下一步", "一个小而安全的行动")]))
            };

        TechniqueCopy copy = localized.Copy;
        return new BuiltInTechniqueDefinition(
            localized.ModuleName, copy.Title, copy.Steps, copy.Summary, TechniqueUiKind.Entry,
            localized.ModuleName, "17.11.2026", copy.Title, copy.Subtitle, copy.Theme, localized.Author,
            1, copy.Icon,
            [
                new TechniqueEntrySeed(copy.Fields[0].Title, copy.Fields[0].Hint),
                new TechniqueEntrySeed(copy.Fields[1].Title, copy.Fields[1].Hint),
                new TechniqueEntrySeed(copy.Fields[2].Title, copy.Fields[2].Hint)
            ],
            [
                new TheorySection(localized.WhatHeading, copy.Summary),
                new TheorySection(localized.WhenHeading, copy.When),
                new TheorySection(localized.HowHeading, copy.How),
                new TheorySection(localized.ExampleHeading, copy.Example)
            ]);
    }


    private static BuiltInTechniqueDefinition CreateNewsCheckPlan(string language)
    {
        if (language is not ("ru" or "en" or "de" or "fr" or "es" or "pt" or "zh"))
        {
            language = "en";
        }
        (string ModuleName, string Author, string WhatHeading, string WhenHeading, string HowHeading, string ExampleHeading, TechniqueCopy Copy) localized =
            language switch
            {
                "ru" => ("Короткая практика", "PsychologyApp", "Что это", "Когда помогает", "Как пройти", "Пример",
                    new("План проверки новостей", "Проверить важное без бесконечного обновления ленты", "Трудный момент",
                        "Короткий план помогает получать нужные сведения, не превращая каждое уведомление в повод открыть ленту. Это не запрет на новости.",
                        "Когда хочется снова проверить обновления, хотя конкретный вопрос уже получил ответ.",
                        "Сформулируйте один вопрос, выберите надёжный источник и подходящее время. Сохраните важные оповещения о безопасности, работе и семье. После проверки закройте ленту или назначьте следующую.",
                        "Проверить время отправления поезда на сайте перевозчика, сохранить важные оповещения и после этого вернуться к своим делам.", "TipsAndUpdates",
                        ["1. Спросите себя, что именно нужно узнать. При срочной угрозе безопасности проверяйте информацию сразу.",
                         "2. Выберите один надёжный источник и подходящий момент. Не отключайте оповещения, важные для безопасности, работы или семьи.",
                         "3. Когда ответ найден, решите, когда проверите новости снова, и переключитесь на одно конкретное дело."],
                        [("Мой вопрос", "Что конкретно мне нужно узнать?"),
                         ("Источник и время", "Надёжный источник и удобный момент"),
                         ("После проверки", "Одно небольшое следующее действие")])) ,
                "en" => ("Short practice", "PsychologyApp", "What it is", "When it may help", "How to try it", "Example",
                    new("Plan a news check", "Check what matters without endless refreshing", "Hard moment",
                        "A short plan can help you get the information you need without treating every alert as a reason to open the feed. It is not a ban on news.",
                        "When you want to check again even though your specific question has already been answered.",
                        "Name one question, choose a reliable source and a suitable time. Keep alerts that matter for safety, work, and family. After checking, close the feed or choose the next check time.",
                        "Check a train departure on the operator’s site, keep essential alerts on, then return to your plans.", "TipsAndUpdates",
                        ["1. Ask what you need to know. If safety is urgent, check the information now.",
                         "2. Choose one reliable source and a suitable time. Keep alerts needed for safety, work, or family.",
                         "3. Once you have the answer, decide when to check again and move to one concrete task."],
                        [("My question", "What do I need to know?"),
                         ("Source and time", "A reliable source and suitable moment"),
                         ("After checking", "One small next action")])) ,
                "de" => ("Kurze Übung", "PsychologyApp", "Was es ist", "Wann es helfen kann", "So geht es", "Beispiel",
                    new("Nachrichtenprüfung planen", "Wichtiges prüfen, ohne endlos zu aktualisieren", "Schwieriger Moment",
                        "Ein kurzer Plan hilft, nötige Informationen zu bekommen, ohne jede Meldung zum Anlass für den Feed zu machen. Nachrichten sind damit nicht verboten.",
                        "Wenn Sie erneut nachsehen möchten, obwohl Ihre konkrete Frage bereits beantwortet ist.",
                        "Formulieren Sie eine Frage, wählen Sie eine zuverlässige Quelle und einen passenden Zeitpunkt. Behalten Sie wichtige Meldungen zu Sicherheit, Arbeit und Familie. Schließen Sie danach den Feed oder planen Sie die nächste Prüfung.",
                        "Die Abfahrtszeit eines Zuges auf der Website des Betreibers prüfen, wichtige Meldungen behalten und danach zum Alltag zurückkehren.", "TipsAndUpdates",
                        ["1. Fragen Sie sich, was Sie genau wissen möchten. Bei einer akuten Sicherheitsfrage prüfen Sie die Information sofort.",
                         "2. Wählen Sie eine zuverlässige Quelle und einen passenden Zeitpunkt. Behalten Sie wichtige Meldungen zu Sicherheit, Arbeit oder Familie.",
                         "3. Wenn Sie die Antwort haben, legen Sie die nächste Prüfung fest und wenden Sie sich einer konkreten Aufgabe zu."],
                        [("Meine Frage", "Was möchte ich wissen?"),
                         ("Quelle und Zeit", "Zuverlässige Quelle und passender Zeitpunkt"),
                         ("Danach", "Eine kleine nächste Handlung")])) ,
                "fr" => ("Exercice bref", "PsychologyApp", "De quoi s’agit-il", "Quand cela peut aider", "Comment essayer", "Exemple",
                    new("Planifier sa consultation des nouvelles", "Vérifier l’essentiel sans actualiser sans fin", "Moment difficile",
                        "Un plan bref peut aider à obtenir les informations nécessaires sans faire de chaque alerte une raison d’ouvrir le fil. Il ne s’agit pas d’interdire les nouvelles.",
                        "Quand vous avez envie de vérifier encore alors que votre question précise a déjà une réponse.",
                        "Formulez une question, choisissez une source fiable et un moment adapté. Gardez les alertes utiles pour la sécurité, le travail et vos proches. Après la consultation, fermez le fil ou choisissez le prochain moment.",
                        "Vérifier l’horaire d’un train sur le site de l’opérateur, garder les alertes importantes puis reprendre ses activités.", "TipsAndUpdates",
                        ["1. Demandez-vous ce que vous voulez savoir. En cas d’urgence liée à la sécurité, vérifiez tout de suite.",
                         "2. Choisissez une source fiable et un moment adapté. Gardez les alertes liées à la sécurité, au travail ou à vos proches.",
                         "3. Une fois la réponse trouvée, décidez quand consulter à nouveau et passez à une activité concrète."],
                        [("Ma question", "Que dois-je savoir précisément ?"),
                         ("Source et moment", "Une source fiable et un moment adapté"),
                         ("Après", "Une petite action suivante")])) ,
                "es" => ("Práctica breve", "PsychologyApp", "Qué es", "Cuándo puede ayudar", "Cómo probarla", "Ejemplo",
                    new("Planifica una consulta de noticias", "Consulta lo importante sin actualizar sin parar", "Momento difícil",
                        "Un plan breve puede ayudarte a obtener la información necesaria sin abrir la sección cada vez que llega una notificación. No prohíbe leer noticias.",
                        "Cuando quieres volver a consultar aunque tu pregunta concreta ya tenga respuesta.",
                        "Formula una pregunta, elige una fuente fiable y un momento adecuado. Conserva las alertas importantes para la seguridad, la familia y el trabajo. Después, cierra la sección o decide cuándo volver.",
                        "Consultar el horario de un tren en la web de la compañía, mantener las alertas esenciales y volver a tus planes.", "TipsAndUpdates",
                        ["1. Pregúntate qué necesitas saber. Si hay una urgencia de seguridad, consulta la información ahora.",
                         "2. Elige una fuente fiable y un momento adecuado. Mantén las alertas necesarias para la seguridad, la familia o el trabajo.",
                         "3. Cuando tengas la respuesta, decide cuándo volver a consultar y pasa a una tarea concreta."],
                        [("Mi pregunta", "¿Qué necesito saber exactamente?"),
                         ("Fuente y momento", "Una fuente fiable y un momento adecuado"),
                         ("Después", "Una pequeña acción siguiente")])) ,
                "pt" => ("Prática breve", "PsychologyApp", "O que é", "Quando pode ajudar", "Como experimentar", "Exemplo",
                    new("Planejar uma consulta de notícias", "Conferir o que importa sem atualizar sem parar", "Momento difícil",
                        "Um plano curto pode ajudar você a obter a informação necessária sem abrir o feed a cada aviso. Ele não proíbe a leitura de notícias.",
                        "Quando você quer conferir de novo mesmo que sua pergunta específica já tenha resposta.",
                        "Formule uma pergunta, escolha uma fonte confiável e um horário adequado. Mantenha os avisos importantes para segurança, família e trabalho. Depois, feche o feed ou escolha quando consultar novamente.",
                        "Consultar o horário do trem no site da empresa, manter avisos essenciais e voltar aos seus planos.", "TipsAndUpdates",
                        ["1. Pergunte a si mesmo o que precisa saber. Se houver urgência de segurança, confira a informação agora.",
                         "2. Escolha uma fonte confiável e um horário adequado. Mantenha avisos importantes para segurança, trabalho ou família.",
                         "3. Quando encontrar a resposta, decida quando consultar de novo e passe a uma tarefa concreta."],
                        [("Minha pergunta", "O que preciso saber exatamente?"),
                         ("Fonte e horário", "Uma fonte confiável e um momento adequado"),
                         ("Depois", "Uma pequena próxima ação")])) ,
                _ => ("短暂练习", "PsychologyApp", "这是什么", "什么时候可能有帮助", "如何尝试", "示例",
                    new("制定新闻查看计划", "查看重要信息，避免不停刷新", "困难时刻",
                        "简短计划可以帮助你获取需要的信息，而不是把每条通知都当作打开新闻的理由。这不是禁止看新闻。",
                        "当具体问题已经有答案，你仍想再次查看时。",
                        "提出一个具体问题，选择可靠来源和合适时间。保留与安全、工作和家人有关的重要提醒。查看后关闭新闻，或决定下次查看的时间。",
                        "在铁路运营方的网站查询发车时间，保留重要提醒，然后回到自己的安排。", "TipsAndUpdates",
                        ["1. 问问自己具体想知道什么。如果安全问题很紧急，请立即查看信息。",
                         "2. 选择一个可靠来源和合适的时间。保留与安全、工作或家人有关的提醒。",
                         "3. 找到答案后，决定下次查看的时间，然后去做一件具体的事情。"],
                        [("我的问题", "我具体需要知道什么？"),
                         ("来源和时间", "可靠来源与合适的时机"),
                         ("查看之后", "一个小的下一步")]))
            };

        TechniqueCopy copy = localized.Copy;
        return new BuiltInTechniqueDefinition(
            localized.ModuleName, copy.Title, copy.Steps, copy.Summary, TechniqueUiKind.Entry,
            localized.ModuleName, "17.11.2026", copy.Title, copy.Subtitle, copy.Theme, localized.Author,
            2, copy.Icon,
            [
                new TechniqueEntrySeed(copy.Fields[0].Title, copy.Fields[0].Hint),
                new TechniqueEntrySeed(copy.Fields[1].Title, copy.Fields[1].Hint),
                new TechniqueEntrySeed(copy.Fields[2].Title, copy.Fields[2].Hint)
            ],
            [
                new TheorySection(localized.WhatHeading, copy.Summary),
                new TheorySection(localized.WhenHeading, copy.When),
                new TheorySection(localized.HowHeading, copy.How),
                new TheorySection(localized.ExampleHeading, copy.Example)
            ]);
    }

    private static BuiltInTechniqueDefinition CreateHabitRestartPlan(string language)
    {
        if (language is not ("ru" or "en" or "de" or "fr" or "es" or "pt" or "zh"))
        {
            language = "en";
        }

        (string ModuleName, string Author, string WhatHeading, string WhenHeading, string HowHeading, string ExampleHeading, TechniqueCopy Copy) localized =
            language switch
            {
                "ru" => ("Короткая практика", "PsychologyApp", "Что это", "Когда помогает", "Как пройти", "Пример",
                    new("Возвращение после пропуска", "Продолжить без наказания и попыток наверстать", "Новая привычка",
                        "Короткий план помогает вернуться к полезному действию после перерыва без самокритики и двойной нагрузки.",
                        "Когда привычный сигнал уже прошёл или действие несколько раз не получилось выполнить.",
                        "Проверьте, подходит ли действие сейчас. Выберите следующий естественный сигнал и самую лёгкую версию шага. Не нужно делать вдвое больше за пропущенный раз; если препятствия повторяются, измените план или откажитесь от него.",
                        "Не удалось прогуляться утром — после обеда выйти на пять минут, а не пытаться пройти вдвое больше завтра.", "Replay",
                        ["1. Решите, всё ли ещё подходит действие. Его можно изменить или отложить, если обстоятельства поменялись.",
                         "2. Выберите ближайший подходящий момент как сигнал для возвращения. Не нужно ждать понедельника или начала месяца.",
                         "3. Начните с самой лёгкой версии действия. Не компенсируйте пропуски двойной нагрузкой.",
                         "4. Если препятствия повторяются, поменяйте сигнал, место или размер шага."],
                        [("Моя привычка", "Одно небольшое действие"),
                         ("Сигнал для возвращения", "После чего я попробую снова?"),
                         ("Самый лёгкий вариант", "Что можно сделать за пару минут?")])),
                "en" => ("Short practice", "PsychologyApp", "What it is", "When it may help", "How to try it", "Example",
                    new("A gentle restart", "Return without punishment or catching up", "A new habit",
                        "A short plan helps you return to a useful action after a break without self-criticism or doubling the effort.",
                        "When a familiar cue has passed or you have missed the action more than once.",
                        "Check whether the action still fits. Choose the next natural cue and the easiest version of the step. You do not need to do twice as much for a missed day; if barriers keep showing up, change or drop the plan.",
                        "If a morning walk did not happen, take a five-minute walk after lunch instead of trying to walk twice as far tomorrow.", "Replay",
                        ["1. Check whether the action still fits. You may change or pause it when circumstances change.",
                         "2. Choose the next suitable moment as your cue. You do not have to wait for Monday or a new month.",
                         "3. Start with the easiest version of the action. Do not double the effort to make up for a miss.",
                         "4. If the same barrier keeps appearing, change the cue, place, or size of the step."],
                        [("My habit", "One small action"),
                         ("A cue to return", "After what will I try again?"),
                         ("The easiest version", "What can I do in a couple of minutes?")])),
                "de" => ("Kurze Übung", "PsychologyApp", "Was es ist", "Wann es helfen kann", "So geht es", "Beispiel",
                    new("Sanft neu beginnen", "Ohne Strafe oder Nachholen weitermachen", "Eine neue Gewohnheit",
                        "Ein kurzer Plan hilft, nach einer Pause ohne Selbstkritik und doppelte Anstrengung zu einer hilfreichen Handlung zurückzukehren.",
                        "Wenn ein vertrauter Auslöser vorbei ist oder die Handlung mehrmals ausgefallen ist.",
                        "Prüfen Sie, ob die Handlung noch passt. Wählen Sie den nächsten natürlichen Auslöser und die einfachste Version des Schritts. Sie müssen einen ausgefallenen Tag nicht durch doppelte Anstrengung ausgleichen. Wenn Hindernisse bleiben, ändern oder beenden Sie den Plan.",
                        "Der Spaziergang am Morgen fiel aus? Gehen Sie nach dem Mittagessen fünf Minuten, statt morgen doppelt so weit zu gehen.", "Replay",
                        ["1. Prüfen Sie, ob die Handlung noch passt. Bei veränderten Umständen können Sie sie ändern oder pausieren.",
                         "2. Wählen Sie den nächsten passenden Moment als Auslöser. Sie müssen nicht bis Montag oder zum Monatsanfang warten.",
                         "3. Beginnen Sie mit der einfachsten Version. Gleichen Sie einen Ausfall nicht durch doppelte Anstrengung aus.",
                         "4. Wenn dasselbe Hindernis wiederkehrt, ändern Sie Auslöser, Ort oder Schrittgröße."],
                        [("Meine Gewohnheit", "Eine kleine Handlung"),
                         ("Auslöser für den Neustart", "Woran schließe ich wieder an?"),
                         ("Die einfachste Version", "Was schaffe ich in ein paar Minuten?")])),
                "fr" => ("Exercice bref", "PsychologyApp", "De quoi s’agit-il", "Quand cela peut aider", "Comment essayer", "Exemple",
                    new("Reprendre en douceur", "Continuer sans punition ni rattrapage", "Une nouvelle habitude",
                        "Un plan bref aide à reprendre une action utile après une pause, sans autocritique ni effort doublé.",
                        "Quand un repère familier est passé ou que l’action a été manquée plusieurs fois.",
                        "Vérifiez si l’action vous convient toujours. Choisissez le prochain repère naturel et la version la plus simple. Inutile de faire deux fois plus pour compenser ; si les obstacles se répètent, modifiez ou abandonnez le plan.",
                        "La marche du matin n’a pas eu lieu ? Faites cinq minutes après le déjeuner au lieu d’essayer de marcher deux fois plus demain.", "Replay",
                        ["1. Vérifiez si l’action vous convient toujours. Vous pouvez la modifier ou faire une pause si les circonstances changent.",
                         "2. Choisissez le prochain moment adapté comme repère. Pas besoin d’attendre lundi ou le mois prochain.",
                         "3. Commencez par la version la plus simple. Ne doublez pas l’effort pour compenser un oubli.",
                         "4. Si le même obstacle revient, changez de repère, de lieu ou de taille d’étape."],
                        [("Mon habitude", "Une petite action"),
                         ("Repère pour reprendre", "Après quoi vais-je réessayer ?"),
                         ("La version la plus simple", "Que puis-je faire en quelques minutes ?")])),
                "es" => ("Práctica breve", "PsychologyApp", "Qué es", "Cuándo puede ayudar", "Cómo probarla", "Ejemplo",
                    new("Volver con amabilidad", "Continuar sin castigos ni compensaciones", "Un hábito nuevo",
                        "Un plan breve ayuda a retomar una acción útil después de una pausa, sin autocriticarte ni duplicar el esfuerzo.",
                        "Cuando ya pasó una señal habitual o no pudiste hacer la acción varias veces.",
                        "Comprueba si la acción sigue encajando. Elige la próxima señal natural y la versión más fácil del paso. No hace falta hacer el doble para compensar; si los obstáculos se repiten, cambia o deja el plan.",
                        "Si no pudiste pasear por la mañana, camina cinco minutos después de comer en vez de intentar caminar el doble mañana.", "Replay",
                        ["1. Comprueba si la acción sigue encajando. Puedes cambiarla o pausarla si las circunstancias cambiaron.",
                         "2. Elige el próximo momento adecuado como señal. No tienes que esperar al lunes ni al mes siguiente.",
                         "3. Empieza por la versión más fácil. No dupliques el esfuerzo para compensar un día.",
                         "4. Si el mismo obstáculo vuelve, cambia la señal, el lugar o el tamaño del paso."],
                        [("Mi hábito", "Una acción pequeña"),
                         ("Señal para volver", "¿Después de qué lo intentaré otra vez?"),
                         ("La versión más fácil", "¿Qué puedo hacer en un par de minutos?")])),
                "pt" => ("Prática breve", "PsychologyApp", "O que é", "Quando pode ajudar", "Como experimentar", "Exemplo",
                    new("Retomar com gentileza", "Continuar sem punição nem compensação", "Um novo hábito",
                        "Um plano breve ajuda a voltar a uma ação útil depois de uma pausa, sem autocrítica ou esforço dobrado.",
                        "Quando um sinal habitual já passou ou você deixou de fazer a ação mais de uma vez.",
                        "Confira se a ação ainda faz sentido. Escolha o próximo sinal natural e a versão mais fácil do passo. Não é preciso fazer o dobro para compensar; se os obstáculos se repetirem, mude ou abandone o plano.",
                        "Se não deu para caminhar de manhã, caminhe cinco minutos depois do almoço em vez de tentar andar o dobro amanhã.", "Replay",
                        ["1. Veja se a ação ainda faz sentido. Você pode mudá-la ou pausar se as circunstâncias mudarem.",
                         "2. Escolha o próximo momento adequado como sinal. Não precisa esperar até segunda-feira ou o próximo mês.",
                         "3. Comece pela versão mais fácil. Não dobre o esforço para compensar uma pausa.",
                         "4. Se o mesmo obstáculo voltar, mude o sinal, o lugar ou o tamanho do passo."],
                        [("Meu hábito", "Uma ação pequena"),
                         ("Sinal para voltar", "Depois de quê vou tentar novamente?"),
                         ("A versão mais fácil", "O que posso fazer em alguns minutos?")])),
                _ => ("短暂练习", "PsychologyApp", "这是什么", "什么时候可能有帮助", "如何尝试", "示例",
                    new("温和地重新开始", "不惩罚自己，也不试图补回", "新习惯",
                        "简短计划可以帮助你在暂停后重新开始有益的行动，不必自责或加倍努力。",
                        "当熟悉的提示信号已经过去，或行动几次没有完成时。",
                        "先看看这个行动是否仍适合你。选择下一个自然出现的提示信号和最简单的行动版本。不必加倍补做；如果障碍反复出现，可以调整或放弃计划。",
                        "早上没能散步，就在午饭后走五分钟，不必明天走双倍的路。", "Replay",
                        ["1. 看看这个行动是否仍适合现在的情况。情况改变时可以调整或暂停。",
                         "2. 选择下一个合适时刻作为提示信号，不必等到周一或下个月。",
                         "3. 从最简单的版本开始，不要为了补偿而加倍努力。",
                         "4. 如果同一个障碍反复出现，调整信号、地点或行动规模。"],
                        [("我的习惯", "一个小行动"),
                         ("重新开始的信号", "在什么事情之后再试一次？"),
                         ("最简单的版本", "几分钟内可以做什么？")]))
            };

        TechniqueCopy copy = localized.Copy;
        return new BuiltInTechniqueDefinition(
            localized.ModuleName, copy.Title, copy.Steps, copy.Summary, TechniqueUiKind.Entry,
            localized.ModuleName, "18.11.2026", copy.Title, copy.Subtitle, copy.Theme, localized.Author,
            2, copy.Icon,
            [
                new TechniqueEntrySeed(copy.Fields[0].Title, copy.Fields[0].Hint),
                new TechniqueEntrySeed(copy.Fields[1].Title, copy.Fields[1].Hint),
                new TechniqueEntrySeed(copy.Fields[2].Title, copy.Fields[2].Hint)
            ],
            [
                new TheorySection(localized.WhatHeading, copy.Summary),
                new TheorySection(localized.WhenHeading, copy.When),
                new TheorySection(localized.HowHeading, copy.How),
                new TheorySection(localized.ExampleHeading, copy.Example)
            ]);
    }

    private static BuiltInTechniqueDefinition CreateFeedbackReview(string language)
    {
        if (language is not ("ru" or "en" or "de" or "fr" or "es" or "pt" or "zh"))
        {
            language = "en";
        }

        (string ModuleName, string Author, string WhatHeading, string WhenHeading, string HowHeading, string ExampleHeading, TechniqueCopy Copy) localized =
            language switch
            {
                "ru" => ("Короткая практика", "PsychologyApp", "Что это", "Когда помогает", "Как пройти", "Пример",
                    new("Разобрать обратную связь", "Отделить конкретику от ярлыков и выбрать ответ", "Сложный момент",
                        "Короткий план помогает разобрать обратную связь: что именно сказали, что можно уточнить и какой следующий шаг выбрать. Она не определяет вашу ценность и не обязывает соглашаться с несправедливостью.",
                        "Когда после отзыва трудно понять, что делать дальше или хочется сразу защищаться.",
                        "Если можете, сначала сделайте паузу. Отделите конкретное действие или просьбу от оценки личности. Отметьте, что понятно, а что стоит уточнить. Выберите один полезный шаг, вопрос или границу. Можно ответить позже. При угрозах или унижении важнее поддержка и безопасность.",
                        "Коллега говорит: «Ты всё задерживаешь». Уточните: «Какой именно этап отстаёт и к какой дате нужен результат?»", "Forum",
                        ["1. Сделайте паузу, если это безопасно; не обязательно отвечать сразу.",
                         "2. Запишите конкретное действие или просьбу отдельно от ярлыка.",
                         "3. Уточните один неясный пример, срок или критерий.",
                         "4. Выберите полезный шаг, вопрос или границу. При угрозах ищите поддержку."],
                        [("Что именно мне сказали?", "Коротко, без оценки себя."),
                         ("Что конкретно и что нужно уточнить?", "Пример, срок, критерий или контекст."),
                         ("Мой следующий шаг", "Одно действие, вопрос или граница.")])),
                "en" => ("Short practice", "PsychologyApp", "What it is", "When it may help", "How to try it", "Example",
                    new("Sort through feedback", "Separate specifics from labels and choose a response", "Hard moment",
                        "A short plan helps you review feedback: what was said, what needs clarification, and what next step fits. It does not define your worth or require you to accept unfair treatment.",
                        "When feedback leaves you unsure what to do next or ready to defend yourself right away.",
                        "If it is safe, pause first. Separate a specific action or request from a judgment about you. Note what is clear and what needs clarification. Choose one useful step, question, or boundary. You can reply later. With threats or humiliation, prioritize safety and support.",
                        "A colleague says, “You hold everything up.” Ask, “Which step is delayed, and when is it needed?”", "Forum",
                        ["1. Pause if it is safe; you do not have to reply immediately.",
                         "2. Write down the specific action or request separately from a label.",
                         "3. Clarify one example, deadline, or standard that is unclear.",
                         "4. Choose a useful step, question, or boundary. Seek support if there are threats."],
                        [("What exactly was said?", "Briefly, without judging yourself."),
                         ("What is specific, and what needs clarifying?", "An example, deadline, standard, or context."),
                         ("My next step", "One action, question, or boundary.")])),
                "de" => ("Kurze Übung", "PsychologyApp", "Was es ist", "Wann es helfen kann", "So geht es", "Beispiel",
                    new("Rückmeldung sortieren", "Konkretes von Etiketten trennen und eine Antwort wählen", "Schwieriger Moment",
                        "Ein kurzer Plan hilft, Rückmeldung zu prüfen: Was wurde gesagt, was sollte geklärt werden und welcher nächste Schritt passt? Sie bestimmt nicht Ihren Wert und verpflichtet Sie nicht, Unfaires anzunehmen.",
                        "Wenn Sie nach einer Rückmeldung nicht wissen, was Sie tun sollen, oder sich sofort verteidigen möchten.",
                        "Machen Sie, wenn es sicher ist, zuerst eine Pause. Trennen Sie eine konkrete Handlung oder Bitte von einem Urteil über Ihre Person. Notieren Sie, was klar ist und was geklärt werden sollte. Wählen Sie einen hilfreichen Schritt, eine Frage oder eine Grenze. Sie können später antworten. Bei Drohungen oder Demütigung sind Sicherheit und Unterstützung wichtiger.",
                        "Ein Kollege sagt: „Sie halten alles auf.“ Fragen Sie: „Welcher Schritt verzögert sich und bis wann wird er gebraucht?“", "Forum",
                        ["1. Machen Sie eine Pause, wenn es sicher ist; Sie müssen nicht sofort antworten.",
                         "2. Notieren Sie die konkrete Handlung oder Bitte getrennt vom Etikett.",
                         "3. Fragen Sie nach einem unklaren Beispiel, einer Frist oder einem Maßstab.",
                         "4. Wählen Sie einen hilfreichen Schritt, eine Frage oder eine Grenze. Suchen Sie bei Drohungen Unterstützung."],
                        [("Was wurde genau gesagt?", "Kurz und ohne Selbsturteil."),
                         ("Was ist konkret, was muss geklärt werden?", "Beispiel, Frist, Maßstab oder Kontext."),
                         ("Mein nächster Schritt", "Eine Handlung, Frage oder Grenze.")])),
                "fr" => ("Exercice bref", "PsychologyApp", "De quoi s’agit-il", "Quand cela peut aider", "Comment essayer", "Exemple",
                    new("Trier un retour", "Distinguer les faits des étiquettes et choisir une réponse", "Moment difficile",
                        "Ce plan bref aide à examiner un retour : ce qui a été dit, ce qui mérite d’être clarifié et la suite qui vous convient. Il ne définit pas votre valeur et ne vous oblige pas à accepter l’injustice.",
                        "Quand un retour vous laisse sans savoir quoi faire ou vous donne envie de vous défendre immédiatement.",
                        "Si vous êtes en sécurité, faites d’abord une pause. Distinguez une action ou une demande précise d’un jugement sur vous. Notez ce qui est clair et ce qui doit être précisé. Choisissez une étape utile, une question ou une limite. Vous pouvez répondre plus tard. En cas de menaces ou d’humiliation, la sécurité et le soutien priment.",
                        "Un collègue dit : « Vous retardez tout. » Demandez : « Quelle étape est en retard et pour quand en avez-vous besoin ? »", "Forum",
                        ["1. Faites une pause si cela ne présente pas de risque ; vous n’avez pas à répondre tout de suite.",
                         "2. Notez l’action ou la demande précise séparément de l’étiquette.",
                         "3. Clarifiez un exemple, un délai ou un critère qui reste flou.",
                         "4. Choisissez une étape utile, une question ou une limite. Cherchez du soutien en cas de menace."],
                        [("Qu’a-t-on dit exactement ?", "Brièvement, sans vous juger."),
                         ("Qu’est-ce qui est précis et que faut-il clarifier ?", "Un exemple, délai, critère ou contexte."),
                         ("Ma prochaine étape", "Une action, une question ou une limite.")])),
                "es" => ("Práctica breve", "PsychologyApp", "Qué es", "Cuándo puede ayudar", "Cómo probarla", "Ejemplo",
                    new("Ordenar los comentarios", "Separar los detalles de las etiquetas y elegir una respuesta", "Momento difícil",
                        "Este plan breve ayuda a revisar un comentario: qué se dijo, qué conviene aclarar y qué paso elegir. No define tu valor ni te obliga a aceptar un trato injusto.",
                        "Cuando un comentario te deja sin saber qué hacer o con ganas de defenderte enseguida.",
                        "Si es seguro, haz una pausa primero. Separa una acción o petición concreta de un juicio sobre ti. Anota qué está claro y qué conviene aclarar. Elige un paso útil, una pregunta o un límite. Puedes responder más tarde. Ante amenazas o humillación, prioriza la seguridad y el apoyo.",
                        "Un compañero dice: «Retrasas todo». Pregunta: «¿Qué parte se ha retrasado y para cuándo hace falta?»", "Forum",
                        ["1. Haz una pausa si es seguro; no tienes que responder de inmediato.",
                         "2. Anota la acción o petición concreta aparte de la etiqueta.",
                         "3. Aclara un ejemplo, plazo o criterio que no esté claro.",
                         "4. Elige un paso útil, una pregunta o un límite. Busca apoyo si hay amenazas."],
                        [("¿Qué se dijo exactamente?", "Breve, sin juzgarte."),
                         ("¿Qué es concreto y qué debo aclarar?", "Un ejemplo, plazo, criterio o contexto."),
                         ("Mi siguiente paso", "Una acción, pregunta o límite.")])),
                "pt" => ("Prática breve", "PsychologyApp", "O que é", "Quando pode ajudar", "Como experimentar", "Exemplo",
                    new("Organizar o feedback", "Separar detalhes de rótulos e escolher uma resposta", "Momento difícil",
                        "Este plano breve ajuda a analisar um feedback: o que foi dito, o que precisa ser esclarecido e qual próximo passo faz sentido. Ele não define seu valor nem obriga você a aceitar algo injusto.",
                        "Quando um feedback deixa você sem saber o que fazer ou com vontade de se defender imediatamente.",
                        "Se for seguro, faça uma pausa primeiro. Separe uma ação ou pedido específico de um julgamento sobre você. Anote o que está claro e o que precisa ser esclarecido. Escolha um passo útil, uma pergunta ou um limite. Você pode responder depois. Diante de ameaças ou humilhação, priorize segurança e apoio.",
                        "Um colega diz: «Você atrasa tudo». Pergunte: «Qual etapa está atrasada e para quando ela é necessária?»", "Forum",
                        ["1. Faça uma pausa se for seguro; você não precisa responder na hora.",
                         "2. Anote a ação ou o pedido específico separadamente do rótulo.",
                         "3. Esclareça um exemplo, prazo ou critério que não esteja claro.",
                         "4. Escolha um passo útil, uma pergunta ou um limite. Procure apoio se houver ameaças."],
                        [("O que foi dito exatamente?", "Brevemente, sem se julgar."),
                         ("O que é específico e o que preciso esclarecer?", "Um exemplo, prazo, critério ou contexto."),
                         ("Meu próximo passo", "Uma ação, pergunta ou limite.")])),
                _ => ("简短练习", "PsychologyApp", "这是什么", "什么时候可能有帮助", "如何尝试", "示例",
                    new("梳理反馈", "把具体信息与标签分开，再选择回应", "困难时刻",
                        "这个简短计划帮助你梳理反馈：对方说了什么、哪些需要澄清、下一步怎么做。反馈不能定义你的价值，也不代表你必须接受不公平的对待。",
                        "收到反馈后不知道该做什么，或很想马上为自己辩护时。",
                        "如果安全，先暂停一下。把具体行动或请求与对你的评价分开。记下哪些内容清楚，哪些还需要澄清。选择一个有用的行动、问题或界限。你可以晚些再回应。遇到威胁或羞辱时，优先考虑安全并寻求支持。",
                        "同事说：“你总在拖进度。”可以问：“具体是哪一步延迟了？什么时候需要完成？”", "Forum",
                        ["1. 如果安全，先暂停；你不必立刻回应。",
                         "2. 把具体行动或请求与标签分开记录。",
                         "3. 询问一个不清楚的例子、期限或标准。",
                         "4. 选择一个有用的行动、问题或界限。遇到威胁时寻求支持。"],
                        [("对方具体说了什么？", "简短记录，不评价自己。"),
                         ("哪些内容具体，哪些需要澄清？", "例子、期限、标准或情境。"),
                         ("我的下一步", "一个行动、问题或界限。")]))
            };

        TechniqueCopy copy = localized.Copy;
        return new BuiltInTechniqueDefinition(
            localized.ModuleName, copy.Title, copy.Steps, copy.Summary, TechniqueUiKind.Entry,
            localized.ModuleName, "18.11.2026", copy.Title, copy.Subtitle, copy.Theme, localized.Author,
            2, copy.Icon,
            [
                new TechniqueEntrySeed(copy.Fields[0].Title, copy.Fields[0].Hint),
                new TechniqueEntrySeed(copy.Fields[1].Title, copy.Fields[1].Hint),
                new TechniqueEntrySeed(copy.Fields[2].Title, copy.Fields[2].Hint)
            ],
            [
                new TheorySection(localized.WhatHeading, copy.Summary),
                new TheorySection(localized.WhenHeading, copy.When),
                new TheorySection(localized.HowHeading, copy.How),
                new TheorySection(localized.ExampleHeading, copy.Example)
            ]);
    }

    private static BuiltInTechniqueDefinition CreateConnectionStepPlan(string language)
    {
        if (language is not ("ru" or "en" or "de" or "fr" or "es" or "pt" or "zh"))
        {
            language = "en";
        }

        (string ModuleName, string Author, string WhatHeading, string WhenHeading, string HowHeading, string ExampleHeading, TechniqueCopy Copy) localized =
            language switch
            {
                "ru" => ("Короткая практика", "PsychologyApp", "Что это", "Когда помогает", "Как пройти", "Пример",
                    new("План небольшого контакта", "Выбрать безопасный формат общения без давления", "Отношения",
                        "Короткий план помогает выбрать посильный и безопасный контакт: разговор, общее дело, тихое присутствие или практическую помощь. Он не требует немедленно кому-то писать и не обещает, что одиночество исчезнет.",
                        "Когда хочется больше связи, но непонятно, с чего начать, или на общение мало сил.",
                        "Сначала решите, что вам нужно сейчас. Выберите безопасного человека, группу или формат; не связывайтесь с тем, рядом с кем небезопасно. Предложите короткий конкретный контакт и оставьте право отказаться. Если сил нет или ответа не будет, можно сделать паузу, выбрать другой формат или обратиться к другому человеку.",
                        "«Хочешь прогуляться 15 минут в субботу? Если не получится — всё в порядке».", "Group",
                        ["1. Выберите, чего хочется: поговорить, побыть рядом, заняться общим делом или попросить о небольшой помощи.",
                         "2. Подумайте, с кем и в каком формате вам достаточно безопасно.",
                         "3. Сформулируйте короткое приглашение, оставив другому право выбрать или отказаться.",
                         "4. Подготовьте запасной вариант на случай отказа, тишины или нехватки сил."],
                        [("Какого контакта мне хочется?", "Разговор, совместное дело, присутствие или помощь."),
                         ("Кто или какой формат кажется безопасным?", "Можно выбрать группу, онлайн или пока не решать."),
                         ("Мой маленький шаг и запасной план", "Короткое приглашение; что я сделаю, если план не сложится?")])),
                "en" => ("Short practice", "PsychologyApp", "What it is", "When it may help", "How to try it", "Example",
                    new("Plan a small connection", "Choose a safe way to connect without pressure", "Relationships",
                        "This short plan helps you choose a manageable, safe kind of connection: conversation, a shared activity, quiet company, or practical help. It does not require messaging anyone right now or promise that loneliness will disappear.",
                        "When you want more connection but are unsure how to start, or have little energy for socializing.",
                        "First decide what would help today. Choose a safe person, group, or format; do not contact someone you feel unsafe around. Suggest a brief, specific activity and leave room for a no. If energy is low or there is no reply, you can pause, choose another format, or ask someone else.",
                        "“Would you like to take a 15-minute walk on Saturday? No worries if not.”", "Group",
                        ["1. Choose what you want: a conversation, company, a shared activity, or a small practical help.",
                         "2. Consider who and which format feel safe enough.",
                         "3. Write a brief invitation that leaves the other person free to choose or decline.",
                         "4. Make a backup plan for a no, no reply, or low energy."],
                        [("What kind of connection do I want?", "Conversation, shared activity, company, or help."),
                         ("Who or what format feels safe?", "A group or online option is fine; you can wait to decide."),
                         ("My small step and backup plan", "A brief invitation; what if it does not work out?")])),
                "de" => ("Kurze Übung", "PsychologyApp", "Was es ist", "Wann es helfen kann", "So geht es", "Beispiel",
                    new("Einen kleinen Kontakt planen", "Sicher und ohne Druck Verbindung aufnehmen", "Beziehungen",
                        "Dieser kurze Plan hilft, eine passende und sichere Verbindung zu wählen: ein Gespräch, eine gemeinsame Aktivität, ruhige Gesellschaft oder praktische Hilfe. Sie müssen niemandem sofort schreiben; der Plan verspricht nicht, dass Einsamkeit verschwindet.",
                        "Wenn Sie sich mehr Verbindung wünschen, aber nicht wissen, wie Sie anfangen sollen, oder wenig Kraft für Kontakte haben.",
                        "Überlegen Sie zuerst, was heute guttun könnte. Wählen Sie eine sichere Person, Gruppe oder Form; kontaktieren Sie niemanden, bei dem Sie sich unsicher fühlen. Schlagen Sie etwas Kurzes und Konkretes vor und lassen Sie ein Nein zu. Bei wenig Kraft oder ohne Antwort können Sie pausieren, ein anderes Format wählen oder jemand anderen fragen.",
                        "„Möchtest du Samstag 15 Minuten spazieren gehen? Wenn nicht, ist das auch in Ordnung.“", "Group",
                        ["1. Wählen Sie, was Sie möchten: ein Gespräch, Gesellschaft, eine gemeinsame Aktivität oder kleine praktische Hilfe.",
                         "2. Überlegen Sie, welche Person und welches Format sicher genug wirken.",
                         "3. Formulieren Sie eine kurze Einladung, bei der die andere Person frei wählen oder ablehnen kann.",
                         "4. Planen Sie eine Alternative bei Absage, ausbleibender Antwort oder wenig Kraft."],
                        [("Welche Verbindung wünsche ich mir?", "Gespräch, gemeinsame Aktivität, Gesellschaft oder Hilfe."),
                         ("Wer oder welches Format fühlt sich sicher an?", "Auch eine Gruppe oder online ist möglich; Sie können abwarten."),
                         ("Mein kleiner Schritt und Plan B", "Eine kurze Einladung; was mache ich, wenn es nicht klappt?")])),
                "es" => ("Práctica breve", "PsychologyApp", "Qué es", "Cuándo puede ayudar", "Cómo probarla", "Ejemplo",
                    new("Planificar un contacto pequeño", "Elegir una forma segura de conectar sin presión", "Relaciones",
                        "Este plan breve ayuda a elegir un contacto asumible y seguro: conversar, compartir una actividad, estar en compañía tranquila o recibir ayuda práctica. No exige escribir a alguien ahora ni promete que desaparezca la soledad.",
                        "Cuando quieres más conexión pero no sabes cómo empezar, o tienes poca energía para socializar.",
                        "Primero decide qué te vendría bien hoy. Elige una persona, grupo o formato seguro; no contactes con alguien con quien no te sientes a salvo. Propón algo breve y concreto, dejando espacio para un no. Si tienes poca energía o no hay respuesta, puedes hacer una pausa, elegir otro formato o hablar con otra persona.",
                        "«¿Te apetece dar un paseo de 15 minutos el sábado? Si no puedes, no pasa nada».", "Group",
                        ["1. Elige qué te apetece: conversar, tener compañía, compartir una actividad o pedir ayuda práctica.",
                         "2. Piensa con quién y en qué formato te sientes suficientemente seguro.",
                         "3. Redacta una invitación breve que deje libertad para aceptar o rechazar.",
                         "4. Prepara otra opción si te dicen que no, no responden o te falta energía."],
                        [("¿Qué tipo de contacto quiero?", "Conversar, hacer algo juntos, compañía o ayuda."),
                         ("¿Quién o qué formato me parece seguro?", "Puede ser un grupo o una opción en línea; también puedes esperar."),
                         ("Mi paso pequeño y plan alternativo", "Una invitación breve; ¿qué haré si no sale?")])),
                "fr" => ("Exercice bref", "PsychologyApp", "De quoi s’agit-il", "Quand cela peut aider", "Comment essayer", "Exemple",
                    new("Préparer un petit contact", "Choisir un lien sûr et sans pression", "Relations",
                        "Ce plan bref aide à choisir un contact accessible et sûr : parler, partager une activité, profiter d’une présence calme ou recevoir une aide pratique. Il n’oblige pas à écrire tout de suite et ne promet pas de faire disparaître la solitude.",
                        "Quand vous souhaitez davantage de lien sans savoir par où commencer, ou avec peu d’énergie pour voir du monde.",
                        "Commencez par repérer ce qui vous ferait du bien aujourd’hui. Choisissez une personne, un groupe ou un format sûr ; ne contactez pas quelqu’un auprès de qui vous ne vous sentez pas en sécurité. Proposez une activité courte et précise en laissant la possibilité de refuser. Si vous manquez d’énergie ou n’obtenez pas de réponse, vous pouvez faire une pause, changer de format ou contacter quelqu’un d’autre.",
                        "« Ça te dirait une petite marche de 15 minutes samedi ? Aucun souci si tu ne peux pas. »", "Group",
                        ["1. Choisissez ce qui vous ferait du bien : parler, être accompagné, partager une activité ou demander une petite aide pratique.",
                         "2. Pensez à une personne et à un format suffisamment sûrs.",
                         "3. Rédigez une invitation brève qui laisse à l’autre le choix d’accepter ou de refuser.",
                         "4. Prévoyez une autre option en cas de refus, d’absence de réponse ou de manque d’énergie."],
                        [("Quel lien est-ce que je souhaite ?", "Parler, partager une activité, être accompagné ou recevoir de l’aide."),
                         ("Quelle personne ou quel format me semble sûr ?", "Un groupe ou le format en ligne convient aussi ; vous pouvez attendre."),
                         ("Mon petit pas et mon plan B", "Une invitation brève ; que faire si cela ne marche pas ?")])),
                "pt" => ("Prática breve", "PsychologyApp", "O que é", "Quando pode ajudar", "Como experimentar", "Exemplo",
                    new("Planejar um contato pequeno", "Escolher uma forma segura de se conectar sem pressão", "Relacionamentos",
                        "Este plano breve ajuda a escolher um contato possível e seguro: conversar, fazer algo junto, ter companhia tranquila ou receber ajuda prática. Não exige que você escreva para alguém agora nem promete que a solidão vai desaparecer.",
                        "Quando você quer mais conexão, mas não sabe por onde começar, ou tem pouca energia para socializar.",
                        "Primeiro, pense no que seria bom hoje. Escolha uma pessoa, grupo ou formato seguro; não procure alguém perto de quem não se sente seguro. Sugira algo breve e específico e deixe espaço para a pessoa recusar. Se estiver sem energia ou não houver resposta, você pode pausar, escolher outro formato ou falar com outra pessoa.",
                        "«Quer caminhar por 15 minutos no sábado? Tudo bem se não puder»", "Group",
                        ["1. Escolha o que você quer: conversar, ter companhia, fazer algo junto ou pedir uma pequena ajuda prática.",
                         "2. Pense em quem e em qual formato parecem seguros o bastante.",
                         "3. Escreva um convite breve que deixe a outra pessoa livre para aceitar ou recusar.",
                         "4. Tenha uma alternativa caso a pessoa recuse, não responda ou você fique sem energia."],
                        [("Que tipo de contato eu quero?", "Conversa, atividade em comum, companhia ou ajuda."),
                         ("Quem ou qual formato parece seguro?", "Pode ser um grupo ou algo on-line; você também pode esperar."),
                         ("Meu passo pequeno e plano B", "Um convite breve; o que faço se não der certo?")])),
                _ => ("简短练习", "PsychologyApp", "这是什么", "什么时候可能有帮助", "如何尝试", "示例",
                    new("计划一次轻松联系", "选择安全、没有压力的联系方式", "人际关系",
                        "这个简短计划帮助你选择一种可承受且安全的联系：聊天、共同活动、安静陪伴或实际帮助。不要求你立刻给谁发消息，也不承诺孤独会消失。",
                        "想增加联系却不知道如何开始，或没有太多精力社交时。",
                        "先想想今天什么会对你有帮助。选择安全的人、群体或方式；不要联系让你觉得不安全的人。提出一个简短具体的活动，并给对方拒绝的空间。如果精力不足或没有收到回复，可以暂停、换一种方式，或联系其他人。",
                        "“周六要不要散步15分钟？不方便也没关系。”", "Group",
                        ["1. 选择你想要的联系：聊天、有人陪伴、一起做事或寻求一点实际帮助。",
                         "2. 想想哪个人和方式让你觉得足够安全。",
                         "3. 写一句简短邀请，让对方可以自由选择或拒绝。",
                         "4. 如果对方拒绝、没有回复或你精力不足，准备一个替代方案。"],
                        [("我想要什么样的联系？", "聊天、共同活动、陪伴或帮助。"),
                         ("谁或哪种方式让我觉得安全？", "群体或线上方式也可以；你也可以先等等。"),
                         ("我的小步骤和备用计划", "一个简短邀请；如果没成，我会怎么做？")]))
            };

        TechniqueCopy copy = localized.Copy;
        return new BuiltInTechniqueDefinition(
            localized.ModuleName, copy.Title, copy.Steps, copy.Summary, TechniqueUiKind.Entry,
            localized.ModuleName, "18.11.2026", copy.Title, copy.Subtitle, copy.Theme, localized.Author,
            2, copy.Icon,
            [
                new TechniqueEntrySeed(copy.Fields[0].Title, copy.Fields[0].Hint),
                new TechniqueEntrySeed(copy.Fields[1].Title, copy.Fields[1].Hint),
                new TechniqueEntrySeed(copy.Fields[2].Title, copy.Fields[2].Hint)
            ],
            [
                new TheorySection(localized.WhatHeading, copy.Summary),
                new TheorySection(localized.WhenHeading, copy.When),
                new TheorySection(localized.HowHeading, copy.How),
                new TheorySection(localized.ExampleHeading, copy.Example)
            ]);
    }

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
