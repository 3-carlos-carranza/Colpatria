using System;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Core.DataTransferObject.WebServiceConsultation;
using Core.Entities.Process;
using Core.GlobalRepository.Inalambria;
using Core.GlobalRepository.SQL.Process;
using Crosscutting.Common;
using Newtonsoft.Json;

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class InalambriaAppService : IInalambriaAppService
    {
        private readonly IInalambriaAuthRepository _inalambriaAuthRepository;
        private readonly IInalambriaRepository _inalambriaRepository;
        private readonly IWebServiceConsultationRepository _webServiceConsultationRepository;
        private readonly WebSettingsConsultationSettingsBuilder _webSettingsConsultationSettingsBuilder;

        public InalambriaAppService(IInalambriaAuthRepository inalambriaAuthRepository,
            IInalambriaRepository inalambriaRepository,
            WebSettingsConsultationSettingsBuilder webSettingsConsultationSettingsBuilder,
            IWebServiceConsultationRepository webServiceConsultationRepository)
        {
            _inalambriaAuthRepository = inalambriaAuthRepository;
            _inalambriaRepository = inalambriaRepository;
            _webSettingsConsultationSettingsBuilder = webSettingsConsultationSettingsBuilder;
            _webServiceConsultationRepository = webServiceConsultationRepository;
        }

        public string GetTicketKdc()
        {
            return _inalambriaAuthRepository.GetTicketKdc();
        }

        public string SendSms(string devicenumber, string message, string provider, long executionId)
        {
            var response = (_inalambriaRepository.SendSms(GetTicketKdc(), devicenumber, message, provider));
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
                return response;
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
                        .WithTypeOfConsultation((int)TypeOfConsultation.CommunicationError)
                        .WithWebServiceName(ServiceNameType.SendSms.GetStringValue())
                        .Build();

                AddWebServiceConsultation(consultation);
                return response;
            }
        }

        public void AddWebServiceConsultation(WebServiceConsultationSettings settings)
        {
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