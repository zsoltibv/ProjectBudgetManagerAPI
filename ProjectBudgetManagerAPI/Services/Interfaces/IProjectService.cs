using ProjectBudgetManagerAPI.Models;
using ProjectBudgetManagerAPI.Helpers;

namespace ProjectBudgetManagerAPI.Services.Interfaces
{
    public interface IProjectService 
    {
        Task<List<Project>> GetAll();

        Task<ProjectStatistics> GetStatistics(Guid projectId);
        Task<Project> GetProjectById(Guid projectId);
    }
}
