﻿using Application.Main.Definition.MyCustomProcessFlow.Steps;
using Application.Main.Implementation.ProcessFlow.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;
using Banlinea.ProcessFlow.Model;
using Core.DataTransferObject.Vib;
using Core.Entities.Enumerations;
using Core.Entities.WsMotor;
using Core.GlobalRepository.SQL.User;
using Crosscutting.Common.Extensions;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class ShowFinishRequestStep : BaseStep, IShowFinishRequestStep
    {
        private readonly IUserRepository _userRepository;

        public ShowFinishRequestStep(IProcessFlowStore store,
            IUserRepository userRepository)
            : base(store)
        {
            _userRepository = userRepository;
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            //Obtener respuesta de WsMotor
            var userInfo = _userRepository.GetUserInfoByExecutionId(argument.Execution.Id);
            var data = JsonConvert.DeserializeObject<WsMotorServiceResponse>(userInfo.ResponseWsMotor);

            userInfo.ClassificationWsMotor = data.ScoresMotor.ScoreMotor.Classification == "A"
                ? Classification.Approved.GetStringValue()
                : Classification.Declined.GetStringValue();

            TraceFlow(argument);
            var step = (StepDetail)GetCurrentStep(argument);
            if (!argument.IsSubmitting)
            {
                return new RequestResponse
                {
                    Name = userInfo.Names,
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

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }
    }
}