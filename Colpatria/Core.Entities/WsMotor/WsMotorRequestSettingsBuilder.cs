using System.Collections.Generic;

namespace Core.Entities.WsMotor
{
    public class WsMotorRequestSettingsBuilder
    {
        private string _identification;
        private string _lastName;
        private List<Parameter> _paramsRequest;
        private string _typeIdentification;
        private string _user;
        private long _executionId;

        public WsMotorRequestSettingsBuilder()
        {
            _identification = string.Empty;
            _lastName = string.Empty;
            _typeIdentification = string.Empty;
            _user = string.Empty;
            _paramsRequest = null;
        }
        public WsMotorRequest Build()
        {
            return new WsMotorRequest
            {
                Identification = _identification,
                LastName = _lastName,
                TypeIdentification = _typeIdentification,
                User = _user,
                Parameters = new Parameters
                {
                    Parameter = _paramsRequest
                },
                ExecutionId = _executionId
            };
        }
        public WsMotorRequestSettingsBuilder WithUser(string item)
        {
            _user = item;
            return this;
        }
        public WsMotorRequestSettingsBuilder WithIdentificaction(string item)
        {
            _identification = item;
            return this;
        }
        public WsMotorRequestSettingsBuilder WithLastName(string item)
        {
            _lastName = item;
            return this;
        }
        public WsMotorRequestSettingsBuilder WithTypeIdentification(string item)
        {
            _typeIdentification = item;
            return this;
        }
        public WsMotorRequestSettingsBuilder WithParamsRequest(List<Parameter> item)
        {
            _paramsRequest = item;
            return this;
        }
        public WsMotorRequestSettingsBuilder WithExecutionId(long id)
        {
            _executionId = id;
            return this;
        }
    }
}