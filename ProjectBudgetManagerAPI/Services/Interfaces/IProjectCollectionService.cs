using ProjectBudgetManagerAPI.Models;
using ProjectBudgetManagerAPI.Helpers;

namespace ProjectBudgetManagerAPI.Services.Interfaces
{
    public interface IProjectCollectionService 
    {
        Task<List<Project>> GetAll();

        Task<ProjectStatistics> GetStatistics(Guid projectId);
    }
}
