using System;
using System.Collections.Generic;
using System.Configuration;
using Core.Entities.Evidente;
using Core.GlobalRepository.Evidente;
using Crosscutting.Common.Tools.XmlUtilities;

namespace Data.DataCredito
{
    public class EvidenteRepository : IEvidenteRepository
    {
        private readonly string _password;
        private readonly string _username;
        private readonly ValidationResponseBuilder _validationResponseBuilder;
        private readonly XmlProcessor _xmlProcessor;

        public EvidenteRepository()
        {
            _xmlProcessor = new XmlProcessor();
            _username = ConfigurationManager.AppSettings["EvidenteUsername"];
            _password = ConfigurationManager.AppSettings["EvidentePassword"];
            //ClientExtensions.SetNetworkCredentials(_username, _password);
            //RequestEncoding = Encoding.UTF8;
            _validationResponseBuilder = new ValidationResponseBuilder();
        }
        public AnswerResponse AnswerQuestions(AnswerSettings settings)
        {
            throw new NotImplementedException();
        }

        public QuestionsResponse GetQuestions(QuestionsSettings settings)
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
            };
        }

        public ValidationResponse Validate(ValidateUserSettings settings)
        {
            throw new NotImplementedException();
        }

        //protected override WebRequest GetWebRequest(Uri uri = null)
        //{
        //    var actualUri = uri ?? new Uri(Url);
        //    var request = (HttpWebRequest)base.GetWebRequest(actualUri);
        //    return (PreAuthenticate) ? request.GetRequestWithBasicAuthorization(actualUri) : request;
        //}
    }
}
