//   -----------------------------------------------------------------------
//   <copyright file=ShowScreenResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using System.Collections.Generic;
using Application.Main.Definition.Enumerations;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Model;
using Core.Entities.Process;

namespace Application.Main.Implementation.ProcessFlow.Responses
{
    public class ShowScreenResponse : IShowScreenResponse
    {
        public IEnumerable<Page> Pages { get; set; }
        public InterfaceTypeResponse InterfaceTypeResponse { get; }
        public ExecutionFlow Execution { get; set; }

        public ResponseDetailFlow ResponseDetail { get; set; }
        public string FriendlyUrl { get; set; }
        public string ActionMethod { get; set; }
        public string PartialView { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public ShowScreenType ShowScreenType { get; }
        public string Name { get; set; }
    }
}