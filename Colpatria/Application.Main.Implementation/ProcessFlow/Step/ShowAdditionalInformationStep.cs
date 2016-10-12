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
using Newtonsoft.Json;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class ShowAdditionalInformationStep : BaseStep
    {
        private readonly IUserAppService _userAppService;
        public ShowAdditionalInformationStep(IProcessFlowStore store, IUserAppService userAppService) : base(store)
        {
            _userAppService = userAppService;
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            var userInfo = _userAppService.GetUserInfoByExecutionId(argument.Execution.Id);

            TraceFlow(argument);
            if (!argument.IsSubmitting)
            {
                var step = (StepDetail)GetCurrentStep(argument);
                return new AdditionalInformationResponse
                {
                    UserInfoDto = userInfo,
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
            }
            Console.WriteLine("Submitting form...Guardando campos");
            argument.IsSubmitting = false;
            return await OnSuccess(argument).Result.Advance(argument);
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}
