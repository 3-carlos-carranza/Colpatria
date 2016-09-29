using Core.Entities.WsMotor;

namespace Core.GlobalRepository.WsMotor
{
    public interface IWsMotorRepository
    {
        WsMotorServiceResponse Validate(WsMotorRequest wsMotorRequest);
    }
}
