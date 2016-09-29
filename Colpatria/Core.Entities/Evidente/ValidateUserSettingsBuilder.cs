using System;

namespace Core.Entities.Evidente
{
    public class ValidateUserSettingsBuilder
    {
        private string _channel;
        private DateTime _expeditionDate;
        private string _identification;
        private string _names;
        private string _lastName;
        private string _paramProduct;
        private string _product;
        private string _identificationType;
        private string _secondLastName;
        private long _executionId;
        public ValidateUserSettingsBuilder()
        {
            _channel = string.Empty;
            _expeditionDate = DateTime.UtcNow;
            _identification = string.Empty;
            _names = string.Empty;
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
                Names = _names,
                LastName = _lastName,
                SecondLastName = _secondLastName,
                ParamProduct = _paramProduct,
                Product = _product,
                IdentificationType = _identificationType,
                ExecutionId = _executionId
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
        public ValidateUserSettingsBuilder WithNames(string item)
        {
            _names = item;
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
        public ValidateUserSettingsBuilder WithExecutionId(long id)
        {
            _executionId = id;
            return this;
        }
    }
}
