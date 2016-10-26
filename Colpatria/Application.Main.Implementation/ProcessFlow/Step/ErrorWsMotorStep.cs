using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Implementation.ProcessFlow.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;
using Banlinea.ProcessFlow.Model;
using Core.DataTransferObject.Vib;
using Core.Entities.WsMotor;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class ErrorWsMotorStep : BaseStep
    {
        private readonly IUserAppService _userAppService;
        public ErrorWsMotorStep(IProcessFlowStore store, IUserAppService userAppService) : base(store)
        {
            _userAppService = userAppService;
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            var errorWsMotor = new ErrorWsMotorResponse();
            if (argument == null) throw new ArgumentNullException(nameof(argument));
            var userInfo = _userAppService.GetUserInfoByExecutionId(argument.Execution.Id);
            await Task.Factory.StartNew(() => TraceFlow(argument)).ConfigureAwait(false);
            var step = await Task.Factory.StartNew(() => (StepDetail)GetCurrentStep(argument)).ConfigureAwait(false);
            var response = new WsMotorResponse
            {
                ErrorWsMotorResponse = errorWsMotor,
                Execution = argument.Execution,
                Action = step.Action,
                ActionMethod = step.ActionMethod,
                Controller = step.Controller,
                FriendlyUrl = (step.PageName + "/" + step.SectionName).Replace(" ", "-"),
                ResponseDetail = new ResponseDetailFlow
                {
                    Status = ReponseStatus.Success
                }
            };
            return Task.FromResult((IProcessFlowResponse)response).Result;
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}
