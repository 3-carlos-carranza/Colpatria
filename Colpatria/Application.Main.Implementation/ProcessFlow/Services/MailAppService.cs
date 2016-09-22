using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Banlinea.Framework.Notification.EmailProviders.Contracts;
using Crosscutting.Common;

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

        public bool SendMail(EmailMessage emailMessage)
        {
            //Send Data Mail
            return _emailNotificatorService.SendEmail(new EmailMessage
            {
                Subject = emailMessage.Subject,
                To = emailMessage.To,
                Sender = emailMessage.Sender,
                Body = _mailService.TemplateResponseRequest()
            });
        }
    }
}