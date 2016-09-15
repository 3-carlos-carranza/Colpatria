﻿using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Application.Main.Definition.ProcessFlow.Api.Steps;
using Core.Entities.WsMotor;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class SubmitWsMotorStep : BaseStep
    {
        private readonly IWsMotorAppService _wsMotorAppService;
        private readonly PetitionSettingsBuilder _petitionSettingsBuilder;

        public SubmitWsMotorStep(IProcessFlowStore store, IWsMotorAppService wsMotorAppService, PetitionSettingsBuilder petitionSettingsBuilder) : base(store)
        {
            _wsMotorAppService = wsMotorAppService;
            _petitionSettingsBuilder = new PetitionSettingsBuilder();
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            var response = _wsMotorAppService.GetScoreResponse(_petitionSettingsBuilder
                .WithKey("10cuu")
                .WithIdentificaction("59854768")
                .WithLastName("monroy")
                .WithTypeIdentification("1")
                .WithUser("78989767")
                .WithParamsRequest(new[]
                {
                    new Parameters
                    {
                        Type = 'T',
                        Name = "STRAID",
                        Value = "1550"
                    },
                    new Parameters
                    {
                        Type = 'T',
                        Name = "STRNAM",
                        Value = "Billing_Strategy"
                    },
                    new Parameters
                    {
                        Type = 'A',
                        Name = "facturarAciertaCod",
                        Value = "true"
                    },
                    new Parameters
                    {
                        Type = 'B',
                        Name = "facturarQuantoMinimoCod",
                        Value = "true"
                    },
                    new Parameters
                    {
                        Type = 'C',
                        Name = "facturarQuantoMaximoCod",
                        Value = "true"
                    },
                    new Parameters
                    {
                        Type = 'R',
                        Name = "_edad",
                        Value = "30"
                    }
                }).Build());

            //Metodo para validar la respuesta devuelta - Score

            return await OnSucess(argument).Result.Advance(argument);
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}