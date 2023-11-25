using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ProjectBudgetManagerAPI.Models
{
    public class Task
    {
        public Guid TaskId { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool IsDone { get; set; }

        [JsonIgnore]
        public Guid ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}
