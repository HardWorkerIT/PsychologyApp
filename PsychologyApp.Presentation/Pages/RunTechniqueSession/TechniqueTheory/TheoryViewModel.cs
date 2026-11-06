using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PsychologyApp.Application.Configuration;
using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Presentation.Features.RunTechniqueSession.Index;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Models.Practice.Techniques;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.ViewModels;

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.TechniqueTheory;

public partial class TheoryViewModel : BaseViewModel
{
    private readonly TechniqueId? _techniqueId;
    private readonly string? _legacyContent;
    private readonly TechniqueCatalogGateway _techniqueCatalog;
    private readonly IOptions<AppSettings>? _settings;
    private readonly ILogger<TheoryViewModel>? _logger;
    private readonly SemaphoreSlim _initGate = new(1, 1);
    private bool _initialized;
    private CancellationTokenSource? _initCts;
    private string? _loadedLanguageKey;
    private string _observedLanguageKey = AppStrings.Language;

    public bool HasInitialized => _initialized;

    public TheoryViewModel(
        INavigationService navigationService,
        TechniqueCatalogGateway techniqueCatalog,
        string content,
        TechniqueId? techniqueId = null,
        IOptions<AppSettings>? settings = null,
        ILogger<TheoryViewModel>? logger = null)
    {
        _techniqueId = techniqueId;
        _legacyContent = techniqueId is null ? content : null;
        _techniqueCatalog = techniqueCatalog;
        _settings = settings;
        _logger = logger;
        ModuleName = AppStrings.ShellTabPractice;
        PageName = AppStrings.TechniqueTheory;

        BindNavigation(navigationService);
        Cancel = new Command(CancelInit);
        Reload = new AsyncCommand(ReloadAsync);

        if (techniqueId is null)
        {
            ApplyContent(content, null);
            SetDone();
            _initialized = true;
        }
    }

    public Task EnsureInitializedAsync()
    {
        if (_initialized && !IsFail)
        {
            return Task.CompletedTask;
        }

        return InitializeCoreAsync();
    }

    public Task InitializeAsync() => EnsureInitializedAsync();

    private async Task InitializeCoreAsync()
    {
        if (_techniqueId is null)
        {
            return;
        }

        await _initGate.WaitAsync();
        try
        {
            if (_initialized
                && !IsFail
                && string.Equals(_loadedLanguageKey, AppStrings.Language, StringComparison.Ordinal))
            {
                return;
            }

            _initCts?.Cancel();
            _initCts?.Dispose();
            IOptions<AppSettings>? settings = _settings;
            _initCts = settings is null
                ? new CancellationTokenSource(TimeSpan.FromSeconds(10))
                : OperationCancellation.CreateMiddleTimeoutSource(settings);
            string languageKey = AppStrings.Language;
            await LoadTechniqueContentAsync(_techniqueId.Value, languageKey, _initCts.Token);
            _initialized = !IsFail
                && string.Equals(_loadedLanguageKey, AppStrings.Language, StringComparison.Ordinal);
        }
        finally
        {
            _initGate.Release();
        }
    }

    private async Task ReloadAsync()
    {
        _initialized = false;
        _initCts?.Cancel();
        await EnsureInitializedAsync();
    }

    private void CancelInit()
    {
        _initCts?.Cancel();
        CancelProgress();
    }

    protected override void RefreshLocalizedProperties()
    {
        Notify(
            nameof(PageTitle),
            nameof(BackText),
            nameof(TechniqueSubtitle),
            nameof(HasTechniqueSubtitle),
            nameof(LoadingText),
            nameof(FailedText),
            nameof(RetryText));

        string languageKey = AppStrings.Language;
        bool languageChanged = !string.Equals(_observedLanguageKey, languageKey, StringComparison.Ordinal);
        _observedLanguageKey = languageKey;
        if (_techniqueId is TechniqueId && languageChanged)
        {
            ReloadAsync().FireAndForget();
            return;
        }

        if (!string.IsNullOrWhiteSpace(_legacyContent))
        {
            ApplyContent(_legacyContent, null);
        }
    }

    private async Task LoadTechniqueContentAsync(TechniqueId techniqueId, string languageKey, CancellationToken cancellationToken)
    {
        try
        {
            await UiThread.RunAsync(SetInit);
            TechniqueDefinition definition = await _techniqueCatalog.GetAsync(techniqueId, cancellationToken);
            cancellationToken.ThrowIfCancellationRequested();
            if (!string.Equals(languageKey, AppStrings.Language, StringComparison.Ordinal))
            {
                return;
            }

            await UiThread.RunAsync(() =>
            {
                if (cancellationToken.IsCancellationRequested
                    || !string.Equals(languageKey, AppStrings.Language, StringComparison.Ordinal))
                {
                    return;
                }

                ApplyContent(definition);
                _loadedLanguageKey = languageKey;
                SetDone();
            });
        }
        catch (OperationCanceledException)
        {
            await UiThread.RunAsync(CancelProgress);
        }
        catch (Exception ex)
        {
            _logger?.LogError(ex, "Failed to load technique theory content.");
            await UiThread.RunAsync(SetFail);
        }
    }
}
