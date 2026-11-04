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

## Technique catalog — 2026-11-04

- [x] Скрыть двенадцать практик из новых рекомендаций, сохранив старые ID, определения и доступ к черновикам; добавить локализованные ThoughtDefusion, STOP, OppositeAction, ProblemSolving, CheckTheFacts, WorryTime и ImplementationIntention; обновить маршруты чата, тестов и программ. «Занять голову» ограничена временной паузой на 30–60 секунд; «Один маленький шаг» уточнена как планирование посильной активности; «Лопни шарики» оставлена как игровая пауза без обещания снижения тревоги. «Якорь ресурса» переименован и переписан в семи локалях как необязательное воспоминание об опоре без неподтверждённой связки жеста с состоянием; ID сохранён, практика остаётся архивной. XAML и визуальный UI не менялись.
- [x] Добавить «Волну импульса» на семи языках; ограничить офлайн-маршрут мягкой злостью и явной фразой о безопасно откладываемом действии; добавить тесты отрицания и риска вреда. Исправить отсечение «прежде чем» в анализаторе. Application `net10.0` — 1 451 тест, Presentation `net10.0` — 908 тестов прошли. Эффект минутной адаптации не подтверждён; клинический review и пилот нужны до заявлений об эффективности.

- [x] Переработать технику №15: мягкий ритм 4/6 без задержек в основном и полноэкранном круге, нейтральная обратная связь и выход при дискомфорте на семи языках; XAML не менялся. Индивидуальный эффект и клиническая пригодность этой минутной адаптации не установлены.

- [x] Согласовать дыхательные подсказки статьи о панике с техникой №15 во всех семи локалях: мягкий ритм только по желанию, остановка при дискомфорте и переключение на окружение. Текущая проверка: Application — 1 437 и Presentation `net10.0` — 908 тестов пройдены; Android-сборка заблокирована отсутствующим SDK (`XA5300`).

- [x] Прогнать пять .NET test-проектов в Release (Presentation `net10.0`): 2,813 тестов прошло; `git diff --check` прошёл.
- [ ] Clinician review, native-speaker copy review, and a user pilot remain open. See `docs/technique-catalog-review-2026-11-03.md`.
- [x] Добавить «Сенсорную паузу» (`SensoryComfort`) на семи языках как необязательную 30–60-секундную адаптацию DBT-самоуспокоения; подключить к каталогу, рекомендациям и офлайн-чату с оценкой дискомфорта до/после без обещания эффекта. Подробности и первичные источники: `docs/technique-sensory-comfort-review-2026-11-04.md`.
- [ ] Получить клиническую проверку сенсорной паузы, ревью переводов носителями и пользовательские данные до заявлений об эффективности.

- [x] По этой итерации пройдены Application `net10.0` — 1 439 тестов и Presentation `net10.0` — 908 тестов; Android target не собрался из-за отсутствующего SDK (`XA5300`).

- [ ] Android build/device verification remains blocked by the missing Android SDK (`XA5300`).

## External blocker
- [ ] Android package/emulator verification: `dotnet build PsychologyApp.Presentation/PsychologyApp.Presentation.csproj -c Release -f net10.0-android --no-restore` failed with `XA5300` because the Android SDK directory is missing. `dotnet workload list` also fails in this host with the .NET SDK installer `TypeInitializationException`. Install/CI/device verification remains external; no SDK was installed and nothing was published.

## Technique improvement — 2026-11-04
- [x] Улучшена «Позиция наблюдателя»: тот же `Observer`/черновой формат и порядок полей, но понятная минутная практика дистанцированного самообращения на семи языках; техника доступна в каталоге, узких чат-рекомендациях и последовательности исследования практик. Добавлены проверки доступности, формы черновика, рекомендуемых ситуаций и исключений для повышенного риска. Эффективность конкретной адаптации не заявляется; клиническое ревью и пользовательский пилот остаются открытыми.
- [x] Release-проверки: Application `net10.0` — 1 468 тестов, Presentation `net10.0` — 908; `git diff --check` прошёл. Android-таргет не проверен: отсутствует Android SDK (`XA5300`).
- [x] Офлайн-анализатор распознаёт прямую просьбу не предлагать дыхательные/телесные упражнения на русском и английском; рекомендация учитывается в автоматическом подборе и выборе «успокоиться», хранится только в состоянии текущего чата и сбрасывается при явной просьбе попробовать дыхание/телесную практику. Добавлены варианты формулировок, регрессионные, отрицательные и тесты восстановления чата. Application `net10.0` — 1 495 тестов прошло.
