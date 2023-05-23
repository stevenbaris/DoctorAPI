using DoctorApp.Models;
using DoctorApp.ViewModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace DoctorAPP.Repository.MsSQL
{
    public class TaskRestRepository : ITaskRepository
    {
        // interact with database and perform CRUD 

        string baseURL = "https://jsonplaceholder.typicode.com";
        string baseURLLocal = "http://localhost:5185";
        HttpClient httpClient = new HttpClient();
        public TaskRestRepository()
        {
        }

        public async Task<Doctor> AddDoctor(Doctor newDoctor)
        {

            var data = JsonConvert.SerializeObject(newDoctor);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync(baseURLLocal + "/api/Doctor/", content);
            if (response.IsSuccessStatusCode)
            {
                var responsecontent = await response.Content.ReadAsStringAsync();
                var contact = JsonConvert.DeserializeObject<Doctor>(responsecontent);
                return contact;
            }
            return null;
        }

        public async Task DeleteDoctor(int doctorId)
        {
            var response = await httpClient.DeleteAsync(baseURLLocal + $"/api/Doctor/{doctorId}");
            if (!response.IsSuccessStatusCode)
            {
                throw new Exception("Failed to delete contact. Error: " + response.StatusCode);
            }
        }

        public async Task<List<Doctor>> GetAllDoctor()
        {
            var response = await httpClient.GetAsync(baseURLLocal + "/api/Doctor/");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync();
                var List = JsonConvert.DeserializeObject<List<Doctor>>(data);
                return List;
            }
            return null;
        }

        public async Task<Doctor> GetDoctorById(int id)
        {
            var response = await httpClient.GetAsync(baseURLLocal + $"/api/Doctor/{id}");
            if (response.IsSuccessStatusCode)
            {
                var data = await response.Content.ReadAsStringAsync(); // json standard
                var piece = JsonConvert.DeserializeObject<Doctor>(data);
                return piece;
            }
            return null;
        }

        public async Task<Doctor> UpdateDoctor(int doctorId, Doctor newDoctor)
        {
            var data = JsonConvert.SerializeObject(newDoctor);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await httpClient.PutAsync(baseURLLocal + $"/api/Doctor/{doctorId}", content);
            response.EnsureSuccessStatusCode();

            var responseContent = await response.Content.ReadAsStringAsync();
            var modified = JsonConvert.DeserializeObject<Doctor>(responseContent);
            return modified;

        }
    }
}
