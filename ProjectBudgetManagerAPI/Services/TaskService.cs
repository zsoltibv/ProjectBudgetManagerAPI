using Microsoft.EntityFrameworkCore;
using ProjectBudgetManagerAPI.Config;
using ProjectBudgetManagerAPI.Helpers;
using ProjectBudgetManagerAPI.Models;
using ProjectBudgetManagerAPI.Services.Interfaces;
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

        public async Task<WorkDays> GetAllTasksOfEmployeeInAnInterval(Guid employeeId, DateTime startDate, DateTime endDate)
        {
            var employeeName = await _projectBudgetManagerDbContext.Employees
                .Where(e => e.EmployeeId == employeeId)
                .Select(e => e.Name)
                .FirstOrDefaultAsync();

            var tasks = await _projectBudgetManagerDbContext.EmployeeTasks
                .Include(et => et.Task)
                .Include(et => et.Task.Project)
                .Where(et => et.EmployeeId == employeeId && startDate <= et.Date && et.Date <= endDate)
                .ToListAsync();

            var workDays = new WorkDays
            {
                EmployeeName = employeeName,
                Date = tasks.Select(et => et.Date).Distinct().ToList(),
                TaskNames = tasks.Select(et => et.Task.Name).ToList(),
                ProjectNames = tasks.Select(et => et.Task.Project.Name).ToList(),
                HoursWorked = tasks.Select(et => et.Hours).ToList(),
                IsTaskDone = tasks.Select(et => et.Task.IsDone).ToList()
            };

            return workDays;
        }

        public async Task<Task> GetTaskById(Guid taskId)
        {
            var result = await _projectBudgetManagerDbContext.Tasks.FirstOrDefaultAsync(p => p.TaskId == taskId);
            return result;
        }

    }
}
