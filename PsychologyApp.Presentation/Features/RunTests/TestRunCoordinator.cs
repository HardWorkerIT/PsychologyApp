using PsychologyApp.Application.ClinicalCare;
using PsychologyApp.Application.Models;
using PsychologyApp.Application.Models.Tests;
using PsychologyApp.Application.UserProgress;
using PsychologyApp.Presentation.Entities.Test;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Navigation;

namespace PsychologyApp.Presentation.Features.RunTests;

public sealed record QuestionnaireCompletionRequest(
    IEnumerable<Question> Questions,
    TestSessionInfo Session,
    DateTime StartedAtUtc);

public sealed record QuestionnaireSavedResult(
    QuestionnaireSubmission Submission,
    QuestionnaireResultDetail? Detail,
    QuestionnaireCompletionRequest Request);

public sealed class TestRunCoordinator(
    QuestionnaireSubmissionService submissionService,
    QuestionnaireDetailBuilder detailBuilder,
    IClinicalCareService? clinicalCareService = null)
{
    public Task StartAsync(TestDefinition definition, INavigationService navigationService) =>
        definition.Kind switch
        {
            TestKind.LuscherStandard => navigationService.GoToStandardTestAsync(),
            TestKind.LuscherBrief => navigationService.GoToAlternativeTestAsync(),
            TestKind.Questionnaire => StartQuestionnaireAsync(definition, navigationService),
            _ => Task.CompletedTask
        };

    public async Task RetakeAsync(
        string testId,
        ITestCatalogService testCatalogService,
        INavigationService navigationService,
        CancellationToken cancellationToken = default)
    {
        TestDefinition? definition = await testCatalogService.GetByIdAsync(testId, cancellationToken);
        if (definition is null)
        {
            return;
        }

        await navigationService.GoToRootAsync();
        await StartAsync(definition, navigationService);
    }

    public async Task CompleteQuestionnaireAsync(
        QuestionnaireCompletionRequest request,
        IUserProgressService userProgressService,
        INavigationService navigationService,
        CancellationToken cancellationToken = default)
    {
        QuestionnaireSavedResult saved = await SaveQuestionnaireAsync(
            request,
            userProgressService,
            cancellationToken,
            openHelpOnSaveFailure: navigationService.GoToCrisisHubAsync);

        await NavigateQuestionnaireResultAsync(saved, navigationService, cancellationToken);
    }

    public async Task<QuestionnaireSavedResult> SaveQuestionnaireAsync(
        QuestionnaireCompletionRequest request,
        IUserProgressService userProgressService,
        CancellationToken cancellationToken = default,
        Func<Task>? openHelpOnSaveFailure = null)
    {
        QuestionnaireSubmission submission = submissionService.Calculate(
            request.Questions,
            request.Session.AnalyzerId);

        QuestionnaireResultDetail? detail;
        try
        {
            detail = await detailBuilder.BuildAsync(request.Questions, request.Session, request.StartedAtUtc, cancellationToken);
            await submissionService.SaveAsync(userProgressService, request.Session, submission.Score, submission.Interpretation,
                cancellationToken, detailBuilder.Serialize(detail));
        }
        catch when (submission.SelfHarmItemEndorsed && openHelpOnSaveFailure is not null)
        {
            try
            {
                await openHelpOnSaveFailure();
            }
            catch (Exception error)
            {
                BestEffort.Report(error);
            }

            throw;
        }

        // An answer other than "never" to the question about suicidal thoughts is a risk signal in its own right, whatever the total:
        // it is recorded exactly like the risk check, so the startup gate and the dashboard treat it the same way.
        if (submission.SelfHarmItemEndorsed && clinicalCareService is not null)
        {
            // The result is already saved at this point, so a failure to record the risk must not fail the whole completion
            // (a retry would save the result twice); the crisis screen still opens below.
            try
            {
                await clinicalCareService.AssessRiskAsync(
                    new RiskAssessmentInput { HasSelfHarmThoughts = true, Source = $"test:{request.Session.AnalyzerId}" },
                    cancellationToken);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Trace.TraceError($"Could not record the risk signal from a questionnaire ({ex.GetType().Name}).");
            }
        }

        return new QuestionnaireSavedResult(submission, detail, request);
    }

    public async Task NavigateQuestionnaireResultAsync(
        QuestionnaireSavedResult saved,
        INavigationService navigationService,
        CancellationToken cancellationToken = default)
    {
        QuestionnaireSubmission submission = saved.Submission;
        QuestionnaireCompletionRequest request = saved.Request;
        TestResultInfo result = new()
        {
            Score = submission.Score,
            Interpretation = submission.Interpretation,
            InterpretationDetail = submission.InterpretationDetail,
            AnalyzerId = request.Session.AnalyzerId,
            RecommendedTechnique = submission.SelfHarmItemEndorsed ? null : submission.RecommendedTechnique,
            TestId = request.Session.TestId,
            Detail = saved.Detail,
            NeedsUrgentHelp = submission.SelfHarmItemEndorsed
        };

        try
        {
            bool completed = await NavigationRetry.TryExecuteWithRetryAsync(
                () => navigationService.GoToTestResultAsync(result, cancellationToken),
                status => status is NavigationRunStatus.Completed or NavigationRunStatus.DroppedDuplicate,
                maxAttempts: submission.SelfHarmItemEndorsed ? 1 : 3,
                cancellationToken: cancellationToken);

            if (!completed)
            {
                throw new TestCompletionNavigationException();
            }
        }
        finally
        {
            // Help must be reachable even if the result page could not open. On success, Back returns to the result.
            if (submission.SelfHarmItemEndorsed)
            {
                await navigationService.GoToCrisisHubAsync();
            }
        }
    }

    private static Task StartQuestionnaireAsync(TestDefinition definition, INavigationService navigationService)
    {
        if (definition.Questions is null || definition.AnalyzerId is null)
        {
            return Task.CompletedTask;
        }

        string analyzerId = definition.AnalyzerId;
        Func<int, string> scoreAnalyzer = score =>
            TestScoreLabelMapper.GetSummary(analyzerId, score) ?? string.Empty;

        List<Question> questions = definition.Questions
            .Select(question => new Question
            {
                Number = question.Number,
                Context = question.Context,
                Answers = question.Answers
                    .Select(answer => new Answer
                    {
                        Number = answer.Number,
                        Ball = answer.Ball,
                        Text = answer.Text,
                        Selected = false
                    })
                    .ToList()
            })
            .ToList();

        return navigationService.GoToQuestionPageAsync(
            questions,
            scoreAnalyzer,
            definition.SingleAnswer,
            new TestSessionInfo { TestId = definition.TestId, AnalyzerId = definition.AnalyzerId });
    }
}
