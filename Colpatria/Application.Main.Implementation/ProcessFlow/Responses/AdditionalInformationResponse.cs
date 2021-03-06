﻿//   -----------------------------------------------------------------------
//   <copyright file=AdditionalInformationResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using Application.Main.Definition.MyCustomProcessFlow.Steps.Responses;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Banlinea.ProcessFlow.Model;
using Core.DataTransferObject.Vib;


namespace Application.Main.Implementation.ProcessFlow.Responses
{
    public class AdditionalInformationResponse : IAdditionalInformationResponse
    {
        public ExecutionFlow Execution { get; set; }
        public ResponseDetailFlow ResponseDetail { get; set; }
        public string FriendlyUrl { get; set; }
        public string ActionMethod { get; set; }
        public string PartialView { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
        public ShowScreenType ShowScreenType => ShowScreenType.ShowForm;

        public string Name { get; set; }
        public UserInfoDto UserInfoDto { get; set; }
    }
}