using PsychologyApp.Presentation.App.Providers;
using PsychologyApp.Presentation.Entities.Test;
using PsychologyApp.Presentation.Features.RunTests.DependencyInjection;
using PsychologyApp.Presentation.Shared.Common;
using System.ComponentModel;

namespace PsychologyApp.Presentation.Pages.RunTests.Question;

public partial class QuestionPage : ContentPage
{
    public QuestionPage(
        IQuestionViewModelFactory questionViewModelFactory,
        List<TestQuestion> questions,
        Func<int, string> analyzer,
        bool singleAnswer,
        TestSessionInfo? session = null)
    {
        BindingContext = questionViewModelFactory.Create(this, questions, analyzer, singleAnswer, session);
        InitializeComponent();
        if (BindingContext is QuestionViewModel viewModel)
        {
            viewModel.ValidationHintRequested += OnValidationHintRequested;
            viewModel.PropertyChanged += OnViewModelPropertyChanged;
        }
    }

    private void OnViewModelPropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(QuestionViewModel.CurrentIndex))
        {
            QuestionScroll.ScrollToAsync(0, 0, animated: false).FireAndForget();
        }
    }

    private void OnValidationHintRequested(object? sender, EventArgs e)
    {
        if (QuestionCard is not null)
        {
            SafeAsync.Run(() => UiAnimations.SafeShakeAsync(QuestionCard));
        }
    }

    protected override bool OnBackButtonPressed()
    {
        if (BindingContext is not QuestionViewModel viewModel)
        {
            return base.OnBackButtonPressed();
        }

        if (viewModel.BackCommand.CanExecute(null))
        {
            viewModel.BackCommand.Execute(null);
        }
        return true;
    }
}
