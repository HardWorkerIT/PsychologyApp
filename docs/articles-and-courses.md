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
| Courses | Sleep without pills (CBT-I, 7 days, ISI), Anxiety under control (6 days, GAD-7), Out of apathy (behavioural activation, 6 days, PHQ-9), After trauma (5 days, PCL-5), A plan for manageable tasks (3 days, GAD-7) | `CourseContent.Ru/.En` |
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
- The exam-anxiety and caregiver articles with their six linked anchor thoughts are available in all seven languages. Together with the values and support-plan articles below, the catalog now has 55 articles. The new clinical copy and translations need review before release; the article list is virtualized and does not need pagination.

## Values as a guide

- **Values as a guide: choose one manageable step** distinguishes ongoing directions (such as respect or curiosity) from specific outcomes and offers a small, flexible reflection exercise. A meta-analytic review of ACT research reported changes in psychological flexibility processes, including values-based action; it does not establish that one standalone exercise will have the same effect for everyone ([Gloster et al., 2024](https://pubmed.ncbi.nlm.nih.gov/38615492/)).
- The values article and five linked anchor thoughts are available in all seven app languages. Clinical review and native-speaker proofreading are still required. The 55-article library uses a virtualized `CollectionView`; article pagination is not needed. The quote feed already loads additional items on demand.

## When low mood returns

- **If low mood returns: make a support plan** helps people notice personal early signs, write down manageable next steps, and decide whom to contact. NICE relapse-prevention guidance recommends discussing warning signs and contingency plans with a care professional; this article does not diagnose relapse or advise medication changes ([NICE NG222, recommendations 1.8.4 and 1.8.7](https://www.nice.org.uk/guidance/ng222/chapter/recommendations)).
- The article and five linked anchor thoughts are available in all seven app languages. Clinical review and native-speaker proofreading are still required. The 55-article library remains virtualized; article pagination is not needed.
