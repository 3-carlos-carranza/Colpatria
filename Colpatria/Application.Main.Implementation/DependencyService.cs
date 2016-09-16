﻿#region Signature

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
using Application.Main.Definition.ProcessFlow.Api.Steps;
using Application.Main.Implementation.ProcessFlow;
using Application.Main.Implementation.ProcessFlow.Arguments;
using Application.Main.Implementation.ProcessFlow.Services;
using Application.Main.Implementation.ProcessFlow.Step;
using Microsoft.Practices.Unity;
using SubmitFormStep = Application.Main.Implementation.ProcessFlow.Step.SubmitFormStep;

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
            container.RegisterType<IWsMotorAppService, WsMotorAppService>();
            
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
            container.RegisterType<IStep, ShowFormStep>("ShowFormStep");
            container.RegisterType<IStep, SubmitEvidenteStep>("SubmitEvidenteStep");
            container.RegisterType<IStep, SubmitWsMotorStep>("SubmitWsMotorStep");
            container.RegisterType<IStep, ShowAdditionalInformationStep>("ShowAdditionalInformationStep");
            container.RegisterType<IStep, ShowFinishRequestStep>("ShowFinishRequestStep");
            container.RegisterType<IStep, SubmitAdditionalInformationStep>("SubmitAdditionalInformationStep");
            
            

            container.RegisterType<IEnumerable<IStep>, IStep[]>();
        }
    }
}