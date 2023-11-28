using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBudgetManagerAPI.Models
{
    public class EmployeeTask
    {
        public Guid EmployeeTaskId { get; set; }
        public Guid EmployeeId { get; set; }
        public Guid TaskId { get; set; }

        public int Hours { get; set; }
        public DateTime Date { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        [ForeignKey("TaskId")]
        public Task Task { get; set; }
    }
}
