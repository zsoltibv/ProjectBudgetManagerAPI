using ProjectBudgetManagerAPI.DTO;
using ProjectBudgetManagerAPI.Models;

namespace ProjectBudgetManagerAPI.Helpers
{
    public class WorkDays
    {
        public DateTime Date { get; set; }
        public List<EmployeeTaskDTOWithHours> EmployeeTasks { get; set; }
    }
}
