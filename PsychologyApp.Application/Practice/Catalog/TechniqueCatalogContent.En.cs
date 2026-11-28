using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Practice.Catalog;

internal static class TechniqueCatalogContentEn
{
    internal static TheorySection[] Theory(string what, string when, string how, string example) =>
    [
        new("What it is", what),
        new("When to try it", when),
        new("How the practice goes", how),
        new("Example", example)
    ];

    /// <summary>Common topics for a "problem" field: a start to tap and then add a word or two, not a full answer.</summary>
    private static readonly string[] ProblemTopics =
        ["A fight with someone close", "Something at work", "Conflict with my boss", "Studies or an exam", "Health", "Money", "Loneliness", "A failure", "A breakup", "Relationship with my parents", "Children", "Moving", "The future", "Criticism of me"];

    private static readonly string[] BackupOptions =
        ["Ask for help", "Wait and try again", "Find another way", "Lower my demands on myself", "Take a break", "Talk it over with someone close", "See a specialist", "Find side work", "Take a course", "Break the task into steps", "Postpone the decision", "Start small"];

    private static readonly string[] HarshThoughts =
        ["\"I'll ruin everything\"", "\"They'll judge me\"", "\"I can't cope\"", "\"Nobody needs me\"", "\"It's a disaster\"", "\"Nothing will work out\"", "\"I'm worse than others\"", "\"Everything always goes wrong\"", "\"It's my fault\"", "\"Something is wrong with me\"", "\"This will never end\"", "\"I have to be perfect\""];

    internal static readonly BuiltInTechniqueDefinition Spin = new(
        "Practice", "Name the feeling",
        [
            "1. Choose a recent, mildly upsetting everyday situation",
            "2. Name the main feeling",
            "3. Rate how strong it feels now (0–10)"
        ],
        "Briefly notice the situation and feeling without expecting immediate relief.",
        TechniqueUiKind.Entry, "Technique #1", "26.01.2023", "Name the feeling", "Notice what is happening now", "Hard moment", "PsychologyApp team", 5, "Autorenew",
        [
            new TechniqueEntrySeed("Situation", "For example: a minor issue at work. Skip distressing details.", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Main feeling", "Hurt, worry, anger…", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("How strong it feels now", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Note the situation, feeling, and how strong it feels now. This is self-observation, not treatment or a promise that the feeling will change right away.",
            "For a mildly upsetting everyday situation, if writing about it feels comfortable. Do not choose a traumatic memory or an acute crisis.",
            "Write only what is needed and rate the feeling now. If distress rises, stop, look around, and choose a more neutral practice. There is no need to repeat it.",
            "Situation: a colleague interrupted me. Feeling: irritation. Intensity now: 5 out of 10."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Comparison = new(
        "Practice", "See the wider context",
        [
            "1. Name what feels difficult without minimizing it",
            "2. Which areas of life does it affect?",
            "3. What else matters or needs attention too?",
            "4. What or whom would you like to care for today?",
            "5. Note what you notice without rating the problem as small or large"
        ],
        "This exercise lists different parts of life; it does not determine how serious a problem is.",
        TechniqueUiKind.Entry, "Technique #2", "26.01.2023", "See the wider context", "When one difficulty takes up all your attention", "Scale of the problem", string.Empty, 7, "CompareArrows",
        [
            new TechniqueEntrySeed("What is happening", "What feels difficult right now?", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Areas affected", "E.g. work, health, relationships", Suggestions: ["Work", "Family", "Friends", "Health", "Studies", "Money", "Relationships", "Sleep", "Home", "Hobbies", "Rest", "Plans"]),
            new TechniqueEntrySeed("What else matters", "What also needs attention?", Suggestions: ["Work", "Family", "Health", "Relationships", "Rest", "Children", "Friends", "Studies", "Sleep", "Peace of mind", "Self-growth", "Daily tasks"]),
            new TechniqueEntrySeed("What to care for", "What or who needs your attention today?", Suggestions: ["Health", "People close to me", "Sleep", "Rest", "A work issue", "A conversation", "A daily task", "Personal boundaries", "Not sure yet"]),
            new TechniqueEntrySeed("What do you notice", "There is no need to find a positive conclusion")
        ],
        Theory(
            "This exercise helps list what else has your attention without denying the importance of the difficulty itself.",
            "When one topic takes up most of your attention and you want to name other needs and tasks too.",
            "Use your own words and do not search for a positive spin. If a practical step or safety issue needs attention, prioritize it. You can leave any field blank.",
            "Concern: looking for work. It affects money and sleep; caring for someone close also matters today. You might choose one job-search step and ask for support. That does not make the concern less serious."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Polarity = new(
        "Practice", "Polarities",
        [
            "1. Write what you like about the situation",
            "2. Write what you dislike",
            "3. Compare pairs and notice the balance"
        ],
        "The polarity method helps you see both sides and reduce inner tension.",
        TechniqueUiKind.Polarity, "Technique #3", "26.01.2023", "Polarities", "See both sides of a situation", "Different sides", "Zivorad Slavinski", 5, "Contrast",
        null,
        Theory(
            "Every situation has attractive and unpleasant sides. Naming both reduces one-sided fixation.",
            "When you see only negatives or only positives and feel stuck.",
            "Add like/dislike pairs for one theme. Compare lists without judging who is right.",
            "Work: like income, dislike schedule. Home: like coziness, dislike neighbor noise."),
        "What you dislike", "What you like");

    internal static readonly BuiltInTechniqueDefinition Paper = new(
        "Practice", "A thought on paper",
        [
            "1. Write one thought below or on a sheet of paper",
            "2. Read it once and name the feeling, if you wish",
            "3. Choose what to do with the page: keep, fold, or tear it. Doing nothing is fine too"
        ],
        "Writing can help you notice how a thought is worded; you do not need to destroy the page or expect relief.",
        TechniqueUiKind.Paper, "Technique #4", "26.01.2023", "A thought on paper", "When a thought keeps returning", "Thoughts", "PsychologyApp team", 3, "Description",
        [new TechniqueEntrySeed("Thought", "For example: “I'll ruin the presentation.”", Suggestions: HarshThoughts)],
        Theory(
            "You write down one thought so you can see its wording. This is self-observation, not treatment or a guaranteed way to change a feeling.",
            "When a thought keeps returning and writing feels okay. Stop if it makes you feel worse.",
            "Write one sentence and read it once. Keeping, putting away, or tearing the page is your choice. You do not have to make yourself feel calm.",
            "Thought: “I'll ruin the presentation.” You could keep the note and check one slide."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Future = new(
        "Practice", "A future perspective",
        [
            "1. Choose a manageable everyday difficulty",
            "2. Imagine looking back from a time you choose — for example, one or five years from now"
        ],
        "Rate the situation from a future perspective. It may still matter; you do not have to dismiss it.",
        TechniqueUiKind.Entry, "Technique #5", "30.01.2023", "A future perspective", "Try a wider view without dismissing the issue", "Scale of the problem", "PsychologyApp team", 2, "Schedule",
        [
            new TechniqueEntrySeed("Situation", "For example: a manageable issue at work.", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("How important does it seem from that distance?", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "A future perspective is an imagined way to look at a situation. Its importance may stay the same, and that is okay.",
            "For a manageable everyday difficulty. Do not choose a traumatic memory or an urgent problem that needs action.",
            "Choose a time frame, such as one or five years. Imagine viewing the situation from then and give it a rating. There is no right score; stop if the exercise feels unhelpful.",
            "A missed invitation may still matter a year from now. Today, you could ask about the plans or choose another next step."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Hack = new(
        "Practice", "Pause with nearby details",
        [
            "1. Choose a neutral object nearby; do not return to a distressing memory",
            "2. Name three details: its color, shape, and surface",
            "3. Decide whether to continue or stop"
        ],
        "A brief way to notice an object nearby without revisiting a painful event.",
        TechniqueUiKind.Entry, "Technique #6", "30.01.2023", "Pause with nearby details", "Shift attention to your surroundings", "Hard moment", "PsychologyApp team", 3, "BlurOn",
        [new TechniqueEntrySeed("Object nearby", "For example: a cup, a window, or a book.", Role: EntryFieldRole.None)],
        Theory(
            "Bring your attention to a neutral object here and now. This is a brief orientation exercise, not a way to erase a memory or replace professional support.",
            "When you want to focus briefly on your surroundings. Do not use this practice instead of urgent help.",
            "Name three details about the object. If you feel worse or uncomfortable, stop, look around, and choose another action.",
            "For example: a cup — white, round, cool to the touch."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Experience = new(
        "Practice", "Experience modification",
        [
            "1. Choose an area to work on",
            "2. Describe your attitude toward it",
            "3. Name related beliefs",
            "4. How does attitude change when you think of past experience?",
            "5. Describe a negative experience",
            "6. Rate the negative experience (−10…10)",
            "7. What positive experience could replace it?",
            "8. How would your attitude change with that experience?",
            "9. Rate the new experience (−10…10)"
        ],
        "EMO helps replace a limiting experience with a more supportive one.",
        TechniqueUiKind.Entry, "Technique #7", "08.02.2023", "Experience modification", "Rewrite a limiting experience", "Hard moment", "Filip Slavinski", 15, "Psychology",
        [
            new TechniqueEntrySeed("Area", "Relationships, work, health…", Suggestions: ["Relationships", "Work", "Health", "Money", "Public speaking", "Family", "Studies", "Appearance", "Friendship", "Creativity", "Sport", "Career"]),
            new TechniqueEntrySeed("Attitude toward the area", "How do you feel about it now?", Suggestions: ["Anxiety", "Self-doubt", "Irritation", "Indifference", "Interest", "Tiredness", "Fear", "Shame", "Hope", "Anger", "Confusion", "Calm"]),
            new TechniqueEntrySeed("Related beliefs", "E.g. \"I can't succeed\"", Suggestions: ["\"I can't succeed\"", "\"I'm not good enough\"", "\"They won't accept me\"", "\"Nothing will change\"", "\"I have to be perfect\"", "\"I'm unlucky\"", "\"I don't deserve it\"", "\"Others are better\"", "\"Mistakes are not allowed\"", "\"I'm too old for this\""]),
            new TechniqueEntrySeed("Attitude and past experience", "What changes when you recall the past?", Suggestions: ["It gets heavier", "It gets calmer", "Nothing changes", "Anger comes up", "Sadness comes up", "Fear comes up", "I remember I coped", "I want to avoid it"]),
            new TechniqueEntrySeed("Negative experience", "A specific episode or pattern"),
            new TechniqueEntrySeed("Negative experience rating", "", EntryFieldKind.RatingNeg10To10),
            new TechniqueEntrySeed("Positive replacement", "What supportive experience is possible?", Suggestions: ["A time I succeeded", "A time I was supported", "A time I coped on my own", "A time I was praised", "A time I helped someone", "A time I learned something new", "A time I didn't give up", "A time I was accepted as I am"]),
            new TechniqueEntrySeed("Attitude with the positive", "How would your view of the area change?", Suggestions: ["Hope appears", "More calm", "I want to try again", "It gets interesting", "Confidence appears", "It gets lighter", "I feel strength", "Still hard to believe"]),
            new TechniqueEntrySeed("New experience rating", "", EntryFieldKind.RatingNeg10To10)
        ],
        Theory(
            "Beliefs often rest on one vivid negative experience. Conscious replacement can shift your attitude.",
            "When \"it's always been this way\" and change feels impossible.",
            "Go through the fields in order. Compare the two ratings — aim for the second to be higher.",
            "Area: public speaking. Negative: failed exam (−8). Replacement: good talk (+6)."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Copied = new(
        "Practice", "Notice the thought",
        [
            "1. Write a short phrase that keeps returning",
            "2. Read it once and ask: is it a fact, a prediction or a judgment?",
            "3. If comfortable, check one fact. Stop if your distress grows"
        ],
        "This exercise helps you look at how a thought is worded; repeating it does not guarantee less anxiety.",
        TechniqueUiKind.Copied, "Technique #8", "21.01.2025", "Notice the thought", "Name an anxious phrase without arguing with yourself", "Scale of the problem", string.Empty, 2, "Repeat",
        [new TechniqueEntrySeed("Wording", "I'm afraid of losing my job", Suggestions: HarshThoughts)],
        Theory(
            "This is a brief way to notice the words in a thought and check what it is based on. You do not need to say it aloud or repeat it.",
            "When one phrase keeps returning and you feel ready to look at it briefly. Skip this if the thought feels overwhelming right now.",
            "Write the thought in a few words. Ask what you know for sure and what is a prediction. Do not force yourself to believe an answer. Stop if distress grows.",
            "Thought: \"I will definitely fail the meeting.\" Fact: \"I have a meeting tomorrow.\" The outcome is still unknown."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Extend = new(
        "Practice", "Plan for uncertainty",
        [
            "1. Name the situation you want a backup for",
            "2. Write one realistic option and available resources",
            "3. Choose a next step or decide when to revisit the plan"
        ],
        "Planning can clarify available actions; it cannot guarantee an outcome or immediate relief.",
        TechniqueUiKind.Entry, "Technique #9", "21.01.2025", "Plan for uncertainty", "Find one practical next step", "Scale of the problem", string.Empty, 3, "Backup",
        [
            new TechniqueEntrySeed("Situation", "What might not go as planned?", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Practical option", "E.g. check a deadline or ask for help", Suggestions: BackupOptions),
            new TechniqueEntrySeed("Resource or support", "Who or what could you turn to?", Suggestions: BackupOptions),
            new TechniqueEntrySeed("Next step", "What could you do now, or when will you revisit this?", Suggestions: BackupOptions)
        ],
        Theory(
            "Planning can clarify available actions, but it cannot control other people's decisions or guarantee calm.",
            "When there is a specific practical uncertainty and you want to consider one manageable option.",
            "Separate known facts from worries. Identify one realistic step, resource, or time to return to the question. If planning turns into repeated checking of every scenario and increases distress, stop.",
            "If there is no reply after an interview, you could choose a reasonable time to follow up and focus on other tasks for now. This does not predict the employer's decision."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Resize = new(
        "Practice", "View the image from a distance",
        [
            "1. Briefly name an everyday situation; no need to use painful memories",
            "2. If comfortable, imagine it as a still image",
            "3. You may change its size or distance, but do not force the image to change"
        ],
        "An optional visualization for noticing attention; it does not change the situation or promise relief.",
        TechniqueUiKind.Entry, "Technique #10", "22.01.2025", "View the image from a distance", "Try distance only if it feels comfortable", "Scale of the problem", string.Empty, 2, "ZoomOutMap",
        [new TechniqueEntrySeed("What bothers you", "E.g. a conflict that keeps you awake", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem)],
        Theory(
            "This is a brief imagery exercise: you can observe an image from a distance. People respond differently, and the situation itself does not change.",
            "Only for a manageable everyday concern. Do not choose a painful memory; you can skip the exercise.",
            "Imagine the situation without adding detail. Change its size or distance only if comfortable. If distress grows, stop and notice the room around you.",
            "You might picture a task as a note on a desk and decide when to return to it. The image does not have to become smaller or calmer."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Check = new(
        "Practice", "Shift your attention",
        [
            "1. Name the recurring thought in a short phrase, without details",
            "2. Notice: \"I am having the thought that…\"",
            "3. If you want, shift attention to a neutral sound or object; the thought may stay"
        ],
        "This exercise helps you choose where to place your attention; it does not require thoughts to disappear.",
        TechniqueUiKind.Entry, "Technique #11", "22.01.2025", "Shift your attention", "Notice the thought and choose a neutral focus", "Scale of the problem", string.Empty, 2, "FactCheck",
        [new TechniqueEntrySeed("What you're looping on", "Which thought keeps returning?", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem)],
        Theory(
            "This is a brief way to notice a recurring thought and give attention another task. You do not need to suppress it or become calm.",
            "When you are replaying one topic and feel comfortable trying a brief shift. If the thought concerns real danger, address safety first.",
            "Name the thought in one phrase, then choose a neutral sound or object around you. Stop if distress grows. Do not use this instead of needed medical or practical action.",
            "Thought: \"What if I am ill?\" You can notice it as a thought and decide whether a real step is needed, such as asking a clinician about a symptom."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Observer = new(
        "Practice", "Distanced Self-Talk",
        [
            "1. Briefly name the situation and feeling. No need to describe a painful event.",
            "2. Use your name or “you”: “[Name], what is happening right now?”",
            "3. Ask what matters and what safe, manageable step is possible. Do not excuse harm or minimize danger.",
            "4. Tension may ease, stay the same, or increase. If you feel worse, stop and choose other support."
        ],
        "A brief self-distancing prompt: address yourself by name or as “you” rather than only “I.” It may create room to reflect, but does not promise immediate relief.",
        TechniqueUiKind.Entry, "Technique #12", "12.06.2026", "Distanced Self-Talk", "Use your name or “you” to choose a safe next step", "Difficult moment", "Self-help skill", 1, "Visibility",
        [
            new TechniqueEntrySeed("Situation", "Briefly: what is happening now? Details of a painful event are not needed.", Suggestions: ProblemTopics, Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Feelings from first person", "What are you feeling? One short sentence is enough.", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("What the observer sees", "Address yourself by name or as “you”: what matters, and what is one safe next step?", Suggestions: ["[Name], what matters to you right now?", "What is one safe, realistic step?", "How can you support yourself?", "What would you say to someone you care about?", "You can reply later, when things are clearer"]),
            new TechniqueEntrySeed("Tension now", "Rate it at the end; it may stay the same.", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Distanced self-talk uses your name or “you” instead of only “I.” This may create room to reflect, but it is not a promise of immediate relief.",
            "Try it during manageable emotional or social stress, only when you are safe. Do not use it to excuse harm or dismiss real danger.",
            "Name the feeling briefly, address yourself by name or as “you,” and ask what matters now and what safe step is possible.",
            "Instead of “I can’t cope”: “[Name], this is hard. What is one safe next step you can take?”"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Anchor = new(
        "Practice", "Supportive memory",
        [
            "1. Recall a safe moment when you felt supported or managed a difficulty",
            "2. Notice what helped and what you sensed in your body",
            "3. If you wish, choose a gesture only as a reminder of the memory",
            "4. Rate how helpful the memory feels now (0 = not at all, 10 = very); 0 is okay"
        ],
        "A memory may remind you of familiar sources of support. Responses vary; a gesture is only an optional reminder, not a reliable way to change your state.",
        TechniqueUiKind.Entry, "Technique #13", "12.06.2026", "Supportive memory", "Recall support and notice your resources", "A hard moment", "Memory recall", 4, "SelfImprovement",
        [
            new TechniqueEntrySeed("Resource memory", "Choose a memory that feels safe to recall; skip this exercise if none comes to mind.", Suggestions: ["A talk that went well", "A holiday by the sea", "A hug from someone close", "Finishing something hard", "A walk in nature", "Passing an exam", "The birth of a child", "Winning a competition", "An evening with friends", "Praise from my manager", "First day at a new job", "A morning without rush"]),
            new TechniqueEntrySeed("Body sensations", "Where do you feel it? Warmth, lightness, grounding…", Suggestions: ["Warmth in the chest", "Lightness", "Open shoulders", "Even breathing", "Steady legs", "A smile", "A calm heart", "A straight back", "Energy in my hands", "A relaxed belly"]),
            new TechniqueEntrySeed("Optional reminder gesture", "This gesture may remind you of the memory; you can skip this step", Suggestions: ["Clench a fist", "Touch the wrist", "Join thumb and index finger", "Hand on the heart", "A deep breath", "Squeeze an earlobe", "Open the shoulders", "Stroke my palm"]),
            new TechniqueEntrySeed("Memory response", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "This is a brief memory exercise. Its effect, and any link with a gesture, are not guaranteed.",
            "When you want to remember what has helped before. Choose only a safe memory; stop if it feels harder.",
            "Notice what helped. A gesture is optional and only a reminder; you do not need to make yourself feel calm.",
            "I remember a friend listening to me. Talking helped; I could message them now. Memory response: 5 out of 10."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Grounding = new(
        "Practice", "5-4-3-2-1 grounding",
        [
            "1. Name 5 things you can see",
            "2. Name 4 things you can feel with your body",
            "3. Name 3 sounds around you",
            "4. Name 2 smells",
            "5. Name 1 taste or pleasant sensation"
        ],
        "Sensory grounding shifts attention from anxious thoughts to the present moment.",
        TechniqueUiKind.Entry, "Technique #14", "12.06.2026", "5-4-3-2-1 grounding", "Ground with your five senses", "Hard moment", "Psyche", 3, "Nature",
        [
            new TechniqueEntrySeed("5 things I see", "E.g. window, cup, book, lamp, hand", Suggestions: ["Window", "Table", "Phone", "Computer", "Laptop", "Monitor", "Keyboard", "Cup", "Lamp", "Hand", "Door", "Book", "Chair", "Wall", "Picture", "Plant", "Clock", "Wardrobe", "Sky", "Car"]),
            new TechniqueEntrySeed("4 things I feel with my body", "E.g. chair, floor, clothes, air temperature", Suggestions: ["Chair", "Floor under my feet", "Clothes", "Coolness", "Warmth", "Phone in my hand", "Back of the chair", "Fabric on my skin", "Breath in my chest", "Wind", "Computer mouse", "Keys", "Pillow", "Watch on my wrist"]),
            new TechniqueEntrySeed("3 sounds", "E.g. street, clock, your breath", Suggestions: ["Street", "Clock", "Breathing", "Voices", "Fridge", "Wind", "Silence", "Computer", "Cars", "Birds", "Music", "Air conditioner", "Footsteps", "Rain"]),
            new TechniqueEntrySeed("2 smells", "E.g. coffee, fresh air", Suggestions: ["Coffee", "Fresh air", "Soap", "Food", "Perfume", "Almost nothing", "Tea", "Bread", "Books", "Flowers", "Hand cream", "Wood"]),
            new TechniqueEntrySeed("1 taste or pleasant sensation", "E.g. water in mouth, soft fabric", Suggestions: ["Water", "Tea", "Soft fabric", "Warm palms", "Fresh mouth", "Coffee", "Mint gum", "Chocolate", "An apple", "A warm blanket"])
        ],
        Theory(
            "Shift your attention to what you can see, hear and feel around you.",
            "When worry takes up your attention and you want to focus on your surroundings.",
            "Start with what you can see. If you cannot notice a smell or a taste, move on. Breathe as usual.",
            "I see a cup and a lamp. I feel the floor under my feet. I hear traffic outside."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Breathing = new(
        "Practice", "Gentle paced breathing",
        [
            "1. Rate your tension.",
            "2. Sit comfortably. Breathe gently, no deeper than usual.",
            "3. If it feels comfortable, breathe in for 4 counts and out for 6, without holding your breath.",
            "4. Drop the count or stop if the pace feels uncomfortable. If you feel dizzy or short of breath, return to your usual breathing.",
            "5. Rate your tension again. It may be the same."
        ],
        "A brief, gentle rhythm without breath holds can be tried when tense. It does not suit everyone: counting or focusing on the breath may increase discomfort.",
        TechniqueUiKind.Entry, "Technique #15", "04.07.2026", "Gentle paced breathing", "Gently lengthen your exhale", "Hard moment", "Psyche", 3, "Air",
        [
            new TechniqueEntrySeed("Tension before", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notes", "What did you notice? Any response is okay.", Suggestions: ["The pace felt comfortable", "Counting felt distracting", "The pace felt too slow", "I felt dizzy", "Breathing felt uncomfortable", "I felt a little calmer", "No change in tension", "I felt more tense", "I stopped and noticed things around me"]),
            new TechniqueEntrySeed("Tension after", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "A brief, gentle rhythm with a slightly longer out-breath is one way to try pacing the breath when tense. Responses vary; this practice does not guarantee relief.",
            "When you feel tense and focusing on breathing feels comfortable.",
            "Sit comfortably. Keep the breath gentle and no deeper than usual. For about a minute, you can follow the circle: in for about 4 counts and out for about 6, with no pauses. If the pace feels forced, return to your natural breathing. Stop if discomfort increases and name a few objects around you.",
            "Tension was 7/10. After a minute it was still 7/10; counting felt forced, so I stopped and named five objects around me."
        ),
        null, null);

    internal static readonly BuiltInTechniqueDefinition SmallStep = new(
        "Practice", "One small step",
        [
            "1. Pick one manageable activity. For example, drink some water or message someone close to you.",
            "2. Set aside 2–5 minutes for a safe start. You can stop there.",
            "3. Choose a time within the next 24 hours. If rest or support fits better right now, choose that.",
            "4. Rate your confidence from 0 to 10. If starting feels hard, make the step smaller."
        ],
        "A brief activity plan informed by behavioral activation. A small step can help with getting started, but it does not guarantee a better mood or more energy.",
        TechniqueUiKind.Entry, "Technique #16", "04.07.2026", "One small step", "Choose one activity and start small", "Hard moment", "CBT", 5, "DirectionsWalk",
        [
            new TechniqueEntrySeed("What makes starting hard?", "Tiredness, anxiety, loneliness, too much to do?", Suggestions: ["Tiredness", "Anxiety", "Loneliness", "Too much to do", "Boredom", "I don't know where to start", "I need rest", "The conditions aren't right"], Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("A small activity for me", "Self-care, interest, connection, or a small task", Suggestions: ["Drink water or have a snack", "Wash or get dressed", "Get fresh air for 2 minutes", "Play a favorite song", "Send someone close one message", "Spend 2 minutes on something important", "Put one thing away", "Ask someone to stay with me"]),
            new TechniqueEntrySeed("When will you try it?", "A specific time in the next 24 hours", Suggestions: ["For 2 minutes now", "After breakfast", "After lunch", "After work or study", "At a time I choose today", "Ask someone close to remind me"]),
            new TechniqueEntrySeed("How doable does it feel?", "0 — not confident at all, 10 — completely confident", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Low mood or energy can make it hard to begin. A small planned activity may help create momentum; the effect varies from person to person.",
            "When low mood or energy makes it hard to start and a safe, manageable activity is available. Rest or asking for help can also be a useful step.",
            "Choose an activity for self-care, interest, connection, or a sense of completion; shrink the start to 2–5 minutes and schedule it within 24 hours. Planning is not the same as doing it. If it does not feel manageable, make it smaller or ask for support.",
            "Instead of “clean the whole apartment,” wash one cup after lunch — or send someone close: “Have a minute to talk?”"),
        null, null);

    internal static readonly BuiltInTechniqueDefinition ThoughtRecord = new(
        "Practice", "Thought record",
        [
            "1. Describe the situation without judging it",
            "2. Write the automatic thought",
            "3. Name the emotion and rate it now",
            "4. Separate facts from assumptions and find another possibility",
            "5. Rate the emotion again; it may stay the same"
        ],
        "Separate the situation, thought, and feeling, then check the conclusion against the facts. The feeling does not have to ease.",
        TechniqueUiKind.Entry, "Technique #17", "04.07.2026", "Thought record", "Separate a fact from an interpretation", "Hard moment", "CBT", 7, "EditNote",
        [
            new TechniqueEntrySeed("Situation", "What happened? Where and when? Just the essentials.", Role: EntryFieldRole.Problem),
            new TechniqueEntrySeed("Automatic thought", "What did you think in that moment?", Suggestions: HarshThoughts),
            new TechniqueEntrySeed("Emotion before", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("A more accurate view", "What facts support or challenge it? What else is possible?", Role: EntryFieldRole.Reframe),
            new TechniqueEntrySeed("Emotion after", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "This exercise separates an event from your interpretation of it. It is not a diagnosis or treatment.",
            "For a moderately upsetting situation, if you have the capacity to write about it now. Do not choose a traumatic memory or an acute crisis.",
            "Write down observable facts, then the thought. Look for an explanation that accounts for the facts and the unknowns; do not force a positive view. An unchanged rating does not mean you did anything wrong.",
            "Situation: no reply to a message yet. Thought: “Nobody needs me.” Fact: there is no reply yet. Another possibility: the reason is unknown; the person may be busy."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition SelfCompassion = new(
        "Practice", "Kind words to yourself",
        [
            "1. Write what you criticize yourself for.",
            "2. What would you say to a friend in your situation?",
            "3. Offer yourself the same supportive words.",
            "4. Rate any warmth or relief."
        ],
        "Self-compassion reduces harsh self-criticism and helps recover after a mistake.",
        TechniqueUiKind.Entry, "Technique #18", "04.07.2026", "Kind words to yourself", "Replace self-criticism with support", "Hard moment", "CBT", 5, "Favorite",
        [
            new TechniqueEntrySeed("What you criticize yourself for", "What do you tell yourself or blame yourself for?", Suggestions: ["A mistake at work", "Didn't get it done", "Snapped at someone close", "Comparing myself to others", "Putting things off again", "My appearance", "My weight", "Said the wrong thing", "Not a good enough parent", "Earning too little", "Broke a promise", "Too sensitive"]),
            new TechniqueEntrySeed("What you would tell a friend", "How would you support someone close in this situation?", Role: EntryFieldRole.Kindness),
            new TechniqueEntrySeed("Phrase to yourself", "The same kindness, directed at you", Role: EntryFieldRole.SelfKindness),
            new TechniqueEntrySeed("Warmth / relief", "", EntryFieldKind.Rating0To10)
        ],
        Theory(
            "Self-criticism rarely motivates — it more often fuels shame and paralysis. Self-compassion does not remove responsibility, but gives support.",
            "After a mistake, comparing yourself to others, or feeling not good enough.",
            "Write the criticism, then answer yourself as you would a friend — with respect and without dismissal.",
            "Criticism: I ruined everything again. To friend: you tried, this is fixable. To self: I can learn from this. Warmth: 3 → 6."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition BodyScan = new(
        "Practice", "Where is it in the body?",
        [
            "1. Rate your tension.",
            "2. Slowly move your attention from head to toe.",
            "3. Find where the sensation is strongest.",
            "4. Describe it: for example, small or large, warm or cold.",
            "5. Name the feeling linked to it.",
            "6. If you like, notice what changed—or stayed the same. You can stop or shift your attention to your surroundings at any time."
        ],
        "A body scan invites you to notice sensations and feelings without needing to change them.",
        TechniqueUiKind.Entry, "Technique #19", "16.10.2026", "Where is it in the body?", "Notice sensations and feelings without needing to change them", "Hard moment", "Mindfulness", 4, "Accessibility",
        [
            new TechniqueEntrySeed("Tension now", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Where in the body do you feel it?", "For example: chest, throat, shoulders", Suggestions: ["Head", "Forehead", "Eyes", "Jaw", "Throat", "Neck", "Shoulders", "Chest", "Heart", "Stomach", "Back", "Lower back", "Arms", "Hands", "Legs", "The whole body"]),
            new TechniqueEntrySeed("What is the sensation like?", "For example: tightness, heaviness, a lump", Suggestions: ["Tightness", "Heaviness", "A lump", "Pressure", "Tension", "Heat", "Cold", "Trembling", "Tingling", "Throbbing", "Emptiness", "Numbness", "Pain", "Hard to describe"]),
            new TechniqueEntrySeed("What feeling goes with it?", "For example: anxiety, hurt, tiredness", Role: EntryFieldRole.Emotion),
            new TechniqueEntrySeed("Tension after", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "A body scan can be a way to notice sensations and feelings that may go with them. Tension does not have to change; it may stay the same. Body scans are used in some mindfulness programmes.",
            "When you feel anxious or heavy but cannot tell what exactly you feel; when the body is tense after a hard conversation or day. The practice does not explain illnesses and does not replace a doctor: if a sensation is new, strong or does not go away, see a doctor.",
            "Sit comfortably if that feels okay, and gradually bring your attention to different parts of your body. Describe a sensation as specifically as you can; name a feeling too, if that fits. You do not need to change anything. If turning inward feels uncomfortable, open your eyes, focus on things around you, or stop. Breathe normally.",
            "Tension 6/10. Place: chest. Sensation: tightness. Feeling: worry before a conversation. Afterwards, tension was still 6/10. I opened my eyes and named things in the room. That is a valid result too."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Flashback = new(
        "Practice", "A memory took over",
        [
            "1. Rate how strongly the memory is affecting you now.",
            "2. Tell yourself: “This is a memory. It was then; I am here now.”",
            "3. Name where you are and what time of day it is.",
            "4. Feel the support under your feet. Clench and release your fists.",
            "5. Name 3 things you can see.",
            "6. Take 5 slow out-breaths and touch cool water. Rate your tension again."
        ],
        "Help with a flashback: come back from the memory to the present through time, place, the body and the senses.",
        TechniqueUiKind.Entry, "Technique #20", "16.10.2026", "A memory took over", "Return to the present", "Hard moment", "Trauma", 3, "MyLocation",
        [
            new TechniqueEntrySeed("How strong it is", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Where you are and the time of day", "For example: at home, evening", Suggestions: ["At home", "At work", "Outside", "On transport", "Visiting someone", "Morning", "Afternoon", "Evening", "Night"]),
            new TechniqueEntrySeed("Three things you can see", "For example: window, cup, lamp", Suggestions: ["Window", "Table", "Phone", "Cup", "Lamp", "Door", "Chair", "Wall", "Picture", "Plant", "Clock", "Sky"]),
            new TechniqueEntrySeed("How strong it is now", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "A flashback is a memory of trauma that is lived as if it were happening again: with the same feelings and body reactions. The brain mixes up \"then\" and \"now\". Time, place, the body's support and what you see and hear help bring you back to the present.",
            "When a memory of a hard event takes over, with flashes of images and the feeling \"I'm back there\". Frequent flashbacks are a common sign of a post-traumatic reaction, and they respond well to treatment with a trauma specialist.",
            "Do not try to work through the memory: right now the only task is to come back. Tell yourself where you are and what day it is, press your feet down, name what you see, breathe out slowly, use cold.",
            "Strength 8. \"That was then; now it's 2026, I'm at home, it's evening.\" Feet on the floor; I see a window, a cup, a lamp. Cold water. Now 4."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Nightmare = new(
        "Practice", "Rewrite a nightmare",
        [
            "1. Choose a recurring nightmare, but not the hardest one.",
            "2. Describe it briefly; skip distressing details.",
            "3. Decide what to change: the ending, place, yourself, or someone nearby.",
            "4. Write the new version through to a calm ending.",
            "5. Imagine it for 10–20 minutes each day, during the day.",
            "6. After 1–2 weeks, check whether the nightmares have changed."
        ],
        "Imagery rehearsal: a recurring nightmare is rewritten while awake, and the brain starts dreaming the new version.",
        TechniqueUiKind.Entry, "Technique #21", "16.10.2026", "Rewrite a nightmare", "Reduce nightmare frequency and intensity", "Sleep", "Trauma", 15, "NightsStay",
        [
            new TechniqueEntrySeed("How hard this nightmare is", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("What the nightmare is about, briefly", "One or two sentences, without hard details", Suggestions: ["Someone is chasing me", "I can't get away", "I'm back where it was frightening", "I'm losing someone close", "I can't scream", "I'm falling", "I'm being attacked", "I'm late and can't make it"]),
            new TechniqueEntrySeed("What you change", "Anything you like: it's your dream", Suggestions: ["The ending", "The place", "I become stronger", "A helper appears", "I can speak and shout", "The danger disappears", "Everything turns safe", "I notice it's a dream"]),
            new TechniqueEntrySeed("The new version of the dream", "Describe it in full, from the start to a calm ending", Suggestions: ["I notice it's a dream", "Someone who protects me appears", "I find myself in a safe place", "I calmly walk away", "It all ends well"]),
            new TechniqueEntrySeed("When I'll rehearse the new version", "Every day, 10 to 20 minutes", Suggestions: ["In the morning", "During the day, on a break", "In the evening, a couple of hours before bed", "Every day at the same time"]),
            new TechniqueEntrySeed("How hard it is now", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Recurring nightmares after trauma or stress are kept going by habit: the brain plays the same plot again and again. In imagery rehearsal therapy the plot is rewritten while awake, and the new version is rehearsed in the mind every day. Research shows that this makes nightmares rarer and weaker and sleep better.",
            "With recurring nightmares that make you afraid to fall asleep. If the nightmare is a direct replay of a trauma and even a short description brings strong horror, do this together with a trauma specialist.",
            "Start with an easier nightmare. Do not write out the frightening parts in detail: a couple of sentences is enough. Change the dream any way you like; the new version does not have to be realistic. Rehearse it during the day, not right before sleep, 10 to 20 minutes a day.",
            "Nightmare: someone is chasing me and I can't get away. Change: I notice it's a dream, turn around, and it's just a shadow; I calmly walk home. I rehearse it every day in the afternoon. After two weeks the nightmare comes less often."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition Balloons = new(
        "Practice", "Pop the balloons",
        [
            "1. Rate your tension before the game.",
            "2. Start the round and tap at your own pace. You do not need to pop every balloon.",
            "3. Breathe as usual; do not match your exhale to the pops.",
            "4. The round ends on its own. If it frustrates you or you feel worse, stop.",
            "5. Rate your tension again. No change is a valid result."
        ],
        "A short game for your hands and attention. It may briefly shift your focus, but it need not change how you feel and does not replace action or support.",
        TechniqueUiKind.Entry, "Technique #22", "26.10.2026", "Pop the balloons", "An optional short game break", "Hard moment", "Psyche", 3, "BubbleChart",
        [
            new TechniqueEntrySeed("Tension before", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notes", "What did you notice, if anything? You can leave this blank.", Suggestions: ["A little less tense", "No noticeable change", "More tense", "My attention shifted briefly", "I noticed colors or movement", "The game felt frustrating", "Not sure", "Other"]),
            new TechniqueEntrySeed("Tension after", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "A short game may briefly occupy your hands and attention; its effect varies. It is not a guaranteed way to reduce anxiety or a treatment.",
            "When a short game break feels welcome. Do not delay urgent steps for health or safety because of the game.",
            "Tap at a comfortable pace; you do not have to pop every balloon. Breathe normally; do not sync your breathing with each pop. After the round, compare your rating without expecting a particular result. If there is a practical problem to address, return to the next step when ready.",
            "After an argument, my tension was 7/10 and stayed at 7/10 after the round. I noticed I was still angry and chose to wait before replying."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition CyclicSigh = new(
        "Practice", "Cyclic sigh",
        [
            "1. Rate your tension.",
            "2. Breathe in through your nose, then add one short breath in at the top.",
            "3. Breathe out slowly through your mouth, longer than you breathed in.",
            "4. Follow the circle's rhythm for about 3 minutes.",
            "5. Rate your tension again."
        ],
        "Two gentle breaths in followed by a longer breath out create a breathing rhythm. You do not need to hold your breath or inhale more deeply than usual.",
        TechniqueUiKind.Entry, "Technique #23", "26.10.2026", "Cyclic sigh", "Double inhale, long exhale", "Hard moment", "Psyche", 3, "Air",
        [
            new TechniqueEntrySeed("Tension before", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notes", "What did you notice?", Suggestions: ["A little calmer", "No noticeable change", "More uncomfortable", "I felt dizzy", "I don't want to rate it", "Something else"]),
            new TechniqueEntrySeed("Tension after", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "A randomized study of 111 participants examined cyclic sighing practiced for five minutes daily over one month. Positive mood ratings improved more in that group than in the mindfulness group. This does not show that one short session will quickly lower tension, or that everyone will respond the same way.",
            "Try it if focusing on your breath feels comfortable—for example, before a conversation or during a short pause. If breath focus makes you more uncomfortable, choose an exercise that focuses on your surroundings.",
            "Breathe gently; do not try to inhale as deeply as possible. Repeat the rhythm only while it feels comfortable. If you feel dizzy or uneasy, stop, sit somewhere stable, and return to your usual breathing. Seek medical advice if symptoms are severe or do not ease.",
            "Before a call, I notice tension and try a few gentle cycles. If nothing changes or I feel more uncomfortable, I stop and breathe normally."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition MuscleRelax = new(
        "Practice", "Tense and let go",
        [
            "1. Rate your tension.",
            "2. Tense a muscle group for 5 seconds, at about half strength.",
            "3. Release it and notice the relaxation for 15 seconds.",
            "4. Repeat with your hands, shoulders, face, belly, and legs.",
            "5. Rate your tension again."
        ],
        "Tensing muscles first and then letting go makes it easier for the body to feel what relaxing is.",
        TechniqueUiKind.Entry, "Technique #24", "26.10.2026", "Tense and let go", "Tense muscles, then let go", "Hard moment", "Psyche", 4, "SelfImprovement",
        [
            new TechniqueEntrySeed("Tension before", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notes", "Where in your body does it feel lighter?", Suggestions: ["My shoulders relaxed", "My jaw unclenched", "My hands got warmer", "Breathing got easier", "I feel sleepy", "Some tension is still there", "Nothing changed"]),
            new TechniqueEntrySeed("Tension after", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "Progressive muscle relaxation is one of the best-studied ways to reduce anxiety and tension. Tensing a muscle and then letting it go creates a contrast that helps you notice relaxation and, over time, learn to bring it on. It is not a treatment but a skill that works better with practice.",
            "When your body is tight from stress, when it is hard to sit still or to fall asleep. It suits the evening before sleep well.",
            "Tense at about half strength, without pain. If a part of your body hurts or is injured, don't tense it; just notice it. While letting go, breathe calmly and don't rush to the next group.",
            "Tension 7/10 in the evening after work, shoulders up by my ears. Five groups: hands, shoulders, face, belly, legs. Tension 4/10, my shoulders dropped."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition BusyMind = new(
        "Practice", "Brief Attention Shift",
        [
            "1. Rate your tension only if that feels useful.",
            "2. Choose one neutral task for 30–60 seconds.",
            "3. Distracted? Gently return to the task once; do not criticize yourself.",
            "4. Stop and decide whether a practical step or support is needed."
        ],
        "A brief neutral task may shift attention for a moment when thoughts feel stuck in a loop. It does not remove thoughts or solve the problem.",
        TechniqueUiKind.Entry, "Technique #25", "26.10.2026", "Brief Attention Shift", "Pause repetitive thoughts", "Hard moment", "Psyche", 1, "Extension",
        [
            new TechniqueEntrySeed("Tension before", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityBefore),
            new TechniqueEntrySeed("Notes", "How was that brief pause?", Suggestions: ["My attention shifted for a moment", "Nothing changed", "I felt more frustrated or tense", "I can see a next step now", "I need support", "I stopped the exercise"]),
            new TechniqueEntrySeed("Tension after", "", EntryFieldKind.Rating0To10, Role: EntryFieldRole.IntensityAfter)
        ],
        Theory(
            "A short neutral task, such as naming objects of one colour, can sometimes help you get through an intense moment. It is a temporary shift of attention, not a way to eliminate thoughts; its effect varies from person to person and moment to moment.",
            "When repetitive thoughts have taken your attention and you want a brief pause. If there is an urgent problem or a safety or health concern, address it and seek appropriate help.",
            "Choose one simple task for 30–60 seconds; you do not need perfect focus. Then decide whether there is a practical step to return to. If the task frustrates you or makes things worse, stop and choose another approach.",
            "After an argument, the conversation keeps replaying. For half a minute, name five objects around you, then decide whether to clarify a fact, take a break, or ask for support."),
        null, null);

    internal static readonly BuiltInTechniqueDefinition ThoughtDefusion = new(
        "Practice", "Unhook from a thought",
        [
            "1. Notice one thought. Writing it down is optional.",
            "2. Say: “I’m noticing the thought that…”",
            "3. Notice one thing in front of you and the support beneath your feet.",
            "4. Choose one small next step, or stop here."
        ],
        "A brief acceptance and commitment therapy (ACT) skill: notice a thought as something the mind is doing, not necessarily a fact or a command.",
        TechniqueUiKind.Entry, "Technique #26", "03.11.2026", "Unhook from a thought", "Unhook from a worrying thought", "Thoughts", "Psyche", 1, "FormatQuote",
        [
            new TechniqueEntrySeed("Thought", "Optional: you can do the practice silently", Suggestions: HarshThoughts)
        ],
        Theory(
            "A repeating thought can take over your attention. In ACT, defusion means noticing the thought without arguing with it or trying to push it away.",
            "When one worry, self-critical thought, or fear keeps looping. You do not need to choose a distressing memory.",
            "You do not have to write anything down. Add “I’m noticing the thought that…” before the thought, look at one object, and feel the support beneath your feet. If distress rises, stop and name a few things around you.",
            "“I’ll ruin everything” becomes “I’m noticing the thought that I’ll ruin everything.” You notice the cup in front of you and decide whether to reply to one email or pause."),
        null, null);
}
