#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ShowModalResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 5:01 p. m.</Date>
//   <Update> 2016-09-12 - 5:56 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using Application.Main.Definition.Enumerations;
using Application.Main.Definition.MyCustomProcessFlow;
using Core.Entities.Process;
using Core.Entities.ProcessModel;

#endregion

namespace Application.Main.Implementation.ProcessFlow.Responses
{
    public class ShowModalResponse : IShowScreenResponse
    {
        public InterfaceTypeResponse InterfaceTypeResponse
        {
            get { return InterfaceTypeResponse.ShowModal; }
        }

        public IEnumerable<Page> Pages { get; set; }
        public ExecutionFlow Execution { get; set; }
        public ResponseDetailFlow ResponseDetail { get; set; }
        public string FriendlyUrl { get; set; }
        public string ActionMethod { get; set; }
        public string PartialView { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    }
}