using System.Collections.Generic;
using Banlinea.ProcessFlow.Model;

namespace Core.Entities.Process
{
    public class State : StateFlow
    {
        public State()
        {
            Step = new HashSet<Step>();
        }
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Description { get; set; }
        public override bool NotificationEnabled { get; set; }
        public override bool IsClosed { get; set; }
        public override bool IsRequesting { get; set; }
        public virtual ICollection<Step> Step { get;  } = new HashSet<Step>();
    }
}