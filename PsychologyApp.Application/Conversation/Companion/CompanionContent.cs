using PsychologyApp.Application.Practice.Catalog;

namespace PsychologyApp.Application.Conversation.Companion;

/// <summary>Localized, scripted wording for the deterministic companion dialogue.</summary>
public static class CompanionContent
{
    public static string Greeting(bool english, Random random) => Pick(random, english
        ? ["Hi. I'm here to listen. Tell me in your own words what is going on right now.", "Hello. What's on your mind at the moment? Tell me as it comes."]
        : ["Привет. Я здесь, чтобы выслушать. Расскажите своими словами, что сейчас происходит.", "Здравствуйте. Что у вас на душе прямо сейчас? Расскажите, как есть."]);

    public static string Reflection(SituationAnalysis analysis, bool english, Random random)
    {
        string line = Pick(random, ReflectionLines(analysis.Emotion, english));
        if (analysis.Themes.Count > 0)
        {
            line += english
                ? $" It seems to be connected with {ThemeWith(analysis.Themes[0], true)}."
                : $" Судя по всему, это связано с {ThemeWith(analysis.Themes[0], false)}.";
        }

        if (analysis.IsIntense)
        {
            line += english ? " That sounds really hard." : " Звучит действительно тяжело.";
        }

        return line;
    }

    public static IReadOnlyList<(string Label, CompanionEmotion Emotion)> ClarifyChoices(bool english) => english
        ?
        [
            ("Anxiety or fear", CompanionEmotion.Anxiety), ("Panic", CompanionEmotion.Panic), ("Thoughts going in circles", CompanionEmotion.Overthinking),
            ("Anger", CompanionEmotion.Anger), ("Hurt", CompanionEmotion.Resentment), ("Guilt or shame", CompanionEmotion.Guilt),
            ("Sadness", CompanionEmotion.Sadness), ("Exhaustion", CompanionEmotion.Exhaustion)
        ]
        :
        [
            ("Тревога, страх", CompanionEmotion.Anxiety), ("Паника", CompanionEmotion.Panic), ("Мысли крутятся по кругу", CompanionEmotion.Overthinking),
            ("Злость", CompanionEmotion.Anger), ("Обида", CompanionEmotion.Resentment), ("Вина, стыд", CompanionEmotion.Guilt),
            ("Грусть", CompanionEmotion.Sadness), ("Усталость", CompanionEmotion.Exhaustion)
        ];

    public static string Understood(CompanionEmotion emotion, bool english) => english
        ? $"I see: {EmotionName(emotion, true)}. Thank you."
        : $"Понимаю: {EmotionName(emotion, false)}. Спасибо, что поделились.";

    public static string OfferLine(TechniqueId id, bool english) => english
        ? $"I can guide you through the practice \"{TechniqueTitle(id, true)}\": {TechniqueWhy(id, true)}"
        : $"Могу провести с вами практику «{TechniqueTitle(id, false)}»: {TechniqueWhy(id, false)}";

    public static string StartLabel(TechniqueId id, bool english) => english ? $"Let's start: {TechniqueTitle(id, true)}" : $"Начнём: {TechniqueTitle(id, false)}";

    public static string AlternativeLabel(TechniqueId id, bool english) => english ? $"Another practice: {TechniqueTitle(id, true)}" : $"Другая практика: {TechniqueTitle(id, false)}";

    public static string MoreLabel(bool english) => english ? "I want to say more" : "Хочу ещё рассказать";

    public static string Starting(bool english) => english ? "Okay, let's begin." : "Хорошо, начинаем.";

    public static string Crisis(bool english) => english
        ? "What you wrote is very important, and I'm worried about you. Right now it's best to talk to a real person. I'll open the urgent help section with phone numbers you can call."
        : "То, что вы написали, очень важно, и я переживаю за вас. Сейчас лучше всего поговорить с живым человеком. Я открою раздел срочной помощи с номерами, по которым можно позвонить.";

    public static string EmotionName(CompanionEmotion emotion, bool english) => emotion switch
    {
        CompanionEmotion.Panic => english ? "panic" : "паника",
        CompanionEmotion.Anxiety => english ? "anxiety" : "тревога",
        CompanionEmotion.Overthinking => english ? "racing thoughts" : "навязчивые мысли",
        CompanionEmotion.Anger => english ? "anger" : "злость",
        CompanionEmotion.Resentment => english ? "hurt feelings" : "обида",
        CompanionEmotion.Guilt => english ? "guilt" : "вина",
        CompanionEmotion.Sadness => english ? "sadness" : "грусть",
        CompanionEmotion.Exhaustion => english ? "exhaustion" : "усталость",
        CompanionEmotion.Loneliness => english ? "loneliness" : "одиночество",
        CompanionEmotion.Procrastination => english ? "difficulty getting started" : "трудности с началом дел",
        _ => english ? "unclear" : "неясно"
    };

    public static string ThemeName(CompanionTheme theme, bool english) => theme switch
    {
        CompanionTheme.Work => english ? "work" : "работа",
        CompanionTheme.Relationships => english ? "relationships" : "отношения",
        CompanionTheme.Family => english ? "family" : "семья",
        CompanionTheme.Health => english ? "health" : "здоровье",
        CompanionTheme.Money => english ? "money" : "деньги",
        _ => english ? "study" : "учёба"
    };

    public static string TechniqueTitle(TechniqueId id, bool english) => id switch
    {
        TechniqueId.SensoryComfort => english ? "A sensory pause" : "Сенсорная пауза",

        TechniqueId.UrgeSurfing => english ? "Urge surfing" : "Волна импульса",

        TechniqueId.Grounding => english ? "5-4-3-2-1 grounding" : "Заземление 5-4-3-2-1",
        TechniqueId.Breathing => english ? "Gentle paced breathing" : "Мягкое дыхание",
        TechniqueId.Observer => english ? "Distanced self-talk" : "Разговор с собой со стороны",
        TechniqueId.ThoughtRecord => english ? "Thought record" : "Запись мысли",
        TechniqueId.ThoughtDefusion => english ? "Unhook from a thought" : "Отделиться от мысли",
        TechniqueId.PauseBeforeReaction => english ? "Pause Before Reacting" : "Пауза перед реакцией",
        TechniqueId.OppositeAction => english ? "Choose a Different Action" : "Действие вместо импульса",
        TechniqueId.ProblemSolving => english ? "Solve One Practical Problem" : "Разобрать решаемую задачу",
        TechniqueId.CheckTheFacts => english ? "Check the Facts" : "Проверить факты",
        TechniqueId.WorryTime => english ? "Schedule Worry Time" : "Время для тревоги",
        TechniqueId.ImplementationIntention => english ? "If–Then Action Plan" : "План «если—то»",
        TechniqueId.BusyMind => english ? "Brief Attention Shift" : "Коротко переключить внимание",
        TechniqueId.Paper => english ? "Sheet of paper" : "Лист бумаги",
        TechniqueId.MuscleRelax => english ? "Tense and let go" : "Напрячь и отпустить",
        TechniqueId.Spin => english ? "Spin" : "Крутилка",
        TechniqueId.SelfCompassion => english ? "Kind words to yourself" : "Добрые слова себе",
        TechniqueId.SmallStep => english ? "One small step" : "Один маленький шаг",
        TechniqueId.Anchor => english ? "Supportive memory" : "Воспоминание об опоре",
        TechniqueId.BodyScan => english ? "Where is it in the body?" : "Где это в теле?",
        TechniqueId.Flashback => english ? "A memory took over" : "Накрыло воспоминание",
        TechniqueId.Nightmare => english ? "Rewrite a nightmare" : "Переписать кошмар",
        _ => id.ToString()
    };

    /// <summary>The practice's name as its catalogue card shows it, in any language of the app (outside the ru/en chat).</summary>
    public static string TechniqueTitle(TechniqueId id, string? language) =>
        BuiltInTechniqueCatalogRegistry.For(language)[id].ListTitle;

    public static string TechniqueWhy(TechniqueId id, bool english) => id switch
    {
        TechniqueId.SensoryComfort => english ? "it offers a brief, optional focus on one safe, comfortable sensory cue; it may not change distress." : "она предлагает ненадолго обратить внимание на один безопасный комфортный сигнал; дискомфорт может не измениться.",

        TechniqueId.UrgeSurfing => english ? "it offers a minute to notice a safe-to-delay urge before choosing what to do; the urge may stay the same." : "она предлагает минуту понаблюдать за безопасным, откладываемым импульсом перед выбором действия; сила импульса может не измениться.",

        TechniqueId.Grounding => english ? "it brings attention back to the present through your senses, about 3 minutes." : "она возвращает внимание в настоящий момент через органы чувств, около 3 минут.",
        TechniqueId.Breathing => english ? "it offers a gentle, no-hold pace for about a minute; you can stop if focusing on breath feels uncomfortable." : "она предлагает мягкий ритм дыхания без задержек примерно на минуту; можно остановиться, если следить за дыханием неприятно.",
        TechniqueId.Observer => english ? "it offers a one-minute way to address yourself by name or as ‘you’ and choose a safe next step; distress may not change." : "она предлагает за минуту обратиться к себе по имени или на «ты» и выбрать безопасный шаг; напряжение может не измениться.",
        TechniqueId.ThoughtRecord => english ? "it helps you check a painful thought against the facts." : "она помогает проверить тяжёлую мысль на прочность.",
        TechniqueId.ThoughtDefusion => english ? "it guides you through briefly noticing a repeating thought without arguing with it." : "она помогает коротко заметить повторяющуюся мысль, не споря с ней.",
        TechniqueId.PauseBeforeReaction => english ? "it helps you pause before an impulsive response and choose a safer next step." : "она помогает остановиться перед импульсивным ответом и выбрать более безопасный следующий шаг.",
        TechniqueId.OppositeAction => english ? "it helps you check the facts and safety before taking a small step opposite to an avoidance urge." : "она помогает проверить факты и безопасность, прежде чем сделать небольшой шаг вместо избегания.",
        TechniqueId.ProblemSolving => english ? "it turns one practical problem into a manageable next step, or helps you decide when to revisit it." : "она помогает превратить практическую проблему в посильный шаг или выбрать, когда вернуться к ней.",
        TechniqueId.CheckTheFacts => english ? "it helps separate what happened from what you inferred, while taking real risks and boundaries seriously." : "она помогает отделить факты от предположений, не обесценивая реальную опасность и границы.",
        TechniqueId.WorryTime => english ? "it helps you note a hypothetical worry and choose when to revisit it instead of trying to suppress it." : "она помогает записать тревогу о будущем и выбрать время вернуться к ней, не подавляя мысль.",
        TechniqueId.ImplementationIntention => english ? "it links a clear cue to one small action you choose, with a backup if you get stuck." : "она связывает понятный сигнал с выбранным небольшим действием и запасным шагом на случай, если вы застрянете.",
        TechniqueId.BusyMind => english ? "it offers a brief temporary shift of attention; it does not remove thoughts or solve the problem." : "она ненадолго переключает внимание, но не убирает мысли и не решает проблему.",
        TechniqueId.Paper => english ? "it helps put a looping thought outside your head so you can look at it." : "она помогает вынести повторяющуюся мысль из головы, чтобы посмотреть на неё со стороны.",
        TechniqueId.MuscleRelax => english ? "it helps notice and release muscle tension; skip any painful area." : "она помогает заметить и отпустить мышечное напряжение; болезненные участки можно не напрягать.",
        TechniqueId.Spin => english ? "it lowers the emotional charge of a painful memory." : "она снижает эмоциональный заряд болезненного воспоминания.",
        TechniqueId.SelfCompassion => english ? "it helps you treat yourself the way you would treat a friend." : "она помогает поддержать себя так, как вы поддержали бы друга.",
        TechniqueId.SmallStep => english ? "it helps you choose one safe, meaningful activity and shrink the start to a doable step." : "она помогает выбрать безопасное значимое занятие и уменьшить начало до посильного шага.",
        TechniqueId.Anchor => english ? "it invites you to recall an experience of support; its effect varies." : "она предлагает вспомнить опыт поддержки; отклик у каждого свой.",
        TechniqueId.BodyScan => english ? "it helps you notice where the feeling sits in the body and let the tension ease." : "она помогает заметить, где в теле живёт чувство, и дать напряжению смягчиться.",
        TechniqueId.Flashback => english ? "it brings you back from a hard memory to the present, about 3 minutes." : "она возвращает из тяжёлого воспоминания в настоящее, около 3 минут.",
        TechniqueId.Nightmare => english ? "it makes a recurring nightmare rarer and weaker." : "она делает повторяющийся кошмар реже и слабее.",
        _ => string.Empty
    };

    private static string ThemeWith(CompanionTheme theme, bool english) => theme switch
    {
        CompanionTheme.Work => english ? "work" : "работой",
        CompanionTheme.Relationships => english ? "relationships" : "отношениями",
        CompanionTheme.Family => english ? "family" : "семьёй",
        CompanionTheme.Health => english ? "health" : "здоровьем",
        CompanionTheme.Money => english ? "money" : "деньгами",
        _ => english ? "study" : "учёбой"
    };

    private static string[] ReflectionLines(CompanionEmotion emotion, bool english) => emotion switch
    {
        CompanionEmotion.Panic => english
            ? ["It sounds like panic is washing over you right now. It is a very hard state, but it passes, and you are not alone in it.", "It sounds like everything inside has tightened up with panic. Let's help your body settle first."]
            : ["Похоже, вас сейчас накрывает паника. Это очень тяжёлое состояние, но оно проходит, и вы не одни в этом.", "Звучит так, будто внутри всё сжалось от паники. Давайте сначала поможем телу успокоиться."],
        CompanionEmotion.Anxiety => english
            ? ["It sounds like this situation worries you a lot. Anxiety takes a lot of energy.", "I hear that you feel uneasy and on edge. That is an understandable reaction."]
            : ["Похоже, вас сильно тревожит эта ситуация. Тревога забирает много сил.", "Слышу, что вам тревожно и неспокойно. Это понятная реакция на такую ситуацию."],
        CompanionEmotion.Overthinking => english
            ? ["It sounds like your thoughts keep going in circles and give you no rest. That is exhausting.", "I hear that the same thought keeps coming back again and again."]
            : ["Похоже, мысли крутятся по кругу и не дают передышки. Это очень выматывает.", "Слышу, что одна и та же мысль возвращается снова и снова."],
        CompanionEmotion.Anger => english
            ? ["I hear that you're angry, and that makes sense. Anger often shows that something important was touched.", "It sounds like this really got to you and made you angry."]
            : ["Слышу, что вы злитесь, и это можно понять. Злость часто показывает, что задели что-то важное.", "Похоже, эта ситуация сильно вас задела и разозлила."],
        CompanionEmotion.Resentment => english
            ? ["It sounds like you feel really hurt. When someone touches you like that, it truly hurts.", "I hear hurt in your words. That feeling has a right to be here."]
            : ["Похоже, вам очень обидно. Когда задевают, это правда больно.", "Слышу обиду в ваших словах. Это чувство имеет право быть."],
        CompanionEmotion.Guilt => english
            ? ["It sounds like guilt is weighing on you. That is a heavy load.", "I hear that you are being very hard on yourself right now."]
            : ["Похоже, вас гложет чувство вины. Это тяжёлый груз.", "Слышу, что вы сейчас очень строги к себе."],
        CompanionEmotion.Sadness => english
            ? ["I'm sorry you feel so sad right now. It is important not to push this feeling away.", "I hear heaviness and sorrow in your words."]
            : ["Мне жаль, что вам сейчас так грустно. Это состояние важно не отталкивать.", "Слышу тоску и тяжесть в ваших словах."],
        CompanionEmotion.Exhaustion => english
            ? ["It sounds like you are very tired and have almost no energy left. That is a serious signal to take care of yourself.", "I hear that you are worn out. Exhaustion deserves to be taken seriously too."]
            : ["Похоже, вы очень устали, и сил почти не осталось. Это серьёзный сигнал беречь себя.", "Слышу, что вы измотаны. Усталость тоже нужно принимать всерьёз."],
        CompanionEmotion.Loneliness => english
            ? ["I'm sorry you feel lonely. That is a very hard feeling.", "I hear loneliness in your words. It matters that you told me."]
            : ["Мне жаль, что вы чувствуете себя одиноко. Это очень тяжёлое чувство.", "Слышу одиночество в ваших словах. Хорошо, что вы об этом рассказали."],
        CompanionEmotion.Procrastination => english
            ? ["It sounds like it is hard to get started, and that weighs on you. It happens when a task feels too big.", "I hear that things are stuck and you are blaming yourself for it. That is very common."]
            : ["Похоже, вам трудно начать, и это давит. Так бывает, когда задача кажется слишком большой.", "Слышу, что дело стоит, а вы себя за это ругаете. Это очень частая ситуация."],
        _ => english
            ? ["Thank you for telling me. It sounds like this matters to you."]
            : ["Спасибо, что рассказали. Похоже, это для вас важно."]
    };

    private static string Pick(Random random, string[] variants) =>
        variants.Length == 1 ? variants[0] : variants[random.Next(variants.Length)];
}
