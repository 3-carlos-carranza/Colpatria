using Data.MongoModule;
using DataAccess.ProcessModule;
using DataAccess.UserModule;
using Microsoft.Practices.Unity;
using Presentation.Web.Common;

namespace Crosscutting.DependencyInjectionFactory
{
    public static class ContainerInitializer
    {
        public static void InitializeContainer(this IUnityContainer container)
        {
            container.InitializeProcessRepository();
            container.InitializeUserRepository();
            container.InitializeMongoRepository();
            container.InitializeAppService();
        }
    }
}