using DoctorAPI.Data;
using DoctorApp.Models.Physician;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;

namespace DoctorAPI.Repository.MsSQL
{
    public class DoctorDbRepository : IDoctorRepository
    {
        DDbContext _dbContext;

        public DoctorDbRepository(DDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> AddDoctor(Doctor doctor)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@FirstName", doctor.FirstName));
            parameter.Add(new SqlParameter("@LastName", doctor.LastName));
            parameter.Add(new SqlParameter("@Specialization", doctor.Specialization));

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec AddNewDoctor @FirstName, @LastName, @Specialization", parameter.ToArray()));
            return result;
        }

        public async Task<int> DeleteDoctor(int DoctorId)
        {
            return await Task.Run(() => _dbContext.Database.ExecuteSqlInterpolatedAsync($"DeleteDoctorByID {DoctorId}"));
        }

        public async Task<IEnumerable<Doctor>> GetDoctorById(int DoctorId)
        {
            var param = new SqlParameter("@DoctorId", DoctorId);

            var doctorDetails = await Task.Run(() => _dbContext.Doctors
                            .FromSqlRaw(@"exec GetDoctorByID @DoctorId", param).ToListAsync());

            return doctorDetails;
        }

        public async Task<List<Doctor>> GetDoctorList()
        {
            return await _dbContext.Doctors
                .FromSqlRaw<Doctor>("GetDoctorList")
                .ToListAsync();
        }

        public async Task<int> UpdateDoctor(Doctor doctor)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@DoctorId", doctor.DoctorId));
            parameter.Add(new SqlParameter("@FirstName", doctor.FirstName));
            parameter.Add(new SqlParameter("@LastName", doctor.LastName));
            parameter.Add(new SqlParameter("@Specialization", doctor.Specialization));

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateDoctor @DoctorId, @FirstName, @LastName, @Specialization", parameter.ToArray()));
            return result;
        }
    }
}
