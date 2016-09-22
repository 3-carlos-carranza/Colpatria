using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Text;
using Core.Entities.Evidente;
using Core.GlobalRepository.Evidente;
using Crosscutting.Common.Extensions;
using Crosscutting.Common.Tools.XmlUtilities;
using Data.DataCredito.EvidenteService;

namespace Data.DataCredito
{
    public class EvidenteRepository : ServicioIdentificacion, IEvidenteRepository
    {
        private readonly XmlProcessor _xmlProcessor;

        public EvidenteRepository()
        {
            _xmlProcessor = new XmlProcessor();
            var username = ConfigurationManager.AppSettings["EvidenteUsername"];
            var password = ConfigurationManager.AppSettings["EvidentePassword"];
            this.SetNetworkCredentials(username, password);
            RequestEncoding = Encoding.UTF8;
        }

        public AnswerResponse AnswerQuestions(AnswerSettings settings)
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

        public QuestionsResponse GetQuestions(QuestionsSettings settings)
        {
            var mock = bool.Parse(ConfigurationManager.AppSettings.Get("Mock"));
            if (!mock)
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
            return QuestionsResponseMock();
        }

        public ValidationResponse Validate(ValidateUserSettings settings)
        {

            var mock = bool.Parse(ConfigurationManager.AppSettings.Get("Mock"));
            if (!mock)
            {
                var identificacion = new Identification
                {
                    Number = settings.Identification,
                    Type = settings.IdentificationType
                };

                var datosValidacion = new ValidationRequest
                {
                    Identification = identificacion,
                    PrimerApellido = settings.Lastname,
                    Nombres = settings.Fullname,
                    SegundoApellido = settings.SecondLastname,
                    ExpeditionDate = new ExpeditionDate
                    {
                        Timestamp = DateTimeExtension.ToTimestamp(settings
                            .ExpeditionDate)
                    }
                };

                var serialized = _xmlProcessor.Serialize(datosValidacion);

                var response = validar(settings.ParamProduct, settings.Product, settings.Channel, serialized);

                var deserialized = _xmlProcessor.Deserialize<ValidationResponse>(response);

                return deserialized;
            }
            return new ValidationResponse
            {
                Result =5 ,
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
                        Id = "1",
                        Answers = new List<OptionsAnswer>
                        {
                            new OptionsAnswer
                            {
                                Id = "1",
                                Text = "Menos de 6 meses"
                            },
                            new OptionsAnswer
                            {
                                Id = "2",
                                Text = "Entre seis meses y tres años"
                            },
                            new OptionsAnswer
                            {
                                Id = "3",
                                Text = "Más de tres años"
                            },
                            new OptionsAnswer
                            {
                                Id = "4",
                                Text = "No tengo tarjeta de crédito en Bancolombia"
                            }
                        },
                        Order = 1
                    },
                    new Question
                    {
                        Text = "¿Con cuál de los sigueintes números ha tenido o tiene relación?",
                        Id = "1",
                        Answers = new List<OptionsAnswer>
                        {
                            new OptionsAnswer
                            {
                                Id = "1",
                                Text = "3143151620"
                            },
                            new OptionsAnswer
                            {
                                Id = "2",
                                Text = "7454592"
                            },
                            new OptionsAnswer
                            {
                                Id = "3",
                                Text = "3176482606"
                            },
                            new OptionsAnswer
                            {
                                Id = "4",
                                Text = "1225688956"
                            }
                        },
                        Order = 2
                    },
                    new Question
                    {
                        Text = "¿Con cuál de los siguientes bancos ha tenido relación en los últimos seis meses?",
                        Id = "1",
                        Answers = new List<OptionsAnswer>
                        {
                            new OptionsAnswer
                            {
                                Id = "1",
                                Text = "Bancolombia"
                            },
                            new OptionsAnswer
                            {
                                Id = "2",
                                Text = "Davivienda"
                            },
                            new OptionsAnswer
                            {
                                Id = "3",
                                Text = "Colpatria"
                            },
                            new OptionsAnswer
                            {
                                Id = "4",
                                Text = "No relación con ningún banco mencionado anteriormente"
                            }
                        }
                        ,
                        Order = 3
                    },
                    new Question
                    {
                        Text = "¿Hace cuánto adquirió su servicio con Telmex Hogar?",
                        Id = "1",
                        Answers = new List<OptionsAnswer>
                        {
                            new OptionsAnswer
                            {
                                Id = "1",
                                Text = "Menos de 6 meses"
                            },
                            new OptionsAnswer
                            {
                                Id = "2",
                                Text = "Entre seis meses y tres años"
                            },
                            new OptionsAnswer
                            {
                                Id = "3",
                                Text = "Más de tres años"
                            },
                            new OptionsAnswer
                            {
                                Id = "4",
                                Text = "No tengo servicio con Telmex Hogar"
                            }
                        },
                        Order = 4
                    }
                },
                Id = "1"
                ,Result = "1"
            };
        }

        protected override WebRequest GetWebRequest(Uri uri = null)
        {
            var actualUri = uri ?? new Uri(Url);
            var request = (HttpWebRequest)base.GetWebRequest(actualUri);
            return (PreAuthenticate) ? request.GetRequestWithBasicAuthorization(actualUri) : request;
        }
    }
}