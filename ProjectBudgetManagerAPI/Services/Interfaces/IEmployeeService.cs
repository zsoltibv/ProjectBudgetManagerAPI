using ProjectBudgetManagerAPI.Models;

namespace ProjectBudgetManagerAPI.Services.Interfaces
{
    public interface IEmployeeService
    {
        Task<Employee> GetEmployeeById(Guid employeeId);
    }
}
