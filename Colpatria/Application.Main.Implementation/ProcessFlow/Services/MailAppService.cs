using System;
using System.IO;
using System.Reflection;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Banlinea.Framework.Notification.EmailProviders.Contracts;
using Core.DataTransferObject.Vib;
using Crosscutting.Common;
using Xipton.Razor;

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class MailAppService : IMailAppService
    {
        private readonly IEmailNotificatorService _emailNotificatorService;

        public MailAppService(IEmailNotificatorService emailNotificatorService)
        {
            _emailNotificatorService = emailNotificatorService;
        }

        public bool SendMail(EmailMessage emailMessage)
        {
            //Send Data Mail
            return _emailNotificatorService.SendEmail(emailMessage);
        }
    }
}