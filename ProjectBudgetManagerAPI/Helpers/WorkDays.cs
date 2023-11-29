namespace ProjectBudgetManagerAPI.Helpers
{
    public class WorkDays
    {
        public string EmployeeName { get; set; }
        public List<DateTime> Date { get; set; }
        public List<string> TaskNames { get; set; }
        public List<string> ProjectNames { get; set; }
        public List<int> HoursWorked { get; set; }
        public List<bool> IsTaskDone { get; set; }

    }
}
