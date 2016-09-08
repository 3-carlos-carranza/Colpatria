using Core.Entities.Evidente;

namespace Application.Main.Definition
{
    public interface IEvidenteAppService
    {
        AnswerResponse AnswerQuestions(AnswerSettings settings);
        QuestionsResponse GetQuestions(QuestionsSettings settings);
        ValidationResponse Validate(ValidateUserSettings settings);
    }
}
