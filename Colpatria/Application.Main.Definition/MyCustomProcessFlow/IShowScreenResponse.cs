using System.Collections.Generic;
using Application.Main.Definition.Enumerations;
using Application.Main.Definition.ProcessFlow.Api.ProcessFlows.Response;
using Core.Entities.Process;

namespace Application.Main.Definition.MyCustomProcessFlow
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