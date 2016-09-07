using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Main.Definition;
using Application.Main.Definition.Arguments;
using Application.Main.Definition.Responses;
using Application.Main.Definition.Steps;
using Core.Entities.SQL.Enumerations;
using Core.Entities.SQL.Process;
using Core.GlobalRepository.SQL.Process;
using Crosscutting.Common.Tools.DataType;

namespace Application.Main.Implementation.ProcessFlow
{
    public class ProcessFlowService : IProcessFlowService
    {
        private readonly IStepRepository _stepRepository;
        private readonly IProductProcessRepository _productProcessRepository;
        private readonly IExecutionRepository _executionRepository;
        public ProcessFlowService(
            IEnumerable<IStep> steps, 
            IStepRepository stepRepository, 
            IProductProcessRepository productProcessRepository,
            IExecutionRepository executionRepository)
        {
            Steps = steps;
            _stepRepository = stepRepository;
            _productProcessRepository = productProcessRepository;
            _executionRepository = executionRepository;
            
        }

        public IEnumerable<IStep> Steps { get; }

        public async Task<IStepResponse> RunFlow(IProcessFlowArgument processFlowArgument)
        {
            //Creo la solicitud
            InitializeStepArgument(processFlowArgument);

            var step = processFlowArgument.StepArgument.Execution.CurrentStepId;

            var stepobj = _stepRepository.Get(s => s.Id == step);
            var steps = stepobj.NameClientAlias.Split(Convert.ToChar("|"));

            if (processFlowArgument.IsSubmitting)
            {
                var submittableStep = Steps.First(s => s.Name == steps[1]);
                if (submittableStep != null)
                {
                    return await submittableStep.Advance(processFlowArgument.StepArgument);
                }
            }
            return await Steps.First(s => s.Name == steps[0]).Advance(processFlowArgument.StepArgument);
        }

        private void InitializeStepArgument(IProcessFlowArgument processFlowArgument)
        {
            processFlowArgument.StepArgument.Steps = Steps;

            var processid = 
                _productProcessRepository.GetFiltered
                (s => s.ProductId == processFlowArgument.ExecutionArgument.ProductId).FirstOrDefault();

            if (processFlowArgument.StepArgument.Execution == null)
            {
                var submitFormArgument = processFlowArgument.StepArgument as SubmitFormArgument;
                var c = submitFormArgument?.Form.ToList();
                var request = new Execution
                {
                    CreateDate = DateTime.UtcNow,
                    IsActive = true,
                    ProcessId = processid.Id,
                    ProductId = processFlowArgument.ExecutionArgument.ProductId,
                    SimpleId = ToolExtension.GenSemiUniqueId(),
                    UserId = processFlowArgument.ExecutionArgument.UserId,
                    CurrentStepId = _stepRepository.GetFirstStepbyProcess(processid.ProcessId).Id,
                    State = (int) ExecutionState.Requesting,
                    ProductData = @"{}"
                };
                processFlowArgument.StepArgument.Execution = _executionRepository.CreateRequest(request);
                processFlowArgument.IsSubmitting = true;
            }
            else
            {
                processFlowArgument.StepArgument.Execution =
                    _executionRepository.GetRequestById(processFlowArgument.StepArgument.Execution.Id);
            }
            processFlowArgument.StepArgument.Execution.UserId = processFlowArgument.ExecutionArgument.UserId;
        }
    }
}