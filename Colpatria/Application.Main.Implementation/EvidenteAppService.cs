using Application.Main.Definition;
using Core.Entities.Evidente;
using Core.GlobalRepository.Evidente;

namespace Application.Main.Implementation
{
     public class EvidenteAppService : IEvidenteAppService
     {
         private readonly IEvidenteRepository _evidenteRepository;

         public EvidenteAppService(IEvidenteRepository evidenteRepository)
         {
             _evidenteRepository = evidenteRepository;
         }

         public AnswerResponse AnswerQuestions(AnswerSettings settings)
         {
             return _evidenteRepository.AnswerQuestions(settings);
         }

         public QuestionsResponse GetQuestions(QuestionsSettings settings)
         {
             return _evidenteRepository.GetQuestions(settings);
         }

         public ValidationResponse Validate(ValidateUserSettings settings)
         {
             return _evidenteRepository.Validate(settings);
         }
    }
}
