#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=IResponse.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -08-26  - 10:37 a. m.</Date>
//   <Update> 2016-08-26 - 11:13 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using Core.Entities.ProcessModel;

#endregion

namespace Application.Main.Definition.ProcessFlow.Api.Handler
{
    public interface IResponse
    {
        ReponseStatus Status { get; set; }
        IEnumerable<dynamic> Result { get; set; }
    }
}