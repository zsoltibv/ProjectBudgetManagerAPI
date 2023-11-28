using AutoMapper;
using ProjectBudgetManagerAPI.DTO;
using ProjectBudgetManagerAPI.Models;

namespace ProjectBudgetManagerAPI.Profiles
{
    public class WeeklySalaryProfile : Profile
    {
        public WeeklySalaryProfile()
        {
            CreateMap<WeeklySalary, WeeklySalaryDTO>();
            CreateMap<WeeklySalaryDTO, WeeklySalary>();
        }
    }
}
