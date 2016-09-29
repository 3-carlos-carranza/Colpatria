using Core.Entities.WsMotor;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface IWsMotorAppService
    {
        WsMotorServiceResponse Validate(WsMotorRequest wsMotorRequest);
    }
}