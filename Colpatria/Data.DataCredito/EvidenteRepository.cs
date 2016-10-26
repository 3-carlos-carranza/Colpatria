using Core.DataTransferObject.WebServiceConsultation;
using Core.Entities.Evidente;
using Core.Entities.Process;
using Core.GlobalRepository.Evidente;
using Core.GlobalRepository.SQL.Process;
using Crosscutting.Common.Extensions;
using Crosscutting.Common.Tools.XmlUtilities;
using Data.DataCredito.EvidenteService;
using Microsoft.ApplicationInsights;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;

namespace Data.DataCredito
{
    public class EvidenteRepository : ServicioIdentificacion, IEvidenteRepository
    {
        private readonly IWebServiceConsultationRepository _webServiceConsultationRepository;
        private readonly XmlProcessor _xmlProcessor;
        private readonly WebSettingsConsultationSettingsBuilder _webSettingsConsultationSettingsBuilder;

        public EvidenteRepository(IWebServiceConsultationRepository webServiceConsultationRepository)
        {
            _webServiceConsultationRepository = webServiceConsultationRepository;
            _webSettingsConsultationSettingsBuilder = new WebSettingsConsultationSettingsBuilder();
            _xmlProcessor = new XmlProcessor();
            var username = ConfigurationManager.AppSettings["EvidenteUsername"];
            var password = ConfigurationManager.AppSettings["EvidentePassword"];
            this.SetNetworkCredentials(username, password);
            RequestEncoding = Encoding.UTF8;
        }

        public AnswerResponse AnswerQuestions(AnswerSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            try
            {
                settings.AnswerRequest.Identification = new Identification
                {
                    Number = settings.Identification,
                    Type = settings.IdentificationType
                };

                var serialized = _xmlProcessor.Serialize(settings.AnswerRequest);

                var response = verificar(settings.Product, settings.ParamProduct, serialized);

                var deserialized = _xmlProcessor.Deserialize<AnswerResponse>(response);

                return deserialized;
            }
            catch (Exception exception)
            {
                var clientLog = new TelemetryClient();
                clientLog.TrackException(exception);
                var consultationException =
                    _webSettingsConsultationSettingsBuilder.WithPayload(
                        JsonConvert.SerializeObject(new { Exception = exception }))
                        .WithExecutionId(settings.ExecutionId)
                        .WithTypeOfConsultation((int)TypeOfConsultation.CommunicationError)
                        .WithWebServiceName("Error consultando " + ServiceNameType.Answer.GetStringValue())
                        .Build();
                AddWebServiceConsultation(consultationException);

                return new AnswerResponse { Result = false };
            }
        }

        public QuestionsResponse GetQuestions(QuestionsSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            var mock = bool.Parse(ConfigurationManager.AppSettings.Get("Mock"));
            if (!mock)
            {
                try
                {
                    var questionsRequest = new QuestionsRequest
                    {
                        Identification = settings.Identification,
                        IdentificationType = settings.IdentificationType,
                        ValidationNumber = settings.ValidationNumber
                    };

                    var serialized = _xmlProcessor.Serialize(questionsRequest);

                    var response = preguntas(settings.ParamProduct, settings.Product, settings.Channel, serialized);

                    var deserialized = _xmlProcessor.Deserialize<QuestionsResponse>(response);

                    return deserialized;
                }
                catch (Exception exception)
                {
                    var clientLog = new TelemetryClient();
                    clientLog.TrackException(exception);
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
            }
            return QuestionsResponseMock();
        }

        public ValidationResponse Validate(ValidateUserSettings settings)
        {
            if (settings == null) throw new ArgumentNullException(nameof(settings));
            var mock = bool.Parse(ConfigurationManager.AppSettings.Get("Mock"));
            if (!mock)
            {
                try
                {
                    var identification = new Identification
                    {
                        Number = settings.Identification,
                        Type = settings.IdentificationType
                    };
                    var dataValidation = new ValidationRequest
                    {
                        Identification = identification,
                        LastName = settings.LastName,
                        Names = settings.Names,
                        SecondLastName = settings.SecondLastName,
                        ExpeditionDate = new ExpeditionDate
                        {
                            Timestamp = settings.ExpeditionDate.ToTimestamp()
                        }
                    };
                    var serialized = _xmlProcessor.Serialize(dataValidation);
                    var response = validar(settings.ParamProduct, settings.Product, settings.Channel, serialized);
                    var deserialized = _xmlProcessor.Deserialize<ValidationResponse>(response);
                    return deserialized;
                }
                catch (Exception exception)
                {
                    var clientLog = new TelemetryClient();
                    clientLog.TrackException(exception);
                    clientLog.TrackException(exception);
                    var consultationException =
                        _webSettingsConsultationSettingsBuilder.WithPayload(
                            JsonConvert.SerializeObject(new { Exception = exception }))
                            .WithExecutionId(settings.ExecutionId)
                            .WithTypeOfConsultation((int)TypeOfConsultation.CommunicationError)
                            .WithWebServiceName("Error consultando " + ServiceNameType.Validate.GetStringValue())
                            .Build();
                    AddWebServiceConsultation(consultationException);
                    return new ValidationResponse
                    {
                        ProcessResult = false
                    };
                }
            }
            return new ValidationResponse
            {
                Result = 5,
                ProcessResult = true,
            };
        }
        private static QuestionsResponse QuestionsResponseMock()
        {
            return new QuestionsResponse
            {
                Questions = new List<Question>
                {
                    new Question
                    {
                        Text = "¿Hace cuánto tiene tarjeta de crédito en Bancolombia?",
                        Id = "01",
                        Answers = new List<OptionsAnswer>
                        {
                            new OptionsAnswer
                            {
                                Id = "01",
                                Text = "Menos de 6 meses"
                            },
                            new OptionsAnswer
                            {
                                Id = "02",
                                Text = "Entre seis meses y tres años"
                            },
                            new OptionsAnswer
                            {
                                Id = "03",
                                Text = "Más de tres años"
                            },
                            new OptionsAnswer
                            {
                                Id = "04",
                                Text = "No tengo tarjeta de crédito en Bancolombia"
                            }
                        },
                        Order = 1
                    },
                    new Question
                    {
                        Text = "¿Con cuál de los sigueintes números ha tenido o tiene relación?",
                        Id = "01",
                        Answers = new List<OptionsAnswer>
                        {
                            new OptionsAnswer
                            {
                                Id = "01",
                                Text = "3143151620"
                            },
                            new OptionsAnswer
                            {
                                Id = "02",
                                Text = "7454592"
                            },
                            new OptionsAnswer
                            {
                                Id = "03",
                                Text = "3176482606"
                            },
                            new OptionsAnswer
                            {
                                Id = "04",
                                Text = "1225688956"
                            }
                        },
                        Order = 2
                    },
                    new Question
                    {
                        Text = "¿Con cuál de los siguientes bancos ha tenido relación en los últimos seis meses?",
                        Id = "01",
                        Answers = new List<OptionsAnswer>
                        {
                            new OptionsAnswer
                            {
                                Id = "01",
                                Text = "Bancolombia"
                            },
                            new OptionsAnswer
                            {
                                Id = "02",
                                Text = "Davivienda"
                            },
                            new OptionsAnswer
                            {
                                Id = "03",
                                Text = "Colpatria"
                            },
                            new OptionsAnswer
                            {
                                Id = "04",
                                Text = "No relación con ningún banco mencionado anteriormente"
                            }
                        }
                        ,
                        Order = 3
                    },
                    new Question
                    {
                        Text = "¿Hace cuánto adquirió su servicio con Telmex Hogar?",
                        Id = "01",
                        Answers = new List<OptionsAnswer>
                        {
                            new OptionsAnswer
                            {
                                Id = "01",
                                Text = "Menos de 6 meses"
                            },
                            new OptionsAnswer
                            {
                                Id = "02",
                                Text = "Entre seis meses y tres años"
                            },
                            new OptionsAnswer
                            {
                                Id = "03",
                                Text = "Más de tres años"
                            },
                            new OptionsAnswer
                            {
                                Id = "04",
                                Text = "No tengo servicio con Telmex Hogar"
                            }
                        },
                        Order = 4
                    }
                },
                Id = "01"
                ,
                Result = "01"
            };
        }

        protected override WebRequest GetWebRequest(Uri uri = null)
        {
            var actualUri = uri ?? new Uri(Url);
            var request = (HttpWebRequest)base.GetWebRequest(actualUri);
            return PreAuthenticate ? request.GetRequestWithBasicAuthorization(actualUri) : request;
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