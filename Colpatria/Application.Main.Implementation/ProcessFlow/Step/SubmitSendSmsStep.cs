using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Banlinea.ProcessFlow.Engine.Api;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;
using Core.GlobalRepository.SQL.Process;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class SubmitSendSmsStep : BaseStep, IStep
    {
        private readonly IInalambriaAppService _inalambriaAppService;
        private readonly IUserAppService _userAppService;

        public SubmitSendSmsStep(IProcessFlowStore store, IInalambriaAppService inalambriaAppService,
            IUserAppService userAppService)
            : base(store)
        {
            _inalambriaAppService = inalambriaAppService;
            _userAppService = userAppService;
        }

        public new string Name => GetType().Name;

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            var user = _userAppService.GetUserInfoByExecutionId(argument.Execution.Id);

            _inalambriaAppService.SendSms
                (user.Cellphone,                                                                        
                    "Colpatria informa que usted realizo la solicitud #" + user.SimpleId +
                    " a traves de Oficina Virtual", "1", argument.Execution.Id);

            return await OnSuccess(argument).Result.Advance(argument);
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}