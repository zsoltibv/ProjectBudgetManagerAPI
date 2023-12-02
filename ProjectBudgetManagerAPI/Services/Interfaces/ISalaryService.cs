using ProjectBudgetManagerAPI.Models;

namespace ProjectBudgetManagerAPI.Services.Interfaces
{
    public interface ISalaryService
    {
        public Task<WeeklySalary> PaySalaryForEmployee(Guid employeeId, DateTime startDate, DateTime endDate);
        public Task<List<WeeklySalary>> GetSalariesOfEmployee(Guid employeeId);
    }
}
