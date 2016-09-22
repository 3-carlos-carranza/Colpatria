using Banlinea.Framework.Notification.EmailProviders.Contracts;
using Core.DataTransferObject.Vib;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface IMailAppService
    {
        bool SendMail(EmailMessage emailMessage);
    }
}