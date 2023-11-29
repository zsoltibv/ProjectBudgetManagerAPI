using Microsoft.AspNetCore.Mvc;
using ProjectBudgetManagerAPI.Models;
using ProjectBudgetManagerAPI.Services;
using ProjectBudgetManagerAPI.Services.Interfaces;
using Task = ProjectBudgetManagerAPI.Models.Task;

namespace ProjectBudgetManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService ?? throw new ArgumentNullException(nameof(TaskService));
        }

        [HttpGet("GetAllTasksOfEmployeeInAnInterval")]
        public async Task<IActionResult> GetAllTasksOfEmployeeInAnInterval(Guid employeeId, DateTime startDate, DateTime endDate)
        {
            try
            {
                var tasks = await _taskService.GetAllTasksOfEmployeeInAnInterval(employeeId, startDate, endDate);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }


        [HttpGet("GetTaskById/{taskId}")]
        public async Task<IActionResult> GetTaskById(Guid taskId)
        {
            try
            {
                var task = await _taskService.GetTaskById(taskId);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
