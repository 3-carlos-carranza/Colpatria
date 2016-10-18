using Banlinea.ProcessFlow.Model;

namespace Core.Entities.Process
{
    using System.Collections.Generic;
    public class ExtendedField: FieldFlow
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExtendedField()
        {
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public int BaseFieldId { get; set; }
        public int DataType { get; set; }
        public string ClientValidationClass { get; set; }
        public int? ListId { get; set; }
        public int ProcessId { get; set; }
        public string HtmlData { get; set; }
        public string NameService { get; set; }
        public virtual ExtendedList ExtendedList { get; set; }
        public virtual ICollection<ExtendedFieldValue> ExtendedFieldValue { get; set; } = new HashSet<ExtendedFieldValue>();
        public virtual Process Process { get; set; }
        public virtual ICollection<FieldInSection> FieldInSection { get; set; } = new HashSet<FieldInSection>();
    }
}
