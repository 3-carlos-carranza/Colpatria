
namespace Core.GlobalRepository.Inalambria
{
    public interface IInalambriaRepository
    {
        string SendSms(string tickettgs, string devicenumber, string message, string provider);
    }
}