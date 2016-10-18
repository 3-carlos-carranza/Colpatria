using System;

namespace Core.Entities.Process
{
    using System.Collections.Generic;
    public class ExtendedFieldValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExtendedFieldValue()
        {
            ExtendedFile = new HashSet<ExtendedFile>();
        }
    
        public long Id { get; set; }
        public int ExtendedFieldId { get; set; }
        public long ExecutionId { get; set; }
        public byte[] Value { get; set; }
        public long UserId { get; set; }
        public int CollectionNumber { get; set; }
        public int Applicant { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Execution Execution { get; set; }
        public virtual ExtendedField ExtendedField { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExtendedFile> ExtendedFile { get; set; }
    }
}
