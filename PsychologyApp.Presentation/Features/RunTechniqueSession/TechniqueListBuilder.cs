using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Application.UserProgress;
using PsychologyApp.Domain.Practice;
using PsychologyApp.Presentation.Features.RunTechniqueSession.Index;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Entities.Technique;
using PsychologyApp.Presentation.Shared.Navigation;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace PsychologyApp.Presentation.Features.RunTechniqueSession;

public sealed class TechniqueListLayout
{
    public required bool IsGrouped { get; init; }
    public required IReadOnlyList<TechniqueItem> StaticItems { get; init; }
    public required IReadOnlyList<TechniqueItem> CustomItems { get; init; }
    public required object ItemsSource { get; init; }
    public required IReadOnlyList<TechniqueGroup> Groups { get; init; }
}

public sealed class TechniqueListBuilder(
    IUserProgressService userProgressService,
    TechniqueCatalogGateway techniqueCatalog)
{
    // Recommendations reuse existing exercises; the no-typing route relies on the catalog's optional, skippable answers.
    private static readonly IReadOnlyDictionary<PracticeFinderNeed, TechniqueId[]> FinderPracticeIds =
        new Dictionary<PracticeFinderNeed, TechniqueId[]>
        {
            [PracticeFinderNeed.EyesOpen] =
            [
                TechniqueId.Grounding, TechniqueId.BusyMind, TechniqueId.ThoughtDefusion,
                TechniqueId.Balloons, TechniqueId.CheckTheFacts
            ],
            [PracticeFinderNeed.NoBreathFocus] =
            [
                TechniqueId.BusyMind, TechniqueId.ThoughtDefusion,
                TechniqueId.CheckTheFacts, TechniqueId.Observer
            ],
            [PracticeFinderNeed.NoTyping] =
            [TechniqueId.BusyMind, TechniqueId.ThoughtDefusion, TechniqueId.Balloons, TechniqueId.Grounding],
            [PracticeFinderNeed.Public] =
            [TechniqueId.ThoughtDefusion, TechniqueId.BusyMind, TechniqueId.Grounding],
            [PracticeFinderNeed.BeforeConversation] =
            [TechniqueId.PauseBeforeReaction, TechniqueId.ImplementationIntention, TechniqueId.CheckTheFacts],
            [PracticeFinderNeed.PassengerCommute] =
            [TechniqueId.Grounding, TechniqueId.BusyMind, TechniqueId.ThoughtDefusion],
            [PracticeFinderNeed.BeforeSleep] = [TechniqueId.MuscleRelax, TechniqueId.SelfCompassion],
            [PracticeFinderNeed.AfterConflict] = [TechniqueId.PauseBeforeReaction, TechniqueId.Grounding, TechniqueId.CheckTheFacts]
        };

    internal async Task<IReadOnlyList<TechniqueListEntry>> FindSuitablePracticesAsync(
        PracticeFinderNeed need,
        CancellationToken cancellationToken = default)
    {
        IReadOnlyList<TechniqueListEntry> entries = await techniqueCatalog.GetBuiltInListEntriesAsync(cancellationToken);
        Dictionary<TechniqueId, TechniqueListEntry> byId = entries.ToDictionary(entry => entry.TechniqueId);
        IEnumerable<TechniqueId> preferredIds;
        if (need == PracticeFinderNeed.Quick)
        {
            preferredIds = [TechniqueId.BusyMind, TechniqueId.Observer, TechniqueId.ThoughtDefusion];
        }
        else if (FinderPracticeIds.TryGetValue(need, out TechniqueId[]? ids) && ids is not null)
        {
            preferredIds = ids;
        }
        else
        {
            preferredIds = [];
        }

        List<TechniqueListEntry> results = [];
        foreach (TechniqueId techniqueId in preferredIds)
        {
            if (byId.TryGetValue(techniqueId, out TechniqueListEntry? entry)
                && entry is not null
                && (need != PracticeFinderNeed.Quick || entry.DurationMinutes <= 2))
            {
                results.Add(entry);
            }
        }

        return results;
    }

    public async Task<IReadOnlyList<TechniqueItem>> BuildStaticItemsAsync(
        INavigationService navigationService,
        CancellationToken cancellationToken = default)
    {
        IReadOnlyList<TechniqueListEntry> entries =
            await techniqueCatalog.GetBuiltInListEntriesAsync(cancellationToken);
        IReadOnlyList<string> keys = entries.Select(entry => entry.TechniqueId.ToString()).ToList();

        Task<IReadOnlyDictionary<string, DateTime>> lastPracticeDatesTask =
            userProgressService.GetLastPracticeDatesAsync(keys, cancellationToken);
        Task<IReadOnlySet<string>> draftKeysTask =
            userProgressService.GetSessionDraftKeysAsync(keys, cancellationToken);

        await Task.WhenAll(lastPracticeDatesTask, draftKeysTask);

        IReadOnlyDictionary<string, DateTime> lastPracticeDates = await lastPracticeDatesTask;
        IReadOnlySet<string> draftKeys = await draftKeysTask;

        List<TechniqueItem> items = [];

        foreach (TechniqueListEntry entry in entries)
        {
            string key = entry.TechniqueId.ToString();
            DateTime? lastPracticeDate = lastPracticeDates.TryGetValue(key, out DateTime lastPractice)
                ? lastPractice
                : null;
            string durationText = AppStrings.TechniqueDuration(entry.DurationMinutes);
            string theme = draftKeys.Contains(key) ? AppStrings.TechniqueContinueBadge : entry.Theme;

            items.Add(new TechniqueItem
            {
                Number = entry.Number,
                // Only a practice already done says so: "Not tried yet" on nearly every card was noise.
                Date = lastPracticeDate is null
                    ? string.Empty
                    : AppStrings.TechniqueLastPractice(lastPracticeDate.Value.ToLocalTime().ToString("d")),
                IconName = entry.Icon,
                DurationText = durationText,
                MetaText = AppStrings.TechniqueMetaLine(durationText, theme),
                Title = entry.Title,
                Subtitle = entry.Subtitle,
                Theme = theme,
                Author = entry.Author,
                Flavor = TechniqueFlavors.For(entry.TechniqueId).ToString(),
                Active = true,
                TapCommand = new AsyncCommand(() => navigationService.GoToTechniqueAsync(entry.TechniqueId))
            });
        }

        return items;
    }

    public IReadOnlyList<TechniqueItem> MapCustomItems(
        IEnumerable<TechniqueDTO> techniques,
        INavigationService navigationService) =>
        techniques.Select(item => new TechniqueItem
        {
            Id = item.TechniqueId,
            Number = AppStrings.PracticeCustomTechniqueNumber(item.TechniqueId),
            Date = item.Date,
            Image = item.Image,
            IconName = "Build",
            Title = item.Header,
            Subtitle = item.Description,
            Theme = item.Subject,
            MetaText = item.Subject ?? string.Empty,
            Author = item.Author,
            Active = true,
            TapCommand = new AsyncCommand(() => navigationService.GoToCreatedAsync(item.TechniqueId))
        }).ToList();

    public TechniqueListLayout BuildLayout(
        IReadOnlyList<TechniqueItem> staticItems,
        IReadOnlyList<TechniqueItem> customItems,
        string customGroupLabel)
    {
        if (customItems.Count > 0)
        {
            TechniqueGroup[] groups =
            [
                new TechniqueGroup(string.Empty, staticItems),
                new TechniqueGroup(customGroupLabel, customItems)
            ];
            return new TechniqueListLayout
            {
                IsGrouped = true,
                StaticItems = staticItems,
                CustomItems = customItems,
                Groups = groups,
                ItemsSource = groups
            };
        }

        return new TechniqueListLayout
        {
            IsGrouped = false,
            StaticItems = staticItems,
            CustomItems = customItems,
            Groups = [],
            ItemsSource = new ObservableCollection<TechniqueItem>(staticItems)
        };
    }
}

internal enum PracticeFinderNeed
{
    Quick,
    EyesOpen,
    NoBreathFocus,
    NoTyping,
    Public,
    Situations,
    BeforeConversation,
    PassengerCommute,
    BeforeSleep,
    AfterConflict
}
