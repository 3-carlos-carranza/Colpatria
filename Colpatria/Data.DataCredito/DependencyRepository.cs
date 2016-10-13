using Core.GlobalRepository.Evidente;
using Core.GlobalRepository.WsMotor;
using Microsoft.Practices.Unity;

namespace Data.DataCredito
{
    public static class DependencyRepository
    {
        public static void InitializeDataCreditoRepository(this IUnityContainer container)
        {
            container.RegisterType<IEvidenteRepository, EvidenteRepository>();
            container.RegisterType<IWsMotorRepository, WsMotorRepository>();
        }
    }
}