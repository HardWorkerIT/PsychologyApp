# Threat model (one page)

What the app holds is sensitive: mood notes, chat with the companion, test answers (including depression and self-harm items), risk
assessments, a safety plan with contacts. Everything is stored **on the device only**; the app has no account and no server.

## Assets

| Asset | Where it lives |
| --- | --- |
| Chats, mood notes, test results, risk assessments, safety plan, journal, onboarding topic | Encrypted SQLite database in the app's private folder |
| Preferences (language, reminders, onboarding completion, ad personalization choice) | Android SharedPreferences |
| Exported backup / specialist summary / journal CSV | A file the person chooses to share, staged in the private cache. Failed requests remove the file immediately. After handoff the file is available for up to 15 minutes while the app is running, and expired files are removed on the next start after process termination. |
| Imported backup | Android reads the selected document through a bounded stream without staging a copy. Erasing personal data also cleans up picker copies made by older builds. The original stays at the selected location. |
| Error log | `logs/app-errors.log`, warnings and errors only, no message text; shared only by the person |
| Downloaded prayer audio | Cache folder, HTTPS only, validated as audio |

## Who could get at it, and how it is handled

| Threat | Handling | Residual risk |
| --- | --- | --- |
| Another app, or a copy of the app data, reads the database | Android app sandbox; `allowBackup=false`; cloud backup and device transfer excluded; the file is encrypted at rest (SQLite3 Multiple Ciphers, ChaCha20-Poly1305) with a random 256-bit key kept in the Android Keystore / iOS Keychain via SecureStorage; an older plain database is converted on first launch, verified by table row counts, and the plain copy deleted; unavailable keys or failed migration refuse database access instead of falling back to plaintext | A rooted device with live access to the unlocked app; loss of the key (clearing Keystore data) makes the file unreadable, there is no recovery by design |
| Someone with the unlocked phone | The optional app PIN is required at startup or after a long absence. Android measures the absence with `SystemClock.ElapsedRealtime`. The shell stays covered until the lock page completes. If modal navigation fails, the lock page takes the place of the shell until the lock flow completes. PIN recovery requires successful phone authentication. If the phone cannot authenticate the person, the app remains locked and the person can retry. The recent-apps list hides the app preview on Android 13+ when the lock is enabled. | Losing both the app PIN and the ability to authenticate on the phone prevents access to the records. Widget mood taps can save a rating without opening the journal. |
| The person wants everything gone | «Delete all my data» on the data screen, asked twice: the database file is recreated empty, settings are cleared with a synchronous commit, the logs and the app's own exported files in the cache are deleted, then the app restarts in a fresh process (`PersonalDataEraser`). The files, settings and restart happen while the database lane is held, so a save already queued (an autosaved note, a chat turn) cannot land in the new, empty database | Files already shared to other apps (a backup sent by mail) are outside the app |
| Backup file leaks after sharing | The export offers a passphrase (PBKDF2-SHA256 600k iterations, AES-256-GCM, authenticated). Staged files are removed after the handoff window or when deleting all personal data. | A weak passphrase or an unprotected file retained by the recipient |
| Forged intent to MainActivity | Reminder taps need a per-install secret carried only by our own PendingIntents | Navigation only, no data access |
| Malicious content over the network | Prayer audio is downloaded over HTTPS with size, content-type and magic-byte checks. | Third-party host compromise |
| Crash / error log reveals data | Logs carry exception types and technical messages, never chat or journal text | Exception messages may include SQL fragments |
| Network eavesdropping | No chat, journal, practice text, test result or health data leaves the device. Network traffic includes prayer audio and, on Android, VK ad requests from eligible catalogs. | Prayer-audio request metadata is visible to the hosting provider; VK may receive the IP address, device/app details and ad request/impression/click events. The SDK may also receive the advertising ID only when the person explicitly enables personalized ads in settings |

The Android package includes the VK Ads (myTarget) SDK for native cards in eligible practice, course, article, and general quotes catalogs. Native ads stay out of personalized recommendations, tests, and crisis or help screens. Fullscreen ads are limited to the return from eligible general articles, and rewarded video starts on request in settings. An HTTPS policy URL and a configured slot are required, and an invitation code disables ad requests. Personalized advertising is off by default and can be changed in settings. With consent enabled, the SDK may receive the advertising ID. Technical request data may be sent either way. No chat, journal, practice answer, test result or health data is supplied to the SDK for targeting. Review the SDK's actual network activity and current disclosures before production rollout.

The feedback form passes prepared text to the email, SMS, or system share UI only after the person taps a channel. The app does not send this text to its own server and cannot verify whether it is sent; an external app, service, and recipient handle any message the person chooses to send.

If configured, a voluntary support link opens in the system browser only after the person taps it. Sber handles payment details entered on its page; the app receives no payment confirmation and grants no paid features.

## Safety (not security) risks the app handles

Crisis wording in chat and journal notes, the suicide items of the Beck inventory and PHQ-9, and a red risk check each route to the crisis
screen. These rules need review by a clinician before a public release; see the release notes in the README.
