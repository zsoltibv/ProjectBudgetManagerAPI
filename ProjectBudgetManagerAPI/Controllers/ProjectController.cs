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
        private IProjectCollectionService _projectCollectionService;

        public ProjectController(IProjectCollectionService projectCollectionService)
        {
            _projectCollectionService = projectCollectionService ?? throw new ArgumentNullException(nameof(ProjectCollectionService));
        }

        [HttpGet("GetAllProjects")]
        public async Task<IActionResult> GetAllProjects()
        {
            List<Project> projects = await _projectCollectionService.GetAll();
            return Ok(projects);
        }

        [HttpGet("GetStatisticsForAProject/{projectId}")]
        public async Task<IActionResult> GetStatisticsForAProject(Guid projectId)
        {
            try
            {
                var statistics = await _projectCollectionService.GetStatistics(projectId);

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



    }
}
