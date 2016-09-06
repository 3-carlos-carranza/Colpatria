using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.SQL.Process
{
    partial class Execution
    {
        [NotMapped]
        public int? CurrentPageId { get; set; }

        [NotMapped]
        public long UserId { get; set; }

        [NotMapped]
        public long Month { get; set; }
    }
}