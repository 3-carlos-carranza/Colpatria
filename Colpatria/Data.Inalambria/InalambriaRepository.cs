using System;
using Core.GlobalRepository.Inalambria;
using Data.Inalambria.InalambriaService;
using Microsoft.ApplicationInsights;
using Newtonsoft.Json;

namespace Data.Inalambria
{
    public class InalambriaRepository : ServiceSend, IInalambriaRepository
    {
        public string SendSms(string tickettgs, string devicenumber, string message, string provider)
        {
            try
            {
                return JsonConvert.SerializeObject(Send(tickettgs, devicenumber, message, null, provider));
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