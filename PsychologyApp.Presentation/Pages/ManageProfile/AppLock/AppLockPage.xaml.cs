using System.ComponentModel;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Pages.ManageProfile.AppLock;

public partial class AppLockPage : ContentPage
{
    private readonly AppLockViewModel _viewModel;
    private bool _initialized;
    private bool _pinPulseInProgress;
    private int _lastPinLength;
    private IDispatcherTimer? _pinCooldownTimer;

    public AppLockPage(AppLockViewModel viewModel)
    {
        _viewModel = viewModel;
        BindingContext = viewModel;
        InitializeComponent();
    }

    public Task Unlocked => _viewModel.Unlocked;

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _viewModel.PropertyChanged -= OnViewModelPropertyChanged;
        _viewModel.PropertyChanged += OnViewModelPropertyChanged;
        _viewModel.RefreshPinCooldown();
        UpdateCooldownTimer();
        if (_initialized)
        {
            return;
        }

        _initialized = true;
        SafeAsync.Run(_viewModel.InitializeAsync);
    }

    protected override void OnDisappearing()
    {
        _viewModel.PropertyChanged -= OnViewModelPropertyChanged;
        _pinCooldownTimer?.Stop();
        base.OnDisappearing();
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(AppLockViewModel.IsPinCoolingDown))
        {
            UpdateCooldownTimer();
            return;
        }

        if (e.PropertyName == nameof(AppLockViewModel.PinInput))
        {
            int length = _viewModel.PinInput.Length;
            if (length > _lastPinLength && !_pinPulseInProgress)
            {
                PulsePinCellsAsync().FireAndForget();
            }

            _lastPinLength = length;
            return;
        }

        if (e.PropertyName == nameof(AppLockViewModel.StatusText)
            && _viewModel.HasStatus
            && !_viewModel.IsPinCoolingDown
            && _viewModel.IsPinEntryVisible)
        {
            UiAnimations.SafeShakeAsync(PinEntryPanel).FireAndForget();
        }
    }

    private void UpdateCooldownTimer()
    {
        if (!_viewModel.IsPinCoolingDown)
        {
            _pinCooldownTimer?.Stop();
            return;
        }

        if (_pinCooldownTimer is null)
        {
            _pinCooldownTimer = Dispatcher.CreateTimer();
            _pinCooldownTimer.Interval = TimeSpan.FromSeconds(1);
            _pinCooldownTimer.Tick += (_, _) => _viewModel.RefreshPinCooldown();
        }

        _pinCooldownTimer.Start();
    }

    private async Task PulsePinCellsAsync()
    {
        _pinPulseInProgress = true;
        try
        {
            await UiAnimations.SafePulseAsync(PinCellsLayout);
        }
        finally
        {
            _pinPulseInProgress = false;
        }
    }

    // Back must not step past the lock into the app. Doing nothing would look like a frozen app, so it leaves to the home
    // screen, as the phone's own lock screens do.
    protected override bool OnBackButtonPressed()
    {
#if ANDROID
        Platform.CurrentActivity?.MoveTaskToBack(true);
#endif
        return true;
    }
}
