#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=DependencyService.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 12:29 p. m.</Date>
//   <Update> 2016-09-08 - 12:31 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Application.Main.Definition.ProcessFlow.Api;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows;
using Application.Main.Implementation.ProcessFlow;
using Application.Main.Implementation.ProcessFlow.Arguments;
using Application.Main.Implementation.ProcessFlow.Services;
using Application.Main.Implementation.ProcessFlow.Step;
using Microsoft.Practices.Unity;

#endregion

namespace Application.Main.Implementation
{
    public static class DependencyService
    {
        public static void InitializeAppService(this IUnityContainer container)
        {
            container.RegisterType<IUserAppService, UserAppService>();
            container.RegisterType<ILoggingAppService, LoggingAppService>();
            container.RegisterType<IEvidenteAppService, EvidenteAppService>();
            
            container.RegisterType<IResponseRequestAppService, ResponseRequestAppService>();
            container.RegisterType<IDynamicAppService, DynamicAppService>();

            //Process
            container.RegisterType<IProcessFlowManager, ColpatriaProcessFlowManager>();
            container.RegisterType<IProcessFlowArgument, ProcessFlowArgument>();
            container.RegisterType<IProcessFlowStore, CustomProcessFlowStore>();
            container.RegisterType<IProcessAppService, ProcessAppService>();
            container.RegisterType<ISaveFieldsAppService, SaveFieldsAppService>();

            //Config Steps
            container.RegisterType<IStep, StartFlowStep>("StartFlowStep");
            container.RegisterType<IStep, SubmitFormStep>("SubmitFormStep");
            container.RegisterType<IStep, ShowEvidenteStep>("ShowEvidenteStep");
            container.RegisterType<IStep, SubmitEvidenteStep>("SubmitEvidenteStep");
            container.RegisterType<IStep, ResponseRequestStep>("ResponseRequestStep");
            container.RegisterType<IStep, WsMotorStep>("WsMotorStep");

            container.RegisterType<IEnumerable<IStep>, IStep[]>();
        }
    }
}