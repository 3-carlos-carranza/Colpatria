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
        public virtual int Id { get; set; }
        public virtual string Name { get; set; }
        public virtual string Description { get; set; }
        public virtual DateTime CreateDate { get; set; }
        public virtual int? CreatedBy { get; set; }
        public virtual int FinancialEntityId { get; set; }
        public virtual int FunctionaryAssignationProcess { get; set; }
        public virtual int ProcessType { get; set; }

        //public virtual ICollection<StepFlow> Steps { get; set; } = new HashSet<StepFlow>();
    }
}