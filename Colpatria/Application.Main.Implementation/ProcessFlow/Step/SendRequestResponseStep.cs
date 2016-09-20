using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow;
using Application.Main.Definition.MyCustomProcessFlow.Steps;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class SendRequestResponseStep : BaseStep, ISendRequestResponseStep
    {

        public readonly IMailAppService MailAppService;

        public SendRequestResponseStep(IProcessFlowStore store, IMailAppService mailAppService) : base(store)
        {
            MailAppService = mailAppService;
        }

        public async override Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            SendRequestMail();

            return await OnSuccess(argument).Result.Advance(argument);
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public bool SendRequestMail()
        {
            return MailAppService.SendMail();
        }
    }
}