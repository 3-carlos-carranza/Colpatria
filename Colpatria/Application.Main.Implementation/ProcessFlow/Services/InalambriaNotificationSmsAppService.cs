//   -----------------------------------------------------------------------
//   <copyright file=InalambriaNotificationSmsAppService.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using System;
using System.Configuration;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Banlinea.ProcessFlow.Model;
using Core.DataTransferObject.WebServiceConsultation;
using Core.Entities.Process;
using Core.GlobalRepository.Inalambria;
using Core.GlobalRepository.SQL.Process;
using Crosscutting.Common.Extensions;
using Microsoft.ApplicationInsights;
using Newtonsoft.Json;

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class InalambriaNotificationSmsAppService : INotificationSmsAppService
    {
        private readonly IInalambriaAuthRepository _inalambriaAuthRepository;
        private readonly IInalambriaRepository _inalambriaRepository;
        private readonly IWebServiceConsultationRepository _webServiceConsultationRepository;
        private readonly WebSettingsConsultationSettingsBuilder _webSettingsConsultationSettingsBuilder;

        public InalambriaNotificationSmsAppService(IInalambriaAuthRepository inalambriaAuthRepository,
            IInalambriaRepository inalambriaRepository,
            IWebServiceConsultationRepository webServiceConsultationRepository,
            WebSettingsConsultationSettingsBuilder webSettingsConsultationSettingsBuilder)
        {
            _inalambriaAuthRepository = inalambriaAuthRepository;
            _inalambriaRepository = inalambriaRepository;
            _webServiceConsultationRepository = webServiceConsultationRepository;
            _webSettingsConsultationSettingsBuilder = webSettingsConsultationSettingsBuilder;
        }

        public ResponseDetailFlow SendSms(string devicenumber, string message, long executionId)
        {
            var vResponseDetailFlow = new ResponseDetailFlow();
            var response = _inalambriaRepository.SendSms(GetTicketKdc(), devicenumber, message,
                ConfigurationManager.AppSettings.Get("InalambriaProvider"));
            try
            {
                //Log Service
                var consultation =
                    _webSettingsConsultationSettingsBuilder.WithPayload(JsonConvert.SerializeObject(response))
                        .WithExecutionId(executionId)
                        .WithTypeOfConsultation((int) TypeOfConsultation.Request)
                        .WithWebServiceName(ServiceNameType.SendSms.GetStringValue())
                        .Build();

                AddWebServiceConsultation(consultation);
                vResponseDetailFlow.Status = ReponseStatus.Success;
                //return response;
            }
            catch (Exception ex)
            {
                //Log Service
                var consultation =
                    _webSettingsConsultationSettingsBuilder.WithPayload(
                            JsonConvert.SerializeObject(new
                            {
                                Exception = ex,
                                response
                            }))
                        .WithExecutionId(executionId)
                        .WithTypeOfConsultation((int) TypeOfConsultation.CommunicationError)
                        .WithWebServiceName(ServiceNameType.SendSms.GetStringValue())
                        .Build();

                AddWebServiceConsultation(consultation);
                vResponseDetailFlow.Status = ReponseStatus.Failure;
                var clientLog = new TelemetryClient();
                clientLog.TrackException(ex);
            }
            return vResponseDetailFlow;
        }

        private string GetTicketKdc()
        {
            return _inalambriaAuthRepository.GetTicketKdc();
        }

        public void AddWebServiceConsultation(WebServiceConsultationSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            var item = new WebServiceConsultation
            {
                Payload = settings.Payload,
                ExecutionId = settings.ExecutionId,
                TypeOfConsultation = settings.TypeOfConsultation,
                WebServiceName = settings.WebServiceName,
                CreatedDate = DateTime.UtcNow.ToLocalTime()
            };
            _webServiceConsultationRepository.Add(item);
        }
    }
}