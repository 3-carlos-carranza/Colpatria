using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow.Steps;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class SubmitAdditionalInformationStep : BaseStep, ISubmitAdditionalInformationStep
    {
        private readonly ISaveFieldsAppService _saveFieldsAppService;
        public SubmitAdditionalInformationStep(IProcessFlowStore store, ISaveFieldsAppService saveFieldsAppService) : base(store)
        {
            _saveFieldsAppService = saveFieldsAppService;
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            _saveFieldsAppService.SaveForm(argument);
            return await OnSuccess(argument).Result.Advance(argument);
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}
