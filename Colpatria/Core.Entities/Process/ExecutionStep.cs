using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Process
{
    public class ExecutionStep
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ExecutionId { get; set; }
        public int StepId { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public long UserId { get; set; }
        public virtual Execution Execution { get; set; }
        public virtual Step Step { get; set; }
    }
}
