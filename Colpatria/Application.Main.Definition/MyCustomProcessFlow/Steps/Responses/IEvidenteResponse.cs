//   -----------------------------------------------------------------------
//   <copyright file=IEvidenteResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   -----------------------------------------------------------------------

using System.Collections.Generic;
using Core.Entities.Evidente;

namespace Application.Main.Definition.MyCustomProcessFlow.Steps.Responses
{
    public interface IEvidenteResponse : IShowScreenResponse
    {
        IEnumerable<Question> Questions { get; set; }
    }
}