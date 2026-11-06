using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Services.Speech;

namespace PsychologyApp.Presentation.Shared.UI.Components;

/// <summary>
/// The microphone of one input: starts and stops listening, shows what is being heard, and adds the result to the text.
/// Only one input listens at a time; starting another microphone stops the first one.
/// </summary>
public sealed class VoiceDictation
{
    private static readonly SemaphoreSlim ActiveGate = new(1, 1);
    private static VoiceDictation? _active;

    private readonly Func<string> _readText;
    private readonly Action<string> _writeText;
    private CancellationTokenSource? _listening;
    private CancellationTokenSource? _holdHintLifetime;
    private TaskCompletionSource? _listenFinished;
    private int _stopVersion;
    private int _pressVersion;
    private int _startingPressVersion;
    private int _releaseStopPressVersion;

    public VoiceDictation(Func<string> readText, Action<string> writeText)
    {
        _readText = readText;
        _writeText = writeText;
    }

    public static bool IsAvailable => Speech.IsSupported;

    public bool IsListening => _listening is not null;

    /// <summary>The words heard so far while listening, or a short message after it ends (nothing heard, no permission...).</summary>
    public string StatusText { get; private set; } = string.Empty;

    /// <summary>Raised on the UI thread when <see cref="IsListening"/> or <see cref="StatusText"/> changes.</summary>
    public event EventHandler? Changed;

    private static ISpeechInput Speech =>
        Microsoft.Maui.Controls.Application.Current?.Handler?.MauiContext?.Services.GetService<ISpeechInput>() ?? new NullSpeechInput();

    /// <summary>A press held this long is "talk while holding"; a shorter one is a tap that leaves the microphone on.</summary>
    private const int HoldMilliseconds = 450;

    /// <summary>A tap this soon after a press or release was the same touch, already handled.</summary>
    private const int SameTouchMilliseconds = 800;

    private DateTime _pressedAt;
    private DateTime _lastTouchAt = DateTime.MinValue;
    private bool _pressStartedListening;
    private bool _pressed;

    /// <summary>
    /// Makes <paramref name="button"/> the microphone: hold it to talk and let go to finish, as in messengers; or tap once to start
    /// and once more to stop. A plain tap also comes from screen readers and keyboards, which have no press and release.
    /// </summary>
    public void Attach(View button, Action? beforeStart = null)
    {
        PointerGestureRecognizer pointer = new();
        pointer.PointerPressed += (_, _) => OnPressed(beforeStart);
        pointer.PointerReleased += (_, _) => OnReleased();
        pointer.PointerExited += (_, _) =>
        {
            // The finger slid off the button: the same as letting go.
            if (_pressed)
            {
                OnReleased();
            }
        };
        button.GestureRecognizers.Add(pointer);
        button.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => OnTapped(beforeStart)) });
    }

    private void OnPressed(Action? beforeStart)
    {
        int pressVersion = Interlocked.Increment(ref _pressVersion);
        _pressed = true;
        _pressedAt = _lastTouchAt = DateTime.UtcNow;
        _pressStartedListening = !IsListening;
        if (_pressStartedListening)
        {
            Volatile.Write(ref _startingPressVersion, pressVersion);
            beforeStart?.Invoke();
            ToggleCoreAsync(pressVersion).FireAndForget();
            CancelHoldHintLifetime();
            CancellationTokenSource holdHintLifetime = new();
            _holdHintLifetime = holdHintLifetime;
            ShowHoldingWhenHeldAsync(pressVersion, holdHintLifetime).FireAndForget();
        }
    }

    private void OnReleased()
    {
        int pressVersion = Volatile.Read(ref _pressVersion);
        _pressed = false;
        _lastTouchAt = DateTime.UtcNow;
        bool held = (_lastTouchAt - _pressedAt).TotalMilliseconds >= HoldMilliseconds;
        CancelHoldHintLifetime();

        // If the recognizer is still waiting for the previous microphone, remember the held release and cancel it before it starts.
        if (held && _pressStartedListening && !IsListening)
        {
            Volatile.Write(ref _releaseStopPressVersion, pressVersion);
        }

        // Let go after holding: the words are done. A touch on a microphone that was already on stops it too.
        if (IsListening && (held || !_pressStartedListening))
        {
            Speech.StopAsync().FireAndForget();
        }
    }

    private void OnTapped(Action? beforeStart)
    {
        if (_pressed || (DateTime.UtcNow - _lastTouchAt).TotalMilliseconds < SameTouchMilliseconds)
        {
            return;
        }

        if (!IsListening)
        {
            beforeStart?.Invoke();
        }

        ToggleAsync().FireAndForget();
    }

    /// <summary>Once the press turns into a hold, the hint says that letting go finishes.</summary>
    private async Task ShowHoldingWhenHeldAsync(int pressVersion, CancellationTokenSource lifetime)
    {
        CancellationToken cancellationToken = lifetime.Token;
        try
        {
            await Task.Delay(HoldMilliseconds, cancellationToken);
            while (_pressed
                && Volatile.Read(ref _pressVersion) == pressVersion
                && Volatile.Read(ref _startingPressVersion) == pressVersion)
            {
                await Task.Delay(50, cancellationToken);
            }

            cancellationToken.ThrowIfCancellationRequested();
            if (Volatile.Read(ref _pressVersion) == pressVersion
                && _pressed
                && _pressStartedListening
                && IsListening
                && StatusText == AppStrings.PracticeVoiceListening)
            {
                UiHaptics.Tick();
                SetStatus(AppStrings.PracticeVoiceHolding);
            }
        }
        catch (OperationCanceledException) when (cancellationToken.IsCancellationRequested)
        {
        }
        finally
        {
            if (ReferenceEquals(_holdHintLifetime, lifetime))
            {
                _holdHintLifetime = null;
                lifetime.Dispose();
            }
        }
    }

    public Task ToggleAsync() => ToggleCoreAsync(null);

    private async Task ToggleCoreAsync(int? pressVersion)
    {
        int startVersion = Volatile.Read(ref _stopVersion);
        if (IsListening)
        {
            ClearStartingPress(pressVersion);
            await StopListeningAsync(cancel: false);
            return;
        }

        CancellationTokenSource listening;
        TaskCompletionSource listenFinished;
        bool releasedBeforeListen;
        await ActiveGate.WaitAsync();
        try
        {
            if (startVersion != Volatile.Read(ref _stopVersion))
            {
                return;
            }

            // Another field can start while this input waits for the previous recogniser to stop.
            if (IsListening)
            {
                await StopListeningAsync(cancel: false);
                return;
            }

            if (_active is { } other && other != this)
            {
                await other.StopAsync();
            }

            if (startVersion != Volatile.Read(ref _stopVersion))
            {
                return;
            }

            listening = _listening = new CancellationTokenSource();
            releasedBeforeListen = pressVersion is int startingPress
                && Volatile.Read(ref _releaseStopPressVersion) == startingPress;
            if (releasedBeforeListen)
            {
                listening.Cancel();
            }

            listenFinished = new TaskCompletionSource(TaskCreationOptions.RunContinuationsAsynchronously);
            _listenFinished = listenFinished;
            _active = this;
        }
        finally
        {
            ClearStartingPress(pressVersion);
            ActiveGate.Release();
        }

        UiHaptics.Tick();
        SetStatus(releasedBeforeListen ? string.Empty : AppStrings.PracticeVoiceListening);

        try
        {
            CancellationToken token = listening.Token;
            token.ThrowIfCancellationRequested();
            SpeechInputResult result = await Speech.ListenAsync(heard => SetStatus(heard), token);
            token.ThrowIfCancellationRequested();
            if (result.Status == SpeechInputStatus.Recognized)
            {
                _writeText(AnswerText.AppendSpoken(_readText(), result.Text));
                UiHaptics.Tick();
            }

            SetStatus(result.Status switch
            {
                SpeechInputStatus.NothingHeard => AppStrings.PracticeVoiceNothingHeard,
                SpeechInputStatus.PermissionDenied => AppStrings.PracticeVoicePermissionDenied,
                SpeechInputStatus.Unavailable => AppStrings.PracticeVoiceUnavailable,
                _ => string.Empty
            }, stopped: true);
        }
        catch (OperationCanceledException)
        {
            SetStatus(string.Empty, stopped: true);
        }
        catch (Exception ex)
        {
            BestEffort.Report(ex);
            SetStatus(AppStrings.PracticeVoiceUnavailable, stopped: true);
        }
        finally
        {
            listenFinished.TrySetResult();
            if (ReferenceEquals(_listenFinished, listenFinished))
            {
                _listenFinished = null;
            }
        }
    }

    /// <summary>Stops listening without keeping the words, e.g. when the page closes.</summary>
    public Task StopAsync()
    {
        _pressed = false;
        Interlocked.Increment(ref _pressVersion);
        Volatile.Write(ref _startingPressVersion, 0);
        CancelHoldHintLifetime();
        Interlocked.Increment(ref _stopVersion);
        return StopListeningAsync(cancel: true);
    }

    private void ClearStartingPress(int? pressVersion)
    {
        if (pressVersion is int value)
        {
            Interlocked.CompareExchange(ref _startingPressVersion, 0, value);
        }
    }

    private void CancelHoldHintLifetime()
    {
        CancellationTokenSource? lifetime = _holdHintLifetime;
        _holdHintLifetime = null;
        if (lifetime is null)
        {
            return;
        }

        lifetime.Cancel();
        lifetime.Dispose();
    }

    private async Task StopListeningAsync(bool cancel)
    {
        Task? finished = _listenFinished?.Task;
        if (_listening is null && finished is null)
        {
            return;
        }

        if (cancel)
        {
            _listening?.Cancel();
        }

        await Speech.StopAsync();
        if (finished is not null)
        {
            await finished;
        }
    }

    private void SetStatus(string text, bool stopped = false)
    {
        if (stopped)
        {
            _listening?.Dispose();
            _listening = null;
            if (_active == this)
            {
                _active = null;
            }
        }

        StatusText = text;
        MainThread.BeginInvokeOnMainThread(() => Changed?.Invoke(this, EventArgs.Empty));
    }
}
