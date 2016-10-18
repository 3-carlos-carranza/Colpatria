namespace Core.Entities.Process
{
    using System.Collections.Generic;
    
    public class ExtendedList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExtendedList()
        {
            ExtendedDataList = new HashSet<ExtendedDataList>();
            ExtendedField = new HashSet<ExtendedField>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int? IdListParent { get; set; }
        public int IdListOriginal { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExtendedDataList> ExtendedDataList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExtendedField> ExtendedField { get; set; }
    }
}
