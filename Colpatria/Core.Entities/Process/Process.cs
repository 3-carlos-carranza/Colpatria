using System;
using System.Collections.Generic;
using Banlinea.ProcessFlow.Model;

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
        public virtual ICollection<Execution> Execution { get; set; } = new HashSet<Execution>();
        public virtual ICollection<ExtendedField> ExtendedField { get; set; } = new HashSet<ExtendedField>();
        public virtual ICollection<Page> Page { get; set; } = new HashSet<Page>();
        public virtual ICollection<ProductProcess> ProductProcess { get; set; } = new HashSet<ProductProcess>();
        public virtual ICollection<Step> Step { get; set; } = new HashSet<Step>();
    }
}