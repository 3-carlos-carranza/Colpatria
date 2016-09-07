using Core.Entities.Evidente;

namespace Core.GlobalRepository.Evidente
{
    public interface IEvidenteRepository
    {
        AnswerResponse AnswerQuestions(AnswerSettings settings);
        QuestionsResponse GetQuestions(QuestionsSettings settings);
        ValidationResponse Validate(ValidateUserSettings settings);
    }
}
