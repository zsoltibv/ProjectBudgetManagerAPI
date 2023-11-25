using Task = ProjectBudgetManagerAPI.Models.Task;

namespace ProjectBudgetManagerAPI.Services.Interfaces
{
    public interface ITaskCollectionService 
    {
        Task<List<Task>> GetAll();
    }
}
