using System;

namespace Core.Entities.User
{
    using System.Collections.Generic;

    public class BaseFieldValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaseFieldValue()
        {
            BaseFile = new HashSet<BaseFile>();
        }
        public long Id { get; set; }
        public int BaseFieldId { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long UserId { get; set; }
        public byte[] Value { get; set; }
        public int CollectionNumber { get; set; }
        public virtual BaseField BaseField { get; set; }
        public virtual User User { get; set; }
        public DateTime CreatedDate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaseFile> BaseFile { get; set; }
    }
}
