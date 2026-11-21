using PsychologyApp.Application.Articles;
using PsychologyApp.Application.Conversation;
using PsychologyApp.Application.Conversation.Companion;

namespace PsychologyApp.Application.Chat;

/// <summary>
/// Guided exercises inside the chat. The companion does not only point to a practice: it can walk through checking a thought
/// (cognitive restructuring: belief, facts for and against, what you would tell a friend, a fairer wording, belief again) or solving a
/// problem (the task, options, the most doable one, the first step and when), one question at a time. A step decided on is remembered and
/// asked about in the next chat. Crisis words are checked before any of this, as everywhere.
/// </summary>
public sealed partial class CompanionDialogue
{
    private const int MaxProtocolNote = 300;
    private static readonly string[] StopCommands =
    [
        "стоп", "хватит", "не хочу", "не хочу продолжать", "давай не будем", "остановиться", "давай остановимся", "давай закончим", "отмена", "отменить",
        "stop", "enough", "not now", "dont want", "dont want to continue", "lets stop", "cancel", "end"
    ];

    private static readonly string[] StopCommandPhrases =
    [
        "не хочу продолжать упражнение", "не хочу проходить упражнение", "не хочу отвечать на этот вопрос", "не хочу отвечать на вопросы", "не хочу это упражнение",
        "стоп пожалуйста", "хватит пожалуйста", "давай не будем продолжать упражнение", "давай остановимся здесь", "давай закончим упражнение", "останови упражнение", "остановите упражнение", "остановить упражнение", "останови это", "отмени это", "прерви упражнение", "прервать упражнение", "прекрати упражнение", "прекрати это", "прекратить упражнение", "пропустить упражнение",
        "пропустить вопрос", "пропустить этот вопрос", "этот вопрос пропущу",
        "stop please", "cancel please", "lets stop here", "lets stop the exercise", "not now", "stop this exercise", "stop the exercise", "end this exercise", "end the exercise", "skip this exercise", "skip this question", "cancel this exercise", "cancel the exercise",
        "skip this question", "skip the question", "i dont want to continue this exercise", "i dont want to continue the exercise", "i dont want to answer this question",
        "i want to stop this exercise", "i need to stop this exercise", "lets stop this exercise"
    ];

    private static bool IsProtocolStopRequest(string text)
    {
        string lowered = text.Trim().ToLowerInvariant().Replace('ё', 'е')
            .Replace("'", string.Empty, StringComparison.Ordinal)
            .Replace("’", string.Empty, StringComparison.Ordinal);
        string words = string.Concat(lowered.Select(character => char.IsLetterOrDigit(character) || char.IsWhiteSpace(character) ? character : ' '));
        string normalized = string.Join(" ", words.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries));

        return StopCommands.Any(command => normalized == command)
            || StopCommandPhrases.Any(command => normalized == command || normalized.StartsWith(command + " ", StringComparison.Ordinal));
    }

    /// <summary>Checking a thought fits feelings driven by a thought; problem solving fits a situation that can be acted on.</summary>
    private string? FittingProtocol(CompanionState state, SituationAnalysis analysis, CompanionEmotion emotion)
    {
        if (state.ProtocolOffered || analysis.IsFlashback || analysis.HasLoss || state.GriefShared || emotion == CompanionEmotion.Panic)
        {
            return null;
        }

        // After a hard event was mentioned, the beliefs it left matter more than one passing thought.
        if (state.TraumaAcknowledged)
        {
            return CompanionTraumaContent.Impact;
        }

        // A quarrel, too much work or a lost job ask for a plan; fear of an exam, a failure or a betrayal mostly live in what one tells oneself.
        bool actionable = Enum.TryParse(state.Event, out CompanionEvent happened)
            && Enum.IsDefined(happened)
            && happened is CompanionEvent.Conflict or CompanionEvent.Overload or CompanionEvent.JobLoss;
        if (emotion == CompanionEmotion.Procrastination || (actionable && emotion is not (CompanionEmotion.Guilt or CompanionEmotion.Overthinking)))
        {
            return CompanionProtocolContent.Solve;
        }

        return emotion is CompanionEmotion.Anxiety or CompanionEmotion.Overthinking or CompanionEmotion.Guilt or CompanionEmotion.Sadness or CompanionEmotion.Resentment
            ? CompanionProtocolContent.Think
            : null;
    }

    /// <summary>Extra chips for an offer: a guided exercise, a questionnaire when heavy days keep coming back, an article. Each once per chat.</summary>
    private CompanionState AddGuidedOffers(CompanionState state, List<string> messages, List<ChatQuickReply> quick, SituationAnalysis analysis, CompanionEmotion emotion)
    {
        if (FittingProtocol(state, analysis, emotion) is { } protocol)
        {
            quick.Add(protocol switch
            {
                CompanionProtocolContent.Think => CompanionProtocolContent.ThinkChip(english),
                CompanionTraumaContent.Impact => CompanionTraumaContent.Choices(english)[0],
                _ => CompanionProtocolContent.SolveChip(english)
            });
            // Guilt, sadness and loneliness often rest on a thought about oneself: next to checking the thought, the person may look at what lies under it.
            if (protocol == CompanionProtocolContent.Think && emotion is CompanionEmotion.Guilt or CompanionEmotion.Sadness or CompanionEmotion.Loneliness)
            {
                quick.Add(CompanionProtocolContent.DeeperChip(english));
            }

            state = state with { ProtocolOffered = true };
        }

        if (!state.TestSuggested && _recentHeavyChats >= HeavyChatsForTest
            && CompanionProtocolContent.TestFor(emotion, analysis.IsFlashback) is { } testId && !_recentlyTakenTests.Contains(testId))
        {
            string name = CompanionProtocolContent.TestName(testId);
            messages.Add(CompanionProtocolContent.TestNudge(name, english));
            quick.Add(CompanionProtocolContent.TestNudgeChip(testId, name, english));
            state = state with { TestSuggested = true };
        }

        // In panic the fewer choices the better, and the body article is already offered with the somatic chip.
        if (!state.ArticleOffered && emotion != CompanionEmotion.Panic && CompanionProtocolContent.ArticleFor(emotion, analysis.IsFlashback) is { } articleId
            && ArticleContent.Find(articleId, english ? "en" : "ru") is { } article)
        {
            quick.Add(CompanionProtocolContent.ArticleChip(article, english));
            state = state with { ArticleOffered = true };
        }

        return state;
    }

    private CompanionReply StartProtocol(CompanionState state, string protocol, CompanionEmotion emotion, CompanionTheme? theme)
    {
        if (!CompanionState.HasValidProtocolState(protocol, step: 0, belief: null))
        {
            return CompanionReply.Empty(state);
        }

        return AskProtocol(state with
        {
            Protocol = protocol,
            ProtocolStep = 0,
            ProtocolNotes = [],
            ProtocolBelief = null,
            ProtocolOffered = true,
            TurnsSinceOffer = 0,
            LastQuestion = null,
            LastQuestionId = null,
            QuestionPending = false,
            OfferedPrimary = null,
            OfferedAlternative = null
        }, emotion, theme);
    }

    private CompanionReply AskProtocol(CompanionState state, CompanionEmotion emotion, CompanionTheme? theme)
    {
        if (IsTraumaProtocol(state))
        {
            return AskTrauma(state, emotion, theme);
        }

        bool think = state.Protocol == CompanionProtocolContent.Think;
        string question = state.Protocol switch
        {
            CompanionProtocolContent.Think => CompanionProtocolContent.ThinkQuestion(state.ProtocolStep, english),
            CompanionProtocolContent.Deeper => CompanionProtocolContent.DeeperQuestion(state.ProtocolStep, english),
            _ => CompanionProtocolContent.SolveQuestion(state.ProtocolStep, english)
        };
        IReadOnlyList<ChatQuickReply> chips = think && IsBeliefStep(state.ProtocolStep)
            ? [.. RatingReplies(), CompanionProtocolContent.StopChip(english)]
            : [CompanionProtocolContent.StopChip(english)];
        return Reply([question], chips, state, emotion, theme);
    }

    private static bool IsBeliefStep(int step) => step is CompanionProtocolContent.ThinkBeliefBefore or CompanionProtocolContent.ThinkBeliefAfter;

    private CompanionReply StopProtocol(CompanionState state, CompanionEmotion emotion, CompanionTheme? theme) =>
        Reply([CompanionProtocolContent.Stopped(english)], [], EndProtocol(state), emotion, theme);

    private static CompanionState EndProtocol(CompanionState state) =>
        state with
        {
            Protocol = null,
            ProtocolStep = 0,
            ProtocolNotes = [],
            ProtocolBelief = null,
            TurnsSinceOffer = 0,
            LastQuestion = null,
            LastQuestionId = null,
            QuestionPending = false,
            OfferedPrimary = null,
            OfferedAlternative = null
        };

    /// <summary>The next answer of an exercise: typed words, or a 0..10 rating (typed or tapped) on a belief step.</summary>
    private CompanionReply ContinueProtocol(CompanionState state, string? text, int? rating)
    {
        CompanionEmotion emotion = ParseEmotion(state.Emotion);
        CompanionTheme? theme = ParseTheme(state.Theme);
        string? words = text?.Trim();
        if (words is { Length: > 0 } && IsProtocolStopRequest(words))
        {
            return StopProtocol(state, emotion, theme);
        }

        if (IsTraumaProtocol(state))
        {
            return ContinueTrauma(state, words, rating, emotion, theme);
        }

        bool think = state.Protocol == CompanionProtocolContent.Think;
        if (think && IsBeliefStep(state.ProtocolStep))
        {
            if (rating is not { } belief && !(words is not null && TryParseRating(words, out belief)))
            {
                return AskProtocol(state, emotion, theme);
            }

            if (state.ProtocolStep == CompanionProtocolContent.ThinkBeliefBefore)
            {
                return AskProtocol(state with { ProtocolBelief = belief, ProtocolStep = state.ProtocolStep + 1 }, emotion, theme);
            }

            return FinishThink(state, belief, emotion, theme);
        }

        if (string.IsNullOrWhiteSpace(words))
        {
            return AskProtocol(state, emotion, theme);
        }

        CompanionState answered = state with
        {
            Turns = state.Turns + 1,
            ProtocolNotes = [.. state.ProtocolNotes, words.Length > MaxProtocolNote ? words[..MaxProtocolNote] : words],
            ProtocolStep = state.ProtocolStep + 1
        };

        return answered.Protocol switch
        {
            CompanionProtocolContent.Deeper when answered.ProtocolStep >= CompanionProtocolContent.DeeperSteps => FinishDeeper(answered, emotion, theme),
            CompanionProtocolContent.Solve when answered.ProtocolStep >= CompanionProtocolContent.SolveSteps => FinishSolve(answered, emotion, theme),
            _ => AskProtocol(answered, emotion, theme)
        };
    }

    private CompanionReply FinishThink(CompanionState state, int after, CompanionEmotion emotion, CompanionTheme? theme)
    {
        // Notes: the thought, facts for, facts against, what one would tell a friend, the fairer wording.
        IReadOnlyList<string> notes = state.ProtocolNotes;
        int before = state.ProtocolBelief ?? after;
        string summary = CompanionProtocolContent.ThinkSummary(notes.ElementAtOrDefault(0) ?? string.Empty, notes.ElementAtOrDefault(4) ?? string.Empty, before, after, english);
        List<ChatQuickReply> chips = after >= before
            ? [PracticeReply(nameof(TechniqueId.ThoughtRecord), CompanionContent.StartLabel(TechniqueId.ThoughtRecord, english))]
            : [];
        chips.Add(new ChatQuickReply(ChatQuickReplyKinds.More, CompanionContent.MoreLabel(english)));
        return Reply([summary], chips, EndProtocol(state) with { LastIntensity = state.LastIntensity }, emotion, theme);
    }

    private CompanionReply FinishDeeper(CompanionState state, CompanionEmotion emotion, CompanionTheme? theme)
    {
        // Notes: the thought, what would be hardest, what it says about oneself, what one would tell a friend, the kinder wording.
        IReadOnlyList<string> notes = state.ProtocolNotes;
        string summary = CompanionProtocolContent.DeeperSummary(
            notes.ElementAtOrDefault(0) ?? string.Empty, notes.ElementAtOrDefault(2) ?? string.Empty, notes.ElementAtOrDefault(4) ?? string.Empty, english);
        return Reply(
            [summary],
            [
                PracticeReply(nameof(TechniqueId.SelfCompassion), CompanionContent.StartLabel(TechniqueId.SelfCompassion, english)),
                new ChatQuickReply(ChatQuickReplyKinds.More, CompanionContent.MoreLabel(english))
            ],
            EndProtocol(state),
            emotion,
            theme);
    }

    private CompanionReply FinishSolve(CompanionState state, CompanionEmotion emotion, CompanionTheme? theme)
    {
        // Notes: the task, the options, the chosen one, the first step and when.
        IReadOnlyList<string> notes = state.ProtocolNotes;
        string step = notes.ElementAtOrDefault(3) ?? string.Empty;
        string summary = CompanionProtocolContent.SolveSummary(notes.ElementAtOrDefault(0) ?? string.Empty, notes.ElementAtOrDefault(2) ?? string.Empty, step, english);
        return Reply(
            [summary],
            [new ChatQuickReply(ChatQuickReplyKinds.More, CompanionContent.MoreLabel(english))],
            EndProtocol(state) with { NewPlan = ClipPlan(step) },
            emotion,
            theme);
    }

    private static string ClipPlan(string text)
    {
        string trimmed = text.Trim();
        return trimmed.Length <= CompanionProtocolContent.MaxPlanLength ? trimmed : trimmed[..CompanionProtocolContent.MaxPlanLength].TrimEnd() + "…";
    }

    private CompanionReply AnswerPlan(CompanionState state, string result, CompanionEmotion emotion, CompanionTheme? theme) =>
        Reply([CompanionProtocolContent.PlanAnswer(result, english)], [], state with { OpenPlan = null, PlanResolved = true }, emotion, theme);
}
