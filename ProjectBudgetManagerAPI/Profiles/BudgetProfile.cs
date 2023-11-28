using AutoMapper;
using ProjectBudgetManagerAPI.DTO;
using ProjectBudgetManagerAPI.Models;

namespace ProjectBudgetManagerAPI.Profiles
{
    public class BudgetProfile : Profile
    {
        public BudgetProfile()
        {
            CreateMap<Budget, BudgetDTO>();
            CreateMap<BudgetDTO, Budget>();
        }
    }
}
