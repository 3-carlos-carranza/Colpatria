using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.Enumerations;
using Application.Main.Definition.MyCustomProcessFlow.Steps;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;

using Application.Main.Implementation.ProcessFlow.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;
using Banlinea.ProcessFlow.Model;
using Core.DataTransferObject.Vib;
using Core.GlobalRepository.SQL.User;


namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class ShowFinishRequestStep : BaseStep, IShowFinishRequestStep
    {
        private readonly IResponseRequestAppService _responseRequestAppService;
        private readonly IUserRepository _userRepository;

        public ShowFinishRequestStep(IProcessFlowStore store, IResponseRequestAppService responseRequestAppService, 
            IUserRepository userRepository)
            : base(store)
        {
            _responseRequestAppService = responseRequestAppService;
            _userRepository = userRepository;
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            //Obtener respuesta de WsMotor
            var responseWsMotor = _responseRequestAppService.GetResponse();
            var userInfo = _userRepository.GetUserInfoByExecutionId(argument.Execution.Id);

            var step = (StepDetail) GetCurrentStep(argument);
            if (!argument.IsSubmitting)
            {
                return new RequestResponse
                {
                    Name = userInfo.Names,
                    DateOfExpedition = Convert.ToDateTime(DateTime.UtcNow.ToShortDateString()),
                    MessageClassification = responseWsMotor.MessageClassification,
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

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}