using System.Windows.Input;
using PsychologyApp.Application.Articles;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.ViewModels;
using PsychologyApp.Presentation.Widgets.LibraryCard;

namespace PsychologyApp.Presentation.Pages.ReadArticles.Courses;

/// <summary>One virtualized course section, with an optional ad slot after it.</summary>
public sealed class CourseSectionItem(IEnumerable<LibraryCardItem> courses, bool hasAdPlacement = false) : List<LibraryCardItem>(courses)
{
    public bool HasAdPlacement { get; } = hasAdPlacement;
}

/// <summary>The "Courses" top tab of the Library: what guided self-help is, and the courses with their progress.</summary>
public sealed class CoursesViewModel : BaseViewModel
{
    private const int CoursesBeforeAdCount = 3;

    /// <summary>The same back arrow as on every other pushed page (the page hides the system bar).</summary>
    public ICommand BackCommand { get; }

    private readonly INavigationService _navigation;
    private readonly IReadingService _reading;
    private readonly IDatabaseReadySignal _databaseReady;
    private ReadingState _state = new();
    private IReadOnlyList<LibraryCardItem> _courses = [];
    private IReadOnlyList<CourseSectionItem> _sections = [];

    public CoursesViewModel(INavigationService navigation, IReadingService reading, IDatabaseReadySignal databaseReady)
    {
        BindNavigation(navigation);
        BackCommand = new AsyncCommand(GoBackAsync);
        _navigation = navigation;
        _reading = reading;
        _databaseReady = databaseReady;
        Load();
    }

    public string PageTitle => AppStrings.ArticlesCourses;
    public string LeadText => AppStrings.ArticlesCoursesLead;
    public bool IsCourseAdEligible => OperatingSystem.IsAndroid()
        && Courses.Count >= CoursesBeforeAdCount + 2
        && AdvertisingConfiguration.CanRequestNativeAd(UserPreferencesStore.Load());

    public IReadOnlyList<CourseSectionItem> Sections
    {
        get => _sections;
        private set => SetProperty(ref _sections, value);
    }

    public void RefreshAdEligibility()
    {
        bool showAd = IsCourseAdEligible;
        if (showAd != (Sections.Count > 0 && Sections[0].HasAdPlacement))
        {
            UpdateSections(showAd);
        }

        OnPropertyChanged(nameof(IsCourseAdEligible));
    }

    public IReadOnlyList<LibraryCardItem> Courses
    {
        get => _courses;
        private set
        {
            if (!SetProperty(ref _courses, value))
            {
                return;
            }

            UpdateSections(IsCourseAdEligible);
            OnPropertyChanged(nameof(IsCourseAdEligible));
        }
    }

    /// <summary>Called whenever a day closed meanwhile changes a course's progress.</summary>
    public async Task RefreshAsync()
    {
        try
        {
            await _databaseReady.WaitAsync();
            ReadingState state = await _reading.GetAsync();
            await UiThread.RunAsync(() =>
            {
                IReadOnlyList<Course> catalog = ArticleContent.Courses(AppStrings.Language);
                bool progressChanged = HasVisibleProgressChanged(catalog, _state, state);
                _state = state;
                if (progressChanged)
                {
                    Load(catalog);
                }
            });
        }
        catch (Exception loadError)
        {
            // The courses are in the app; only their progress is missing.
            BestEffort.Report(loadError);
        }
    }

    private static bool HasVisibleProgressChanged(IReadOnlyList<Course> catalog, ReadingState previous, ReadingState current)
    {
        if (ReferenceEquals(previous.Courses, current.Courses))
        {
            return false;
        }

        // The card displays whether a course was started or finished and how many days are complete.
        foreach (Course course in catalog)
        {
            CourseProgress? before = previous.Course(course.Id);
            CourseProgress? after = current.Course(course.Id);
            bool wasFinished = before?.FinishedUtc is not null;
            bool isFinished = after?.FinishedUtc is not null;
            if (wasFinished != isFinished || (!isFinished && before?.Days.Count != after?.Days.Count))
            {
                return true;
            }
        }

        return false;
    }

    private void UpdateSections(bool showAd) => Sections = showAd
        ? [new(Courses.Take(CoursesBeforeAdCount), hasAdPlacement: true), new(Courses.Skip(CoursesBeforeAdCount))]
        : [new(Courses)];

    private void Load() => Load(ArticleContent.Courses(AppStrings.Language));

    private void Load(IReadOnlyList<Course> catalog) =>
        Courses = [.. catalog.Select(course => LibraryCards.Course(course, _state, _navigation))];

    protected override void RefreshLocalizedProperties()
    {
        Load();
        Notify(nameof(PageTitle), nameof(LeadText), nameof(IsCourseAdEligible));
    }
}
