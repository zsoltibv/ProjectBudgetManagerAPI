using ProjectBudgetManagerAPI.Helpers;

namespace ProjectBudgetManagerAPI.Services.Interfaces
{
    public interface IImportAndDeserializeDataService
    {
        string ImportJson(string filePath);
        EmployeesDS? DeserializeJson(string json);
    }
}
