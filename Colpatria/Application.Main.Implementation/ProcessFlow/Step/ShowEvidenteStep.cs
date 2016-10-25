using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Implementation.ProcessFlow.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;
using Banlinea.ProcessFlow.Model;
using Core.DataTransferObject.Vib;
using Core.Entities.Evidente;
using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Implementation.ProcessFlow.Arguments;
using Crosscutting.Common.Tools.DataType;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class ShowEvidenteStep : BaseStep
    {
        private readonly IUserAppService _userAppService;
        private readonly IEvidenteAppService _evidenteAppService;
        private readonly QuestionsSettingsBuilder _questionsSettingsBuilder;
        private readonly ValidateUserSettingsBuilder _validateUserSettingsBuilder;
        private readonly ISaveFieldsAppService _saveFieldsAppService;

        public ShowEvidenteStep(IProcessFlowStore store, IEvidenteAppService evidenteAppService, IUserAppService userAppService, ISaveFieldsAppService saveFieldsAppService) : base(store)
        {
            _evidenteAppService = evidenteAppService;
            _userAppService = userAppService;
            _saveFieldsAppService = saveFieldsAppService;
            _validateUserSettingsBuilder = new ValidateUserSettingsBuilder();
            _questionsSettingsBuilder = new QuestionsSettingsBuilder();
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            TraceFlow(argument);
            if (!argument.IsSubmitting)
            {
                var saveFieldsAppService = argument as ProcessFlowArgument;
                var userInfo = _userAppService.GetUserInfoByExecutionId(argument.Execution.Id);

                var validationSettings =
                _validateUserSettingsBuilder.WithIdentification(userInfo.Identification)
                    .WithTypeOfDocument("1")
                    .WithLastName(userInfo.LastName)
                    .WithSecondLastName(userInfo.SecondLastName)
                    .WithExpeditionDate(userInfo.DateOfExpedition)
                    .WithNames(userInfo.Names)
                    .WithExecutionId(argument.Execution.Id)
                    .Build();
                //validate User
                var validationResponse = _evidenteAppService.Validate(validationSettings);

                if (!validationResponse.ProcessResult)
                {
                    //Execution failed
                    saveFieldsAppService?.Form.Add(new FieldValueOrder { Key = "17", Value = "Ha ocurrido un error con nuestro buró de crédito" });
                    _saveFieldsAppService.SaveForm(saveFieldsAppService);

                    return await OnError(argument).Result.Advance(argument);
                }

                if (!validationResponse.Success)
                {
                    //Execution rejected
                    saveFieldsAppService?.Form.Add(new FieldValueOrder { Key = "17", Value = "Rechazado" });
                    _saveFieldsAppService.SaveForm(saveFieldsAppService);
                    return await OnError(argument).Result.Advance(argument);
                }
                saveFieldsAppService?.Form.Add(new FieldValueOrder { Key = "17", Value = "Aprobado" });
                //calll WS
                var questionsResponse =
                    _evidenteAppService.GetQuestions(_questionsSettingsBuilder.WithDocumentNumber(userInfo.Identification)
                        .WithTypeOfDocument("1")
                        .WithValidationNumber(validationResponse.ValidationNumber)
                        .WithExecutionId(argument.Execution.Id)
                        .Build());
                //validate response
                if (questionsResponse.Result.Equals("00"))
                {
                    saveFieldsAppService?.Form.Add(new FieldValueOrder { Key = "14", Value = "Ha ocurrido un error con nuestro buró de crédito" });
                    _saveFieldsAppService.SaveForm(saveFieldsAppService);
                    return await OnError(argument).Result.Advance(argument);
                }
                if (questionsResponse.MaximumAttemptsPerDay)
                {
                    saveFieldsAppService?.Form.Add(new FieldValueOrder { Key = "14", Value = "Ha superado los intentos diarios permitidos. Intentar mañana" });
                    _saveFieldsAppService.SaveForm(saveFieldsAppService);
                    return await OnError(argument).Result.Advance(argument);
                }
                if (questionsResponse.MaximumAttemptsPerMonth)
                {
                    saveFieldsAppService?.Form.Add(new FieldValueOrder { Key = "14", Value = "Ha superado los intentos mensuales permitidos. Intentar en un mes" });
                    _saveFieldsAppService.SaveForm(saveFieldsAppService);
                    return await OnError(argument).Result.Advance(argument);
                }
                if (questionsResponse.MaximumAttemptsPerYear)
                {
                    saveFieldsAppService?.Form.Add(new FieldValueOrder { Key = "14", Value = "Apreciado Usuario: el proceso de solicitud no puede continuar. Superó máximos intentos permitidos" });
                    _saveFieldsAppService.SaveForm(saveFieldsAppService);
                    return await OnError(argument).Result.Advance(argument);
                }
                saveFieldsAppService?.Form.Add(new FieldValueOrder { Key = "14", Value = "Preguntas obtenidas con éxito" });
                _saveFieldsAppService.SaveForm(saveFieldsAppService);
                var step = (StepDetail)GetCurrentStep(argument);
                return new EvidenteResponse
                {
                    UserInfoDto = userInfo,
                    Execution = argument.Execution,
                    QuestionsResponse = questionsResponse,
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