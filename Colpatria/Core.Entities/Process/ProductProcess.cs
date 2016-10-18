namespace Core.Entities.Process
{
    public class ProductProcess
    {
        public int Id { get; set; }
        public int ProcessId { get; set; }
        public long ProductId { get; set; }
        public virtual Process Process { get; set; }
        public virtual Product Product { get; set; }
    }
}