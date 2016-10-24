using Core.Entities.WsMotor;
using Core.GlobalRepository.WsMotor;
using Crosscutting.Common.Tools.XmlUtilities;
using Data.DataCredito.WsMotorService;
using Microsoft.ApplicationInsights;
using System;
using System.Configuration;

namespace Data.DataCredito
{
    public class WsMotorRepository : ServicioMotorService, IWsMotorRepository
    {
        private readonly XmlProcessor _xmlProcessor;

        public WsMotorRepository()
        {
            _xmlProcessor = new XmlProcessor();
        }

        public WsMotorServiceResponse Validate(WsMotorRequest wsMotorRequest)
        {
            if (wsMotorRequest == null) throw new ArgumentNullException(nameof(wsMotorRequest));
            var mock = bool.Parse(ConfigurationManager.AppSettings.Get("Mock"));
            if (!mock)
            {
                try
                {
                    wsMotorRequest.Parameters.Parameter.Add(new Parameter
                    {
                        Name = "STRAID",
                        Type = "T",
                        Value = "2600"
                    });
                    wsMotorRequest.Parameters.Parameter.Add(new Parameter
                    {
                        Name = "STRNAM",
                        Type = "T",
                        Value = "SuperSymmetry"
                    });
                    var serialized = _xmlProcessor.Serialize(wsMotorRequest);
                    var response = executeStrategy(serialized);
                    var deserialized = _xmlProcessor.Deserialize<WsMotorServiceResponse>(response);
                    return deserialized;
                }
                catch (Exception exception)
                {
                    var clientLog = new TelemetryClient();
                    clientLog.TrackException(exception);
                    return new WsMotorServiceResponse
                    {
                        ScoresMotor = new ScoresMotor
                        {
                            ScoreMotor = new ScoreMotor
                            {
                                Type = "10",
                                Score = "0.0",
                                Classification = "N"
                            }
                        }
                    };
                }
            }
            return new WsMotorServiceResponse
            {
                ScoresMotor = new ScoresMotor
                {
                    ScoreMotor = new ScoreMotor
                    {
                        Type = "10",
                        Score = "0.0",
                        Classification = "A"
                    }
                }
            };
        }
    }
}