using PsychologyApp.Application.Models.Tests;
using PsychologyApp.Application.Tests;
using PsychologyApp.Domain.Practice;
using PsychologyApp.Domain.Tests;

namespace PsychologyApp.Application.Tests;

public sealed record QuestionnaireScoringResult(
    int Score,
    int BandIndex,
    TechniqueId? RecommendedTechnique,
    string? AnalyzerId,
    bool SelfHarmItemEndorsed = false);

public interface IQuestionnaireScoringService
{
    bool TryValidateAllAnswered(IEnumerable<Question> questions);

    QuestionnaireScoringResult Calculate(IEnumerable<Question> questions, string? analyzerId);
}

public sealed class QuestionnaireScoringService : IQuestionnaireScoringService
{
    public bool TryValidateAllAnswered(IEnumerable<Question> questions) =>
        QuestionnaireScoreCalculator.AllQuestionsAnswered(ToAnswerModels(questions));

    public QuestionnaireScoringResult Calculate(IEnumerable<Question> questions, string? analyzerId)
    {
        questions = questions.ToList();
        IReadOnlyList<QuestionnaireQuestionAnswers> answerModels = ToAnswerModels(questions);
        int score = analyzerId == BigFiveProfile.AnalyzerId
            ? BigFiveProfile.CalculateScore(questions.Select(GetSelectedScore).ToArray())
            : QuestionnaireScoreCalculator.CalculateScore(answerModels);
        int bandIndex = TestScoreInterpreter.GetBandIndex(analyzerId, score);
        TechniqueId? recommended = analyzerId is not null
            ? TestScoreRecommendation.RecommendTechnique(analyzerId, score)
            : null;

        return new QuestionnaireScoringResult(
            score, bandIndex, recommended, analyzerId, SelfHarmScreening.IsEndorsed(analyzerId, questions));
    }

    private static IReadOnlyList<QuestionnaireQuestionAnswers> ToAnswerModels(IEnumerable<Question> questions) =>
        questions
            .Select(question => new QuestionnaireQuestionAnswers(
                question.Answers.Where(answer => answer.Selected).Select(answer => answer.Ball).ToList()))
            .ToList();

    private static int GetSelectedScore(Question question)
    {
        Answer[] selected = question.Answers.Where(answer => answer.Selected).ToArray();
        return selected.Length == 1
            ? selected[0].Ball
            : throw new InvalidOperationException("Every Big Five question must have exactly one selected answer.");
    }
}
