using Core.GlobalRepository.Inalambria;
using Microsoft.Practices.Unity;

namespace Data.Inalambria
{
    public static class DataInalambriaDependencies
    {
        public static void InitializeDataInalambriaRepository(this IUnityContainer container)
        {
            container.RegisterType<IInalambriaAuthRepository, InalambriaAuthRepository>();
            container.RegisterType<IInalambriaRepository, InalambriaRepository>();
        }
    }
}