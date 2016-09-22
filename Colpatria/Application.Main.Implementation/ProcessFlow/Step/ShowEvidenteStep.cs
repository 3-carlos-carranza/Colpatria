using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Implementation.ProcessFlow.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;
using Banlinea.ProcessFlow.Model;
using Core.DataTransferObject.Vib;
using Core.Entities.Evidente;


namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class ShowEvidenteStep : BaseStep
    {
        private readonly IUserAppService _userAppService;
        private readonly IEvidenteAppService _evidenteAppService;
        private readonly QuestionsSettingsBuilder _questionsSettingsBuilder;
        private readonly ValidateUserSettingsBuilder _validateUserSettingsBuilder;

        public ShowEvidenteStep(IProcessFlowStore store, IEvidenteAppService evidenteAppService, IUserAppService userAppService) : base(store)
        {
            _evidenteAppService = evidenteAppService;
            _userAppService = userAppService;
            _validateUserSettingsBuilder = new ValidateUserSettingsBuilder();
            _questionsSettingsBuilder = new QuestionsSettingsBuilder();
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            var userInfo = _userAppService.GetUserInfoByExecutionId(argument.Execution.Id);

            var validationSettings =
            _validateUserSettingsBuilder.WithIdentification(userInfo.Identification)
                .WithTypeOfDocument("1")
                .WithLastName(userInfo.LastName)
                .WithSecondLastName(userInfo.SecondLastName)
                .WithExpeditionDate(userInfo.DateOfExpedition)
                .WithFullName(userInfo.FullName)
                .WithExecutionId(argument.Execution.Id)
                .Build();
            //validate User
            var validationResponse = _evidenteAppService.Validate(validationSettings);


            if (!validationResponse.Success)
            {
                return await OnError(argument).Result.Advance(argument);
            }
            //calll WS 
            var questionsResponse =
                _evidenteAppService.GetQuestions(_questionsSettingsBuilder.WithDocumentNumber("")
                    .WithTypeOfDocument("1")
                    .WithValidationNumber(1)
                    .WithExecutionId(argument.Execution.Id)
                    .Build());
            //validate response
            if (questionsResponse.MaximumAttemptsPerDay)
            {
                return await OnError(argument).Result.Advance(argument);
            }
            if (questionsResponse.MaximumAttemptsPerMonth)
            {
                return await OnError(argument).Result.Advance(argument);
            }
            if (questionsResponse.MaximumAttemptsPerYear)
            {
                return await OnError(argument).Result.Advance(argument);
            }
            TraceFlow(argument);
            if (!argument.IsSubmitting)
            {
                var step = (StepDetail)GetCurrentStep(argument);
                return new EvidenteResponse
                {
                    UserInfoDto = userInfo,
                    Execution = argument.Execution,
                    Questions = questionsResponse.Questions,
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
            throw new NotImplementedException();
        }
    }
}
