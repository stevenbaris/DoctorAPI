using DoctorAPI.Repository;
using DoctorAPI.Repository.MsSQL;
using DoctorAPI.DTO;
using DoctorAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DoctorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorRepository _repo;

        public DoctorController(IDoctorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDoctor()
        {
            var result = await _repo.GetAllDoctor();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetDoctorById(int id)
        {
            var result = _repo.GetDoctorById(id);

            if (result == null)
            {
                var errormessage = $"Doctor ID: {id} not found.";
                return NotFound(errormessage);
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDoctor(DoctorDTO doctorDto)
        {
            await _repo.AddDoctor(doctorDto);

            return Ok(doctorDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDoctor(int id, DoctorDTO doctorDto)
        {
            await _repo.UpdateDoctor(id, doctorDto);

            return Ok(doctorDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDoctor(int id)
        {
            var result = _repo.DeleteDoctor(id);

            if (result == null)
            {
                var errormessage = $"Doctor ID: {id} not found.";
                return NotFound(errormessage);
            }

            return Ok(result);
        }
    }
}

