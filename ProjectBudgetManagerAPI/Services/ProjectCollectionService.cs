using Microsoft.EntityFrameworkCore;
using ProjectBudgetManagerAPI.Config;
using ProjectBudgetManagerAPI.Models;
using ProjectBudgetManagerAPI.Helpers;
using ProjectBudgetManagerAPI.Services.Interfaces;

public class ProjectCollectionService : IProjectCollectionService
{
    private readonly ProjectBudgetManagerDbContext _projectBudgetManagerDbContext;

    public ProjectCollectionService(ProjectBudgetManagerDbContext projectBudgetManagerDbContext)
    {
        _projectBudgetManagerDbContext = projectBudgetManagerDbContext;
    }

    public async Task<List<Project>> GetAll()
    {
        var result = await _projectBudgetManagerDbContext.Projects.ToListAsync();
        return result;
    }

    public async Task<ProjectStatistics> GetStatistics(Guid projectId)
    {
        var project = await _projectBudgetManagerDbContext.Projects.FirstOrDefaultAsync(p => p.ProjectId == projectId);

        if (project == null)
        {
            return null;
        }

        var budget = await _projectBudgetManagerDbContext.Budget.FirstOrDefaultAsync(b => b.ProjectId == projectId);

        if (budget == null)
        {
            return null;
        }

        var initialBudget = budget.InitialBudget;
        var spentBudget = budget.SpentBudget;
        var remainingBudget = initialBudget - spentBudget;

        var numberOfHoursNormalProject = await _projectBudgetManagerDbContext.EmployeeTasks
                                                 .Where(et => et.Task.ProjectId == projectId && et.Task.Project.IsSpecial == false)
                                                 .SumAsync(et => et.Hours);


        var numberOfDoneTasksSpecialProject = await _projectBudgetManagerDbContext.Tasks
                                                    .Where(t => t.ProjectId == projectId && t.Project.IsSpecial && t.IsDone)
                                                    .CountAsync();

        return new ProjectStatistics
        {
            InitialBudget = initialBudget,
            SpentBudget = spentBudget,
            RemainingBudget = remainingBudget,
            NumberOfHoursNormalProject = numberOfHoursNormalProject,
            NumberOfDoneTasksSpecialProject = numberOfDoneTasksSpecialProject
        };
    }
}
