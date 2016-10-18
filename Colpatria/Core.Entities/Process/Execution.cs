using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Banlinea.ProcessFlow.Model;

namespace Core.Entities.Process
{
    public class Execution : ExecutionFlow
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override long Id { get; set; }
        public override int ProcessId { get; set; }
        public DateTime CreateDate { get; set; }
        public string SimpleId { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string ProductData { get; set; }
        public override int CurrentStepId { get; set; }
        public int State { get; set; }
        public bool IsActive { get; set; }
        public override int CurrentSectionId { get; set; }
        public override long ProductId { get; set; }
        public virtual Process Process { get; set; }
        public virtual Product Product { get; set; }
        public virtual Section Section { get; set; }
        public virtual Step Step { get; set; }
        public virtual ICollection<ExecutionApplicant> ExecutionApplicant { get; set; } =
            new HashSet<ExecutionApplicant>();
        public virtual ICollection<ExecutionStep> ExecutionStep { get; set; } = new HashSet<ExecutionStep>();
        public virtual ICollection<ExtendedFieldValue> ExtendedFieldValue { get; set; } =
            new HashSet<ExtendedFieldValue>();
        [NotMapped]
        public int? CurrentPageId { get; set; }
        [NotMapped]
        public long UserId { get; set; }
        [NotMapped]
        public long Month { get; set; }
    }
}