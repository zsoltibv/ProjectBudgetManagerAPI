using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBudgetManagerAPI.Models
{
    public class Project
    {
        public Guid ProjectId { get; set; }

        public string Name { get; set; }
        public bool IsSpecial { get; set; }
    }
}
