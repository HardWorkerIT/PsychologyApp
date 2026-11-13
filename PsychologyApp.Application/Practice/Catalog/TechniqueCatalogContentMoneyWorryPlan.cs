using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Practice.Catalog;

/// <summary>A bounded reflection exercise; it does not provide financial or legal advice.</summary>
internal static class TechniqueCatalogContentMoneyWorryPlan
{
    private sealed record Copy(
        string ModuleName, string Author, string WhatHeading, string WhenHeading, string HowHeading, string ExampleHeading,
        string Title, string Subtitle, string Theme, string Summary, string When, string How, string Example, string Icon,
        string WorryTitle, string WorryHint, string FactsTitle, string FactsHint, string StepTitle, string StepHint,
        string[] Steps);

    private static readonly IReadOnlyDictionary<string, Copy> Languages =
        new Dictionary<string, Copy>(StringComparer.Ordinal)
        {
            ["ru"] = new(
                "Практика", "Навык самопомощи", "Что это", "Когда применять", "Как пройти", "Пример",
                "Разобрать денежную тревогу", "Отделить факты, неизвестное и прогнозы и выбрать один безопасный шаг", "Ясность",
                "Короткое упражнение, чтобы упорядочить денежную тревогу. Оно не даёт финансовых или юридических советов и не заменяет практическую помощь.",
                "Когда мысли о деньгах ходят по кругу, но сейчас не под угрозой базовые потребности. Если не хватает еды, жилья, необходимых лекарств или небезопасно, сначала обратитесь за реальной помощью.",
                "Опишите ситуацию общими словами. Не указывайте суммы, реквизиты, пароли, коды подтверждения или данные других людей. Разделите известные факты, то, что нужно уточнить, и опасения. Выберите один небольшой обратимый шаг или просьбу о поддержке. Не принимайте срочных финансовых решений под давлением.",
                "Вы ждёте ответа по счёту и думаете: «Я не справлюсь». Факт: ответа пока нет. Неизвестно: когда он придёт. Опасение: будет трудно успеть. Шаг: проверить срок в известном официальном канале или попросить человека помочь найти практическую поддержку.",
                "AccountBalanceWallet",
                "О чём тревожитесь — в общих словах", "Не пишите суммы, реквизиты, пароли или коды.",
                "Что известно и что нужно уточнить", "Отделите проверяемый факт от неизвестного.",
                "Один безопасный следующий шаг", "Выберите небольшой обратимый шаг или человека, у которого можно попросить помощь.",
                [
                    "1. Проверьте срочность: если сейчас под угрозой еда, жильё, необходимые лекарства или безопасность, остановитесь и обратитесь за живой практической помощью.",
                    "2. Назовите тревогу в общих словах. Не записывайте суммы, номера счетов и карт, пароли, коды подтверждения или чужие личные данные.",
                    "3. Разделите ситуацию на три части: что точно известно, что можно уточнить и какого исхода вы опасаетесь. Опасение важно, но само по себе не является подтверждённым фактом.",
                    "4. Выберите один безопасный вопрос для проверки в знакомом официальном источнике. Не переводите деньги и не сообщайте секретные данные по неожиданному сообщению или звонку.",
                    "5. Если это уместно и безопасно, выберите небольшой обратимый шаг или конкретную просьбу о помощи. Если стало тяжелее, завершите упражнение и поговорите с человеком, которому доверяете."
                ]),
            ["en"] = new(
                "Practice", "Self-help skill", "What it is", "When to use it", "How to do it", "Example",
                "Sort a Money Worry", "Separate facts, unknowns, and predictions, then choose one safe step", "Clarity",
                "A brief exercise for organising a money worry. It does not give financial or legal advice and cannot replace practical help.",
                "Use it when money worries are looping but essential needs are not in immediate danger. If food, housing, essential medicine, or safety is at risk, seek real-world help first.",
                "Describe the situation in general terms. Do not enter amounts, account or card details, passwords, verification codes, or another person’s information. Separate known facts, what needs checking, and feared outcomes. Choose one small, reversible step or ask for support. Do not make urgent financial decisions under pressure.",
                "You are waiting for a reply about a bill and think, I will not cope. Fact: there is no reply yet. Unknown: when it will arrive. Fear: it may be hard to meet the deadline. Step: check the date through a known official channel or ask someone to help find practical support.",
                "AccountBalanceWallet",
                "What is worrying you, in general terms", "Do not enter amounts, account details, passwords, or codes.",
                "What is known and what needs checking", "Separate a checkable fact from an unknown.",
                "One safe next step", "Choose a small reversible step or someone you can ask for help.",
                [
                    "1. Check urgency: if food, housing, essential medicine, or safety is at risk now, stop and seek real-world practical help.",
                    "2. Name the worry in general terms. Do not record amounts, account or card numbers, passwords, verification codes, or another person’s private details.",
                    "3. Sort it into three parts: what is known, what can be checked, and what outcome you fear. The fear matters, but it is not by itself a confirmed fact.",
                    "4. Choose one safe question to check through a familiar official source. Do not transfer money or share secret details because of an unexpected message or call.",
                    "5. If appropriate and safe, choose one small reversible step or a specific request for help. If you feel worse, stop and talk with someone you trust."
                ]),
            ["de"] = new(
                "Übung", "Selbsthilfefertigkeit", "Was ist das", "Wann anwenden", "So geht’s", "Beispiel",
                "Geldsorgen ordnen", "Fakten, offene Fragen und Befürchtungen trennen und einen sicheren Schritt wählen", "Überblick",
                "Eine kurze Übung, um Geldsorgen zu ordnen. Sie bietet keine Finanz- oder Rechtsberatung und ersetzt keine praktische Unterstützung.",
                "Wenn sich Geldsorgen im Kreis drehen, aber grundlegende Bedürfnisse nicht unmittelbar gefährdet sind. Sind Nahrung, Unterkunft, notwendige Medikamente oder Sicherheit bedroht, suchen Sie zuerst konkrete Hilfe.",
                "Beschreiben Sie die Lage allgemein. Geben Sie keine Beträge, Konto- oder Kartendaten, Passwörter, Bestätigungscodes oder Informationen über andere Personen ein. Trennen Sie bekannte Fakten, offene Fragen und befürchtete Folgen. Wählen Sie einen kleinen, umkehrbaren Schritt oder bitten Sie um Unterstützung. Treffen Sie unter Druck keine dringenden Finanzentscheidungen.",
                "Sie warten auf eine Antwort zu einer Rechnung und denken: Ich schaffe das nicht. Fakt: Es gibt noch keine Antwort. Unklar: Wann sie kommt. Befürchtung: Die Frist könnte knapp werden. Schritt: Prüfen Sie den Termin über einen bekannten offiziellen Kanal oder bitten Sie jemanden, mit Ihnen praktische Hilfe zu finden.",
                "AccountBalanceWallet",
                "Was Sie belastet, allgemein beschrieben", "Keine Beträge, Kontodaten, Passwörter oder Codes notieren.",
                "Was bekannt ist und was noch zu klären ist", "Trennen Sie prüfbare Fakten von offenen Fragen.",
                "Ein sicherer nächster Schritt", "Wählen Sie einen kleinen umkehrbaren Schritt oder eine Person, um Hilfe zu bitten.",
                [
                    "1. Prüfen Sie die Dringlichkeit: Sind Nahrung, Unterkunft, notwendige Medikamente oder Sicherheit jetzt gefährdet, unterbrechen Sie die Übung und suchen Sie konkrete Hilfe.",
                    "2. Benennen Sie die Sorge allgemein. Notieren Sie keine Beträge, Konto- oder Kartennummern, Passwörter, Bestätigungscodes oder privaten Daten anderer.",
                    "3. Teilen Sie die Lage in drei Teile: Was ist bekannt, was lässt sich prüfen und welchen Ausgang befürchten Sie? Die Befürchtung ist wichtig, aber allein noch kein bestätigter Fakt.",
                    "4. Wählen Sie eine sichere Frage, die Sie über eine vertraute offizielle Stelle prüfen können. Überweisen Sie wegen unerwarteter Nachrichten oder Anrufe kein Geld und teilen Sie keine geheimen Daten.",
                    "5. Wählen Sie, wenn passend und sicher, einen kleinen umkehrbaren Schritt oder eine konkrete Bitte um Hilfe. Wenn es Ihnen schlechter geht, beenden Sie die Übung und sprechen Sie mit einer vertrauten Person."
                ]),
            ["es"] = new(
                "Práctica", "Habilidad de autoayuda", "Qué es", "Cuándo usarla", "Cómo hacerla", "Ejemplo",
                "Ordenar una preocupación por el dinero", "Distingue hechos, dudas y predicciones y elige un paso seguro", "Claridad",
                "Un ejercicio breve para ordenar una preocupación económica. No ofrece asesoramiento financiero ni legal y no sustituye la ayuda práctica.",
                "Úsalo si la preocupación se repite, pero las necesidades básicas no están en peligro inmediato. Si faltan alimentos, vivienda, medicamentos esenciales o seguridad, busca ayuda real primero.",
                "Describe la situación en términos generales. No escribas cantidades, datos de cuentas o tarjetas, contraseñas, códigos de verificación ni información de otras personas. Separa los hechos conocidos, lo que falta por comprobar y los resultados que temes. Elige un paso pequeño y reversible o pide apoyo. No tomes decisiones financieras urgentes bajo presión.",
                "Esperas una respuesta sobre una factura y piensas: no podré con esto. Hecho: aún no hay respuesta. Duda: cuándo llegará. Temor: quizá no haya tiempo suficiente. Paso: comprueba la fecha en un canal oficial conocido o pide ayuda para encontrar apoyo práctico.",
                "AccountBalanceWallet",
                "Qué te preocupa, en términos generales", "No incluyas cantidades, datos bancarios, contraseñas ni códigos.",
                "Qué sabes y qué falta por comprobar", "Separa un hecho verificable de una duda.",
                "Un siguiente paso seguro", "Elige un paso pequeño y reversible o a quién pedir ayuda.",
                [
                    "1. Comprueba la urgencia: si ahora están en riesgo la comida, la vivienda, los medicamentos esenciales o tu seguridad, detén el ejercicio y busca ayuda práctica en persona.",
                    "2. Nombra la preocupación en términos generales. No anotes cantidades, números de cuenta o tarjeta, contraseñas, códigos de verificación ni datos privados de otras personas.",
                    "3. Separa tres cosas: qué sabes, qué puedes comprobar y qué resultado temes. El temor importa, pero por sí solo no confirma que vaya a ocurrir.",
                    "4. Elige una pregunta segura y compruébala en una fuente oficial que ya conozcas. No envíes dinero ni compartas datos secretos por un mensaje o llamada inesperados.",
                    "5. Si es adecuado y seguro, elige un paso pequeño y reversible o una petición concreta de ayuda. Si te sientes peor, para y habla con alguien de confianza."
                ]),
            ["fr"] = new(
                "Pratique", "Compétence d’auto-aide", "De quoi s’agit-il", "Quand l’utiliser", "Comment faire", "Exemple",
                "Faire le tri dans une inquiétude d’argent", "Distinguer les faits, les inconnues et les scénarios redoutés, puis choisir une étape sûre", "Clarté",
                "Un exercice bref pour organiser une inquiétude liée à l’argent. Il ne donne aucun conseil financier ou juridique et ne remplace pas une aide pratique.",
                "À utiliser si les inquiétudes tournent en boucle sans menace immédiate pour les besoins essentiels. Si la nourriture, le logement, des médicaments indispensables ou la sécurité sont en jeu, cherchez d’abord une aide concrète.",
                "Décrivez la situation en termes généraux. N’indiquez aucun montant, identifiant de compte ou de carte, mot de passe, code de vérification ni donnée concernant autrui. Séparez les faits connus, ce qui reste à vérifier et les issues redoutées. Choisissez une petite étape réversible ou demandez du soutien. Ne prenez pas de décision financière urgente sous pression.",
                "Vous attendez une réponse au sujet d’une facture et pensez : je n’y arriverai pas. Fait : aucune réponse pour l’instant. Inconnue : la date de réponse. Crainte : le délai pourrait être court. Étape : vérifiez la date par un canal officiel connu ou demandez de l’aide pour trouver un soutien pratique.",
                "AccountBalanceWallet",
                "Ce qui vous inquiète, en termes généraux", "N’indiquez ni montants, ni coordonnées, ni mots de passe, ni codes.",
                "Ce qui est connu et ce qui reste à vérifier", "Séparez un fait vérifiable d’une inconnue.",
                "Une prochaine étape sûre", "Choisissez une petite étape réversible ou une personne à qui demander de l’aide.",
                [
                    "1. Vérifiez l’urgence : si la nourriture, le logement, des médicaments indispensables ou la sécurité sont menacés maintenant, arrêtez l’exercice et cherchez une aide concrète.",
                    "2. Nommez l’inquiétude en termes généraux. Ne notez aucun montant, numéro de compte ou de carte, mot de passe, code de vérification ni donnée privée d’une autre personne.",
                    "3. Distinguez trois éléments : ce qui est connu, ce qui peut être vérifié et l’issue que vous redoutez. Cette crainte compte, mais ne confirme pas à elle seule ce qui va arriver.",
                    "4. Choisissez une question sûre à vérifier auprès d’une source officielle que vous connaissez. Ne transférez pas d’argent et ne partagez pas de données secrètes après un message ou appel inattendu.",
                    "5. Si cela convient et reste sûr, choisissez une petite étape réversible ou une demande d’aide précise. Si vous vous sentez plus mal, arrêtez et parlez à une personne de confiance."
                ]),
            ["pt"] = new(
                "Prática", "Habilidade de autoajuda", "O que é", "Quando usar", "Como fazer", "Exemplo",
                "Organizar uma preocupação com dinheiro", "Separe fatos, dúvidas e previsões e escolha um passo seguro", "Clareza",
                "Um exercício breve para organizar uma preocupação financeira. Não oferece aconselhamento financeiro ou jurídico e não substitui ajuda prática.",
                "Use quando a preocupação se repete, mas as necessidades básicas não estão em perigo imediato. Se faltam alimentos, moradia, medicamentos essenciais ou segurança, procure ajuda concreta primeiro.",
                "Descreva a situação em termos gerais. Não informe valores, dados de contas ou cartões, senhas, códigos de verificação nem informações de outras pessoas. Separe fatos conhecidos, o que falta verificar e os resultados que teme. Escolha um passo pequeno e reversível ou peça apoio. Não tome decisões financeiras urgentes sob pressão.",
                "Você espera uma resposta sobre uma conta e pensa: não vou dar conta. Fato: ainda não houve resposta. Dúvida: quando ela chegará. Receio: talvez falte tempo. Passo: confira a data por um canal oficial conhecido ou peça ajuda para encontrar apoio prático.",
                "AccountBalanceWallet",
                "O que preocupa você, em termos gerais", "Não inclua valores, dados bancários, senhas ou códigos.",
                "O que é conhecido e o que falta verificar", "Separe um fato verificável de uma dúvida.",
                "Um próximo passo seguro", "Escolha um passo pequeno e reversível ou alguém a quem pedir ajuda.",
                [
                    "1. Verifique a urgência: se alimentos, moradia, medicamentos essenciais ou segurança estão em risco agora, pare o exercício e procure ajuda prática presencial.",
                    "2. Nomeie a preocupação em termos gerais. Não anote valores, números de contas ou cartões, senhas, códigos de verificação ou dados privados de outra pessoa.",
                    "3. Separe três partes: o que se sabe, o que pode ser verificado e qual resultado você teme. O receio importa, mas não confirma sozinho o que vai acontecer.",
                    "4. Escolha uma pergunta segura para verificar em uma fonte oficial conhecida. Não transfira dinheiro nem compartilhe dados secretos por causa de mensagem ou ligação inesperada.",
                    "5. Se for adequado e seguro, escolha um passo pequeno e reversível ou um pedido específico de ajuda. Se você se sentir pior, pare e converse com alguém de confiança."
                ]),
            ["zh"] = new(
                "练习", "自助技巧", "这是什么", "何时使用", "如何练习", "示例",
                "梳理金钱带来的担忧", "区分事实、未知和预测，再选择一个安全的小步骤", "清晰",
                "这是一个帮助整理金钱担忧的简短练习，不提供财务或法律建议，也不能替代实际帮助。",
                "当担忧反复出现、但基本生活需要暂时没有受到直接威胁时可以使用。如果食物、住处、必需药物或人身安全正面临风险，请先寻求现实中的帮助。",
                "用概括的方式描述情况。不要填写金额、账户或银行卡信息、密码、验证码或他人的个人信息。区分已知事实、需要核实的事情和担心的结果。选择一个小而可调整的步骤，或向他人求助。不要在压力下匆忙作出财务决定。",
                "你在等待一笔账单的答复，心里想：我应付不了。事实：目前还没有答复。未知：答复何时到达。担心：可能赶不上期限。步骤：通过熟悉的官方渠道核实日期，或请可信的人帮忙寻找实际支持。",
                "AccountBalanceWallet",
                "你在担心什么，请用概括的方式描述", "不要填写金额、账户信息、密码或验证码。",
                "哪些已经知道，哪些还要核实", "把可核实的事实与未知分开。",
                "一个安全的下一步", "选择一个小而可调整的步骤，或一位可以求助的人。",
                [
                    "1. 先判断是否紧急：如果食物、住处、必需药物或人身安全现在受到威胁，请停止练习并寻求现实中的实际帮助。",
                    "2. 用概括的方式说出担忧。不要记录金额、账户或银行卡号、密码、验证码或他人的隐私信息。",
                    "3. 分成三部分：已经知道什么、可以核实什么、你担心会发生什么。担忧值得重视，但它本身并不等于已经确认的事实。",
                    "4. 选一个安全的问题，通过你熟悉的官方渠道核实。不要因为陌生消息或电话转账，也不要透露秘密信息。",
                    "5. 如果合适且安全，选择一个小而可调整的步骤，或提出具体的求助请求。如果感觉更糟，请停止练习并联系可信任的人。"
                ])
        };

    internal static IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> For(string? language)
    {
        string key = language?.ToLowerInvariant() ?? "en";
        Copy copy = Languages.TryGetValue(key, out Copy? localized) ? localized : Languages["en"];
        return new Dictionary<TechniqueId, BuiltInTechniqueDefinition>
        {
            [TechniqueId.MoneyWorryPlan] = Create(copy)
        };
    }

    private static BuiltInTechniqueDefinition Create(Copy copy) => new(
        copy.ModuleName,
        copy.Title,
        copy.Steps,
        copy.Summary,
        TechniqueUiKind.Entry,
        copy.ModuleName,
        "2026-11-13",
        copy.Title,
        copy.Subtitle,
        copy.Theme,
        copy.Author,
        4,
        copy.Icon,
        [
            new TechniqueEntrySeed(copy.WorryTitle, copy.WorryHint, Kind: EntryFieldKind.Text),
            new TechniqueEntrySeed(copy.FactsTitle, copy.FactsHint, Kind: EntryFieldKind.Text),
            new TechniqueEntrySeed(copy.StepTitle, copy.StepHint, Kind: EntryFieldKind.Text)
        ],
        [
            new TheorySection(copy.WhatHeading, copy.Summary),
            new TheorySection(copy.WhenHeading, copy.When),
            new TheorySection(copy.HowHeading, copy.How),
            new TheorySection(copy.ExampleHeading, copy.Example)
        ]);
}