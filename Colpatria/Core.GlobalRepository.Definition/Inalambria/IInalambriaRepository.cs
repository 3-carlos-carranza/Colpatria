namespace Core.GlobalRepository.Inalambria
{
    public interface IInalambriaRepository
    {
        bool SendSms(string tickettgs, string devicenumber, string message, string provider);
    }
}