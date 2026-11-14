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
    private VerticalStackLayout? _quoteAdRow;
#endif

    public QuotePage(IPageViewModelActivator pageViewModelActivator, IQuoteViewModelFactory quoteViewModelFactory)
    {
        InitializeComponent();
        ViewModel = this.ActivateViewModel(pageViewModelActivator, page => quoteViewModelFactory.Create(page));
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
        ReconnectQuoteAdRow();
#endif
        ViewModel.RefreshQuoteAdEligibility();
        HandleOnAppearingAsync().FireAndForget();
    }

    protected override void OnDisappearing()
    {
#if ANDROID
        DisconnectQuoteAdRow();
#endif
        base.OnDisappearing();
    }

    private void OnQuoteAdRowBindingContextChanged(object? sender, EventArgs e)
    {
#if ANDROID
        if (sender is not VerticalStackLayout row)
        {
            return;
        }

        if (row.BindingContext is not QuoteFeedDisplayItem { IsAdPlacement: true })
        {
            DisconnectQuoteAdRow(row);
            if (ReferenceEquals(_quoteAdRow, row))
            {
                _quoteAdRow = null;
            }

            return;
        }

        if (_quoteAdRow is not null && !ReferenceEquals(_quoteAdRow, row))
        {
            DisconnectQuoteAdRow(_quoteAdRow);
        }

        _quoteAdRow = row;
        ReconnectQuoteAdRow();
#else
        if (sender is VisualElement footer)
        {
            footer.IsVisible = false;
        }
#endif
    }

#if ANDROID
    private void ReconnectQuoteAdRow()
    {
        if (_quoteAdRow is null)
        {
            return;
        }

        ContentView? host = _quoteAdRow.Children.OfType<ContentView>().FirstOrDefault();
        if (host is null)
        {
            return;
        }

        if (host.Content is not VkBannerView adView)
        {
            adView = new VkBannerView();
            adView.SetBinding(
                VkBannerView.IsEligibleProperty,
                new Binding(nameof(QuoteViewModel.IsQuoteAdEligible)) { Source = ViewModel });
            host.Content = adView;
        }

        _quoteAdRow.SetBinding(
            VisualElement.IsVisibleProperty,
            new Binding(nameof(VkBannerView.IsAdLoaded)) { Source = adView });
    }

    private void DisconnectQuoteAdRow() => DisconnectQuoteAdRow(_quoteAdRow);

    private static void DisconnectQuoteAdRow(VerticalStackLayout? row)
    {
        if (row is null)
        {
            return;
        }

        ContentView? host = row.Children.OfType<ContentView>().FirstOrDefault();
        host?.Content?.Handler?.DisconnectHandler();
        if (host is not null)
        {
            host.Content = null;
        }

        row.RemoveBinding(VisualElement.IsVisibleProperty);
        row.IsVisible = false;
    }
#endif

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
