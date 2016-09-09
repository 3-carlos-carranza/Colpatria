#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=CustomProcessFlowStore.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 1:57 p. m.</Date>
//   <Update> 2016-09-08 - 1:57 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;

#endregion

namespace Application.Main.Implementation.ProcessFlow
{
    public class CustomProcessFlowStore : IProcessFlowStore
    {

        private IEnumerable<Core.Entities.Process.Step> _steps;
        private long productId;
        public IEnumerable<Core.Entities.ProcessModel.StepFlow> Steps
        {
            get
            {
                if (_steps != null)
                {
                    return _steps;
                }
                _steps = _processAppService.GetAllStepsEnablesByProduct(productId);
                return _steps;
            }
        }

        private readonly IProcessAppService _processAppService;

        public CustomProcessFlowStore(IProcessAppService processAppService)
        {
            _processAppService = processAppService;
        }

        public void TrackingStep(IProcessFlowArgument argument)
        {
            Console.WriteLine("Entra al Paso " + argument.Execution.CurrentStepId);
        }

        public async Task<Core.Entities.ProcessModel.StepFlow> GetNextStep(IProcessFlowArgument argument, StepType stepType)
        {

            productId = argument.Execution.ProductId;
            var currentstep = await GetCurrentStep(argument);
            return
                Steps.OrderBy(s => s.Order)
                    .First(s => s.Order == (currentstep.Order + 1) && s.StepType == (int) stepType);
        }

        public async Task<Core.Entities.ProcessModel.StepFlow> GetCurrentStep(IProcessFlowArgument argument)
        {
            return Steps.First(s => s.Id == argument.Execution.CurrentStepId);
        }

        public async Task<Core.Entities.ProcessModel.StepFlow> GetNextStepAsync(IProcessFlowArgument argument,
            StepType stepType,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return Steps.First(s => s.Id == argument.Execution.CurrentStepId && s.StepType == (int) stepType);
        }
    }
}