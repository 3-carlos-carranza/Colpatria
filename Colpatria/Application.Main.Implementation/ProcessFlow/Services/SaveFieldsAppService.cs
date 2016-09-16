using System;
using System.Linq;

using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Implementation.ProcessFlow.Arguments;
using Core.GlobalRepository.SQL.Process;

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class SaveFieldsAppService : ISaveFieldsAppService
    {
        private readonly IExtendedFieldRepository _extendedFieldRepository;

        public SaveFieldsAppService(IExtendedFieldRepository extendedFieldRepository)
        {
            _extendedFieldRepository = extendedFieldRepository;
        }

        public bool SaveForm(IProcessFlowArgument arg)
        {
            const bool response = true;
            var submitFormArgument = arg as ProcessFlowArgument;
            if (submitFormArgument != null)
            {
                _extendedFieldRepository.SetFields(
                    submitFormArgument.Form.ToList(),
                    submitFormArgument.Execution.Id);
            }
            else
            {
                throw new Exception();
            }


            return response;
        }
    }
}