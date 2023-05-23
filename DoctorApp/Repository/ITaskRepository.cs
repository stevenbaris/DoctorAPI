using DoctorApp.Models;

namespace DoctorAPP.Repository
{
    public interface ITaskRepository // contract 
    {
        //List<Doctor> GetAllTasks();

        //// get any specific todo
        //Doctor GetTaskById(int Taskm);

        //// add todo into the list
        //Task<int> AddTask(Doctor newTaskm);

        //// update todo in the list
        //Doctor UpdateTask(int taskmId, Doctor newTaskm);

        //// delete 
        //Task<int> DeleteTask(int taskmId);

        Task<List<Doctor>> GetAllDoctor();
        Task<Doctor> GetDoctorById(int id);
        Task<Doctor> AddDoctor(Doctor newDoctor);
        Task<Doctor> UpdateDoctor(int doctorId, Doctor newDoctor);
        Task DeleteDoctor(int doctorId);
    }
}
