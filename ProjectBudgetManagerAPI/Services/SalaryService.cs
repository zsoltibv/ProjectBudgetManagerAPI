using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProjectBudgetManagerAPI.Config;
using ProjectBudgetManagerAPI.DTO;
using ProjectBudgetManagerAPI.Models;
using ProjectBudgetManagerAPI.Services;
using ProjectBudgetManagerAPI.Services.Interfaces;

namespace ProjectBudgetManagerAPI.Services
{
    public class SalaryService : ISalaryService
    {
        private readonly ProjectBudgetManagerDbContext _projectBudgetManagerDbContext;
        private IBudgetService _budgetService;

        private readonly IMapper _mapper;

        public SalaryService(ProjectBudgetManagerDbContext projectBudgetManagerDbContext, IMapper mapper, IBudgetService budgetService) 
        { 
            _projectBudgetManagerDbContext = projectBudgetManagerDbContext;
            _budgetService = budgetService;
            _mapper = mapper;
        }

        public async Task<WeeklySalary> PaySalaryForEmployee(Guid employeeId, DateTime startDate, DateTime endDate)
        {
            var salary = await _projectBudgetManagerDbContext.WeeklySalaries.FirstOrDefaultAsync(s => s.EmployeeId == employeeId && s.StartDate == startDate && s.EndDate == endDate);

            if (salary != null) 
            {
                WeeklySalaryDTO weeklySalaryDTO = new()
                {
                    WeeklySalaryId = salary.WeeklySalaryId,
                    EmployeeId = salary.EmployeeId,
                    StartDate = salary.StartDate,
                    EndDate = salary.EndDate,
                    GrossAmount = salary.GrossAmount,
                    GrossAmountAfterTax = salary.GrossAmountAfterTax,
                    IsPaid = 1
                };

                var projects = await _projectBudgetManagerDbContext.Projects.ToListAsync();
                
                foreach (var project in projects) 
                {
                    await _budgetService.UpdateSpentBudgetAfterPaySalaryForAnEmployee(salary.EmployeeId, project.ProjectId, startDate, endDate);
                }

                var mapper = _mapper.Map<WeeklySalaryDTO, WeeklySalary>(weeklySalaryDTO);

                _projectBudgetManagerDbContext.ChangeTracker.Clear();
                _projectBudgetManagerDbContext.Update(mapper);
                await _projectBudgetManagerDbContext.SaveChangesAsync();

                return salary;
            }

            return null;
        }

        public async Task<List<WeeklySalary>> GetSalariesOfEmployee(Guid employeeId)
        {
            var salaries = await _projectBudgetManagerDbContext.WeeklySalaries
                .Where(s => s.EmployeeId == employeeId)
                .OrderByDescending(s => s.StartDate)
                .Include(s => s.Employee)
                .ToListAsync();

            if (salaries != null)
                return salaries;

            return null;
        }
    }
}
