using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Practice.Catalog;

/// <summary>Short localized adaptations of fact-checking and scheduled-worry skills.</summary>
internal static class TechniqueCatalogContentEvidenceInformed
{
    private sealed record PracticeCopy(
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
        EntryFieldRole FirstRole,
        EntryFieldRole SecondRole,
        string[]? SecondSuggestions,
        string[]? ThirdSuggestions);

    private sealed record LanguageCopy(
        string ModuleName,
        string Author,
        string WhatHeading,
        string WhenHeading,
        string HowHeading,
        string ExampleHeading,
        PracticeCopy CheckFacts,
        PracticeCopy WorryTime);

    private static readonly IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> Russian = Build(new(
        "Короткая практика", "Навык самопомощи", "Что это", "Когда применять", "Как пройти", "Пример",
        new(
            "Проверить факты", "Отделите событие от догадки", "Сверить вывод с фактами",
            "Навык DBT Check the Facts помогает проверить, соответствуют ли эмоция и её сила обстоятельствам. Цель — выбрать подходящее действие, а не доказать себе, что вы неправы.",
            "Когда тревога, злость или обида усиливаются из-за версии о ситуации, которую можно проверить.",
            "Назовите чувство, разделите наблюдаемое и предположения. Если факты указывают на опасность или нарушение границ, не обесценивайте реакцию — позаботьтесь о безопасности.",
            "Факт: собеседник не ответил два часа. Догадка: «он меня отверг». Можно уточнить, а не решать за него.", "FactCheck",
            ["1. Назовите ситуацию и чувство, которое хотите проверить.", "2. Разделите то, что можно было бы записать на камеру, и то, что вы додумываете.", "3. Спросите себя: какие факты поддерживают мой вывод, какие ему не соответствуют и чего я пока не знаю? Не заставляйте себя думать позитивно.", "4. Если есть опасность или нарушена граница — защитите себя. Если факты неясны — уточните один из них; если вывод не подтверждается — выберите действие по тому, что известно."],
            [("Ситуация", "Что произошло?"), ("Чувство", "Тревога, злость, обида…"), ("Факты и догадки", "Что знаю точно, а что предполагаю?")],
            EntryFieldRole.Problem, EntryFieldRole.Emotion, null, ["Наблюдаю: …", "Предполагаю: …", "Пока не знаю: …"]),
        new(
            "Время для тревоги", "Запишите мысль и назначьте время вернуться к ней", "Отложить разбор, не подавляя мысль",
            "Навык отложенного беспокойства помогает зафиксировать повторяющуюся мысль и выделить позже 10–15 минут на её разбор. Он не требует запрещать себе тревожиться.",
            "Когда беспокоит гипотетическое будущее и прямо сейчас нет срочного действия.",
            "Если есть практический шаг, выберите его или используйте разбор задачи. Если повлиять сейчас нельзя, назначьте точное время позже сегодня; не откладывайте безопасность, здоровье или реальные сроки.",
            "«А вдруг совещание пройдёт плохо?» — записать, назначить разбор после обеда и вернуться к текущему делу.", "Schedule",
            ["1. Запишите тревогу одной короткой фразой — не пытайтесь решить всё сразу.", "2. Есть ли безопасный практический шаг, который нужно сделать сейчас? Если да, запишите его; если вопрос срочный, займитесь им.", "3. Если прямо сейчас повлиять нельзя, назначьте сегодня отдельные 10–15 минут, когда вернётесь к этой мысли.", "4. Если тревога вернётся раньше, отметьте её и мягко вернитесь к текущему занятию. В назначенное время снова решите, есть ли действие или нужна поддержка."],
            [("Что меня тревожит?", "Коротко, одной фразой"), ("Можно ли действовать сейчас?", "Есть ли конкретный безопасный шаг?"), ("Когда вернусь к этому?", "Например: сегодня после обеда")],
            EntryFieldRole.Problem, EntryFieldRole.None, ["Да, есть конкретный шаг", "Нет, сейчас повлиять нельзя", "Не уверен(а), нужно уточнить"], ["Сегодня после обеда", "Сегодня вечером", "Выбрать точное время"])
    ));

    private static readonly IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> English = Build(new(
        "Quick practice", "Self-help skill", "What it is", "When to use it", "How to do it", "Example",
        new(
            "Check the Facts", "Separate what happened from what you inferred", "Compare the story with the facts",
            "The DBT Check the Facts skill asks whether an emotion and its intensity fit the circumstances. The aim is to choose a fitting response, not to prove yourself wrong.",
            "When anxiety, anger, or hurt grows around an interpretation you can check.",
            "Name the feeling and separate observations from assumptions. If the facts point to danger or a crossed boundary, do not dismiss your response; protect your safety.",
            "Fact: someone has not replied for two hours. Guess: “They reject me.” You can ask, rather than decide for them.", "FactCheck",
            ["1. Name the situation and the feeling you want to check.", "2. Separate what a camera could record from what you are adding to the story.", "3. Ask: what supports my interpretation, what does not, and what do I still not know? Do not force a positive thought.", "4. If there is danger or a crossed boundary, protect yourself. If facts are unclear, check one; if the interpretation is unsupported, choose an action based on what you know."],
            [("Situation", "What happened?"), ("Feeling", "Anxiety, anger, hurt…"), ("Facts and assumptions", "What do I know, and what am I guessing?")],
            EntryFieldRole.Problem, EntryFieldRole.Emotion, null, ["I observed: …", "I am guessing: …", "I do not know yet: …"]),
        new(
            "Schedule Worry Time", "Write it down and choose when to revisit it", "Set a time without suppressing the thought",
            "Scheduled worry means noting a recurring thought and setting aside 10–15 minutes later to return to it. It does not require banning the thought.",
            "When the worry is about a hypothetical future and no urgent action is needed now.",
            "If there is a practical step, choose it or use problem-solving. If you cannot influence this now, set a specific time later today. Do not postpone safety, health, or real deadlines.",
            "“What if the meeting goes badly?” — note it, set a time after lunch to revisit it, and return to the current task.", "Schedule",
            ["1. Write the worry in one short sentence; do not try to solve everything now.", "2. Is there a safe practical step you need to take now? If yes, note it; if the issue is urgent, act on it.", "3. If you cannot influence it now, set aside 10–15 minutes later today to revisit the thought.", "4. If it returns sooner, notice it and gently return to what you are doing. At the chosen time, decide whether action or support is needed."],
            [("What am I worrying about?", "One short sentence"), ("Can I act now?", "Is there a concrete, safe step?"), ("When will I revisit it?", "For example: after lunch today")],
            EntryFieldRole.Problem, EntryFieldRole.None, ["Yes, there is a practical step", "No, I cannot influence it now", "Not sure; I need to check"], ["After lunch today", "This evening", "Choose an exact time"])
    ));

    private static readonly IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> German = Build(new(
        "Kurzübung", "Selbsthilfe-Fertigkeit", "Was es ist", "Wann es hilft", "So geht es", "Beispiel",
        new(
            "Fakten prüfen", "Trennen Sie das Ereignis von Ihrer Deutung", "Deutung mit Fakten abgleichen",
            "Die DBT-Fertigkeit «Check the Facts» prüft, ob Gefühl und Stärke zu den Umständen passen. Ziel ist eine passende Reaktion, nicht sich selbst zu widerlegen.",
            "Wenn Angst, Ärger oder Kränkung durch eine überprüfbare Deutung zunimmt.",
            "Benennen Sie das Gefühl und trennen Sie Beobachtung von Vermutung. Weisen Fakten auf Gefahr oder eine verletzte Grenze hin, nehmen Sie das ernst und schützen Sie sich.",
            "Fakt: Jemand hat zwei Stunden nicht geantwortet. Vermutung: «Die Person lehnt mich ab.» Sie können nachfragen.", "FactCheck",
            ["1. Benennen Sie die Situation und das Gefühl, das Sie überprüfen möchten.", "2. Trennen Sie, was eine Kamera aufnehmen könnte, von Ihrer Deutung.", "3. Fragen Sie: Was stützt meine Deutung, was spricht dagegen und was weiß ich noch nicht? Erzwingen Sie keinen positiven Gedanken.", "4. Bei Gefahr oder verletzter Grenze schützen Sie sich. Sind Fakten unklar, prüfen Sie einen; wird die Deutung nicht gestützt, handeln Sie nach dem, was Sie wissen."],
            [("Situation", "Was ist passiert?"), ("Gefühl", "Angst, Ärger, Kränkung…"), ("Fakten und Vermutungen", "Was weiß ich, was vermute ich?")],
            EntryFieldRole.Problem, EntryFieldRole.Emotion, null, ["Ich beobachte: …", "Ich vermute: …", "Das weiß ich noch nicht: …"]),
        new(
            "Sorgenzeit einplanen", "Notieren Sie den Gedanken und legen Sie einen Zeitpunkt fest", "Einen Zeitpunkt setzen, ohne den Gedanken zu unterdrücken",
            "Aufgeschobenes Sorgen heißt, einen wiederkehrenden Gedanken zu notieren und später 10–15 Minuten dafür einzuplanen. Der Gedanke muss nicht verboten werden.",
            "Wenn es um eine hypothetische Zukunft geht und jetzt kein dringender Schritt nötig ist.",
            "Gibt es einen praktischen Schritt, wählen Sie ihn oder nutzen Sie Problemlösen. Können Sie jetzt nichts beeinflussen, legen Sie für später am Tag eine feste Zeit fest. Sicherheit, Gesundheit und echte Fristen nicht aufschieben.",
            "«Was, wenn das Treffen schlecht läuft?» notieren, nach dem Mittagessen erneut ansehen und zur aktuellen Aufgabe zurückkehren.", "Schedule",
            ["1. Notieren Sie die Sorge in einem kurzen Satz; versuchen Sie nicht, jetzt alles zu lösen.", "2. Gibt es jetzt einen sicheren praktischen Schritt? Wenn ja, notieren Sie ihn; bei Dringlichkeit handeln Sie.", "3. Können Sie jetzt nichts beeinflussen, reservieren Sie später heute 10–15 Minuten dafür.", "4. Kommt der Gedanke vorher wieder, nehmen Sie ihn wahr und kehren Sie behutsam zur Tätigkeit zurück. Entscheiden Sie zur festgelegten Zeit, ob Handlung oder Unterstützung nötig ist."],
            [("Was macht mir Sorgen?", "Ein kurzer Satz"), ("Kann ich jetzt handeln?", "Gibt es einen konkreten sicheren Schritt?"), ("Wann komme ich darauf zurück?", "Zum Beispiel heute nach dem Mittagessen")],
            EntryFieldRole.Problem, EntryFieldRole.None, ["Ja, es gibt einen praktischen Schritt", "Nein, ich kann es jetzt nicht beeinflussen", "Unsicher; ich muss es prüfen"], ["Heute nach dem Mittagessen", "Heute Abend", "Einen genauen Zeitpunkt wählen"])
    ));

    private static readonly IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> French = Build(new(
        "Pratique courte", "Compétence d’auto-aide", "De quoi s’agit-il ?", "Quand l’utiliser", "Comment faire", "Exemple",
        new(
            "Vérifier les faits", "Séparez l’événement de votre interprétation", "Comparer l’interprétation aux faits",
            "La compétence DBT « Check the Facts » aide à vérifier si l’émotion et son intensité correspondent aux circonstances. Le but est de choisir une réponse adaptée, pas de se donner tort.",
            "Quand l’anxiété, la colère ou la peine grandit autour d’une interprétation que vous pouvez vérifier.",
            "Nommez l’émotion et séparez les observations des suppositions. Si les faits indiquent un danger ou une limite franchie, ne minimisez pas votre réaction : protégez-vous.",
            "Fait : la personne n’a pas répondu depuis deux heures. Supposition : « elle me rejette ». Vous pouvez demander plutôt que conclure.", "FactCheck",
            ["1. Nommez la situation et l’émotion que vous souhaitez vérifier.", "2. Séparez ce qu’une caméra pourrait enregistrer de ce que vous ajoutez à l’histoire.", "3. Demandez-vous : qu’est-ce qui soutient mon interprétation, qu’est-ce qui ne la soutient pas et qu’est-ce que j’ignore encore ? Ne forcez pas une pensée positive.", "4. En cas de danger ou de limite franchie, protégez-vous. Si les faits sont flous, vérifiez-en un ; si l’interprétation n’est pas étayée, agissez selon ce que vous savez."],
            [("Situation", "Que s’est-il passé ?"), ("Émotion", "Anxiété, colère, peine…"), ("Faits et suppositions", "Que sais-je et qu’est-ce que j’imagine ?")],
            EntryFieldRole.Problem, EntryFieldRole.Emotion, null, ["J’observe : …", "Je suppose : …", "Je ne sais pas encore : …"]),
        new(
            "Planifier un temps pour les inquiétudes", "Notez la pensée et choisissez quand y revenir", "Fixer un moment sans supprimer la pensée",
            "Le report des inquiétudes consiste à noter une pensée récurrente et à réserver plus tard 10 à 15 minutes pour y revenir. Il ne s’agit pas de l’interdire.",
            "Quand l’inquiétude concerne un avenir hypothétique et qu’aucune action urgente n’est nécessaire maintenant.",
            "S’il existe une étape pratique, choisissez-la ou utilisez la résolution de problème. Sinon, fixez une heure précise plus tard aujourd’hui. Ne reportez ni la sécurité, ni la santé, ni une vraie échéance.",
            "« Et si la réunion se passait mal ? » — notez-le, prévoyez d’y revenir après le déjeuner et reprenez la tâche en cours.", "Schedule",
            ["1. Notez l’inquiétude en une phrase courte ; n’essayez pas de tout résoudre maintenant.", "2. Y a-t-il une étape pratique et sûre à faire maintenant ? Si oui, notez-la ; si c’est urgent, agissez.", "3. Si vous ne pouvez rien influencer maintenant, réservez 10 à 15 minutes plus tard aujourd’hui pour y revenir.", "4. Si la pensée revient avant, remarquez-la puis reprenez doucement votre activité. À l’heure prévue, décidez si une action ou du soutien est nécessaire."],
            [("Qu’est-ce qui m’inquiète ?", "Une phrase courte"), ("Puis-je agir maintenant ?", "Existe-t-il une étape concrète et sûre ?"), ("Quand y reviendrai-je ?", "Par exemple : après le déjeuner")],
            EntryFieldRole.Problem, EntryFieldRole.None, ["Oui, il y a une action pratique", "Non, je ne peux pas agir maintenant", "Je ne sais pas, je dois vérifier"], ["Après le déjeuner", "Ce soir", "Choisir une heure précise"])
    ));

    private static readonly IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> Spanish = Build(new(
        "Práctica breve", "Habilidad de autocuidado", "Qué es", "Cuándo usarla", "Cómo hacerla", "Ejemplo",
        new(
            "Comprobar los hechos", "Separa lo ocurrido de lo que interpretas", "Contrastar la interpretación con los hechos",
            "La habilidad DBT «Check the Facts» ayuda a comprobar si la emoción y su intensidad encajan con las circunstancias. El objetivo es elegir una respuesta adecuada, no demostrarte que estás equivocado.",
            "Cuando la ansiedad, el enfado o el dolor aumentan por una interpretación que puedes comprobar.",
            "Nombra la emoción y separa lo observable de las suposiciones. Si los hechos indican peligro o un límite cruzado, no minimices tu reacción: protégete.",
            "Hecho: alguien no ha contestado en dos horas. Suposición: «me rechaza». Puedes preguntar en lugar de decidir por esa persona.", "FactCheck",
            ["1. Nombra la situación y la emoción que quieres comprobar.", "2. Separa lo que una cámara podría grabar de lo que añades a la historia.", "3. Pregúntate: ¿qué apoya mi interpretación, qué no la apoya y qué no sé todavía? No te obligues a pensar en positivo.", "4. Si hay peligro o se cruzó un límite, protégete. Si los hechos no están claros, comprueba uno; si la interpretación no se sostiene, actúa según lo que sabes."],
            [("Situación", "¿Qué ocurrió?"), ("Emoción", "Ansiedad, enfado, dolor…"), ("Hechos y suposiciones", "¿Qué sé y qué estoy imaginando?")],
            EntryFieldRole.Problem, EntryFieldRole.Emotion, null, ["Observo: …", "Supongo: …", "Aún no sé: …"]),
        new(
            "Programar un tiempo para preocuparse", "Anota la idea y elige cuándo volver a ella", "Fijar un momento sin suprimir el pensamiento",
            "Aplazar la preocupación consiste en anotar un pensamiento recurrente y reservar más tarde 10–15 minutos para retomarlo. No significa prohibirse pensar en ello.",
            "Cuando la preocupación trata sobre un futuro hipotético y ahora no hace falta actuar con urgencia.",
            "Si hay un paso práctico, elígelo o usa la resolución de problemas. Si no puedes influir ahora, fija una hora concreta para más tarde. No aplaces la seguridad, la salud ni un plazo real.",
            "«¿Y si la reunión sale mal?» — anótalo, fija un momento después de comer para retomarlo y vuelve a la tarea actual.", "Schedule",
            ["1. Anota la preocupación en una frase corta; no intentes resolverlo todo ahora.", "2. ¿Hay un paso práctico y seguro que debas dar ahora? Si sí, anótalo; si es urgente, actúa.", "3. Si ahora no puedes influir, reserva 10–15 minutos más tarde hoy para volver al tema.", "4. Si el pensamiento vuelve antes, obsérvalo y regresa con calma a lo que estabas haciendo. A la hora elegida, decide si necesitas actuar o pedir apoyo."],
            [("¿Qué me preocupa?", "Una frase corta"), ("¿Puedo actuar ahora?", "¿Hay un paso concreto y seguro?"), ("¿Cuándo volveré a ello?", "Por ejemplo: después de comer")],
            EntryFieldRole.Problem, EntryFieldRole.None, ["Sí, hay un paso práctico", "No puedo influir ahora", "No estoy seguro; necesito comprobarlo"], ["Después de comer", "Esta tarde", "Elegir una hora concreta"])
    ));

    private static readonly IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> Portuguese = Build(new(
        "Prática breve", "Habilidade de autocuidado", "O que é", "Quando usar", "Como fazer", "Exemplo",
        new(
            "Conferir os fatos", "Separe o que aconteceu da sua interpretação", "Comparar a interpretação com os fatos",
            "A habilidade DBT «Check the Facts» ajuda a verificar se a emoção e sua intensidade combinam com as circunstâncias. O objetivo é escolher uma resposta adequada, não provar que você está errado.",
            "Quando a ansiedade, a raiva ou a mágoa aumentam por causa de uma interpretação que pode ser verificada.",
            "Nomeie o sentimento e separe observações de suposições. Se os fatos indicarem perigo ou um limite desrespeitado, não minimize sua reação: proteja-se.",
            "Fato: alguém não respondeu por duas horas. Suposição: «essa pessoa me rejeita». Você pode perguntar em vez de decidir por ela.", "FactCheck",
            ["1. Nomeie a situação e o sentimento que quer conferir.", "2. Separe o que uma câmera poderia registrar do que você acrescentou à história.", "3. Pergunte: o que apoia minha interpretação, o que não apoia e o que ainda não sei? Não force um pensamento positivo.", "4. Se houver perigo ou um limite desrespeitado, proteja-se. Se os fatos não estiverem claros, confira um deles; se a interpretação não se sustentar, aja com base no que sabe."],
            [("Situação", "O que aconteceu?"), ("Sentimento", "Ansiedade, raiva, mágoa…"), ("Fatos e suposições", "O que sei e o que estou imaginando?")],
            EntryFieldRole.Problem, EntryFieldRole.Emotion, null, ["Observo: …", "Estou supondo: …", "Ainda não sei: …"]),
        new(
            "Agendar um tempo para as preocupações", "Anote o pensamento e escolha quando voltar a ele", "Definir um horário sem suprimir o pensamento",
            "Adiar a preocupação consiste em anotar um pensamento recorrente e reservar mais tarde 10–15 minutos para retomá-lo. Não é preciso proibir o pensamento.",
            "Quando a preocupação é sobre um futuro hipotético e não há uma ação urgente agora.",
            "Se existe um passo prático, escolha-o ou use a resolução de problemas. Se não puder influenciar agora, marque um horário específico para mais tarde hoje. Não adie segurança, saúde ou prazos reais.",
            "«E se a reunião der errado?» — anote, marque um horário depois do almoço para retomar o assunto e volte à tarefa atual.", "Schedule",
            ["1. Anote a preocupação em uma frase curta; não tente resolver tudo agora.", "2. Existe um passo prático e seguro que você precisa dar agora? Se sim, anote-o; se for urgente, aja.", "3. Se não puder influenciar agora, reserve 10–15 minutos mais tarde hoje para voltar ao assunto.", "4. Se o pensamento voltar antes, perceba-o e retome com gentileza o que estava fazendo. No horário escolhido, decida se precisa agir ou pedir apoio."],
            [("O que está me preocupando?", "Uma frase curta"), ("Posso agir agora?", "Existe um passo concreto e seguro?"), ("Quando volto a isso?", "Por exemplo: depois do almoço")],
            EntryFieldRole.Problem, EntryFieldRole.None, ["Sim, há um passo prático", "Não posso influenciar agora", "Não sei; preciso conferir"], ["Depois do almoço", "Hoje à noite", "Escolher um horário exato"])
    ));

    private static readonly IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> Chinese = Build(new(
        "快速练习", "自助调节技能", "这是什么", "适用时机", "练习方法", "示例",
        new(
            "核对事实", "区分发生的事和自己的推测", "用事实检查自己的判断",
            "DBT 的“核对事实”技能帮助检查情绪及其强度是否符合实际情况。目标是选择合适的回应，而不是证明自己错了。",
            "当焦虑、愤怒或受伤感因一个可以核实的判断而加重时。",
            "说出感受，并把可观察到的情况与推测分开。如果事实显示有危险或界限被侵犯，不要否定自己的反应，先保护自己。",
            "事实：对方两个小时没有回复。推测：“对方拒绝了我。”你可以先询问，而不是替对方下结论。", "FactCheck",
            ["1. 说出发生了什么，以及你想核实的感受。", "2. 区分摄像机能记录到的内容和你对事情的补充解释。", "3. 问自己：哪些事实支持这个判断，哪些不支持，还有什么不知道？不要强迫自己往积极方向想。", "4. 如有危险或界限被侵犯，先保护自己。事实不清楚时先核实一项；如果判断缺少依据，就根据已知情况选择行动。"],
            [("发生了什么？", "具体情境"), ("感受", "焦虑、愤怒、受伤……"), ("事实和推测", "我确切知道什么？我在猜什么？")],
            EntryFieldRole.Problem, EntryFieldRole.Emotion, null, ["我观察到：……", "我在推测：……", "我还不知道：……"]),
        new(
            "安排担忧时间", "记下想法，并选好之后再处理的时间", "设定时间，不压制想法",
            "延后担忧是先记下反复出现的想法，再安排稍后 10–15 分钟重新处理它。这不是禁止自己去想。",
            "当担忧关于假设的未来，而且现在没有必须立刻采取的行动时。",
            "如果有实际可做的一步，就选择它或使用问题解决练习。如果现在无法影响，就安排今天稍后的具体时间。不要推迟安全、健康或真实期限相关的行动。",
            "“如果会议不顺利怎么办？”——记下来，安排午饭后再想，然后回到当前任务。", "Schedule",
            ["1. 用一句短话记下担忧，不要现在就试图解决所有事情。", "2. 现在有安全且实际的一步要做吗？如果有，记下来；如果紧急，就去处理。", "3. 如果现在无法影响，安排今天稍后 10–15 分钟回来看看。", "4. 如果想法提前回来，注意到它，再温和地回到眼前的事。到约定时间，再决定是否需要行动或寻求支持。"],
            [("我在担心什么？", "用一句短话写下"), ("现在可以行动吗？", "有没有具体且安全的一步？"), ("什么时候再处理？", "例如：今天午饭后")],
            EntryFieldRole.Problem, EntryFieldRole.None, ["有，可以采取实际行动", "现在无法影响", "不确定，需要核实"], ["今天午饭后", "今天晚上", "选择一个具体时间"])
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
            [TechniqueId.CheckTheFacts] = Create(language, language.CheckFacts),
            [TechniqueId.WorryTime] = Create(language, language.WorryTime)
        };

    private static BuiltInTechniqueDefinition Create(LanguageCopy language, PracticeCopy copy) => new(
        language.ModuleName,
        copy.Title,
        copy.Steps,
        copy.Summary,
        TechniqueUiKind.Entry,
        language.ModuleName,
        "2026-11-03",
        copy.Title,
        copy.Subtitle,
        copy.Theme,
        language.Author,
        1,
        copy.Icon,
        [
            new TechniqueEntrySeed(copy.Fields[0].Title, copy.Fields[0].Hint, Role: copy.FirstRole),
            new TechniqueEntrySeed(copy.Fields[1].Title, copy.Fields[1].Hint, Suggestions: copy.SecondSuggestions, Role: copy.SecondRole),
            new TechniqueEntrySeed(copy.Fields[2].Title, copy.Fields[2].Hint, Suggestions: copy.ThirdSuggestions)
        ],
        [
            new TheorySection(language.WhatHeading, copy.Summary),
            new TheorySection(language.WhenHeading, copy.When),
            new TheorySection(language.HowHeading, copy.How),
            new TheorySection(language.ExampleHeading, copy.Example)
        ]);
}
