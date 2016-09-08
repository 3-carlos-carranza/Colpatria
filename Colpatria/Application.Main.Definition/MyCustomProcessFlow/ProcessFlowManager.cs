using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Main.Definition.ProcessFlow.Api;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;

namespace Application.Main.Definition.MyCustomProcessFlow
{
    public class ProcessFlowManager : IProcessFlowManager
    {
        public ProcessFlowManager(IEnumerable<IStep> steps, IProcessFlowStore store)
        {
            Steps = steps;
            Store = store;
        }

        public IEnumerable<IStep> Steps { get; }
        public IProcessFlowStore Store { get; }

        public async Task<IProcessFlowResponse> StartFlow(IProcessFlowArgument arg,
            Func<IProcessFlowArgument, IProcessFlowResponse> actionToStart)
        {
            arg.Steps = Steps;
            if (actionToStart != null)
            {
                return actionToStart.Invoke(arg);
            }
            var step = await Store.GetCurrentStep(arg);
            return await Steps.First(s => s.Name == step.Name).Advance(arg);
        }

        public async Task<IProcessFlowResponse> StartFlowAsync(IProcessFlowArgument arg,
            Func<IProcessFlowArgument, IProcessFlowResponse> actionToStart)
        {
            arg.Steps = Steps;
            var step = await Store.GetCurrentStep(arg);
            return await Steps.First(s => s.Name == step.Name).Advance(arg);
        }

        public async Task<IProcessFlowResponse> StartFlow(IProcessFlowArgument arg)
        {
            var step = await Store.GetCurrentStep(arg);
            return await Steps.First(s => s.Name == step.NameClientAlias).Advance(arg);
        }
    }
}