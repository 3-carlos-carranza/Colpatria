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

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class SubmitEvidenteStep : BaseStep, ISubmitEvidenteStep
    {
        private readonly IUserAppService _userAppService;
        private readonly IEvidenteAppService _evidenteAppService;
        private readonly AnswerSettingsBuilder _answerSettingsBuilder;

        public SubmitEvidenteStep(IProcessFlowStore store, IEvidenteAppService evidenteAppService, IUserAppService userAppService) : base(store)
        {
            _evidenteAppService = evidenteAppService;
            _userAppService = userAppService;
            _answerSettingsBuilder = new AnswerSettingsBuilder();
        }

        public int SectionId { get; set; }
        public int StepId { get; set; }
        public new string Name => GetType().Name;

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            var userInfo = _userAppService.GetUserInfoByExecutionId(argument.Execution.Id);
            var mock = bool.Parse(ConfigurationManager.AppSettings.Get("Mock"));
            if (!mock)
            {
                var arg = argument as IAnswerQuestionArgument;

                var settings = _answerSettingsBuilder.WithIdentification(userInfo.Identification)
                        .WithAnswerRequest(arg.AnswerRequest)
                        .WithIdentificationType("1")
                        .WithExecutionId(argument.Execution.Id)
                        .Build();

                var response = _evidenteAppService.AnswerQuestions(settings);

                if (!response.Result)
                {
                    return await OnError(argument).Result.Advance(argument);
                }
                if (response.Approval)
                {
                    return await OnSuccess(argument).Result.Advance(argument);
                }

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