# Chat companion

The assistant is shown as **AI chat** (ИИ-чат), the owner's choice of name. The label must not be read as a cloud model: the status line
says it works on the phone without internet, and its answers about itself say it is a self-help assistant, not a person and not a
doctor. It has no grammatical gender in its replies.

The chat companion is an offline, on-device dialogue engine behind a messenger-style UI. Its decisions, wording, and actions are
deterministic. The application has no local or cloud language-model runtime, model download, or model-backed reply path. Crisis
turns are checked first and remain deterministic.

## Layers

| Layer | What lives there |
| --- | --- |
| `Application/Chat` | `CompanionDialogue` (the engine), `CompanionState`, `UtteranceClassifier`, wording (`CompanionDialogueContent`, `CompanionActContent`, `CompanionSmallTalk`, `CompanionKnowledge`, `ChatProfileContent`), `ChatService`, `ChatStatistics` |
| `Application/Conversation/Companion` | `LexiconSituationAnalyzer` (feeling, theme, person from text), `TechniqueSuggester`, `CompanionContent` |
| `Infrastructure` | `ChatRepository` (SQLite, Dapper), schema versions 9 (chats, messages) and 10 (`ChatMemory`) |
| `Presentation` | chat list, conversation, companion profile, `CompanionAvatarView`, home card |

## One turn

`ChatService.TakeTurnAsync` loads the chat, merges what is remembered between chats into the state, asks `CompanionDialogue.Respond`,
saves the person's message and the whole reply in one transaction and updates the chat title, feeling and tension.

`CompanionDialogue` decides in this order:

1. Crisis wording is checked first (`KeywordCrisisDetector`). A hit opens the crisis hub and nothing else runs.
2. A typed 0-10 number answers the tension question, exactly like the chip.
2b. Input that is not a message is recognised before anything else is guessed: bare digits ("1111"), key mashing ("asdfgh", "йцукен",
   "qwerty"), one letter repeated, a repeated unit ("sdfsdf"), a long word with no vowel, "???" (means "what?", the last question is
   repeated) and "!!!" (strong feeling, not a smile). The companion says plainly that it could not make it out, does not count it as a
   turn, does not remember it as something said and does not change what it knows (`CompanionState.UnclearStreak`); from the second miss
   in a row it offers the feelings to pick from. While the tension question is open, digits get the scale explained; a lone 0-10 number
   with nothing asked gets "what is that number about?"; a short number (up to three digits) after an open question is an answer.
   Russian typed on the English layout ("ghbdtn" for "привет") is read as Russian when the Russian reading means something to the engine.
   One or two words with no feeling, topic or person, said when nothing was asked, are not thanked as a story.
3. `UtteranceClassifier` says what the person is doing: greeting, thanks, goodbye, yes/no, "I don't know", refusing to talk, asking for
   advice (including a direct question at the end of a long message), explicitly asking how to support someone else, asking to explain, why, is it normal, backchannel, laughter/emoji, good news, how are you, name, capabilities, "say that
   again", "skip". Social phrases count only when the message carries no feeling ("thanks, but I'm still anxious" is a statement).
4. Anything else is a statement about a situation: quote the latest sentence that carries the recognised feeling when possible; if it is long, shorten only at a
   word boundary, and omit the quote if a useful intact excerpt does not fit. Closing quotes after sentence punctuation are handled, and Chinese and other CJK sentence endings are recognised;
   text without spaces is shortened at a Unicode character boundary. When the analysis recognises two distinct feelings, name both tentatively and ask one fitting question at a time. A brief advice request that names no new situation carries the active theme into the reflection. When an explicit advice request has a recognised event, the companion asks an unanswered event-specific question if one is available. If a brief advice request has no clear feeling but the saved context names a situation, ask what decision the person is weighing instead of inferring one.
   The companion measures tension, summarises now and then, returns to earlier context and offers a practice. Replies are selected and assembled by the deterministic dialogue engine. When asked why, it gives a cautious explanation and asks one follow-up tied to a remembered situation, or asks when and around what the feeling first appeared.
5. If a reply repeats one of the last eight companion messages, it is drawn again (up to four times). A conservative, ordered content-word overlap check also catches near-verbatim variants while keeping negation and distinguishing questions from statements; this is a lexical heuristic, not general semantic understanding.

`CompanionState` is an immutable record serialised to JSON with the chat, so a chat resumes exactly where it stopped.
Asked question ids are stored uniquely (up to 128 ids, more than the current built-in question set needs), so a long chat does not restart its question cycle when a short rolling list fills up.

Besides the three-message analysis window and the first quote, it keeps at most eight short excerpts, tagging them when a theme, person or event is recognised. It preserves an early anchor for each of the most recently active contexts first, then uses remaining slots for fresh updates; a newer anchor refreshes no more than once every four message turns, so repeated wording does not crowd memory. The same wording can be kept separately when its recognised tags point to a different topic, person or event, so an earlier case does not hide the new one. These anchors stay in the encrypted chat database. An emotion-only excerpt is kept as untagged context only when no earlier theme, person or event is active, so it cannot be mistaken for a quote from a previous situation. A later recap can reuse an earlier anchor from the same topic and, when the person explicitly chose a support goal, remind them whether they wanted to vent, understand the situation or calm down. A short “again / still / как раньше” can bring back a matching excerpt even when a feeling is named, as long as the message does not identify a new theme, person or event, and ask whether it is the same situation. Retrieval prioritises matching events, people and themes, and rejects an excerpt when a recognised tag conflicts with the current case. A plain yes or no to the recall question gets a specific follow-up. If the person says the recalled context was wrong, that anchor and its active theme, person, event and intensity are cleared before the dialogue continues. Old excerpts are never sent back through emotion analysis, trauma and bereavement messages are not added to this recall list, and the callback is suppressed after either is disclosed. Missing fields in older saved states remain valid and start with an empty list.

## Memory between chats

Table `ChatMemory (MemoryKey, MemoryValue)`:

| Key | Meaning |
| --- | --- |
| `name` | how to address the person |
| `tried:<TechniqueId>` | how many times a practice was started from a chat |
| `helped:<TechniqueId>` | how many times the tension dropped after it |
| `plan`, `plan_at` | a step the person decided on (their own words, cut to 160 characters) and when, in UTC |
| `trauma_notes` | stuck points and triggers found in trauma work (their own words, at most 10 of each), for the summary for a specialist |
| `topic:<key>` | the dates (UTC) of the chats where a person or an area of life came up (`person:Boss`, `theme:Work`), at most 8; dates older than 30 days are pruned on the next saved turn. The third chat on a topic within 30 days is named as a repeat ("“boss” has come up in 3 of our conversations this month"), once per chat, with the offer to look under it |

"Delete all chats" keeps only `name`, `tried:` and `helped:` (its dialog promises the name and preferences); the rest was taken
from the conversations and is deleted with them (`ChatMemoryKeys.OutlivesChats`). "Forget about you" clears the whole table.

Among equally relevant practices, the one with fewer prior starts is offered first; when counts are tied, the reviewed order stays
unchanged unless that would repeat the previous primary suggestion in the same chat. The previously helpful practice can lead when it
has not been tried more often than the current alternative, with a note that it helped before. Panic recommendations remain within the
reviewed panic options. Deleting all chats keeps the practice counters; "forget" clears the memory and keeps the chats. When both shown options have been passed over, the companion asks what did not fit instead of repeating one.

A step decided on (the end of problem solving, or "I'll talk to him tomorrow" said in a chat) is asked about when a new chat opens,
from six hours on and for two weeks: "Last time you decided: … How did it go?" with "I did it / Partly / It didn't work out". The
answer can use those buttons or begin with a clear natural-language outcome phrase. If a detailed reply includes that result,
the companion continues through its normal conversation flow and resolves the old plan instead of reducing the message to a button.

## Guided exercises in the chat

The companion does not only point to a practice; on an offer it can also walk through one exercise, one question at a time
(`CompanionDialogue.Protocols.cs`, wording in `CompanionProtocolContent`):

| Exercise | When it is offered | Steps |
| --- | --- | --- |
| Checking a thought (cognitive restructuring) | anxiety, rumination, guilt, sadness, resentment; fear of an exam, a failure, a betrayal | the thought → belief 0–10 → facts for → facts against → what you would tell a friend → a fairer wording → belief again → summary with both numbers; if the belief did not drop, the thought record practice |
| Problem solving | a quarrel, too much work, a lost job, putting things off | the task in one sentence → two or three options → the most doable → the first 10–15 minute step and when → summary; the step is remembered |
| Looking deeper (the downward arrow) | guilt, sadness, loneliness (next to checking the thought); a topic that keeps coming back | the heaviest thought → suppose it is true: what would be hardest → what it would say about you → what you would tell someone close → a fairer and kinder wording → summary with the person's own words and a note that a belief about oneself that keeps returning is worth working on with a psychologist. It follows the meaning of a thought and never asks what happened |

Each is offered once per chat and never during panic, a flashback or grief. Crisis words are checked before every answer, as
everywhere; "stop" or the "Stop here" chip ends the exercise at any step.

## Trauma work

When a hard event is mentioned, the companion answers it in a trauma-informed way and can work on the beliefs it left (stuck points,
as in cognitive processing therapy) or map what sets the reactions off, without ever asking for the details of the event. Distress is
checked first and the work waits at 7 of 10 or a flashback. See [trauma-module.md](trauma-module.md#trauma-work-in-the-chat).

## Pointing further

- An article that explains the recognised state is offered once per chat as a chip ("Read: …"), except during panic, where the body
  article already comes with the somatic chip.
- From the third chat in two weeks that ended at tension 7 or more, the matching questionnaire is suggested once (PHQ-9 for low mood
  and exhaustion, GAD-7 for anxiety, PCL-5 after a flashback), unless it was taken in those two weeks; the chip opens it directly.

## Companion profile

Opened by tapping the face or the name in the chat header. `ChatService.GetProfileAsync` computes everything from stored chats and the
memory (`ChatStatistics.Compute`), nothing is stored twice:

- chats with something said, messages written, active days, current streak;
- tension at the start and the end of each measured chat (last eight), how many improved, the average change;
- practices with tried / helped counters, the most frequent feelings with their share;
- trust level (0-3) from the number of messages written; it is a friendly progress marker, not a clinical measure;
- short insights that only state what the numbers show.

## Limits, stated plainly

- The engine understands what its lexicon and rules cover. On held-out sentences the analyzer's accuracy is far below its accuracy on the
  tuned set (see companion-understanding.md). Expect misses on unusual wording; the companion then asks which feeling is closest.
- A person can ask for another wording of a standard prompt or the three non-trauma guided exercises; those alternatives are prewritten. A trauma-specific prompt without a reviewed alternative is repeated transparently. Repeat, rephrase, skip, stop, and crisis interrupts do not become exercise answers or advance a step.
- Time of day comes from the phone's clock.
- All Russian and English wording, the psychoeducation texts and the advice ("what usually helps") must be reviewed by a psychologist
  before release. They are general and non-diagnostic by design.

## Tests

`Application.Tests/Chat`: classifier, dialogue, small talk, knowledge, statistics, service with an in-memory repository.
`Infrastructure.Tests/Data`: repository, schema, memory. The Presentation project is Android-only, so its view models are not unit tested on
Windows; the logic they show lives in Application on purpose.
