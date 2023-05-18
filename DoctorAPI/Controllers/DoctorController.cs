using DoctorAPI.Repository;
using DoctorApp.Models.Physician;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : Controller
    {
        IDoctorRepository _repo;

        public DoctorController(IDoctorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet("getdoctorlist")]
        public async Task<List<Doctor>> GetDoctorList()
        {
            try
            {
                return await _repo.GetDoctorList();
            }
            catch
            {
                throw;
            }
        }

        [HttpGet("getdoctorbyid")]
        public async Task<IEnumerable<Doctor>> GetDoctorById(int Id)
        {
            try
            {
                var response = await _repo.GetDoctorById(Id);

                if (response == null)
                {
                    return null;
                }

                return response;
            }
            catch
            {
                throw;
            }
        }

        [HttpPost("adddoctor")]
        public async Task<IActionResult> AddDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest();
            }

            try
            {
                var response = await _repo.AddDoctor(doctor);

                return Ok(response);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut("updatedoctor")]
        public async Task<IActionResult> UpdateDoctor(Doctor doctor)
        {
            if (doctor == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _repo.UpdateDoctor(doctor);
                return Ok(result);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete("deletedoctor")]
        public async Task<int> DeleteDoctor(int Id)
        {
            try
            {
                var response = await _repo.DeleteDoctor(Id);
                return response;
            }
            catch
            {
                throw;
            }
        }
    }
}