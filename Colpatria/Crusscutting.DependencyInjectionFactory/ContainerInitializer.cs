using Data.MongoModule;
using Microsoft.Practices.Unity;

namespace Crusscutting.DependencyInjectionFactory
{
    public static class ContainerInitializer
    {
        public static void InitializeContainer(this IUnityContainer container)
        {
            container.InitializeMongoRepository();
        }
    }
}
