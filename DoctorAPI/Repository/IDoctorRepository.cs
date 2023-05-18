using DoctorApp.Models.Physician;

namespace DoctorAPI.Repository
{
    public interface IDoctorRepository
    {
         Task<List<Doctor>> GetDoctorList();
         Task<IEnumerable<Doctor>> GetDoctorById(int Id);
         Task<int> AddDoctor(Doctor doctor);
         Task<int> UpdateDoctor(Doctor doctor);
         Task<int> DeleteDoctor(int Id);
    }
}
