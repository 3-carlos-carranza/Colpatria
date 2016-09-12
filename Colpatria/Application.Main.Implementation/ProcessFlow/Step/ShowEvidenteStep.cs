using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Application.Main.Definition.ProcessFlow.Api.Steps;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class ShowEvidenteStep : BaseStep
    {
        public ShowEvidenteStep(IProcessFlowStore store) : base(store)
        {
        }

        public override Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            throw new System.NotImplementedException();
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}
