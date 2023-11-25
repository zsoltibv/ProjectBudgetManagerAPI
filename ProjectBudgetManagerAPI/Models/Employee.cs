using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBudgetManagerAPI.Models
{
    public class Employee
    {
        public Guid EmployeeId { get; set; }

        public string Name { get; set; }
        public double HourlyPay { get; set; }
    }
}
