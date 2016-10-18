namespace Core.Entities.User
{

    public class FieldToCreateUser
    {
        public int Id { get; set; }
        public int BaseFieldId { get; set; }
        public string ColumnName { get; set; }
        public string DataType { get; set; }
        public virtual BaseField BaseField { get; set; }
    }
}
