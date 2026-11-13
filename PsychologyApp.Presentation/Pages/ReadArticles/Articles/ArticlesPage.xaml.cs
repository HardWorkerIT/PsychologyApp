using PsychologyApp.Presentation.Features.ReadArticles;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
#if ANDROID
using PsychologyApp.Presentation.Platforms.Android;
#endif

namespace PsychologyApp.Presentation.Pages.ReadArticles.Articles;

public partial class ArticlesPage : ContentPage
{
    private readonly ArticlesViewModel _viewModel;

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
        VkBannerView adView = new();
        adView.SetBinding(VkBannerView.IsEligibleProperty, nameof(ArticlesViewModel.IsArticleAdEligible));
        AdHost.Content = adView;
#endif
        _viewModel.RefreshAdEligibility();
        _viewModel.RefreshAsync().FireAndForget();
    }

    protected override void OnDisappearing()
    {
#if ANDROID
        AdHost.Content?.Handler?.DisconnectHandler();
        AdHost.Content = null;
#endif
        base.OnDisappearing();
    }
}
