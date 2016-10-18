using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Core.DataTransferObject.WebServiceConsultation;
using Core.Entities.Evidente;
using Core.Entities.Process;
using Core.GlobalRepository.Evidente;
using Core.GlobalRepository.SQL.Process;
using Crosscutting.Common.Extensions;
using Newtonsoft.Json;
using System;
using System.Configuration;

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class EvidenteAppService : IEvidenteAppService
    {
        private readonly IEvidenteRepository _evidenteRepository;
        private readonly IWebServiceConsultationRepository _webServiceConsultationRepository;
        private readonly WebSettingsConsultationSettingsBuilder _webSettingsConsultationSettingsBuilder;

        public EvidenteAppService(IEvidenteRepository evidenteRepository,
            IWebServiceConsultationRepository webServiceConsultationRepository)
        {
            _evidenteRepository = evidenteRepository;
            _webServiceConsultationRepository = webServiceConsultationRepository;
            _webSettingsConsultationSettingsBuilder = new WebSettingsConsultationSettingsBuilder();
        }

        public AnswerResponse AnswerQuestions(AnswerSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            
                settings.Channel = ConfigurationManager.AppSettings["EvidenteChannel"];
                settings.ParamProduct = ConfigurationManager.AppSettings["EvidenteParamProduct"];
                settings.Product = ConfigurationManager.AppSettings["EvidenteProduct"];

                var consultation =
                    _webSettingsConsultationSettingsBuilder.WithPayload(JsonConvert.SerializeObject(settings))
                        .WithExecutionId(settings.ExecutionId)
                        .WithTypeOfConsultation((int)TypeOfConsultation.Request)
                        .WithWebServiceName(ServiceNameType.Answer.GetStringValue())
                        .Build();

                AddWebServiceConsultation(consultation);

                var response = _evidenteRepository.AnswerQuestions(settings);
                var consultationResponse =
                _webSettingsConsultationSettingsBuilder.WithPayload(JsonConvert.SerializeObject(response))
                    .WithExecutionId(settings.ExecutionId)
                    .WithTypeOfConsultation((int)TypeOfConsultation.Response)
                    .WithWebServiceName(ServiceNameType.Answer.GetStringValue())
                    .Build();
                AddWebServiceConsultation(consultationResponse);
               return response;
        }
        public QuestionsResponse GetQuestions(QuestionsSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            
                settings.Channel = ConfigurationManager.AppSettings["EvidenteChannel"];
                settings.ParamProduct = ConfigurationManager.AppSettings["EvidenteParamProduct"];
                settings.Product = ConfigurationManager.AppSettings["EvidenteProduct"];

                var consultation =
                    _webSettingsConsultationSettingsBuilder.WithPayload(JsonConvert.SerializeObject(settings))
                        .WithExecutionId(settings.ExecutionId)
                        .WithTypeOfConsultation((int)TypeOfConsultation.Request)
                        .WithWebServiceName(ServiceNameType.Questions.GetStringValue())
                        .Build();

                AddWebServiceConsultation(consultation);
                var response = _evidenteRepository.GetQuestions(settings);

                var consultationResponse =
                    _webSettingsConsultationSettingsBuilder.WithPayload(JsonConvert.SerializeObject(response))
                        .WithExecutionId(settings.ExecutionId)
                        .WithTypeOfConsultation((int)TypeOfConsultation.Response)
                        .WithWebServiceName(ServiceNameType.Questions.GetStringValue())
                        .Build();
                AddWebServiceConsultation(consultationResponse);
                return response;
        }
        public ValidationResponse Validate(ValidateUserSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
                settings.Channel = ConfigurationManager.AppSettings["EvidenteChannel"];
                settings.ParamProduct = ConfigurationManager.AppSettings["EvidenteParamProduct"];
                settings.Product = ConfigurationManager.AppSettings["EvidenteProduct"];

                var consultation =
                    _webSettingsConsultationSettingsBuilder.WithPayload(JsonConvert.SerializeObject(settings))
                        .WithExecutionId(settings.ExecutionId)
                        .WithTypeOfConsultation((int)TypeOfConsultation.Request)
                        .WithWebServiceName(ServiceNameType.Validate.GetStringValue())
                        .Build();

                AddWebServiceConsultation(consultation);

                var response = _evidenteRepository.Validate(settings);
                var consultationResponse =
               _webSettingsConsultationSettingsBuilder.WithPayload(JsonConvert.SerializeObject(response))
                   .WithExecutionId(settings.ExecutionId)
                   .WithTypeOfConsultation((int)TypeOfConsultation.Response)
                   .WithWebServiceName(ServiceNameType.Validate.GetStringValue())
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