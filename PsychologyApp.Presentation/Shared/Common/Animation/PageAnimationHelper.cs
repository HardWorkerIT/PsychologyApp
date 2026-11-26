using System.ComponentModel;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.ViewModels;

namespace PsychologyApp.Presentation.Shared.Common;

public sealed class PageAnimationHelper : IDisposable
{
    private readonly BaseViewModel? _viewModel;
    private readonly VisualElement? _loadingView;
    private readonly VisualElement? _contentView;
    private readonly VisualElement? _introView;
    private readonly Layout? _staggerLayout;
    private CancellationTokenSource? _cts;
    private bool _contentRevealed;
    private bool _introDismissed;
    private bool _disposed;

    public PageAnimationHelper(
        BaseViewModel? viewModel,
        VisualElement? loadingView = null,
        VisualElement? contentView = null,
        Layout? staggerLayout = null,
        VisualElement? introView = null)
    {
        _viewModel = viewModel;
        _loadingView = loadingView;
        _contentView = contentView;
        _staggerLayout = staggerLayout;
        _introView = introView;

        if (_viewModel is not null)
        {
            _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
    }

    public void TryRevealAsync() => ScheduleAnimation(HandleLoadingStateAsync);

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName is nameof(BaseViewModel.IsDone)
            or nameof(BaseViewModel.IsInit))
        {
            ScheduleAnimation(HandleLoadingStateAsync);
        }
    }

    private void ScheduleAnimation(Func<Task> animation)
    {
        VisualElement? anchor = _contentView ?? _loadingView ?? _introView ?? _staggerLayout;
        if (anchor?.Dispatcher is null)
        {
            animation().FireAndForget();
            return;
        }

        anchor.Dispatcher.DispatchAsync(async () =>
        {
            if (!UiAnimations.CanAnimate(anchor) && anchor.Window is null)
            {
                await Task.Yield();
            }

            await animation();
        }).FireAndForget();
    }

    private async Task HandleLoadingStateAsync()
    {
        if (_disposed || _viewModel is null)
        {
            return;
        }

        if (_viewModel.IsInit)
        {
            if (_contentRevealed)
            {
                _cts?.Cancel();
                _contentRevealed = false;
            }

            if (_introView is not null && !_introDismissed && _introView.IsVisible)
            {
                _introDismissed = true;
                await UiAnimations.SafeHideAsync(_introView, cancellationToken: ResetCancellation());
            }
            else
            {
                UiAnimations.ResetVisualState(_contentView);
            }

            return;
        }

        if (_viewModel.IsDone && !_contentRevealed)
        {
            CancellationToken cancellationToken = ResetCancellation();
            _contentRevealed = true;

            if (_contentView is not null && _contentView.IsVisible && !ShouldSkipContentReveal(_contentView))
            {
                await UiAnimations.SafeRevealPremiumAsync(_contentView, cancellationToken: cancellationToken);
            }

            if (!cancellationToken.IsCancellationRequested && _staggerLayout is not null && _staggerLayout.IsVisible)
            {
                await UiAnimations.RevealChildrenStaggeredAsync(_staggerLayout, cancellationToken: cancellationToken);
            }
        }
    }

    internal static bool ShouldSkipContentReveal(VisualElement contentView) =>
        contentView is CollectionView or ItemsView;

    private CancellationToken ResetCancellation()
    {
        _cts?.Cancel();
        _cts?.Dispose();
        _cts = new CancellationTokenSource();
        return _cts.Token;
    }

    public void Dispose()
    {
        _disposed = true;
        if (_viewModel is not null)
        {
            _viewModel.PropertyChanged -= OnViewModelPropertyChanged;
        }

        _cts?.Cancel();
        _cts?.Dispose();
        _cts = null;
        UiAnimations.ResetVisualState(_contentView);
    }
}
