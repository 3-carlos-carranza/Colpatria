namespace Core.Entities.ProcessModel
{
    public class State
    {
        public string Description { get; set; }
        public long Id { get; set; }
        public bool IsClosed { get; set; }
        public bool IsRequesting { get; set; }
        public string Name { get; set; }
        public bool NotificationEnabled { get; set; }
    }
}