#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ResponseDetail.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -08-26  - 11:10 a. m.</Date>
//   <Update> 2016-08-26 - 11:10 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

using System;

namespace Core.Entities.ProcessModel
{
    public class ResponseDetailFlow
    {
        public ReponseStatus Status { get; set; }
        public virtual Exception Exception { get; set; }
        public string Description { get; set; }
    }
}