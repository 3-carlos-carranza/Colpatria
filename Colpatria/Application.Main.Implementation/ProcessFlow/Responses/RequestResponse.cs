//   -----------------------------------------------------------------------
//   <copyright file=RequestResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using System;
using Application.Main.Definition.Enumerations;
using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Model;


namespace Application.Main.Implementation.ProcessFlow.Responses
{
    public class RequestResponse : IRequestResponse
    {
        public string Name { get; set; }
        public string ClientName { get; set; }
        public DateTime DateOfExpedition { get; set; }
        public MessageClassification MessageClassification { get; set; }
        public bool IsResponsePersonalized { get; set; }
        public ExecutionFlow Execution { get; set; }
        public ResponseDetailFlow ResponseDetail { get; set; }
        public string FriendlyUrl { get; set; }
        public string ActionMethod { get; set; }
        public string PartialView { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public ShowScreenType ShowScreenType => ShowScreenType.ShowForm;
    }
}