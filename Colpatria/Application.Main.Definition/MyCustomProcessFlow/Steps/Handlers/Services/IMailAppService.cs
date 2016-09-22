using Banlinea.Framework.Notification.EmailProviders.Contracts;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface IMailAppService
    {
        bool SendMail(EmailMessage emailMessage);
    }
}