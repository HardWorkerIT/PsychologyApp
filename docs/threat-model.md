# Threat model (one page)

What the app holds is sensitive: mood notes, chat with the companion, test answers (including depression and self-harm items), risk
assessments, a safety plan with contacts. Everything is stored **on the device only**; the app has no account and no server.

## Assets

| Asset | Where it lives |
| --- | --- |
| Chats, mood notes, test results, risk assessments, safety plan, journal | SQLite database in the app's private folder |
| Preferences (language, reminders, onboarding) | Android SharedPreferences |
| Exported backup / specialist summary | A file the person chooses to share; removed from the cache right after the share sheet closes |
| Error log | `logs/app-errors.log`, warnings and errors only, no message text; shared only by the person |
| Downloaded prayer audio | Cache folder, HTTPS only, validated as audio |

## Who could get at it, and how it is handled

| Threat | Handling | Residual risk |
| --- | --- | --- |
| Another app, or a copy of the app data, reads the database | Android app sandbox; `allowBackup=false`; cloud backup and device transfer excluded; the file is encrypted at rest (SQLite3 Multiple Ciphers, ChaCha20-Poly1305) with a random 256-bit key kept in the Android Keystore / iOS Keychain via SecureStorage; an older plain database is converted on first launch, verified by table row counts, and the plain copy deleted; unavailable keys or failed migration refuse database access instead of falling back to plaintext | A rooted device with live access to the unlocked app; loss of the key (clearing Keystore data) makes the file unreadable, there is no recovery by design |
| Someone with the unlocked phone | Optional lock on the data screen (`AppLockCoordinator`): the phone's own unlock (BiometricPrompt with fingerprint, face or the phone's PIN, Android 10+), asked at every start and after more than a minute away, measured on `SystemClock.ElapsedRealtime` (counts sleep, cannot be set back like the wall clock); the app keeps no PIN of its own. The lock screen shows nothing personal, only 112 and the helpline. With the lock on, the recent-apps list shows no picture of the app (Android 13+) | While the lock is due, the shell is drawn invisible from the first frame of a start or a return, so nothing flashes before the lock screen; if the phone's screen lock is removed, or the system reports it cannot ask (no credential, no working sensor, the prompt fails to open), the app opens (by design, so no one is locked out of their records); widget mood taps are saved without unlocking (they read nothing) |
| The person wants everything gone | «Delete all my data» on the data screen, asked twice: the database file is recreated empty, settings are cleared with a synchronous commit, the logs and the app's own exported files in the cache are deleted, then the app restarts in a fresh process (`PersonalDataEraser`). The files, settings and restart happen while the database lane is held, so a save already queued (an autosaved note, a chat turn) cannot land in the new, empty database | Files already shared to other apps (a backup sent by mail) are outside the app |
| Backup file leaks after sharing | The export offers a passphrase (PBKDF2-SHA256 600k iterations, AES-256-GCM, authenticated); the unprotected option stays available; the temporary file is deleted from the cache after sharing | A weak passphrase; an unprotected export sent somewhere unsafe |
| Forged intent to MainActivity | Reminder taps need a per-install secret carried only by our own PendingIntents | Navigation only, no data access |
| Malicious content over the network | Prayer audio is downloaded over HTTPS with size, content-type and magic-byte checks. | Third-party host compromise |
| Crash / error log reveals data | Logs carry exception types and technical messages, never chat or journal text | Exception messages may include SQL fragments |
| Network eavesdropping | No chat, journal, practice text, test result or health data leaves the device. Network traffic includes prayer audio and, on Android, VK ad requests from eligible catalogs. | Prayer-audio request metadata is visible to the hosting provider; VK may receive the IP address, device/app details, an available advertising identifier and ad request/impression/click events |

The Android package includes the VK Ads (myTarget) SDK for banners in eligible practice, course, article, and general quotes catalog views. The quote banner is limited to the non-personal All feed; ads stay out of personalized recommendations, tests, and crisis/help screens. Banners load automatically when the HTTPS policy URL and slot are configured; EISBRECHER disables requests. The SDK receives a false value for its personalized-advertising consent setting. VK may receive the IP address, device/app details, an available advertising identifier and ad request/impression/click events. No chat, journal, practice answer, test result or health data is supplied to the SDK for targeting. Review the SDK's actual network activity and current disclosures before production rollout.

The feedback form passes prepared text to the email, SMS, or system share UI only after the person taps a channel. The app does not send this text to its own server and cannot verify whether it is sent; an external app, service, and recipient handle any message the person chooses to send.

## Safety (not security) risks the app handles

Crisis wording in chat and journal notes, the suicide items of the Beck inventory and PHQ-9, and a red risk check each route to the crisis
screen. These rules need review by a clinician before a public release; see the release notes in the README.
