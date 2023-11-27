using Microsoft.AspNetCore.Mvc;
using ProjectBudgetManagerAPI.Services;
using ProjectBudgetManagerAPI.Services.Interfaces;

namespace ProjectBudgetManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService ?? throw new ArgumentNullException(nameof(EmployeeService));
        }

        [HttpGet("GetEmployeeById/{employeeId}")]
        public async Task<IActionResult> GetEmployeeById(Guid employeeId)
        {
            try
            {
                var employee = await _employeeService.GetEmployeeById(employeeId);
                return Ok(employee);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
