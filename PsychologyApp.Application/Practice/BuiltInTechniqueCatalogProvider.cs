using PsychologyApp.Application.Abstractions.Integration;
using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Application.Practice.Catalog;
using PsychologyApp.Domain.Practice;

namespace PsychologyApp.Application.Practice;

public sealed class BuiltInTechniqueCatalogProvider(Func<string>? languageKeyProvider = null) : ITechniqueCatalogProvider
{
    public Task<IReadOnlyList<BuiltInTechniqueDefinition>> LoadAllAsync(CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        string languageKey = languageKeyProvider?.Invoke() ?? "ru";
        return Task.Run<IReadOnlyList<BuiltInTechniqueDefinition>>(() =>
        {
            IReadOnlyDictionary<TechniqueId, BuiltInTechniqueDefinition> definitions = BuiltInTechniqueCatalogRegistry.For(languageKey);
            cancellationToken.ThrowIfCancellationRequested();

            return Enum.GetValues<TechniqueId>()
                .Select(id => definitions[id])
                .ToList();
        }, cancellationToken);
    }
}
