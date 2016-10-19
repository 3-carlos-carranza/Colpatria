using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Core.DataTransferObject.WebServiceConsultation;
using Core.Entities.Process;
using Core.Entities.WsMotor;
using Core.GlobalRepository.SQL.Process;
using Core.GlobalRepository.WsMotor;
using Crosscutting.Common.Extensions;
using Newtonsoft.Json;
using System;
using System.Configuration;

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class WsMotorAppService : IWsMotorAppService
    {
        private readonly IWebServiceConsultationRepository _webServiceConsultationRepository;
        private readonly IWsMotorRepository _wsMotorRepository;
        private readonly WebSettingsConsultationSettingsBuilder _webSettingsConsultationSettingsBuilder;

        public WsMotorAppService(IWebServiceConsultationRepository webServiceConsultationRepository, IWsMotorRepository wsMotorRepository)
        {
            _webServiceConsultationRepository = webServiceConsultationRepository;
            _wsMotorRepository = wsMotorRepository;
            _webSettingsConsultationSettingsBuilder = new WebSettingsConsultationSettingsBuilder();
        }

        public WsMotorServiceResponse Validate(WsMotorRequest wsMotorRequest)
        {
            if (wsMotorRequest == null) throw new ArgumentNullException(nameof(wsMotorRequest));
            
                wsMotorRequest.UsertNit = ConfigurationManager.AppSettings["WsMotorUserNit"];
                wsMotorRequest.UserType = ConfigurationManager.AppSettings["WsMotorUserType"];
                wsMotorRequest.User = ConfigurationManager.AppSettings["WsMotorUser"];

                var consultation =
                _webSettingsConsultationSettingsBuilder.WithPayload(JsonConvert.SerializeObject(wsMotorRequest))
                    .WithExecutionId(wsMotorRequest.ExecutionId)
                    .WithTypeOfConsultation((int)TypeOfConsultation.Request)
                    .WithWebServiceName(ServiceNameType.WsMotorValidate.GetStringValue())
                    .Build();

                AddWebServiceConsultation(consultation);

                var response = _wsMotorRepository.Validate(wsMotorRequest);
                var consultationResponse =
                _webSettingsConsultationSettingsBuilder.WithPayload(JsonConvert.SerializeObject(response))
                    .WithExecutionId(wsMotorRequest.ExecutionId)
                    .WithTypeOfConsultation((int)TypeOfConsultation.Response)
                    .WithWebServiceName(ServiceNameType.WsMotorValidate.GetStringValue())
                    .Build();
                AddWebServiceConsultation(consultationResponse);
                return response;
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
                CreatedDate = DateTime.UtcNow
            };
            _webServiceConsultationRepository.Add(item);
        }
    }
}