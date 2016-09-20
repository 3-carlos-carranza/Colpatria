using Banlinea.Framework.Notification.EmailProviders.Contracts;

namespace Crosscutting.Common
{
    public interface IMailService : IEmailNotificatorService
    {
        string TemplateResponseRequest();
    }
}