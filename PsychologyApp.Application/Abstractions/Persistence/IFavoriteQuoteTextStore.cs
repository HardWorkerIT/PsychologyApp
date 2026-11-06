namespace PsychologyApp.Application.Abstractions.Persistence;

public interface IFavoriteQuoteTextStore
{
    Task<IReadOnlySet<string>> GetTextsAsync(CancellationToken cancellationToken = default);

    Task AddTextAsync(string text, CancellationToken cancellationToken = default);

    Task RemoveTextAsync(string text, CancellationToken cancellationToken = default);

    /// <summary>Merges the supplied favorite texts into storage without removing favorites written concurrently elsewhere.</summary>
    Task SaveTextsAsync(IReadOnlySet<string> texts, CancellationToken cancellationToken = default);

    Task<IReadOnlySet<int>> GetLegacyIndicesAsync(CancellationToken cancellationToken = default);

    Task ClearLegacyIndicesAsync(CancellationToken cancellationToken = default);
}
