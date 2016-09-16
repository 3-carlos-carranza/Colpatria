using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.Enumerations;
using Application.Main.Definition.MyCustomProcessFlow.Steps;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Application.Main.Definition.ProcessFlow.Api.Steps;
using Application.Main.Implementation.ProcessFlow.Responses;
using Core.DataTransferObject.Vib;
using Core.Entities.ProcessModel;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class ShowFinishRequestStep : BaseStep, IShowFinishRequestStep
    {
        private readonly IResponseRequestAppService _responseRequestAppService;

        public ShowFinishRequestStep(IProcessFlowStore store, IResponseRequestAppService responseRequestAppService)
            : base(store)
        {
            _responseRequestAppService = responseRequestAppService;
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            //Obtener respuesta de WsMotor
            var responseWsMotor = _responseRequestAppService.GetResponse();
            var step = (StepDetail) GetCurrentStep(argument);
            
            var response = new RequestResponse
            {
                Name = responseWsMotor.Name,
                DateOfExpedition = responseWsMotor.DateOfExpedition,
                MessageClassification = responseWsMotor.MessageClassification,
                IsResponsePersonalized = responseWsMotor.IsResponsePersonalized,
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
            return response;
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}