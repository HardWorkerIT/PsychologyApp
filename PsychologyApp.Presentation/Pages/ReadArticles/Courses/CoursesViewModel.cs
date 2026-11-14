using System.Windows.Input;
using PsychologyApp.Application.Articles;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.ViewModels;
using PsychologyApp.Presentation.Widgets.LibraryCard;

namespace PsychologyApp.Presentation.Pages.ReadArticles.Courses;

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
        && AdvertisingConfiguration.CanRequestAds(UserPreferencesStore.Load());

    public IReadOnlyList<LibraryCardItem> CoursesBeforeAd => IsCourseAdEligible
        ? Courses.Take(CoursesBeforeAdCount).ToArray()
        : Courses;

    public IReadOnlyList<LibraryCardItem> CoursesAfterAd => IsCourseAdEligible
        ? Courses.Skip(CoursesBeforeAdCount).ToArray()
        : [];

    public void RefreshAdEligibility()
    {
        OnPropertyChanged(nameof(IsCourseAdEligible));
        OnPropertyChanged(nameof(CoursesBeforeAd));
        OnPropertyChanged(nameof(CoursesAfterAd));
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

            OnPropertyChanged(nameof(IsCourseAdEligible));
            OnPropertyChanged(nameof(CoursesBeforeAd));
            OnPropertyChanged(nameof(CoursesAfterAd));
        }
    }

    /// <summary>Called whenever the page appears: a day closed meanwhile changes a course's progress.</summary>
    public async Task RefreshAsync()
    {
        try
        {
            await _databaseReady.WaitAsync();
            ReadingState state = await _reading.GetAsync();
            await UiThread.RunAsync(() =>
            {
                _state = state;
                Load();
            });
        }
        catch (Exception loadError)
        {
            // The courses are in the app; only their progress is missing.
            BestEffort.Report(loadError);
        }
    }

    private void Load() =>
        Courses = [.. ArticleContent.Courses(AppStrings.Language).Select(course => LibraryCards.Course(course, _state, _navigation))];

    protected override void RefreshLocalizedProperties()
    {
        Load();
        Notify(nameof(PageTitle), nameof(LeadText), nameof(IsCourseAdEligible));
    }
}
