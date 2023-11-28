using Microsoft.EntityFrameworkCore;
using ProjectBudgetManagerAPI.Config;
using ProjectBudgetManagerAPI.Models;
using ProjectBudgetManagerAPI.Services.Interfaces;

namespace ProjectBudgetManagerAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly ProjectBudgetManagerDbContext _projectBudgetManagerDbContext;

        public EmployeeService(ProjectBudgetManagerDbContext projectBudgetManagerDbContext)
        {
            _projectBudgetManagerDbContext = projectBudgetManagerDbContext;
        }

        public async Task<Employee> GetEmployeeById(Guid employeeId)
        {
            var result = await _projectBudgetManagerDbContext.Employees.FirstOrDefaultAsync(e => e.EmployeeId == employeeId);
            return result;
        }
        public async Task<List<Employee>> GetAllEmployees()
        {
            var result = await _projectBudgetManagerDbContext.Employees.ToListAsync();
            return result;
        }

    }
}
