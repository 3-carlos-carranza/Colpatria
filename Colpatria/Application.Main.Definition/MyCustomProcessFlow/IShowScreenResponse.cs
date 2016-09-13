using System.Collections.Generic;
using Application.Main.Definition.Enumerations;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Core.Entities.Process;

namespace Application.Main.Definition.MyCustomProcessFlow
{
    public interface IShowScreenResponse : IInterfaceResponse
    {
        InterfaceTypeResponse InterfaceTypeResponse { get; }
    }
}