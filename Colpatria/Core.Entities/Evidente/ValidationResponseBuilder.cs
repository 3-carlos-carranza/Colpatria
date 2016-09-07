namespace Core.Entities.Evidente
{
    public class ValidationResponseBuilder
    {
        private bool _alerts;
        private bool _excludeClient;
        private int _numberOfIntents;
        private bool _processResult;
        private int _result;
        private bool _validatedExpeditionDate;
        private bool _validatedLastname;
        private bool _validatedName;
        private long _validationNumber;
        public ValidationResponseBuilder()
        {
            _alerts = false;
            _excludeClient = false;
            _numberOfIntents = 0;
            _processResult = true;
            _result = 0;
            _validatedExpeditionDate = true;
            _validatedLastname = true;
            _validatedName = true;
            _validationNumber = 0;
        }
        public ValidationResponse Build()
        {
            return new ValidationResponse
            {
                Alerts = _alerts,
                ExcludeClient = _excludeClient,
                NumberOfIntents = _numberOfIntents,
                ProcessResult = _processResult,
                Result = _result,
                ValidatedExpeditionDate = _validatedExpeditionDate,
                ValidatedLastname = _validatedLastname,
                ValidatedName = _validatedName,
                ValidationNumber = _validationNumber,
            };
        }
        public ValidationResponseBuilder WithAlerts(bool item)
        {
            _alerts = item;
            return this;
        }
        public ValidationResponseBuilder WithExcludeClient(bool item)
        {
            _excludeClient = item;
            return this;
        }
        public ValidationResponseBuilder WithNumberOfIntents(int item)
        {
            _numberOfIntents = item;
            return this;
        }
        public ValidationResponseBuilder WithProcessResult(bool item)
        {
            _processResult = item;
            return this;
        }
        public ValidationResponseBuilder WithResult(int item)
        {
            _result = item;
            return this;
        }
        public ValidationResponseBuilder WithValidatedExpeditionDate(bool item)
        {
            _validatedExpeditionDate = item;
            return this;
        }
        public ValidationResponseBuilder WithValidatedLastname(bool item)
        {
            _validatedLastname = item;
            return this;
        }
        public ValidationResponseBuilder WithValidatedName(bool item)
        {
            _validatedName = item;
            return this;
        }
        public ValidationResponseBuilder WithValidatedNumber(long item)
        {
            _validationNumber = item;
            return this;
        }
    }
}
