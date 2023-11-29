using Microsoft.EntityFrameworkCore;
using ProjectBudgetManagerAPI.Config;
using ProjectBudgetManagerAPI.DTO;
using ProjectBudgetManagerAPI.Helpers;
using ProjectBudgetManagerAPI.Models;
using ProjectBudgetManagerAPI.Services.Interfaces;
using System.Threading.Tasks;
using Task = ProjectBudgetManagerAPI.Models.Task;

namespace ProjectBudgetManagerAPI.Services
{
    public class TaskService : ITaskService
    {
        private readonly ProjectBudgetManagerDbContext _projectBudgetManagerDbContext;

        public TaskService(ProjectBudgetManagerDbContext projectBudgetManagerDbContext)
        {
            _projectBudgetManagerDbContext = projectBudgetManagerDbContext;
        }

        public async Task<List<WorkDays>> GetAllTasksOfEmployeeInAnInterval(Guid employeeId, DateTime startDate, DateTime endDate)
        {
            var workDaysList = new List<WorkDays>();

            for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
            {
                var employeeTasks = await _projectBudgetManagerDbContext.EmployeeTasks
                    .Include(et => et.Task)
                    .Include(et => et.Task.Project)
                    .Where(et => et.EmployeeId == employeeId && currentDate == et.Date)
                    .ToListAsync();

                var workDays = new WorkDays
                {
                    Date = currentDate,
                    EmployeeTasks = employeeTasks.Select(et => new EmployeeTaskDTOWithHours
                    {
                        Hours = et.Hours,
                        Task = et.Task
                    }).ToList(),
                };

                if(workDays.EmployeeTasks.Count != 0)
                {
                    workDaysList.Add(workDays);
                }
            }

            return workDaysList;
        }

        public async Task<Task> GetTaskById(Guid taskId)
        {
            var result = await _projectBudgetManagerDbContext.Tasks.FirstOrDefaultAsync(p => p.TaskId == taskId);
            return result;
        }

    }
}
