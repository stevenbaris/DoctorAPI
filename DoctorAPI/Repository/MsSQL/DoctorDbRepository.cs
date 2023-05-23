using DoctorAPI.Data;
using DoctorAPI.DTO;
using DoctorAPI.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DoctorAPI.Repository.MsSQL
{
    public class DoctorDbRepository : IDoctorRepository
    {
        private readonly DDbContext _context;

        public DoctorDbRepository(DDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task AddDoctor(DoctorDTO doctorDto)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@FirstName", doctorDto.FirstName));
            parameter.Add(new SqlParameter("@LastName", doctorDto.LastName));
            parameter.Add(new SqlParameter("@Specialization", doctorDto.Specialization));

            await _context.Database.ExecuteSqlRawAsync("EXEC AddDoctor @FirstName, @LastName, @Specialization",
                parameter.ToArray());
        }

        public Doctor DeleteDoctor(int doctorId)
        {
            var parameter = new SqlParameter("@DoctorId", doctorId);
            var result = _context.Doctors.FromSqlRaw("EXEC DeleteDoctor @DoctorId", parameter)
                .AsEnumerable()
                .FirstOrDefault();

            return result;

        }

        public async Task<List<Doctor>> GetAllDoctor()
        {
            return await _context.Doctors.FromSqlRaw("EXEC GetAllDoctor").ToListAsync();
        }

        public Doctor GetDoctorById(int id)
        {
            var result = _context.Doctors.FromSqlRaw("EXEC GetDoctorById @DoctorId", new SqlParameter("@DoctorId", id))
                .AsEnumerable()
                .FirstOrDefault();

            return result;
        }

        public async Task UpdateDoctor(int doctorId, DoctorDTO doctorDto)
        {
            var doctorIdParam = new SqlParameter("@DoctorId", doctorId);
            var firstParam = new SqlParameter("@FirstName", doctorDto.FirstName);
            var lastParam = new SqlParameter("@LastName", doctorDto.LastName);
            var specialParam = new SqlParameter("@Specialization", doctorDto.Specialization);


            await _context.Database.ExecuteSqlRawAsync("EXEC UpdateDoctor @DoctorId, @FirstName, @LastName, @Specialization",
                doctorIdParam, firstParam, lastParam, specialParam);
        }
    }
}
