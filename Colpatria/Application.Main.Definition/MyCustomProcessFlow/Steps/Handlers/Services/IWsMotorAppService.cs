using Core.Entities.WsMotor;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface IWsMotorAppService
    {
        ScoreResponse GetScoreResponse(Petition petition);
    }
}