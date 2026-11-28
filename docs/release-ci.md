# Выпуск через CI

Workflow [`release`](../.github/workflows/release.yml) публикует релиз на GitHub: APK для установки напрямую и AAB для
RuStore и Google Play, оба подписаны ключом выпуска, с заметками из раздела версии в CHANGELOG.md. Репозиторий публичный:
скачать файлы может любой.

## Когда выходит релиз

На каждый push в `main` workflow вызывает `CI` и `android-smoke` для того же коммита. Для публикации должны пройти тесты,
проверка покрытия, сборки Apple и Android smoke. После этого проверяется готовность версии к выпуску:

- для версии из `ApplicationDisplayVersion` ещё нет тега `v<версия>`;
- `ApplicationVersion` соответствует версии (2.008 — код 2008);
- верхний раздел CHANGELOG.md с номером — эта версия, а `[Unreleased]` пуст: заметки к релизу описывают всё, что в пакете;
- в секретах репозитория есть ключ выпуска.

Если версия не готова, проверка выводит причину в сообщении «No release». Перед публикацией workflow собирает AAB и APK
для `android-arm64` из проверенного коммита и проверяет идентификатор APK `com.subconscious.psychologyapp`, версию,
код и подпись. CI останавливает выпуск, если сертификат APK отличается от сертификата предыдущего доверенного релиза.

Выпуск — это осознанный шаг, как и раньше: поднимите версию в csproj, перенесите записи из `[Unreleased]` в новый раздел,
отправьте в `main`. Клинические тексты к этому моменту должен проверить психолог ([clinical-review.md](clinical-review.md)).
Выпустить повторно ту же версию нельзя: нужен новый номер (Android не обновит приложение без нового кода версии).

Ручного запуска нет: GitHub показывает кнопку Run workflow только для workflow с ветки по умолчанию, а это
`features/re-design`. Повторить выпуск — новый push в `main` (пока тега версии нет, проверки пройдут заново).

## Секреты

Settings → Secrets and variables → Actions → New repository secret:

| Секрет | Что положить |
| --- | --- |
| `ANDROID_KEYSTORE_BASE64` | файл ключа выпуска в base64: `base64 -w0 release.keystore` (Git Bash) или `[Convert]::ToBase64String([IO.File]::ReadAllBytes("release.keystore"))` (PowerShell) |
| `ANDROID_KEY_ALIAS` | алиас ключа (`AndroidSigningKeyAlias` из `AndroidSigning.local.props`) |
| `ANDROID_KEYSTORE_PASSWORD` | пароль хранилища (`AndroidSigningStorePass`) |
| `ANDROID_KEY_PASSWORD` | пароль ключа (`AndroidSigningKeyPass`) |

Нужен тот же ключ, которым подписаны версии в магазинах, иначе установленные приложения не обновятся. Ключ попадает в
CI только на время сборки и удаляется в конце run; GitHub скрывает значения секретов в логах.

В Settings → Secrets and variables → Actions → Variables добавьте переменную репозитория
`ANDROID_RELEASE_CERT_SHA256`. Возьмите отпечаток из ранее опубликованного APK, которым пользователи обновляются напрямую:

```bash
apksigner verify --print-certs PsychologyApp-2.015.apk
```

Скопируйте значение `Signer #1 certificate SHA-256 digest`. Допускаются 64 шестнадцатеричных символа с двоеточиями или без.
Без этой переменной готовый к публикации релиз остановится до сборки. Отпечаток нового APK сравнивается с ней перед публикацией.

Локальный выпуск (`bash scripts/android-release.sh`) остаётся: он делает те же проверки, кроме требования пустого
`[Unreleased]` и сравнения с переменной репозитория, и ничего не публикует.
