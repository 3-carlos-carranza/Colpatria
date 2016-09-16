using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow.Steps;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Application.Main.Definition.ProcessFlow.Api.Steps;
using Application.Main.Implementation.ProcessFlow.Arguments;
using Application.Main.Implementation.ProcessFlow.Services;
using Core.Entities.WsMotor;
using Crosscutting.Common.Tools.DataType;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class SubmitWsMotorStep : BaseStep, ISubmitWsMotorStep
    {
        private readonly IWsMotorAppService _wsMotorAppService;
        private readonly PetitionSettingsBuilder _petitionSettingsBuilder;
        private readonly ISaveFieldsAppService _saveFieldsAppService;

        public SubmitWsMotorStep(IProcessFlowStore store, 
            IWsMotorAppService wsMotorAppService,
            PetitionSettingsBuilder petitionSettingsBuilder,
            ISaveFieldsAppService saveFieldsAppService)
            : base(store)
        {
            _wsMotorAppService = wsMotorAppService;
            _saveFieldsAppService = saveFieldsAppService;
            _petitionSettingsBuilder = new PetitionSettingsBuilder();
        }

        public override async Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            #region var response = _wsMotorAppService.GetScoreResponse(_petitionSettingsBuilder

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

            #endregion

            //Metodo para validar la respuesta devuelta - Score Validado
            _wsMotorAppService.ValidateScore(response);

            //Guardar en base de datos la respuesta del score
            //var saveFieldsAppService = argument as ProcessFlowArgument;
            //saveFieldsAppService?.Form.Add(new FieldValueOrder { Key = "30", Value = "Aprobada" });
            //_saveFieldsAppService.SaveForm(saveFieldsAppService);

            return await OnSucess(argument).Result.Advance(argument);
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument,
            CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}






