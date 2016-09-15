using System.Collections.Generic;

namespace Core.Entities.WsMotor
{
    public class PetitionSettingsBuilder
    {
        private string _identification;
        private string _key;
        private string _lastName;
        private IEnumerable<Parameters> _paramsRequest;
        private string _typeIdentification;
        private string _user;

        public PetitionSettingsBuilder()
        {
            _key = string.Empty;
            _identification = string.Empty;
            _lastName = string.Empty;
            _typeIdentification = string.Empty;
            _user = string.Empty;
            _paramsRequest = null;
        }

        public Petition Build()
        {
            return new Petition
            {
                Key = _key,
                Identification = _identification,
                LastName = _lastName,
                TypeIdentification = _typeIdentification,
                User = _user,
                ParamsRequest = _paramsRequest
            };
        }

        public PetitionSettingsBuilder WithKey(string item)
        {
            _key = item;
            return this;
        }

        public PetitionSettingsBuilder WithUser(string item)
        {
            _user = item;
            return this;
        }

        public PetitionSettingsBuilder WithIdentificaction(string item)
        {
            _identification = item;
            return this;
        }

        public PetitionSettingsBuilder WithLastName(string item)
        {
            _lastName = item;
            return this;
        }

        public PetitionSettingsBuilder WithTypeIdentification(string item)
        {
            _typeIdentification = item;
            return this;
        }

        public PetitionSettingsBuilder WithParamsRequest(IEnumerable<Parameters> item)
        {
            _paramsRequest = item;
            return this;
        }
    }
}