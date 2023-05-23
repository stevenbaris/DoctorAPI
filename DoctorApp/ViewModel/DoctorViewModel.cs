using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoctorApp.ViewModel
{
    public class DoctorViewModel
    {
        [Required]
        [DisplayName("First Name")]
        [MaxLength(100)]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [MaxLength(100)]
        public string LastName { get; set; }

        [Required]
        [DisplayName("Description")]
        [MaxLength(4000)]
        public string Specialization { get; set; }
    }
}
