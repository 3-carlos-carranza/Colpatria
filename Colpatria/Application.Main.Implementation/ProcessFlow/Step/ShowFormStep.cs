using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Application.Main.Definition.ProcessFlow.Api.Steps;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class ShowFormStep : BaseStep
    {
        public ShowFormStep(IProcessFlowStore store) : base(store)
        {
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            return await OnSucess(argument).Result.Advance(argument);
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}