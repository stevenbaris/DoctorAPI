using DoctorApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DoctorApp.Repository
{
    public interface IDoctorRepository
    {
        List<Doctor> GetAllTasks();

        Doctor GetTaskById(int Taskm);

        Doctor AddTask(Doctor newTaskm);

        Doctor UpdateTask(int taskmId, Doctor newTaskm);

        Doctor DeleteTask(int taskmId);
    }
}
