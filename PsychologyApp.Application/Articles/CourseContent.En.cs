using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Articles;

public static partial class ArticleContent
{
    private static readonly Course[] CoursesEn =
    [
        new(
            CourseIds.Sleep,
            "Sleep without pills",
            "Seven days of cognitive behavioural therapy for insomnia, the best-studied way to get sleep back",
            "Bedtime",
            "isi",
            "ISI-7",
            [
                new(
                    "How sleep works",
                    4,
                    [
                        P("Sleep can't be \"switched on\" by effort. Two forces prepare it: sleep pressure, which builds all day while you are awake, and the internal clock, which makes us sleepy and alert at the same times each day."),
                        P("In insomnia both forces get knocked off: people go to bed earlier to \"catch up\", lie awake for a long time, nap in the day, get up at different times. Sleep pressure has no time to build, and the clock gets confused."),
                        Cycle("The insomnia loop", "A bad night", "Worry: \"I won't sleep again\"", "Trying hard to fall asleep", "Tension keeps sleep away"),
                        P("This course is built on cognitive behavioural therapy for insomnia (CBT-I). Medical guidelines recommend it first, before sleeping pills: the effect lasts after the course ends."),
                        Warning("When to see a doctor first"),
                        List(
                            "Loud snoring, pauses in breathing during sleep, strong daytime sleepiness",
                            "Unpleasant sensations in the legs in the evening that make you want to move",
                            "Insomnia together with low mood for more than two weeks",
                            "You drive or operate machinery and are very sleepy in the day")
                    ],
                    "Every morning write down: when you went to bed, roughly when you fell asleep, how many times you woke, when you got up and how you slept from 0 to 10. No clock at night, roughly, by feel.",
                    "When do you usually go to bed and get up? What gets in the way of your sleep most?"),
                new(
                    "The bed is for sleep",
                    4,
                    [
                        P("If you often lie awake in bed, worry or look at your phone there, the brain links the bed with being awake. That is why you can nod off in an armchair and be wide awake the moment you lie down."),
                        H("Rules that restore the link"),
                        List(
                            "Go to bed only when you feel sleepy, not just tired",
                            "If you can't sleep for about 20 minutes, get up and do something calm in dim light. Come back when you feel sleepy",
                            "The bed is only for sleep and intimacy: no phone, series or work",
                            "Get up at the same time every day, even after a bad night and at weekends",
                            "Don't nap, and if you really must, no more than 20 minutes and before 3 pm"),
                        Quiz("The night was bad. What is better in the morning?", 1, "A fixed wake-up time is the main anchor of sleep. If you sleep in, there will be less sleep pressure by evening, and the next night will be hard too.", "Sleep in to recover", "Get up at the usual time", "Get up, then have a good nap in the day")
                    ],
                    "Choose a wake-up time you can keep all seven days, and get up at it. If you can't sleep for about 20 minutes, get out of bed.",
                    "Which wake-up time did you choose? What was hard about the \"get up if you can't sleep\" rule?"),
                new(
                    "The sleep window",
                    5,
                    [
                        P("The longer a person lies awake in bed, the lighter and more broken sleep becomes. A technique called sleep compression helps: time in bed is brought closer to how much you actually sleep."),
                        H("How to work out the window"),
                        List(
                            "From your notes of the last few days, work out how long you sleep on average",
                            "Add 30 minutes: this is your time in bed, but not less than six hours",
                            "Count it back from your chosen wake-up time: that gives your bedtime",
                            "Don't go to bed before that time, even if you really want to"),
                        P("The first days you will be sleepy: it means sleep pressure is building. After a week, if you sleep most of the time in bed, the window can be extended by 15 minutes."),
                        Warning("Take care"),
                        P("Don't compress sleep if you have bipolar disorder or epilepsy, if you are pregnant, or if sleepiness makes driving or work dangerous. In these cases, discuss sleep with a doctor.")
                    ],
                    "Work out your sleep window and keep it until the end of the course: no bed before your bedtime, up at the same time.",
                    "What is your sleep window? How did the first night with it go?"),
                new(
                    "An evening that prepares for sleep",
                    4,
                    [
                        P("Sleep comes more easily when body and mind have time to slow down. The hour before bed is the bridge from day to sleep."),
                        H("What helps"),
                        List(
                            "An hour before bed: dim light and calm activities without screens",
                            "Avoid coffee, strong tea and energy drinks for at least 6 hours before bed; if they disturb your sleep, try stopping earlier",
                            "Alcohol helps you fall asleep but makes sleep shallow and wakes you towards morning",
                            "A heavy dinner 2–3 hours before bed",
                            "In the morning, daylight for at least 15 minutes: it sets the internal clock"),
                        P("One-minute plan: choose when your wind-down will begin and one quiet activity, such as reading a few pages. If an hour is not available, choose a shorter version in advance. For example: “After my evening tasks, I’ll dim the lights and read a little.”"),
                        H("Relaxing before sleep"),
                        P("Slow breathing with a long out-breath lowers arousal. Try it now."),
                        Breathe("Breathe in for 4, out for 6")
                    ],
                    "Try your plan tonight: allow time for quiet activities before bed when you can, and use your shorter version when an hour is not available. Keep your phone off the bed while retaining important alerts.",
                    "What went into your evening ritual? What turned out to be hard?"),
                new(
                    "Thoughts that keep you awake",
                    4,
                    [
                        P("The mind often starts working precisely in bed: during the day there was no time for thoughts. So it helps to give them time earlier."),
                        H("Time for thoughts"),
                        List(
                            "In the evening, a couple of hours before bed, set aside 15 minutes",
                            "Write down everything that worries you, and for each item one next step or \"nothing I can do for now\"",
                            "If the thought comes back in bed, tell yourself: \"I've written this down, I'll deal with it tomorrow\""),
                        Quiz("In bed you think: \"If I don't sleep, I'll fail everything tomorrow.\" What is closer to the truth?", 1, "The thought exaggerates. After a bad night things are harder, but most people still get their tasks done. The stronger the fear about tomorrow, the harder it is to fall asleep.", "It's true, failure is inevitable", "After a bad night it's harder, but I usually manage the main things", "Better not to go to bed at all"),
                        Practice(TechniqueId.ThoughtDefusion, "Unhook from a thought")
                    ],
                    "Every evening, set aside 15 minutes to write down what worries you, and don't take those thoughts to bed.",
                    "Which thoughts come most often at night? Did writing them down help?"),
                new(
                    "Stop fighting sleep",
                    4,
                    [
                        P("The harder you try to sleep, the worse it goes. Sleep is like a shy bird: it comes when no one chases it."),
                        H("What helps let go of control"),
                        List(
                            "Put the clock out of sight: counting \"five hours left\" wakes you up",
                            "Allow yourself not to sleep: \"I'll lie here and rest, sleep will come when it comes\"",
                            "A bad night is not a disaster: the body recovers even after incomplete sleep",
                            "Don't cancel plans because of a bad night: that way insomnia doesn't run your life"),
                        P("Compare your notes from the first days with now: how have the time to fall asleep, the number of awakenings and the sleep rating changed?")
                    ],
                    "Keep the clock out of sight at night. After a bad night, live the day as usual.",
                    "What has changed in your sleep over these days, according to your notes?"),
                new(
                    "Summary and plan",
                    4,
                    [
                        P("In a week you have gone through the core of CBT for insomnia. Sleep recovers gradually: many people notice improvement in two to four weeks if they keep to the rules."),
                        H("What to keep doing"),
                        List(
                            "One wake-up time every day",
                            "Go to bed only when sleepy, and get up if you can't sleep",
                            "If you sleep most of the night, extend the window by 15 minutes a week",
                            "The evening ritual and time for thoughts"),
                        H("If insomnia comes back"),
                        P("After stress, illness or travel, sleep can go off track again. That's normal: go back to the rules of this course, and it will recover faster than the first time."),
                        P("Take the ISI-7 index again and compare with your result at the start. If there is no improvement, see a doctor: there are sleep specialists who provide CBT-I."),
                        TestsTab("ISI-7 Index", "isi")
                    ],
                    "Write down your plan for if sleep goes off track again.",
                    "What in the course helped most? What will you keep doing?")
            ]),
        new(
            CourseIds.Anxiety,
            "Anxiety under control",
            "Six days: understand how anxiety works, calm the body, check frightening thoughts and take a first step towards the fear",
            "Psychology",
            "gad7",
            "GAD-7",
            [
                new(
                    "How anxiety works",
                    4,
                    [
                        P("Anxiety is an alarm meant to warn of danger. The trouble starts when it goes off too often, too loudly, and doesn't switch off for a long time."),
                        Cycle("The anxiety loop", "A frightening thought", "Anxiety in the body", "Avoidance or a safety net", "Relief for a minute", "The brain learns: \"it was dangerous\""),
                        P("What keeps anxiety going is not the fear itself but what we do so as not to feel it: avoiding, re-checking, seeking reassurance, going over thoughts. Step by step, the course works through each link of this loop."),
                        P("At the start of the course it is worth taking the GAD-7 scale: at the end you will compare the result."),
                        TestsTab("GAD-7 Scale", "gad7")
                    ],
                    "Three times today, when you feel anxious, notice: what happened, what the thought was, what the body felt and what you did.",
                    "When and where does anxiety show up most often?"),
                new(
                    "Calming the body",
                    4,
                    [
                        P("When anxiety is high, it is hard to argue with thoughts. First it helps to calm the body: a slow out-breath switches on the system that brakes the fight-or-flight response."),
                        Breathe("Breathe in for 4, out for 6"),
                        P("If the anxiety is strong and everything feels unreal, bring your attention back to the present through your senses."),
                        Practice(TechniqueId.Grounding, "5-4-3-2-1 grounding"),
                        P("Important: breathing is not a way to get rid of anxiety at any cost. It helps you get through the peak, not avoid situations.")
                    ],
                    "Twice a day, two minutes of slow breathing, even when calm: that way the skill is there when you need it.",
                    "What did you notice in your body when you breathed slowly?"),
                new(
                    "Checking a frightening thought",
                    5,
                    [
                        P("Anxious thoughts sound like facts: \"I'll embarrass myself\", \"something terrible will happen\". But they are predictions, and they can be checked."),
                        H("Questions to ask the thought"),
                        List(
                            "What facts support this thought, and what facts go against it?",
                            "What happened in similar cases before?",
                            "What is most likely, rather than most frightening?",
                            "If the worst happens, how will I cope with it?",
                            "What would I tell a friend with this thought?"),
                        Quiz("\"I will definitely mess it up.\" Which thinking trap is this?", 1, "It is fortune-telling: the thought treats something that has not happened yet as a fact.", "Mind-reading", "Fortune-telling", "Discounting the positive"),
                        Practice(TechniqueId.ThoughtRecord, "Thought record")
                    ],
                    "Once today, check an anxious thought with a thought record.",
                    "Which thought did you check? How much did you believe it before and after?"),
                new(
                    "Worry time",
                    4,
                    [
                        P("Worry feels useful: \"if I think more, I'll be ready\". In fact, going over things rarely leads to a solution and keeps anxiety high."),
                        Quiz("How do you tell solving from going in circles?", 0, "Solving moves towards a step: what can I do, and when. Going in circles produces new \"what ifs\".", "Solving ends in a step, going in circles in a new \"what if\"", "Going in circles takes longer", "You can't"),
                        H("How to postpone worry"),
                        List(
                            "Choose 15–20 minutes a day, not before bed",
                            "When worry comes at another time, write the topic down in one line and tell yourself: \"I'll think about it in my worry time\"",
                            "In your worry time, go through the list: plan a step for what you can do, let go of what you can't",
                            "Often, by the appointed time, the topic no longer seems important"),
                        Practice(TechniqueId.ThoughtDefusion, "Unhook from a thought"),
                        P("If you keep reopening the news for certainty, write down the exact question and decide whether you need to act now. If there is no action to take, choose when to check again."),
                        See(ArticleIds.NewsLoop, "When the news keeps pulling you back")
                    ],
                    "Set yourself a worry time and postpone anxious thoughts to it.",
                    "Did you manage to postpone worry? What happened to the topics by the appointed time?"),
                new(
                    "Safety nets and avoidance",
                    4,
                    [
                        P("The strongest thing keeping anxiety going is avoidance. It can be open (I don't go, I don't call) or hidden: safety nets people use to get through a situation."),
                        Check("Do I have safety nets?", 2, "You have several safety nets. They keep the fear going: the brain thinks things turned out fine only thanks to them. Try giving one up in an easy situation.", "You have few safety nets. Also notice what you avoid completely.", "I carry a pill, water or a charged phone \"just in case\"", "I only go to hard places with someone", "I sit close to the exit", "I distract myself so as not to notice the anxiety", "I check or ask again many times"),
                        P("The way out is to meet what you fear gradually and do without safety nets. Then the brain learns from experience that the feared thing doesn't happen or is bearable.")
                    ],
                    "Make a list of three to five situations you avoid, from the easiest to the hardest.",
                    "Which situation from the list are you ready to try first?"),
                new(
                    "The first step and a plan",
                    4,
                    [
                        P("The most effective way to weaken anxiety is exposure: gradually meeting the fear. You don't need to go straight to the most frightening thing: start with an easy step and test a prediction."),
                        List(
                            "Before the step, write down what you fear and how sure you are it will happen",
                            "Take the step without safety nets and stay in the situation until you have tested the prediction",
                            "Afterwards, write down what actually happened"),
                        Ladder("Fear ladder"),
                        H("What to keep doing"),
                        List(
                            "Slow breathing at the peak of anxiety",
                            "Checking thoughts and worry time",
                            "Steps up the fear ladder every few days"),
                        P("Take the GAD-7 scale again and compare with the start. If anxiety is strong or gets in the way of life, see a psychotherapist: CBT for anxiety is well studied."),
                        TestsTab("GAD-7 Scale", "gad7")
                    ],
                    "Take the first step on your fear ladder and write down what happened.",
                    "What did you predict, and what actually happened?")
            ]),
        new(
            CourseIds.Mood,
            "Out of apathy",
            "Six days of behavioural activation: small steps to bring back energy and what brings joy",
            "Cloud",
            "phq9",
            "PHQ-9",
            [
                new(
                    "The inactivity loop",
                    4,
                    [
                        P("When mood is at zero, it is natural to do less: there's no energy, nothing appeals. But the less we do, the less there is in life that brings joy and a sense of \"I managed\", and mood drops even lower."),
                        Cycle("The inactivity loop", "No energy", "I do less", "Less joy and fewer wins", "Even less energy"),
                        P("Behavioural activation breaks this loop from the other side: not waiting until you feel like it, but taking small steps after which energy and the wish gradually return. It is one of the best-studied methods of help for depression."),
                        P("Take the PHQ-9 scale at the start of the course: at the end you will compare the result."),
                        TestsTab("PHQ-9 Scale", "phq9"),
                        Warning("If thoughts of death appear"),
                        P("If you have thoughts that it would be better if you weren't here, don't stay alone with them: this course does not replace help from a specialist."),
                        Crisis("I need help now")
                    ],
                    "Today and tomorrow, notice what you are doing and rate your mood from 0 to 10 several times a day.",
                    "How are your days going now? What have you stopped doing lately?"),
                new(
                    "What lifts your mood",
                    4,
                    [
                        P("Look at your observations: at which moments was your mood slightly higher? Often it is something small: a conversation, a walk, a shower, a task done."),
                        H("Two kinds of useful activities"),
                        List(
                            "Pleasant ones: what brings pleasure, however faint — music, tasty food, sunshine",
                            "\"I managed\" ones: what leaves a sense of accomplishment — washing up, answering an email"),
                        P("In depression, pleasure from pleasant things is weaker than before. That's normal: what matters is doing, not waiting for the old joy.")
                    ],
                    "Make a list of ten activities: five pleasant and five \"I managed\". The smaller and simpler, the better.",
                    "What went into your list? Was there something that lifted your mood a little?"),
                new(
                    "Small steps",
                    4,
                    [
                        P("Big plans are daunting in apathy and don't get done. It helps to break things down: not \"clean the flat\" but \"clear three things off the table\"."),
                        List(
                            "Choose one activity from the list for today",
                            "Break it down to a step that takes five minutes",
                            "Set a time and place: \"after breakfast, in the kitchen\"",
                            "Afterwards, note how your mood changed"),
                        Practice(TechniqueId.SmallStep, "One small step"),
                        P("The aim is not to make your mood lift right away. If it stays the same, note how manageable the activity was and adjust the next step."),
                        See(ArticleIds.SmallStepReview, "When a small step does not lift your mood")
                    ],
                    "Every day, do one pleasant activity and one \"I managed\" activity at the time you set.",
                    "What did you manage to do? How did your mood change afterwards?"),
                new(
                    "\"I don't feel like it\"",
                    4,
                    [
                        P("The main obstacle is the thought \"I don't feel like it, I'll do it when I have the energy\". In apathy the wish comes after action, not before it."),
                        Quiz("No energy, and a walk is planned for today. What is better?", 1, "In apathy the wish comes back after action. Even five minutes give body and mood the signal \"I did something\".", "Wait until you feel like it", "Go out for at least five minutes", "Put it off until the weekend"),
                        H("Other obstacle thoughts"),
                        List(
                            "\"It's pointless\": check afterwards — is anything even a little different?",
                            "\"It's too small\": small steps are exactly what the way out is made of",
                            "\"I used to do more\": compare yourself with yesterday, not with your past self"),
                        Practice(TechniqueId.SelfCompassion, "Kind words to yourself")
                    ],
                    "When you don't feel like it, do at least a five-minute version of what you planned.",
                    "Which thought most often stops you from starting? What helped you get round it?"),
                new(
                    "People around you",
                    4,
                    [
                        P("In apathy you want to shut yourself off from everyone. But contact with people is one of the strongest remedies for low mood, even if right now it doesn't bring joy as it used to."),
                        List(
                            "Write to one person you haven't been in touch with for a while",
                            "A short meeting or call is better than none",
                            "You don't have to explain everything: \"things are hard right now, let's just go for a walk\"",
                            "If energy is low, choose people who are easy to be with"),
                        Practice(TechniqueId.SmallStep, "One small step"),
                        P("You do not have to explain everything: you can ask for something concrete, such as listening, company or help with one task."),
                        See(ArticleIds.SupportRequest, "How to ask for support")
                    ],
                    "Get in touch with at least one person in the next two days.",
                    "Who did you contact? How was it?"),
                new(
                    "What matters to me",
                    4,
                    [
                        P("So that the steps don't turn into chores, it helps to link them to what matters to you: people close to you, health, work, creativity, nature."),
                        List(
                            "Choose one area that matters to you",
                            "Think about who you want to be in it",
                            "Choose one small step in that direction for the week"),
                        H("What to keep doing"),
                        List(
                            "Every day one pleasant activity and one \"I managed\"",
                            "Small steps instead of big plans",
                            "Contact with people"),
                        P("Take the PHQ-9 scale again and compare with the start. If the result is high or not changing, see a doctor or psychotherapist: depression is very treatable."),
                        TestsTab("PHQ-9 Scale", "phq9"),
                        Crisis("I need help now")
                    ],
                    "Take one step in an area that matters to you this week.",
                    "What matters to you? Which step did you choose?")
            ]),
        new(
            CourseIds.Trauma,
            "After trauma",
            "Five days on what is safe to do on your own: understand your reaction, cope with flashbacks and nightmares, find a specialist",
            "Healing",
            "pcl5",
            "PCL-5",
            [
                new(
                    "A normal reaction to an abnormal event",
                    4,
                    [
                        P("After a hard event almost everyone has intrusive memories, nightmares, anxiety, numbness, irritability. It is not weakness but the reaction of a brain trying to protect you from it happening again."),
                        P("This course won't process the trauma: that takes therapy with a specialist. It will help you understand what is happening to you, cope with hard moments and arrive at a specialist prepared. You don't need to recall or describe the event itself in this course."),
                        P("Take the PCL-5 scale at the start: at the end you will compare the result."),
                        TestsTab("PCL-5 scale", "pcl5"),
                        Warning("If the danger is ongoing"),
                        P("If you are under threat now, or thoughts of harming yourself have appeared, safety comes first."),
                        Crisis("I need help now")
                    ],
                    "Notice when things get harder during the day, without details of the event: the time, the place, what was around.",
                    "Which of these reactions do you recognise in yourself?"),
                new(
                    "Coming back to the present",
                    4,
                    [
                        P("A flashback is a memory relived as if it were happening now. Time, place, the support of the body and the senses help you come back."),
                        Practice(TechniqueId.Flashback, "A memory took over"),
                        Practice(TechniqueId.Grounding, "5-4-3-2-1 grounding"),
                        H("Your own grounding kit"),
                        List(
                            "A phrase: \"This is a memory. It is a different time now, I am safe\"",
                            "Something to carry with you: a pebble, a ring, something with a scent",
                            "A person you can message",
                            "Something cold: water, ice"),
                        Breathe("The out-breath longer than the in-breath"),
                        P("If focusing on breath or body increases distress, stop. Open your eyes, choose a neutral object around you, or skip the exercise."),
                        See(ArticleIds.TraumaGrounding, "When grounding increases distress")
                    ],
                    "Put together your grounding kit and try the \"A memory took over\" practice at a calm moment, so you know it in advance.",
                    "What went into your grounding kit?"),
                new(
                    "Sleep and nightmares",
                    4,
                    [
                        P("After trauma sleep often suffers: it is hard to fall asleep, sleep is light, nightmares come. Lack of sleep makes the days more anxious and irritable."),
                        List(
                            "One wake-up time every day",
                            "Light in the morning, a calm evening without the news",
                            "If a nightmare wakes you: light, where am I and what day it is, water, slow out-breaths",
                            "Alcohol strengthens nightmares in the second half of the night"),
                        P("A recurring nightmare can be rewritten: imagery rehearsal makes nightmares less frequent and weaker. Start with a milder one."),
                        Practice(TechniqueId.Nightmare, "Rewrite a nightmare")
                    ],
                    "Keep one wake-up time. If you have recurring nightmares, try rewriting one of them, starting with a milder one.",
                    "How are you sleeping now? What helps after a hard night?"),
                new(
                    "Support and people",
                    4,
                    [
                        P("Trauma often distances people from others and from what used to matter. Support from people close to you is one of the strongest factors in recovery."),
                        List(
                            "You don't have to talk about the event: you can simply be together",
                            "Tell people close to you how to help you at a hard moment",
                            "Gradually bring back what gave you support: walks, movement, things you used to enjoy",
                            "Don't numb feelings with alcohol: it gets in the way of recovery"),
                        P("Avoiding reminders is understandable, but over time it narrows life and keeps the trauma \"hot\". It is better to work on this with a specialist than to force yourself alone."),
                        P("What the event changed in how you think about yourself — blame, \"something is wrong with me\", \"no one can be trusted\" — can be worked through in the chat, without retelling what happened."),
                        TraumaChat("Work it through in the chat"),
                        Practice(TechniqueId.SelfCompassion, "Kind words to yourself")
                    ],
                    "Do one thing that used to give you support, and spend time with someone you trust.",
                    "Who and what gives you support now?"),
                new(
                    "The way to a specialist",
                    5,
                    [
                        P("Post-traumatic symptoms respond well to trauma-focused psychotherapy: prolonged exposure, cognitive therapy, EMDR, written exposure. It usually takes 8–16 sessions."),
                        See(ArticleIds.TraumaTreatment, "How trauma is treated and how to choose a specialist"),
                        H("How to prepare"),
                        List(
                            "Take the PCL-5 scale again and compare with the start",
                            "Export a summary from the app for the specialist: \"Profile → Options → Data & backup\"",
                            "Write down your questions: which method, how many sessions, how progress will be measured",
                            "You don't have to tell everything about the event at the first meeting"),
                        TestsTab("PCL-5 scale", "pcl5"),
                        Crisis("I need help now")
                    ],
                    "Find one or two specialists who work with trauma and book a consultation.",
                    "What in the course was most useful? What do you want to discuss with the specialist?")
            ]),
        new(
            CourseIds.MoneyStress,
            "Money worries: 14 days of support",
            "Fourteen short steps to check urgency, separate facts from predictions, and find support. GAD-7 covers general anxiety over the past two weeks, not finances; a score change does not prove the course caused it. This is not financial or legal advice.",
            "AccountBalanceWallet",
            "gad7",
            "GAD-7",
            [
                new(
                    "One worry",
                    4,
                    [P("GAD-7 covers general anxiety symptoms over the past two weeks, not money concerns. Choose one worry and describe it without amounts, account details, or names."), TestsTab("Open GAD-7: general anxiety over the past two weeks", "gad7"), See(ArticleIds.MoneyStress, "Money worries: facts and predictions")],
                    "Write it in general terms or say it aloud.",
                    "What most often brings your attention back to it?"),
                new(
                    "Check urgency first",
                    4,
                    [P("If food, housing, essential medicine, or safety is at risk, seek real-world practical help today; the course can wait.")],
                    "Name one need that requires attention today and someone you could contact.",
                    "What needs attention first?"),
                new(
                    "Facts and predictions",
                    4,
                    [P("Separate known facts, what needs checking, and a fear about the future. You can acknowledge uncertainty without filling it with the worst prediction."), Practice(TechniqueId.MoneyWorryPlan, "Sort a Money Worry"), See(ArticleIds.MoneyStress, "Money worries: facts and predictions")],
                    "Try the practice using general notes.",
                    "What could you separate from the fear?"),
                new(
                    "One question to check",
                    4,
                    [P("Choose a question whose answer may reduce uncertainty. For a bill or service, use a familiar official channel.")],
                    "Write one question and where you can safely check the answer.",
                    "What is clearer now?"),
                new(
                    "Protect personal information",
                    4,
                    [P("Do not share passwords, PINs, verification codes, or full account details. Verify unexpected requests for transfers another way.")],
                    "Choose a pause rule before sharing data or sending money.",
                    "Which boundary adds safety?"),
                new(
                    "Make a specific request",
                    4,
                    [P("Support need not be money: company, making a call together, or finding a local service. The other person may agree or decline."), See(ArticleIds.SupportRequest, "How to ask for support")],
                    "Draft a request for one task and time, without financial secrets.",
                    "Who could you ask?"),
                new(
                    "A manageable step",
                    4,
                    [P("Choose a safe action within your control that can be reviewed. Specialist financial or legal questions need a qualified local professional."), Practice(TechniqueId.MoneyWorryPlan, "Sort a Money Worry")],
                    "Choose one small reversible step or ask for support.",
                    "What helps you avoid taking everything on at once?"),
                new(
                    "A backup option",
                    4,
                    [P("A plan is more flexible when it includes another option in case of delay or refusal. It need not solve everything.")],
                    "Name one alternative and a support contact.",
                    "Which option seems realistic?"),
                new(
                    "Time to review",
                    4,
                    [P("If nothing urgent needs action, set a short time to check information, then return to the present task. Do not delay necessary help.")],
                    "Choose a calm time to review your plan.",
                    "What can wait?"),
                new(
                    "Practical support",
                    4,
                    [P("Your area may have social, community, or health services. Options vary; the app does not recommend financial decisions.")],
                    "Find a familiar local source to ask what support is available.",
                    "What would you ask?"),
                new(
                    "Talk without sharing secrets",
                    4,
                    [P("You might tell someone: I feel worried and would like company for a while. You do not need to share amounts or account details.")],
                    "Decide what you are comfortable sharing in general terms.",
                    "What kind of help would you like?"),
                new(
                    "Support yourself",
                    4,
                    [P("Rest, water, food, or a familiar calming activity will not solve a money problem, but may help you get through today.")],
                    "Choose one available act of care that does not require spending.",
                    "What could give you a little breathing room?"),
                new(
                    "Review your limits",
                    4,
                    [P("Notice what is clearer, what is unknown, and where another person’s help is needed. You can simplify the plan.")],
                    "Keep one next step and set the rest aside if safe.",
                    "What need not be solved today?"),
                new(
                    "Choose what comes next",
                    4,
                    [P("After about two weeks, you may repeat GAD-7. It does not assess finances or prove the course caused a change. If anxiety keeps disrupting daily life, discuss support with a professional."), TestsTab("Repeat GAD-7; scores do not assess finances or show what caused a change", "gad7"), Crisis("I need help now")],
                    "Choose one support or step to continue.",
                    "What would you keep or discuss with a professional?")
            ]),

        new(CourseIds.ValuesAction, "Small steps toward what matters", "Five days to choose a meaningful direction and try manageable actions.", "TrackChanges", "who5", "WHO-5",
            [
                new("Find a direction", 3, [P("A value is the kind of person you want to be in an area of life, not an outcome you have to complete once and for all."), See(ArticleIds.ValuesAction, "Values as a guide: choose one manageable step")], "Name one area that matters to you right now.", "What makes it matter to you?"),
                new("Make the step smaller", 3, [P("Choose an action that takes a few minutes. It should be small enough to try and meaningful enough to feel like your choice.")], "Write down an action that takes no more than 5–10 minutes.", "How could you make it easier or shorter?"),
                new("Plan for an obstacle", 3, [P("Think of what might get in the way and choose a backup option. A plan can change; that is not failure.")], "Complete: “If … gets in the way, I can try …”.", "What would be a kinder option if you have less energy?"),
                new("Try without waiting for the right mood", 3, [P("You do not have to feel confident or motivated first. You can try a small step, notice what comes up, and stop or simplify it if that feels safer.")], "If it is safe, try your step or an easier version.", "What did you notice before and after?"),
                new("Review the plan", 3, [P("Review how well the action fit rather than judging yourself. Repeat it, adjust it, or choose another direction.")], "Write what you want to repeat or change this week.", "What action can support what matters without adding pressure?")
            ]),


        new(CourseIds.ProblemPlanning, "A plan for manageable tasks", "Break a problem into steps and review the plan", "Checklist", "gad7", "GAD-7",
            [
                new("Choose a problem", 3, [P("First name one specific problem. Not everything is in your control; choose what you can influence."), See(ArticleIds.ProblemPlanning, "A plan for manageable tasks")], "Write down one problem and what is within your control.", "Which part of the situation can you influence?"),
                new("Choose a step", 3, [P("Write down several options, even if none seems perfect. Choose one small, safe step."), See(ArticleIds.ProblemPlanning, "A plan for manageable tasks")], "Write down two options and choose one manageable step.", "What might get in the way, and what is a backup option?"),
                new("Review the plan", 3, [P("After trying, notice what helped and what was too difficult. You can adjust the plan or ask for support."), See(ArticleIds.ProblemPlanning, "A plan for manageable tasks")], "Try the step if it is safe, and note what happened.", "What would you keep, change or discuss with someone?")
            ]),
        new(
            CourseIds.Overwhelm,
            "Less overwhelm, one clearer next step",
            "Five short days to sort urgency, shrink a task, and find support. Move at your own pace.",
            "Checklist",
            "pss10",
            "PSS-10",
            [
                new("Get tasks out of your head", 4, [P("A short list can show the size of what is asking for attention. Use a few words; private details are not needed."), H("Check urgency first"), Warning("If safety, health, food, housing, or essential medicine is at risk, seek practical help first."), See(ArticleIds.Overwhelm, "When everything piles up: choose one next step")], "List what is asking for attention and mark only what cannot safely wait.", "What became clearer after making the list?"),
                new("Separate urgency from worry", 4, [P("Strong worry deserves care, but it does not set the order by itself. Check deadlines, consequences, and what you can influence."), Quiz("What can help you choose the first task?", 1, "Deadlines and consequences help assess urgency; how loud worry feels does not make a task first by itself.", "Choose the loudest worry", "Check the deadline and consequences", "Try to solve everything at once")], "Choose one task for today and one that can wait.", "What truly cannot be postponed?"),
                new("Shrink the next step", 4, [P("Describe an action that takes a few minutes. If it still feels too big, break it down again."), See(ArticleIds.Overwhelm, "When everything piles up: choose one next step"), Practice(TechniqueId.ExternalOrientation, "Three neutral details")], "Name the start of the task: open, call, check, or gather one item.", "How could you make this step easier?"),
                new("Ask for manageable help", 4, [P("A request for one specific action is clearer than asking someone to solve everything. They may agree, suggest another option, or say no; you can then look for other support."), List("Ask someone to stay with you", "Ask for help checking one fact", "Ask to share one task")], "Write a short request and choose someone you could ask.", "What response or backup option would work?"),
                new("Review the plan", 4, [P("Review whether the plan fits your circumstances now, not whether you have been strict enough with yourself. You can continue, simplify, or ask for support."), TestsTab("If you wish, repeat PSS-10. It screens perceived stress; it is not a diagnosis, and a score change does not show the course caused it.", "pss10")], "Choose one step you want to keep for the next few days.", "How can you keep the plan from becoming another source of pressure?")
            ]),

        new(
            CourseIds.NewsBoundaries,
            "News on your schedule",
            "Five days to check feeds less out of habit while keeping important alerts.",
            "TipsAndUpdates", "pss10", "PSS-10",
            [
                new("Notice the habit", 4, [P("When you reach for the feed, ask: what do I want to know, and do I need to act now?"), See(ArticleIds.NewsLoop, "When the news keeps pulling you back"), TestsTab("The PSS-10 measures perceived stress over the past month. It is a screening measure, not a diagnosis.", "pss10")], "Notice once what prompted you to check the news.", "What were you hoping to find out?"),
                new("One question, one source", 4, [P("State one question and choose a reliable source that can answer it. Once you have the answer, more updates may not add useful information."), Quiz("You found the answer you needed. What can you do if no urgent action is required?", 1, "Choosing when to check again can interrupt automatic refreshing.", "Keep refreshing until you feel calm", "Choose a time to check again and return to your task", "Ban yourself from reading the news")], "Choose one question and one source for your next check.", "How will you know you have the information you need?"),
                new("Keep important alerts", 4, [P("You can turn off optional notifications while keeping alerts needed for safety, family, or work."), List("Keep alerts from essential services", "Turn off optional notifications", "Ask close contacts to call about urgent matters")], "Review notification settings only if it feels useful.", "Which alerts do you need to keep?"),
                new("Make a check-in plan", 4, [P("Choose a suitable time and source. You do not need a strict limit: adjust the plan if urgent news or new circumstances arise."), Practice(TechniqueId.NewsCheckPlan, "Plan a news check")], "Fill in the short plan or simply think it through.", "What will you do after checking?"),
                new("Review without judging yourself", 4, [P("Notice whether this routine feels more workable. Keep it, change it, or leave it. A change in PSS-10 scores does not prove that the course caused it."), Quiz("What if information that affects safety appears?", 1, "A plan should not stop you from checking urgent information or following official guidance.", "Wait for the planned check-in", "Check a reliable source and act as needed", "Turn off every alert"), TestsTab("You may repeat the PSS-10 if you wish. Comparing scores does not establish why they changed.", "pss10")], "Keep one setting that works for you.", "What routine felt manageable?")
            ]),
        new(
            CourseIds.HabitMaintenance,
            "A habit you can return to",
            "Five days to choose a cue, make starting easier, and plan a gentle restart after a missed day.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Choose one action", 4, [P("Start with one small action within your control that supports everyday well-being. Do not choose several goals at once."), See(ArticleIds.HabitFormation, "A new habit: one small action and a cue"), TestsTab("WHO-5 is a brief well-being screen for the past two weeks, not a diagnosis or a measure of willpower.", "who5")], "Name one action you would like to repeat.", "Why does this step fit your life right now?"),
                new("Attach it to a cue", 4, [P("Choose a regular event that can remind you to begin, such as after breakfast or when you get home."), Practice(TechniqueId.ImplementationIntention, "If–Then Action Plan"), Quiz("Which plan is easier to remember at the right moment?", 1, "A specific cue and a small action make it easier to begin without waiting for a certain mood.", "I will do more of this sometime", "After breakfast, I will write one sentence", "I will start when I feel motivated")], "Complete: After …, I will …", "What regular cue already exists in your day?"),
                new("Make starting easier", 4, [P("Remove one small obstacle: set out what you need, open the file, or choose a place. The first step can take only a couple of minutes."), List("Prepare what you will need", "Reduce the time or amount", "Choose an easier place or time")], "Make the beginning one step easier.", "What got in the way, and what did you change?"),
                new("Plan how to restart", 4, [P("A missed day is information about what happened, not proof of failure. You do not need to double the effort or criticize yourself; you can return at the next suitable opportunity."), Practice(TechniqueId.HabitRestartPlan, "A gentle restart"), Quiz("You missed your usual action. What may help you return without extra pressure?", 1, "The next suitable cue and a smaller step let you continue without punishment or catch-up.", "Do twice as much tomorrow", "Return at the next cue and start small", "Abandon the plan forever")], "Choose a cue for restarting and the easiest version of the action.", "How can you continue without trying to catch up?"),
                new("Keep what works", 4, [P("Treat the plan as an experiment: repeat it, make the action smaller, change the cue, or pause. You may repeat WHO-5 if you wish; a score change alone does not prove the course caused an effect."), TestsTab("WHO-5 is a well-being screen, not a diagnosis. Comparing scores does not establish why they changed.", "who5")], "Keep one adjustment you want to try next.", "What felt workable, and what might you change?")
            ]),
        new(
            CourseIds.FeedbackResponse,
            "Responding to feedback without self-criticism",
            "Four short lessons: separate facts from labels, clarify expectations, and choose a response that respects your boundaries.",
            "Forum", "who5", "WHO-5",
            [
                new("Notice your first reaction", 4, [P("Someone’s words may sting. You do not have to agree, argue, or defend yourself immediately. First notice what you heard and how it landed."), See(ArticleIds.Feedback, "Feedback without labels"), TestsTab("WHO-5 is a general screen of well-being over the past two weeks, not a diagnosis or a measure of how well you accepted feedback.", "who5")], "Choose a phrase that gives you time to think.", "What could you say to avoid replying in the heat of the moment?"),
                new("Ask for specifics", 4, [P("Asking for one example can make it clearer what could change. Clarify the deadline, standard, or situation without promising to accept everything said."), Practice(TechniqueId.FeedbackReview, "Sort through feedback")], "Write one question that would clarify the expectation.", "What is still too vague here?"),
                new("Choose the useful part", 4, [P("You can consider a specific comment, clarify what is disputed, and reject a label. The aim is to choose your next step, not prove your worth."), Warning("Threats, humiliation, discrimination, or pressure call for boundaries and support, not self-criticism.")], "Choose one point you are willing to check or discuss.", "What can I influence, and what do I not have to accept?"),
                new("Close with a calm next step", 4, [P("Agree on one action or a time to review it. If you cannot reach agreement, you can record the facts and consult a trusted person or relevant workplace or school policy."), Quiz("Which reply best helps clarify what to do next?", 1, "A specific question clarifies expectations; a pause leaves room to choose your response.", "Agree with everything to end the conversation.", "Ask for an example or standard and reply later.", "Decide that one mistake describes your whole self."), TestsTab("A strong reaction to words does not prove they are true. WHO-5 is a general well-being screen, not a feedback test; score changes do not prove the course caused an effect.", "who5")], "Try one question or reply that respects your boundaries.", "What small next step will you choose?")
            ]),
        new(
            CourseIds.ConnectionWithoutPressure,
            "Connection at your own pace",
            "Five small steps to identify the kind of connection you want, choose a safe format, and make a low-pressure invitation.",
            "Group", "who5", "WHO-5",
            [
                new("Name the kind of connection you want", 4, [P("Sometimes you want a conversation; sometimes a shared activity, quiet company, or practical help. You do not need to aim for a certain number of contacts."), See(ArticleIds.Loneliness, "Loneliness"), TestsTab("WHO-5 is a general well-being screen for the past two weeks, not a loneliness measure or diagnosis. A score change alone does not prove the course caused an effect.", "who5")], "Choose one kind of connection that would feel useful now.", "What does comfortable connection mean to me?"),
                new("Choose a safe format", 4, [P("Think about who and how feels safer: one to one, in a group, online, or by a short message. A pause is an option; do not contact someone you feel unsafe around.")], "Name a person, group, or format that feels safe enough.", "What format would make it easier to start?"),
                new("Invite without pressure", 4, [P("A brief, specific invitation is easier to accept or decline. Leave the other person room to choose a time or say no."), See(ArticleIds.SupportRequest, "How to ask for support"), Practice(TechniqueId.ConnectionStepPlan, "Plan a small connection")], "Draft an invitation for a short walk, conversation, or shared activity.", "How can I leave the other person free to choose?"),
                new("Leave room to adjust", 4, [P("Start with a convenient time and an easy way to end. If energy is low, make the plan smaller or move it. A reply or no reply does not define your worth."), Practice(TechniqueId.ConnectionStepPlan, "Plan a small connection")], "Choose a simple format and decide when you could end or reschedule.", "How can I support myself if plans change?"),
                new("Reflect without judging yourself", 4, [P("Notice whether it felt safe and worthwhile and whether you would repeat or change the format. Do not rate yourself by message counts or someone else's response."), Quiz("What is useful to notice after a small connection?", 0, "It is useful to review the format and your own experience. Someone else's response does not measure your worth.", "Did it feel safe and comfortable, and what could I adjust?", "How many messages did I get in an hour?", "Does no reply prove people do not want to see me?"), TestsTab("WHO-5 is a general well-being screen for the past two weeks, not a loneliness measure or diagnosis. A score change alone does not prove the course caused an effect.", "who5")], "Choose one format you want to try or adjust.", "What small step fits me now?")
            ]),
        new(
            CourseIds.Boundaries,
            "Communicating boundaries",
            "Four short steps to identify your limits, state them clearly, and choose a safe response.",
            "Forum", "who5", "WHO-5",
            [
                new("What matters to me", 4, [P("Assertive communication means stating what you need while respecting the other person's right to respond. It does not guarantee agreement and is never an obligation."), H("Three ways to respond"), List("Stay silent when you disagree", "Pressure or insult in return", "Calmly state your position and request"), Quiz("Which response is assertive?", 2, "A clear, calm message expresses your position while leaving the other person free to respond.", "Agree when you do not want to", "Raise your voice until they agree", "Say: “I can’t today. Could we discuss another day?”"), TestsTab("WHO-5 is a general well-being screen for the past two weeks, not an assertiveness measure or diagnosis.", "who5"), Crisis("I need help now")], "Notice one safe situation where you would like to state a limit. You do not need to act yet.", "What matters to you in this situation?"),
                new("Say no clearly and briefly", 4, [P("A refusal can be brief and polite. You do not have to explain it in detail; if it suits you, you may offer another option, but you do not have to."), List("“I can’t right now”", "“I’m not able to take this on”", "“I need to think. I’ll reply tomorrow”"), P("If someone keeps pressing, calmly repeat your main sentence. You do not have to prove that your reason is good enough.")], "Prepare one refusal for a low-risk everyday situation.", "Which words sound natural for you?"),
                new("Make a specific request", 4, [P("A specific request is easier to understand than a hint or accusation. Name the situation, what matters to you, and one manageable option."), Quiz("Which request is clearer?", 1, "A specific request describes an action and time without guessing the other person's motives.", "“You never listen to me”", "“When you have a moment, could you listen for ten minutes?”", "Say nothing and hope they guess"), P("The other person may agree, suggest a compromise, or decline. You still have the right to ask and choose your next step.")], "Write or simply think through one brief request.", "What could you make more specific?"),
                new("Choose a safe next step", 4, [P("Start with a lower-risk situation and decide in advance what you might do after different responses. You can postpone or end a conversation, or have support with you."), P("If being direct could lead to threats, violence, punishment, or more control, do not practise alone. Put safety first and contact a trusted person or service."), TestsTab("WHO-5 measures general well-being, not boundary skills. A score change alone does not prove the course had an effect.", "who5")], "Choose one safe step: say the phrase, seek support, or make no change for now.", "What would be a kind next step for you?")
            ]),
        new(
            CourseIds.WorkRecovery,
            "Recovering after work",
            "Four days to notice what helps you switch off, choose manageable rest, and protect time away from work.",
            "TipsAndUpdates", "pss10", "PSS-10",
            [
                new("What helps me recover", 4, [P("Different ways of resting suit different people. Research looks at switching attention from work, relaxing, doing something engaging, and choosing your own pace or timing. These are options, not a checklist."), H("Ideas to try"), List("A quiet pause or calm rest", "An activity that absorbs you or teaches something new", "Time with others or on your own", "Gentle movement, if it suits you"), TestsTab("PSS-10 measures perceived stress over the past month. It does not diagnose burnout or measure recovery from work.", "pss10"), Crisis("I need help now")], "Notice one way of resting that sometimes helps or feels manageable.", "What helps you shift your attention, even a little?"),
                new("End the workday gently", 4, [P("Unfinished tasks can keep occupying your attention. If you can, choose a small end-of-work cue: close work tabs, note the first step for tomorrow, or change clothes."), P("Adapt this to shifts, on-call duties, and urgent responsibilities. Keep alerts that you need for safety or work.")], "Choose a brief end-of-work cue that fits your schedule.", "What could help you notice the shift to personal time?"),
                new("Choose rest without a perfect plan", 4, [P("Rest does not need to become another task. Ask whether quiet, company, an engaging activity, or doing nothing fits best right now."), List("Make an activity shorter", "Choose something that needs little preparation", "Let yourself change your mind"), P("Research finds associations between some recovery experiences and well-being, but it does not promise the same effect for everyone. Notice your own experience.")], "Try a small version of rest, or choose when you could return to it.", "What felt pleasant, neutral, or not right for you?"),
                new("Protect workable personal time", 4, [P("You may not control every demand. If work keeps intruding on rest, consider discussing priorities, deadlines, or support with a manager, colleague, or someone you trust."), P("If the conditions cannot change yet, that is not a personal failure. Choose only what is within reach, such as a pause, a short activity, or when to next check work."), TestsTab("A repeat PSS-10 is only a general stress screen. A score difference does not show why things changed or measure this course's effect.", "pss10")], "Keep one small adjustment you would like to try this week.", "What would you like to keep or change next?")
            ]),
        new(
            CourseIds.SelfCompassion,
            "Be kinder to yourself after a mistake",
            "Four short steps to notice self-criticism, separate facts from labels, and choose a helpful response.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Notice the inner critic", 4, [P("After a mistake, self-criticism can turn one action into a label for your whole self. You do not have to argue with it or force positive thinking; first separate what happened from your judgment of yourself."), H("Fact and label"), List("I forgot to reply — a fact", "I am a terrible friend — a label", "What could help repair this? — a question"), TestsTab("WHO-5 is a general well-being screen for the past two weeks. It does not measure self-compassion or prove a course effect.", "who5"), Crisis("I need help now")], "Notice a self-critical label and try to describe the event without judging yourself. You do not need to write it down.", "What happened when you remove the label?"),
                new("Speak to yourself as you would to a friend", 4, [P("Imagine someone close to you made the same mistake. Being supportive does not mean excusing everything; it can help you see the whole situation and choose a next step."), Quiz("Which response is both kind and honest?", 2, "It acknowledges the mistake without attacking the person and points to a practical next step.", "You always ruin things", "It does not matter at all", "You made one mistake; let's see what can be repaired")], "Say one truthful sentence to yourself without putting yourself down.", "How does that sentence sound?"),
                new("Repair what you can, without punishing yourself", 4, [P("Kindness to yourself can go together with responsibility. You can acknowledge an impact and repair what is possible without turning one mistake into a verdict on your whole self."), List("What exactly happened?", "Who or what was affected?", "What small step could help now?"), P("Not everything can be repaired right away. You can still learn from it and ask someone you trust for advice.")], "Choose one manageable action to repair or support.", "What is within your control now?"),
                new("Plan a kind next step", 4, [P("Make a short plan for next time: notice self-criticism, pause, and choose one helpful action. Change the plan if it does not fit."), TestsTab("A repeat WHO-5 is only a general well-being screen. A score difference does not measure self-compassion or prove a course effect.", "who5")], "Keep one sentence or action you can return to.", "What would you like to try next time?")
            ]),
        new(
            CourseIds.SupportSomeone,
            "Support someone with care",
            "Four steps to ask, listen, offer manageable help, and involve more support when needed.",
            "Group", "pss10", "PSS-10",
            [
                new("Start with a simple question", 4, [P("Choose a calm time and place if it is safe. Ask whether the person wants to talk; you do not have to guess or insist."), List("How are you right now?", "Would you like to talk, or just have some company?", "Is there anything I can do to help?"), TestsTab("PSS-10 measures perceived stress over the past month. It does not measure support skills or assess another person's condition.", "pss10"), Crisis("I need help now")], "Think of one open, low-pressure question. You do not have to ask it right away.", "How can you show that it is okay to decline the conversation?"),
                new("Listen without rushing to fix things", 4, [P("Let the person finish and allow pauses. Check that you understood instead of immediately advising, comparing, or diagnosing."), Quiz("Which response leaves more room for the person?", 1, "An open question lets them choose what they want to share.", "You just need to take your mind off it", "What feels hardest right now?", "I have been through that, so I know what you should do")], "Reflect back what you heard in your own words, then ask if you got it right.", "What changes when you do not rush to give advice?"),
                new("Offer a choice of help", 4, [P("Support can be simple and specific. Ask what would help most right now: listening, help with one task, or looking for information together. Offer only what you can genuinely do."), List("Would you like me to listen?", "Can I help with one specific thing?", "Would you like to think together about whom to contact?"), P("If they say no, respect that. You can leave the door open to talk later.")], "With their permission, offer one concrete option, or think of one you could offer in the future.", "What kind of help is manageable for both of you?"),
                new("Involve more support and keep your limits", 4, [P("You can be present without handling everything alone or being the only support. Be honest about when you are available and suggest involving someone trusted or a professional."), P("If they describe immediate danger or cannot stay safe, do not carry it alone: involve local emergency or crisis support if possible. Do not promise to keep a threat to life secret."), TestsTab("A repeat PSS-10 is only a general indicator of perceived stress, not a rating of your support or evidence of course effect.", "pss10")], "Choose one boundary or extra source of support so you are not carrying the strain alone.", "Who could support you?")
            ]),
        new(
            CourseIds.TaskStart,
            "Start what you keep putting off",
            "Three steps: make the start smaller, choose a time, and continue without blame.",
            "Checklist", "who5", "WHO-5",
            [
                new("Choose one task", 3, [P("Putting something off can come from an unclear first step or an uncomfortable feeling, not laziness. Name the task and the first visible action."), TestsTab("WHO-5 is a general well-being screen for the past two weeks; it does not measure this course skill or prove a course effect.", "who5"), Crisis("I need help now")], "Choose one task and a first step that takes up to five minutes.", "What would make the start clearer?"),
                new("Make starting easier", 3, [P("Prepare what you need and pick a time. You can begin for five minutes, then decide whether to continue.")], "Write when, where, and how you will start.", "What might get in the way, and how could you simplify it?"),
                new("Support the next step", 3, [P("Review without blame: what helped you start, what got in the way, and what is realistic now? Sometimes the task itself needs revising.")], "Keep one approach that helped you get moving.", "What did you learn about how you get started?")
            ]),
        new(
            CourseIds.FlexibleStandards,
            "Let good enough be enough",
            "Notice when high standards help and when they make it harder to finish.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("Notice the cost of perfect", 3, [P("High standards can help, until they take too much time, rest, or the chance to finish. Notice one rule you set for yourself."), TestsTab("WHO-5 is a general well-being screen for the past two weeks; it does not measure this course skill or prove a course effect.", "who5"), Crisis("I need help now")], "Choose one example where a standard is getting in the way.", "What does that rule give you, and what does it cost?"),
                new("Define enough", 3, [P("Ask who needs the result and what it actually needs to do. Choose two or three quality checks instead of polishing without end.")], "Set a realistic finish line for one task.", "What could you stop improving?"),
                new("Try a small experiment", 3, [P("If it feels safe, leave a small imperfection or finish when a timer ends. This is an experiment, not a demand to stop caring about quality.")], "Choose a gentle experiment, or simply notice the rule.", "What did you expect, and what happened?")
            ]),
        new(
            CourseIds.ThoughtLoops,
            "When thoughts keep looping",
            "Notice a repeating thought and bring attention back to what you choose to do.",
            "Psychology", "gad7", "GAD-7",
            [
                new("Notice the loop", 3, [P("A repeating thought can feel like problem-solving, but may not bring a new answer. Notice when it returns and what tends to trigger it."), TestsTab("GAD-7 measures general anxiety over the past two weeks; it is not a diagnosis or a test of this course skill.", "gad7"), Crisis("I need help now")], "Notice one moment when a thought starts looping.", "What often starts the loop?"),
                new("Separate a thought from a fact", 3, [P("Try naming it as a thought: “I notice the thought that…” This does not dismiss the problem; it keeps a prediction from becoming a fact.")], "Name one thought neutrally, without arguing with it.", "What changes when you call it a thought?"),
                new("Return to what you chose", 3, [P("You do not need to push the thought away. Notice it, then gently return to what you are doing; if action is needed, choose a time and one step.")], "Choose a small action for the next ten minutes.", "Where would you like to place your attention?")
            ]),
        new(
            CourseIds.UncertainDecisions,
            "Decide without full certainty",
            "Compare facts, what matters to you, and one manageable next step.",
            "Checklist", "gad7", "GAD-7",
            [
                new("Separate facts from guesses", 3, [P("Some information may be unavailable in a difficult choice. Note what you know, what you assume, and what cannot be known yet."), TestsTab("GAD-7 measures general anxiety over the past two weeks; it is not a diagnosis or a test of this course skill.", "gad7"), Crisis("I need help now")], "Sort one question into facts and assumptions.", "Which fact would be most useful to clarify?"),
                new("Name your priorities", 3, [P("Compare options using what matters to you: safety, time, relationships, resources, or other values. There may be no perfect option.")], "Choose two priorities and compare the options.", "What matters most for you to protect?"),
                new("Choose a next step", 3, [P("If possible, choose a small, reversible step and a date to review it. This leaves room for new information without promising to know the outcome.")], "Set one step and a time to review it.", "How could you check the decision later?")
            ]),
        new(
            CourseIds.PauseBeforeReply,
            "Pause before replying",
            "Notice rising tension, take a pause, and decide whether to answer now.",
            "TipsAndUpdates", "pss10", "PSS-10",
            [
                new("Notice tension early", 3, [P("Irritation or worry can show up in the body or the speed of your speech before you have thought through a reply. Notice your early sign."), TestsTab("PSS-10 measures perceived stress over the past month; it does not measure this course skill or prove a course effect.", "pss10"), Crisis("I need help now")], "Recall one body signal or change in behaviour.", "How do you notice it is time to slow down?"),
                new("Take a short pause", 3, [P("If it is safe, delay your reply, feel your feet on the floor, and name what is happening. You do not have to make yourself calm immediately.")], "Prepare a phrase: “I need a little time. I’ll reply later.”", "What kind of pause is realistic for you?"),
                new("Reply with intention", 3, [P("When ready, choose your aim: clarify, ask, set a limit, or end the conversation. If it is unsafe, focus on leaving and getting support.")], "Prepare one sentence that expresses your aim.", "What would you like the other person to understand?")
            ]),
        new(
            CourseIds.IrritationSignals,
            "Notice irritation early",
            "Spot early signals, lower the intensity, and choose a safe response.",
            "Forum", "pss10", "PSS-10",
            [
                new("Find an early signal", 3, [P("Irritation can signal tension or a need, but it is not an instruction. Notice what changes in your body, thoughts, or behaviour."), TestsTab("PSS-10 measures perceived stress over the past month; it does not measure this course skill or prove a course effect.", "pss10"), Crisis("I need help now")], "Name one early signal.", "What often happens before irritation rises?"),
                new("Lower the intensity safely", 3, [P("If possible, step away to a safe place and slow your breathing or notice your surroundings. You do not have to stay in an argument.")], "Choose one safe way to pause.", "How will you know a pause is needed?"),
                new("Choose what comes next", 3, [P("When the intensity eases, name what you need: time, clarity, help, or a limit. You can return later, or not return if it is unsafe.")], "Prepare a request or action for next time.", "What could help you avoid reaching your limit?")
            ]),
        new(
            CourseIds.ConflictRepair,
            "Reconnect after an argument",
            "Own your part, apologise without pressure, and discuss a next step.",
            "Forum", "who5", "WHO-5",
            [
                new("Describe the action, not the person", 3, [P("After an argument, name a specific action rather than labelling yourself or the other person as bad. Reconnecting is only an option when it is safe."), TestsTab("WHO-5 is a general well-being screen for the past two weeks; it does not measure this course skill or prove a course effect.", "who5"), Crisis("I need help now")], "Describe your part in one factual sentence.", "What would you like to clarify?"),
                new("Apologise specifically", 3, [P("An apology names the action and its possible impact without an excuse or demand for forgiveness. You can say what you will try to do differently.")], "Draft a short apology without adding “but”.", "What are you willing to take responsibility for?"),
                new("Leave room for a response", 3, [P("Give the other person room to reply and set their own limits. Reconciliation is not guaranteed; sometimes it is enough to agree on a practical next step.")], "Choose one request or limit to discuss.", "What outcome would be acceptable and safe?")
            ]),
        new(
            CourseIds.LifeTransitions,
            "Adjust to change at your pace",
            "Keep familiar supports, name what changed, and choose one manageable step.",
            "TrackChanges", "pss10", "PSS-10",
            [
                new("Name what changed", 3, [P("A new job, move, study, or family change can affect several routines at once. You do not have to adjust quickly."), TestsTab("PSS-10 measures perceived stress over the past month; it does not measure this course skill or prove a course effect.", "pss10"), Crisis("I need help now")], "Name one change and how it affects your day.", "What feels harder or different now?"),
                new("Keep one familiar support", 3, [P("Keep one simple anchor that helps your rhythm: a meal time, short walk, conversation, or evening routine. Adapt it to new conditions.")], "Choose one familiar anchor for this week.", "What can stay, even while things change?"),
                new("Take the next step", 3, [P("Break adjustment into small questions: what to learn, whom to ask, and what can wait. Your pace may change.")], "Choose one question or action for the next few days.", "What support could make this change easier?")
            ]),
        new(
            CourseIds.GriefAtYourPace,
            "Grieve at your own pace",
            "No deadlines or required stages: care for basic needs and find support.",
            "Healing", "who5", "WHO-5",
            [
                new("Make room for what you feel", 3, [P("After a loss, people feel different things in different ways. There is no required timeline for grief and no need to do it “right”."), TestsTab("WHO-5 is a general well-being screen for the past two weeks; it does not measure this course skill or prove a course effect.", "who5"), Crisis("I need help now")], "Name what feels hardest or what you do not feel ready to do.", "What would you like to allow yourself today?"),
                new("Make the day manageable", 3, [P("On a hard day, choose one basic need or small task. You can ask someone close to stay with you or help with something practical.")], "Reduce one task to a manageable step.", "What kind of care do you need today?"),
                new("Do not carry it alone", 3, [P("If you want, find a way to remember the person or talk about the loss. If grief keeps making daily life hard over time, professional support is an option.")], "Choose a person or service you could contact.", "What kind of support would feel gentle now?")
            ]),
        new(
            CourseIds.ReturnToFocus,
            "Return to focus after an interruption",
            "Capture the interruption, choose the next action, and restart gently.",
            "TipsAndUpdates", "who5", "WHO-5",
            [
                new("Notice the interruption", 3, [P("Getting distracted is a normal part of working. Notice what drew you away: a notification, new thought, tiredness, or unclear step."), TestsTab("WHO-5 is a general well-being screen for the past two weeks; it does not measure this course skill or prove a course effect.", "who5"), Crisis("I need help now")], "Name one common source of interruption.", "What most often breaks your focus?"),
                new("Capture it and return", 3, [P("Write down the distracting task briefly so you do not have to hold it in mind. Then name one next action for your current task.")], "Make a note and choose a five-minute action.", "What first step would bring you back?"),
                new("Make the setting easier", 3, [P("Remove one optional interruption and decide what to do next time you are pulled away. If you are very tired, a break may help more than pushing.")], "Change one setting in your workspace or notifications.", "What helps you restart without blame?")
            ]),
        new(
            CourseIds.StudyBlocks,
            "Study in short blocks",
            "Choose one learning goal, a short focus block, and a recovery break.",
            "Checklist", "pss10", "PSS-10",
            [
                new("Set one study goal", 3, [P("Choose one clear result for a study block: solve a problem, read a short section, or explain a topic. The larger goal can wait."), TestsTab("PSS-10 measures perceived stress over the past month; it does not measure this course skill or prove a course effect.", "pss10"), Crisis("I need help now")], "Write one result for a short study session.", "How will you know this block is done?"),
                new("Find your own rhythm", 3, [P("Choose a focus and break length that suits you. A standard timer is optional; adjust it to your attention and health.")], "Try one short block followed by a break.", "What rhythm felt manageable?"),
                new("Check what you remember", 3, [P("After a break, try recalling the main points without looking, then check the material. A gap shows what to revisit; it does not rate your worth.")], "Name three things you remember.", "What could you review next?")
            ]),
        new(
            CourseIds.BodyNeutrality,
            "Look at appearance more neutrally",
            "Reduce comparisons, use neutral attention, and return to activities that matter.",
            "Healing", "who5", "WHO-5",
            [
                new("Notice attention on appearance", 3, [P("Many people feel unhappy with their appearance at times, but frequent checking and comparison can take energy. You do not have to force yourself to love every feature."), TestsTab("WHO-5 is a general well-being screen for the past two weeks; it does not measure this course skill or prove a course effect.", "who5"), Crisis("I need help now")], "Notice when appearance thoughts take your attention.", "What do you put off because of these thoughts?"),
                new("Try a neutral view", 3, [P("Instead of judging, describe what you notice neutrally or what your body helps you do today. You do not have to feel grateful or satisfied.")], "Replace one judgment with a neutral observation.", "What words feel less harsh and more accurate?"),
                new("Return to what matters", 3, [P("Choose an activity that matters for reasons beyond appearance: connection, study, rest, or a hobby. If body concerns disrupt eating, health, or daily life, professional support may help.")], "Return to one small activity you have delayed.", "What matters to you beyond appearance?")
            ]),
        new(
            CourseIds.SelfWorth,
            "Worth more than achievements",
            "Notice your roles and qualities beyond results, then choose a meaningful action.",
            "TrackChanges", "who5", "WHO-5",
            [
                new("See beyond results", 3, [P("Work and success are part of life, not the measure of your whole worth. Recall roles, relationships, and qualities that matter regardless of productivity."), TestsTab("WHO-5 is a general well-being screen for the past two weeks; it does not measure this course skill or prove a course effect.", "who5"), Crisis("I need help now")], "Name one role or quality that matters to you.", "What is valuable about you without a result?"),
                new("Find a specific example", 3, [P("Recall a small example of kindness, courage, curiosity, or reliability. You do not have to prove you are always that way; one moment is enough.")], "Find one recent example.", "What do you usually overlook about yourself?"),
                new("Act on what matters", 3, [P("Choose an action that expresses a quality you value but does not depend on achievement or praise. It can be very small.")], "Do or plan one such action.", "What does this step say about what matters to you?")
            ]),
        new(
            CourseIds.SocialSteps,
            "Take small steps in social situations",
            "Choose a safe interaction, check your expectations, and move at your own pace.",
            "Group", "gad7", "GAD-7",
            [
                new("Choose a manageable situation", 3, [P("If social situations feel worrying, start with one that feels mildly challenging and safe. You can decline a step that does not feel right."), TestsTab("GAD-7 measures general anxiety over the past two weeks; it is not a diagnosis or a test of this course skill.", "gad7"), Crisis("I need help now")], "Choose one brief interaction that matters to you.", "What feels manageable, rather than perfect?"),
                new("Check your expectation", 3, [P("Before the interaction, note what you fear and what else could happen. You do not have to prove the worry wrong; leave room for other outcomes.")], "Write one prediction and one alternative.", "What did you notice during the interaction?"),
                new("Learn from your experience", 3, [P("Afterwards, note what helped, what was hard, and what next step suits you. You choose the pace, repetitions, and pauses.")], "Choose whether to repeat, reduce, or pause the step.", "What helped you feel safer?")
            ]),
        new(
            CourseIds.AppointmentPreparation,
            "Prepare for an important appointment",
            "Gather questions, name your priority, and clarify next steps with a professional.",
            "Forum", "pss10", "PSS-10",
            [
                new("Name what matters most", 3, [P("Before an appointment, decide which question matters most and what you hope to discuss. You do not need to diagnose yourself in advance."), TestsTab("PSS-10 measures perceived stress over the past month; it does not measure this course skill or prove a course effect.", "pss10"), Crisis("I need help now")], "Write your main topic in one sentence.", "What is important to remember to ask?"),
                new("Prepare short notes", 3, [P("If useful, note when the concern began, what has changed, and any medicines or questions that matter. You may bring someone with you if you choose.")], "Prepare up to three questions or observations.", "What notes could make it easier to speak?"),
                new("Clarify the plan", 3, [P("Ask the professional to explain unfamiliar words and the next step. You can ask again or say you are not ready to decide yet.")], "Prepare a phrase to ask for clarity or time.", "What would help you understand the plan?")
            ]),
        new(
            CourseIds.WaitingForAnswer,
            "Get through waiting for an answer",
            "Limit checking, keep a routine, and choose what is within your control.",
            "Psychology", "gad7", "GAD-7",
            [
                new("Separate waiting from control", 3, [P("Waiting for a reply can take over your attention, even when you cannot make it arrive sooner. Separate what you can do from what is outside your control."), TestsTab("GAD-7 measures general anxiety over the past two weeks; it is not a diagnosis or a test of this course skill.", "gad7"), Crisis("I need help now")], "Write one thing in each group.", "What can you do, and what must wait?"),
                new("Set a time to check", 3, [P("Choose a reasonable time to check messages or status again. Between checks, return to an ordinary task or rest.")], "Set the next time you will check.", "What could help you avoid automatic checking?"),
                new("Prepare for either outcome", 3, [P("Choose a small next step for a reply and for a delay. This is not a prediction; it gives you a choice while you wait.")], "Set a date to follow up if needed.", "What would you like to lean on while waiting?")
            ]),
        new(
            CourseIds.AskForHelp,
            "Ask for specific help",
            "Name what you need, whom you could ask, and what feels manageable.",
            "Group", "who5", "WHO-5",
            [
                new("Identify what you need", 3, [P("A request is easier to hear when it is specific: time, a conversation, information, or help with one task. You do not have to manage everything alone."), TestsTab("WHO-5 is a general well-being screen for the past two weeks; it does not measure this course skill or prove a course effect.", "who5"), Crisis("I need help now")], "Name one need without explaining why.", "What help could change things a little?"),
                new("Choose a person and words", 3, [P("Think who could help with this need. A brief request with a clear action and time makes it easier to answer.")], "Draft one sentence asking for help.", "Who could you ask, and when?"),
                new("Allow different answers", 3, [P("Someone may agree, offer another option, or decline. Your need still matters; you can ask someone else or contact a service.")], "Choose a backup source of support.", "How will you care for yourself after asking?")
            ]),
        new(
            CourseIds.CaregiverLimits,
            "Care for someone without losing yourself",
            "Share responsibilities, name your limits, and find additional support.",
            "Group", "pss10", "PSS-10",
            [
                new("Notice the amount of care", 3, [P("Supporting someone can involve many invisible tasks. List the main responsibilities and notice what truly needs your involvement."), TestsTab("PSS-10 measures perceived stress over the past month; it does not measure this course skill or prove a course effect.", "pss10"), Crisis("I need help now")], "Name one task that could be discussed or shared.", "What is draining you most right now?"),
                new("Name a limit", 3, [P("A limit does not mean abandoning someone. It is an honest description of the time, energy, or actions you can offer safely.")], "Phrase one limit on your support.", "How could you say it clearly and calmly?"),
                new("Find more support", 3, [P("Think of people, services, or practical changes that could share the load. If care cannot be provided safely, seek professional or emergency help.")], "Choose one source of additional support.", "Who could you contact this week?")
            ]),
        new(
            CourseIds.LowEnergyRoutine,
            "A gentler plan for low-energy days",
            "Keep the necessary minimum, make the first step smaller, and include rest.",
            "TipsAndUpdates", "who5", "WHO-5",
            [
                new("Choose the minimum", 3, [P("On a low-energy day, you do not have to complete your usual plan. Choose one necessary task and what can wait."), TestsTab("WHO-5 is a general well-being screen for the past two weeks; it does not measure this course skill or prove a course effect.", "who5"), Crisis("I need help now")], "Reduce your list to one important item.", "What truly cannot wait today?"),
                new("Make the first step smaller", 3, [P("Break the task into a two-minute action and prepare what you need. If even that is too much, ask someone for help.")], "Choose the smallest safe next step.", "What would make it easier?"),
                new("Include recovery", 3, [P("Plan a short rest without needing to earn it. If low energy or low mood keeps interfering with life, professional support is an option.")], "Choose a simple pause or someone to contact.", "What could help you not carry this alone?")
            ]),
        new(
            CourseIds.AfterDifficultTalk,
            "Recover after a difficult conversation",
            "Return to the present, separate facts from guesses, and choose a safe next step.",
            "Psychology", "pss10", "PSS-10",
            [
                new("Lower the tension", 3, [P("After a difficult conversation, your body may need time. Find a point of support, look around, and name where you are. You do not have to decide who was right yet."), TestsTab("PSS-10 measures perceived stress over the past month; it does not measure this course skill or prove a course effect.", "pss10"), Crisis("I need help now")], "Take a short pause and notice your surroundings.", "What helps you feel here and now?"),
                new("Separate words from conclusions", 3, [P("Note what was said or done separately from what you assume it meant. This does not dismiss your feelings; it helps you choose what to do next.")], "Separate one fact from one interpretation.", "What do you know, and what are you assuming?"),
                new("Choose whether to continue", 3, [P("You can clarify, ask for time, or not continue contact. If the conversation involves threats or control, do not return to it alone.")], "Choose one safe option for next time.", "What boundary or support do you need?")
            ]),
    ];
}
