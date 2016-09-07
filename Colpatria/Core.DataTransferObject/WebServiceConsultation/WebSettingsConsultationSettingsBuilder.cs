namespace Core.DataTransferObject.WebServiceConsultation
{
    public class WebSettingsConsultationSettingsBuilder
    {
        private string _payload;

        private long _executionId;

        private int _typeOfConsultation;

        private string _webServiceName;
        public WebSettingsConsultationSettingsBuilder()
        {
            _executionId = 0;
            _payload = string.Empty;
            _typeOfConsultation = 0;
            _webServiceName = string.Empty;
        }
        public WebServiceConsultationSettings Build()
        {
            return new WebServiceConsultationSettings
            {
                Payload = _payload,
                ExecutionId = _executionId,
                TypeOfConsultation = _typeOfConsultation,
                WebServiceName = _webServiceName
            };
        }
        public WebSettingsConsultationSettingsBuilder WithPayload(string item)
        {
            _payload = item;
            return this;
        }

        public WebSettingsConsultationSettingsBuilder WithExecutionId(long item)
        {
            _executionId = item;
            return this;
        }

        public WebSettingsConsultationSettingsBuilder WithTypeOfConsultation(int item)
        {
            _typeOfConsultation = item;
            return this;
        }

        public WebSettingsConsultationSettingsBuilder WithWebServiceName(string item)
        {
            _webServiceName = item;
            return this;
        }
    }
}
