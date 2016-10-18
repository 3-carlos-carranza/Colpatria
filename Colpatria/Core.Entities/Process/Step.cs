using System.Collections.Generic;
using Banlinea.ProcessFlow.Model;

namespace Core.Entities.Process
{
    public class Step : StepFlow
    {
        public override int Id { get; set; }
        public override int ProcessId { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public bool? AutoAdvance { get; set; }
        public override string NameClientAlias { get; set; }
        public int? ParentId { get; set; }
        public override int Order { get; set; }
        public bool? IsPre { get; set; }
        public override int StateId { get; set; }
        public override bool Enable { get; set; }
        public override StepType StepType { get; set; }
        public virtual ICollection<Execution> Execution { get;  } = new HashSet<Execution>();
        public virtual ICollection<ExecutionStep> ExecutionStep { get; } = new HashSet<ExecutionStep>();
        public virtual Process Process { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<StepSection> StepSection { get;  } = new HashSet<StepSection>();
    }
}