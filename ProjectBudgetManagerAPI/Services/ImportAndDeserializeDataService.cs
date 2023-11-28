using Newtonsoft.Json;
using ProjectBudgetManagerAPI.Helpers;
using ProjectBudgetManagerAPI.Services.Interfaces;
using System.Text.Json.Serialization;

namespace ProjectBudgetManagerAPI.Services
{
    public class ImportAndDeserializeDataService : IImportAndDeserializeDataService
    {
        public string ImportJson(string filePath)
        {
            string json = File.ReadAllText(filePath);

            return json;
        }

        public EmployeesDS? DeserializeJson(string json)
        {
            EmployeesDS? employees = JsonConvert.DeserializeObject<EmployeesDS>(json);

            if(employees != null) 
            { 
                return employees;
            }

            return null;
        }

    }
}
