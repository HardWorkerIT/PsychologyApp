using PsychologyApp.Presentation.Features.ReadArticles;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
#if ANDROID
using PsychologyApp.Presentation.Platforms.Android;
#endif

namespace PsychologyApp.Presentation.Pages.ReadArticles.Courses;

public partial class CoursesPage : ContentPage
{
    private readonly CoursesViewModel _viewModel;
#if ANDROID
    private VkCatalogAdRows? _catalogAds;
#endif

    public CoursesPage(ICoursesViewModelFactory viewModelFactory)
    {
        InitializeComponent();
        _viewModel = viewModelFactory.Create(this);
#if ANDROID
        _catalogAds = new(_viewModel, nameof(CoursesViewModel.IsCourseBannerEligible),
            nameof(CoursesViewModel.IsCourseAdEligible), new Thickness(0, 16, 0, 16));
#endif
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
#if ANDROID
        _catalogAds?.SetPageVisible(true);
#endif
        _viewModel.RefreshAdEligibility();
        _viewModel.RefreshAsync().FireAndForget();
    }

    protected override void OnDisappearing()
    {
#if ANDROID
        _catalogAds?.SetPageVisible(false);
#endif
        base.OnDisappearing();
    }

    private void OnCourseAdFooterBindingContextChanged(object? sender, EventArgs e)
    {
#if ANDROID
        if (sender is ContentView row)
        {
            bool? isBanner = row.BindingContext switch
            {
                CourseSectionItem { HasBannerPlacement: true } => true,
                CourseSectionItem { HasAdPlacement: true } => false,
                _ => null
            };
            _catalogAds?.BindRow(row, isBanner);
        }
#endif
    }
}
