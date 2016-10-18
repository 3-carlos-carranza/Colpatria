namespace Core.Entities.User
{
    public partial class BaseDataListValue
    {
        public int ListId { get; set; }
        public int Id { get; set; }
        public string Value { get; set; }
        public int? IdParent { get; set; }
        public int? Order { get; set; }
        public virtual BaseDataList BaseDataList { get; set; }
    }
}
