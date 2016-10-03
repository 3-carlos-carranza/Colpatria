using Core.GlobalRepository.Inalambria;
using Data.Inalambria.InalambriaService;

namespace Data.Inalambria
{
    public class InalambriaRepository : ServiceSend, IInalambriaRepository
    {
        public bool SendSms(string tickettgs, string devicenumber, string message, string provider)
        {
            return (Send(tickettgs, devicenumber, message, null, provider)).Status;
        }
    }
}