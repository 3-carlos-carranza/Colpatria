using System;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Application.Main.Implementation.ProcessFlow.Responses;
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
            return new ScoreResponse();
        }

        public IWsMotorResponse ValidateScore(ScoreResponse petition)
        {
            return new WsMotorResponse();
        }
    }
}