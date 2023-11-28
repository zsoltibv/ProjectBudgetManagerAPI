namespace ProjectBudgetManagerAPI.DTO
{
    public class WeeklySalaryDTO
    {
        public Guid WeeklySalaryId { get; set; }
        public Guid EmployeeId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int TotalHours { get; set; }
        public int GrossAmount { get; set; }
        public int GrossAmountAfterTax { get; set; }
        public bool IsPaid { get; set; }
    }
}
