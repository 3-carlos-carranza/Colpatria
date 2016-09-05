using Application.Main.Definition;
using Application.Main.Implementation;
using Microsoft.Practices.Unity;

namespace Presentation.Web.Common
{
    public static class HelperDependencyService
    {
        public static void InitializeAppService(this IUnityContainer container)
        {
            container.RegisterType<ILoggingAppService, LoggingAppService>();
            container.RegisterType<IEvidenteAppService, EvidenteAppService>();
        }
    }
}