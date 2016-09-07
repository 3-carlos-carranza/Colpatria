using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Main.Definition;
using Application.Main.Definition.Arguments;
using Application.Main.Definition.Responses;
using Application.Main.Definition.Steps;
using Application.Main.Implementation.ProcessFlow.Arguments;
using Core.Entities.SQL.Enumerations;
using Core.Entities.SQL.Process;
using Core.GlobalRepository.SQL.Process;

namespace Application.Main.Implementation.ProcessFlow
{
    public class ProcessFlowService : IProcessFlowService
    {
        private readonly IStepRepository _stepRepository;
        private readonly IProductProcessRepository _productProcessRepository;
        public ProcessFlowService(IEnumerable<IStep> steps, IStepRepository stepRepository, IProductProcessRepository productProcessRepository)
        {
            Steps = steps;
            _stepRepository = stepRepository;
            _productProcessRepository = productProcessRepository;
        }

        public IEnumerable<IStep> Steps { get; }

        public Task<IStepResponse> RunFlow(IProcessFlowArgument processFlowArgument)
        {
            throw new NotImplementedException();
        }

        private void InitializeStepArgument(IProcessFlowArgument processFlowArgument)
        {
            processFlowArgument.StepArgument.Steps = Steps;

            var processid = _productProcessRepository.GetFiltered(s => s.ProductId == processFlowArgument.ExecutionArgument.ProductId).FirstOrDefault();

            if (processFlowArgument.StepArgument.Execution == null)
            {
                //Login 
                var submitFormStepArgument = processFlowArgument.StepArgument as SubmitFormArgument;

                var request = new Execution
                {
                    CreateDate = DateTime.UtcNow,
                    IsActive = true,
                    //ProductId = processFlowArgument.ExecutionArgument.ProductId,
                    SimpleId = "123456",//Tools.GenSemiUniqueId(6),
                    UserId = processFlowArgument.ExecutionArgument.UserId,
                    //CurrentStepId = _stepRepository.GetFirstStepbyProcess().Id,
                    State = (int) ExecutionState.Requesting,
                    ProductData = @"{}"
                };
                //processFlowArgument.StepArgument.Request = _requestRepository.CreateRequest(request);
                processFlowArgument.IsSubmitting = true;
            }
            else
            {
                //processFlowArgument.StepArgument.Request =
                //    _requestRepository.GetRequestById(processFlowArgument.StepArgument.Request.Id);
            }
            //processFlowArgument.StepArgument.Request.UserId = processFlowArgument.RequestArgument.UserId;
        }
    }
}