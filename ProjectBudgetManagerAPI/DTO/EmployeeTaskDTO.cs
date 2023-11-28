namespace ProjectBudgetManagerAPI.DTO
{
    public class EmployeeTaskDTO
    {
        public Guid EmployeeTaskId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid TaskId { get; set; }
        public int Hours { get; set; }
        public DateTime Date {  get; set; }
    }
}
