using Microsoft.Extensions.Logging;
using PsychologyApp.Presentation.Features.RunTests;
using PsychologyApp.Presentation.Shared.Common;

namespace PsychologyApp.Presentation.Pages.RunTests.Question;

public partial class QuestionViewModel
{
    private bool _isCompleting;
    private bool _resultOpened;
    private QuestionnaireSavedResult? _savedResult;
    private bool _resultNavigationFailed;

    public bool ResultNavigationFailed
    {
        get => _resultNavigationFailed;
        private set => SetProperty(ref _resultNavigationFailed, value);
    }

    public string ResultNavigationFailedText => AppStrings.TestsResultNavigationFailedMessage;

    private async Task CalculateAnswersAsync()
    {
        if (_isCompleting || _resultOpened)
        {
            return;
        }

        if (_savedResult is null && !_submissionService.TryValidateAllAnswered(Questions))
        {
            _toastService.LongToast(AppStrings.TestsAnswerAllToast);
            return;
        }

        if (_session is null)
        {
            return;
        }

        _isCompleting = true;
        _wizard.CancelAutoAdvance();
        NotifyCompletionState();
        try
        {
            QuestionnaireCompletionRequest request =
                new(Questions, _session, _startedAtUtc);

            _savedResult ??= await _runCoordinator.SaveQuestionnaireAsync(
                request,
                _userProgressService,
                openHelpOnSaveFailure: _navigationService.GoToCrisisHubAsync);
            NotifyCompletionState();

            await UiThread.RunAsync(async () =>
            {
                await _runCoordinator.NavigateQuestionnaireResultAsync(
                    _savedResult,
                    _navigationService);
            });

            _resultOpened = true;
            ResultNavigationFailed = false;
        }
        catch (Exception ex) when (_savedResult is not null)
        {
            ResultNavigationFailed = true;
            _logger.LogWarning(ex, "Questionnaire result saved but navigation to result screen failed for {TestId}.", _session.TestId);
            _toastService.LongToast(AppStrings.TestsResultNavigationFailedMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to complete questionnaire for {TestId}.", _session.TestId);
            _toastService.LongToast(AppStrings.TestsResultSaveFailedMessage);
        }
        finally
        {
            _isCompleting = false;
            NotifyCompletionState();
        }
    }

    private void NotifyCompletionState()
    {
        Notify(nameof(CanEditAnswers), nameof(CanAdvance), nameof(IsPreviousVisible),
            nameof(NextButtonText), nameof(NextButtonColumn), nameof(NextButtonColumnSpan));
        _nextCommand.RaiseCanExecuteChanged();
    }
}
