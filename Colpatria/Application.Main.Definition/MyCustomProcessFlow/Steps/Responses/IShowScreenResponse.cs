//   -----------------------------------------------------------------------
//   <copyright file=IShowScreenResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using Application.Main.Definition.Enumerations;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;

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