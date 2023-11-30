namespace ProjectBudgetManagerAPI.Services.Interfaces
{
    public interface IBudgetService
    {
        public Task UpdateSpentBudgetAfterPaySalaryForAnEmployee(Guid employeeId, Guid projectId, DateTime startDate, DateTime endDate);
        public Task<decimal> CalculateSpendingsInADayForAProject(Guid employeeId, Guid projectId, DateTime date);
    }
}
