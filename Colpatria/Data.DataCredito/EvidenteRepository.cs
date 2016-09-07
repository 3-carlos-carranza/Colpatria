using System;
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
            throw new NotImplementedException();
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
