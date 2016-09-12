using Application.Main.Definition.Enumerations;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Responses
{
    public interface IInterfaceWebResponse : IInterfaceResponse
    {
        InterfaceTypeResponse InterfaceTypeResponse { get; }
        
    }
}