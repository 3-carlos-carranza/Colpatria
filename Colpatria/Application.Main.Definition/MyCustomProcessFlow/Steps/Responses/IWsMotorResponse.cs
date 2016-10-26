//   -----------------------------------------------------------------------
//   <copyright file=IWsMotorResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using Banlinea.ProcessFlow.Engine.Api.ProcessFlows.Response;
using Core.Entities.WsMotor;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Responses
{
    public interface IWsMotorResponse : IShowScreenResponse
    {
        ErrorWsMotorResponse ErrorWsMotorResponse { get; set; }
    }
}