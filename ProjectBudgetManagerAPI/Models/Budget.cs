using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBudgetManagerAPI.Models
{
    public class Budget
    {
        public Guid BudgetId { get; set; }

        public decimal InitialBudget { get; set; }
        public decimal SpentBudget { get; set; }
        public Guid ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project Project { get; set; }
    }
}
