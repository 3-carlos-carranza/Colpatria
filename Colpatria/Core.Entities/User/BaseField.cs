namespace Core.Entities.User
{
    using System.Collections.Generic;
    
    public class BaseField
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BaseField()
        {
            BaseFieldValue = new HashSet<BaseFieldValue>();
            FieldToCreateUser = new HashSet<FieldToCreateUser>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int DataType { get; set; }
        public string ClientValidationClass { get; set; }
        public string ServerRegex { get; set; }
        public int? ListId { get; set; }
        public bool IsMail { get; set; }
        public bool IsCallNumber { get; set; }
        public string HtmlData { get; set; }
        public bool IsUniqueForUser { get; set; }
        public int ApplicantNumber { get; set; }
        public virtual BaseDataList BaseDataList { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BaseFieldValue> BaseFieldValue { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FieldToCreateUser> FieldToCreateUser { get; set; }
    }
}
