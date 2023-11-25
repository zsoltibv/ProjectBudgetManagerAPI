namespace ProjectBudgetManagerAPI.Helpers
{
    public class ProjectStatistics
    {
        public decimal InitialBudget { get; set; }
        public decimal SpentBudget { get; set; }
        public decimal RemainingBudget { get; set; }
        public int NumberOfHoursNormalProject{ get; set; }
        public int NumberOfDoneTasksSpecialProject { get; set; }
    }
}
