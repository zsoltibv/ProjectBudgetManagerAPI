using ProjectBudgetManagerAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjectBudgetManagerAPI.DTO
{
    public class EmployeeTaskDTOWithHours
    {
        public int Hours { get; set; }
        public Models.Task Task { get; set; }
    }
}
