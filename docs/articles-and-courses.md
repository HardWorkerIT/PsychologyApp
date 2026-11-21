# Articles and courses

**Status:** psychoeducation and self-help copy, to be reviewed by a clinical psychologist (and the "see a doctor" lists by a physician)
before release.

## Why courses

Reading about anxiety or sleep changes little by itself. Guided self-help — short reading, an exercise, a task between sessions and a
measure at the start and the end — has clear effects for anxiety, depression and insomnia (Cuijpers et al.; for insomnia, digital
CBT-I). The Library tab therefore has courses besides articles, and the articles themselves ask for an answer, not only reading.

## What the Library has

The Library is the "Materials" group of the burger menu: For you, Courses, Articles, Prayers, Quotes. Each part opens as its own page
over the current tab (the tab bar stays), so nothing has to be scrolled past to reach the articles.

| Part | What it does | Where |
| --- | --- | --- |
| For you | Up to three picks from what the app already knows on the device: a course in progress, an article not read to the end, recent questionnaire results (PCL-5 / PC-PTSD-5, PHQ-9, ISI, GAD-7 against published cut-offs), three or more hard days in the mood journal | `ReadingRecommender` |
| Courses | Existing courses plus twenty three-day practical courses (procrastination, perfectionism, rumination, decisions, conflict repair, transitions, grief, study, body image, care and more; see below) | `CourseContent.*` |
| Search | Every word of the query in the title, summary or text; "ё" = "е"; title matches first | `ArticleSearch` |
| Saved | Listed under "For you", below the picks | `ReadingState.Saved` |
| Read marks | An article counts as read once its end is on screen, not on opening | `ArticleReaderPage` |
| Listening | The phone's own speech engine reads the article part by part; only the app's text is spoken, never what the person wrote | `ArticleSpeech`, `ReadAloud` |

## Interactive blocks

`ArticleBlockKind`: `Checklist` ("do I recognise this?", a verdict at a threshold, never a diagnosis), `Quiz` (one answer, then the right
one and why: recalling fixes knowledge better than rereading), `Cycle` (a vicious circle written out step by step, readable by screen
readers and at large text sizes), `Breathe` (the breathing pacer, 4 in / 6 out, one minute, inside the article), `Tests` (opens one
questionnaire by id), `Article` (a link to another article), `Task` (a course day's task).

## Course rules

- One day at a time; the next day opens on the next calendar day, so the task has time to be tried (`CourseRules`, tested).
- Each day ends with a question answered in one's own words. The answer is kept only in the encrypted database and the backup.
  Words that read as a crisis do not close the day: the screen leads to crisis help.
- The measure: the course's questionnaire at the start (a result up to 30 days before the start counts) and the latest one
  (`CourseMeasure`, tested).
- The trauma course does not ask to recall or describe the event; processing a trauma takes a therapist (see trauma-module.md).
  Sleep compression in the sleep course keeps at least six hours in bed and is not for bipolar disorder, epilepsy, pregnancy or
  dangerous sleepiness.

## Storage

`ReadingState` (read, saved, last opened, course progress with answers) is one JSON document in `AppMetadata` (`ReadingRepository`,
source-generated), included in the backup; a backup is restored only when nothing is stored yet, so restoring an old file never erases
newer progress.

## Problem planning

The three-day planning course and its article use small, adjustable steps and distinguish problems within a person’s influence from other worries. The GAD-7 is an optional measure of anxiety symptoms, not a measure of planning skill or a diagnosis. Sources: [NHS problem solving](https://www.nhs.uk/every-mind-matters/mental-wellbeing-tips/self-help-cbt-techniques/problem-solving/) and [WHO stress management guide](https://tdr.who.int/home/our-work/global-engagement/9789240003927). Text and translations need clinical and native-speaker review before release.

## Habit formation and recovery

- **A new habit: one small action and a cue** explains how to link a manageable action to a recurring context, reduce friction, and resume after a missed opportunity. In a real-world study, habit automaticity developed at very different rates; a single missed opportunity did not materially affect the process. This is not a promise or a deadline for an individual ([Lally et al., 2010](https://doi.org/10.1002/ejsp.674)).
- **Recovering after work: find a way that fits** presents switching off, relaxation, doing something different, and choosing how to spend free time as options rather than a checklist. A longitudinal study associated weekend recovery experiences with affect during the weekend and following workweek; the article does not claim that a particular activity causes recovery or suits everyone ([Fritz et al., 2010](https://doi.org/10.1002/job.672)).
- Both articles and four linked anchor thoughts are available in all seven app languages. The content and translations still need review by a clinical psychologist and native speakers before release.

## Exam anxiety and caregiver wellbeing

- **Before an exam: prepare and work with anxiety** separates anxiety from knowledge and offers short study cycles, low-stakes practice, and practical exam-day steps. A meta-analysis found post-treatment benefits for several interventions, while long-term evidence and study quality were limited ([von der Embse et al., 2018](https://pubmed.ncbi.nlm.nih.gov/30826687/)). Practice testing may also help some learners, but the evidence is still developing and difficult tests can add stress ([Yang et al., 2023](https://eric.ed.gov/?id=EJ1390002)).
- **When you care for someone: keep some strength for yourself** covers noticing overload, making specific requests, and seeking support. A review found a small average reduction in caregiver distress with substantial variation across studies, so the article avoids promising that one strategy will work for everyone ([Liu et al., 2022](https://pubmed.ncbi.nlm.nih.gov/36276315/)).
- The exam-anxiety and caregiver articles with their six linked anchor thoughts are available in all seven languages. Together with the values, support-plan, attention, and expanded self-help articles below, the catalog now has 161 articles. The new clinical copy and translations need review before release; the article list is virtualized and does not need pagination.

## Values as a guide

- **Values as a guide: choose one manageable step** distinguishes ongoing directions (such as respect or curiosity) from specific outcomes and offers a small, flexible reflection exercise. A meta-analytic review of ACT research reported changes in psychological flexibility processes, including values-based action; it does not establish that one standalone exercise will have the same effect for everyone ([Gloster et al., 2024](https://pubmed.ncbi.nlm.nih.gov/38615492/)).
- The values article and five linked anchor thoughts are available in all seven app languages. Clinical review and native-speaker proofreading are still required. The 161-article library uses a virtualized `CollectionView`; article pagination is not needed. The quote feed already loads additional items on demand.

## When low mood returns

- **If low mood returns: make a support plan** helps people notice personal early signs, write down manageable next steps, and decide whom to contact. NICE relapse-prevention guidance recommends discussing warning signs and contingency plans with a care professional; this article does not diagnose relapse or advise medication changes ([NICE NG222, recommendations 1.8.4 and 1.8.7](https://www.nice.org.uk/guidance/ng222/chapter/recommendations)).
- The article and five linked anchor thoughts are available in all seven app languages. Clinical review and native-speaker proofreading are still required. The 161-article library remains virtualized; article pagination is not needed.

## Attention and ADHD assessment

- **Adult attention difficulties: when to discuss an ADHD assessment** distinguishes a persistent pattern from occasional distraction. NICE says assessment should include a developmental and clinical history, impact across life settings, and should not rely on a rating scale alone ([NICE NG87, recommendations 1.2.10 and 1.3.1–1.3.3](https://www.nice.org.uk/guidance/ng87/chapter/recommendations)). The NHS also notes that other conditions can affect attention and may need consideration ([NHS: ADHD in adults](https://www.nhs.uk/conditions/adhd-adults/)).
- The article and five linked anchor thoughts are available in all seven app languages. Clinical review and native-speaker proofreading are still required. The 161-article library uses a virtualized list; article pagination is not needed.

## Boundaries and work recovery

- **Communicating boundaries** offers low-pressure practice in identifying a limit, declining a request, making a specific request, and choosing a safe next step. It follows the broad skills sequence in the Centre for Clinical Interventions' assertiveness workbook, but uses original wording. Direct communication is explicitly optional when it could increase risk; safety and outside support come first ([CCI assertiveness workbook](https://www.cci.health.wa.gov.au/Resources/Looking-After-Yourself/Assertiveness)). WHO-5 is a general well-being screen, not a measure of assertiveness; score changes do not establish a course effect.
- **Recovering after work** treats detachment, relaxation, engaging activities, and choice over time or pace as options to experiment with, not a checklist or personal obligation. Meta-analyses find associations between recovery experiences and well-being, with different patterns across outcomes; the course does not promise that one activity will work for everyone or imply that workload is under the worker's control ([Headrick et al., 2023](https://doi.org/10.1007/s10869-022-09821-3)). PSS-10 measures perceived stress, not burnout or work recovery, and score changes do not establish a course effect.
- Both courses are present in all seven language catalogs. The wording and translations need clinical and native-speaker review before release.

## Self-compassion and supporting someone

- **Self-compassion after a mistake** uses a gradual sequence: notice self-criticism, distinguish an event from a global label, choose a responsible and kind response, and make a small plan for next time. It draws on the Centre for Clinical Interventions' self-compassion workbook while avoiding any promise that a brief course will change well-being ([CCI self-compassion resources](https://www.cci.health.wa.gov.au/Home/Resources/For-Clinicians/Self-Compassion)). WHO-5 remains a general well-being screen, not a self-compassion measure.
- **Supporting someone with care** practices asking, listening without rushing to advice, offering practical options with permission, and sharing responsibility for safety. Its structure reflects Samaritans' listening guidance and WHO psychological first aid's look, listen, link principles; it does not train users to diagnose or replace professional help ([Samaritans listening guidance](https://www.samaritans.org/how-we-can-help/if-youre-worried-about-someone-else/little-tips/), [WHO psychological first aid](https://www.who.int/publications/psychological-first-aid)). PSS-10 measures perceived stress, not supportive-listening skill.
- Both courses are translated across the seven catalogs. Psychological and native-speaker review is needed before release.

## Twenty short practical courses

Each course has three brief lessons, one small task and a reflection question per day. The first day includes the in-app help route. Available screening scales (WHO-5, GAD-7, PSS-10) are general well-being, anxiety or perceived-stress screens; they do not measure the specific course skill or prove course effectiveness.

1. Start a task you keep putting off
2. Let good enough be enough
3. When thoughts keep looping
4. Decide without full certainty
5. Pause before replying
6. Notice irritation early
7. Reconnect after an argument
8. Adjust to change at your pace
9. Grieve at your own pace
10. Return to focus after an interruption
11. Study in short blocks
12. Look at appearance more neutrally
13. Worth more than achievements
14. Take small steps in social situations
15. Prepare for an important appointment
16. Get through waiting for an answer
17. Ask for specific help
18. Care for someone without losing yourself
19. A gentler plan for low-energy days
20. Recover after a difficult conversation

The task sequences draw on CCI resources for [procrastination](https://www.cci.health.wa.gov.au/Resources/For-Clinicians/Procrastination), [perfectionism](https://www.cci.health.wa.gov.au/Resources/For-Clinicians/Perfectionism), and [appearance concerns](https://www.cci.health.wa.gov.au/en/Resources/Looking-After-Yourself/Appearance-Concerns), WHO's [stress-management guide](https://www.who.int/publications/b/53604), and NHS [grief guidance](https://www.nhs.uk/mental-health/feelings-symptoms-behaviours/feelings-and-symptoms/grief-bereavement-loss/). The course copy is original and needs psychologist and native-speaker review before release.

## Expanded short articles

- The catalog contains 100 additional two-minute articles across anxiety, thought patterns, energy and mood, emotions, trauma recovery, relationships, body-based coping, and finding support. Each is assigned to an existing topic section and participates in the existing title, summary, and full-text search. The catalog now has 161 articles in seven languages.
- The pieces offer small optional steps and avoid diagnosing, promising an outcome, or suggesting that self-help replaces professional care. Crisis-related guidance points toward trusted people and local urgent services. The framing was cross-checked against the [WHO stress management guide](https://tdr.who.int/home/our-work/global-engagement/9789240003927), [NICE guidance for anxiety and panic](https://www.nice.org.uk/guidance/cg113/chapter/Recommendations), [NICE depression guidance](https://www.nice.org.uk/guidance/ng222/chapter/recommendations), [NHS mental-health self-help](https://www.nhs.uk/every-mind-matters/mental-health-issues/), and [CCI self-help resources](https://www.cci.health.wa.gov.au/en/Resources/Looking-After-Yourself). These references inform editorial guardrails; the copy is original and still requires review by a clinical psychologist and native speakers before release.
