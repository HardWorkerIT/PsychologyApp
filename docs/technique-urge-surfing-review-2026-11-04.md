# «Волна импульса»: evidence and safety review — 2026-11-04

## Scope

The catalog adds a short, optional, one-minute adaptation of mindful urge surfing for everyday actions that can safely wait (for example, sending a heated message or checking a phone again). The app does not present it as treatment for addiction, self-harm, or violence.

## Evidence and limits

- DBT teaching material describes urge surfing as observing and describing urges, especially cravings and addictive behavior: [Linehan, DBT Skills Training Manual teaching notes](https://www.guilford.com/add/linehan7_old/lin-p-4teaching.pdf?t=1).
- In a randomized brief-instruction study of 123 college smokers, urge surfing did not significantly reduce immediate craving compared with control, though the study reported fewer cigarettes over the following seven days: [Bowen & Marlatt, 2009, PubMed](https://pubmed.ncbi.nlm.nih.gov/20025372/).
- These sources do not validate this app's one-minute adaptation for anger, texting, or phone checking. The urge can stay the same or intensify; users are told that this is not failure. No immediate benefit or clinical effectiveness claim is justified.

## Safety boundaries in the flow

- First check that delaying the action is safe. Do not postpone medical care, prescribed medication, food, water, or a safety action.
- Do not use the exercise alone when there is a risk of harm to self or another person; the copy directs the user to their safety plan and immediate live support.
- Body attention is optional and has an external-orientation exit if it feels worse.
- The action field is optional. The closing step offers several safe next choices and does not require waiting for the urge to disappear.

## Routing and verification

The offline chat only offers the practice when the lexicon recognizes a narrow action-urge phrase alongside mild anger, with no detected body symptoms, intensity, trauma, loss, or emotion attributed to another person. Explicit self-harm and violence phrases suppress this flag. This phrase matching is a heuristic, not a safety classifier; it can miss wording and should not be treated as crisis assessment.

Before making effectiveness claims, request a clinician review, native-speaker review of every locale, and a user pilot measuring immediate urge ratings, completion, worsening, and help-seeking. Those steps have not been done.
A regression test exposed an existing clause-trimming false positive: «прежде чем ударить» was dropped as though it described the past. Clause trimming now preserves «прежде чем», so the following harm phrase reaches the safety routing check. The Russian harmful-urge regression test covers this case.
