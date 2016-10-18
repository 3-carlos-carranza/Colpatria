namespace Core.Entities.Process
{
    public class ExtendedDataList
    {
        public int Id { get; set; }
        public int? ListId { get; set; }
        public string Value { get; set; }
        public int? IdParent { get; set; }
        public int? OriginalValue { get; set; }
        public int? Order { get; set; }
        public virtual ExtendedList ExtendedList { get; set; }
    }
}
