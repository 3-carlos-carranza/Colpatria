//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Entities.User
{
    using System;
    using System.Collections.Generic;
    
    public partial class BaseFieldValue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaseFieldValue()
        {
            this.BaseFile = new HashSet<BaseFile>();
        }
    
        public long Id { get; set; }
        public int BaseFieldId { get; set; }
        public System.DateTime UpdateDate { get; set; }
        public long UserId { get; set; }
        public byte[] Value { get; set; }
        public int CollectionNumber { get; set; }
    
        public virtual BaseField BaseField { get; set; }
        public virtual User User { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaseFile> BaseFile { get; set; }
    }
}
