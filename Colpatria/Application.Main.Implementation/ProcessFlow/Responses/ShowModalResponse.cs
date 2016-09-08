#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ShowModalResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-05  - 11:34 a. m.</Date>
//   <Update> 2016-09-08 - 2:21 p. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using Application.Main.Definition.Enumerations;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Core.Entities.ProcessModel;
using Page = Core.Entities.Process.Page;

#endregion

namespace Application.Main.Implementation.ProcessFlow.Responses
{
    public class ShowModalResponse : IShowScreenResponse
    {
        public Execution Execution { get; set; }
        public ResponseDetail ResponseDetail { get; set; }
        public string FriendlyUrl { get; set; }
        public string ActionMethod { get; set; }
        public string PartialView { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public InterfaceTypeResponse InterfaceTypeResponse { get; }
        public IShowScreenResponse Make { get; }
        public IEnumerable<Page> Pages { get; set; }
    }
}