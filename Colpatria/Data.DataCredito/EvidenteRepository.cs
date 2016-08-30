using System;
using Core.Entities.Evidente;
using Core.GlobalRepository.Evidente;

namespace Data.DataCredito
{
    public class EvidenteRepository : IEvidenteRepository
    {
        public AnswerResponse AnswerQuestions(AnswerSettings settings)
        {
            throw new NotImplementedException();
        }

        public QuestionsResponse GetQuestions(QuestionsSettings settings)
        {
            throw new NotImplementedException();
        }

        public ValidationResponse Validate(ValidateUserSettings settings)
        {
            throw new NotImplementedException();
        }
    }
}
