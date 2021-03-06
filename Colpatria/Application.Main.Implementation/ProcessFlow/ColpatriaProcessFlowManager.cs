﻿using Banlinea.ProcessFlow.Engine;
using Banlinea.ProcessFlow.Engine.Api;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Model;
using Core.Entities.Enumerations;
using Core.Entities.Process;
using Core.GlobalRepository.SQL.Process;
using Crosscutting.Common.Tools.DataType;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Main.Implementation.ProcessFlow
{
    public class ColpatriaProcessFlowManager : ProcessFlowManager
    {
        private readonly IExecutionRepository _executionRepository;

        public ColpatriaProcessFlowManager(IEnumerable<IStep> steps, IProcessFlowStore store, IExecutionRepository executionRepository)
            : base(steps, store)
        {
            if (steps == null) throw new ArgumentNullException(nameof(steps));
            if (store == null) throw new ArgumentNullException(nameof(store));
            if (executionRepository == null) throw new ArgumentNullException(nameof(executionRepository));
            _executionRepository = executionRepository;
        }

        public override async Task<IProcessFlowResponse> StartFlow(IProcessFlowArgument arg)
        {
            if (arg == null) throw new ArgumentNullException(nameof(arg));
            arg.Steps = Steps;
            InitializeArgument(arg);
            return await base.StartFlow(arg).ConfigureAwait(false);
        }

        private void InitializeArgument(IProcessFlowArgument arg)
        {
            if (arg == null) throw new ArgumentNullException(nameof(arg));
            if (arg.Execution.ProductId == 0)
            {
                throw new Exception("Falta el Producto!!!");
            }
            if (arg.Execution.Id == 0)
            {
                var stepFlow = (Core.Entities.Process.Step)Store.GetNextStep(arg, StepType.Success);
                var request = new Execution
                {
                    CreateDate = DateTime.UtcNow,
                    IsActive = true,
                    ProcessId = stepFlow.ProcessId,
                    ProductId = arg.Execution.ProductId,
                    SimpleId = ToolExtension.GenSemiUniqueId(),
                    UserId = arg.User.Id,
                    CurrentStepId = stepFlow.Id,
                    State = (int)ExecutionState.Requesting,
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