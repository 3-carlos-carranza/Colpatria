using Core.GlobalRepository.Evidente;
using Microsoft.Practices.Unity;

namespace Data.DataCredito
{
    public static class MongoDependencyRepository
    {
        public static void InitializeDataCreditoRepository(this IUnityContainer container)
        {
            container.RegisterType<IEvidenteRepository, EvidenteRepository>();
        }
    }
}