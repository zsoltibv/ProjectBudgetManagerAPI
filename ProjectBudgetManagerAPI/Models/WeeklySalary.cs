using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBudgetManagerAPI.Models
{
    public class WeeklySalary
    {
        public Guid WeeklySalaryId { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int GrossAmount { get; set; }
        public int GrossAmountAfterTax { get; set; }
        public int IsPaid { get; set; }
        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
    }
}
