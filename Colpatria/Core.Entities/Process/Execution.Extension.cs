using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Process
{
    partial class Step : Core.Entities.ProcessModel.Step
    {

    }

    partial class Execution :Core.Entities.ProcessModel.Execution
    {
        [NotMapped]
        public int? CurrentPageId { get; set; }

        [NotMapped]
        public long UserId { get; set; }

        [NotMapped]
        public long Month { get; set; }
    }
}