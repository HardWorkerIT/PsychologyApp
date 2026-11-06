using PsychologyApp.Presentation.Shared.Services.Preferences;
using PsychologyApp.Application.Practice;
using PsychologyApp.Application.Quot;
using PsychologyApp.Application.Tests;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Shared.Common.Localization;

public sealed class LanguageContentReloader : ILanguageContentReloader
{
    private readonly IUserPreferencesStore _preferences;
    public const int DefaultQuoteFeedCount = 20;

    private readonly IQuotService _quotService;
    private readonly CachedQuotContentProvider _quotCache;
    private readonly CachedTestCatalogProvider _testCatalogCache;
    private readonly CachedTechniqueCatalogProvider _techniqueCatalogCache;
    private readonly ITechniqueCatalogService _techniqueCatalogService;
    private readonly object _sync = new();
    private string _lastPersistedLanguage = UserPreferences.DefaultLanguage;
    private Task _reloadTask = Task.CompletedTask;
    private bool _isPreparingForErase;

    public LanguageContentReloader(
        IQuotService quotService,
        CachedQuotContentProvider quotCache,
        CachedTestCatalogProvider testCatalogCache,
        CachedTechniqueCatalogProvider techniqueCatalogCache,
        ITechniqueCatalogService techniqueCatalogService,
        IUserPreferencesStore preferences)
    {
        _preferences = preferences;
        _quotService = quotService;
        _quotCache = quotCache;
        _testCatalogCache = testCatalogCache;
        _techniqueCatalogCache = techniqueCatalogCache;
        _techniqueCatalogService = techniqueCatalogService;
        _lastPersistedLanguage = _preferences.PersistedLanguage;
        _preferences.Changed += OnPreferencesChanged;
    }

    public Task EnsureReloadedAsync()
    {
        lock (_sync)
        {
            return _reloadTask;
        }
    }

    private void OnPreferencesChanged()
    {
        lock (_sync)
        {
            if (_isPreparingForErase)
            {
                return;
            }

            string persistedLanguage = _preferences.PersistedLanguage;
            if (string.Equals(_lastPersistedLanguage, persistedLanguage, StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            _lastPersistedLanguage = persistedLanguage;
            _quotCache.Invalidate();
            _testCatalogCache.Invalidate();
            _techniqueCatalogCache.Invalidate();
            _techniqueCatalogService.Invalidate();
            _reloadTask = QueueReseedAsync(_reloadTask);
        }
    }

    /// <summary>Stops new reseeds and waits for every already queued language reload before the database is replaced.</summary>
    public async Task PrepareForEraseAsync()
    {
        Task reload;
        lock (_sync)
        {
            _isPreparingForErase = true;
            reload = _reloadTask;
        }

        try
        {
            await reload.ConfigureAwait(false);
        }
        catch
        {
            // A completed failed reseed owns no further database work; it must not prevent a full data erase.
        }

        await _quotService.PrepareForEraseAsync().ConfigureAwait(false);
    }

    public void CompleteErase()
    {
        _quotService.CompleteErase();
        lock (_sync)
        {
            _lastPersistedLanguage = _preferences.PersistedLanguage;
            _quotCache.Invalidate();
            _testCatalogCache.Invalidate();
            _techniqueCatalogCache.Invalidate();
            _techniqueCatalogService.Invalidate();
            _isPreparingForErase = false;
        }
    }

    private async Task QueueReseedAsync(Task previous)
    {
        try
        {
            await previous.ConfigureAwait(false);
        }
        catch
        {
            // Keep later language selections usable after one failed background reload.
        }

        await _quotService.ReseedFeedAsync(DefaultQuoteFeedCount).ConfigureAwait(false);
    }
}
