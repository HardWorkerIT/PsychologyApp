# How the companion understands what people write

The messenger companion (`CompanionDialogue`) has to decide which state the person is in (panic, anxiety, anger, guilt...) from free text.
This page records how well that works, what was measured, and what was decided.

## What runs in the app today

A weighted **lexicon** (`LexiconSituationAnalyzer`, RU + EN, with simple negation and a colloquial extension list) runs first.
It is instant, offline and predictable. If it finds no match, a local Russian classifier can suggest a feeling for a sufficiently long message;
the person can confirm or reject it. When confidence is low, the dialogue reflects the person's words and asks an open question.

## Measurements (`AnalyzerDatasetTests`, `tools/PsychologyApp.NluEval`)

All current Russian expansion sets are synthetic examples authored for development; they are not real-user observations or clinical validation.
The lexicon and local classifier are evaluated separately from the user-facing flow. In the live flow, the classifier only suggests a feeling
after the lexicon returns Unknown, and the person can confirm or reject it.

| Russian set | Examples | Lexicon | Full offline flow | Status |
|-----|---------:|---------:|---------:|---------|
| v11 | 110 | 62% after phrase expansion | 90% (99/110) | Spent during tuning |
| v12 | 110 | 68% after phrase expansion | 93% (102/110) | Spent during tuning |
| **v13** | **110** | **84%** | **96% (106/110)** | Current fresh check; exact text overlap with classifier training: 0 |

The v13 end-to-end score meets the 95% development target on this one balanced synthetic set. Per-class accuracy is: Panic 10/10, Anxiety 9/10,
Overthinking 10/10, Anger 10/10, Resentment 8/10, Guilt 10/10, Sadness 9/10, Exhaustion 10/10, Loneliness 10/10, Procrastination 10/10,
Unknown 10/10. Resentment is the weakest class at 80%. The lexicon alone recognizes 92/110 (84%); the local guesser supplies 14 suggestions
and correctly resolves all 14 on this set. This result must not be generalized to real users: the sample is small, synthetic, and not independently reviewed.

Earlier English and mixed-language measurements below are historical and have different data splits. Their scores should not be compared as
if they were a shared benchmark. The evaluator prints per-class precision, recall and F1 plus common confusion pairs so aggregate accuracy
does not hide weak categories. For credible quality claims, the next evaluation needs independently authored and psychologist-reviewed Russian
phrases, with test examples kept out of both the lexicon and classifier training.

The conversation suite also exercises multi-turn user outcomes: correcting a feeling, declining an inferred goal, changing from
listening to understanding, indirect requests, and the crisis route after a support preference has been chosen. These are
synthetic examples, not clinical validation. Add independently written cases before tuning a category; do not turn individual
test misses into lexicon terms one by one.

### Sentence embeddings (multilingual-e5-small, int8 ONNX, ~118 MB), nearest labelled example

In an earlier experiment, on the then-current 53-message held-out set, 100 development messages as prototypes (`--test`):

| Method | Held-out accuracy |
|--------|-------------------|
| Lexicon | 24% |
| Embeddings, nearest example | 42% |
| Lexicon, falling back to embeddings when it recognises nothing | 52% |

That experiment predates the current datasets and cannot be compared directly with the table above.

With few prototypes per class embeddings alone were weaker than the lexicon (43-68% on the development set depending on the number
of prototypes); the gain comes from combining them. Embedding one message takes ~8 ms on a desktop CPU.

## Decision

**Embeddings are not integrated yet.** Reasons:

- Even the best variant is wrong about half of the time on unseen text; the missing ingredient is labelled data, not the model.
- Shipping needs ONNX Runtime (~15-20 MB extra in the APK) plus a ~118 MB model download (the downloader exists in
  `Infrastructure/LocalModel`), and adds a heavy dependency for a partial gain.
- A wrong guess is costly in this domain ("you seem hurt" to someone who feels guilty). Any embedding-based guess should be
  *proposed and confirmed with one tap*, not assumed.

What would make it worthwhile:

1. **Labelled data.** A few hundred to a thousand messages labelled by a psychologist; train a small classifier on the embeddings
   instead of nearest-example matching, and evaluate on a held-out set that is never tuned on.
2. **Confirm-before-assume UX.** Use the embedding only to pre-select the two most likely chips ("Sounds like anxiety or fear?").
3. Re-run `tools/PsychologyApp.NluEval` and compare with the numbers above.

Until then the low recognition rate is absorbed by the dialogue design (open questions, chips, quoting the person's words).

## How to re-run

```bash
dotnet test PsychologyApp.Application.Tests --filter AnalyzerDataset --logger "console;verbosity=detailed"

dotnet run -c Release --project tools/PsychologyApp.NluEval -- <e5-dir> \
  PsychologyApp.Application.Tests/Conversation/Data/nlu-dataset.json \
  --test PsychologyApp.Application.Tests/Conversation/Data/nlu-heldout.json
```

`<e5-dir>` holds `model_qint8_avx512_vnni.onnx` and `sentencepiece.bpe.model` from `intfloat/multilingual-e5-small` (MIT).
Do not tune the lexicon on the held-out set; replace it with a fresh set first.

## Confidence is not a usable "is this a guess?" signal (measured)

`SituationAnalysis.Confidence` is `top / (top + second + 1)`. A single clear keyword ("anxious", "тревожно") scores exactly 0.5, the same as one
accidental match, so a threshold cannot tell them apart. Measured precision of the named feeling, by minimum confidence:

| Minimum confidence | Development set (named / precision) | Held-out set (named / precision) |
|--------------------|-------------------------------------|----------------------------------|
| 0 | 145 / 99% | 19 / 74% |
| 0.51 | 119 / 99% | 12 / 83% |
| 0.67 | 50 / 100% | 2 / 100% |

Requiring 0.51 raised held-out precision from 74% to 83% but made the dialogue stop naming obvious single-keyword messages
("I feel so anxious about my job"), which broke three existing dialogue tests, so it was not adopted. The held-out problem is mostly
**coverage** (19 of 60 messages named at all), not wrong names: better recall needs a larger lexicon or the embedding fallback
described above, not a confidence cut-off.

## Third lexicon round (2026-10) and the telling-message rule

`LexiconExtendedPhrasings.cs` adds how people describe a state without naming it (body signs, situations, figures of speech).
Measured on `nlu-fresh2.json` (98 messages written *after* the round and never tuned on):

| Lexicon | Final set (never tuned on) |
|---------|----------------------------|
| Before the round | 37% |
| After the round | **41%** |

The two older sets (`nlu-heldout.json` 92%, `nlu-fresh.json` 96%) were read while writing the terms, so those numbers are inflated and only
guard against regressions. The honest figure is the final set: +4 points. Word lists have reached their limit; the rest needs data
(see "What would make it worthwhile" above).

Because most of what is missed is a person *telling* something, a message of eight words or more that names no feeling now gets the
choice of feelings right away (`CompanionDialogue.TellingWords`) instead of an open question, which used to make them tell it again;
shorter unclear messages keep the old two-step behaviour.

## A second opinion for what the lexicon misses (2026-10)

`EmotionGuesser` is a naive Bayes classifier over character 3-5-grams, trained at first use from the labelled messages in
`Conversation/Companion/Data/emotion-training.json` (the evaluation sets merged and de-duplicated). In a free-text statement it runs only when
the lexicon recognised nothing and the message has at least five normalized words. Its answer is never assumed: the chat asks "Sounds like X, is that
right? If not, pick what is closer." and puts X first among the feeling chips, so one tap confirms it.

Leave-one-set-out (`EmotionGuesserTests`: train without one of six sets, then evaluate on that set), with the current minimum margin of 25 natural-log units and at least
5 normalized words:

| Measure | Across six sets (587 messages) |
|---|---|
| Lexicon alone | 452 right (77.0%) |
| Lexicon, then a proposed guess when the lexicon says Unknown | 517 right (88.1%) |
| Lexicon misses that received a proposal | 72 of 93 |
| Proposed feelings accepted by the labels | 65 of 72 (90.3%) |
| Small talk wrongly proposed as a feeling | 0 |

Proposal precision varies by emotion: Anxiety 6/7 (86%), Exhaustion 5/7 (71%), Guilt 4/5 (80%), Resentment 9/10 (90%); the other proposed classes were 86-100% on these small samples. This is not enough data to set separate per-class confidence gates safely.

On the older final sets under the current gate, lexicon -> lexicon plus guesser: `nlu-fresh2.json` 42% -> 73%, `nlu-fresh3.json` 60% -> 78%, `nlu-fresh4.json` 62% -> 78%.

A historical threshold sweep on earlier folds found that a margin of 25 raised proposal precision to 90% (64/71) but reduced combined correct classifications from 516 to 513. The current gate is 25: the bundled model's original threshold of 5 led to too many incorrect suggestions in a full-suite regression check. On the current fresh v13 Russian set, the higher gate reaches 96% because the expanded lexicon handles most messages first. A rejected guess becomes an open question instead of a forced label.

Limits: training and tests are synthetic and mostly written by the same author; they do not represent real people's phrasing or clinical quality. The missing ingredient is independently labelled, consented examples reviewed by a psychologist. Keep them local to development; never send chat text off-device.

The shipped training set has 1,615 labelled examples and is built from the labelled files with `node tools/build-emotion-training.js`; a test fails when an evaluation case is missing from the bundle. The classifier is deterministic and uses character 3-5-grams, word stems, word pairs and a separate “no feeling named” class.
Update (2026-10-30): the guesser now applies the shared `UtteranceText.Normalize` to training and user messages before counting words or building
features. The lexicon measurements above were recalculated after this change. The earlier embedding experiment remains a separate historical result.
