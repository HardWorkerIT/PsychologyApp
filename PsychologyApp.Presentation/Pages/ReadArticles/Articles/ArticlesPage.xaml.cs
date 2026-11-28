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
    private VkCatalogAdRows? _catalogAds;
#endif

    public ArticlesPage(IArticlesViewModelFactory viewModelFactory)
    {
        InitializeComponent();
        _viewModel = viewModelFactory.Create(this);
#if ANDROID
        _catalogAds = new(_viewModel, nameof(ArticlesViewModel.IsArticleBannerEligible),
            nameof(ArticlesViewModel.IsArticleAdEligible), new Thickness(0, 16, 0, 16));
#endif
        BindingContext = _viewModel;
    }

    // "For you", the read marks and the course progress follow what happened since the tab was last seen.
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

    private void OnArticleAdFooterBindingContextChanged(object? sender, EventArgs e)
    {
#if ANDROID
        if (sender is ContentView row)
        {
            bool? isBanner = row.BindingContext switch
            {
                ArticleSectionItem { HasBannerPlacement: true } => true,
                ArticleSectionItem { HasAdPlacement: true } => false,
                _ => null
            };
            _catalogAds?.BindRow(row, isBanner);
        }
#endif
    }
}
