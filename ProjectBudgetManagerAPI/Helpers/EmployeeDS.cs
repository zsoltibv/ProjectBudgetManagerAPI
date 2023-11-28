namespace ProjectBudgetManagerAPI.Helpers
{
    public class EmployeeDS
    {
        public string Name { get; set; }
        public double HourlyPay { get; set; }
        public List<DayDS> Days { get; set; }
        public int TotalHours { get; set; }
        public int GrossAmount { get; set; }
        public int Tax { get; set; }
    }
}
