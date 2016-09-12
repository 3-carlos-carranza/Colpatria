#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ColpatriaProcessFlowManager.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 5:01 p. m.</Date>
//   <Update> 2016-09-09 - 12:58 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow;
using Application.Main.Definition.ProcessFlow.Api;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Core.Entities.Enumerations;
using Core.Entities.Process;
using Core.GlobalRepository.SQL.Process;
using Crosscutting.Common.Tools.DataType;
using StepType = Application.Main.Definition.ProcessFlow.Api.ProcessFlows.StepType;

#endregion

namespace Application.Main.Implementation.ProcessFlow
{
    public class ColpatriaProcessFlowManager : ProcessFlowManager
    {
        private readonly IExecutionRepository _executionRepository;

        public ColpatriaProcessFlowManager(IEnumerable<IStep> steps, IProcessFlowStore store,
            IExecutionRepository executionRepository) : base(steps, store)
        {
            _executionRepository = executionRepository;
        }
        public override async Task<IProcessFlowResponse> StartFlow(IProcessFlowArgument arg,
                   Func<IProcessFlowArgument, IProcessFlowResponse> actionToStart)
        {
            InitializeArgument(arg);
            //arg.Steps = Steps;
            return await base.StartFlow(arg, actionToStart);
        }
       

        private void InitializeArgument(IProcessFlowArgument arg)
        {
            if (arg.Execution.ProductId == 0)
            {
                throw new Exception("Falta el Producto!!!"); ;
            }
            if (arg.Execution.Id == 0)
            {
                var stepFlow =((Core.Entities.Process.Step) Store.GetNextStep(arg,StepType.Success));
                var request = new Execution
                {
                    CreateDate = DateTime.UtcNow,
                    IsActive = true,
                    ProcessId = stepFlow.ProcessId,
                    ProductId = arg.Execution.ProductId,
                    SimpleId = ToolExtension.GenSemiUniqueId(),
                    UserId = arg.User.Id,
                    CurrentStepId = stepFlow.Id,
                    State = (int) ExecutionState.Requesting,
                    ProductData = @"{}"
                };
                arg.Execution = _executionRepository.CreateRequest(request);
                arg.IsSubmitting = true;
            }
            else
            {
                arg.Execution = _executionRepository.GetRequestById(arg.Execution.Id);
            }
        }
    }
}