using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectBudgetManagerAPI.Helpers;
using ProjectBudgetManagerAPI.Models;
using ProjectBudgetManagerAPI.Services;
using ProjectBudgetManagerAPI.Services.Interfaces;
using System.Text;

namespace ProjectBudgetManagerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExportDataToDbController : ControllerBase
    {
        private IExportDataToDbService _exportDataToDbService;

        public ExportDataToDbController(IExportDataToDbService exportDataToDbService)
        {
            _exportDataToDbService = exportDataToDbService ?? throw new ArgumentNullException(nameof(ExportDataToDbService));
        }

        [HttpPost("AddAllData")]
        public async Task<IActionResult> ProcessJsonFile([FromForm] IFormFile jsonFile)
        {
            if (jsonFile != null && jsonFile.Length > 0)
            {
                using (var streamReader = new StreamReader(jsonFile.OpenReadStream(), Encoding.UTF8))
                {
                    var jsonContent = await streamReader.ReadToEndAsync();

                    try
                    {
                        var employees = JsonConvert.DeserializeObject<EmployeesDS>(jsonContent);

                        await _exportDataToDbService.AddAllData(employees);

                        return Ok($"JSON file processed successfully. Decoded content: {jsonContent}");
                    }
                    catch (JsonException ex)
                    {
                        return BadRequest($"Error decoding JSON: {ex.Message}");
                    }
                }
            }

            return BadRequest("Invalid file or no file provided.");
        }
    }
}
