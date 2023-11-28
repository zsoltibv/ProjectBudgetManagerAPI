using ProjectBudgetManagerAPI.Helpers;

namespace ProjectBudgetManagerAPI.Services.Interfaces
{
    public interface IExportDataToDbService
    {
        public Task AddEmployees(string url);
        public Task AddProjects(string url);
        public Task AddBudget(string url);
        public Task AddTasks(string url);
        public Task AddEmployeeTask(string url);
        public Task AddWeeklySalary(string url);
        public Task AddAllData(EmployeesDS employeesDS);
        public Task UpdateWeeklySalaryIsPaid(string url, string employeeName, DateTime startDate, DateTime endDate);
    }
}
