//   -----------------------------------------------------------------------
//   <copyright file=EvidenteResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using System.Collections.Generic;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Model;
using Core.Entities.Evidente;


namespace Application.Main.Implementation.ProcessFlow.Responses
{
    public class EvidenteResponse : IEvidenteResponse
    {
        public IEnumerable<Question> Questions { get; set; }
        public ExecutionFlow Execution { get; set; }
        public ResponseDetailFlow ResponseDetail { get; set; }
        public string FriendlyUrl { get; set; }
        public string ActionMethod { get; set; }
        public string PartialView { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public ShowScreenType ShowScreenType => ShowScreenType.ShowForm;

        public string Name { get; set; }
    }
}