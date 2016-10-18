using System.Collections.Generic;
using Banlinea.ProcessFlow.Model;

namespace Core.Entities.Process
{
    public class Page : PageFlow
    {
        public int ProcessId { get; set; }
        public virtual Process Process { get; set; }
        public virtual ICollection<Section> Section { get; } = new HashSet<Section>();
    }
}