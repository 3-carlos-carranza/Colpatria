using System;
using System.ComponentModel.DataAnnotations;

namespace Presentation.Web.Colpatria.Models
{
    public class UserViewModel
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string FirstLastName { get; set; }

        [Required]
        public string SecondLastName { get; set; }

        [Required]
        public string IdentificationType { get; set; }

        [Required]
        public long Identification { get; set; }

        [Required]
        public DateTime DateOfExpedition { get; set; }

        [Required]
        public string PlaceOfExpedition { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public long Telephone { get; set; }

        [Required]
        public long Cellphone { get; set; }

        [Required]
        public string TermsAndConditions { get; set; }
    }
}