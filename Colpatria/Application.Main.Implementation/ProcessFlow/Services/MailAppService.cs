using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Banlinea.Framework.Notification.EmailProviders.Contracts;
using Crosscutting.Common;
using Xipton.Razor;

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class MailAppService : IMailAppService
    {

        private readonly IEmailNotificatorService _emailNotificatorService;
        private readonly IMailService _mailService;

        public MailAppService(IEmailNotificatorService emailNotificatorService, IMailService mailService)
        {
            _emailNotificatorService = emailNotificatorService;
            _mailService = mailService;
        }

        public bool SendMail()
        {

            var razorTemplate = _mailService.TemplateResponseRequest();
            var template = File.ReadAllText(razorTemplate);
            var html = new RazorMachine().ExecuteContent(template).Result;

            //Get Data
            var optionList = new List<EmailAddress>
            {
                new EmailAddress("Carlos Carranza", "carlosscarranza@yahoo.com")
                {
                    Name = "Carlos Carranza",
                    Address = "carlosscarranza@yahoo.com"
                }
            };

            //Send Data Mail
            return _emailNotificatorService.SendEmail(new EmailMessage()
            {
                
                Subject = "carlosscarranza@yahoo.com",
                To = optionList,
                Body = html,
                
                Sender = new EmailAddress()
                {
                    Name = "Carlos Carranza",
                    Address = "carlos.carranza@banlinea.com"
                }, 
            });
        }
    }
}