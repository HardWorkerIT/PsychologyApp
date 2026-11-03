# PsychologyApp project roadmap

Goal: improve the repository's reliability and presentation as a public .NET portfolio project without claiming unverified Android behavior.

AI companion backlog: [docs/ai-companion-roadmap.md](docs/ai-companion-roadmap.md) (30 UI-free tasks).
Technique improvement backlog: [docs/technique-improvement-roadmap.md](docs/technique-improvement-roadmap.md) (21 tasks focused on clarity, shorter flows, fit, and safe feedback; no visual UI changes).
Performance and engineering-quality backlog: [docs/performance-quality-roadmap.md](docs/performance-quality-roadmap.md) (20 Android-first tasks for the offline app).

## Performance and quality — 2026-11-03
- [x] Remove the abandoned local LLM download/runtime/settings path; deterministic offline chat and practice suggestions remain. See `docs/chat-companion.md` and the threat model.
- [x] Replace post-`Task.WhenAll` `.Result` access with `await`; add a CI check for blocking task waits in production layers, with one documented debug-watchdog allowlist.
- [x] Run all five test projects in Release: 2,773 passed, 0 failed.
- [x] Add a model-free Russian NLU benchmark; lexicon analysis now allocates about 22 KB/message versus 402 KB before, with host p95 reduced from 1.02 ms to 0.55 ms. Android/AOT profile remains open.
- [x] Add SQLite query-plan coverage for chat history/list, mood history, test history, practice-note lookup, and quote lookup; migration v15 removes one redundant chat ordering index and verifies existing chat data is preserved.
- [x] Publish backup JSON, specialist summaries, and journal CSV through a flushed same-directory temporary file and atomic move; failure tests confirm the previous complete export survives.
- [ ] Android Release build and device profiling remain blocked: host has no Android SDK (`XA5300`); weak and mid-range phones are also unavailable for measured baselines.

## Completed
- [x] Fix the missing Domain project reference that broke the Linux `net10.0` Presentation test build.
- [x] Run all five .NET 10 test projects (2,834 passing), Release-build twelve platform-independent projects (0 warnings/errors), and audit NuGet vulnerabilities in six production projects.
- [x] Publish the CI badge and record evidence/limits in `docs/quality-review-2026-11-02.md`.

## Completed in continuation
- [x] Review Android release configuration and startup/lifecycle paths. No repository defect was confirmed, so no speculative runtime changes were made.
- [x] Diagnose Stryker: its local Windows run fails before test discovery because Buildalyzer invokes an installed .NET SDK command that throws `TypeInitializationException`; no Stryker project/configuration defect was established.
- [x] Re-run relevant checks and record results/limits in the quality review.

## Practice flow UI follow-up — 2026-11-03
- [x] Confirm the catalog starts a selected practice directly, guided sessions expose one step with progress and skip/back, early finish is available, and interrupted drafts resume.
- [x] Open the optional post-practice check-in by default; it remains collapsible.
- [x] Add a localized “choose another practice” action beside the recommended next practice; it returns to the technique list and remains unavailable in crisis flow.
- [x] Add the label in Russian, English, German, French, Spanish, Portuguese, and Chinese.
- [x] Run `PsychologyApp.Presentation.Tests` in Release: 891 passed, 0 failed; `git diff --check` reported no whitespace errors.
- [ ] Compile and smoke-test the Android UI on an emulator/device; blocked by the missing Android SDK below.

## External blocker
- [ ] Android package/emulator verification: `dotnet build PsychologyApp.Presentation/PsychologyApp.Presentation.csproj -c Release -f net10.0-android --no-restore` failed with `XA5300` because the Android SDK directory is missing. `dotnet workload list` also fails in this host with the .NET SDK installer `TypeInitializationException`. Install/CI/device verification remains external; no SDK was installed and nothing was published.
