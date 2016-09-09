using System.Collections.Generic;

namespace Core.Entities.ProcessModel
{
    public abstract class StateFlow
    {
        public string Description { get; set; }
        public int Id { get; set; }
        public bool IsClosed { get; set; }
        public bool IsRequesting { get; set; }
        public string Name { get; set; }
        public bool NotificationEnabled { get; set; }
        public virtual ICollection<StepFlow> Step { get; set; } = new HashSet<StepFlow>();
    }
}