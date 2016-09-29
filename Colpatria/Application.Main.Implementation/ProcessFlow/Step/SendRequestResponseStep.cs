﻿using System;
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

            var email = new EmailMessage()
            {
                Subject = "Colpatria - Respuesta de la solicitud",
                To = EmailAddress(userInfo),
                Sender = new EmailAddress("Colpatria", "carlos.carranza@banlinea.com")
                {
                    Name = "Colpatria",
                    Address = "carlos.carranza@banlinea.com"
                },
                Body = TemplateResponseRequest(userInfo)
            };

            TraceFlow(argument);
            //Intentos
            for (var i = 0; i < 2; i++)
            {
                if (MailAppService.SendMail(email))
                    break;
            }

            return await OnSuccess(argument).Result.Advance(argument);
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
            throw new System.NotImplementedException();
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