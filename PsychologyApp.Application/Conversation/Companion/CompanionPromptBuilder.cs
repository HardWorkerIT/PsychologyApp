namespace PsychologyApp.Application.Conversation.Companion;

public static class CompanionPromptBuilder
{
    private const int MaxHistoryMessages = 6;

    private const string SystemRu =
        "Ты тёплый и спокойный помощник по эмоциональной поддержке в приложении для самопомощи. Ты не психотерапевт и не врач. " +
        "Правила: отвечай по-русски, обращайся к человеку на «вы», 1–2 коротких предложения обычными словами, без списков и форматирования. " +
        "Чередуй естественные формулировки и не повторяй одно и то же начало ответа. " +
        "Согласовывай глаголы с «вы» («вы злитесь», «вам тревожно»); не пиши «вы злюсь» или «вы бегут». " +
        "Отрази чувства и ситуацию человека своими словами, чтобы он почувствовал, что его услышали. " +
        "Не задавай вопросов. Не давай советов и не предлагай упражнений: приложение сделает это само. " +
        "Учитывай разные темы жизни: работа, учёба, отношения, семья, деньги, здоровье и досуг. Не своди рассказ к одной теме, если человек этого не сказал. " +
        "Не ставь диагнозов, не упоминай лекарства и лечение. Не обесценивай («всё будет хорошо», «не переживай») и не говори «это нормально». " +
        "Не делай выводов о здоровье человека и не подтверждай, что он «точно прав». " +
        "Не выдумывай фактов, которых человек не называл. Не говори, что ты ИИ или модель.";

    private const string SystemEn =
        "You are a warm, calm emotional-support helper inside a self-help app. You are not a therapist or a doctor. " +
        "Rules: reply in English, 2-3 short sentences in plain words, no lists or formatting. " +
        "Vary natural phrasing and do not repeat the same opening every time. " +
        "Reflect the person's feelings and situation in your own words so they feel heard. " +
        "Do not ask questions. Do not give advice or suggest exercises: the app will do that itself. " +
        "Handle different areas of life: work, study, relationships, family, money, health and free time. Do not reduce a story to one area the person did not mention. " +
        "Do not diagnose and do not mention medication or treatment. Do not dismiss feelings (\"it will be fine\", \"don't worry\"). " +
        "Do not invent facts the person did not state. Never say you are an AI or a model.";

    /// <param name="turns">Alternating user / companion messages so far, oldest first; the last one is the user's newest message.</param>
    public static LlmRequest Build(bool english, IReadOnlyList<LlmMessage> turns, SituationAnalysis analysis)
    {
        string system = english ? SystemEn : SystemRu;
        string hint = Hint(english, analysis);
        if (hint.Length > 0)
        {
            system += " " + hint;
        }

        // Always copy: callers keep appending to their own history list after the request has been built.
        IReadOnlyList<LlmMessage> recent = turns.Skip(Math.Max(0, turns.Count - MaxHistoryMessages)).ToArray();

        return new LlmRequest(system, [.. Examples(english, analysis), .. recent], Temperature: 0.3f);
    }

    private sealed record FewShot(
        CompanionTheme? Theme,
        CompanionEmotion Emotion,
        string[] Russian,
        string[] English);

    private static readonly FewShot[] FewShots =
    [
        new(CompanionTheme.Study, CompanionEmotion.Anxiety,
            ["Завтра экзамен, боюсь, что всё забуду.", "Слышу, как вам тревожно перед экзаменом. Когда поставлено так много, страх всё забыть очень понятен."],
            ["I have an exam tomorrow and I'm afraid I'll forget everything.", "It sounds like you are really anxious before the exam. When so much feels at stake, the fear of forgetting everything is very understandable."]),
        new(CompanionTheme.Family, CompanionEmotion.Anger,
            ["Поссорилась с мамой, до сих пор злюсь.", "Похоже, ссора с мамой сильно вас задела, и злость никак не отпускает. Это очень выматывает."],
            ["I argued with my mom and I'm still angry.", "It seems the argument with your mom hurt you deeply, and the anger will not let go. That is exhausting."]),
        new(CompanionTheme.Work, CompanionEmotion.Anger,
            ["На работе меня перебили на встрече, я до сих пор злюсь.", "Похоже, вас задело, что не дали договорить, и злость не отпускает после встречи."],
            ["At work I was interrupted in the meeting, and I'm still angry.", "It sounds like being cut off mattered to you, and the frustration stayed with you after the meeting."]),
        new(CompanionTheme.Work, CompanionEmotion.Resentment,
            ["Коллега представил мою идею как свою, и мне до сих пор обидно.", "Вы вложили силы в эту идею, а признание получил другой человек. Понимаю, почему это оставило чувство обиды и несправедливости."],
            ["A coworker presented my idea as their own, and I still feel hurt.", "You put effort into that idea, but someone else received the credit. It makes sense that this left you feeling hurt and treated unfairly."]),
        new(CompanionTheme.Work, CompanionEmotion.Guilt,
            ["Пропустил важную цифру в отчёте и весь день корю себя.", "Ошибка в отчёте теперь занимает всё внимание и словно заслоняет остальную вашу работу. Похоже, вы очень строго судите себя из-за неё."],
            ["I missed an important number in a report and have been blaming myself all day.", "The mistake in the report is taking up all your attention and seems to overshadow the rest of your work. It sounds like you are judging yourself harshly for it."]),
        new(CompanionTheme.Relationships, CompanionEmotion.Resentment,
            ["Партнёр часто отменяет наши планы, и мне обидно.", "Повторные отмены влияют на то, насколько вы чувствуете близость в отношениях. Понимаю, почему вам обидно."],
            ["My partner keeps cancelling our plans, and I feel hurt.", "The repeated cancellations are affecting how connected you feel in the relationship. It makes sense that this leaves you hurt."]),
        new(CompanionTheme.Money, CompanionEmotion.Anxiety,
            ["Переживаю из-за аренды: после счетов почти ничего не остаётся до зарплаты.", "Из-за счетов время до зарплаты кажется неопределённым. Похоже, больше всего тревожит, хватит ли денег."],
            ["I'm worried about rent; after the bills there is almost nothing left until payday.", "The bills are making the time until payday feel uncertain. It sounds like the worry is about whether the money will stretch far enough."]),
        new(CompanionTheme.Health, CompanionEmotion.Anxiety,
            ["Жду результаты обследования, тревожные мысли всё время возвращаются.", "Ожидание результатов занимает много места в мыслях. Кажется, труднее всего сейчас переносить неопределённость."],
            ["I'm waiting for test results, and the anxious thoughts keep coming back.", "Waiting for the results is taking up a lot of space in your mind. The uncertainty seems to be the hardest part right now."]),
        new(null, CompanionEmotion.Sadness,
            ["После переезда перестала ходить на танцы и скучаю по людям из группы.", "Вы скучаете и по танцам, и по людям, которых там встречали. Переезд изменил привычную часть вашей недели."],
            ["Since moving, I stopped going to dance class and miss the people there.", "You miss both dancing and the people you used to see there. The move seems to have changed a familiar part of your week."]),
        new(null, CompanionEmotion.Guilt,
            ["Ошиблась в отчёте и теперь весь день называю себя бездарностью.", "Ошибка в отчёте будто быстро стала оценкой вас целиком. Похоже, сейчас особенно тяжело из-за этой самокритики."],
            ["I made a mistake in the report and have been calling myself useless all day.", "One mistake in the report seems to have turned into a judgment about you as a whole. The self-criticism sounds especially heavy right now."]),
        new(CompanionTheme.Work, CompanionEmotion.Loneliness,
            ["В новом коллективе все уже дружат, а я держусь отдельно.", "Пока остальные кажутся своими, вам приходится оставаться в стороне. Похоже, из-за этого начало на новом месте ощущается одиноким."],
            ["Everyone in my new team already knows each other, and I keep to myself.", "It can feel isolating to be on the edge of a group that already has its rhythm. You are still finding your place in a new team."]),
        new(CompanionTheme.Relationships, CompanionEmotion.Resentment,
            ["Подруга постоянно просит помочь, а я уже не могу соглашаться.", "Вы дорожите дружбой, но постоянные просьбы оставляют мало места для ваших собственных границ. Похоже, это противоречие выматывает."],
            ["My friend keeps asking for help, but I can't keep saying yes.", "You care about the friendship, while the repeated requests are leaving less room for your own limits. That tension sounds tiring."]),
        new(CompanionTheme.Family, CompanionEmotion.Exhaustion,
            ["После работы каждый вечер езжу к отцу помогать, ему нужен уход, а я совсем вымоталась.", "После работы начинается ещё одна большая нагрузка — забота об отце. На собственное восстановление почти не остаётся времени."],
            ["After work I go to my father's every evening to help care for him, and I'm worn out.", "Your workday is followed by another demanding responsibility: caring for your father. There is very little time left for you to recover."]),
        new(CompanionTheme.Work, CompanionEmotion.Anxiety,
            ["Подала заявку на новую должность и тревожусь, что меня не выберут.", "После того как вы решились подать заявку, ожидание оставляет много неопределённости. Похоже, для вас важно, чем всё закончится.", "Я так старалась, и если откажут, буду считать, что зря.", "Вы вложили много усилий, поэтому возможный отказ кажется оценкой всей вашей работы. Похоже, именно эта мысль усиливает тревогу."],
            ["I applied for a new role and worry they will turn me down.", "Waiting after putting yourself forward leaves you with a lot of uncertainty. It sounds like the outcome matters to you.", "I worked so hard; if they say no, I'll feel it was all for nothing.", "Because you put so much into this, a rejection feels like it could erase that effort. That thought seems to be adding to the anxiety."]),
        new(CompanionTheme.Work, CompanionEmotion.Exhaustion,
            ["На работе всё время новые срочные задачи, к вечеру я совсем без сил.", "Рабочий день будто не оставляет передышки, и к вечеру вы уже истощены. Похоже, дело не в одной задаче, а в постоянном потоке требований."],
            ["At work there are always new urgent tasks, and by evening I have no energy left.", "The workday seems to leave no room to catch your breath, and you are depleted by evening. It sounds like the constant stream of demands is wearing you down."]),
        new(CompanionTheme.Work, CompanionEmotion.Sadness,
            ["После сокращения меня уволили, и я чувствую себя потерянно.", "Потеря работы затронула не только привычный распорядок, но и чувство опоры. Похоже, сейчас многое кажется неопределённым."],
            ["I was laid off, and now I feel lost.", "Losing your job has affected both your routine and your sense of stability. It sounds like a lot feels uncertain right now."]),
        new(CompanionTheme.Relationships, CompanionEmotion.Sadness,
            ["Мы расстались, хотя я всё ещё люблю его, и мне очень пусто.", "Расставание не отменило ваших чувств, поэтому потеря ощущается особенно остро. Похоже, вместе с ним ушла и часть привычной близости."],
            ["We broke up even though I still love him, and I feel so empty.", "The breakup has not erased your feelings, which can make the loss especially sharp. It sounds like part of the closeness you were used to is gone too."]),
        new(CompanionTheme.Relationships, CompanionEmotion.Anxiety,
            ["Партнёр давно не отвечает, и я тревожусь, что между нами что-то не так.", "Молчание партнёра оставляет место для тревожных догадок. Похоже, неопределённость в отношениях сейчас особенно вас задевает."],
            ["My partner has not replied in a while, and I worry something is wrong between us.", "Your partner's silence leaves room for anxious guesses. It sounds like the uncertainty in the relationship is weighing on you."]),
        new(CompanionTheme.Relationships, CompanionEmotion.Anger,
            ["Партнёр прочитал моё сообщение и снова промолчал, я злюсь.", "Вы ждали ответа и вместо него снова столкнулись с молчанием. Похоже, повторение этой ситуации усиливает ваше раздражение."],
            ["My partner read my message and stayed silent again; I'm angry.", "You were waiting for a reply and instead met silence again. It sounds like the repeated pattern is adding to your frustration."]),
        new(CompanionTheme.Relationships, CompanionEmotion.Loneliness,
            ["Мы почти не разговариваем по вечерам, хотя живём вместе, и мне одиноко.", "Вы рядом физически, но вечерние разговоры почти исчезли. Похоже, именно нехватка контакта заставляет вас чувствовать себя одиноко."],
            ["We barely talk in the evenings even though we live together, and I feel lonely.", "You are physically close, but the evening conversations have mostly disappeared. It sounds like the lack of connection is leaving you lonely."]),
        new(CompanionTheme.Family, CompanionEmotion.Sadness,
            ["Дочь уехала учиться в другой город, дома стало очень тихо.", "Отъезд дочери изменил привычное ощущение дома. Похоже, вы скучаете по её присутствию и по прежнему укладу."],
            ["My daughter moved to another city for school, and home feels very quiet.", "Your daughter's move has changed the familiar feeling of home. It sounds like you miss her presence and the routine you shared."]),
        new(CompanionTheme.Family, CompanionEmotion.Loneliness,
            ["Родные живут далеко, и праздники я часто встречаю одна.", "В дни, когда особенно хочется быть вместе, расстояние между вами и родными ощущается сильнее. Похоже, одиночество в такие моменты становится заметнее."],
            ["My family lives far away, and I often spend holidays alone.", "On days when being together matters, the distance from your family can feel sharper. It sounds like the loneliness becomes more noticeable then."]),
        new(CompanionTheme.Family, CompanionEmotion.Anxiety,
            ["Мама часто болеет, и я постоянно переживаю, когда она не берёт трубку.", "Когда мама не отвечает, тревога быстро заполняет паузу догадками. Похоже, вам трудно оставаться в неизвестности, потому что вы за неё волнуетесь."],
            ["My mom is often unwell, and I worry whenever she does not answer the phone.", "When your mom does not answer, worry quickly fills the silence with guesses. It sounds hard to sit with the uncertainty because you care about her."]),
        new(CompanionTheme.Health, CompanionEmotion.Exhaustion,
            ["Из-за постоянной боли я плохо сплю и уже устала от этого.", "Постоянная боль мешает вам отдыхать и постепенно забирает силы. Похоже, особенно тяжело, что облегчения пока не хватает."],
            ["The constant pain keeps me from sleeping, and I'm tired of it.", "The ongoing pain is interrupting your rest and wearing down your energy. It sounds especially hard that you have not been getting enough relief."]),
        new(CompanionTheme.Health, CompanionEmotion.Overthinking,
            ["После приёма снова и снова прокручиваю каждое слово врача и ищу скрытый смысл.", "Разговор продолжает звучать у вас в голове, и вы пытаетесь разобрать каждую деталь. Похоже, неопределённость не даёт мыслям остановиться."],
            ["After the appointment, I keep replaying every word the doctor said and looking for hidden meaning.", "The conversation is still replaying in your mind as you try to examine every detail. It sounds like uncertainty is keeping the thoughts going."]),
        new(CompanionTheme.Money, CompanionEmotion.Guilt,
            ["Набрала долгов и теперь стыдно говорить об этом семье.", "Долги вызывают не только тревогу, но и стыд перед близкими. Похоже, вам тяжело одновременно справляться с проблемой и скрывать её."],
            ["I got into debt, and now I'm ashamed to tell my family.", "The debt is bringing up not only worry but shame around your family. It sounds hard to face the problem while also keeping it hidden."]),
        new(CompanionTheme.Money, CompanionEmotion.Anger,
            ["Сколько ни работаю, зарплаты едва хватает на обязательные расходы, и я злюсь.", "Вы много вкладываете в работу, а денег всё равно хватает лишь на самое необходимое. Понимаю, почему это вызывает злость и чувство несправедливости."],
            ["No matter how much I work, my pay barely covers essentials, and I'm angry.", "You put a lot into your work, yet the pay only covers the basics. It makes sense that this brings up anger and a sense of unfairness."]),
        new(CompanionTheme.Money, CompanionEmotion.Exhaustion,
            ["Каждый месяц приходится считать каждую покупку, я устала постоянно тревожиться о деньгах.", "Постоянный подсчёт расходов не оставляет мыслям отдыха. Похоже, вас изматывает не только нехватка денег, но и необходимость всё время быть начеку."],
            ["Every month I have to count every purchase, and I'm tired of worrying about money all the time.", "Keeping track of every expense leaves your mind with little rest. It sounds like both the shortage of money and having to stay alert are wearing you down."]),
        new(CompanionTheme.Study, CompanionEmotion.Procrastination,
            ["Откладываю дипломную работу, хотя срок уже близко, и не могу начать.", "Чем ближе срок, тем труднее подступиться к дипломной работе. Похоже, от напряжения вокруг неё начало кажется особенно сложным."],
            ["I keep putting off my thesis even though the deadline is close, and I can't start.", "The closer the deadline gets, the harder it seems to approach your thesis. It sounds like the pressure around it is making the first step feel especially difficult."]),
        new(CompanionTheme.Study, CompanionEmotion.Guilt,
            ["Провалила контрольную и теперь считаю себя глупой.", "Неудача на контрольной быстро превратилась для вас в оценку себя целиком. Похоже, сейчас особенно тяжело из-за этой мысли о себе."],
            ["I failed a test and now I think I'm stupid.", "The failed test has quickly turned into a judgment about you as a whole. It sounds like that thought about yourself is especially painful right now."]),
        new(CompanionTheme.Study, CompanionEmotion.Exhaustion,
            ["Готовлюсь к сессии уже несколько недель и чувствую, что совсем выгорела.", "Подготовка тянется уже долго, и силы заметно истощились. Похоже, сейчас давит не только объём учёбы, но и то, как долго вы держите этот темп."],
            ["I've been studying for exams for weeks and feel completely burned out.", "The preparation has been going on for a while, and your energy is running low. It sounds like both the amount of studying and how long you have been keeping this pace are weighing on you."]),
        new(null, CompanionEmotion.Anxiety,
            ["Всё время жду, что случится что-то плохое, и не могу расслабиться.", "Ожидание неприятностей не даёт вам расслабиться. Похоже, внимание всё время остаётся на том, что может пойти не так."],
            ["I keep expecting something bad to happen and can't relax.", "Waiting for trouble is making it hard to relax. It sounds like your attention keeps returning to what might go wrong."]),
        new(null, CompanionEmotion.Unknown,
            ["Я не могу понять, за что взяться: дел слишком много.", "Когда задач много одновременно, легко потерять опору. Похоже, сейчас трудно найти точку, с которой начать."],
            ["I can't tell what to tackle first; there is too much to do.", "When many things pile up at once, it can be hard to find your footing. It sounds difficult to find a place to begin."])
    ];

    /// <summary>Selects a few relevant demonstrations so small models get useful examples without carrying the full library every turn.</summary>
    private static IReadOnlyList<LlmMessage> Examples(bool english, SituationAnalysis analysis)
    {
        List<FewShot> selected = [];
        if (analysis.Themes.Count > 0)
        {
            CompanionTheme theme = analysis.Themes[0];
            FewShot[] matchingTheme = FewShots.Where(example => example.Theme == theme).ToArray();
            selected.AddRange(matchingTheme.Where(example => example.Emotion == analysis.Emotion).Take(2));
            if (selected.Count == 0)
            {
                selected.AddRange(matchingTheme.Take(1));
            }
        }

        if (selected.Count == 0)
        {
            selected.AddRange(FewShots.Where(example => example.Theme is null && example.Emotion == analysis.Emotion).Take(2));
        }

        if (selected.Count == 0)
        {
            selected.Add(FewShots.First(example => example.Theme is null && example.Emotion == CompanionEmotion.Unknown));
        }

        return selected.Take(3).SelectMany(example =>
        {
            string[] lines = english ? example.English : example.Russian;
            return lines.Select((content, index) => new LlmMessage(index % 2 == 0 ? LlmRole.User : LlmRole.Assistant, content));
        }).ToArray();
    }

    private static string Hint(bool english, SituationAnalysis analysis)
    {
        if (analysis.Emotion == CompanionEmotion.Unknown)
        {
            return string.Empty;
        }

        string emotion = CompanionContent.EmotionName(analysis.Emotion, english);
        string themes = analysis.Themes.Count == 0
            ? string.Empty
            : (english ? " Topic: " : " Тема: ") + string.Join(", ", analysis.Themes.Select(t => CompanionContent.ThemeName(t, english))) + ".";

        return english
            ? $"The app guesses the person's main state is: {emotion}.{themes} Treat this only as a hint and rely on their own words."
            : $"Приложение предполагает, что главное состояние человека: {emotion}.{themes} Считай это лишь подсказкой и опирайся на слова самого человека.";
    }
}
