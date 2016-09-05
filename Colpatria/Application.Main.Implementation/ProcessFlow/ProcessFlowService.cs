using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Main.Definition;
using Application.Main.Definition.Arguments;
using Application.Main.Definition.Responses;
using Application.Main.Definition.Steps;

namespace Application.Main.Implementation.ProcessFlow
{
    public class ProcessFlowService : IProcessFlowService
    {
        public ProcessFlowService(IEnumerable<IStep> steps)
        {
            Steps = steps;
        }

        public IEnumerable<IStep> Steps { get; }

        public Task<IStepResponse> RunFlow(IProcessFlowArgument processFlowArgument)
        {
            throw new NotImplementedException();
        }
    }
}