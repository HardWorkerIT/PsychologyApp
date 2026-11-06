using Microsoft.Maui.ApplicationModel.DataTransfer;
using PsychologyApp.Presentation.Entities.Journal;
using PsychologyApp.Presentation.Entities.Profile;
using PsychologyApp.Presentation.Features.ManageJournal;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.ViewModels;
using System.Windows.Input;

namespace PsychologyApp.Presentation.Pages.ManageJournal.JournalTimeline;

public sealed class JournalTimelineViewModel : BaseViewModel
{
    private readonly JournalMoodLoader _journalMoodLoader;
    private readonly JournalScreenCoordinator _journalScreenCoordinator;
    private readonly INavigationService _navigationService;
    private int _loadGeneration;
    private IReadOnlyList<JournalTimelineDayGroup> _allTimelineGroups = [];
    private string _loadedLanguageKey = AppStrings.Language;
    private bool _loaded;
    private bool _isLoading = true;
    private bool _isLoadFailed;

    public JournalTimelineViewModel(
        JournalMoodLoader journalMoodLoader,
        JournalScreenCoordinator journalScreenCoordinator,
        INavigationService navigationService)
    {
        _journalMoodLoader = journalMoodLoader;
        _journalScreenCoordinator = journalScreenCoordinator;
        _navigationService = navigationService;
        BindNavigation(navigationService);
        BackCommand = new AsyncCommand(() => navigationService.GoBackAsync());
        ReloadCommand = new AsyncCommand(ReloadAsync);
        SelectTimelineEntryCommand = new AsyncCommand<object?>(SelectTimelineEntryAsync);
        ShareEntryCommand = new AsyncCommand<object?>(ShareEntryAsync);
    }

    public string PageTitle => AppStrings.JournalTimelineTitle;
    public string SearchPlaceholder => AppStrings.JournalSearchPlaceholder;
    public string ShareLabel => AppStrings.JournalShareLabel;
    public string LoadingText => AppStrings.SkeletonLoadingLabel;
    public string LoadFailedText => AppStrings.LoadFailed;
    public string RetryText => AppStrings.RetryQuestion;

    public ICommand BackCommand { get; }
    public ICommand ReloadCommand { get; }
    public ICommand SelectTimelineEntryCommand { get; }
    public ICommand ShareEntryCommand { get; }

    private IReadOnlyList<object> _timelineItems = [];
    public IReadOnlyList<object> TimelineItems
    {
        get => _timelineItems;
        private set
        {
            if (SetProperty(ref _timelineItems, value))
            {
                OnPropertyChanged(nameof(HasMoodNotes));
                OnPropertyChanged(nameof(ShowMoodNotesEmpty));
                OnPropertyChanged(nameof(MoodNotesEmpty));
            }
        }
    }

    public bool HasMoodNotes => TimelineItems.Count > 0;
    public bool ShowMoodNotesEmpty => _loaded && !IsLoading && !IsLoadFailed && !HasMoodNotes;

    public bool IsLoading
    {
        get => _isLoading;
        private set
        {
            if (SetProperty(ref _isLoading, value))
            {
                OnPropertyChanged(nameof(ShowMoodNotesEmpty));
            }
        }
    }

    public bool IsLoadFailed
    {
        get => _isLoadFailed;
        private set
        {
            if (SetProperty(ref _isLoadFailed, value))
            {
                OnPropertyChanged(nameof(ShowMoodNotesEmpty));
            }
        }
    }

    public string MoodNotesEmpty =>
        string.IsNullOrWhiteSpace(SearchQuery)
            ? AppStrings.JournalTimelineEmpty
            : AppStrings.JournalSearchEmpty;

    private string _searchQuery = string.Empty;
    public string SearchQuery
    {
        get => _searchQuery;
        set
        {
            if (SetProperty(ref _searchQuery, value))
            {
                ApplySearchFilter();
            }
        }
    }

    protected override void RefreshLocalizedProperties()
    {
        Notify(
            nameof(PageTitle),
            nameof(SearchPlaceholder),
            nameof(ShareLabel),
            nameof(MoodNotesEmpty),
            nameof(LoadingText),
            nameof(LoadFailedText),
            nameof(RetryText),
            nameof(HasMoodNotes),
            nameof(ShowMoodNotesEmpty));
        string languageKey = AppStrings.Language;
        if (!string.Equals(_loadedLanguageKey, languageKey, StringComparison.Ordinal))
        {
            _loadedLanguageKey = languageKey;
            LoadAsync().FireAndForget();
        }
    }

    public Task ReloadAsync() => LoadAsync();

    private void ApplySearchFilter()
    {
        IReadOnlyList<JournalTimelineDayGroup> groups =
            JournalMoodLoader.FilterGroupsByNoteSearch(_allTimelineGroups, SearchQuery);
        TimelineItems = FlattenGroups(groups);
    }

    private static IReadOnlyList<object> FlattenGroups(IReadOnlyList<JournalTimelineDayGroup> groups)
    {
        List<object> items = [];
        foreach (JournalTimelineDayGroup group in groups)
        {
            items.Add(new JournalTimelineHeaderItem(group.Day, group.DateLabel));
            foreach (MoodNoteItem entry in group.Entries)
            {
                items.Add(entry);
            }
        }

        return items;
    }

    private async Task LoadAsync()
    {
        int generation = Interlocked.Increment(ref _loadGeneration);
        if (!_loaded)
        {
            IsLoading = true;
            IsLoadFailed = false;
        }

        try
        {
            JournalMoodSnapshot snapshot = await _journalMoodLoader.LoadAsync(90);
            if (generation != Volatile.Read(ref _loadGeneration))
            {
                return;
            }

            await UiThread.RunAsync(() =>
            {
                if (generation != Volatile.Read(ref _loadGeneration))
                {
                    return;
                }

                _allTimelineGroups = snapshot.TimelineGroups;
                ApplySearchFilter();
                _loaded = true;
                IsLoading = false;
                IsLoadFailed = false;
            });
        }
        catch (Exception bestEffortError)
        {
            // Timeline is optional.
            BestEffort.Report(bestEffortError);
            if (!_loaded)
            {
                await UiThread.RunAsync(() =>
                {
                    if (generation == Volatile.Read(ref _loadGeneration))
                    {
                        IsLoading = false;
                        IsLoadFailed = true;
                    }
                });
            }
        }
    }

    private async Task SelectTimelineEntryAsync(object? parameter)
    {
        if (parameter is not MoodNoteItem entry)
        {
            return;
        }

        await _journalScreenCoordinator.OpenEditorDayAsync(entry.Day, _navigationService);
    }

    private async Task ShareEntryAsync(object? parameter)
    {
        if (parameter is not MoodNoteItem entry)
        {
            return;
        }

        string note = entry.HasNote ? entry.NoteText : string.Empty;
        IReadOnlyList<string> factors = JournalNoteFactors.ExtractActiveLabels(note);
        await Share.Default.RequestAsync(new ShareTextRequest
        {
            Title = AppStrings.JournalShareTitle,
            Text = AppStrings.JournalShareEntryWithFactors(entry.DateText, entry.MoodLevel, note, factors)
        });
    }
}
