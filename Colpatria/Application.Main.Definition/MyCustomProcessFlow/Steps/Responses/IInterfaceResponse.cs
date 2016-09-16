//   -----------------------------------------------------------------------
//   <copyright file=IInterfaceResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using Application.Main.Definition.Enumerations;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Responses
{
    public interface IInterfaceWebResponse : IInterfaceResponse
    {
        InterfaceTypeResponse InterfaceTypeResponse { get; }
    }
}