#!/usr/bin/env bash
# Installs the Release package on the running emulator/device, starts it, drives it with random input and fails on a native crash,
# an unhandled exception or a cold start slower than MAX_START_MS. Needs adb on PATH. Usage: tools/android-smoke.sh <apk-dir> [package]
set -u
APK_DIR="${1:?apk directory}"
PKG="${2:-com.subconscious.psychologyapp}"
MAX_START_MS="${MAX_START_MS:-8000}"

APK=$(ls "$APK_DIR"/*-Signed.apk 2>/dev/null | head -1)
[ -n "$APK" ] || APK=$(ls "$APK_DIR"/*.apk | head -1)
echo "installing $APK"
adb install -r "$APK" || exit 1

adb logcat -c
COMPONENT=$(adb shell cmd package resolve-activity --brief "$PKG" | tail -1 | tr -d '\r')
echo "starting $COMPONENT"
adb shell am start -W -n "$COMPONENT" | tee start.txt

TOTAL=$(grep -oE "TotalTime: [0-9]+" start.txt | grep -oE "[0-9]+" || true)
if [ -z "$TOTAL" ]; then
  # Newer Android releases may report only WaitTime from `am start -W`.
  TOTAL=$(grep -oE "WaitTime: [0-9]+" start.txt | grep -oE "[0-9]+" || true)
fi
echo "cold start: ${TOTAL:-unknown} ms (limit $MAX_START_MS)"

STATUS=0
CRASH=0
MONKEY_FAILED=0
APP_PIDS=""
# `am start -W` can return before the app process is available on low-memory emulator images.
for attempt in {1..30}; do
  APP_PIDS=$(adb shell pidof "$PKG" | tr -d '\r' || true)
  [ -n "$APP_PIDS" ] && break
  sleep 0.5
done

if [ -z "$APP_PIDS" ]; then
  echo "FAIL: the app process did not become ready after startup"; STATUS=1; MONKEY_FAILED=1
  : > monkey.txt
else
  echo "app process IDs before interaction: $APP_PIDS"
  # Let the first frame acquire focus before injecting random input.
  sleep 2
  if ! adb shell monkey --ignore-crashes --ignore-security-exceptions -p "$PKG" --throttle 300 --pct-syskeys 0 -s 7 2000 > monkey.txt 2>&1; then
    echo "FAIL: monkey could not complete the interaction run"; STATUS=1; MONKEY_FAILED=1
  fi
  if ! grep -q "Events injected: 2000" monkey.txt; then
    echo "FAIL: monkey did not inject all 2000 events"; STATUS=1; MONKEY_FAILED=1
  fi
fi
if [ "$MONKEY_FAILED" -ne 0 ]; then
  cat monkey.txt
fi
adb logcat -d > logcat.txt

if [ -z "$TOTAL" ] || [ "$TOTAL" -ge "$MAX_START_MS" ]; then
  echo "FAIL: cold start missing or slower than ${MAX_START_MS} ms"; STATUS=1
fi
FATAL_LINES=$(grep -n "FATAL EXCEPTION" logcat.txt | cut -d: -f1 || true)
while IFS= read -r line; do
  [ -n "$line" ] || continue
  end=$((line + 80))
  exception=$(sed -n "${line},${end}p" logcat.txt)
  if printf "%s\n" "$exception" | grep -Fq "Process: $PKG"; then
    printf "%s\n" "$exception"
    CRASH=1
  fi
done <<EOF
$FATAL_LINES
EOF
if [ -n "$APP_PIDS" ]; then
  native_crashes=$(awk -v pids=" $APP_PIDS " '$3 != "" && index(pids, " "$3" ") && /Fatal signal|plt_entry/ { print; found=1 } END { if (!found) exit 1 }' logcat.txt || true)
  if [ -n "$native_crashes" ]; then
    printf "%s\n" "$native_crashes"
    CRASH=1
  fi
fi
if [ "$CRASH" -ne 0 ]; then
  echo "FAIL: the app crashed during the interaction run"
  STATUS=1
fi
if ! adb shell pidof "$PKG" > /dev/null; then
  echo "FAIL: the app is not running at the end"; STATUS=1
fi
[ "$STATUS" -eq 0 ] && echo "smoke test passed"
exit "$STATUS"
