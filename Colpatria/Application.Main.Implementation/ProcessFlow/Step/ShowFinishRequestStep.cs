﻿using System;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;

using Application.Main.Implementation.ProcessFlow.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;
using Banlinea.ProcessFlow.Model;
using Core.DataTransferObject.Vib;

using MessageClassification = Application.Main.Definition.Enumerations.MessageClassification;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class ShowFinishRequestStep : BaseStep
    {
        private readonly IResponseRequestAppService _responseRequestAppService;

        public ShowFinishRequestStep(IProcessFlowStore store, IResponseRequestAppService responseRequestAppService) : base(store)
        {
            _responseRequestAppService = responseRequestAppService;
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            var step = (StepDetail)GetCurrentStep(argument);
            //var name = _responseRequestAppService.Get();
            var response = new RequestResponse
            {
                Name = "Carlos Carranza",
                DateOfExpedition = DateTime.UtcNow,
                MessageClassification = MessageClassification.Approved,
                IsResponsePersonalized = false,

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

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}