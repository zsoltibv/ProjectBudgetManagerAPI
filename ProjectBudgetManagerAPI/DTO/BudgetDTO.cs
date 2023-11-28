namespace ProjectBudgetManagerAPI.DTO
{
    public class BudgetDTO
    {
        public Guid BudgetId { get; set; }
        public Guid ProjectId { get; set; }
        public decimal InitialBudget { get; set; }
        public decimal SpentBudget { get; set; }
    }
}
