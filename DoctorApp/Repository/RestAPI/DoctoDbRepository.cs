using DoctorApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace DoctorApp.Repository.RestAPI
{
    public class DoctoDbRepository : Controller
    {
        public class DoctorDbRepository : IDoctorRepository
        {
            // interact with database and perform CRUD 

            string baseURL = "https://jsonplaceholder.typicode.com";
            string baseURLLocal = "http://localhost:5185";
            HttpClient httpClient = new HttpClient();
            
            public DoctorDbRepository()
            {

            }

            public Doctor AddTask(Doctor newTaskm)
            {
                throw new NotImplementedException();
            }

            public Doctor DeleteTask(int taskmId)
            {
                throw new NotImplementedException();
            }

            public List<Doctor> GetAllTasks()
            {
                // fetch todos from rest service -> http request message
                var response = httpClient.GetAsync(baseURLLocal + "/todos").Result;
                if (response.IsSuccessStatusCode)
                {
                    var data = response.Content.ReadAsStringAsync().Result;
                    List<Doctor> todos = JsonConvert.DeserializeObject<List<Doctor>>(data);
                    return todos;
                }
                return null;
            }

            public Doctor GetTaskById(int Taskm)
            {
                throw new NotImplementedException();
            }

            public Doctor UpdateTask(int taskmId, Doctor newTaskm)
            {
                throw new NotImplementedException();
            }
        }
    }
}
