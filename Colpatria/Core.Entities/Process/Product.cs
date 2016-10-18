using System.Collections.Generic;

namespace Core.Entities.Process
{
    public class Product
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int CompanyId { get; set; }

        public virtual ICollection<Execution> Execution { get; } = new HashSet<Execution>();

        public virtual ICollection<ProductProcess> ProductProcess { get; } = new HashSet<ProductProcess>();
    }
}