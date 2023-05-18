using DoctorApp.Models;
using DoctorApp.Repository;
using DoctorApp.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Controllers
{
    public class DoctorController : Controller
    {
        string baseURL = "http://localhost:5185";

        HttpClient httpClient = new HttpClient();

        public IActionResult Index()
        {
            var response = httpClient.GetAsync(baseURL + "/api/Doctor/getdoctorlist").Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                List<Doctor> todos = JsonConvert.DeserializeObject<List<Doctor>>(data);
                return View(todos);
            }
            return View();
        }
        [HttpGet]
        public IActionResult AddTodo()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddTodo(AddDoctorViewModel todoVM)
        {
            string newBaseURl = baseURL + "/api/Doctor/adddoctor";
            var stringContent = new StringContent(JsonConvert.SerializeObject(todoVM), Encoding.UTF8, "application/json");
            var response = httpClient.PostAsync(newBaseURl, stringContent).Result;
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                Doctor todo = JsonConvert.DeserializeObject<Doctor>(responsecontent);

                return RedirectToAction("Index");
            }

            return View();
        }
        [HttpGet]
        public IActionResult Details(int todoId)
        {
            var response = httpClient.GetAsync(baseURL + "/api/Doctor/getdoctorbyid/" + todoId).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                Doctor todos = JsonConvert.DeserializeObject<Doctor>(data);
                return View(todos);
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int todoId)
        {
            var response = httpClient.GetAsync(baseURL + "/api/Doctor/getdoctorbyid/" + todoId).Result;
            if (response.IsSuccessStatusCode)
            {
                var data = response.Content.ReadAsStringAsync().Result;
                AddDoctorViewModel todos = JsonConvert.DeserializeObject<AddDoctorViewModel>(data);
                return View(todos);
            }
            return View();
        }
        [HttpPost]
        public IActionResult Edit(AddDoctorViewModel todoVM, int todoId)
        {
            string data = JsonConvert.SerializeObject(todoVM);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = httpClient.PutAsync(baseURL + "/api/Doctor/updatedoctor/" + todoId, content).Result;
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = response.Content.ReadAsStringAsync().Result;
                Doctor todo = JsonConvert.DeserializeObject<Doctor>(responsecontent);
                return View(todo);
            }
            return View();
        }
        public IActionResult Delete(int todoId)
        {
            var response = httpClient.DeleteAsync(baseURL + "/api/Doctor/deletedoctor/" + todoId).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest(response);
        }
    }
}


