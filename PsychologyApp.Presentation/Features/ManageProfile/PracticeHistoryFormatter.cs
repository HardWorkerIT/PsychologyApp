using PsychologyApp.Application.Models;
using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Application.Practice;
using PsychologyApp.Domain.Practice;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Features.ManageProfile;

public sealed class PracticeHistoryFormatter(ITechniqueCatalogService techniqueCatalogService)
{
    public async Task<(string Name, string Icon)> ResolveNameAndIconAsync(
        string itemKey,
        string? pageName = null,
        CancellationToken cancellationToken = default)
    {
        if (itemKey.StartsWith("custom_", StringComparison.Ordinal))
        {
            return (pageName ?? itemKey, "SelfImprovement");
        }

        if (Enum.TryParse(itemKey, out TechniqueId techniqueId))
        {
            BuiltInTechniqueDefinition technique = await techniqueCatalogService.GetAsync(techniqueId, cancellationToken);
            return (technique.PageName, technique.ListIcon);
        }

        return (string.IsNullOrWhiteSpace(pageName) ? itemKey : pageName, "SelfImprovement");
    }

    public async Task<string> ResolveNameAsync(CompletionDTO completion, CancellationToken cancellationToken = default) =>
        await ResolveNameAsync(completion.ItemKey, completion.PageName, cancellationToken);

    public async Task<string> ResolveNameAsync(
        string itemKey,
        string? pageName = null,
        CancellationToken cancellationToken = default) =>
        (await ResolveNameAndIconAsync(itemKey, pageName, cancellationToken)).Name;

    public async Task<string> ResolveIconAsync(CompletionDTO completion, CancellationToken cancellationToken = default) =>
        await ResolveIconAsync(completion.ItemKey, cancellationToken);

    public async Task<string> ResolveIconAsync(string itemKey, CancellationToken cancellationToken = default) =>
        (await ResolveNameAndIconAsync(itemKey, cancellationToken: cancellationToken)).Icon;

    public (string Text, bool HasDuration) ResolveDuration(CompletionDTO completion) =>
        ResolveDuration(completion.DurationSeconds);

    public (string Text, bool HasDuration) ResolveDuration(SessionResultDTO result) =>
        ResolveDuration(result.DurationSeconds);

    private static (string Text, bool HasDuration) ResolveDuration(int durationSeconds)
    {
        if (durationSeconds <= 0)
        {
            return (string.Empty, false);
        }

        return (AppStrings.TestResultDuration(durationSeconds), true);
    }

    public (string Text, bool HasDelta) ResolveSudsDelta(SessionResultDTO result)
    {
        if (result.PreIntensity is not (>= 0 and <= 10) || result.PostIntensity is not (>= 0 and <= 10))
        {
            return (string.Empty, false);
        }

        return (AppStrings.PracticeSudsDelta(result.PreIntensity.Value, result.PostIntensity.Value), true);
    }
}
