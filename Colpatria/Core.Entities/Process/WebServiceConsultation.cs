using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.Process
{
    public class WebServiceConsultation
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public long ExecutionId { get; set; }
        public string Payload { get; set; }
        public string WebServiceName { get; set; }
        public int TypeOfConsultation { get; set; }
        public System.DateTime CreatedDate { get; set; }
    }
}
