//   -----------------------------------------------------------------------
//   <copyright file=IRequestResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using System;
using Application.Main.Definition.Enumerations;
using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Core.DataTransferObject.Vib;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Responses
{
    public interface IRequestResponse : IShowScreenResponse
    {
        MessageClassification MessageClassification { get; }
        UserInfoDto UserInfoDto { get; set; }
    }
}