namespace Core.Entities.Evidente
{
    public class AnswerSettingsBuilder
    {
        private string _channel;

        private string _identification;

        private AnswerRequest _answerRequest;

        private string _paramProduct;

        private string _product;

        private string _identificationType;

        private long _requestId;

        public AnswerSettingsBuilder()
        {
            _channel = string.Empty;
            _identification = string.Empty;
            _answerRequest = new AnswerRequest();
            _paramProduct = string.Empty;
            _product = string.Empty;
            _identificationType = string.Empty;
        }
        public AnswerSettings Build()
        {
            return new AnswerSettings
            {
                Channel = _channel,
                Identification = _identification,
                AnswerRequest = _answerRequest,
                ParamProduct = _paramProduct,
                Product = _product,
                IdentificationType = _identificationType,
                RequestId = _requestId
            };
        }
        public AnswerSettingsBuilder WithChannel(string item)
        {
            _channel = item;
            return this;
        }
        public AnswerSettingsBuilder WithIdentification(string item)
        {
            _identification = item;
            return this;
        }
        public AnswerSettingsBuilder WithAnswerRequest(
            AnswerRequest item)
        {
            _answerRequest = item;
            return this;
        }
        public AnswerSettingsBuilder WithParamProduct(string item)
        {
            _paramProduct = item;
            return this;
        }
        public AnswerSettingsBuilder WithProduct(string item)
        {
            _product = item;
            return this;
        }
        public AnswerSettingsBuilder WithIdentificationType(string item)
        {
            _identificationType = item;
            return this;
        }
        public AnswerSettingsBuilder WithRequestId(long id)
        {
            _requestId = id;
            return this;
        }
    }
}
