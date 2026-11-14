using PsychologyApp.Presentation.Features.ReadArticles;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
#if ANDROID
using PsychologyApp.Presentation.Platforms.Android;
#endif

namespace PsychologyApp.Presentation.Pages.ReadArticles.Courses;

public partial class CoursesPage : ContentPage
{
    private readonly CoursesViewModel _viewModel;

    public CoursesPage(ICoursesViewModelFactory viewModelFactory)
    {
        InitializeComponent();
        _viewModel = viewModelFactory.Create(this);
        BindingContext = _viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
#if ANDROID
        VkBannerView adView = new();
        adView.SetBinding(VkBannerView.IsEligibleProperty, nameof(CoursesViewModel.IsCourseAdEligible));
        AdHost.Content = adView;
        AdHost.SetBinding(VisualElement.IsVisibleProperty, new Binding(nameof(VkBannerView.IsAdLoaded)) { Source = adView });
#endif
        _viewModel.RefreshAdEligibility();
        _viewModel.RefreshAsync().FireAndForget();
    }

    protected override void OnDisappearing()
    {
#if ANDROID
        AdHost.RemoveBinding(VisualElement.IsVisibleProperty);
        AdHost.IsVisible = false;
        AdHost.Content?.Handler?.DisconnectHandler();
        AdHost.Content = null;
#endif
        base.OnDisappearing();
    }
}
