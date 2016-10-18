#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=Process.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 5:01 p. m.</Date>
//   <Update> 2016-09-12 - 11:18 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Collections.Generic;
using Banlinea.ProcessFlow.Model;

#endregion

namespace Core.Entities.Process
{
    public class Process : ProcessFlow
    {
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override DateTime CreateDate { get; set; }
        public override int? CreatedBy { get; set; }
        public int FunctionaryAssignationProcessType { get; set; }
        public int FormGenerationOption { get; set; }
        public override int ProcessType { get; set; }
        public int FinancialEntityType { get; set; }


        public virtual ICollection<Execution> Execution { get; } = new HashSet<Execution>();

        public virtual ICollection<ExtendedField> ExtendedField { get; } = new HashSet<ExtendedField>();

        public virtual ICollection<Page> Page { get;  } = new HashSet<Page>();

        public virtual ICollection<ProductProcess> ProductProcess { get; } = new HashSet<ProductProcess>();

        public virtual ICollection<Step> Step { get; } = new HashSet<Step>();
    }
}