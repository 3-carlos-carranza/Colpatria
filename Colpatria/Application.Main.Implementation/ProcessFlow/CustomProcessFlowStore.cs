#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=CustomProcessFlowStore.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 5:01 p. m.</Date>
//   <Update> 2016-09-12 - 11:47 a. m.</Update>
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
using Core.Entities.ProcessModel;

#endregion

namespace Application.Main.Implementation.ProcessFlow
{
    public class CustomProcessFlowStore : IProcessFlowStore
    {
        private readonly IProcessAppService _processAppService;

        private IEnumerable<Core.Entities.Process.Step> _steps;
        private long productId;

        public CustomProcessFlowStore(IProcessAppService processAppService)
        {
            _processAppService = processAppService;
        }

        public IEnumerable<StepFlow> Steps
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

        public void TrackingStep(IProcessFlowArgument argument)
        {
            Console.WriteLine("Entra al Paso " + argument.Execution.CurrentStepId);
        }

        public StepFlow GetNextStep(IProcessFlowArgument argument, StepType stepType)
        {
            productId = argument.Execution.ProductId;
            var currentstep = GetCurrentStep(argument);
            if (currentstep != null)
            {
                return
                    Steps.OrderBy(s => s.Order)
                        .FirstOrDefault(s => s.Order == (currentstep.Order + 1) && s.StepType == (int) stepType);
            }
            return Steps.OrderBy(s => s.Order).FirstOrDefault(s => s.StepType == (int) stepType);
        }

        public StepFlow GetCurrentStep(IProcessFlowArgument argument)
        {
            productId = argument.Execution.ProductId;
            return Steps.FirstOrDefault(s => s.Id == argument.Execution.CurrentStepId);
        }

        public async Task<StepFlow> GetNextStepAsync(IProcessFlowArgument argument,
            StepType stepType,
            CancellationToken cancellationToken = new CancellationToken())
        {
            return Steps.First(s => s.Id == argument.Execution.CurrentStepId && s.StepType == (int) stepType);
        }
    }
}