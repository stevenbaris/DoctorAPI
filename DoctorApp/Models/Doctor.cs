using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DoctorApp.Models
{
    public class Doctor
    {
        public int DoctorId { get; set; }

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

        public Doctor() { }

        public Doctor(int doctorId, string firstName, string lastName, string specialization)
        {
            DoctorId = doctorId;
            FirstName = firstName;
            LastName = lastName;
            Specialization = specialization;
        }

    }
}
