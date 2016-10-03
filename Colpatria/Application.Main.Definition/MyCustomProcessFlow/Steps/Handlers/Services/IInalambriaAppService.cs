namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface IInalambriaAppService
    {
        string GetTicketKdc();

        bool SendSms(string devicenumber, string message, string provider);
    }
}