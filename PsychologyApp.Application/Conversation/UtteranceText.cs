namespace PsychologyApp.Application.Conversation;

/// <summary>
/// How a person's message is read before matching: lower case, ё as е, apostrophes dropped ("don't" is "dont"), every
/// other non-letter a single space. The crisis check and the situation analyzer share it, so a phrase one of them
/// matches cannot be split differently for the other.
/// </summary>
internal static class UtteranceText
{
    private static readonly string[] HarmVerbPrefixes =
    [
        "hurt", "harm", "hit", "punch", "attack", "kill", "strangl", "chok", "suffocat", "stab", "shoot", "shot", "kick", "slap", "beat", "push", "shov", "bite", "bit", "smack", "strik", "struck", "throw", "threw", "hurl", "toss", "burn", "poison", "drown", "drug", "rape", "torture", "wound", "injur", "maim", "abus", "assault",
        "удар", "бь", "изб", "изоб", "уби", "убей", "убью", "застрел", "пристрел", "навреди", "навред", "причини", "причин", "задуш", "душ", "пореж", "зарез", "толк", "швыр", "укус", "укуш", "пну", "отрав", "утоп", "изнасил", "пыт",
        "matar", "golpe", "peg", "lastim", "apuñal", "estrangul", "dispar", "atac", "agred", "herir",
        "bless", "frapp", "tuer", "attaqu", "étrangl", "etrangl", "poignard", "agress", "batt", "tirer",
        "schlag", "töt", "toet", "umbring", "verletz", "angreif", "würg", "wuerg", "erstech", "erschieß", "erschiess", "verprüg", "verprueg",
        "machuc", "ferir", "bater", "esfaque", "atirar"
    ];

    private static readonly HashSet<string> EnglishHumanOrAnimalTargets = new(StringComparer.Ordinal)
    {
        "someone", "somebody", "anyone", "anybody", "everyone", "everybody", "person", "persons", "people", "him", "her", "them", "you", "man", "men", "woman", "women", "boy", "boys", "girl", "girls",
        "child", "children", "kid", "kids", "baby", "babies", "toddler", "toddlers", "partner", "partners", "spouse", "spouses", "wife", "wives", "husband", "husbands",
        "boyfriend", "boyfriends", "girlfriend", "girlfriends", "friend", "friends", "ex", "boss", "bosses", "coworker", "coworkers", "colleague", "colleagues",
        "classmate", "classmates", "supervisor", "supervisors", "manager", "managers", "employee", "employees", "neighbor", "neighbors", "roommate", "roommates",
        "parent", "parents", "mother", "mothers", "father", "fathers", "mom", "moms", "dad", "dads", "son", "sons", "daughter", "daughters", "brother", "brothers",
        "sister", "sisters", "teacher", "teachers", "student", "students", "patient", "patients", "stranger", "strangers", "family", "families", "animal", "animals",
        "pet", "pets", "dog", "dogs", "cat", "cats"
    };

    private static readonly string[] RussianHumanOrAnimalTargetPrefixes =
    [
        "кого", "кому", "какого", "человек", "люд", "муж", "жен", "ребен", "сын", "доч",
        "партнер", "партнерш", "друг", "подруг", "началь", "коллег", "сосед", "мам", "пап", "отц", "мать", "матер", "брат", "сестр",
        "учител", "ученик", "собак", "кошк", "питом"
    ];

    private static readonly string[] OtherLanguageHumanOrAnimalTargetPrefixes =
    [
        "alguien", "persona", "personas", "hombre", "mujer", "niñ", "nino", "amigo", "amiga", "pareja", "compañer", "companero", "vecin", "animal", "perro", "gato",
        "quelquun", "quelquune", "homme", "femme", "enfant", "ami", "amie", "copain", "copine", "partenaire", "voisin", "voisine", "animal", "chien", "chat",
        "jemand", "mensch", "menschen", "mann", "frau", "kind", "freund", "partner", "nachbar", "kolleg", "tier", "hund", "katze",
        "alguém", "alguem", "pessoa", "homem", "mulher", "criança", "crianca", "amigo", "amiga", "parceir", "vizinh", "animal", "cachorro", "cão", "cao", "gato"
    ];

    private static readonly HashSet<string> PreposedHumanObjectPronouns = new(StringComparer.Ordinal)
    {
        "jemand", "jemanden", "jemandem", "jemandens", "ihn", "ihnen", "sie", "euch", "dich", "ihm", "ihr",
        "le", "la", "les", "lui", "leur", "te", "toi", "vous", "nous", "eux", "elle", "elles", "ils"
    };

    private static readonly string[] SpanishHarmVerbPrefixes =
    [
        "matar", "golpe", "peg", "lastim", "apuñal", "estrangul", "dispar", "atac", "agred", "herir"
    ];

    private static readonly string[] SpanishObjectClitics =
    [
        "me", "te", "lo", "la", "los", "las", "le", "les", "nos", "os", "se"
    ];

    private static readonly HashSet<string> SpanishObjectArticles = new(StringComparer.Ordinal)
    {
        "el", "la", "los", "las", "un", "una", "unos", "unas"
    };

    private static readonly HashSet<string> RussianExactHumanOrAnimalTargets = new(StringComparer.Ordinal)
    {
        "ты", "вы", "его", "ее", "их", "него", "нему", "ним", "ему", "ей", "тебя", "тебе", "тобой", "вас", "вам", "вами",
        "всех", "всем", "всеми", "каждого", "каждому", "каждой", "каждым"
    };

    private static readonly HashSet<string> RussianPreposedObjectPronouns = new(StringComparer.Ordinal)
    {
        "его", "ее", "их", "него", "нему", "ним", "ему", "ей", "тебя", "тебе", "тобой", "вас", "вам", "вами", "всех", "всем", "всеми"
    };

    private static readonly HashSet<string> HarmIntentCueWords = new(StringComparer.Ordinal)
    {
        "want", "wants", "wanted", "wanna", "like", "likes", "wish", "wishes", "might", "may", "could", "can", "will", "going", "gonna", "afraid", "scared", "fear", "worried", "worry", "urge", "tempted",
        "thinking", "considering", "planning", "plan", "intend", "intends", "intending", "intended", "ready", "need", "needs", "needed", "must", "хочу", "хотел", "хотела", "хотелось", "хочется", "могу", "может", "мог", "могла",
        "надо", "нужно", "должен", "должна", "должно", "должны", "обязан", "обязана", "обязаны", "боюсь", "страшно", "опасаюсь", "тянет", "собираюсь", "планирую", "план", "думаю", "подумываю", "готов", "готова", "сорвусь",
        "quiero", "quisiera", "podría", "podria", "puedo", "voy", "planeo", "pienso", "pretendo",
        "veux", "voudrais", "pourrais", "peux", "vais", "pense", "prévois", "prevois",
        "könnte", "koennte", "kann", "wollte", "werde", "plane", "denke",
        "quero", "queria", "poderia", "posso", "vou", "planejo", "penso"
    };

    private static readonly HashSet<string> HarmIntentNegations = new(StringComparer.Ordinal)
    {
        "not", "dont", "didnt", "doesnt", "isnt", "wasnt", "werent", "havent", "hasnt", "hadnt", "wouldnt", "shouldnt", "mustnt",
        "never", "не", "ни", "никогда", "no", "ne", "pas", "nicht", "não", "nao"
    };

    private static readonly HashSet<string> HarmIntentNegationModifiers = new(StringComparer.Ordinal)
    {
        "really", "actually", "ever", "even", "genuinely", "truly", "очень", "особо", "совсем", "больше"
    };

    private static readonly HashSet<string> FigurativeHarmObjects = new(StringComparer.Ordinal)
    {
        "feelings", "pride", "reputation", "ego", "heart", "confidence", "image", "trust", "emotions", "emotionally", "mentally", "psychologically",
        "чувствам", "чувства", "чувство", "гордость", "репутацию", "репутации", "самооценку"
    };

    private static readonly HashSet<string> FirstPersonHarmVerbForms = new(StringComparer.Ordinal)
    {
        "ударю", "изобью", "убью", "застрелю", "пристрелю", "наврежу", "причиню", "задушу", "порежу", "зарежу", "толкну", "швырну", "укушу", "пну"
    };

    private static readonly HashSet<string> IrregularPastHarmVerbForms = new(StringComparer.Ordinal)
    {
        "shot", "struck", "bit", "threw"
    };

    private static readonly HashSet<string> PastTimeMarkers = new(StringComparer.Ordinal)
    {
        "yesterday", "last", "ago", "earlier", "previously", "once", "вчера", "позавчера", "раньше", "давно", "тогда",
        "ayer", "hier", "gestern", "früher", "frueher", "ontem"
    };

    private static readonly HashSet<string> CompetitiveActivities = new(StringComparer.Ordinal)
    {
        "chess", "tennis", "football", "soccer", "basketball", "baseball", "golf", "cards", "poker", "sports", "race", "racing", "game", "games", "competition", "contest", "debate", "election", "vote", "record", "score", "level"
    };

    private static readonly HashSet<string> NonviolentThrowObjects = new(StringComparer.Ordinal)
    {
        "ball", "bone", "lifeline", "party", "look", "text", "message", "email", "note", "question", "idea", "suggestion", "line", "invite", "link", "copy", "reminder", "dm",
        "enlace", "vínculo", "vinculo", "url", "foto", "imagen", "beso", "mensaje", "texto", "nota", "etiqueta", "pegatina"
    };

    private static readonly HashSet<string> NonviolentPushActions = new(StringComparer.Ordinal)
    {
        "apply", "accept", "admit", "apologize", "change", "consider", "decide", "do", "exercise", "finish", "follow", "get", "go", "help", "improve", "lose", "make", "participate", "practice", "respond", "stay", "study", "succeed", "take", "talk", "tell", "try", "work"
    };

    private static readonly HashSet<string> HarmObjectIntroducers = new(StringComparer.Ordinal)
    {
        "my", "your", "his", "her", "their", "our", "the", "a", "an", "another", "this", "that", "these", "those", "some", "to",
        "den", "die", "das", "einen", "eine", "einem", "a", "al", "em",
        "моего", "мою", "моему", "моей", "моих", "своего", "свою", "своему", "его", "ее", "их", "этого", "эту", "этот", "одного", "одну", "по", "в"
    };

    public static string Normalize(string text)
    {
        char[] chars = text.ToLowerInvariant()
            .Replace("i'll", "i will", StringComparison.Ordinal)
            .Replace("i’ll", "i will", StringComparison.Ordinal)
            .Replace('ё', 'е')
            .Replace("'", string.Empty)
            .Replace("’", string.Empty)
            .Select(c => char.IsLetterOrDigit(c) ? c : ' ')
            .ToArray();
        return string.Join(' ', new string(chars).Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }

    /// <summary>Finds a harm verb with a nearby human or animal object; this is a conservative safety cue, not intent assessment.</summary>
    public static bool MentionsHarmToAnother(string[] tokens)
    {
        for (int i = 0; i < tokens.Length; i++)
        {
            if (IsHarmVerb(tokens[i]) && HasLiteralHumanOrAnimalObject(tokens, i))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>Routes explicit or feared intent to harm another person to safety support; bare reports are not intent.</summary>
    public static bool IndicatesIntentToHarmAnother(string[] tokens)
    {
        for (int i = 0; i < tokens.Length; i++)
        {
            if (!IsHarmVerb(tokens[i]) || !HasLiteralHumanOrAnimalObject(tokens, i))
            {
                continue;
            }

            if (FirstPersonHarmVerbForms.Contains(tokens[i]) && (i == 0 || !HarmIntentNegations.Contains(tokens[i - 1])))
            {
                return true;
            }

            if (HasDoubleNegatedHarmCue(tokens, i))
            {
                return true;
            }

            if (i == 0 && !LooksLikePastReport(tokens, i))
            {
                return true;
            }

            if (HasLossOfControlCue(tokens, i))
            {
                return true;
            }

            for (int cue = Math.Max(0, i - 4); cue < i; cue++)
            {
                if (HarmIntentCueWords.Contains(tokens[cue]) && !IsNegatedHarmCue(tokens, cue, i))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool HasDoubleNegatedHarmCue(string[] tokens, int verbIndex)
    {
        for (int i = Math.Max(0, verbIndex - 5); i < verbIndex; i++)
        {
            if ((tokens[i] is "cant" or "cannot" or "couldnt") && i + 1 < verbIndex && tokens[i + 1] == "not")
            {
                return true;
            }

            if ((tokens[i] is "cant" or "cannot" or "couldnt") && i + 2 < verbIndex
                && tokens[i + 1] == "help" && tokens[i + 2] == "but")
            {
                return true;
            }

            if (tokens[i] == "не" && i + 2 < verbIndex
                && (tokens[i + 1] is "могу" or "мог" or "могла" or "могли" or "смогу" or "смог" or "смогла" or "смогли" or "может")
                && tokens[i + 2] == "не")
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsHarmVerb(string token) =>
        HarmVerbPrefixes.Any(prefix => token.StartsWith(prefix, StringComparison.Ordinal));

    private static bool HasLiteralHumanOrAnimalObject(string[] tokens, int verbIndex)
    {
        if (IsObviousNonviolentHarmUsage(tokens, verbIndex))
        {
            return false;
        }

        int next = verbIndex + 1;
        if (IsLiteralPersonOrAnimalObject(tokens, next))
        {
            return true;
        }

        if (next + 1 < tokens.Length && HarmObjectIntroducers.Contains(tokens[next]) && IsLiteralPersonOrAnimalObject(tokens, next + 1))
        {
            return true;
        }

        if (verbIndex > 0 && PreposedHumanObjectPronouns.Contains(tokens[verbIndex - 1]))
        {
            return true;
        }

        string verb = tokens[verbIndex];
        if (SpanishHarmVerbPrefixes.Any(prefix => verb.StartsWith(prefix, StringComparison.Ordinal))
            && SpanishObjectClitics.Any(clitic => verb.Length > clitic.Length && verb.EndsWith(clitic, StringComparison.Ordinal)))
        {
            return true;
        }

        if (tokens[verbIndex].StartsWith("причини", StringComparison.Ordinal) && next + 1 < tokens.Length && tokens[next] == "вред"
            && (IsLiteralPersonOrAnimalObject(tokens, next + 1) || (next + 2 < tokens.Length && HarmObjectIntroducers.Contains(tokens[next + 1]) && IsLiteralPersonOrAnimalObject(tokens, next + 2))))
        {
            return true;
        }

        if (tokens[verbIndex].StartsWith("beat", StringComparison.Ordinal) && next + 1 < tokens.Length && tokens[next] == "up"
            && (IsLiteralPersonOrAnimalObject(tokens, next + 1) || (next + 2 < tokens.Length && HarmObjectIntroducers.Contains(tokens[next + 1]) && IsLiteralPersonOrAnimalObject(tokens, next + 2))))
        {
            return true;
        }

        if ((tokens[verbIndex].StartsWith("shoot", StringComparison.Ordinal) || tokens[verbIndex].StartsWith("shot", StringComparison.Ordinal))
            && next + 1 < tokens.Length && tokens[next] == "at"
            && (IsLiteralPersonOrAnimalObject(tokens, next + 1) || (next + 2 < tokens.Length && HarmObjectIntroducers.Contains(tokens[next + 1]) && IsLiteralPersonOrAnimalObject(tokens, next + 2))))
        {
            return true;
        }

        if (verbIndex > 0 && RussianPreposedObjectPronouns.Contains(tokens[verbIndex - 1]))
        {
            return true;
        }

        return IsThrownObjectAtPerson(tokens, verbIndex);
    }

    /// <summary>Filters common idioms that otherwise look like a literal assault in the short-window matcher.</summary>
    private static bool IsObviousNonviolentHarmUsage(string[] tokens, int verbIndex)
    {
        if (tokens[verbIndex].StartsWith("peg", StringComparison.Ordinal)
            && HasNonviolentSpanishPegarObject(tokens, verbIndex))
        {
            return true;
        }

        int targetIndex = verbIndex + 1;
        if (targetIndex < tokens.Length && !IsHumanOrAnimalTargetAt(tokens, targetIndex) && HarmObjectIntroducers.Contains(tokens[targetIndex]))
        {
            targetIndex++;
        }

        if (!IsHumanOrAnimalTargetAt(tokens, targetIndex))
        {
            return false;
        }

        string verb = tokens[verbIndex];
        int afterTarget = targetIndex + 1;
        if (verb.StartsWith("beat", StringComparison.Ordinal)
            && afterTarget < tokens.Length
            && (((tokens[afterTarget] is "at" or "in") && tokens.Skip(afterTarget + 1).Take(4).Any(CompetitiveActivities.Contains))
                || (tokens[afterTarget] == "to" && afterTarget + 1 < tokens.Length && tokens[afterTarget + 1] == "the"
                    && afterTarget + 2 < tokens.Length && tokens[afterTarget + 2] == "punch")))
        {
            return true;
        }

        if (verb.StartsWith("hit", StringComparison.Ordinal) && afterTarget < tokens.Length && tokens[afterTarget] == "up")
        {
            return true;
        }

        if (verb.StartsWith("kick", StringComparison.Ordinal) && afterTarget < tokens.Length && tokens[afterTarget] == "out")
        {
            return true;
        }

        if (verb.StartsWith("push", StringComparison.Ordinal) && afterTarget + 1 < tokens.Length
            && tokens[afterTarget] == "to" && NonviolentPushActions.Contains(tokens[afterTarget + 1]))
        {
            return true;
        }

        if ((verb.StartsWith("throw", StringComparison.Ordinal) || verb.StartsWith("threw", StringComparison.Ordinal)
                || verb.StartsWith("toss", StringComparison.Ordinal))
            && afterTarget + 1 < tokens.Length
            && HarmObjectIntroducers.Contains(tokens[afterTarget])
            && NonviolentThrowObjects.Contains(tokens[afterTarget + 1]))
        {
            return true;
        }

        if ((verb.StartsWith("shoot", StringComparison.Ordinal) || verb.StartsWith("shot", StringComparison.Ordinal))
            && afterTarget + 1 < tokens.Length
            && HarmObjectIntroducers.Contains(tokens[afterTarget])
            && NonviolentThrowObjects.Contains(tokens[afterTarget + 1]))
        {
            return true;
        }

        return false;
    }

    private static bool HasNonviolentSpanishPegarObject(string[] tokens, int verbIndex)
    {
        int objectIndex = verbIndex + 1;
        if (objectIndex < tokens.Length && SpanishObjectArticles.Contains(tokens[objectIndex]))
        {
            objectIndex++;
        }

        return objectIndex < tokens.Length && NonviolentThrowObjects.Contains(tokens[objectIndex]);
    }

    private static bool IsHumanOrAnimalTargetAt(string[] tokens, int index) =>
        index < tokens.Length && IsHumanOrAnimalTarget(tokens[index]);

    private static bool LooksLikePastReport(string[] tokens, int verbIndex)
    {
        string verb = tokens[verbIndex];
        if (IrregularPastHarmVerbForms.Contains(verb)
            || verb.EndsWith("ed", StringComparison.Ordinal)
            || verb.EndsWith("л", StringComparison.Ordinal)
            || verb.EndsWith("ла", StringComparison.Ordinal)
            || verb.EndsWith("ло", StringComparison.Ordinal)
            || verb.EndsWith("ли", StringComparison.Ordinal))
        {
            return true;
        }

        return tokens.Skip(verbIndex + 1).Take(6).Any(token =>
            PastTimeMarkers.Contains(token) || token.StartsWith("прошл", StringComparison.Ordinal));
    }

    private static bool IsThrownObjectAtPerson(string[] tokens, int verbIndex)
    {
        if (!tokens[verbIndex].StartsWith("throw", StringComparison.Ordinal) && !tokens[verbIndex].StartsWith("threw", StringComparison.Ordinal)
            && !tokens[verbIndex].StartsWith("hurl", StringComparison.Ordinal) && !tokens[verbIndex].StartsWith("toss", StringComparison.Ordinal))
        {
            return false;
        }

        // A thrown object only counts as an assault cue when it is directed at a person or animal.
        int limit = Math.Min(tokens.Length - 1, verbIndex + 5);
        for (int i = verbIndex + 1; i < limit; i++)
        {
            if (tokens[i] is "at" or "toward" or "towards")
            {
                return IsLiteralPersonOrAnimalObject(tokens, i + 1)
                    || (i + 2 < tokens.Length && HarmObjectIntroducers.Contains(tokens[i + 1]) && IsLiteralPersonOrAnimalObject(tokens, i + 2));
            }
        }

        return false;
    }

    private static bool IsNegatedHarmCue(string[] tokens, int cueIndex, int verbIndex)
    {
        for (int i = cueIndex - 1, examined = 0; i >= 0 && examined <= 2; i--, examined++)
        {
            if (HarmIntentNegations.Contains(tokens[i]))
            {
                return true;
            }

            if (!HarmIntentNegationModifiers.Contains(tokens[i]))
            {
                break;
            }
        }

        for (int i = cueIndex + 1; i < verbIndex; i++)
        {
            if (HarmIntentNegations.Contains(tokens[i]))
            {
                bool contrastiveContinuation = tokens.Skip(i + 1).Take(verbIndex - i - 1)
                    .Any(token => token is "but" or "а" or "но");
                if (contrastiveContinuation)
                {
                    continue;
                }

                return true;
            }
        }

        return false;
    }

    private static bool HasLossOfControlCue(string[] tokens, int verbIndex)
    {
        int start = Math.Max(0, verbIndex - 5);
        for (int i = start; i < verbIndex; i++)
        {
            if ((tokens[i] is "cant" or "cannot") && i + 2 < verbIndex
                && (tokens[i + 1] is "stop" or "control" or "trust") && tokens[i + 2] == "myself")
            {
                return true;
            }

            if (tokens[i] == "не" && i + 1 < verbIndex && (tokens[i + 1] is "сдержусь" or "удержусь"))
            {
                return true;
            }

            if (tokens[i] == "не" && i + 3 < verbIndex && tokens[i + 1] == "могу" && tokens[i + 2] == "себя"
                && (tokens[i + 3] is "сдержать" or "остановить"))
            {
                return true;
            }
        }

        // Fear of losing control may come after the harm phrase: "I don't want to hurt anyone, but I can't control myself".
        int end = Math.Min(tokens.Length, verbIndex + 9);
        for (int i = verbIndex + 1; i < end; i++)
        {
            if ((tokens[i] is "cant" or "cannot") && i + 2 < end
                && (tokens[i + 1] is "stop" or "control" or "trust") && tokens[i + 2] == "myself")
            {
                return true;
            }

            if (tokens[i] == "не" && i + 1 < end && (tokens[i + 1] is "сдержусь" or "удержусь"))
            {
                return true;
            }

            if (tokens[i] == "не" && i + 3 < end && tokens[i + 1] == "могу" && tokens[i + 2] == "себя"
                && (tokens[i + 3] is "сдержать" or "остановить"))
            {
                return true;
            }

            if (tokens[i] is "afraid" or "scared" or "worried" or "terrified" or "боюсь" or "страшно")
            {
                int cueEnd = Math.Min(end, i + 8);
                bool lossOfControl = false;
                for (int cue = i + 1; cue < cueEnd; cue++)
                {
                    lossOfControl |= (tokens[cue] is "lose" or "losing" or "lost")
                        && cue + 1 < cueEnd && tokens[cue + 1] == "control";
                    lossOfControl |= (tokens[cue] is "потерять" or "теряю")
                        && cue + 1 < cueEnd && tokens[cue + 1] == "контроль";
                    lossOfControl |= tokens[cue] is "сдержаться" or "удержаться" or "сорваться" or "сорвусь";
                }

                if (lossOfControl)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private static bool IsRussianHumanOrAnimalTarget(string token) =>
        RussianExactHumanOrAnimalTargets.Contains(token) ||
        RussianHumanOrAnimalTargetPrefixes.Any(prefix => token.StartsWith(prefix, StringComparison.Ordinal));

    private static bool IsHumanOrAnimalTarget(string token) =>
        EnglishHumanOrAnimalTargets.Contains(token)
        || IsRussianHumanOrAnimalTarget(token)
        || OtherLanguageHumanOrAnimalTargetPrefixes.Any(prefix => token.StartsWith(prefix, StringComparison.Ordinal));

    private static bool IsLiteralPersonOrAnimalObject(string[] tokens, int index)
    {
        if (index >= tokens.Length || !IsHumanOrAnimalTarget(tokens[index]))
        {
            return false;
        }

        int next = index + 1;
        if (next < tokens.Length && FigurativeHarmObjects.Contains(tokens[next]))
        {
            return false;
        }

        return next + 1 >= tokens.Length || tokens[next] != "s" || !FigurativeHarmObjects.Contains(tokens[next + 1]);
    }
}
