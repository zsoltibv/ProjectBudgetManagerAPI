using AutoMapper;
using ProjectBudgetManagerAPI.DTO;
using ProjectBudgetManagerAPI.Models;

namespace ProjectBudgetManagerAPI.Profiles
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<Models.Task, TaskDTO>();
            CreateMap<TaskDTO, Models.Task>();
        }
    }
}
