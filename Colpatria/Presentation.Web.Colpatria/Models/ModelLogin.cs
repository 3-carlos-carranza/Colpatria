using System.ComponentModel.DataAnnotations;

namespace Presentation.Web.Colpatria.Models
{
    public class ModelLogin
    {
        [Required]
        public string Identification { get; set; }
        [Required]
        public string SimpleId { get; set; }

        [Required]
        public int DocumentType { get; set; }
    }
}