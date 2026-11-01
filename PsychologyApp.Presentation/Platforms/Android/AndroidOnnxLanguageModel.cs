using PsychologyApp.Application.Conversation.Companion;
using PsychologyApp.Application.Chat;
using PsychologyApp.LocalLlm;

namespace PsychologyApp.Presentation.Platforms.Android;

/// <summary>Android adapter for the optional, locally installed ONNX model.</summary>
internal sealed class AndroidOnnxLanguageModel(ILocalModelInstaller installer, IChatLanguageProvider language) : ILanguageModel, IDisposable
{
    private readonly SemaphoreSlim _gate = new(1, 1);
    private OnnxGenAiEngine? _engine;

    public bool IsAvailable => installer.Manifest.SupportsLanguage(language.IsEnglish)
        && installer.IsInstalled;

    public async Task<string?> GenerateAsync(LlmRequest request, CancellationToken cancellationToken = default)
    {
        if (!IsAvailable)
        {
            return null;
        }

        await _gate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            OnnxGenAiEngine engine = await GetEngineAsync(cancellationToken).ConfigureAwait(false);
            return await Task.Run(() => engine.Generate(request, cancellationToken), cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _gate.Release();
        }
    }

    public async Task WarmUpAsync(CancellationToken cancellationToken = default)
    {
        if (!IsAvailable)
        {
            return;
        }

        await _gate.WaitAsync(cancellationToken).ConfigureAwait(false);
        try
        {
            _ = await GetEngineAsync(cancellationToken).ConfigureAwait(false);
        }
        finally
        {
            _gate.Release();
        }
    }

    public async Task ReleaseAsync()
    {
        await _gate.WaitAsync().ConfigureAwait(false);
        try
        {
            _engine?.Dispose();
            _engine = null;
        }
        finally
        {
            _gate.Release();
        }
    }

    public void Dispose()
    {
        _engine?.Dispose();
        _gate.Dispose();
    }

    private async Task<OnnxGenAiEngine> GetEngineAsync(CancellationToken cancellationToken)
    {
        if (_engine is not null)
        {
            return _engine;
        }

        OnnxGenAiEngine engine = new(Path.Combine(FileSystem.AppDataDirectory, "llm"));
        try
        {
            await Task.Run(engine.Load, cancellationToken).ConfigureAwait(false);
            _engine = engine;
            return engine;
        }
        catch
        {
            engine.Dispose();
            throw;
        }
    }
}
