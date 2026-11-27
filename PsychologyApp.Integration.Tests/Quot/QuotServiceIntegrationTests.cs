using Microsoft.Extensions.DependencyInjection;
using PsychologyApp.Application.Abstractions.Integration;
using PsychologyApp.Application.Abstractions.Persistence;
using PsychologyApp.Application.Models;
using PsychologyApp.Application.Quot;
using PsychologyApp.Testing.Data;
using Xunit;

namespace PsychologyApp.Integration.Tests.Quot;

public sealed class QuotServiceIntegrationTests : IAsyncLifetime
{
    private readonly SharedMemoryConnectionFactory _connectionFactory = new();
    private ServiceProvider _provider = null!;

    public Task InitializeAsync()
    {
        _provider = IntegrationTestServiceCollection.BuildCoreProvider(_connectionFactory, services =>
        {
            var inner = new FakeQuotContentProvider();
            IntegrationTestServiceCollection.ReplaceSingleton<IQuotContentProvider>(
                services,
                new CachedQuotContentProvider(inner));
        });
        return Task.CompletedTask;
    }

    [Fact]
    public async Task LoadSingleAsync_PersistsQuoteToDatabase()
    {
        IDatabaseInitializer initializer = _provider.GetRequiredService<IDatabaseInitializer>();
        IQuotService quotService = _provider.GetRequiredService<IQuotService>();

        await initializer.InitializeAsync();
        await quotService.LoadSingleAsync();

        IEnumerable<PsychologyApp.Application.Models.QuotDTO> quotes =
            await quotService.GetAllAsync(5);

        Assert.NotEmpty(quotes);
    }

    [Fact]
    public async Task PopulateUnreadFeed_PreservesFavoritesAndHistoryWhenTheCatalogIsExhausted()
    {
        await _provider.GetRequiredService<IDatabaseInitializer>().InitializeAsync();
        IQuotService quotService = _provider.GetRequiredService<IQuotService>();
        QuotDTO daily = Assert.IsType<QuotDTO>(await quotService.GetDailyQuoteAsync(new DateOnly(2026, 1, 1)));

        await quotService.EnsureUnreadQuotesInFeedAsync(20);
        var other = Assert.Single(await quotService.GetUnreadAsync(20), quote => quote.QuotId != daily.QuotId);
        await quotService.MarkAsReadedAsync(other.QuotId);
        await quotService.MarkAsFavouriteAsync(other.QuotId, true);

        await quotService.EnsureUnreadQuotesInFeedAsync(20);

        Assert.Equal(daily.QuotId, Assert.Single(await quotService.GetUnreadAsync(20)).QuotId);
        Assert.Equal(other.QuotId, Assert.Single(await quotService.GetFavouritesAsync(20)).QuotId);
        Assert.True(await quotService.IsAllCaughtUpAsync(dailyQuoteText: daily.Text));
    }

    public async Task DisposeAsync()
    {
        await _connectionFactory.DisposeAsync();
        await _provider.DisposeAsync();
    }

    private sealed class FakeQuotContentProvider : IQuotContentProvider
    {
        public Task<IReadOnlyList<QuotSeed>> LoadAllAsync(CancellationToken cancellationToken = default) =>
            Task.FromResult<IReadOnlyList<QuotSeed>>(
            [
                new QuotSeed("Title", "Text", "Theme"),
                new QuotSeed("Another title", "Another text", "Theme")
            ]);
    }
}
