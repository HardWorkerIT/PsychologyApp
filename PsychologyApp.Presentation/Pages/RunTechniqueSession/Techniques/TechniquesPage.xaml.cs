using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Features.RunTechniqueSession.DependencyInjection;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Pages.RunTechniqueSession.Techniques;
#if ANDROID
using PsychologyApp.Presentation.Platforms.Android;
#endif

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.Techniques;

public partial class TechniquesPage : ContentPage
{
    private TechniquesViewModel? _viewModel;
    private PageAnimationHelper? _animationHelper;

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
        _animationHelper?.TryRevealAsync();
        if (_viewModel is null)
        {
            return;
        }

        _viewModel.RefreshPracticeAdEligibility();
#if ANDROID
        VkBannerView adView = new();
        adView.SetBinding(VkBannerView.IsEligibleProperty, nameof(TechniquesViewModel.IsPracticeAdEligible));
        PracticeAdHost.Content = adView;
        PracticeAdHost.SetBinding(
            VisualElement.IsVisibleProperty,
            new Binding(nameof(VkBannerView.IsAdLoaded)) { Source = adView });
#endif

        _viewModel.RefreshOnAppearAsync().FireAndForget();

        _viewModel.TryOpenPendingTechniqueAsync().FireAndForget();
        _viewModel.TryOpenPendingJournalAsync().FireAndForget();
    }

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
        PracticeAdHost.RemoveBinding(VisualElement.IsVisibleProperty);
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
            _viewModel?.UnsubscribeFromTechniqueChanges();

            _animationHelper?.Dispose();
            _animationHelper = null;
        }
    }
}
