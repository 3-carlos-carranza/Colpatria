using System;
using System.Configuration;
using Core.GlobalRepository.Inalambria;
using Data.Inalambria.InalambriaAuthService;
using Microsoft.ApplicationInsights;

namespace Data.Inalambria
{
    public class InalambriaAuthRepository : ServiceKDC, IInalambriaAuthRepository
    {
        public string GetTicketKdc()
        {
            try
            {
                var pass = ASGeneratePassword(ConfigurationManager.AppSettings["UserToolSend"], "true");
                var ticket = GetCrypto(pass.Ticket, ConfigurationManager.AppSettings["PassToolSend"]);
                var password = GetCrypto(pass.Password, ConfigurationManager.AppSettings["PassToolSend"]);

                var ticketTgs = SetCrypto(ticket, password);

                return ASGenerateTicket(ticketTgs);
            }
            catch (Exception exception)
            {
                var clientLog = new TelemetryClient();
                clientLog.TrackException(exception);
                return string.Empty;
            }
        }
    }
}