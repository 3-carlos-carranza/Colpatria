#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=ProcessFlow.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 11:02 a. m.</Date>
//   <Update> 2016-09-09 - 11:23 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Collections.Generic;

#endregion

namespace Core.Entities.ProcessModel
{
    public abstract class ProcessFlow
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreateDate { get; set; }
        public int? CreatedBy { get; set; }
        public int FinancialEntityId { get; set; }
        public int FunctionaryAssignationProcess { get; set; }
        public int ProcessType { get; set; }

        //public virtual ICollection<StepFlow> Steps { get; set; } = new HashSet<StepFlow>();
    }
}