using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Core.Entities.WsMotor;

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class WsMotorAppService : IWsMotorAppService
    {
        private readonly PetitionSettingsBuilder _petitionSettingsBuilder;

        public WsMotorAppService(PetitionSettingsBuilder petitionSettingsBuilder)
        {
            _petitionSettingsBuilder = new PetitionSettingsBuilder();
        }

        public ScoreResponse GetScoreResponse(Petition petition)
        {
            var response = _petitionSettingsBuilder
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
                });

            return new ScoreResponse()
            {
                
            };
        }
    }
}