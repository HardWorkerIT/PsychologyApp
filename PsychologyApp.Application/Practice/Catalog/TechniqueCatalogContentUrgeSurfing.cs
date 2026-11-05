using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Practice.Catalog;

/// <summary>A short, safety-bounded adaptation of mindful urge surfing; it does not promise the urge will fall.</summary>
internal static class TechniqueCatalogContentUrgeSurfing
{
    private sealed record Copy(
        string ModuleName, string Author, string WhatHeading, string WhenHeading, string HowHeading, string ExampleHeading,
        string Title, string Subtitle, string Theme, string Summary, string When, string How, string Example, string Icon,
        string BeforeTitle, string UrgeTitle, string UrgeHint, string AfterTitle,
        string[] Steps, string[] Suggestions);

    private static readonly IReadOnlyDictionary<string, Copy> Languages =
        new Dictionary<string, Copy>(StringComparer.Ordinal)
        {
            ["ru"] = new(
                "Практик", "Навык самопомощи", "Что это", "Когда применять", "Как пройти", "Пример",
                "Волна импульса", "Заметьте желание действовать, прежде чем решать, что делать", "Наблюдение",
                "Короткая адаптация навыка наблюдения за импульсом (urge surfing) из практик осознанности DBT. Вместо борьбы с желанием вы замечаете его и оставляете себе время на выбор. Навык описан прежде всего для тяги и зависимого поведения; этот минутный формат для бытовых, безопасно откладываемых действий отдельно не проверялся и не обещает ослабить импульс.",
                "Когда хочется немедленно отправить сообщение или снова проверить телефон и подождать одну минуту безопасно. Не откладывайте медицинскую помощь, нужные лекарства, еду, воду и действия для безопасности. Не используйте эту практику в одиночку при риске навредить себе или кому-то; обратитесь к плану безопасности и живой поддержке.",
                "Сначала проверьте, безопасно ли отложить действие на минуту. Назовите желание фразой «Я замечаю импульс…». Если это комфортно, заметьте одно ощущение в теле, не пытаясь его изменить. В течение минуты наблюдайте: оно усиливается, держится или меняется? Затем оцените импульс ещё раз и выберите следующий безопасный шаг. Не нужно ждать, пока импульс исчезнет.",
                "Вы злитесь и хотите сразу отправить сообщение. На минуту отложите отправку и замечайте, что происходит с желанием и напряжением в челюсти. Импульс может остаться таким же сильным; это не провал. Решите, хотите ли вы подождать ещё, изменить обстановку или обдуманно ответить.",
                "Visibility", "Сила импульса до (0–10)", "Какое действие хочется сделать?", "Опишите только действие, которое безопасно отложить. Можно оставить поле пустым.", "Сила импульса после (0–10)",
                [
                    "1. Оцените силу желания действовать от 0 до 10.",
                    "2. Убедитесь, что действие можно безопасно отложить на минуту. Если оно срочное, касается здоровья или безопасности — займитесь им или обратитесь за помощью.",
                    "3. Назовите желание без оценки: «Я замечаю импульс немедленно [действие]». Импульс — это переживание, а не обязательный приказ.",
                    "4. Если внимание к телу комфортно, выберите одно ощущение и наблюдайте его около минуты: оно усиливается, остаётся прежним или меняется? Не заставляйте его исчезнуть. Если становится хуже, остановитесь и переключите внимание на окружающее.",
                    "5. Оцените импульс снова. Он может ослабнуть, не измениться или усилиться. Выберите безопасный следующий шаг: подождать, сменить обстановку, попросить поддержки или действовать после обдуманного решения. При риске вреда себе или другим нужна немедленная живая помощь."
                ],
                ["Сразу написать или ответить", "Снова проверить телефон", "Другое безопасно откладываемое действие"]),
            ["en"] = new(
                "Practice", "Self-help skill", "What it is", "When to use it", "How to do it", "Example",
                "Ride Out an Urge", "Notice the pull to act before deciding what to do", "Observation",
                "A brief adaptation of mindful urge surfing from DBT mindfulness practice. Instead of fighting a desire, you notice it and make room for a choice. The skill is described primarily for cravings and addictive behavior; this one-minute version for everyday, safely delayable actions has not been tested separately and does not promise to reduce an urge.",
                "When you want to send a message immediately or check your phone again, and waiting one minute is safe. Do not delay medical care, needed medication, food, water, or safety actions. Do not use this practice alone if you may harm yourself or someone else; follow your safety plan and get live support.",
                "First check that it is safe to delay the action for a minute. Name the pull: “I notice an urge to…”. If comfortable, notice one body sensation without trying to change it. For a minute, observe: is it getting stronger, staying steady, or changing? Then rate the urge again and choose a safe next step. You do not have to wait for it to disappear.",
                "You are angry and want to send a message right away. Delay sending for a minute and notice what happens to the urge and the tension in your jaw. The urge may stay just as strong; that is not failure. Decide whether to wait longer, change your surroundings, or reply after thinking it through.",
                "Visibility", "Urge strength before (0–10)", "What action am I pulled to take?", "Describe only an action that is safe to delay. You may leave this blank.", "Urge strength after (0–10)",
                [
                    "1. Rate how strong the pull to act feels, from 0 to 10.",
                    "2. Check that waiting a minute is safe. If the action is urgent or concerns health or safety, take care of it or seek help.",
                    "3. Name the pull without judging it: “I notice an urge to [action] right now.” An urge is an experience, not an order you must follow.",
                    "4. If body awareness feels comfortable, notice one sensation for about a minute: is it growing, steady, or changing? Do not force it to go away. If you feel worse, stop and orient to your surroundings.",
                    "5. Rate the urge again. It may ease, stay the same, or increase. Choose a safe next step: wait, change your surroundings, ask for support, or act after considering your choice. If you may harm yourself or someone else, get immediate live support."
                ],
                ["Text or reply right away", "Check my phone again", "Another action that is safe to delay"]),
            ["de"] = new(
                "Übung", "Selbsthilfe", "Was ist das?", "Wann anwenden?", "So geht es", "Beispiel",
                "Einen Impuls beobachten", "Nimm den Handlungsdrang wahr, bevor du dich entscheidest", "Beobachten",
                "Eine kurze Anpassung des achtsamen Umgangs mit Impulsen („Urge Surfing“) aus der DBT-Achtsamkeit. Statt gegen den Wunsch anzukämpfen, bemerkst du ihn und schaffst Raum für eine Entscheidung. Die Fertigkeit wird vor allem bei Suchtdruck beschrieben; diese einminütige Version für alltägliche, sicher aufschiebbare Handlungen wurde nicht eigens geprüft und verspricht keine Abschwächung des Impulses.",
                "Wenn du sofort eine Nachricht senden oder erneut dein Telefon prüfen möchtest und eine Minute Aufschub sicher ist. Verschiebe keine medizinische Hilfe, notwendigen Medikamente, Nahrung, Wasser oder Sicherheitsmaßnahmen. Bei Gefahr, dir oder anderen zu schaden, nutze diese Übung nicht allein, sondern deinen Sicherheitsplan und direkte Unterstützung.",
                "Prüfe zuerst, ob du die Handlung sicher eine Minute aufschieben kannst. Benenne den Drang: „Ich bemerke den Impuls, …“. Wenn es sich gut anfühlt, nimm eine Körperempfindung wahr, ohne sie verändern zu wollen. Beobachte eine Minute lang: wird sie stärker, bleibt sie gleich oder verändert sie sich? Bewerte den Impuls danach erneut und wähle einen sicheren nächsten Schritt. Du musst nicht warten, bis er verschwindet.",
                "Du bist wütend und möchtest sofort eine Nachricht senden. Warte eine Minute und beobachte den Impuls und die Spannung im Kiefer. Der Impuls kann gleich stark bleiben; das ist kein Scheitern. Entscheide, ob du weiter wartest, die Umgebung wechselst oder überlegt antwortest.",
                "Visibility", "Impulsstärke vorher (0–10)", "Was möchte ich gerade tun?", "Beschreibe nur eine Handlung, die sicher warten kann. Das Feld darf leer bleiben.", "Impulsstärke nachher (0–10)",
                [
                    "1. Bewerte den Handlungsdrang von 0 bis 10.",
                    "2. Prüfe, ob eine Minute Aufschub sicher ist. Ist die Handlung dringend oder betrifft sie Gesundheit oder Sicherheit, kümmere dich darum oder hole Hilfe.",
                    "3. Benenne den Drang ohne Urteil: „Ich bemerke gerade den Impuls, …“. Ein Impuls ist ein Erleben, kein Befehl.",
                    "4. Wenn die Aufmerksamkeit auf den Körper angenehm ist, beobachte etwa eine Minute lang eine Empfindung: wird sie stärker, bleibt sie gleich oder verändert sie sich? Erzwinge kein Verschwinden. Wenn es dir schlechter geht, hör auf und richte die Aufmerksamkeit nach außen.",
                    "5. Bewerte den Impuls erneut. Er kann nachlassen, gleich bleiben oder stärker werden. Wähle einen sicheren nächsten Schritt: warten, die Umgebung wechseln, Unterstützung holen oder nach kurzem Nachdenken handeln. Bei möglicher Gefahr für dich oder andere hole sofort direkte Hilfe."
                ],
                ["Sofort schreiben oder antworten", "Das Telefon erneut prüfen", "Eine andere sicher aufschiebbare Handlung"]),
            ["es"] = new(
                "Práctica", "Autocuidado", "Qué es", "Cuándo usarla", "Cómo hacerlo", "Ejemplo",
                "Observar la ola del impulso", "Nota el deseo de actuar antes de decidir qué hacer", "Observación",
                "Es una adaptación breve de la observación consciente del impulso («urge surfing») en las prácticas de atención plena de DBT. En lugar de luchar contra el deseo, lo notas y dejas espacio para elegir. Esta habilidad se describe principalmente para los deseos intensos y las conductas adictivas; esta versión de un minuto para acciones cotidianas que se pueden aplazar con seguridad no se ha probado por separado y no promete reducir el impulso.",
                "Cuando quieras enviar un mensaje de inmediato o volver a mirar el teléfono y esperar un minuto sea seguro. No retrases atención médica, medicación necesaria, comida, agua ni acciones de seguridad. Si existe riesgo de hacerte daño o hacérselo a alguien, no uses esta práctica a solas: sigue tu plan de seguridad y busca apoyo directo.",
                "Primero comprueba si es seguro aplazar la acción un minuto. Nombra el deseo: «Noto el impulso de…». Si te resulta cómodo, observa una sensación corporal sin intentar cambiarla. Durante un minuto, observa: ¿se intensifica, se mantiene o cambia? Después vuelve a valorar el impulso y elige un paso seguro. No tienes que esperar a que desaparezca.",
                "Estás enfadado y quieres enviar un mensaje de inmediato. Espera un minuto antes de enviarlo y observa el impulso y la tensión en la mandíbula. Puede seguir igual de fuerte; no es un fracaso. Decide si quieres esperar más, cambiar de entorno o responder tras pensarlo.",
                "Visibility", "Intensidad del impulso antes (0–10)", "¿Qué acción me apetece hacer?", "Describe solo una acción que sea seguro aplazar. Puedes dejarlo en blanco.", "Intensidad del impulso después (0–10)",
                [
                    "1. Valora cuánto te empuja a actuar, de 0 a 10.",
                    "2. Comprueba que esperar un minuto sea seguro. Si la acción es urgente o afecta a tu salud o seguridad, ocúpate de ella o pide ayuda.",
                    "3. Nombra el impulso sin juzgarlo: «Noto el impulso de [acción] ahora». Es una experiencia, no una orden que debas obedecer.",
                    "4. Si prestar atención al cuerpo te resulta cómodo, observa una sensación durante un minuto: ¿crece, sigue igual o cambia? No intentes hacerla desaparecer. Si empeoras, detente y orienta la atención hacia el entorno.",
                    "5. Valora el impulso de nuevo. Puede disminuir, seguir igual o aumentar. Elige un paso seguro: esperar, cambiar de entorno, pedir apoyo o actuar tras pensarlo. Si puedes hacerte daño o hacérselo a alguien, busca apoyo directo de inmediato."
                ],
                ["Escribir o responder ya", "Volver a mirar el teléfono", "Otra acción que sea seguro aplazar"]),
            ["fr"] = new(
                "Exercice", "Aide personnelle", "De quoi s’agit-il ?", "Quand l’utiliser ?", "Comment faire", "Exemple",
                "Observer la vague d’une impulsion", "Remarquez l’envie d’agir avant de choisir quoi faire", "Observation",
                "Une adaptation brève de l’observation consciente des impulsions (« urge surfing ») issue de la pleine conscience en DBT. Au lieu de lutter contre l’envie, vous la remarquez et vous vous laissez le temps de choisir. Cette compétence est surtout décrite pour les envies liées aux addictions ; cette version d’une minute pour des gestes quotidiens que l’on peut différer sans risque n’a pas été évaluée séparément et ne promet pas d’atténuer l’impulsion.",
                "Lorsque vous voulez envoyer un message immédiatement ou vérifier encore votre téléphone, et qu’attendre une minute est sans danger. Ne différez pas des soins médicaux, un traitement nécessaire, la nourriture, l’eau ou une mesure de sécurité. En cas de risque de vous faire du mal ou d’en faire à quelqu’un, ne restez pas seul avec cet exercice : suivez votre plan de sécurité et demandez un soutien direct.",
                "Vérifiez d’abord qu’il est sans danger de différer l’action une minute. Nommez l’envie : « Je remarque une impulsion à… ». Si cela vous convient, observez une sensation corporelle sans chercher à la modifier. Pendant une minute, remarquez si elle augmente, reste stable ou change. Évaluez l’impulsion de nouveau et choisissez une étape sûre. Vous n’avez pas à attendre qu’elle disparaisse.",
                "Vous êtes en colère et voulez envoyer un message tout de suite. Attendez une minute avant l’envoi et observez l’envie et la tension dans votre mâchoire. L’impulsion peut rester aussi forte ; ce n’est pas un échec. Décidez si vous souhaitez attendre davantage, changer d’environnement ou répondre après réflexion.",
                "Visibility", "Force de l’impulsion avant (0–10)", "Quelle action ai-je envie de faire ?", "Décrivez seulement une action qu’il est sans risque de différer. Vous pouvez laisser ce champ vide.", "Force de l’impulsion après (0–10)",
                [
                    "1. Évaluez la force de l’envie d’agir de 0 à 10.",
                    "2. Vérifiez qu’attendre une minute est sans danger. Si l’action est urgente ou concerne la santé ou la sécurité, occupez-vous-en ou demandez de l’aide.",
                    "3. Nommez l’envie sans vous juger : « Je remarque l’impulsion de [action], là, maintenant. » Une impulsion est une expérience, pas un ordre.",
                    "4. Si l’attention au corps vous convient, observez une sensation pendant environ une minute : augmente-t-elle, reste-t-elle stable ou change-t-elle ? Ne cherchez pas à la faire disparaître. Si vous vous sentez plus mal, arrêtez et regardez autour de vous.",
                    "5. Réévaluez l’impulsion. Elle peut diminuer, rester stable ou augmenter. Choisissez une étape sûre : attendre, changer d’environnement, demander du soutien ou agir après réflexion. Si vous risquez de vous faire du mal ou d’en faire à quelqu’un, demandez immédiatement un soutien direct."
                ],
                ["Écrire ou répondre tout de suite", "Vérifier encore le téléphone", "Une autre action qu’il est sans risque de différer"]),
            ["pt"] = new(
                "Prática", "Autocuidado", "O que é", "Quando usar", "Como fazer", "Exemplo",
                "Observar a onda do impulso", "Perceba a vontade de agir antes de decidir o que fazer", "Observação",
                "Uma adaptação breve da observação consciente do impulso («urge surfing») das práticas de atenção plena da DBT. Em vez de lutar contra a vontade, você a percebe e cria espaço para escolher. A habilidade é descrita principalmente para fissuras e comportamentos aditivos; esta versão de um minuto para ações cotidianas que podem ser adiadas com segurança não foi avaliada separadamente e não promete reduzir o impulso.",
                "Quando quiser enviar uma mensagem imediatamente ou verificar o celular de novo, e esperar um minuto for seguro. Não adie cuidados médicos, medicamentos necessários, comida, água ou ações de segurança. Se houver risco de machucar a si mesmo ou outra pessoa, não faça esta prática sozinho: siga seu plano de segurança e procure apoio direto.",
                "Primeiro, confirme que é seguro adiar a ação por um minuto. Nomeie a vontade: «Percebo um impulso de…». Se for confortável, observe uma sensação no corpo sem tentar mudá-la. Por um minuto, note se ela aumenta, permanece ou muda. Depois avalie o impulso novamente e escolha um próximo passo seguro. Você não precisa esperar que desapareça.",
                "Você está com raiva e quer enviar uma mensagem imediatamente. Espere um minuto antes de enviar e observe o impulso e a tensão na mandíbula. Ele pode continuar tão forte quanto antes; isso não é fracasso. Decida se quer esperar mais, mudar de ambiente ou responder depois de refletir.",
                "Visibility", "Força do impulso antes (0–10)", "Que ação estou com vontade de fazer?", "Descreva apenas uma ação que seja seguro adiar. Você pode deixar em branco.", "Força do impulso depois (0–10)",
                [
                    "1. Avalie de 0 a 10 a força da vontade de agir.",
                    "2. Confirme que esperar um minuto é seguro. Se a ação for urgente ou envolver saúde ou segurança, cuide dela ou peça ajuda.",
                    "3. Nomeie a vontade sem julgamento: «Percebo um impulso de [ação] agora». Um impulso é uma experiência, não uma ordem.",
                    "4. Se prestar atenção ao corpo for confortável, observe uma sensação por cerca de um minuto: ela aumenta, fica igual ou muda? Não tente fazê-la desaparecer. Se piorar, pare e volte a atenção para o ambiente.",
                    "5. Avalie o impulso novamente. Ele pode diminuir, permanecer igual ou aumentar. Escolha um próximo passo seguro: esperar, mudar de ambiente, pedir apoio ou agir depois de refletir. Se houver risco de machucar a si mesmo ou outra pessoa, procure apoio direto imediatamente."
                ],
                ["Escrever ou responder agora", "Verificar o celular novamente", "Outra ação que seja seguro adiar"]),
            ["zh"] = new(
                "练习", "自我照护", "这是什么", "适用时机", "练习方法", "示例",
                "观察冲动的起伏", "先留意行动的冲动，再决定怎么做", "观察",
                "这是对 DBT 正念练习中觉察冲动（urge surfing）的简短改编。不要和冲动对抗，先注意到它，为自己留出选择的空间。这项技能主要用于成瘾相关的渴求；此处针对日常、可以安全延后的行动所做的一分钟版本尚未单独验证，也不保证冲动减弱。",
                "当你很想立刻发消息或再次查看手机，而且等待一分钟是安全的。不延误医疗照护、必要药物、食物、饮水或安全行动。如果你可能伤害自己或他人，不要独自使用此练习；请遵循安全计划并寻求现实中的支持。",
                "先确认把行动延后一分钟是安全的。用一句话说出冲动：“我注意到自己很想……”。如果关注身体让你感觉舒适，就观察一种身体感受，不必试图改变它。用一分钟留意它是在增强、保持不变还是发生变化。然后再次评估冲动，并选择安全的下一步。不必等到冲动消失。",
                "你很生气，想马上发消息。先等一分钟，留意冲动和下颌的紧绷感。冲动可能仍然很强；这不代表失败。想想是否继续等一会儿、换个环境，或考虑后再回复。",
                "Visibility", "练习前的冲动强度（0–10）", "我现在很想做什么？", "只描述可以安全延后的行动。也可以留空。", "练习后的冲动强度（0–10）",
                [
                    "1. 将行动冲动的强度评为 0 到 10。",
                    "2. 确认等待一分钟是安全的。如果事情紧急或涉及健康、安全，就先处理或寻求帮助。",
                    "3. 不评判地说出冲动：“我注意到自己现在很想 [行动]。”冲动是一种体验，不是必须服从的命令。",
                    "4. 如果关注身体让你感觉舒适，用约一分钟观察一种感受：它在增强、保持不变还是变化？不要强迫它消失。如果感觉更糟，就停下并把注意力转向周围环境。",
                    "5. 再次评估冲动。它可能减弱、保持不变或增强。选择安全的下一步：继续等待、换个环境、寻求支持，或经过考虑后行动。如果你可能伤害自己或他人，请立即寻求现实中的支持。"
                ],
                ["立刻发消息或回复", "再次查看手机", "其他可以安全延后的行动"])
        };

    internal static IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> For(string? language)
    {
        string key = language?.ToLowerInvariant() ?? "en";
        Copy copy = Languages.TryGetValue(key, out Copy? localized) ? localized : Languages["en"];
        return new Dictionary<TechniqueId, BuiltInTechniqueDefinition>
        {
            [TechniqueId.UrgeSurfing] = Create(copy)
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
            new TechniqueEntrySeed(copy.UrgeTitle, copy.UrgeHint, Suggestions: copy.Suggestions),
            new TechniqueEntrySeed(copy.AfterTitle, Kind: EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        [
            new TheorySection(copy.WhatHeading, copy.Summary),
            new TheorySection(copy.WhenHeading, copy.When),
            new TheorySection(copy.HowHeading, copy.How),
            new TheorySection(copy.ExampleHeading, copy.Example)
        ]);
}
