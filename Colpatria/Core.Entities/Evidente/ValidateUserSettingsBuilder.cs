using System;

namespace Core.Entities.Evidente
{
    public class ValidateUserSettingsBuilder
    {
        private string _channel;
        private DateTime _expeditionDate;
        private string _identification;
        private string _fullName;
        private string _lastName;
        private string _paramProduct;
        private string _product;
        private string _identificationType;
        private string _secondLastName;
        private long _requestId;
        public ValidateUserSettingsBuilder()
        {
            _channel = string.Empty;
            _expeditionDate = DateTime.UtcNow;
            _identification = string.Empty;
            _fullName = string.Empty;
            _lastName = string.Empty;
            _secondLastName = string.Empty;
            _paramProduct = string.Empty;
            _product = string.Empty;
            _identificationType = "1";
        }
        public ValidateUserSettings Build()
        {
            return new ValidateUserSettings
            {
                Channel = _channel,
                ExpeditionDate = _expeditionDate,
                Identification = _identification,
                Fullname = _fullName,
                Lastname = _lastName,
                SecondLastname = _secondLastName,
                ParamProduct = _paramProduct,
                Product = _product,
                IdentificationType = _identificationType,
                RequestId = _requestId
            };
        }
        public ValidateUserSettingsBuilder WithChannel(string item)
        {
            _channel = item;
            return this;
        }
        public ValidateUserSettingsBuilder WithExpeditionDate(DateTime item)
        {
            _expeditionDate = item;
            return this;
        }
        public ValidateUserSettingsBuilder WithIdentification(string item)
        {
            _identification = item;
            return this;
        }
        public ValidateUserSettingsBuilder WithFullName(string item)
        {
            _fullName = item;
            return this;
        }
        public ValidateUserSettingsBuilder WithLastName(string item)
        {
            _lastName = item;
            return this;
        }
        public ValidateUserSettingsBuilder WithParamProduct(string item)
        {
            _paramProduct = item;
            return this;
        }
        public ValidateUserSettingsBuilder WithProduct(string item)
        {
            _product = item;
            return this;
        }
        public ValidateUserSettingsBuilder WithTypeOfDocument(string item)
        {
            _identificationType = item;
            return this;
        }
        public ValidateUserSettingsBuilder WithSecondLastName(string value)
        {
            _secondLastName = value;
            return this;
        }
        public ValidateUserSettingsBuilder WithRequestId(long id)
        {
            _requestId = id;
            return this;
        }
    }
}
