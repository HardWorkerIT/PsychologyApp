namespace PsychologyApp.Application.Articles;

public static partial class ArticleContent
{
    private static readonly Article[] AdditionalArticlesEn =
    [
        new(
            ArticleIds.CallNerves,
            "Nerves before a call",
            "Prepare for one conversation, not a perfect performance",
            "TipsAndUpdates",
            2,
            [
                P("A call can feel stressful because so much is unknown: who will answer, what they may ask, and how they will respond. Choose one practical aim, such as making an appointment, checking a time, or passing on information. That is enough; you do not need to script every line."),
                H("Give yourself a prompt"),
                P("Write down the person’s name, your aim, and an opening sentence: “Hello, I’m calling to ask about…”. Keep useful dates, reference numbers, or questions nearby. Decide that you can ask someone to repeat something. For a difficult conversation, it is okay to say, “I need a moment to think,” or arrange to continue later."),
                H("After the call"),
                P("Note what you learned and whether a next step is needed. Do not judge yourself by how smoothly you spoke; pauses and nerves do not erase the purpose of the call. If you could not get through, choose one next route: try later, write instead, or ask for help. If calls regularly keep you from important tasks, consider discussing it with a suitable professional.")
            ]),
        new(
            ArticleIds.WaitingForReply,
            "Waiting for a reply",
            "Live with uncertainty and choose a useful next step",
            "TipsAndUpdates",
            2,
            [
                P("Waiting for a reply can quickly fill with guesses: “I said something wrong,” “They are ignoring me,” or “This is urgent.” But silence alone does not explain why someone has not replied. They may be busy, away from their phone, thinking about what to say, or not ready to respond. Until you know more, try not to treat one explanation as a fact."),
                H("Separate the fact from the story"),
                P("For example, a message has been read but there is no reply. The facts are the read receipt and the time. “The relationship is over” is one possible explanation, not proof. You could name two other possibilities, including a neutral one. You do not have to convince yourself that everything is fine; it is enough to notice that you do not have much information yet."),
                H("Check whether action is needed now"),
                P("Is there a deadline, a safety concern, or a consequence that cannot wait? If so, do not rely only on a chat reply: use another appropriate channel, contact someone who can help, or reach local emergency services if there is immediate danger. If it is not urgent, choose a reasonable time to check again. There is no universal waiting period; use the situation and any agreements you have made."),
                H("Make a plan instead of checking repeatedly"),
                List(
                    "State what you know without adding a conclusion: “There is no reply yet.”",
                    "Ask what information you actually need and whether it is available another way.",
                    "Choose when you will check next, then move the chat out of sight.",
                    "Do a short task that does not depend on a notification."),
                P("If the reply matters and the agreed time has passed, you can send one brief, non-accusing follow-up: “Could you let me know whether you can reply today? If not, I’ll make another plan.” This makes your need clear while leaving room for an honest answer."),
                H("When this happens often"),
                P("Look at the wider pattern, not just one pause. At a calm time, discuss what response times matter to each of you and what to do when one person is unavailable. You can make a decision based on the information you have. Someone else’s silence does not measure your worth, and a neutral explanation does not require you to wait indefinitely.")
            ]),
        new(
            ArticleIds.AfterSocialEvent,
            "After a gathering: stop replaying every line",
            "Reflect without turning the conversation into self-criticism",
            "TipsAndUpdates",
            2,
            [
                P("After an important meeting or social event, the conversation may keep replaying in your mind. It is easy to focus on pauses, awkward phrases, or someone’s expression and conclude that everything went badly. But memory is not a complete recording: fatigue, anxiety, and what feels important now can shape what stands out."),
                H("Separate what you noticed from what you concluded"),
                P("Write down one specific moment: what did you actually say or do? Then note the judgment about yourself separately, such as “I am boring” or “They were disappointed.” That is an interpretation. What else could explain the moment? Perhaps the conversation ended quickly, the other person was in a hurry, or the topic was difficult. You do not have to choose the most positive explanation; simply avoid treating the anxious one as proven."),
                H("Does the conversation need a next step?"),
                P("Check whether there is a clear promise, question, or mistake that genuinely needs attention. If so, write down the action and when you will return to it, such as clarifying a detail tomorrow. If there is no such step, replaying the scene is unlikely to add information. You might tell yourself: “I have checked what I can; there are no new facts yet.”"),
                H("A brief way to close the event"),
                List(
                    "Name one neutral or pleasant moment without judging yourself as a whole.",
                    "If you have a question, save it for a calm follow-up.",
                    "Choose a transition to the present: water, quiet, a walk, or one small task.",
                    "If the thought returns, notice it and leave the review until the time you chose."),
                P("The aim is not to prove that the event went perfectly. It is enough to decide whether a useful action remains and allow the rest to stay uncertain. If these worries often interfere with connection or rest, consider discussing them with a professional."),
            ]),
        new(
            ArticleIds.FearOfMistakes,
            "A mistake is not a verdict",
            "Set a clear standard for good enough",
            "TipsAndUpdates",
            2,
            [
                P("Fear of getting something wrong can turn an ordinary task into an exam: you may recheck everything, wait for complete confidence, or put the task off. The aim is not to dismiss mistakes. It is to decide in advance what matters, what risk needs checking, and where a reasonable stopping point is."),
                H("Define what is sufficient before you begin"),
                P("Describe the result in observable terms: send a message with the required facts, prepare a draft, or meet the essential requirements. Then ask what a mistake could realistically affect and which check would reduce that risk. Safety, health, money, and important documents may require formal rules and careful review; “good enough” does not replace them."),
                H("When a mistake has already happened"),
                P("Separate the event from a judgment about yourself. Instead of “I ruined everything,” name the fact: “The file has the wrong date.” Work out who is affected, whether it can be corrected, and who needs to know. Responsibility means taking a useful corrective step, not punishing yourself indefinitely."),
                H("A brief review without self-attack"),
                List(
                    "What happened, stated as facts?",
                    "What is the actual impact, and what am I still guessing?",
                    "What step could correct or limit the impact?",
                    "What can I adjust next time without demanding perfection?"),
                P("If fear of mistakes regularly gets in the way of work, study, or relationships, consider discussing it with a professional. That does not mean something is wrong with you; it can help you find support that fits."),
            ]),
        new(
            ArticleIds.ChangeAnxiety,
            "When change feels worrying",
            "Separate what is known, unknown, and within your influence",
            "TipsAndUpdates",
            2,
            [
                P("Change can feel unsettling even when it is wanted: familiar routines shift while the outcome is unclear. Trying to plan every possibility can be exhausting without making the future predictable. Separate what you can do now from questions that do not have answers yet."),
                H("Use three columns"),
                P("Write what is known, unknown, and within your influence. For example, a move date may be set, the route may be unclear, and you can gather documents today. Look into an unknown first only if its answer could change your next decision."),
                H("Choose the nearest useful step"),
                P("What small action could help in the next day: confirm a deadline, prepare one item, speak with someone involved, or protect time to rest? If nothing can be done now, choose a specific time to revisit the question. This does not promise a good outcome; it keeps the task from occupying your mind all day."),
                List(
                    "Name what has actually changed.",
                    "Choose one open question that affects a decision.",
                    "Pick an action or a time to check again.",
                    "Leave the rest open until new information arrives."),
                P("If the change involves danger or serious consequences, confirm the facts and contact people or services that can help."),
            ]),
        new(
            ArticleIds.WorryBeforeTask,
            "Before a difficult task",
            "Start with a safe, bounded step",
            "TipsAndUpdates",
            2,
            [
                P("Before an important task, anxiety may tell you to wait until you feel completely sure or have a perfect plan. Readiness does not always come before starting. First identify what makes the task difficult: an unclear outcome, too much work, missing information, the possibility of a mistake, or a conversation with someone."),
                H("Choose the first piece"),
                P("Pick a 5–15 minute step that is safe to do: open the document, gather materials, read the instructions, or ask one clarifying question. Decide in advance where you will stop. If you need permission, expertise, or someone’s agreement, do not guess—write down who can clarify it."),
                H("Review the plan, not yourself"),
                P("After the first step, check what is clearer and what is still unknown. You can continue, pause, or change the plan. Stopping at the point you chose is part of keeping your agreement with yourself. If the task still feels too large, break it down further or ask for support instead of treating the difficulty as a lack of willpower.")
            ]),
        new(
            ArticleIds.AvoidedFirstStep,
            "Take only the first step",
            "Starting can take two minutes",
            "TipsAndUpdates",
            2,
            [
                P("When a task feels large or unclear, it is easy to avoid the whole thing. That is not always laziness: you may not know where to begin, have little energy, or feel that a mistake would cost too much. You do not need to promise yourself you will finish. Make the beginning visible and limited."),
                H("Turn the goal into an action"),
                P("“Work on the report” does not tell you what to do with your hands. “Open the file and write down three questions” does. A useful first step is brief, specific, and possible now. If it still feels stuck, make it smaller: open the document, find the right page, or write one heading."),
                H("Remove one obstacle"),
                P("Notice the main barrier: a missing file, too many materials, an unclear definition of done, or phone distractions. Remove just one. Organizing the entire process can become another way of postponing it."),
                H("A trial, not a promise"),
                P("Set a timer for five or ten minutes and allow yourself to stop when it ends. Then check what changed: is the task clearer, do you have energy to continue, or do you need information or help? Stopping as planned is a completed step too."),
                H("A plan for the next few minutes"),
                List(
                    "Write the desired result in one sentence.",
                    "Choose an action you can see or verify.",
                    "Prepare one useful item and remove one barrier.",
                    "After the short start, choose whether to continue, simplify, or ask for help."),
                P("If even small tasks remain unmanageable for a long time and this affects daily life, consider talking with someone you trust or a professional about your workload and available support."),
            ]),
        new(
            ArticleIds.CheckingLoop,
            "Check, then stop",
            "Set a clear purpose while keeping necessary safety checks",
            "TipsAndUpdates",
            2,
            [
                P("Repeated checking may ease worry briefly, then doubt returns: “What if I missed something?” Some checks are required. The aim is not to stop checking everything, but to distinguish a needed check from repetition without new reasons."),
                H("Before checking"),
                P("Before checking, name what you need to confirm, which source is reliable, and what will count as done. For a ticket, that might mean comparing the date and destination with the official document. Follow any rule that requires a second check; a personal limit does not replace a required process."),
                H("When doubt returns"),
                P("If doubt returns, ask whether circumstances, information, or requirements have changed. If so, check the changed part. If not, note that you completed the check using your chosen rule and move on. You do not need to wait until you feel completely calm."),
                H("A check with clear limits"),
                List(
                    "Name the purpose of the check.",
                    "Choose a reliable source and the required number of checks.",
                    "Mark it complete.",
                    "Return if new facts or safety requirements arise."),
                P("If repeated checking takes a lot of time or restricts daily life, consider professional support. Do not skip checks needed for safety.")
            ]),
        new(
            ArticleIds.PublicPlaceAnxiety,
            "Anxiety in a crowded place",
            "Reduce the load and keep room to choose",
            "TipsAndUpdates",
            2,
            [
                P("Noise, close crowds, waiting, or feeling unable to leave can increase anxiety. You do not have to force yourself to endure it or treat leaving as failure. First check the situation and choose a step that supports safety and choice."),
                H("Find an available anchor"),
                P("If possible, move somewhere quieter and notice the exit. You might name a few objects or feel your feet on the floor. These are options, not a ritual; skip body-focused attention if it feels uncomfortable."),
                H("Decide what comes next"),
                P("Ask whether changing your place or pace would help you stay. Would a pause, rescheduling, or calling someone you trust be better? Choose a step instead of demanding immediate calm. If there is danger, ask someone nearby to help you reach safety."),
                H("A brief plan"),
                List(
                    "Find a safe spot and locate the exit.",
                    "Reduce one trigger if possible.",
                    "Choose to stay, pause, leave, or ask for support.",
                    "Stop an exercise if it increases discomfort."),
                P("If these situations regularly interfere with life, discuss them with a professional. For immediate danger, contact local emergency services.")
            ]),
        new(
            ArticleIds.MorningWorry,
            "A morning without a list of worries",
            "Choose today’s priority and give the rest a time",
            "TipsAndUpdates",
            2,
            [
                P("In the morning, unfinished tasks can all feel urgent. Mentally planning the whole week can add strain and hide what truly needs attention today. A short plan helps choose the nearest action instead of trying to control everything at once."),
                H("Separate urgent from important"),
                P("Write down what worries you, then mark one item with a real deadline or consequence today. Choose its first step and a time. If it depends on someone else, note whom to contact or what help to request. Give the rest a specific time."),
                H("Check basic needs"),
                P("Before expecting high productivity, ask what would support your start: water, food, prescribed medication, quiet, or comfortable clothes. Scale the plan down if your health or circumstances change."),
                H("A plan for a few minutes"),
                List(
                    "What truly needs action today?",
                    "What is the smallest next step?",
                    "When will I return to the other questions?",
                    "What would support me physically right now?"),
                P("If morning worry often disrupts daily activities or sleep, consider discussing it with a professional.")
            ]),
        new(
            ArticleIds.SensoryOverload,
            "When there is too much noise and activity",
            "Reduce input and restore a sense of choice",
            "TipsAndUpdates",
            2,
            [
                P("Conversations, alerts, bright screens, and requests arriving together can overload attention. It may become harder to follow speech, make choices, or continue a familiar task. This signals strain, not a lack of effort. Start with one available change."),
                H("Reduce one source of strain"),
                P("Move somewhere quieter, mute a nonessential alert, dim the screen, or ask people to speak one at a time. If you cannot leave, reduce the number of tasks and ask for one instruction to be repeated. Choose changes that are safe and realistic."),
                H("Keep the option to stop"),
                P("If breathing exercises, closing your eyes, or body focus increase discomfort, stop and choose an external focus or a pause. You can say, “I need it a little quieter; I’ll answer later.” You do not have to explain more than you want."),
                H("A plan to reduce input"),
                List(
                    "Notice the strongest trigger.",
                    "Change one factor: sound, light, pace, or distance.",
                    "Postpone one nonessential decision.",
                    "Ask for help if you cannot leave or pause on your own."),
                P("If overload begins suddenly with severe symptoms or you cannot stay safe, seek help.")
            ]),
        new(
            ArticleIds.EveningTension,
            "End the day gently",
            "Carry unfinished tasks forward without planning all night",
            "TipsAndUpdates",
            2,
            [
                P("In the evening, unfinished tasks can feel like proof that the day was not good enough. Trying to solve everything in your head before bed can extend the workday. A brief note and a clear transition may help you set the tasks down for now."),
                H("Close the open loops"),
                P("Write what is done, what truly needs a next action, and what can wait. For an important task, note one concrete starting step for tomorrow and an approximate time. If you need to discuss a deadline or ask for help, write down whom to contact and when. You do not need to plan the whole week."),
                H("Choose a stopping signal"),
                P("Save the note and close the list. Then choose a simple action that marks the end of tasks for today: dim the lights, put materials away, wash up, or sit quietly. It cannot guarantee sleep, but it can help you stop working through tasks in bed."),
                H("Three evening notes"),
                List(
                    "What have I already done today?",
                    "Which task needs one next step?",
                    "What can wait until its planned time?"),
                P("If worry regularly interferes with sleep, discuss it with a healthcare professional.")
            ]),
        new(
            ArticleIds.AnxietyComedown,
            "After a wave of anxiety",
            "Regain a sense of safety before deciding whether to reflect",
            "TipsAndUpdates",
            2,
            [
                P("After intense anxiety, you may want to understand the cause immediately and make sure it never happens again. But analysing while exhausted can add strain. First check safety and give yourself time to return to a familiar pace."),
                H("Return to simple conditions"),
                P("If you are safe, choose a familiar, low-demand action: sit down, drink water, eat, get warm, or move somewhere quieter. You do not have to use a breathing technique or close your eyes. Stop anything that increases discomfort and choose another option."),
                H("Review only what could help"),
                P("Later, when it is easier to focus, note what was happening, what helped even a little, and whether there is a practical question for next time. You do not need to find one definitive cause or blame yourself. If action is needed, write the next step or whom you could discuss it with."),
                H("A gentle reset"),
                List(
                    "Check that you are in a safe place.",
                    "Choose one simple need or familiar activity.",
                    "Postpone analysis if it adds strain.",
                    "Return to usual tasks gradually."),
                P("If episodes recur, strongly affect daily life, or involve severe symptoms, seek professional help.")
            ]),
        new(
            ArticleIds.SafePractice,
            "Practice is not a test",
            "You can adapt an exercise or stop while staying in control",
            "TipsAndUpdates",
            2,
            [
                P("A practice is useful only when it fits you in the moment. Completing every step at any cost is not the goal. You can change the pace, skip part of an exercise, or end it."),
                H("Keep your options before you start"),
                P("Decide how you will stop and where you will turn your attention. You can keep your eyes open, shorten the time, change position, or choose an external focus. Breathing and body-awareness exercises do not suit everyone; choose an option that does not increase discomfort."),
                H("If discomfort appears"),
                P("Stop, return to your natural breathing, and look around. If it is safe, change position or move to a familiar simple activity. You do not need to push through to finish. If discomfort continues or grows, seek support."),
                H("Check before you begin"),
                List(
                    "Does this exercise fit me right now?",
                    "How will I know when to stop?",
                    "What will I choose instead if it feels uncomfortable?"),
                P("A practice does not replace professional care and should not replace urgent help when there is immediate danger.")
            ]),

        new(
            ArticleIds.ThoughtLabel,
            "Give a thought a name",
            "Notice it without arguing with it",
            "TipsAndUpdates",
            2,
            [
                P("A thought can sound convincing, especially when you are tired or anxious. Try adding: “I am noticing the thought that…” This does not prove the thought wrong. It separates a mental event from an established fact and can create a little room to choose what to do next."),
                H("Check what is known"),
                P("Briefly write what happened and what you inferred. Ask: “What did I directly observe? What is still an interpretation?” You do not need to analyse every thought or persuade yourself of the opposite. If it concerns an important decision, look for information that could genuinely change your next step."),
                H("Return to a chosen action"),
                P("Choose one small action connected to your task or values: open the document, ask a question, or take a pause. The thought may remain; you do not have to eliminate it first. If this exercise increases distress, stop and choose a form of support that feels more suitable.")
            ]),
        new(
            ArticleIds.MindReading,
            "Do not guess what others think",
            "Separate what you observed from what you inferred",
            "TipsAndUpdates",
            2,
            [
                P("When someone is quiet or replies briefly, the mind may quickly supply an explanation: “They are angry” or “I ruined it.” Those are possibilities, but not the only ones. It helps to separate what you actually saw or heard from the meaning you gave it."),
                H("Check when it is appropriate"),
                P("If the relationship and question matter, ask calmly and specifically: “Have I understood correctly that…?” or “When would be a good time to talk?” Do not demand an immediate answer from someone who is busy. If clarification is not useful now, acknowledge the uncertainty and wait for more information."),
                H("Do not turn a guess into a verdict"),
                P("Hold more than one explanation in mind: the person may be busy, tired, or may not have seen the message. None has to be correct. The aim is not to replace one certainty with another, but to avoid treating an assumption as proof. Then decide whether a real next step is needed or whether you can return to your own plans.")
            ]),
        new(
            ArticleIds.WorstVsLikely,
            "The worst outcome is not the most likely",
            "Prepare without living through it in advance",
            "TipsAndUpdates",
            2,
            [
                P("Anxiety can present the hardest outcome as if it has nearly happened. Instead of arguing with yourself, consider three possibilities: a difficult outcome, a favourable one, and the most plausible one given what you know. This is neither a prediction nor a promise that things will go well; it is a way to make room for more than one possibility."),
                H("Separate preparation from replaying"),
                P("Choose one useful step for the most plausible outcome. If the worst outcome would have serious consequences, make a brief, reasonable plan for what you would do and whom you would contact. You do not need detailed plans for every imagined scenario. Ask what new information would change your view, and seek only that information."),
                H("Leave uncertainty open"),
                P("If useful, note one fact for and one against each possibility. If there is no information yet, label it “unknown.” Then return to something you can do now. If there is an actual threat, respond to the facts and seek practical help; this exercise is not a substitute.")
            ]),
        new(
            ArticleIds.EvidenceAndUnknown,
            "What I know and what I do not",
            "Do not fill a gap with an anxious guess",
            "TipsAndUpdates",
            2,
            [
                P("When an answer is missing, an anxious explanation can feel like a fact. Separating what is known from what is unknown will not remove uncertainty, but it can keep a guess from driving your decisions. Write down facts separately from open questions."),
                H("Ask what you can actually find out"),
                P("For each question, decide where reliable information might come from, whom you could ask, or when to revisit it. Look only for information that could change an action. Repeatedly checking the same source usually does not create new evidence."),
                H("Leave open questions open"),
                P("If there is no answer now, label it “unknown for now.” Choose a time to check again or set the question aside. Then return to something available to you. Uncertainty can feel uncomfortable, but it does not always need to be closed immediately.")
            ]),
        new(
            ArticleIds.NegativityFilter,
            "Notice more than what went wrong",
            "Add one more fact to the picture",
            "TipsAndUpdates",
            2,
            [
                P("After a difficult event, attention can stick to mistakes and miss neutral or helpful moments. This does not mean you should make the situation sound better than it was. The task is simply to check whether one part has become the whole story."),
                H("Restore some context"),
                P("Name what went wrong, then add one other relevant fact: what you did, what remained ordinary, who helped, or what you learned. A neutral detail counts. You do not need to search for praise if that feels out of place right now."),
                H("Use the fuller picture for your next step"),
                P("Ask whether the added fact changes what you need to do. If so, choose an action. If not, you can acknowledge the difficulty without turning it into a verdict about yourself. One good moment does not cancel a hard one; it can make your view more accurate.")
            ]),
        new(
            ArticleIds.ConversationReplay,
            "Stop replaying the conversation endlessly",
            "Check whether there is new information or an action",
            "TipsAndUpdates",
            2,
            [
                P("After a conversation, it is easy to revisit every phrase and guess what the other person thought. A brief review can help if it leads to clarity or repair. Repeating it without new information often only drains you."),
                H("Separate a conclusion from a next step"),
                P("Write down a specific fact, commitment, or question that truly needs an answer. If you want to clarify or repair something, choose a short message and an appropriate time. You do not need to send several messages to reach absolute certainty."),
                H("If nothing is new, pause"),
                P("Name what is happening: “I am replaying this, but I have no new information.” Shift to an activity that brings your attention to the present. If the issue still matters, set a time to decide calmly whether a conversation is needed. You do not have to decide right now.")
            ]),
        new(
            ArticleIds.DecisionFatigue,
            "Simplify a small choice",
            "Decide in advance what is good enough",
            "TipsAndUpdates",
            2,
            [
                P("Small decisions can accumulate, especially when each one requires a fresh comparison. For recurring choices, a rule set in advance can help: a time, budget, or quality limit. This does not mean rushing important decisions. Give those a separate moment and consider them carefully."),
                H("Keep the choice small"),
                P("For a decision that is easy to revisit, keep two acceptable options and compare them against one criterion. For example: which will be easier to maintain this week? Limiting options helps protect attention; it is not a way to find a perfect answer."),
                H("Revisit only when something changes"),
                P("Write down the choice and what would make you reconsider it, such as changed circumstances or an important new fact. If nothing has changed, try following your decision. If it affects safety, health, or a major commitment, do not use a shortcut in place of a proper check.")
            ]),
        new(
            ArticleIds.GoodEnough,
            "Good enough is still a result",
            "Limit unnecessary polishing",
            "TipsAndUpdates",
            2,
            [
                P("When work matters, it makes sense to want to check it again. Without a stopping rule, though, edits can continue after the result is already usable. Before you start, decide what must be true and where you will stop."),
                H("Set a finish line"),
                P("Choose two or three observable requirements and a way to check them. For example, an email should communicate the request, include the right date, and get one check for obvious typos. Then save or send it. The criteria should fit the task; they do not need to demand perfection in every respect."),
                H("Return only for a specific reason"),
                P("Wanting to check again does not by itself mean there is an error. Reopen the work if you find a concrete problem, receive new information, or need a required change. This helps distinguish useful correction from polishing in search of impossible certainty.")
            ]),
        new(
            ArticleIds.ControlInfluence,
            "What I can influence and what I cannot",
            "Focus on an action available to you",
            "TipsAndUpdates",
            2,
            [
                P("When a situation depends on other people or circumstances, trying to control every part can be exhausting. Separating what you can do from what you cannot does not make the situation fair or remove real constraints. It helps you decide where to place your effort."),
                H("Find your circle of action"),
                P("Ask: what can I say, prepare, request, or decide? Choose one specific step. For what is outside your influence, consider a boundary, support, or a time to check again. Sometimes the available action is to say no, ask for help, or report a problem."),
                H("Do not take responsibility for someone else"),
                P("You can make a clear request, but you cannot guarantee the response. Notice where your part ends, and do not turn another person’s decision into a measure of your worth. If the issue involves actual danger or a rights violation, seek practical support instead of relying only on a change in perspective.")
            ]),
        new(
            ArticleIds.SelfTalkReset,
            "Change the tone of your self-talk",
            "Be respectful and specific with yourself",
            "TipsAndUpdates",
            2,
            [
                P("Self-criticism can sound like motivation: “If I’m hard on myself, I’ll get it together.” But insults do not explain what to do next. A respectful tone does not mean excusing an action or ignoring its impact. It helps you describe the situation accurately and keep room to respond."),
                H("Replace a label with an observable fact"),
                P("Try replacing “I’m irresponsible” with “I missed the deadline and have not told the team yet.” The first is a judgment about your whole character; the second names an event and an action you can address. The more specific the description, the easier it is to choose a next step."),
                H("A sentence for a difficult moment"),
                P("Use three parts: what happened, what it affected, and what you will do now. For example: “I answered sharply, the conversation became tense, so I’ll return to it and clarify what I meant.” If you caused harm, acknowledging it and trying to repair it matters more than making the wording sound positive."),
                H("Check for honesty and respect"),
                List(
                    "Name the fact without “always” or “never.”",
                    "Notice a feeling or consequence without treating it as proof that you are a failure.",
                    "Choose one manageable step: repair, clarify, apologize, or ask for support.",
                    "Use the tone you would use with someone you care about, while staying honest."),
                P("You do not have to believe a new phrase right away. It is enough for it to be more accurate and useful. If self-criticism becomes constant or painful, professional support may help."),
            ]),
        new(
            ArticleIds.WorryAboutWorry,
            "Worrying about being worried",
            "Do not demand that you calm down at once",
            "TipsAndUpdates",
            2,
            [
                P("When you notice anxiety, a second thought may appear: “I should not react this way.” That can add pressure. The first reaction has already happened; you do not have to criticise yourself for it. The aim is not to force calm, but to choose a manageable action while anxiety is present."),
                H("Name both reactions"),
                P("Try noticing: “I feel anxious, and now I am worried about feeling anxious.” You do not need to argue with it or find perfect words. Then ask whether there is a practical reason to act: prepare, ask for support, or address a specific issue."),
                H("Measure success by the chosen step"),
                P("Ask what you wanted to do before anxiety appeared, and choose a smaller version of that step. Afterwards, notice the action or pause, not how calm you became. If anxiety often limits daily life, consider discussing it with a mental health professional.")
            ]),
        new(
            ArticleIds.CompareHighlightReel,
            "Do not compare your life with someone else's showcase",
            "A feed shows selected moments, not a whole life",
            "TipsAndUpdates",
            2,
            [
                P("Posts usually show one moment, not someone’s ordinary worries, doubts, and routines. Comparing your everyday life with another person’s highlight can leave you feeling behind. That feeling is real, but it does not establish your worth or tell the whole story."),
                H("Name what you are longing for"),
                P("Close the post for a moment and ask what feels missing right now: rest, connection, money, recognition, or time for something important. You do not have to dismiss the wish. You are noticing a need, not committing to change your whole life immediately."),
                H("Choose one small step toward your own life"),
                P("If possible, take one practical step: message someone, plan a rest, or return to your own project. If no step is available now, simply name that. Someone else’s success does not take away your possibilities; a break from the feed may help you reconnect with your own pace.")
            ]),
        new(
            ArticleIds.IntrusiveThoughts,
            "An unwanted thought is not an intention",
            "Consider actions, context, and safety",
            "TipsAndUpdates",
            2,
            [
                P("Thoughts can sometimes be disturbing, frightening, or contrary to your values. Having a thought does not by itself prove that you want to act on it. You do not have to test whether you are a “good person” through endless checking or searches for complete certainty."),
                H("Avoid feeding a checking loop"),
                P("If you are safe, try briefly labelling it “an unwanted thought” without analysing it again and again. Return to an ordinary activity or an external point of focus. If the thought is connected to an actual intention, plan, or immediate risk to you or someone else, treat that as a safety issue: move away from means of harm and contact a trusted person, professional, or emergency service urgently."),
                H("Seek support if it is disrupting life"),
                P("If these thoughts are frightening, time-consuming, or interfering with daily life, tell a mental health professional. You can describe how often they occur, how they affect you, and what helps without trying to diagnose yourself.")
            ]),
        new(
            ArticleIds.OneThingAtATime,
            "One task at a time",
            "Make your focus specific and finite",
            "TipsAndUpdates",
            2,
            [
                P("Switching between messages, tabs, and tasks can feel busy while making it harder to notice when anything is done. You do not need to focus all day. Try one short block with a visible result: check three lines, answer one email, or read a few pages."),
                H("Make it easier to return"),
                P("Before starting, silence only the alerts and close only the windows that tend to pull you away, when that is practical. Keep a “later” note nearby: write down new tasks rather than acting on each immediately. If interruptions are unavoidable, leave yourself a quick marker: where you stopped and what comes next."),
                H("End the block deliberately"),
                P("When the timer ends or you reach your chosen result, pause and decide whether to continue, switch tasks, or rest. If focus did not come, make the step smaller or check whether fatigue, hunger, or an uncomfortable setting is getting in the way. This is not a productivity contest; it is a way to reduce mental clutter and choose your next action more clearly.")
            ]),

        new(
            ArticleIds.MoodMovement,
            "A little movement when energy is low",
            "Try a gentle step without needing to feel energized",
            "TipsAndUpdates",
            2,
            [
                P("When energy is low, even ordinary movement can feel like another task. You do not have to convince yourself that a short walk will improve your mood. You can simply check what action feels possible and how it feels. The aim is not a workout, but a considerate check-in with your body."),
                H("Choose what feels manageable"),
                P("You might stretch while seated, walk to a window, change position, or spend a few minutes outside. Choose the duration and leave yourself room to stop. If you have health limitations, follow your clinician’s advice; movement should not cause pain or require pushing through discomfort."),
                H("Notice without grading yourself"),
                P("Afterward, ask: is anything more comfortable, unchanged, or more tiring? Any answer is useful and does not mean you did something wrong. If rest is what you need, choose rest. If low energy is persistent or sudden, consider discussing it with a health professional.")
            ]),
        new(
            ArticleIds.PleasureMastery,
            "Enjoyment and a sense of completion",
            "Notice different ways an activity can support you",
            "TipsAndUpdates",
            2,
            [
                P("Some activities feel pleasant in the moment; others bring a sense of completion or connection to what matters. These are different experiences, and none has to follow every task. When you are tired, it may help to notice an activity’s actual effect instead of expecting instant enjoyment."),
                H("Plan without overloading yourself"),
                P("Choose one small option from any category that fits: enjoyment—listen to one song or make tea; completion—clear one surface or answer one email; connection—send a brief message to someone you trust. You can choose just one. Consider time, energy, access, and whether you actually want to do it."),
                H("Review the experience gently"),
                P("Afterward, note separately whether it felt pleasant and whether you felt “I finished something.” If neither changed, that is not failure and not a reason to force a repeat. You may need rest, a different format, or a smaller step. These observations can make future plans more realistic, not become a score of your worth.")
            ]),
        new(
            ArticleIds.EnergyBudget,
            "Budget energy as well as time",
            "Plan for recovery along with demands",
            "TipsAndUpdates",
            2,
            [
                P("Two tasks that take the same amount of time can require very different effort. When planning, count travel, preparation, concentration, and emotional load as well as hours. A schedule with no room for transitions or pauses can be too crowded even when the calendar looks open."),
                H("Leave some margin"),
                P("Choose one essential task and, if there is capacity, one small one. Put a simple break or lighter activity between demanding tasks. You do not need to fill every free space. If the schedule depends on other people, keep a possible alternative or ask which tasks take priority."),
                H("Adjust using what you learn"),
                P("At the end of the day, notice which items took more energy than expected and whether you had enough recovery. Treat that as information for the next plan, not a reason to criticize yourself. On an unpredictable day, reduce the list to what matters most and move the rest.")
            ]),
        new(
            ArticleIds.RestBreak,
            "Take a break without guilt",
            "Rest can help with the next choice",
            "TipsAndUpdates",
            2,
            [
                P("When there is a lot to do, rest can feel like a reward you must earn first. A pause can instead be an ordinary part of managing effort, not proof of weakness. It does not have to make you more productive; it can simply give you a chance to notice how you are doing and decide what comes next."),
                H("Match the break to the kind of tiredness"),
                P("If your eyes and attention are tired, a few quiet minutes away from a screen may help. If your body feels stiff, change position or stretch gently if that is comfortable. If noise is overwhelming, move somewhere calmer. Water, food, fresh air, or a conversation with someone you trust may fit better. There is no universal method; choose what is safe and available."),
                H("Do not turn the pause into another task"),
                P("Choose an approximate length and one simple activity: sit by a window for five minutes or take a short walk. You do not need to judge whether you are resting correctly. When the pause ends, you can take one next step, reschedule something, ask for help, or stop for today."),
                H("When rest never fits"),
                P("Ongoing exhaustion is not always solved by stricter planning. Look at whether some work can be reduced, moved, or divided; which deadlines can be discussed; and what support you could request. Not every task depends only on personal discipline."),
                H("A gentle break plan"),
                List(
                    "Notice what is tired: attention, body, or emotions.",
                    "Choose a short pause that fits right now.",
                    "Set aside one demand of yourself while resting.",
                    "Afterward, decide what truly needs to continue."),
                P("If fatigue lasts, disrupts daily activities, or raises health concerns, speak with a medical professional. This article is not a substitute for individual care."),
            ]),
        new(
            ArticleIds.StartFriction,
            "Remove one obstacle before you start",
            "Prepare the next step, not the whole process",
            "TipsAndUpdates",
            2,
            [
                P("When starting feels hard, “just get organized” may not explain what is in the way. The task may be unclear, the file hard to find, materials unavailable, or the first step too large. Pick one specific barrier you can check instead of redesigning your whole day."),
                H("Make the entry point easier"),
                P("If the task is unclear, write down a question or ask what outcome is expected. If setup is the problem, open the document or put materials where you can see them. If your phone pulls you away, set it aside for one short block when practical. Avoid turning preparation into another large task."),
                H("See whether it helped"),
                P("Try starting after changing just one condition and notice whether it feels easier. If not, undo what did not help and check another possible cause. The barrier may depend on someone else—for example, you may need access, a decision, or assistance. Then the next step is a clear request, not trying to overcome everything alone.")
            ]),
        new(
            ArticleIds.TransitionRitual,
            "Pause when moving between tasks",
            "Leave a note for unfinished work and name what comes next",
            "TipsAndUpdates",
            2,
            [
                P("After an interruption, it can be hard to remember where you stopped, while unfinished work keeps taking up attention. A brief transition can capture that and make the next start calmer. This is not a required ritual or a way to work without breaks—just a prompt if it helps you."),
                H("Close the previous task"),
                P("Write one line about what is done and what remains. Save the file or put materials somewhere easy to find. If you are waiting for a reply, note who you are waiting for and when you will check. You do not need to tidy your entire workspace."),
                H("Choose what to do next"),
                P("Name the first visible action for the next task, then set the previous one aside. The transition can take less than a minute: save, note, name. If pausing increases tension or you need rest, do not force the routine. After trying it a few times, keep only the parts that actually help.")
            ]),
        new(
            ArticleIds.TaskActivation,
            "When starting feels hard",
            "Attach one tiny action to a familiar cue",
            "TipsAndUpdates",
            2,
            [
                P("Waiting for motivation can postpone a task, but you do not have to begin with the full workload. Choose an action that only opens the task: open the document, read the instructions, or write a heading. This is a start, not a promise to finish everything."),
                H("Use a clear cue"),
                P("Link the action to an ordinary event: “After breakfast, I’ll open the file and look at the first line.” Be specific about where and when, and remove one obstacle in advance. If you miss the cue, choose another moment; one missed start does not cancel the plan."),
                H("Choose what happens after the start"),
                P("After the small step, check your capacity and choose whether to continue briefly, pause, or stop. Starting counts; the amount completed does not define your effort. Sometimes difficulty means the task is unclear, too large, or requires support. If it often interferes with daily life, consider discussing it with a suitable professional.")
            ]),
        new(
            ArticleIds.GentleRoutine,
            "A flexible routine instead of a perfect one",
            "Keep one steady point, not a rigid schedule",
            "TipsAndUpdates",
            2,
            [
                P("A routine can help by reducing how many decisions you have to make each day. But a detailed schedule can become a source of guilt when something changes. Choose one repeatable anchor—for example, planning after breakfast—and let the rest of the day stay flexible."),
                H("Make the habit resilient"),
                P("Link an action to an event, not only a time: open the curtains after waking, or check one message after lunch. Prepare an easy version for a harder day: take one breath by the window instead of walking, or write one priority instead of a full list. The minimum should be genuinely doable."),
                H("Return without punishment"),
                P("If you miss the habit, resume at the next suitable opportunity; you do not need to make up for it. If it no longer helps or has become burdensome, change it or let it go. A routine should adapt to your life and needs, not become a test of discipline.")
            ]),
        new(
            ArticleIds.WakeAtNight,
            "If you wake during the night",
            "Lower the pressure and let sleep return in its own time",
            "TipsAndUpdates",
            2,
            [
                P("Waking at night does not mean the rest of the night is lost. Repeated clock-checking and counting the hours can add pressure. If you can, avoid looking at the time and do not demand that you fall asleep immediately. Make the setting as calm and safe as you reasonably can."),
                H("Choose a quiet activity"),
                P("If lying in bed becomes uncomfortable and sleep is not returning, you might get up briefly and do something quiet in dim light. Return to bed when you feel sleepy again. You do not have to follow advice that feels uncomfortable; consider your safety, how you feel, and your clinician’s guidance."),
                H("Set tomorrow’s worries aside"),
                P("If thoughts about tasks keep repeating, write down one task or question and leave it for the morning. In the morning, keep your usual routine as much as possible without demanding too much to compensate for the night. If sleep problems persistently affect your wellbeing or daily life, discuss them with a health professional.")
            ]),
        new(
            ArticleIds.SmallDayPlan,
            "A day plan with some breathing room",
            "Choose what matters and leave space for life",
            "TipsAndUpdates",
            2,
            [
                P("A plan can provide direction when it reflects your actual energy and allows for surprises. A long list rarely shows how much time travel, transitions, and rest take. Start by asking: what truly matters today, and what can move without serious consequences?"),
                H("Keep the plan short"),
                P("Write down one main task, one small everyday step, and a pause for food or recovery. Leave an open block between them. If a task is vague, define a visible result: not “deal with paperwork,” but “find the form I need.” Keep remaining tasks on a separate list."),
                H("Revise as the day unfolds"),
                P("If circumstances change or your energy drops, adjust the plan: shrink a step, move an item, or ask for help. At the end of the day, consider whether the plan helped you find your way—not how many boxes you checked. A plan is a working support you can change, not a promise to do everything.")
            ]),
        new(
            ArticleIds.AskForHelpTask,
            "Ask for help with one specific part",
            "Describe the task so it is easy to respond",
            "TipsAndUpdates",
            2,
            [
                P("Asking for help can feel awkward, especially if you are used to managing alone or worry about being a burden. A specific request reduces uncertainty and helps someone understand what you need. You do not have to prove that you are tired enough or have earned support."),
                H("Narrow the request"),
                P("Name one task, its scope, and a useful deadline: “Could you look over the first paragraph of this email today?” Say what you have already done and ask whether the timing works. Leave room for the person to decline or suggest a smaller version. If you need help thinking something through, say roughly how much time you are asking for."),
                H("Think of another route"),
                P("If the person cannot help, that is not necessarily a judgment of you or the relationship. Consider making the task smaller, moving the deadline, or asking someone else. If the request is about safety or an urgent need, do not stop at one refusal—seek suitable support.")
            ]),
        new(
            ArticleIds.MeaningfulActivity,
            "Choose a small action that matters to you",
            "Connect one step with something you value",
            "TipsAndUpdates",
            2,
            [
                P("When energy is low, the point of a larger task can disappear. Instead of asking, “What should I get done?”, try, “What matters to me in this situation?” It might be care, connection, curiosity, reliability, or rest. A value is not a checklist item or a measure of productivity; it is a direction that can help you choose an action."),
                H("Make the value concrete"),
                P("Choose a five- or ten-minute action in that direction: send someone a kind message, open the document you need, water a plant, or go to bed earlier. Make the step small enough to begin without waiting to feel motivated. If recovery matters most right now, rest can be a meaningful action too."),
                H("Notice the experience, not just the outcome"),
                P("Afterward, notice what was there: interest, tiredness, relief, or nothing in particular. You do not have to force a sense of satisfaction. If the action was unsuitable or unavailable, adjust it or leave it for later. Meaning does not require a big result, and it does not erase real limits.")
            ]),
        new(
            ArticleIds.FlexibleGoals,
            "Keep the direction; adjust the method",
            "A goal can change shape when circumstances change",
            "TipsAndUpdates",
            2,
            [
                P("Plans are often made under one set of conditions and carried out under another. If a plan has become unmanageable, that is a reason to review it, not to blame yourself. Separate three things: the direction you care about, the specific goal, and the method for reaching it. Sometimes the meaning can stay while the deadline or workload changes."),
                H("Choose a workable level"),
                P("You can set three versions in advance: a minimum for a hard day, a usual step, and an extra amount if you have capacity. For exam preparation, that might mean opening your notes and reading one page, reviewing one topic, or studying the whole section. Choose a minimum that still helps you move forward rather than becoming a punishment."),
                H("Review deadlines and agreements"),
                P("If other people depend on the goal, tell them about a delay early and suggest a realistic new estimate. Look for barriers that keep returning: an unclear next step, too little time, fatigue, or missing resources. Revising a plan is a way to manage conditions; sometimes it is also reasonable to change the goal or ask for help.")
            ]),
        new(
            ArticleIds.CelebrateCompletion,
            "Notice a finished step before rushing on",
            "A brief pause can make effort visible",
            "TipsAndUpdates",
            2,
            [
                P("After finishing something, attention often jumps straight to what remains. The day can then feel like an uninterrupted chain of unfinished tasks. Pause briefly and name a fact without exaggerating it: “I sent the email,” “I asked for help,” or “I rested when I was tired.” This is not a required gratitude ritual or a way to pretend everything is wonderful."),
                H("Notice what helped"),
                P("If useful, add one observation: which step worked, what took effort, or what support made a difference. That turns acknowledgment into information for next time instead of a judgment about your worth. Do not compare your pace with someone else’s or dismiss what you did because more remains."),
                H("Choose the next transition"),
                P("After the pause, decide what fits now: continue, switch tasks, ask for support, or stop for today. Finishing does not always mean doing everything perfectly; sometimes it means stopping at an agreed and safe point. On a hard day, you can recognize the effort without needing to feel happy about it.")
            ]),

        new(
            ArticleIds.NameEmotion,
            "Name the feeling more specifically",
            "It can help you see what kind of support is missing",
            "TipsAndUpdates",
            2,
            [
                P("“I feel bad” communicates that things are hard, but it may not suggest what could help. If you can, add one detail: worried, lonely, irritated, ashamed, hurt, or tired. You do not need the perfect word or an explanation for anyone else."),
                H("Separate the feeling from the situation"),
                P("Ask yourself: what happened, what am I feeling, and what matters to me right now? Anger, for example, can sit alongside exhaustion; anxiety may come with missing information. Write down what you notice without turning it into a judgment about yourself or someone else’s intentions. If you cannot find a word, start with what you notice in your body or surroundings."),
                H("Choose a small response"),
                P("Consider whether you need a pause, more clarity, contact with someone you trust, or a safer place. Naming a feeling does not require acting on it immediately. Sometimes noticing it and postponing a decision until you feel steadier is enough. If the distress feels unbearable or you cannot keep yourself safe, seek urgent help.")
            ]),
        new(
            ArticleIds.MixedFeelings,
            "You can have two different feelings at once",
            "Conflicting reactions can coexist",
            "TipsAndUpdates",
            2,
            [
                P("Changes, close relationships, and decisions rarely bring just one reaction. You can be excited about an opportunity and sad about what you are leaving behind; want connection and also need time alone. Mixed feelings do not prove that you are inconsistent or have made the wrong choice."),
                H("Make room for both sides"),
                P("Try finishing two sentences: “I feel glad because…” and “I feel sad or worried because…”. You do not have to make either side cancel the other or decide which one is the “real” feeling. If your thoughts are tangled, write them separately or talk with someone who will not rush you toward an answer."),
                H("Decide with values and circumstances in mind"),
                P("Feelings offer information, while decisions can also consider safety, facts, commitments, and what matters to you. Choose a next step that does not require denying either side. It may help to wait, gather information, or discuss the choice with someone you trust.")
            ]),
        new(
            ArticleIds.AngerPause,
            "Pause before replying in anger",
            "Reduce risk first, then decide what to say",
            "TipsAndUpdates",
            2,
            [
                P("When anger rises, attention can narrow and words or actions may escalate the conversation. If it is safe, stop messaging or suggest a brief pause: “I want to talk about this, but I need time to cool down. I’ll come back to it later.” Name a realistic time to return if you are willing."),
                H("Use the pause to lower intensity"),
                P("Move to a calmer place, drink some water, or shift to a neutral activity. Do not send messages to punish or frighten the other person, and do not drive if you feel too activated. When you are calmer, separate what happened from blame and decide what request or boundary you want to express."),
                H("Safety matters more than the conversation"),
                P("If there is a risk of violence, threats, or being followed, do not try to resolve the conflict alone. Go somewhere safer, contact someone you trust, or reach emergency services. A pause does not obligate you to resume the conversation; you may end it if continuing would be unsafe.")
            ]),
        new(
            ArticleIds.ShameKindness,
            "Meet shame without humiliating yourself",
            "You can repair a mistake without punishing yourself",
            "TipsAndUpdates",
            2,
            [
                H("Separate the feeling from the facts"),
                P("Shame can turn one action into a verdict on your whole identity: “I made a mistake” becomes “I am a bad person.” Describe the situation specifically and without labels: what did you say or do, what happened next, and who was affected? This does not remove responsibility; it helps identify what can be addressed."),
                H("Acknowledge impact without guessing"),
                P("If your words or actions affected someone, acknowledge that directly and briefly. You might say, “I interrupted you, and I can see that may have felt dismissive.” You do not need to lead with your intentions or ask for forgiveness. Ask whether they are open to discussing what might help repair things, and respect their answer."),
                H("Choose a realistic repair"),
                P("An apology, correcting an error, or changing a specific behavior may be appropriate. Some consequences cannot be undone quickly, and showing change over time may matter more. Choose one real step without promising what you cannot guarantee. Punishing yourself does not rebuild trust or repair harm."),
                H("Keep self-respect in the picture"),
                P("Try speaking to yourself as someone who is accountable and still deserves respect: “I regret what I did. I can acknowledge it and decide what to do next.” Self-kindness is not an excuse. It can keep your attention on responsibility and action instead of an endless stream of self-insults."),
            ]),
        new(
            ArticleIds.GuiltRepair,
            "Guilt: repair something or let it go",
            "Separate responsibility from endless self-blame",
            "TipsAndUpdates",
            2,
            [
                P("Guilt can point to a boundary you crossed or harm you caused. But feeling guilty does not prove that you are responsible for everything. Look at a specific action rather than passing a verdict on your whole self."),
                H("If you caused harm"),
                P("Name what happened and what can realistically be repaired. If appropriate, offer a specific apology without making excuses and ask what the affected person wants. An apology does not require them to forgive you or continue contact. Take a reasonable repair step and change what is within your control."),
                H("If it is not yours to carry, or you have made amends"),
                P("Check whether you are taking responsibility for someone else’s feelings, circumstances, or choices. Once you have made a reasonable repair, endless self-punishment does not help the person who was hurt. You can acknowledge regret, learn from it, and choose what to do next. A complex or painful situation may be worth discussing with a professional.")
            ]),
        new(
            ArticleIds.EnvyInformation,
            "Envy can point to something you want",
            "Turn comparison into a direction of your own",
            "TipsAndUpdates",
            2,
            [
                P("Envy can feel uncomfortable and may tempt you to judge yourself. The feeling does not define whether you are a good person. Sometimes it points to a wish that has not had much attention: more freedom, recognition, closeness, or time for something meaningful."),
                H("Name the need behind the comparison"),
                P("Ask what exactly you envy and which part you genuinely want in your own life. Separate the value you want from the other person’s way of pursuing it. Independence may matter to you even if that person’s route to it would not suit you."),
                H("Choose a manageable step without copying"),
                P("Consider one action for this week: ask for more responsibility, contact someone close, or make time to practise a skill. You may find the wish came from comparison rather than your own values; then you can let it go. The aim is not to become someone else, but to hear your own direction more clearly.")
            ]),
        new(
            ArticleIds.AllowSadness,
            "Sadness does not have to disappear right away",
            "Make room for the feeling and choose support",
            "TipsAndUpdates",
            2,
            [
                P("Loss, a breakup, disappointment, or exhaustion can come with sadness. You do not have to explain it immediately or force yourself to cheer up. You can acknowledge “this is hard right now” even if you do not yet know what to do about it."),
                H("Choose a gentle source of support"),
                P("Ask what is available now: some time alone, a message to someone close, food, rest, or one necessary task. You do not need to do everything at once. When asking for support, be direct: “I do not need a solution; could you stay with me?” or “Could you help with one specific task?”"),
                H("Care for yourself without demanding a mood change"),
                P("Basic needs still matter when sadness does not lift after one step. If it continues to disrupt daily life or becomes heavier, consider professional support. Asking for help does not mean you have failed; it may be the next available way to be supported.")
            ]),
        new(
            ArticleIds.Numbness,
            "When it is hard to feel anything",
            "Do not force yourself to open up at once",
            "TipsAndUpdates",
            2,
            [
                P("Numbness or a sense of emptiness can feel unsettling. The feeling alone cannot tell you what caused it. You do not have to make yourself cry, revisit memories, or explain everything immediately. Start with a neutral point of reference and what could help you through the next few minutes."),
                H("Check simple needs"),
                P("Notice where you are, what time it is, and what your body may need: water, food, warmth, rest, or a quieter place. Choose only what is available. You might message someone close: “I cannot find the words right now; could you stay in touch for a bit?”"),
                H("Seek support if it persists"),
                P("If the numbness frightens you, lasts, or makes self-care and daily tasks difficult, discuss it with a professional. Do not automatically attribute new, severe, or painful symptoms to an emotional state; seek medical assessment when appropriate.")
            ]),
        new(
            ArticleIds.EmotionWave,
            "A feeling can change, even if not right away",
            "Notice it without using a stopwatch",
            "TipsAndUpdates",
            2,
            [
                P("A strong feeling can seem permanent, especially while you are in the middle of it. It may change gradually, in waves, or not yet change at all. You do not have to wait for it to disappear before caring for yourself or choosing a safe next step."),
                H("Notice without demanding a lower number"),
                P("If it helps, name the feeling and rate its intensity from zero to ten. The rating is not a test: you do not have to make the number smaller. You can also notice where you are, what happened beforehand, and what offers a little support now."),
                H("Choose an action for the next few minutes"),
                P("Try one simple support: sit down, drink water, move away from noise, or contact someone you trust. Later, you can check in again and compare only with your own earlier experience. If it has not changed, that is not failure; choose another kind of support or seek help if coping feels difficult.")
            ]),
        new(
            ArticleIds.BodyNoticingChoice,
            "Notice your body at a comfortable pace",
            "An outside anchor is also an option",
            "TipsAndUpdates",
            2,
            [
                P("Attention to breathing and body sensations helps some people and increases discomfort for others. You can stop a body scan at any time. The aim is not to find the correct sensation, but to choose a safe way to orient yourself that suits you now."),
                H("Try a brief check-in"),
                P("If it feels comfortable, notice one neutral detail: your feet on the floor, your back against a support, or the temperature of the air. You do not need to change your breathing or make yourself relax. Stay with the observation only as long as it feels okay."),
                H("Shift focus if discomfort grows"),
                P("If focusing on your body increases anxiety, open your eyes and name a few things around you, such as their colour or shape. You do not have to return to body sensations. Do not automatically attribute new, severe, or painful symptoms to anxiety; discuss them with a clinician.")
            ]),
        new(
            ArticleIds.PauseBeforeReact,
            "Pause between an impulse and a reply",
            "First decide whether waiting is safe",
            "TipsAndUpdates",
            2,
            [
                P("A strong feeling can push you to send a message, agree, or refuse immediately. A short pause can help you check whether your response fits your goal. But waiting is not always helpful: if delay creates risk or affects something important, reply briefly and clearly now."),
                H("Save a draft"),
                P("Decide what you want to do: share a fact, ask a question, set a boundary, or agree on a time. If waiting is safe, draft your message and leave it for a few minutes. Then remove blame or phrases that do not serve your goal. A slow breath may help you pause, but it does not have to change how you feel."),
                H("Choose a response for the situation"),
                P("Reread the message and check whether your request or information is clear. You can reply briefly, ask for time, or return to the conversation later. If safety, a deadline, or urgent help is involved, do not use a pause to avoid it; communicate what is needed or seek support.")
            ]),
        new(
            ArticleIds.EmotionalBoundary,
            "Someone else's feelings are not yours to fix",
            "You can care and still keep your boundaries",
            "TipsAndUpdates",
            2,
            [
                P("When someone close is struggling, it is easy to feel responsible for finding a solution or removing their distress. Support does not require taking responsibility for another person’s feelings or choices. Your care can be warm and still have limits."),
                H("Ask what kind of help would be useful"),
                P("Try: “Would it help if I listened, helped with one specific thing, or thought through options with you?” Offer only what you can genuinely do, such as a ten-minute conversation or help with one task. Do not promise constant availability if you cannot provide it."),
                H("State your boundary clearly"),
                P("You might say: “I care and can talk now, but I cannot solve this for you.” If you cannot help, suggest another resource only when appropriate. If there is immediate danger, do not rely on personal support alone; involve a trusted person, professional, or emergency service.")
            ]),
        new(
            ArticleIds.SupportWithoutFixing,
            "Be there without fixing everything",
            "Ask what kind of support is needed",
            "TipsAndUpdates",
            2,
            [
                P("People often offer advice out of care, but advice can feel like pressure during a difficult moment. Before suggesting a solution, ask whether the person wants listening, company, or practical help. This respects their choice and reduces the chance of solving the wrong problem."),
                H("Offer a specific, limited option"),
                P("Ask: “Would you like me to listen, stay with you, or help think through a next step?” If they choose to talk, listen without interrupting with advice or demanding details. Offer only help you can follow through on: a set amount of time, a call, or one concrete task."),
                H("Protect your capacity and safety"),
                P("You can care and still say “I cannot right now.” Do not promise secrecy about an immediate threat. If the person or someone nearby is in danger, involve a trusted adult, professional, or emergency service; do not become the only source of support.")
            ]),
        new(
            ArticleIds.AfterCrying,
            "After crying, give yourself time",
            "Start with simple needs, not an explanation",
            "TipsAndUpdates",
            2,
            [
                P("After intense crying, you might feel tired, shaky, numb, or relieved; people respond differently. You do not have to explain the tears or force yourself to calm down. Check the immediate situation: are you somewhere safe? Do you need water, warmth, a comfortable position, or another person nearby? Choose only what feels suitable."),
                H("Make the next step very small"),
                P("You might wash your face, drink some water, wrap up, or simply sit. If those actions do not help or feel unpleasant, there is no need to do them “correctly.” Put off major decisions until you have more capacity. If you want, message someone you trust: “I’m having a hard time. Could you stay in touch for a bit?”"),
                H("Return to activities gradually"),
                P("When you are ready, choose one small task or rest. Crying does not mean you are weak or back at the beginning. If crying often interferes with daily life, your wellbeing is getting worse, or you cannot stay safe, reach out to a professional; seek emergency help if danger is immediate.")
            ]),

        new(
            ArticleIds.SpecificRequest,
            "Make a specific request",
            "Brief context, an action, and a suitable time",
            "TipsAndUpdates",
            2,
            [
                P("Hints and long explanations can hide what you are asking for. Try a simple structure: brief context, a specific action, and a time. For example: “I’d like to talk about the schedule. Do you have ten minutes after dinner today?” This does not guarantee agreement, but it gives the other person something clear to respond to."),
                H("Leave room for choice"),
                P("Ask whether now works and be ready for a no or another time. If it is not urgent, offer two options. Do not add a threat or guilt to get agreement. If you are setting a boundary, also say what you will do yourself."),
                H("Check what the answer means"),
                P("If a yes is vague, clarify the time or next step. If there is no answer yet, agree when to revisit it or decide what you can do independently. In an unsafe situation, an ordinary conversation may not be enough; choose a safer way to get support.")
            ]),
        new(
            ArticleIds.ListenReflect,
            "Understand first, then respond",
            "Check the meaning before offering advice",
            "TipsAndUpdates",
            2,
            [
                P("In a tense conversation, it is easy to prepare your reply while the other person is still speaking. Briefly reflecting what you heard can check your understanding and give them a chance to correct it. This is not a way to win an argument; it helps you avoid responding to something they did not say."),
                H("Summarize one main point"),
                P("Choose one idea: “If I understood, you were upset that the plans changed without warning?” Then pause and let the person clarify. Do not immediately add a defense, diagnosis, or solution. If you are unsure, ask what you missed."),
                H("Ask what would help now"),
                P("You might ask: “Would you like me to listen, or should we think through what to do?” Reflecting a point does not mean agreeing with every judgment or giving up your boundaries. If the conversation becomes unsafe or too intense, pause and return only under suitable conditions.")
            ]),
        new(
            ArticleIds.BoundarySentence,
            "A boundary is clearer when it speaks about you",
            "Say what works for you and what you will do",
            "TipsAndUpdates",
            2,
            [
                P("A boundary is not a way to make someone behave differently. It is a clear statement of what is acceptable to you and what you will do if a situation continues. Choose one specific event instead of explaining the whole relationship. If speaking directly could lead to threats or violence, do not rehearse it alone; consider safety and support first."),
                H("Keep it brief and use “I”"),
                P("Try this structure: “When X happens, Y is difficult for me. I am asking for Z; if it continues, I will do W.” For example: “I can discuss this without insults. If they continue, I will end the call.” Promise only an action you can take yourself. You do not have to prove that your boundary is valid or get the other person to agree."),
                H("Repeat once, then follow through"),
                P("If you are drawn into an argument about whether you are allowed to set a boundary, calmly repeat it without adding new defenses. Then do what you said, if it is safe. Someone may be upset by a boundary, and it can still matter. If circumstances change, you may revise it or ask for help maintaining it.")
            ]),
        new(
            ArticleIds.NoWithoutEssay,
            "You can say no without a long defense",
            "Be clear without proving that your reasons are good enough",
            "TipsAndUpdates",
            2,
            [
                P("Saying no may disappoint someone or invite questions, and you may worry that the relationship will suffer. If refusing is safe, a clear sentence is enough. You can care about the other person and still decline. Decide what you can actually offer before answering; do not promise something you cannot or do not want to do just to relieve pressure."),
                H("Choose words that fit"),
                P("You might say, “Thanks for asking, but I can’t this time,” “I don’t have capacity for this right now,” or “That time does not work for me.” You may offer another option if you want to, but an alternative is not required. You also do not have to share every personal reason. Being kind does not mean being vague."),
                H("Handle follow-up pressure"),
                P("If the person keeps asking, repeat your answer briefly instead of supplying a new reason each time. You can end the conversation or reply later. If a direct refusal could bring threats, control, or harm, put safety first: involve someone you trust, choose a safer way to communicate, or leave if you can.")
            ]),
        new(
            ArticleIds.DifficultTalkOpening,
            "Give a difficult conversation a small goal",
            "Start with one event and one request",
            "TipsAndUpdates",
            2,
            [
                P("A difficult topic can quickly turn into a judgment about the whole relationship. Before talking, write down one goal: what do you want to clarify, solve, or simply let the other person know? Then choose one specific event and one request. If you are angry, exhausted, or afraid, it is okay to pause; the conversation does not have to happen immediately."),
                H("Describe the event and its effect"),
                P("Choose a time when you both have some calm and enough time. Say what you observed, how it affected you, and what change you would like to try. For example: “When plans change at short notice, I struggle to arrange childcare. Could we try to let each other know earlier?” Avoid claims about motives such as “You always” or “You don’t care.”"),
                H("Leave room for a response"),
                P("Listen to how the other person understood you, then clarify one misunderstanding or agree on a workable next step. If the conversation gets too heated, arrange a pause and a time to return. If speaking directly could lead to violence or retaliation, do not treat communication skills as protection; seek help from someone you trust or a professional service.")
            ]),
        new(
            ArticleIds.RepairAfterConflict,
            "Return to a conversation after an argument",
            "Check readiness and choose one point to clarify",
            "TipsAndUpdates",
            2,
            [
                P("After an argument, you may want to explain everything immediately or never return to it. Before trying to clarify, ask whether the other person is willing to talk and check whether you feel ready. A modest first conversation can aim to understand one moment, not resolve the whole relationship."),
                H("Stay with one specific event"),
                P("Describe what happened without labels or guesses about motives. Name your part, if there is one, and ask how the other person saw it. Listening to their account does not mean you automatically agree. If your accounts differ, clarify one fact or what a phrase meant instead of arguing about everything at once."),
                H("End the conversation with care"),
                P("Name what is clearer and what might come next: a small agreement, another conversation, or time to think. If tension rises, agree on a pause. If there are threats, intimidation, or fear, do not pursue reconciliation at any cost: end the conversation, move somewhere safe, and seek support.")
            ]),
        new(
            ArticleIds.ApologyResponsibility,
            "Apologize with accountability and boundaries",
            "Name the specific action without excusing its impact",
            "TipsAndUpdates",
            2,
            [
                P("A useful apology focuses on the action and its impact, not on proving you are a good person. Be specific: “I interrupted you, so you could not finish.” Acknowledge the effect and say you are sorry without adding “but you did this too.” Your intentions can be discussed separately if the other person wants to."),
                H("Offer a realistic repair"),
                P("Say what you will try to do differently next time and ask whether one small repair would help now. Do not promise something you cannot deliver. The other person does not owe immediate forgiveness or reassurance; give them time and accept their response."),
                H("Accountability does not require giving up safety"),
                P("You can own a specific mistake while still declining insults, pressure, or accusations you believe are untrue. Do not use an apology to obtain forgiveness or restart contact. If the conversation becomes unsafe, stop and create safe distance.")
            ]),
        new(
            ArticleIds.FeedbackAsInformation,
            "Separate feedback about work from your worth",
            "Look for specific information, not a verdict about you",
            "TipsAndUpdates",
            2,
            [
                P("A comment about one result can sound like a judgment of your whole self, especially when it is unexpected or delivered sharply. Pause and separate three things: the exact words, an observable fact, and the conclusion you drew about yourself. “The report needs an example” describes the work; “I cannot do anything right” is a global judgment."),
                H("Clarify the feedback"),
                P("If the comment is vague, ask for one example and what change would be noticeable. Choose one realistic point to try in your next piece of work. Not every delivery is useful: insults and humiliation do not become constructive just because they are called feedback."),
                H("Decide what to do next"),
                P("You do not have to respond immediately. You can note the useful part, think it over later, or ask someone who knows the context. If the feedback conflicts with facts or an agreement, clarify that calmly. One task and one evaluation do not define all of your abilities.")
            ]),
        new(
            ArticleIds.ReceiveNo,
            "When someone says no",
            "A refusal of one request is not always a rejection of you",
            "TipsAndUpdates",
            2,
            [
                H("Clarify what the answer applies to"),
                P("“No” may refer to a particular request, the timing, or one option. Avoid drawing a quick conclusion about the relationship or your worth unless the person has said that. If it is appropriate, you can calmly check: “Do you mean this isn’t possible right now?”"),
                H("Respect the boundary"),
                P("When the refusal is clear, do not turn clarification into pressure. The other person may decline or choose not to explain. You can feel disappointed, take a pause, and decide what to do next. Accepting the answer does not mean you must agree that it is fair in every way; it means not trying to obtain agreement through pressure."),
                H("Find another route"),
                P("If the need remains, separate the need from this particular source of help. You might ask once about a different time or option if the person seems open to that. Otherwise, consider whom else to ask, which part you can handle yourself, or whether the task can wait."),
                H("Make room for disappointment"),
                P("Name the feeling plainly: “I’m disappointed; I was counting on help.” You do not have to convince yourself the refusal does not matter or that you should feel calm immediately. When the first reaction settles, review your options and choose one next step. One declined request does not define your worth."),
            ]),
        new(
            ArticleIds.CheckAssumption,
            "Check a guess with a question",
            "Clarify the meaning before building a story",
            "TipsAndUpdates",
            2,
            [
                P("An unclear message leaves room for guesses: a short reply may seem cold, and a pause may feel deliberate. But one signal rarely gives the whole picture. Before drawing a conclusion, separate what you observed from what you inferred."),
                H("Ask one neutral question"),
                P("If the answer matters, ask: “Did I understand correctly that…?” or “Did you mean…?” Leave out accusations and avoid sending a string of messages. If the answer is not urgent, give the person time; choose when you will check again instead of refreshing the chat constantly."),
                H("Decide whether more clarity is needed"),
                P("If clarification would not change what you do, you can leave the question open. If it would, wait for an answer or explain what you need to know and by when. If the conversation is unsafe, choose another route or seek support. The aim is useful clarity, not absolute certainty.")
            ]),
        new(
            ArticleIds.AskSupport,
            "Ask for support by naming what would help",
            "A clear request can make it easier to begin",
            "TipsAndUpdates",
            2,
            [
                P("Asking can feel difficult when you are already struggling. You may fear rejection, judgment, or becoming a burden. Start by identifying what would help right now: being heard, thinking through options, practical help, or simply not being alone. The request can be small and limited in time."),
                H("Name the support and the time"),
                P("Be specific: “Today has been rough. Could you listen for ten minutes without advice?” or “Could you help me book an appointment? I am finding it hard to start.” Ask whether now works for the other person. They can agree, decline, or suggest another option. You do not have to tell the whole story to justify asking."),
                H("If it does not work this time"),
                P("A no or a busy moment does not always mean that you are not valued. Consider asking another trusted person, choosing a different kind of support, or making the request smaller. If you are in immediate danger or cannot keep yourself safe, do not rely on one loved one alone; involve emergency or professional support.")
            ]),
        new(
            ArticleIds.ConflictNotFailure,
            "Disagreement does not always mean a relationship is over",
            "Notice how you treat each other",
            "TipsAndUpdates",
            2,
            [
                P("Differences of opinion can happen even in close relationships. What matters is not only what is said during a disagreement, but what happens afterwards: whether people listen, take responsibility, and change specific behaviour. One argument alone cannot answer every question about a relationship’s future."),
                H("Discuss one issue at a time"),
                P("If you are both safe and willing to talk, choose one event or request. Describe what happened, how it affected you, and what specific change might help. Ask how the other person saw it. You do not have to agree on everything or solve it all in one conversation."),
                H("Do not put reconciliation above safety"),
                P("Respect and responsibility need to be mutual; they are not yours alone to provide. If there are threats, violence, control, or fear for your safety, focus first on protection and support. A reconciliation conversation is not required and may not be safe.")
            ]),
        new(
            ArticleIds.MakeExpectationsClear,
            "State expectations in advance",
            "Do not wait for someone to guess",
            "TipsAndUpdates",
            2,
            [
                P("Everyday conflict can come from different ideas about timing, roles, or what “finished” means, not from bad intentions. “We’ll do it later” might mean today to one person and next week to another. Clarifying early can reveal a mismatch before it turns into resentment."),
                H("Agree on concrete details"),
                P("Before doing something together, discuss who will do what, by when, and what counts as complete. Ask the other person to say the agreement back in their own words, or confirm it briefly in writing. This cannot guarantee agreement, but it makes expectations visible."),
                H("Update the agreement when plans change"),
                P("If timing or capacity changes, let the other person know early and suggest a new option. Discuss the problem and next step instead of assigning motives. If you cannot agree, decide what you can do separately and where more help is needed.")
            ]),
        new(
            ArticleIds.DigitalBoundaries,
            "Boundaries in messaging",
            "Notifications do not have to run your day",
            "TipsAndUpdates",
            2,
            [
                P("Frequent alerts break attention and can create the feeling that every message needs an immediate reply. But being constantly available is not the same as caring. You can choose a communication routine that fits your responsibilities and relationships, when it is safe and practical."),
                H("Set expectations and notifications"),
                P("Choose a time for ordinary messages and turn off sounds or previews for those that can wait. If useful, tell people close to you when you usually reply. Agree on a clear separate way to reach you for urgent situations so important messages are not missed."),
                H("Leave room to adjust"),
                P("Try the routine for a few days and check whether important messages still get through and whether it is easier to focus. If your circumstances change, update the rule. This is not a ban on contact; it is a way to respond with more attention without being available every minute.")
            ]),
        new(
            ArticleIds.FamilyPressure,
            "When family members pressure you with advice",
            "Thank them and say you will decide",
            "TipsAndUpdates",
            2,
            [
                P("Advice may come from care, but repeated persuasion can still be tiring. You can acknowledge someone’s concern without accepting their decision for you. A short statement is often clearer than a long explanation that invites debate over every point."),
                H("Prepare a calm response"),
                P("For example: “I hear that you are worried. I will think about it and decide.” If the topic continues, repeat the same sentence, suggest returning to it later, or change the subject. You do not need agreement in order to state your decision."),
                H("Consider safety first"),
                P("A direct response does not fit every relationship. If disagreement could lead to threats, violence, loss of housing, or another risk, do not test the boundary alone. Discuss a safety plan with someone trustworthy or a professional, and choose a time and way to respond that reduces risk.")
            ]),
        new(
            ArticleIds.FriendshipInvitation,
            "Invite someone without making a big plan",
            "A small invitation is easier to accept or decline",
            "TipsAndUpdates",
            2,
            [
                P("When you would like to meet, arranging a big plan can feel like a lot. A specific, low-key invitation reduces uncertainty: it helps the other person picture the plan and answer. A no or a busy day reflects their availability now, not your worth."),
                H("Make the invitation simple"),
                P("Name an activity, day, and approximate length: “Would you like to take a twenty-minute walk after work on Thursday?” Add that another time or a no is okay. You do not have to apologise for inviting them or explain why you want to meet."),
                H("Make room for any answer"),
                P("After sending it, wait instead of sending several follow-ups. If they cannot make it, offer one alternative if they seem interested, or leave the next move to them. If there is no reply, return to your own plans and decide later whether you want to try again.")
            ]),
        new(
            ArticleIds.SmallConnection,
            "Start with a small connection",
            "Contact does not have to begin with a deep conversation",
            "TipsAndUpdates",
            2,
            [
                P("Loneliness can make the first step feel unusually hard. You do not have to become sociable overnight or find a close friend right away. Choose a low-pressure contact: send an acquaintance one line, greet a neighbor, spend time near people in a familiar place, or join a conversation about a neutral topic. A small step is an experiment, not a test."),
                H("Match the contact to your capacity"),
                P("Think about what usually feels manageable: a message, a short call, a group activity, or simply being in a familiar public place. You can set a time limit and plan how to leave if you get tired. Choose a person and setting with less pressure. If there is no reply, do not use one moment to judge your worth; try another time or format."),
                H("Notice what suits you"),
                P("Afterward, note what felt comfortable, what took energy, and how long you needed to recover. The goal is not to count conversations or endure an unpleasant setting. If loneliness keeps interfering with daily life or your wellbeing is getting worse, consider reaching out to a trusted person or professional.")
            ]),

        new(
            ArticleIds.OrientNow,
            "Check where you are now",
            "A gentle way to orient to the present",
            "TipsAndUpdates",
            2,
            [
                H("Orient without rushing"),
                P("When attention is pulled into the past or an anxious future, it can sometimes help to notice what is around you. This is not a way to force yourself to calm down or a test of how focused you are. Keep the goal modest: notice a few neutral facts about the present, then choose where to place your attention next."),
                H("Name simple facts"),
                P("Keep your eyes open if that feels more comfortable. Look around and name where you are, roughly what part of the day it is, and one nearby object. You might describe its color, shape, or purpose. Then notice one more neutral cue, such as a sound outside, a line on the wall, or light on a surface. You do not need to find meaning in it."),
                H("Make the exercise your own"),
                P("Choose only observations that do not feel overwhelming. You do not have to list many details, move, touch anything, or focus on breathing. You could repeat one sentence: “I am here; it is morning; there is a table in front of me.” If words do not come, simply looking at an object is enough."),
                H("Check whether it suits you"),
                P("After a few seconds, ask yourself whether things feel a little clearer, unchanged, or more uncomfortable. Any answer is okay. If distress increases, stop and switch to something that feels safer; you can ask someone you trust to stay with you. You do not have to achieve calm or push through."),
            ]),
        new(
            ArticleIds.GroundingChoice,
            "Choose grounding that suits you",
            "Not everyone is comfortable focusing on the body",
            "TipsAndUpdates",
            2,
            [
                H("Grounding is a choice, not a rule"),
                P("Grounding often means a brief exercise for noticing the present, but there is no single version that works for everyone. Some people prefer looking at objects or listening to a sound; attention to breathing or the body can feel uncomfortable for others. You can skip any method and stop at any time."),
                H("Start with something outside you"),
                P("Choose one simple detail nearby: name a color, find an object with straight lines, or describe what an object is used for. Another option is to notice a steady background sound without trying to identify its source. Stay with one cue for a few seconds, then check how you feel."),
                H("Notice body sensations only if you want to"),
                P("If it feels comfortable, notice the support of a chair, the position of your feet, or the fabric of a sleeve. You do not need to scan your whole body, change position, or close your eyes. If body awareness brings pain, numbness, strong tension, or unwanted memories, skip it and choose an outside object instead."),
                H("Keep permission to change course"),
                P("Ask yourself: is this manageable, neutral, or making things harder? If manageable, you can continue briefly. If nothing changes, that is information, not failure. If you feel worse, stop. The aim is not to guarantee relief; it is to find support that suits you without pressure."),
            ]),
        new(
            ArticleIds.AfterNightmare,
            "After a nightmare, return gently to the present",
            "You do not have to interpret or replay the dream",
            "TipsAndUpdates",
            2,
            [
                P("After a nightmare, your body may keep reacting as if danger were still present. Do not demand that you fall asleep immediately or understand what the dream means. If it feels okay, turn on a light, look around, and remind yourself, “That was a dream; I am awake now.” You might name where you are, today's date, or one familiar object. If focusing on your surroundings or body makes you more distressed, stop and choose something else."),
                H("Choose a calm next step"),
                P("Sit comfortably, drink some water, or do a familiar quiet activity. If it helps, message someone you trust; if you do not want to wake anyone, you can leave a light on. You do not have to write the dream down or discuss it in the night. Return to bed when you feel ready rather than following a strict schedule."),
                H("If nightmares keep recurring"),
                P("Notice only details that may help you talk with a professional, such as how often they happen and how they affect sleep and daytime life. You do not need to find a symbolic explanation on your own. If nightmares regularly disrupt rest or connect to a difficult experience, discuss them with a healthcare professional or psychologist. If danger is immediate, focus first on safety and urgent help.")
            ]),
        new(
            ArticleIds.AnniversaryReaction,
            "A difficult date can call for a gentler plan",
            "A reaction may come before, during, or after the date",
            "TipsAndUpdates",
            2,
            [
                P("Dates connected with loss, change, or a painful event can bring different reactions. Distress may appear beforehand, on the day, or afterward; some people notice little or no reaction. None of these responses means you are grieving or coping “wrong.” You do not owe anyone an explanation for why the date matters to you."),
                H("Decide how you want to spend the day"),
                P("If possible, leave fewer commitments and decide in advance whom you could message or call. You may remember the person or event in your own way, spend the day as usual, or skip rituals entirely. Make a backup plan in case the day becomes too difficult: leave early, pause, or ask someone to stay with you."),
                H("Leave room to recover"),
                P("Think about what would help afterward: an easy meal, sleep, an unplanned evening, or talking with someone close. Do not compare your feelings with someone else’s or force yourself to mark the date. If distress keeps disrupting daily life, discuss support with a professional; if your safety is at immediate risk, seek urgent help.")
            ]),
        new(
            ArticleIds.PaceRecovery,
            "Recover at your own pace",
            "Do not turn self-care into a marathon",
            "TipsAndUpdates",
            2,
            [
                H("Rest is not another plan to complete"),
                P("When life feels hard, self-care advice can become a long list of obligations. If your energy is low, even a useful practice may feel like another demand. Recovery does not have to be quick or look the same every day. You can choose one small support, or choose not to add anything today."),
                H("Choose a manageable minimum"),
                P("Ask what feels possible: drink some water, eat, put your phone aside briefly, open a window, or message someone you trust. Choose an action that fits your actual circumstances. You do not need a timer or a quota if that adds pressure; limits are useful only when they help you stop."),
                H("Notice the effect without grading yourself"),
                P("Afterward, notice what changed: a little easier, about the same, or harder? This is not a score for your discipline. If a practice does not suit you, stop or choose a different kind of support. Sometimes the useful discovery is that you need quiet, food, sleep, practical help, or another person nearby."),
                H("Ask for help before you are depleted"),
                P("If daily tasks remain difficult for a while, you do not have to wait until you can manage everything alone. Tell someone close what has become hard, or discuss how you are feeling with a professional. Asking for help is a practical step, like resting; you do not first have to prove you tried everything."),
            ]),
        MiniArticle(ArticleIds.SafetyFirst, "Safety matters more than an exercise", "Self-help does not require staying in danger", "If there is a threat nearby, first try to get somewhere safer and contact someone who can help. Breathing and grounding do not replace protection, medical care, or emergency services. If you cannot leave on your own, ask a specific nearby person to call for help."),
        new(
            ArticleIds.ChooseTrustedPerson,
            "Choose someone you can ask for support",
            "Ask for specific help that feels manageable",
            "TipsAndUpdates",
            2,
            [
                P("When things are hard, it can seem as if you need to explain everything at once. A first request can be brief. Think of someone who usually respects your boundaries and can listen calmly. They do not have to be the closest person in your life if that relationship does not feel safe."),
                H("Say what would help"),
                P("For example: “I am having a hard time. Could you talk with me for ten minutes?” or “Could you help me decide whom to call?” If speaking feels difficult, send a short message you agreed on in advance or ask for company without questions. Check whether now is a good time for them."),
                H("Have another option ready"),
                P("A supportive person may be busy or unsure how to respond. That does not mean your request was wrong. Think in advance of someone else you could contact or a local professional service. If there is immediate danger, contact emergency support rather than waiting for one person to reply.")
            ]),
        new(
            ArticleIds.AfterStressRecovery,
            "After a stressful event",
            "Give yourself time to return to ordinary tasks",
            "TipsAndUpdates",
            2,
            [
                P("After a stressful event, attention and energy may be limited. You do not have to analyse everything immediately or return to your usual pace at once. First check what you need for the next hour and which task truly cannot wait."),
                H("Start with one simple support"),
                P("Choose something available: drink water, eat, change clothes, spend a little time in quiet, or message someone close. If the task list feels heavy, move one non-urgent item to a specific later time. Do not require yourself to feel better after each step."),
                H("Consider whether more support would help"),
                P("If the effects continue to disrupt sleep, work, study, or daily life, talk with a professional or clinician. Do not automatically attribute new or severe physical symptoms to stress. You can ask for help before things become unbearable.")
            ]),
        MiniArticle(ArticleIds.FlashbackGrounding, "When the past feels close again", "Orient to the present and keep your choices", "Look around and name where you are and today's date if helpful. Choose a visible object or contact someone nearby. Do not force yourself to close your eyes, breathe deeply, or tell details; seek real help if you are in danger. You can stop orienting if it intensifies the experience. Move toward a safe person or place; seek urgent help if there is immediate danger."),
        new(
            ArticleIds.RecoveryNotLinear,
            "Recovery is not a straight line",
            "A difficult day does not erase your progress",
            "TipsAndUpdates",
            2,
            [
                P("Strong feelings can return after a calmer period because of fatigue, a reminder, or new circumstances. That does not prove your efforts have disappeared or that you are back at the beginning. Instead of judging yourself as a whole, look at what is happening today and what might help you through this stretch."),
                H("Make the next step manageable"),
                P("Ask what you could simplify, postpone, or do with someone else today. Choose one basic need and one manageable task. Use something that helped before only if it still fits; you are allowed to choose another approach."),
                H("Reach out again if needed"),
                P("If the strain is growing, disrupting daily life, or becoming difficult to manage alone, contact someone you trust or a professional. Reaching out again is part of caring for yourself, not proof that progress is gone. If you are in immediate danger, seek urgent help.")
            ]),

        new(
            ArticleIds.BreathIsOptional,
            "Breathing practice is optional",
            "Do not force yourself to change your breathing",
            "TipsAndUpdates",
            2,
            [
                H("You do not have to focus on breath"),
                P("Breathing exercises do not suit everyone and are not needed for every difficult moment. Paying attention to each breath can increase tension or uncomfortable sensations for some people. You can skip this practice, let your breathing remain natural, and choose another anchor. That does not mean you are doing anything wrong."),
                H("If you choose to try"),
                P("Get comfortable and simply notice your ordinary breathing for a few seconds, without counting, holding, or trying to breathe more deeply. You might notice fabric moving on your chest only if that feels comfortable. A brief try is enough; there is no required rhythm or duration."),
                H("Stop if it feels uncomfortable"),
                P("If you feel dizzy, more anxious, short of breath, or uncomfortable focusing on breathing, stop the exercise and return to your usual breathing. Shift to an outside cue, such as a color or object. Do not try to “correct” the feeling with deeper breaths or breath-holding."),
                H("When medical assessment matters"),
                P("This practice cannot identify the cause of breathlessness or replace care. New, significant, or quickly worsening shortness of breath needs medical assessment; for sudden severe worsening or immediate danger, contact local emergency services. If a clinician has recommended a breathing technique for a medical reason, follow their individual instructions."),
            ]),
        new(
            ArticleIds.GroundingCanChange,
            "When grounding does not help",
            "Switch methods or stop",
            "TipsAndUpdates",
            2,
            [
                H("No effect is not your fault"),
                P("A grounding exercise may not suit you right now. It is not required to change your mood quickly, and not feeling relief does not mean you did it wrong. Focusing on sensations, breathing, or memories can sometimes increase anxiety. If that happens, pay attention to your response instead of pushing on."),
                H("Pause and choose again"),
                P("Stop if you feel worse, dizzy, detached, or simply want to stop. Open your eyes if they were closed and look at a neutral object, but only if that feels comfortable. You do not need to take deep breaths, count sensations, or repeat steps until you get a “right” result."),
                H("Try a lower-effort option"),
                P("If you want to continue, choose a simpler outside cue: read a sign, name one color, or notice where the door is. You can also set exercises aside and do an ordinary, steady activity. Avoid trying several techniques in a row if that adds pressure."),
                H("When another person may help"),
                P("If it is hard to stay safe on your own, contact someone you trust and say what would help: company, support with a practical task, or help reaching a professional. If there is immediate danger, contact local emergency services. You can decline an exercise and still deserve support."),
            ]),
        new(
            ArticleIds.MovementAnchor,
            "Use movement as an anchor",
            "A small movement can restore a sense of choice",
            "TipsAndUpdates",
            2,
            [
                H("Movement is only one option"),
                P("A small movement can be an anchor if it feels comfortable in your body right now. It does not have to improve your mood or look like exercise. You can choose a very small action, watch movement around you, or use a still object instead; these options are equally valid."),
                H("Choose a stable position"),
                P("First make sure you are sitting or standing safely, with no risk of losing your balance. If comfortable, slowly open and close your fingers, gently turn your wrists, or notice the support under your feet. One movement within a comfortable range is enough; you do not need to stretch, stand up, or repeat a set number."),
                H("Pay attention to your response"),
                P("Notice what happens as you move. If it feels neutral or pleasant, you can continue for a few seconds. Stop if you feel pain, dizziness, weakness, or more anxious. Do not push through a symptom for the sake of a practice; you can switch to a visual anchor or ask for help."),
                H("Finish without judging the result"),
                P("When you are ready, simply stop moving and choose what comes next: sit for a while, return to an ordinary activity, or contact someone. There is no need to compare your movement with how you used to move. If new or significant physical symptoms make movement difficult, discuss them with a healthcare professional."),
            ]),
        new(
            ArticleIds.SensesAnchor,
            "An anchor through the senses",
            "Choose one neutral signal around you",
            "TipsAndUpdates",
            2,
            [
                H("One signal is enough"),
                P("When the environment feels full of input, you can choose just one neutral signal instead of following a long checklist. For example, notice one color, an object’s shape, a steady sound, or the temperature of the air. You do not need to find five things, close your eyes, or use every sense."),
                H("Choose what feels manageable"),
                P("An anchor should feel neutral enough for you. Bright light, noise, smells, and touch can distract or irritate. If a signal feels unpleasant, do not make yourself stay with it. You can move to a quieter spot, look at a familiar object, or skip this practice altogether."),
                H("Adapt for access and comfort"),
                P("If looking around is difficult, you might name a familiar object from memory or notice one quiet sound. If sounds are distracting, choose a shape or color. With vision, hearing, or mobility limitations, use any cue that is accessible; you do not have to rely on sight, sound, or touch specifically."),
                H("Check whether it suits you now"),
                P("Stay with the chosen cue for a few seconds, then ask whether things feel more comfortable, unchanged, or harder. You do not need to reach a particular state. If discomfort increases, switch or stop. Choosing a different cue is not a mistake; it is a way to respect your limits."),
            ]),
        MiniArticle(ArticleIds.EarlyStressSigns, "Notice early signs of overload", "Noticing early gives you more options", "Choose one early sign you notice more than once, such as tension or shorter attention. Briefly note when it tends to happen, then choose one response: pause, clarify the task, or ask for help. This can guide planning; it is not a diagnosis."),
        MiniArticle(ArticleIds.RelaxWithoutForce, "Relax without effort", "You do not have to become completely calm", "Choose an action that takes little concentration: lower your shoulders, get more comfortable, or loosen your hands. Let your breath be natural. A little comfort is enough; do not force your body to relax fully. If focusing on your body increases discomfort, shift your attention to something around you."),
        MiniArticle(ArticleIds.BasicCareWithoutRules, "Basic care without strict rules", "Choose what you need right now", "Choose one thing you need in the next hour and make it small: a glass of water, a snack, a warm layer, or a message to someone. If it is not available, name the obstacle and ask for specific help. Not being able to manage everything alone is not a personal failure."),
        new(
            ArticleIds.NewSymptomsCare,
            "New or unusual symptoms",
            "Do not diagnose yourself from an article",
            "TipsAndUpdates",
            2,
            [
                H("Consider urgency first"),
                P("A new physical symptom can have many causes, and an article cannot reliably identify yours. If it is severe, worsening quickly, or feels dangerous, do not delay medical care to try an exercise or search online for an explanation. For immediate danger or sudden serious worsening, contact local emergency services."),
                H("Write down observations if it is safe to do so"),
                P("A brief note may help when speaking with a clinician: when it began, what changed, how often it happens, and what else you noticed. Mention medicines and recent changes if relevant. You do not need to diagnose yourself or keep detailed records if that takes too much energy."),
                H("Describe the effect on daily life"),
                P("Notice whether the symptom affects sleep, movement, eating, work, or usual activities. Tell the clinician what worries you most and what you are concerned it might mean. You can prepare questions or ask someone you trust to come with you if that would help."),
                H("Self-help does not replace medical assessment"),
                P("A calming activity may support you while you arrange care if it feels comfortable, but it cannot identify the cause of a symptom. For sudden worsening, severe pain, difficulty breathing, loss of consciousness, or another urgent warning sign, seek urgent help according to local guidance. If you are unsure how urgent it is, contact a medical service and describe what is happening."),
            ]),
        new(
            ArticleIds.FindTherapist,
            "Choosing a professional for a first meeting",
            "Look for a clear and safe way of working",
            "TipsAndUpdates",
            2,
            [
                P("Starting a search can be difficult: profiles may sound alike, and you cannot know in advance whether trust will develop. You do not have to find the perfect person on the first try. Begin with practical checks: relevant training and authorization, experience with your concern, session format, cost, and availability. If your question involves physical health or medication, ask which medical professional can assess it."),
                H("Ask practical questions"),
                P("Before booking or at the first meeting, ask how the work is usually structured, how goals are discussed, and how you can say that the format is not helping. Clarify payment and cancellation policies, contact between sessions, and how confidentiality works, including its limits. You do not need to share personal details by phone just to understand the arrangements."),
                H("Notice how the collaboration feels over time"),
                P("After the meeting, consider whether the process was clear, you could ask questions, and your boundaries were respected. Feeling awkward at a first conversation does not by itself mean the professional is a poor fit; clarity and safety matter too. If the fit does not improve, you can discuss it or look elsewhere. If you are in immediate danger, do not wait for a routine appointment; seek urgent help.")
            ]),
        new(
            ArticleIds.FirstAppointment,
            "A first appointment can start with one example",
            "You do not need to tell the whole story perfectly",
            "TipsAndUpdates",
            2,
            [
                P("Before a first meeting, it is easy to try to prepare a complete history and find exactly the right words. You do not have to. If useful, write down one recent situation that shows what is troubling you and what you would like to change. You can bring the note, read it, or ask the professional to guide you with one question at a time."),
                H("Bring the questions that matter to you"),
                P("You might ask how sessions work, what is confidential and when information may be shared, how goals are set, and what to do if you feel worse between appointments. You can also ask about cost, session length, and cancellations. You do not need to cover everything at once; start with what matters most."),
                H("Keep the option to pause"),
                P("You can say that you are not ready to discuss a topic, ask what a question means, or take a break. A first meeting is a chance to learn about the format, not a test of how well you tell your story. Afterward, consider whether it felt sufficiently safe and clear. You can decide later whether to continue.")
            ]),
        new(
            ArticleIds.DescribeSymptoms,
            "Describe what is happening through real examples",
            "When it began, how it repeats, and how life is affected",
            "TipsAndUpdates",
            2,
            [
                P("You do not need specialist terms or a ready explanation to talk about a difficult experience. Start with one recent example: what was happening, what you noticed, and what became harder to do. It is okay to say “I am not sure” or “I cannot describe it more clearly yet.” The aim is to understand together, not to guess a diagnosis in advance."),
                H("Gather a few useful details"),
                P("If you remember, note when it began, how often it happens, how long it lasts, and what circumstances change it. Describe effects on sleep, study, work, relationships, or caring for yourself. You can add what you have tried and what helped a little or made things worse. You do not need to keep a detailed diary if that feels tiring."),
                H("Prepare questions and relevant information"),
                P("You can write down medication, health changes, or other details that may be related; ask the professional what is useful if you are unsure. Do not change treatment based on an article or questionnaire. New or severe physical symptoms need medical assessment; if there is immediate danger, use urgent support.")
            ]),
        new(
            ArticleIds.SelfHelpLimits,
            "When self-help is not enough",
            "Professional support is a valid next step",
            "TipsAndUpdates",
            2,
            [
                H("Notice when the difficulty is lasting"),
                P("Self-help can support everyday challenges, but it does not have to solve everything. Professional support may be useful if your situation keeps disrupting sleep, work, study, relationships, or self-care; if things are getting worse; or if you are giving up important activities more often. You do not need to wait until it feels unbearable."),
                H("You do not need a diagnosis to reach out"),
                P("It is enough to describe what has changed and how long it has been going on. Depending on what is available to you, you might start with a primary care clinician, psychologist, or another qualified professional. If you are unsure where to begin, ask a healthcare service to suggest a first step."),
                H("Prepare a short summary"),
                P("Before the conversation, note a few points: what concerns you most, when it began, how it affects daily life, and what you have tried. Add questions about possible support. You do not have to explain everything at once; you can ask for unfamiliar terms to be explained and agree on one next step."),
                H("Asking is already an action"),
                P("You do not need to prove that you tried hard enough on your own. If booking an appointment or starting the conversation feels difficult, ask someone close to help find a contact or stay with you. If you or someone else is in immediate danger, contact local emergency services."),
            ]),

        new(
            ArticleIds.ScreeningNotDiagnosis,
            "A questionnaire is not a diagnosis",
            "A result can start a conversation, not label you",
            "TipsAndUpdates",
            2,
            [
                H("What a result can tell you"),
                P("A questionnaire collects answers about experiences during a defined period and in response to particular questions. A score may suggest topics to discuss, but it cannot explain the cause of how you feel by itself. Recent events, health, sleep, and how a question is understood can all affect answers."),
                H("What a score cannot establish"),
                P("A result neither confirms nor rules out a diagnosis, and it does not replace a conversation with a professional. A threshold or color band belongs to that tool; it is not a final judgment about you. A high score does not define what is “wrong” with you, and a low one does not invalidate difficulties affecting your life."),
                H("Use it as a note for a conversation"),
                P("If the result concerns you, save it with the date and consider what was happening during that period. You can note which questions stood out and what you would like to ask a professional. You do not need to repeat the questionnaire many times to get a number you want."),
                H("Do not change care based on one score"),
                P("Do not start, stop, or change treatment based only on an in-app score. Discuss questions with a qualified professional who can consider the answers in context. If your condition has suddenly worsened or you are in immediate danger, do not wait to retake a questionnaire; seek urgent help."),
            ]),
        MiniArticle(ArticleIds.SupportPlan, "Make a short support plan", "Write down signs, steps, and contacts", "Note how you recognize things getting harder, what tends to help, and whom you can tell. Add professional contacts and local emergency services. A plan does not replace help; it points to whom to contact when thinking is hard. Keep the plan somewhere easy to find and check the contacts in advance. Tell someone close which step you may need if things worsen."),
        MiniArticle(ArticleIds.CrisisSteps, "If you are not safe right now", "Connect with real-time help", "Move somewhere safer if possible and contact local emergency services or someone you trust. Say briefly what is happening and where you are. Do not stay alone if there is immediate danger. If calling is difficult, ask someone nearby to call or go with you. Share your location and say directly that help is needed now."),
        MiniArticle(ArticleIds.MedicationWithClinician, "Medication questions belong with a professional", "Do not change a prescription on your own", "If you have concerns about medication, write down its name, your question, and any unwanted effect, then discuss it with the prescriber or a pharmacist. Do not start, stop, or change a dose based on an article or app. Do not double a missed dose unless a clinician or the medication instructions say to. Contact a medical service for a severe reaction or sudden worsening."),
        new(
            ArticleIds.DeadlineConversation,
            "If you may miss a deadline, say so early",
            "Share the facts, a realistic estimate, and options",
            "TipsAndUpdates",
            2,
            [
                P("When a deadline is at risk, worry can make you stay silent or promise more than you can deliver. A brief update is more useful while people still have choices. Before you contact them, check what is complete, what remains, and what depends on you versus outside factors. You do not need to hide the delay or defend yourself with a long story."),
                H("Offer workable options"),
                P("State the facts and your best estimate: “The draft is ready; review will take two more days.” Then offer options: move the deadline, reduce the scope, send a finished part now, or agree on a check-in. If your estimate is uncertain, say so and give a time when you can update it."),
                H("Confirm the agreement"),
                P("Check which option was chosen, who needs to know, and when you will share progress. Do not promise a date that depends on giving up sleep or other essential needs. If delays keep happening, separately review the cause—task size, resources, or unclear priorities. That helps improve planning without turning it into self-blame.")
            ]),
        new(
            ArticleIds.DifficultMessageReply,
            "Pause before replying to a difficult message",
            "Decide what you want your response to accomplish",
            "TipsAndUpdates",
            2,
            [
                P("A sharp or ambiguous message can create an urge to reply immediately. If there is no urgent practical reason, give yourself time. Separate the exact words from your guess about the sender’s intent: a message may sound cold, but text alone may not explain why. Wait until you know what you want the reply to do."),
                H("Choose a purpose and a format"),
                P("Your purpose might be to clarify a fact, state a boundary, share a decision, or postpone the conversation. Draft a reply and remove anything that only escalates the exchange. For example: “I saw your message. I’ll answer the question tomorrow,” or “I can discuss this without insults.” For a complicated topic, a call or in-person conversation may work better than texting, if it is safe."),
                H("Protect yourself and keep useful records"),
                P("If the message includes threats, harassment, or coercion, you do not have to reply or continue contact. Save information you may need, use blocking or reporting tools, and seek support. If there is an immediate threat, move somewhere safer and contact emergency services or someone you trust.")
            ]),
        new(
            ArticleIds.CancelPlans,
            "Cancel plans clearly and with care",
            "Let the other person know early; share only what you want",
            "TipsAndUpdates",
            2,
            [
                P("Plans sometimes need to change because of health, circumstances, or limited energy. Let the other person know as soon as you can, especially if they are already counting on the meeting. A clear sentence is enough: “I need to cancel today.” You can keep the reason private; a short message is not rude just because it lacks a long explanation."),
                H("Suggest another plan if you mean it"),
                P("If you genuinely want to meet later, suggest a specific day or ask what works for them. Do not promise a new date from guilt if you are unsure you can make it. Acknowledge a practical inconvenience if there is one: “I know you set aside your evening.” The other person may feel disappointed or decline to reschedule."),
                H("Put safety and wellbeing first"),
                P("If you are cancelling because a situation feels unsafe, you do not have to keep the plan for someone else’s convenience. Choose a way to communicate that does not increase risk; sometimes a brief message or help from someone you trust is safer. If cancellations are frequent and concern you, consider what is getting in the way without blaming yourself.")
            ]),
    ];
}
