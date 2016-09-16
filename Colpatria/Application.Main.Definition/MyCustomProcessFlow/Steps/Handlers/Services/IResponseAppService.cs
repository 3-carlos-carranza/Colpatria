using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Handlers.Services
{
    public interface IResponseRequestAppService
    {
        IRequestResponse GetResponse();
    }
}