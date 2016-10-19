using Banlinea.ProcessFlow.Model;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface INotificationSmsAppService
    {
        ResponseDetailFlow SendSms(string devicenumber, string message, long executionId);
    }
}