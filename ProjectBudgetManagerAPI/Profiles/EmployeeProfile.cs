using AutoMapper;
using ProjectBudgetManagerAPI.DTO;
using ProjectBudgetManagerAPI.Models;

namespace ProjectBudgetManagerAPI.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>();
        }
    }
}
