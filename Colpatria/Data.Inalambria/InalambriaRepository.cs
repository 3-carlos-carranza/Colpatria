using Core.GlobalRepository.Inalambria;
using Data.Inalambria.InalambriaService;
using Newtonsoft.Json;


namespace Data.Inalambria
{
    public class InalambriaRepository : ServiceSend, IInalambriaRepository
    {
        public string SendSms(string tickettgs, string devicenumber, string message, string provider)
        {
            return JsonConvert.SerializeObject(Send(tickettgs, devicenumber, message, null, provider));
        }
    }
}