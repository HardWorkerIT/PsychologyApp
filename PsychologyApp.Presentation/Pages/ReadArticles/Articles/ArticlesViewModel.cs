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
    public ArticleSectionItem(string title, IEnumerable<LibraryCardItem> articles, bool hasAdPlacement = false)
        : base(articles)
    {
        Title = title;
        HasAdPlacement = hasAdPlacement;
    }

    public string Title { get; }
    public bool HasTitle => Title.Length > 0;
    public bool HasAdPlacement { get; }
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

    private readonly INavigationService _navigation;
    private readonly IReadingService _reading;
    private readonly IDatabaseReadySignal _databaseReady;
    private string _selectedKey = AllKey;
    private string _query = string.Empty;
    private ReadingState _state = new();
    private IReadOnlyList<ArticleSectionItem> _sections = [];
    private string _emptyText = string.Empty;
    private bool? _lastCanPlaceArticleAd;

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
            if (selectedKey == _selectedKey && _lastCanPlaceArticleAd == CanPlaceArticleAd)
            {
                return;
            }

            _selectedKey = selectedKey;
            foreach (FilterChipTabItem filter in Filters)
            {
                filter.IsSelected = filter.Key == _selectedKey;
            }

            Load();
        });
        BuildFilters();
        Load();
    }

    public string PageTitle => AppStrings.ShellTabArticlesShort;
    public string SearchPlaceholder => AppStrings.ArticlesSearchPlaceholder;
    public ICommand SelectFilterCommand { get; }

    internal bool IsBrowsingGeneralCatalog => _selectedKey == AllKey && string.IsNullOrWhiteSpace(_query);

    private bool CanPlaceArticleAd => OperatingSystem.IsAndroid()
        && string.IsNullOrWhiteSpace(_query)
        && AdvertisingConfiguration.CanRequestNativeAd(UserPreferencesStore.Load());

    public bool IsArticleAdEligible => Sections.Any(section => section.HasAdPlacement)
        && CanPlaceArticleAd;

    public void RefreshAdEligibility()
    {
        if (_lastCanPlaceArticleAd != CanPlaceArticleAd)
        {
            Load();
        }

        OnPropertyChanged(nameof(IsArticleAdEligible));
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
        try
        {
            await _databaseReady.WaitAsync();
            ReadingState state = await _reading.GetAsync();
            await UiThread.RunAsync(() =>
            {
                // The page appears again after every article: rebuild the list only when a read or saved mark actually changed.
                bool marksChanged = !state.Read.SequenceEqual(_state.Read) || !state.Saved.SequenceEqual(_state.Saved);
                _state = state;
                if (marksChanged)
                {
                    Load();
                }
            });
        }
        catch (Exception loadError)
        {
            // The articles are in the app; only the read and saved marks are missing.
            BestEffort.Report(loadError);
        }
    }

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
        bool canPlaceAd = CanPlaceArticleAd;
        _lastCanPlaceArticleAd = canPlaceAd;
        int queryLength = _query.AsSpan().Trim().Length;

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
            EmptyText = found.Count == 0 ? AppStrings.ArticlesNothingFound : string.Empty;
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
                EmptyText = savedArticles.Count == 0 ? AppStrings.ArticlesNothingSaved : string.Empty;
            }

            return;
        }

        EmptyText = queryLength > 0 ? AppStrings.ArticlesSearchMinLength : string.Empty;
        IReadOnlyList<ArticleSection> sourceSections = ArticleContent.Sections(Language)
            .Where(section => _selectedKey == AllKey || section.Key == _selectedKey)
            .ToList();
        int articleCount = sourceSections.Sum(section => section.Articles.Count);
        if (!canPlaceAd || articleCount < ArticlesBeforeAdCount)
        {
            Sections = sourceSections
                .Select(section => new ArticleSectionItem(section.Title, section.Articles.Select(Card)))
                .ToList();
            return;
        }

        List<ArticleSectionItem> displaySections = [];
        int articlesUntilAd = ArticlesBeforeAdCount;
        bool adPlaced = false;
        foreach (ArticleSection section in sourceSections)
        {
            IReadOnlyList<Article> articles = section.Articles;
            if (!adPlaced && articles.Count >= articlesUntilAd)
            {
                displaySections.Add(new ArticleSectionItem(
                    section.Title,
                    articles.Take(articlesUntilAd).Select(Card),
                    hasAdPlacement: true));
                adPlaced = true;
                if (articles.Count > articlesUntilAd)
                {
                    displaySections.Add(new ArticleSectionItem(string.Empty, articles.Skip(articlesUntilAd).Select(Card)));
                }
            }
            else
            {
                displaySections.Add(new ArticleSectionItem(section.Title, articles.Select(Card)));
                if (!adPlaced)
                {
                    articlesUntilAd -= articles.Count;
                }
            }
        }

        Sections = displaySections;
    }

    private LibraryCardItem Card(Article article) => LibraryCards.Article(article, _state, _navigation);

    protected override void RefreshLocalizedProperties()
    {
        BuildFilters();
        Load();
        Notify(nameof(PageTitle), nameof(SearchPlaceholder));
    }
}
