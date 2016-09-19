using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class SendRequestResponseStep : BaseStep, ISendRequestResponseStep
    {
        public SendRequestResponseStep(IProcessFlowStore store) : base(store)
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

        public bool SendRequestMail()
        {
            return true;
        }
    }
}