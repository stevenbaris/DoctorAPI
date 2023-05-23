using DoctorAPI.Model;
using DoctorAPI.Data;
using DoctorAPI.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace DoctorAPI.Data
{
    public class DDbContext : IdentityDbContext<ApplicationUser>
    {
        public DDbContext(DbContextOptions<DDbContext> options) : base(options) 
        {

        }
        
        public DbSet<Doctor> Doctors => Set<Doctor>();
    }
}
