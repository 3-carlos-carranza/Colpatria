//   -----------------------------------------------------------------------
//   <copyright file=IRequestResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using System;
using Application.Main.Definition.Enumerations;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Responses
{
    public interface IRequestResponse : IShowScreenResponse
    {
        string Name { get; set; }
        DateTime DateOfExpedition { get; set; }
        MessageClassification MessageClassification { get; }
        bool IsResponsePersonalized { get; set; }
    }
}