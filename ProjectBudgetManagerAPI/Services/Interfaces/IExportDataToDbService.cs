using ProjectBudgetManagerAPI.Helpers;

namespace ProjectBudgetManagerAPI.Services.Interfaces
{
    public interface IExportDataToDbService
    {
        public Task AddEmployees();
        public Task AddProjects();
        public Task AddBudget();
        public Task AddTasks();
        public Task AddEmployeeTask();
        public Task AddWeeklySalary();
        public Task AddAllData(EmployeesDS employeesDS);
        public Task UpdateWeeklySalaryIsPaid(string employeeName, DateTime startDate, DateTime endDate);
    }
}
