using System.Collections.Generic;
using Application.Main.Definition;
using Application.Main.Definition.Arguments;
using Application.Main.Definition.Services;
using Application.Main.Definition.Steps;
using Application.Main.Implementation;
using Application.Main.Implementation.ProcessFlow;
using Application.Main.Implementation.ProcessFlow.Arguments;
using Application.Main.Implementation.ProcessFlow.Services;
using Application.Main.Implementation.ProcessFlow.Step;
using Microsoft.Practices.Unity;

namespace Presentation.Web.Common
{
    public static class HelperDependencyService
    {
        public static void InitializeAppService(this IUnityContainer container)
        {
            container.RegisterType<IUserAppService, UserAppService>();
            container.RegisterType<ILoggingAppService, LoggingAppService>();
            container.RegisterType<IDynamicAppService, DynamicAppService>();

            //Process
            container.RegisterType<ISubmitFormArgument, SubmitFormArgument>();
            container.RegisterType<IProcessFlowArgument, ProcessFlowArgument>();
            container.RegisterType<IProcessFlowService, ProcessFlowService>();
            container.RegisterType<ISubmitFormAppService, SubmitFormAppService>();

            //Config Steps
            container.RegisterType<IStep, EvidenteStep>("EvidenteStep");
            container.RegisterType<IStep, SubmitFormStep>("SubmitFormStep");
            container.RegisterType<IStep, StartFlowStep>("StartFlowStep");
            container.RegisterType<IEnumerable<IStep>, IStep[]>();

        }
    }
}