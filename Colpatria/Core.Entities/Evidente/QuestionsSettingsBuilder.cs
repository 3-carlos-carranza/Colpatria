namespace Core.Entities.Evidente
{
    public class QuestionsSettingsBuilder
    {
        private string _channel;
        private string _identification;
        private string _paramProduct;
        private string _product;
        private string _identificationType;
        private long _validationNumber;
        private long _requestId;
        public QuestionsSettingsBuilder()
        {
            _channel = string.Empty;
            _identification = string.Empty;
            _paramProduct = string.Empty;
            _product = string.Empty;
            _identificationType = string.Empty;
            _validationNumber = 0;
        }
        public QuestionsSettings Build()
        {
            return new QuestionsSettings
            {
                Channel = _channel,
                Identification = _identification,
                ParamProduct = _paramProduct,
                Product = _product,
                IdentificationType = _identificationType,
                ValidationNumber = _validationNumber,
                RequestId = _requestId
            };
        }
        public QuestionsSettingsBuilder WithChannel(string item)
        {
            _channel = item;
            return this;
        }
        public QuestionsSettingsBuilder WithDocumentNumber(string item)
        {
            _identification = item;
            return this;
        }
        public QuestionsSettingsBuilder WithParamProducto(string item)
        {
            _paramProduct = item;
            return this;
        }
        public QuestionsSettingsBuilder WithProduct(string item)
        {
            _product = item;
            return this;
        }
        public QuestionsSettingsBuilder WithTypeOfDocument(string item)
        {
            _identificationType = item;
            return this;
        }
        public QuestionsSettingsBuilder WithValidationNumber(long item)
        {
            _validationNumber = item;
            return this;
        }
        public QuestionsSettingsBuilder WithRequestId(long requestId)
        {
            _requestId = requestId;
            return this;
        }
    }
}
