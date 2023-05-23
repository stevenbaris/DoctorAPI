using DoctorApp.Models;
using DoctorAPP.Repository;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;

namespace DoctorApp.Controllers
{
    public class DoctorController : Controller
    {
        ITaskRepository _repo;

        public DoctorController(ITaskRepository repo)
        {
            this._repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var tasklist = await _repo.GetAllDoctor();
            return View(tasklist);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Doctor newDoctor) // model binded this where the views data is accepted 
        {
            await _repo.AddDoctor(newDoctor);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int doctorId)
        {
            var updated = await _repo.GetDoctorById(doctorId);
            if (updated == null)
                return NotFound();

            return View(updated);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int DoctorId, Doctor newDoctor)
        {
            if (DoctorId != newDoctor.DoctorId)
                return NotFound();

            if (ModelState.IsValid)
            {
                var modified = await _repo.UpdateDoctor(DoctorId, newDoctor);
                return RedirectToAction(nameof(Index), new { DoctorId = newDoctor.DoctorId });
            }

            return View(newDoctor);
        }

        public async Task<IActionResult> Delete(int DoctorId)
        {
            await _repo.DeleteDoctor(DoctorId);
            return RedirectToAction("Index");
        }
    }
}
