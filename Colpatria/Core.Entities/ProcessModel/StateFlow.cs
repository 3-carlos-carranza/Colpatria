using System.Collections.Generic;

namespace Core.Entities.ProcessModel
{
    public abstract class StateFlow
    {
        public virtual string Description { get; set; }
        public virtual int Id { get; set; }
        public virtual bool IsClosed { get; set; }
        public virtual bool IsRequesting { get; set; }
        public virtual string Name { get; set; }
        public virtual bool NotificationEnabled { get; set; }
        public virtual ICollection<StepFlow> Step { get; set; } = new HashSet<StepFlow>();
    }
}