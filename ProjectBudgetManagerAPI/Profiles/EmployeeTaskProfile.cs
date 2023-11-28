using AutoMapper;
using ProjectBudgetManagerAPI.DTO;
using ProjectBudgetManagerAPI.Models;

namespace ProjectBudgetManagerAPI.Profiles
{
    public class EmployeeTaskProfile : Profile
    {
        public EmployeeTaskProfile()
        {
            CreateMap<EmployeeTask, EmployeeTaskDTO>();
            CreateMap<EmployeeTaskDTO, EmployeeTask>();
        }
    }
}
