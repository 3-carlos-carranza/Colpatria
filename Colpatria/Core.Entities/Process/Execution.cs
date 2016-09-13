#region Signature

//   -----------------------------------------------------------------------
//   <copyright file=Execution.cs company="Banlinea S.A.S">
//       Copyright (c) Banlinea Todos los derechos reservados.
//   </copyright>
//   <author>Jeysson Stevens  Ramirez </author>
//   <Date>  2016 -09-08  - 5:01 p. m.</Date>
//   <Update> 2016-09-12 - 11:26 a. m.</Update>
//   -----------------------------------------------------------------------

#endregion

#region

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Core.Entities.ProcessModel;

#endregion

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