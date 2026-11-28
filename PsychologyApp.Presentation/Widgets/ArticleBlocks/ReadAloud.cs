using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;

namespace PsychologyApp.Presentation.Widgets.ArticleBlocks;

/// <summary>
/// Reads an article aloud with the phone's own speech engine, part by part (a long text in one go is cut off by some engines).
/// Only the app's own text is spoken: nothing the person wrote. Stops when the screen is left.
/// </summary>
public sealed class ReadAloud
{
    private CancellationTokenSource? _speaking;

    public bool IsSpeaking => _speaking is not null;

    public bool HasError { get; private set; }

    public event Action? Changed;

    public async Task ToggleAsync(IReadOnlyList<string> parts)
    {
        if (_speaking is not null)
        {
            Stop();
            return;
        }

        HasError = false;
        CancellationTokenSource speaking = new();
        _speaking = speaking;
        Changed?.Invoke();
        try
        {
            // The articles are read in the interface language: each language has its own text now.
            string language = AppLanguages.Normalize(AppStrings.Language);
            Task<IEnumerable<Locale>> localesTask = TextToSpeech.Default.GetLocalesAsync();
            // GetLocalesAsync has no cancellation parameter. Observe a late platform failure while allowing a screen leave/stop
            // to release this speech operation immediately instead of retaining the page until the platform responds.
            _ = localesTask.ContinueWith(
                static task => { _ = task.Exception; },
                CancellationToken.None,
                TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously,
                TaskScheduler.Default);
            Locale? locale = (await localesTask.WaitAsync(speaking.Token))
                .FirstOrDefault(candidate => candidate.Language.StartsWith(language, StringComparison.OrdinalIgnoreCase));
            SpeechOptions options = new() { Locale = locale };
            foreach (string part in parts)
            {
                speaking.Token.ThrowIfCancellationRequested();
                await TextToSpeech.Default.SpeakAsync(part, options, speaking.Token);
            }
        }
        catch (OperationCanceledException)
        {
            // Stopped by the person or by leaving the screen.
        }
        catch (Exception speechError)
        {
            HasError = true;
            BestEffort.Report(speechError);
        }
        finally
        {
            if (ReferenceEquals(_speaking, speaking))
            {
                _speaking = null;
                Changed?.Invoke();
            }

            speaking.Dispose();
        }
    }

    public void Stop()
    {
        CancellationTokenSource? speaking = _speaking;
        _speaking = null;
        speaking?.Cancel();
        Changed?.Invoke();
    }
}
