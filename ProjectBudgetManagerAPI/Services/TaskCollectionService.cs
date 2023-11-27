using Microsoft.EntityFrameworkCore;
using ProjectBudgetManagerAPI.Config;
using ProjectBudgetManagerAPI.Services.Interfaces;
using Task = ProjectBudgetManagerAPI.Models.Task;

namespace ProjectBudgetManagerAPI.Services
{
    public class TaskCollectionService : ITaskCollectionService
    {
        private readonly ProjectBudgetManagerDbContext _projectBudgetManagerDbContext;

        public TaskCollectionService(ProjectBudgetManagerDbContext projectBudgetManagerDbContext)
        {
            _projectBudgetManagerDbContext = projectBudgetManagerDbContext;
        }

        public async Task<List<Task>> GetAll(Guid employeeId)
        {
            var result = await _projectBudgetManagerDbContext.EmployeeTasks
                              .Where(et => et.EmployeeId == employeeId)
                              .Include(et => et.Task)
                              .ThenInclude(t => t.Project)
                              .Select(et => et.Task)
                              .ToListAsync();
            return result;
        }
        public async Task<Task> GetTaskById(Guid taskId)
        {
            var result = await _projectBudgetManagerDbContext.Tasks.FirstOrDefaultAsync(p => p.TaskId == taskId);
            return result;
        }

    }
}
