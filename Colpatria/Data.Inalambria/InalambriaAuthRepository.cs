using System.Configuration;
using Core.GlobalRepository.Inalambria;
using Data.Inalambria.InalambriaAuthService;

namespace Data.Inalambria
{
    public class InalambriaAuthRepository : ServiceKDC, IInalambriaAuthRepository
    {
        public string GetTicketKdc()
        {
            //1
            ASResponse pass =  ASGeneratePassword(ConfigurationManager.AppSettings["UserToolSend"], "true");

            //2
            string ticket = GetCrypto(pass.Ticket, ConfigurationManager.AppSettings["PassToolSend"]); 
            string password = GetCrypto(pass.Password, ConfigurationManager.AppSettings["PassToolSend"]);
            string flag = GetCrypto(pass.Flag, ConfigurationManager.AppSettings["PassToolSend"]);

            //3 retorna un XML 
            string ticketTgs = SetCrypto(ticket, password);

            //4
            return ASGenerateTicket(ticketTgs);
        }
    }
}