using Banlinea.ProcessFlow.Model;

namespace Core.Entities.Process
{
    using System.Collections.Generic;

    public class Section :SectionFlow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Section()
        {
            Execution = new HashSet<Execution>();
            FieldInSection = new HashSet<FieldInSection>();
            StepSection = new HashSet<StepSection>();
        }
        public virtual ICollection<Execution> Execution { get;  } = new HashSet<Execution>();
        public virtual ICollection<FieldInSection> FieldInSection { get;  } = new HashSet<FieldInSection>();
        public virtual Page Page { get; set; }
        public virtual ICollection<StepSection> StepSection { get; } = new HashSet<StepSection>();
    }
}
