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
        private ITaskCollectionService _taskCollectionService;

        public TaskController(ITaskCollectionService taskCollectionService)
        {
            _taskCollectionService = taskCollectionService ?? throw new ArgumentNullException(nameof(TaskCollectionService));
        }

        [HttpGet("GetAllTasks/{employeeId}")]
        public async Task<IActionResult> GetAllTasks(Guid employeeId)
        {
            try
            {
                var tasks = await _taskCollectionService.GetAll(employeeId);
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
                var task = await _taskCollectionService.GetTaskById(taskId);
                return Ok(task);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
