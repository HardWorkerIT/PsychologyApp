using PsychologyApp.Presentation.Features.ReadArticles;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
#if ANDROID
using PsychologyApp.Presentation.Platforms.Android;
#endif

namespace PsychologyApp.Presentation.Pages.ReadArticles.Articles;

public partial class ArticlesPage : ContentPage
{
    private readonly ArticlesViewModel _viewModel;
#if ANDROID
    internal bool IsBrowsingGeneralCatalog => _viewModel.IsBrowsingGeneralCatalog;
    private VerticalStackLayout? _articleAdFooter;
    private bool _catalogVisible;
#endif

    public ArticlesPage(IArticlesViewModelFactory viewModelFactory)
    {
        InitializeComponent();
        _viewModel = viewModelFactory.Create(this);
        BindingContext = _viewModel;
    }

    // "For you", the read marks and the course progress follow what happened since the tab was last seen.
    protected override void OnAppearing()
    {
        base.OnAppearing();
#if ANDROID
        _catalogVisible = true;
        ReconnectArticleAdFooter();
#endif
        _viewModel.RefreshAdEligibility();
        _viewModel.RefreshAsync().FireAndForget();
    }

    protected override void OnDisappearing()
    {
#if ANDROID
        _catalogVisible = false;
        DisconnectArticleAdFooter();
#endif
        base.OnDisappearing();
    }

    private void OnArticleAdFooterBindingContextChanged(object? sender, EventArgs e)
    {
#if ANDROID
        if (sender is not VerticalStackLayout footer)
        {
            return;
        }

        if (footer.BindingContext is not ArticleSectionItem { HasAdPlacement: true })
        {
            DisconnectArticleAdFooter(footer);
            if (ReferenceEquals(_articleAdFooter, footer))
            {
                _articleAdFooter = null;
            }

            return;
        }

        if (_articleAdFooter is not null && !ReferenceEquals(_articleAdFooter, footer))
        {
            DisconnectArticleAdFooter(_articleAdFooter);
        }

        _articleAdFooter = footer;
        ReconnectArticleAdFooter();
#else
        if (sender is VisualElement footer)
        {
            footer.IsVisible = false;
        }
#endif
    }

#if ANDROID
    private void ReconnectArticleAdFooter()
    {
        if (!_catalogVisible || _articleAdFooter is null)
        {
            return;
        }

        ContentView? host = _articleAdFooter.Children.OfType<ContentView>().FirstOrDefault();
        if (host is null)
        {
            return;
        }

        if (host.Content is not VkNativeView adView)
        {
            adView = new VkNativeView();
            adView.SetBinding(
                VkNativeView.IsEligibleProperty,
                new Binding(nameof(ArticlesViewModel.IsArticleAdEligible)) { Source = _viewModel });
            host.Content = adView;
        }

        _articleAdFooter.SetBinding(
            VisualElement.IsVisibleProperty,
            new Binding(nameof(VkNativeView.IsAdLoaded)) { Source = adView });
    }

    private void DisconnectArticleAdFooter() => DisconnectArticleAdFooter(_articleAdFooter);

    private static void DisconnectArticleAdFooter(VerticalStackLayout? footer)
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
