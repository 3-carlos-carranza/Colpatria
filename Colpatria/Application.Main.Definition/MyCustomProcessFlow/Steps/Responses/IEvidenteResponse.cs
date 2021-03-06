﻿//   -----------------------------------------------------------------------
//   <copyright file=IEvidenteResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Core.DataTransferObject.Vib;
using Core.Entities.Evidente;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Responses
{
    public interface IEvidenteResponse : IShowScreenResponse
    {
        ErrorEvidenteResponse ErrorEvidenteResponse { get; set; }
        QuestionsResponse QuestionsResponse { get; set; }
        UserInfoDto UserInfoDto { get; set; }
    }
}