#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=EvidenteAppService.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-07  - 2:28 p. m.</Date>
//   <Update> 2016-09-08 - 11:19 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Configuration;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Core.DataTransferObject.WebServiceConsultation;
using Core.Entities.Evidente;
using Core.Entities.Process;
using Core.GlobalRepository.Evidente;
using Core.GlobalRepository.SQL.Process;
using Crosscutting.Common;
using Newtonsoft.Json;

#endregion

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
            AnswerResponse response;
            settings.Channel = ConfigurationManager.AppSettings["EvidenteChannel"];
            settings.ParamProduct = ConfigurationManager.AppSettings["EvidenteParamProduct"];
            settings.Product = ConfigurationManager.AppSettings["EvidenteProduct"];

            var consultation =
                _webSettingsConsultationSettingsBuilder.WithPayload(JsonConvert.SerializeObject(settings))
                    .WithExecutionId(settings.ExecutionId)
                    .WithTypeOfConsultation((int) TypeOfConsultation.Request)
                    .WithWebServiceName(ServiceNameType.Answer.GetStringValue())
                    .Build();

            AddWebServiceConsultation(consultation);
            try
            {
                response = _evidenteRepository.AnswerQuestions(settings);
            }
            catch (Exception exception)
            {
                var consultationException =
                    _webSettingsConsultationSettingsBuilder.WithPayload(
                            JsonConvert.SerializeObject(new {Exception = exception}))
                        .WithExecutionId(settings.ExecutionId)
                        .WithTypeOfConsultation((int) TypeOfConsultation.CommunicationError)
                        .WithWebServiceName("Error consultando " + ServiceNameType.Answer.GetStringValue())
                        .Build();
                AddWebServiceConsultation(consultationException);
                return new AnswerResponse {Result = false};
            }

            var consultationResponse =
                _webSettingsConsultationSettingsBuilder.WithPayload(JsonConvert.SerializeObject(response))
                    .WithExecutionId(settings.ExecutionId)
                    .WithTypeOfConsultation((int) TypeOfConsultation.Response)
                    .WithWebServiceName(ServiceNameType.Answer.GetStringValue())
                    .Build();
            AddWebServiceConsultation(consultationResponse);

            return response;
        }

        public QuestionsResponse GetQuestions(QuestionsSettings settings)
        {
            var mock = settings.Channel = ConfigurationManager.AppSettings["Mock"];
            if (mock == "true")
            {
                return _evidenteRepository.GetQuestions(settings);
            }
            else
            {
                QuestionsResponse response;
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

                try
                {
                    response = _evidenteRepository.GetQuestions(settings);
                }
                catch (Exception exception)
                {
                    var consultationException =
                        _webSettingsConsultationSettingsBuilder.WithPayload(
                                JsonConvert.SerializeObject(new { Exception = exception }))
                            .WithExecutionId(settings.ExecutionId)
                            .WithTypeOfConsultation((int)TypeOfConsultation.CommunicationError)
                            .WithWebServiceName("Error consultando " + ServiceNameType.Questions.GetStringValue())
                            .Build();
                    AddWebServiceConsultation(consultationException);
                    return new QuestionsResponse { Result = "00" };
                }

                var consultationResponse =
                    _webSettingsConsultationSettingsBuilder.WithPayload(JsonConvert.SerializeObject(response))
                        .WithExecutionId(settings.ExecutionId)
                        .WithTypeOfConsultation((int)TypeOfConsultation.Response)
                        .WithWebServiceName(ServiceNameType.Questions.GetStringValue())
                        .Build();
                AddWebServiceConsultation(consultationResponse);

                return response;
            }
        }

        public ValidationResponse Validate(ValidateUserSettings settings)
        {
            ValidationResponse response;
            settings.Channel = ConfigurationManager.AppSettings["EvidenteChannel"];
            settings.ParamProduct = ConfigurationManager.AppSettings["EvidenteParamProduct"];
            settings.Product = ConfigurationManager.AppSettings["EvidenteProduct"];

            var consultation =
                _webSettingsConsultationSettingsBuilder.WithPayload(JsonConvert.SerializeObject(settings))
                    .WithExecutionId(settings.ExecutionId)
                    .WithTypeOfConsultation((int) TypeOfConsultation.Request)
                    .WithWebServiceName(ServiceNameType.Validate.GetStringValue())
                    .Build();

            AddWebServiceConsultation(consultation);

            try
            {
                response = _evidenteRepository.Validate(settings);
            }
            catch (Exception exception)
            {
                var consultationException =
                    _webSettingsConsultationSettingsBuilder.WithPayload(
                            JsonConvert.SerializeObject(new {Exception = exception}))
                        .WithExecutionId(settings.ExecutionId)
                        .WithTypeOfConsultation((int) TypeOfConsultation.CommunicationError)
                        .WithWebServiceName("Error consultando " + ServiceNameType.Validate.GetStringValue())
                        .Build();
                AddWebServiceConsultation(consultationException);
                return new ValidationResponse {ProcessResult = false};
            }
            var consultationResponse =
                _webSettingsConsultationSettingsBuilder.WithPayload(JsonConvert.SerializeObject(response))
                    .WithExecutionId(settings.ExecutionId)
                    .WithTypeOfConsultation((int) TypeOfConsultation.Response)
                    .WithWebServiceName(ServiceNameType.Validate.GetStringValue())
                    .Build();
            AddWebServiceConsultation(consultationResponse);

            return response;
        }

        public void AddWebServiceConsultation(WebServiceConsultationSettings settings)
        {
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