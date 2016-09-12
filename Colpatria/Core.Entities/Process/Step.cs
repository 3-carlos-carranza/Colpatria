#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=Step.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 5:01 p. m.</Date>
//   <Update> 2016-09-12 - 11:45 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System.Collections.Generic;
using Core.Entities.ProcessModel;

#endregion

namespace Core.Entities.Process
{
    public class Step : StepFlow
    {
        public Step()
        {
            Execution = new HashSet<Execution>();
            ExecutionStep = new HashSet<ExecutionStep>();
            StepSection = new HashSet<StepSection>();
        }

        public override int Id { get; set; }
        public override int ProcessId { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public bool? AutoAdvance { get; set; }
        public override string NameClientAlias { get; set; }
        public int? ParentId { get; set; }
        public int? Order { get; set; }
        public bool? IsPre { get; set; }
        public override int StateId { get; set; }
        public override bool Enable { get; set; }
        public override int StepType { get; set; }

        public virtual ICollection<Execution> Execution { get; set; }

        public virtual ICollection<ExecutionStep> ExecutionStep { get; set; }
        public virtual Process Process { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<StepSection> StepSection { get; set; }
    }
}