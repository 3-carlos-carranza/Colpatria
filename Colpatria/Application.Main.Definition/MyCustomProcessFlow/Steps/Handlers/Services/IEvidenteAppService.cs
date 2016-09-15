using Core.Entities.Evidente;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface IEvidenteAppService
    {
        AnswerResponse AnswerQuestions(AnswerSettings settings);
        QuestionsResponse GetQuestions(QuestionsSettings settings);
        ValidationResponse Validate(ValidateUserSettings settings);
    }

    public interface IWsMotorAppService
    {
        
    }
}
