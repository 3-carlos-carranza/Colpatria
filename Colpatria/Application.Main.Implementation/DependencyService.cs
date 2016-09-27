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
using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Application.Main.Implementation.ProcessFlow;
using Application.Main.Implementation.ProcessFlow.Arguments;
using Application.Main.Implementation.ProcessFlow.Services;
using Application.Main.Implementation.ProcessFlow.Step;
using Banlinea.Framework.Notification.EmailProviders.Contracts;
using Banlinea.ProcessFlow.Engine.Api;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.Steps;
using Crosscutting.Common;
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
            container.RegisterType<IMailAppService, MailAppService>();
            container.RegisterType<IEmailNotificatorService, MailService>();
            
            container.RegisterType<IResponseRequestAppService, ResponseRequestAppService>();
            container.RegisterType<IDynamicAppService, DynamicAppService>();
            container.RegisterType<ISubmitFormArgument, ProcessFlowArgument>();
            container.RegisterType<IAnswerQuestionArgument, ProcessFlowArgument>();

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
            container.RegisterType<IStep, ErrorEvidenteStep>("ErrorEvidenteStep");
            container.RegisterType<IStep, ShowFormStep>("ShowFormStep");
            container.RegisterType<IStep, SubmitEvidenteStep>("SubmitEvidenteStep");
            container.RegisterType<IStep, SubmitWsMotorStep>("SubmitWsMotorStep");
            container.RegisterType<IStep, ShowAdditionalInformationStep>("ShowAdditionalInformationStep");
            container.RegisterType<IStep, ShowFinishRequestStep>("ShowFinishRequestStep");
            container.RegisterType<IStep, SubmitAdditionalInformationStep>("SubmitAdditionalInformationStep");
            container.RegisterType<IStep, SendRequestResponseStep>("SendRequestResponseStep");
            container.RegisterType<IStep, ShowDataSummaryStep>("ShowDataSummaryStep");

            container.RegisterType<IEnumerable<IStep>, IStep[]>();
        }
    }
}