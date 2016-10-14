using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Application.Main.Definition.MyCustomProcessFlow.Steps;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Banlinea.Framework.Notification.EmailProviders.Contracts;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Engine.Api.Steps;
using Core.DataTransferObject.Vib;
using Core.Entities.WsMotor;
using Newtonsoft.Json;
using Xipton.Razor;

namespace Application.Main.Implementation.ProcessFlow.Step
{
    public class SendRequestResponseStep : BaseStep, ISendRequestResponseStep
    {

        public readonly IMailAppService MailAppService;
        private readonly IUserAppService _userAppService;
        private string _razorTemplate;

        public SendRequestResponseStep(IProcessFlowStore store, IMailAppService mailAppService, IUserAppService userAppService) : base(store)
        {
            MailAppService = mailAppService;
            _userAppService = userAppService;
        }

        public async override Task<IProcessFlowResponse> Advance(IProcessFlowArgument argument)
        {
            var userInfo = _userAppService.GetUserInfoByExecutionId(argument.Execution.Id);
            var data = JsonConvert.DeserializeObject<WsMotorServiceResponse>(userInfo.ResponseWsMotor);
            IDictionary<string, string> classification = new Dictionary<string, string>
            {
                {"A", "Aprobada"},
                {"R", "Rechazada"}
            };

            userInfo.ClassificationWsMotor = classification[data.ScoresMotor.ScoreMotor.Classification];
            TraceFlow(argument);

            var email = EmailMessage(userInfo);

            TraceFlow(argument);
            for (var i = 0; i < 2; i++)
            {
                if (MailAppService.SendMail(email))
                    break;
            }

            return await OnSuccess(argument).Result.Advance(argument);
        }

        private EmailMessage EmailMessage(UserInfoDto userInfo)
        {
            var email = new EmailMessage()
            {
                Subject =
                    userInfo.Product == "1" ? "Solicitud Tarjeta de Crédito Colpatria" : "Solicitud cuenta de ahorros Colpatria",
                To = EmailAddress(userInfo),
                Sender = new EmailAddress("Colpatria", ConfigurationManager.AppSettings["From"])
                {
                    Name = "Colpatria",
                    Address = ConfigurationManager.AppSettings["From"]
                },
                Body = TemplateResponseRequest(userInfo)
            };
            return email;
        }

        private static List<EmailAddress> EmailAddress(UserInfoDto userInfo)
        {
            return new List<EmailAddress>()
            {
                new EmailAddress(userInfo.Names, userInfo.Email)
                {
                    Name = userInfo.FullName,
                    Address = userInfo.Email
                }
            };
        }

        public override Task<IProcessFlowResponse> AdvanceAsync(IProcessFlowArgument argument, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new NotImplementedException();
        }

        public string TemplateResponseRequest(UserInfoDto userInfoDto)
        {
            var path = Uri.UnescapeDataString(new UriBuilder(Assembly.GetExecutingAssembly().CodeBase).Path);
            var dir = (Path.GetDirectoryName(path))?.Replace("bin", string.Empty);

            _razorTemplate = userInfoDto.Product == "1" ? Path.Combine(dir, @"Views\Request\EmailRequest.cshtml") 
                : Path.Combine(dir, @"Views\SecondFlowTemp\EmailRequest.cshtml");

            var template = File.ReadAllText(_razorTemplate);
            return new RazorMachine().ExecuteContent(template, userInfoDto, skipLayout: true).Result;
        }
    }
}