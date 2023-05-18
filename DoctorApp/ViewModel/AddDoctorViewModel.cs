using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace DoctorApp.ViewModel
{
    public class AddDoctorViewModel
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
