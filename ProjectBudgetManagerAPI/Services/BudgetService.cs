using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectBudgetManagerAPI.Config;
using ProjectBudgetManagerAPI.DTO;
using ProjectBudgetManagerAPI.Models;
using ProjectBudgetManagerAPI.Services.Interfaces;

namespace ProjectBudgetManagerAPI.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly ProjectBudgetManagerDbContext _projectBudgetManagerDbContext;

        private readonly IMapper _mapper;

        public BudgetService(ProjectBudgetManagerDbContext projectBudgetManagerDbContext, IMapper mapper)
        {
            _projectBudgetManagerDbContext = projectBudgetManagerDbContext;
            _mapper = mapper;
        }

        public async System.Threading.Tasks.Task UpdateSpentBudgetAfterPaySalaryForAnEmployee(Guid employeeId, Guid projectId, DateTime startDate, DateTime endDate)
        {
            decimal spendings = 0;
            var budget = await _projectBudgetManagerDbContext.Budget.FirstOrDefaultAsync(b => b.ProjectId == projectId);

            if (budget != null)
            {
                for (DateTime currentDate = startDate; currentDate <= endDate; currentDate = currentDate.AddDays(1))
                {
                    spendings += CalculateSpendingsInADayForAProject(employeeId, projectId, currentDate).Result;
                }

                BudgetDTO budgetDTO = new()
                {
                    BudgetId = budget.BudgetId,
                    ProjectId = budget.ProjectId,
                    InitialBudget = budget.InitialBudget,
                    SpentBudget = budget.SpentBudget + spendings
                };

                var mapped = _mapper.Map<BudgetDTO, Budget>(budgetDTO);

                _projectBudgetManagerDbContext.ChangeTracker.Clear();
                _projectBudgetManagerDbContext.Update(mapped);
                await _projectBudgetManagerDbContext.SaveChangesAsync();
            }
        }

        public async Task<decimal> CalculateSpendingsInADayForAProject(Guid employeeId, Guid projectId, DateTime date)
        {
            decimal spendings = 0;
            var employeeTasks = await _projectBudgetManagerDbContext.EmployeeTasks
                .Include(et => et.Task)
                .Include(et => et.Task.Project)
                .Where(et => et.EmployeeId == employeeId && et.Date == date && et.Task.ProjectId == projectId)
                .ToListAsync();

            foreach (var employeeTask in employeeTasks)
            {
                if (!employeeTask.Task.Project.IsSpecial)
                {
                    var employee = await _projectBudgetManagerDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeTask.EmployeeId);

                    spendings += (decimal)employee.HourlyPay * employeeTask.Hours;
                }
                else
                {
                    if (employeeTask.Task.IsDone)
                    {
                        spendings += employeeTask.Task.Price;
                    }
                }
            }

            return spendings;
        }
    }
}
