using Microsoft.AspNetCore.Mvc;
using ProjectBudgetManagerAPI.Services;
using ProjectBudgetManagerAPI.Services.Interfaces;

namespace ProjectBudgetManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SalaryController : ControllerBase
    {
        private ISalaryService _salaryService;

        public SalaryController(ISalaryService salaryService)
        {
            _salaryService = salaryService ?? throw new ArgumentNullException(nameof(ExportDataToDbService));
        }

        [HttpPut("PaySalary/{employeeId}")]
        public async Task<IActionResult> PaySalary(Guid employeeId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var result = await _salaryService.PaySalaryForEmployee(employeeId, startDate, endDate);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetSalary/{employeeId}")]
        public async Task<IActionResult> GetSalaries(Guid employeeId)
        {
            try
            {
                var result = await _salaryService.GetSalariesOfEmployee(employeeId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
