using DoctorAPI.DTO;
using DoctorAPI.Models;

namespace DoctorAPI.Repository
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAllDoctor();
        Doctor GetDoctorById(int id);
        Task AddDoctor(DoctorDTO doctorDto);
        Task UpdateDoctor(int doctorId, DoctorDTO doctorDto);
        Doctor DeleteDoctor(int doctorId);
    }
}
