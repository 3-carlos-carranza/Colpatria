//   -----------------------------------------------------------------------
//   <copyright file=ShowModalResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

#region

using System.Collections.Generic;
using Application.Main.Definition.Enumerations;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Banlinea.ProcessFlow.Model;
using Core.Entities.Process;

#endregion

namespace Application.Main.Implementation.ProcessFlow.Responses
{
    public class ShowModalResponse : IShowScreenResponse
    {
        public IEnumerable<Page> Pages { get; set; }

        public InterfaceTypeResponse InterfaceTypeResponse
        {
            get { return InterfaceTypeResponse.ShowModal; }
        }

        public ExecutionFlow Execution { get; set; }
        public ResponseDetailFlow ResponseDetail { get; set; }
        public string FriendlyUrl { get; set; }
        public string ActionMethod { get; set; }
        public string PartialView { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public string Name { get; set; }
    }
}