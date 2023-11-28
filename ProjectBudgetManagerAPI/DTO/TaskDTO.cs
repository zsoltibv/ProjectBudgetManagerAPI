namespace ProjectBudgetManagerAPI.DTO
{
    public class TaskDTO
    {
        public Guid TaskId { get; set; }
        public Guid ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsDone { get; set; } = false;
    }
}
