using Microsoft.AspNetCore.Mvc;
using ProjectBudgetManagerAPI.Models;
using ProjectBudgetManagerAPI.Services;
using ProjectBudgetManagerAPI.Services.Interfaces;

namespace ProjectBudgetManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService ?? throw new ArgumentNullException(nameof(ProjectService));
        }

        [HttpGet("GetAllProjects")]
        public async Task<IActionResult> GetAllProjects()
        {
            List<Project> projects = await _projectService.GetAll();
            return Ok(projects);
        }

        [HttpGet("GetStatisticsForAProject/{projectId}")]
        public async Task<IActionResult> GetStatisticsForAProject(Guid projectId)
        {
            try
            {
                var statistics = await _projectService.GetStatistics(projectId);

                if (statistics == null)
                {
                    return NotFound();
                }

                return Ok(statistics);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("GetProjectById/{projectId}")]
        public async Task<IActionResult> GetProjectById(Guid projectId)
        {
            try
            {
                var project = await _projectService.GetProjectById(projectId);
                return Ok(project);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("GeTasksThatBelongToProject/{projectId}")]
        public async Task<IActionResult> GetTasksThatBelongToProject(Guid projectId)
        {
            try
            {
                var tasks = await _projectService.GetTasksThatBelongToProject(projectId);
                return Ok(tasks);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }
    }
}
