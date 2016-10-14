using Data.Inalambria.InalambriaService;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface IInalambriaAppService
    {
        string GetTicketKdc();

        string SendSms(string devicenumber, string message, string provider, long executionId);
    }
}