#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=Process.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -08-26  - 10:01 a. m.</Date>
//   <Update> 2016-08-26 - 10:01 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Collections.Generic;

#endregion

namespace Core.Entities.ProcessModel
{
    public class Process
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CreatedBy { get; set; }
        public int FinancialEntityId { get; set; }
        public int FunctionaryAssignationProcess { get; set; }
        public int ProcessType { get; set; }

        public IEnumerable<Step> Steps { get; set; }
    }
}