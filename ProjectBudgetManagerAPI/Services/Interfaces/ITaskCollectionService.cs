using Task = ProjectBudgetManagerAPI.Models.Task;

namespace ProjectBudgetManagerAPI.Services.Interfaces
{
    public interface ITaskCollectionService 
    {
        Task<List<Task>> GetAll(Guid employeeId);

        Task<Task> GetTaskById(Guid taskId);
    }
}
