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
    private VerticalStackLayout? _courseAdFooter;
#endif

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
        ReconnectCourseAdFooter();
#endif
        _viewModel.RefreshAdEligibility();
        _viewModel.RefreshAsync().FireAndForget();
    }

    protected override void OnDisappearing()
    {
#if ANDROID
        DisconnectCourseAdFooter();
#endif
        base.OnDisappearing();
    }

    private void OnCourseAdFooterBindingContextChanged(object? sender, EventArgs e)
    {
#if ANDROID
        if (sender is not VerticalStackLayout footer)
        {
            return;
        }

        if (footer.BindingContext is not CourseSectionItem { HasAdPlacement: true })
        {
            DisconnectCourseAdFooter(footer);
            if (ReferenceEquals(_courseAdFooter, footer))
            {
                _courseAdFooter = null;
            }

            return;
        }

        if (_courseAdFooter is not null && !ReferenceEquals(_courseAdFooter, footer))
        {
            DisconnectCourseAdFooter(_courseAdFooter);
        }

        _courseAdFooter = footer;
        ReconnectCourseAdFooter();
#else
        if (sender is VisualElement footer)
        {
            footer.IsVisible = false;
        }
#endif
    }

#if ANDROID
    private void ReconnectCourseAdFooter()
    {
        if (_courseAdFooter is null)
        {
            return;
        }

        ContentView? host = _courseAdFooter.Children.OfType<ContentView>().FirstOrDefault();
        if (host is null)
        {
            return;
        }

        if (host.Content is not VkBannerView adView)
        {
            adView = new VkBannerView();
            adView.SetBinding(
                VkBannerView.IsEligibleProperty,
                new Binding(nameof(CoursesViewModel.IsCourseAdEligible)) { Source = _viewModel });
            host.Content = adView;
        }

        _courseAdFooter.SetBinding(
            VisualElement.IsVisibleProperty,
            new Binding(nameof(VkBannerView.IsAdLoaded)) { Source = adView });
    }

    private void DisconnectCourseAdFooter() => DisconnectCourseAdFooter(_courseAdFooter);

    private static void DisconnectCourseAdFooter(VerticalStackLayout? footer)
    {
        if (footer is null)
        {
            return;
        }

        ContentView? host = footer.Children.OfType<ContentView>().FirstOrDefault();
        host?.Content?.Handler?.DisconnectHandler();
        if (host is not null)
        {
            host.Content = null;
        }

        footer.RemoveBinding(VisualElement.IsVisibleProperty);
        footer.IsVisible = false;
    }
#endif
}
