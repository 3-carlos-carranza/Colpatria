namespace Core.Entities.User
{
    using System.Collections.Generic;
    
    public class BaseDataList
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaseDataList()
        {
            BaseField = new HashSet<BaseField>();
            BaseDataListValue = new HashSet<BaseDataListValue>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long? IdListParent { get; set; }
        public string LocationTable { get; set; }
        public string Field { get; set; }
        public string Filter { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaseField> BaseField { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaseDataListValue> BaseDataListValue { get; set; }
    }
}
