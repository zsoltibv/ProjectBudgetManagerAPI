using Microsoft.AspNetCore.Mvc;
using ProjectBudgetManagerAPI.Helpers;
using Task = ProjectBudgetManagerAPI.Models.Task;

namespace ProjectBudgetManagerAPI.Services.Interfaces
{
    public interface ITaskService 
    {
        Task<WorkDays> GetAllTasksOfEmployeeInAnInterval(Guid employeeId, DateTime startDate, DateTime endDate);

        Task<Task> GetTaskById(Guid taskId);
    }
}
