using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBudgetManagerAPI.Models
{
    public class Task
    {
        public Guid TaskId { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsDone { get; set; }
        public Guid ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}
