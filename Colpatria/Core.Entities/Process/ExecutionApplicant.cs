using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Process
{
    public class ExecutionApplicant
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ExecutionId { get; set; }
        public long UserId { get; set; }
        public bool IsMain { get; set; }
        public int Applicant { get; set; }
        public virtual Execution Execution { get; set; }
    }
}
