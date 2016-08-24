using Data.MongoModule;
using Microsoft.Practices.Unity;
using Presentation.Web.Common;

namespace Crusscutting.DependencyInjectionFactory
{
    public static class ContainerInitializer
    {
        public static void InitializeContainer(this IUnityContainer container)
        {
            container.InitializeMongoRepository();
            container.InitializeAppService();
        }
    }
}
 