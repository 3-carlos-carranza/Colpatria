//   -----------------------------------------------------------------------
//   <copyright file=SaveFieldsAppService.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using System;
using System.Linq;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Implementation.ProcessFlow.Arguments;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
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