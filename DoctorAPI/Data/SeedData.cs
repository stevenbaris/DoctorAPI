using DoctorApp.Models.Physician;
using Microsoft.EntityFrameworkCore;

namespace DoctorApp.Data
{
    public static class SeedData
    {
        public static void SeedDefaultData(this ModelBuilder modelBuilder)
        {
            var specialization = new List<Doctor>
                {
                new Doctor(1, "Maria", "Clara", "Opthamologist"),
                new Doctor(2, "Juan", "Cruz", "Neurologist"),
                new Doctor(3, "Tim", "Hortons", "Surgeon"),

                };

            modelBuilder.Entity<Doctor>().HasData(specialization);
        }
    }
}
