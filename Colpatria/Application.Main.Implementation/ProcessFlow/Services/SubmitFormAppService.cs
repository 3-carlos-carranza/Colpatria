using System;
using System.Linq;
using Application.Main.Definition.Arguments;
using Application.Main.Definition.Services;
using Application.Main.Implementation.ProcessFlow.Arguments;
using Core.GlobalRepository.SQL.Process;

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class SubmitFormAppService : ISubmitFormAppService
    {
        private readonly IExtendedFieldRepository _extendedFieldRepository;

        public SubmitFormAppService(IExtendedFieldRepository extendedFieldRepository)
        {
            _extendedFieldRepository = extendedFieldRepository;
        }

        public bool SaveForm(IStepArgument stepArgument)
        {
            const bool response = true;
            var submitFormArgument = stepArgument as SubmitFormArgument;
            if (submitFormArgument != null)
            {
                _extendedFieldRepository.SetFields(
                    submitFormArgument.Form.ToList(),
                    submitFormArgument.Execution.Id,
                    submitFormArgument.OwnerId);
            }
            else
            {
                throw new Exception();
            }


            return response;
        }
    }
}