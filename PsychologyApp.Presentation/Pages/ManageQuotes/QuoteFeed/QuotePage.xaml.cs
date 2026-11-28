using PsychologyApp.Presentation.Entities.Quote;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Common.Infrastructure;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Features.ManageQuotes;
using PsychologyApp.Presentation.Features.ManageQuotes.DependencyInjection;
using PsychologyApp.Presentation.Pages.ManageQuotes.QuoteFeed;
using System.ComponentModel;
#if ANDROID
using PsychologyApp.Presentation.Platforms.Android;
#endif

namespace PsychologyApp.Presentation.Pages.ManageQuotes.QuoteFeed;

public partial class QuotePage : ContentPage
{
    private QuoteViewModel ViewModel = default!;
    private PageAnimationHelper? _animationHelper;
    private bool _wasSearching;
    private QuoteFeedMode _lastFeedMode;
#if ANDROID
    private VkCatalogAdRows? _catalogAds;
#endif

    public QuotePage(IPageViewModelActivator pageViewModelActivator, IQuoteViewModelFactory quoteViewModelFactory)
    {
        InitializeComponent();
        ViewModel = this.ActivateViewModel(pageViewModelActivator, page => quoteViewModelFactory.Create(page));
#if ANDROID
        _catalogAds = new(ViewModel, nameof(QuoteViewModel.IsQuoteBannerEligible),
            nameof(QuoteViewModel.IsQuoteAdEligible), new Thickness(0, 8, 0, 8));
#endif
        _animationHelper = new PageAnimationHelper(ViewModel, LoadingProgress, QuotesCollectionView);
        ViewModel.PropertyChanged += OnViewModelPropertyChanged;
        _wasSearching = ViewModel.IsSearching;
        _lastFeedMode = ViewModel.FeedMode;
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName is nameof(QuoteViewModel.IsDone)
            or nameof(QuoteViewModel.FeedMode)
            or nameof(QuoteViewModel.IsSearching)
            or nameof(QuoteViewModel.ShowAllReadEmpty))
        {
            ViewModel.RefreshQuoteAdEligibility();
        }

        if (e.PropertyName == nameof(QuoteViewModel.FeedMode) && ViewModel.FeedMode != _lastFeedMode)
        {
            _lastFeedMode = ViewModel.FeedMode;
            UiStateAnimator.CrossfadeContentRefreshAsync(QuotesCollectionView).FireAndForget();
        }

        if (e.PropertyName == nameof(QuoteViewModel.IsSearching) && ViewModel.IsSearching != _wasSearching)
        {
            AnimateSearchModeCrossfadeAsync().FireAndForget();
            _wasSearching = ViewModel.IsSearching;
        }

        if (e.PropertyName == nameof(QuoteViewModel.IsSearchFilteringVisible))
        {
            UiStateAnimator.AnimateVisibilityAsync(SearchFilteringProgress, ViewModel.IsSearchFilteringVisible).FireAndForget();
        }
    }

    private async Task AnimateSearchModeCrossfadeAsync()
    {
        if (ViewModel.IsSearching)
        {
            if (FeedFilterBar.IsVisible)
            {
                await UiAnimations.SafeHideAsync(FeedFilterBar);
            }

            return;
        }

        FeedFilterBar.IsVisible = true;
        await UiAnimations.SafeRevealLiteAsync(
            FeedFilterBar,
            UiAnimations.TabReappearSlideOffset,
            allowHidden: true);
    }

    private void OnRemainingItemsThresholdReached(object? sender, EventArgs e)
    {
        if (!ViewModel.IsDone || ViewModel.IsInit || ViewModel.IsSearching)
        {
            return;
        }

        ViewModel.LoadMoreQuotesCommand.Execute(null);
    }

    private void OnPullToRefresh(object? sender, EventArgs e) =>
        HandlePullToRefreshAsync().FireAndForget();

    private async Task HandlePullToRefreshAsync()
    {
        try
        {
            await ViewModel.ReloadFromPullAsync();
        }
        finally
        {
            QuotesRefresh.IsRefreshing = false;
        }
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
#if ANDROID
        _catalogAds?.SetPageVisible(true);
#endif
        ViewModel.RefreshQuoteAdEligibility();
        HandleOnAppearingAsync().FireAndForget();
    }

    protected override void OnDisappearing()
    {
#if ANDROID
        _catalogAds?.SetPageVisible(false);
#endif
        base.OnDisappearing();
    }

    private void OnQuoteAdRowBindingContextChanged(object? sender, EventArgs e)
    {
#if ANDROID
        if (sender is ContentView row)
        {
            bool? isBanner = row.BindingContext switch
            {
                QuoteFeedDisplayItem { IsBannerPlacement: true } => true,
                QuoteFeedDisplayItem { IsAdPlacement: true } => false,
                _ => null
            };
            _catalogAds?.BindRow(row, isBanner);
        }
#endif
    }

    private async Task HandleOnAppearingAsync()
    {
        _animationHelper?.TryRevealAsync();
        await ViewModel.EnsureInitializedAsync();
        await ViewModel.TryApplyPendingFeedAsync();
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        if (Handler is null)
        {
            ViewModel.PropertyChanged -= OnViewModelPropertyChanged;
            _animationHelper?.Dispose();
            _animationHelper = null;
        }
    }
}
