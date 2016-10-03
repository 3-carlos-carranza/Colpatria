using Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services;
using Core.GlobalRepository.Inalambria;

namespace Application.Main.Implementation.ProcessFlow.Services
{
    public class InalambriaAppService : IInalambriaAppService
    {
        private readonly IInalambriaAuthRepository _inalambriaAuthRepository;
        private readonly IInalambriaRepository _inalambriaRepository;

        public InalambriaAppService(IInalambriaAuthRepository inalambriaAuthRepository, IInalambriaRepository inalambriaRepository)
        {
            _inalambriaAuthRepository = inalambriaAuthRepository;
            _inalambriaRepository = inalambriaRepository;
        }

        public string GetTicketKdc()
        {
            return _inalambriaAuthRepository.GetTicketKdc();
        }

        public bool SendSms(string devicenumber, string message, string provider)
        {
            return _inalambriaRepository.SendSms(GetTicketKdc(), devicenumber, message, provider);
        }
    }
}