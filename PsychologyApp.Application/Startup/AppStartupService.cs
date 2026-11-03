using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PsychologyApp.Application.Abstractions.Persistence;
using PsychologyApp.Application.Abstractions.Startup;
using PsychologyApp.Application.Configuration;
using PsychologyApp.Application.Conversation.Companion;
using PsychologyApp.Application.Practice;
using PsychologyApp.Application.Quot;
using PsychologyApp.Application.Statistic;

namespace PsychologyApp.Application.Startup;

public sealed class AppStartupService(
    IDatabaseInitializer databaseInitializer,
    IQuotService quotService,
    IQuoteCatalogVersionStore quoteCatalogVersionStore,
    ITechniqueCatalogService techniqueCatalogService,
    IOptions<AppSettings> settings,
    ILogger<AppStartupService> logger,
    IStatisticService? statistics = null) : IAppStartupService
{
    private readonly object _warmupLock = new();
    private Task? _warmupTask;

    public async Task InitializeAsync(CancellationToken cancellationToken = default)
    {
        await databaseInitializer.InitializeAsync(cancellationToken).ConfigureAwait(false);
    }

    public Task WarmupAsync()
    {
        lock (_warmupLock)
        {
            return _warmupTask ??= Task.Run(InitializeOptionalWorkAsync);
        }
    }

    private async Task InitializeOptionalWorkAsync()
    {
        using var timeoutSource = new CancellationTokenSource();
        timeoutSource.CancelAfter(settings.Value.MiddleTimeoutMs);

        try
        {
            await Task.WhenAll(
                SeedQuotesAsync(timeoutSource.Token),
                PrewarmTechniqueCatalogAsync(timeoutSource.Token),
                PrewarmEmotionGuesserAsync(),
                PruneStatisticsAsync(timeoutSource.Token)).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Optional startup warmup failed; app can continue.");
        }
    }

    private static Task PrewarmEmotionGuesserAsync() => Task.Run(() => _ = EmotionGuesser.Bundled);

    /// <summary>Page-visit history is written on every screen view and read by nothing but a distinct-page count: keep 90 days of it.</summary>
    private async Task PruneStatisticsAsync(CancellationToken cancellationToken)
    {
        if (statistics is null)
        {
            return;
        }

        try
        {
            await statistics.PruneAsync(StatisticsRetention, cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "Pruning page statistics failed; app can continue.");
        }
    }

    private static readonly TimeSpan StatisticsRetention = TimeSpan.FromDays(90);

    private async Task SeedQuotesAsync(CancellationToken cancellationToken)
    {
        try
        {
            int persistedVersion = await quoteCatalogVersionStore.GetAsync(cancellationToken).ConfigureAwait(false);
            if (persistedVersion < QuoteCatalogPolicy.CurrentVersion)
            {
                await quotService.ReseedFeedAsync(QuoteCatalogPolicy.DefaultFeedSeedCount, cancellationToken).ConfigureAwait(false);
                await quoteCatalogVersionStore.SetAsync(QuoteCatalogPolicy.CurrentVersion, cancellationToken).ConfigureAwait(false);
            }
            else
            {
                await quotService.LoadSingleAsync(cancellationToken).ConfigureAwait(false);
            }
        }
        catch (Exception ex)
        {
            // Any failure here (a bad asset, a database error, the startup deadline) is survivable: the quotes are seeded again next start,
            // because the catalogue version is only recorded after a complete seeding.
            logger.LogError(ex, "Preload quotes failed; app can continue.");
        }
    }

    private async Task PrewarmTechniqueCatalogAsync(CancellationToken cancellationToken)
    {
        try
        {
            await techniqueCatalogService.GetAllAsync(cancellationToken).ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Preload technique catalog failed; app can continue.");
        }
    }
}
