using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Implementation.ProcessFlow.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;
using Banlinea.ProcessFlow.Model;
using Core.DataTransferObject.Vib;
using Core.Entities.Enumerations;
using Core.Entities.WsMotor;
using Crosscutting.Common.Extensions;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class ShowDataSummaryStep : BaseStep
    {
        private readonly IUserAppService _userAppService;

        public ShowDataSummaryStep(IProcessFlowStore store, IUserAppService userAppService) : base(store)
        {
            _userAppService = userAppService;
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            if (argument == null) throw new ArgumentNullException(nameof(argument));

            var userInfo = _userAppService.GetUserInfoByExecutionId(argument.Execution.Id);
            var data = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<WsMotorServiceResponse>(userInfo.ResponseWsMotor)).ConfigureAwait(false);
            userInfo.ClassificationWsMotor = data.ScoresMotor.ScoreMotor.Classification == "A"
                ? Classification.Approved.GetStringValue()
                : Classification.Declined.GetStringValue();
            TraceFlow(argument);
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

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}