// ----------------------------------------------------------------------- <copyright
// file=SubmitEvidenteStep.cs company="Banlinea S.A.S"> Copyright (c) Banlinea Todos los derechos
// reservados. </copyright> <author>Jeysson Stevens Ramirez </author> -----------------------------------------------------------------------

using Application.Main.Definition.MyCustomProcessFlow.Steps;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;
using Core.Entities.Evidente;
using System;
using System.Configuration;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Implementation.ProcessFlow.Arguments;
using Crosscutting.Common.Tools.DataType;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class SubmitEvidenteStep : BaseStep, ISubmitEvidenteStep
    {
        private readonly IUserAppService _userAppService;
        private readonly IEvidenteAppService _evidenteAppService;
        private readonly AnswerSettingsBuilder _answerSettingsBuilder;
        private readonly ISaveFieldsAppService _saveFieldsAppService;

        public SubmitEvidenteStep(IProcessFlowStore store, IEvidenteAppService evidenteAppService, IUserAppService userAppService, ISaveFieldsAppService saveFieldsAppService) : base(store)
        {
            _evidenteAppService = evidenteAppService;
            _userAppService = userAppService;
            _saveFieldsAppService = saveFieldsAppService;
            _answerSettingsBuilder = new AnswerSettingsBuilder();
        }

        public int SectionId { get; set; }
        public int StepId { get; set; }
        public new string Name => GetType().Name;

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            if (argument == null) throw new ArgumentNullException(nameof(argument));
            var userInfo = _userAppService.GetUserInfoByExecutionId(argument.Execution.Id);
            var mock = bool.Parse(ConfigurationManager.AppSettings.Get("Mock"));
            if (!mock)
            {
                var saveFieldsAppService = argument as ProcessFlowArgument;
                var arg = argument as IAnswerQuestionArgument;

                var settings = _answerSettingsBuilder.WithIdentification(userInfo.Identification)
                        .WithAnswerRequest(arg.AnswerRequest)
                        .WithIdentificationType("1")
                        .WithExecutionId(argument.Execution.Id)
                        .Build();

                var response = _evidenteAppService.AnswerQuestions(settings);

                if (!response.Result)
                {
                    saveFieldsAppService?.Form.Add(new FieldValueOrder { Key = "16", Value = "Ha ocurrido un error con nuestro buró de crédito" });
                    _saveFieldsAppService.SaveForm(saveFieldsAppService);
                    return await OnError(argument).Result.Advance(argument);
                }
                if (response.Approval)
                {
                    saveFieldsAppService?.Form.Add(new FieldValueOrder { Key = "16", Value = "Aprobado" });
                    _saveFieldsAppService.SaveForm(saveFieldsAppService);
                    return await OnSuccess(argument).Result.Advance(argument);
                }
                saveFieldsAppService?.Form.Add(new FieldValueOrder { Key = "16", Value = "Las respuestas proporcionadas no coinciden" });
                _saveFieldsAppService.SaveForm(saveFieldsAppService);
                return await OnError(argument).Result.Advance(argument);
            }

            return await OnSuccess(argument).Result.Advance(argument);
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}