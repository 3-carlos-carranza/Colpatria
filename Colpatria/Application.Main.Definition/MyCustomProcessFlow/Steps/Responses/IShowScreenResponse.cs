using Application.Main.Definition.Enumerations;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Responses
{
    public interface IShowScreenResponse : IInterfaceResponse
    {
        string FriendlyUrl { get; set; }
        string ActionMethod { get; set; }
        string PartialView { get; set; }
        string Action { get; set; }
        string Controller { get; set; }
        InterfaceTypeResponse InterfaceTypeResponse { get; }
    }
}