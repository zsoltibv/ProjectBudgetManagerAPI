using ProjectBudgetManagerAPI.Models;
using ProjectBudgetManagerAPI.Helpers;
using Task = ProjectBudgetManagerAPI.Models.Task;

namespace ProjectBudgetManagerAPI.Services.Interfaces
{
    public interface IProjectService 
    {
        Task<List<Project>> GetAll();

        Task<ProjectStatistics> GetStatistics(Guid projectId);
        Task<Project> GetProjectById(Guid projectId);
        Task<List<Task>> GetTasksThatBelongToProject(Guid projectId);
    }
}
