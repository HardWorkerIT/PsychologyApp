using System.ComponentModel;
using PsychologyApp.Presentation.App.Providers;
using PsychologyApp.Presentation.Features.RunTechniqueSession.DependencyInjection;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Navigation;

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.PracticeCompletion;

public partial class PracticeCompletionPage : ContentPage
{
    private PracticeCompletionViewModel? _viewModel;
    private readonly KeyboardResize _keyboard = new();
    private bool _motionSynced;
    private bool _hadMoodDelta;

    public PracticeCompletionPage(
        IPracticeCompletionViewModelFactory factory,
        int activeDays,
        string? completedItemKey = null,
        long? sessionResultId = null)
    {
        _viewModel = factory.Create(this, activeDays, completedItemKey, sessionResultId);
        BindingContext = _viewModel;
        InitializeComponent();
        _viewModel.PropertyChanged += OnViewModelPropertyChanged;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        _keyboard.Enable();
        if (_viewModel is null)
        {
            return;
        }

        if (!_motionSynced)
        {
            MoodDeltaLabel.IsVisible = _viewModel.HasMoodDelta;
            _motionSynced = true;
            _hadMoodDelta = _viewModel.HasMoodDelta;
        }
    }

    protected override void OnDisappearing()
    {
        _keyboard.Restore();
        base.OnDisappearing();
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (_viewModel is null || !_motionSynced)
        {
            return;
        }

        if (e.PropertyName is nameof(PracticeCompletionViewModel.HasMoodDelta)
            or nameof(PracticeCompletionViewModel.SelectedMoodLevel)
            or nameof(PracticeCompletionViewModel.BeforeMoodLevel))
        {
            HandleMoodDeltaMotionAsync().FireAndForget();
        }
    }

    private async Task HandleMoodDeltaMotionAsync()
    {
        if (_viewModel is null)
        {
            return;
        }

        bool hasMoodDelta = _viewModel.HasMoodDelta;
        await UiStateAnimator.AnimateVisibilityAsync(MoodDeltaLabel, hasMoodDelta);

        if (hasMoodDelta && !_hadMoodDelta
            && _viewModel.SelectedMoodLevel > _viewModel.BeforeMoodLevel)
        {
            await UiAnimations.SafePulseAsync(MoodDeltaLabel);
        }

        _hadMoodDelta = hasMoodDelta;
    }

    protected override bool OnBackButtonPressed()
    {
        if (_viewModel is null)
        {
            return base.OnBackButtonPressed();
        }

        if (_viewModel.FinishCommand.CanExecute(null))
        {
            _viewModel.FinishCommand.Execute(null);
        }

        return true;
    }

    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        if (Handler is null && _viewModel is not null)
        {
            _viewModel.PropertyChanged -= OnViewModelPropertyChanged;
            _viewModel = null;
        }
    }
}
