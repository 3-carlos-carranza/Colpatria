//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core.Entities.Process
{
    using System;
    using System.Collections.Generic;
    
    public partial class Section
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Section()
        {
            this.Execution = new HashSet<Execution>();
            this.FieldInSection = new HashSet<FieldInSection>();
            this.StepSection = new HashSet<StepSection>();
        }
    
        public int Id { get; set; }
        public int PageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public string NameAlias { get; set; }
        public Nullable<bool> ReadOnly { get; set; }
        public int Type { get; set; }
        public bool IsVisible { get; set; }
        public bool Enable { get; set; }
        public string ActionMethod { get; set; }
        public string Action { get; set; }
        public string Controller { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Execution> Execution { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FieldInSection> FieldInSection { get; set; }
        public virtual Page Page { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StepSection> StepSection { get; set; }
    }
}