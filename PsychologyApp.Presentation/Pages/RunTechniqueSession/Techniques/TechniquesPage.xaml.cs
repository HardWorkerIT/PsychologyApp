using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Features.RunTechniqueSession.DependencyInjection;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Pages.RunTechniqueSession.Techniques;
using PsychologyApp.Presentation.Entities.Technique;
#if ANDROID
using PsychologyApp.Presentation.Platforms.Android;
#endif

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.Techniques;

public partial class TechniquesPage : ContentPage
{
    private TechniquesViewModel? _viewModel;
    private PageAnimationHelper? _animationHelper;
#if ANDROID
    private VerticalStackLayout? _practiceBannerFooter;
    private bool _catalogVisible;
#endif

    public TechniquesPage(
        IPageViewModelActivator pageViewModelActivator,
        ITechniquesViewModelFactory techniquesViewModelFactory)
    {
        InitializeComponent();
        _viewModel = this.ActivateViewModel(pageViewModelActivator, page => techniquesViewModelFactory.Create(page));
        _animationHelper = new PageAnimationHelper(_viewModel, LoadingProgress, TechniquesCollectionView);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
#if ANDROID
        _catalogVisible = true;
#endif
        _animationHelper?.TryRevealAsync();
        if (_viewModel is null)
        {
            return;
        }

        _viewModel.SubscribeToTechniqueChanges();
        _viewModel.RefreshPracticeAdEligibility();
#if ANDROID
        ReconnectPracticeBannerFooter();
        VkNativeView native = new();
        native.SetBinding(VkNativeView.IsEligibleProperty, nameof(TechniquesViewModel.IsPracticeAdEligible));
        native.PropertyChanged += (_, args) =>
        {
            if (args.PropertyName == nameof(VkNativeView.IsAdLoaded)) PracticeAdHost.IsVisible = native.IsAdLoaded;
        };
        PracticeAdHost.Content = native;
        PracticeAdHost.IsVisible = false;
#endif

        _viewModel.RefreshOnAppearAsync().FireAndForget();

        _viewModel.TryOpenPendingTechniqueAsync().FireAndForget();
        _viewModel.TryOpenPendingJournalAsync().FireAndForget();
    }

    private void OnPracticeBannerFooterReady(object? sender, EventArgs e)
    {
#if ANDROID
        if (sender is not VerticalStackLayout footer || footer.BindingContext is not TechniqueGroup { Key: "Body", Count: > 0 })
        {
            if (sender is VerticalStackLayout unused && unused.Children.OfType<ContentView>().FirstOrDefault() is { } unusedHost)
            {
                unusedHost.Content?.Handler?.DisconnectHandler();
                unusedHost.Content = null;
                unused.IsVisible = false;
            }
            if (ReferenceEquals(_practiceBannerFooter, sender))
            {
                _practiceBannerFooter = null;
            }
            return;
        }

        if (!ReferenceEquals(_practiceBannerFooter, footer))
        {
            DisconnectPracticeBannerFooter();
            _practiceBannerFooter = footer;
        }
        ReconnectPracticeBannerFooter();
#endif
    }

#if ANDROID
    private void ReconnectPracticeBannerFooter()
    {
        if (!_catalogVisible || _viewModel is null || _practiceBannerFooter is not { } footer)
        {
            return;
        }

        ContentView? host = footer.Children.OfType<ContentView>().FirstOrDefault();
        if (host is null || host.Content is VkBannerView)
        {
            return;
        }

        host.Content?.Handler?.DisconnectHandler();
        host.Content = null;
        VkBannerView banner = new();
        banner.SetBinding(VkBannerView.IsEligibleProperty,
            new Binding(nameof(TechniquesViewModel.IsPracticeBannerEligible)) { Source = _viewModel });
        banner.AdLoadedChanged += (_, _) => footer.IsVisible = banner.IsAdLoaded;
        host.Content = banner;
        footer.IsVisible = banner.IsAdLoaded;
    }

    private void DisconnectPracticeBannerFooter()
    {
        VerticalStackLayout? footer = _practiceBannerFooter;
        ContentView? host = footer?.Children.OfType<ContentView>().FirstOrDefault();
        host?.Content?.Handler?.DisconnectHandler();
        if (host is not null)
        {
            host.Content = null;
        }
        if (footer is not null)
        {
            footer.IsVisible = false;
        }
    }
#endif

    private void OnRemainingItemsThresholdReached(object? sender, EventArgs e)
    {
        if (_viewModel is null)
        {
            return;
        }

        _viewModel.LoadMoreCustomTechniquesCommand.Execute(null);
    }

    protected override void OnDisappearing()
    {
#if ANDROID
        _catalogVisible = false;
        DisconnectPracticeBannerFooter();
        PracticeAdHost.IsVisible = false;
        PracticeAdHost.Content?.Handler?.DisconnectHandler();
        PracticeAdHost.Content = null;
#endif
        base.OnDisappearing();
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        if (Handler is null)
        {
#if ANDROID
            _catalogVisible = false;
            DisconnectPracticeBannerFooter();
            _practiceBannerFooter = null;
#endif
            _viewModel?.UnsubscribeFromTechniqueChanges();

            _animationHelper?.Dispose();
            _animationHelper = null;
        }
    }
}
