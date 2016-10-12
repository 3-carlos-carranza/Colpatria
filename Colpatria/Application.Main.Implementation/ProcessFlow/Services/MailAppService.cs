using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Banlinea.Framework.Notification.EmailProviders.Contracts;

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