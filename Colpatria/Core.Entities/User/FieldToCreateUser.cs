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

    public partial class FieldToCreateUser
    {
        public int Id { get; set; }
        public int BaseFieldId { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
    
        public virtual BaseField BaseField { get; set; }
    }
}
