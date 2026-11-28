using System.Collections.ObjectModel;
using System.Windows.Input;
using PsychologyApp.Application.Articles;
using PsychologyApp.Presentation.Entities.FilterChip;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.ViewModels;
using PsychologyApp.Presentation.Widgets.LibraryCard;

namespace PsychologyApp.Presentation.Pages.ReadArticles.Articles;

/// <summary>A section of the list: a group of a grouped CollectionView is a list of its items with a header.</summary>
public sealed class ArticleSectionItem : List<LibraryCardItem>
{
    public ArticleSectionItem(string title, IEnumerable<LibraryCardItem> articles, bool hasAdPlacement = false, bool hasBannerPlacement = false)
        : base(articles)
    {
        Title = title;
        HasAdPlacement = hasAdPlacement;
        HasBannerPlacement = hasBannerPlacement;
    }

    public string Title { get; }
    public bool HasTitle => Title.Length > 0;
    public bool HasAdPlacement { get; }
    public bool HasBannerPlacement { get; }
}

/// <summary>
/// The "Articles" top tab of the Library: search, chips for one section or all, and the articles in sections with read and saved marks.
/// </summary>
public sealed class ArticlesViewModel : BaseViewModel
{
    /// <summary>The same back arrow as on every other pushed page (the page hides the system bar).</summary>
    public ICommand BackCommand { get; }

    private const string AllKey = "all";
    private const string SavedKey = "saved";
    private const int ArticlesBeforeAdCount = 6;
    private const int ArticlesBeforeBannerCount = 2;

    private readonly INavigationService _navigation;
    private readonly IReadingService _reading;
    private readonly IDatabaseReadySignal _databaseReady;
    private string _selectedKey = AllKey;
    private string _query = string.Empty;
    private ReadingState _state = new();
    private bool _readingStateLoaded;
    private bool _readingStateFailed;
    private bool _refreshing;
    private IReadOnlyList<ArticleSectionItem> _sections = [];
    private string _emptyText = string.Empty;
    private (bool Banner, bool Native)? _lastArticleAdEligibility;

    public ArticlesViewModel(INavigationService navigation, IReadingService reading, IDatabaseReadySignal databaseReady)
    {
        BindNavigation(navigation);
        BackCommand = new AsyncCommand(GoBackAsync);
        _navigation = navigation;
        _reading = reading;
        _databaseReady = databaseReady;
        SelectFilterCommand = new Command<string?>(key =>
        {
            string selectedKey = string.IsNullOrEmpty(key) ? AllKey : key;
            UiHaptics.Tick();
            if (selectedKey == _selectedKey && _lastArticleAdEligibility == ArticleAdEligibility)
            {
                return;
            }

            _selectedKey = selectedKey;
            foreach (FilterChipTabItem filter in Filters)
            {
                filter.IsSelected = filter.Key == _selectedKey;
            }

            Load();
            NotifySavedState();
        });
        RetrySavedCommand = new AsyncCommand(RefreshAsync);
        BuildFilters();
        Load();
    }

    public string PageTitle => AppStrings.ShellTabArticlesShort;
    public string SearchPlaceholder => AppStrings.ArticlesSearchPlaceholder;
    public ICommand SelectFilterCommand { get; }
    public ICommand RetrySavedCommand { get; }
    public bool ShowSavedLoading => _selectedKey == SavedKey && !_readingStateLoaded && !_readingStateFailed;
    public bool ShowSavedLoadFailure => _selectedKey == SavedKey && _readingStateFailed;
    public string SavedLoadingText => AppStrings.SkeletonLoadingLabel;
    public string SavedLoadFailedText => AppStrings.LoadFailed;
    public string RetrySavedText => AppStrings.RetryQuestion;

    internal bool IsBrowsingGeneralCatalog => _selectedKey == AllKey && string.IsNullOrWhiteSpace(_query);

    private (bool Banner, bool Native) ArticleAdEligibility
    {
        get
        {
            if (!OperatingSystem.IsAndroid() || !string.IsNullOrWhiteSpace(_query))
            {
                return (false, false);
            }

            UserPreferencesState preferences = UserPreferencesStore.Load();
            return (AdvertisingConfiguration.CanRequestBannerAd(preferences), AdvertisingConfiguration.CanRequestNativeAd(preferences));
        }
    }

    public bool IsArticleAdEligible => Sections.Any(section => section.HasAdPlacement)
        && OperatingSystem.IsAndroid()
        && AdvertisingConfiguration.CanRequestNativeAd(UserPreferencesStore.Load());
    public bool IsArticleBannerEligible => Sections.Any(section => section.HasBannerPlacement)
        && OperatingSystem.IsAndroid()
        && AdvertisingConfiguration.CanRequestBannerAd(UserPreferencesStore.Load());

    public void RefreshAdEligibility()
    {
        if (_lastArticleAdEligibility != ArticleAdEligibility)
        {
            Load();
        }

        OnPropertyChanged(nameof(IsArticleAdEligible));
        OnPropertyChanged(nameof(IsArticleBannerEligible));
    }

    public ObservableCollection<FilterChipTabItem> Filters { get; } = [];

    /// <summary>What is typed in the search field; the list follows it as it is typed.</summary>
    public string Query
    {
        get => _query;
        set
        {
            if (SetProperty(ref _query, value ?? string.Empty))
            {
                Load();
                OnPropertyChanged(nameof(IsArticleAdEligible));
                OnPropertyChanged(nameof(IsArticleBannerEligible));
            }
        }
    }

    public IReadOnlyList<ArticleSectionItem> Sections
    {
        get => _sections;
        private set
        {
            if (SetProperty(ref _sections, value))
            {
                OnPropertyChanged(nameof(IsArticleAdEligible));
                OnPropertyChanged(nameof(IsArticleBannerEligible));
            }
        }
    }

    public string EmptyText
    {
        get => _emptyText;
        private set
        {
            if (SetProperty(ref _emptyText, value))
            {
                OnPropertyChanged(nameof(HasEmptyText));
            }
        }
    }

    public bool HasEmptyText => EmptyText.Length > 0;

    /// <summary>Called whenever the page appears: an article read or saved meanwhile changes its marks.</summary>
    public async Task RefreshAsync()
    {
        if (_refreshing)
        {
            return;
        }

        bool retrying = _readingStateFailed;
        _refreshing = true;
        _readingStateFailed = false;
        NotifySavedState();
        try
        {
            await _databaseReady.WaitAsync();
            ReadingState state = await _reading.GetAsync();
            await UiThread.RunAsync(() =>
            {
                // The page appears again after every article: rebuild the list only when a read or saved mark actually changed.
                bool marksChanged = retrying || !_readingStateLoaded || !state.Read.SequenceEqual(_state.Read) || !state.Saved.SequenceEqual(_state.Saved);
                _state = state;
                _readingStateLoaded = true;
                if (marksChanged)
                {
                    Load();
                }
            });
        }
        catch (Exception loadError)
        {
            BestEffort.Report(loadError);
            _readingStateFailed = true;
            if (_selectedKey == SavedKey)
            {
                Load();
            }
        }
        finally
        {
            _refreshing = false;
            NotifySavedState();
        }
    }

    private void NotifySavedState() => Notify(nameof(ShowSavedLoading), nameof(ShowSavedLoadFailure));

    private static string Language => AppStrings.Language;

    /// <summary>The section chips: built once, and again only when the language changes (a tap just moves the selection).</summary>
    private void BuildFilters()
    {
        Filters.Clear();
        Filters.Add(new FilterChipTabItem { Key = AllKey, Title = AppStrings.ArticlesFilterAll, IsSelected = _selectedKey == AllKey });
        Filters.Add(new FilterChipTabItem { Key = SavedKey, Title = AppStrings.ArticlesFilterSaved, IsSelected = _selectedKey == SavedKey });
        foreach (ArticleSection section in ArticleContent.Sections(Language))
        {
            Filters.Add(new FilterChipTabItem { Key = section.Key, Title = section.Title, IsSelected = _selectedKey == section.Key });
        }
    }

    private void Load()
    {
        (bool canPlaceBanner, bool canPlaceNative) = ArticleAdEligibility;
        _lastArticleAdEligibility = (canPlaceBanner, canPlaceNative);
        int queryLength = _query.AsSpan().Trim().Length;

        if (_selectedKey == SavedKey && !_readingStateLoaded)
        {
            Sections = [];
            EmptyText = string.Empty;
            return;
        }

        if (queryLength >= ArticleSearch.MinQueryLength)
        {
            IReadOnlyList<Article> found = ArticleSearch.Find(_query, Language);
            if (_selectedKey == SavedKey)
            {
                HashSet<string> savedArticleIds = _state.Saved.ToHashSet(StringComparer.Ordinal);
                found = found.Where(article => savedArticleIds.Contains(article.Id)).ToList();
            }
            else if (_selectedKey != AllKey)
            {
                HashSet<string> selectedArticleIds = ArticleContent.Sections(Language)
                    .Where(section => section.Key == _selectedKey)
                    .SelectMany(section => section.Articles)
                    .Select(article => article.Id)
                    .ToHashSet(StringComparer.Ordinal);
                found = found.Where(article => selectedArticleIds.Contains(article.Id)).ToList();
            }

            Sections = found.Count == 0 ? [] : [new ArticleSectionItem(string.Empty, found.Select(Card))];
            EmptyText = found.Count == 0 && !ShowSavedLoadFailure ? AppStrings.ArticlesNothingFound : string.Empty;
            return;
        }

        if (_selectedKey == SavedKey)
        {
            List<Article> savedArticles = _state.Saved
                .Select(id => ArticleContent.Find(id, Language))
                .OfType<Article>()
                .ToList();
            Sections = savedArticles.Count == 0 ? [] : [new ArticleSectionItem(string.Empty, savedArticles.Select(Card))];
            if (queryLength > 0)
            {
                EmptyText = AppStrings.ArticlesSearchMinLength;
            }
            else
            {
                EmptyText = savedArticles.Count == 0 && !ShowSavedLoadFailure ? AppStrings.ArticlesNothingSaved : string.Empty;
            }

            return;
        }

        EmptyText = queryLength > 0 ? AppStrings.ArticlesSearchMinLength : string.Empty;
        IReadOnlyList<ArticleSection> sourceSections = ArticleContent.Sections(Language)
            .Where(section => _selectedKey == AllKey || section.Key == _selectedKey)
            .ToList();
        int articleCount = sourceSections.Sum(section => section.Articles.Count);
        bool placeBanner = canPlaceBanner && articleCount >= ArticlesBeforeBannerCount;
        bool placeNative = canPlaceNative && articleCount >= ArticlesBeforeAdCount;
        if (!placeBanner && !placeNative)
        {
            Sections = sourceSections
                .Select(section => new ArticleSectionItem(section.Title, section.Articles.Select(Card)))
                .ToList();
            return;
        }

        List<ArticleSectionItem> displaySections = [];
        int displayedArticleCount = 0;
        bool bannerPlaced = false;
        bool nativePlaced = false;
        foreach (ArticleSection section in sourceSections)
        {
            int offset = 0;
            bool titlePending = true;
            while (offset < section.Articles.Count)
            {
                int nextPlacement = int.MaxValue;
                if (placeBanner && !bannerPlaced) nextPlacement = Math.Min(nextPlacement, ArticlesBeforeBannerCount);
                if (placeNative && !nativePlaced) nextPlacement = Math.Min(nextPlacement, ArticlesBeforeAdCount);
                int take = Math.Min(section.Articles.Count - offset, Math.Max(1, nextPlacement - displayedArticleCount));
                int countAfterChunk = displayedArticleCount + take;
                bool hasBannerPlacement = placeBanner && !bannerPlaced && countAfterChunk == ArticlesBeforeBannerCount;
                bool hasAdPlacement = placeNative && !nativePlaced && countAfterChunk == ArticlesBeforeAdCount;
                displaySections.Add(new ArticleSectionItem(
                    titlePending ? section.Title : string.Empty,
                    section.Articles.Skip(offset).Take(take).Select(Card),
                    hasAdPlacement,
                    hasBannerPlacement));
                bannerPlaced |= hasBannerPlacement;
                nativePlaced |= hasAdPlacement;
                titlePending = false;
                offset += take;
                displayedArticleCount = countAfterChunk;
            }
        }

        Sections = displaySections;
    }

    private LibraryCardItem Card(Article article) => LibraryCards.Article(article, _state, _navigation);

    protected override void RefreshLocalizedProperties()
    {
        BuildFilters();
        Load();
        Notify(nameof(PageTitle), nameof(SearchPlaceholder), nameof(SavedLoadingText), nameof(SavedLoadFailedText), nameof(RetrySavedText));
    }
}
