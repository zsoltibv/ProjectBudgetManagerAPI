using AutoMapper;
using ProjectBudgetManagerAPI.DTO;
using ProjectBudgetManagerAPI.Models;

namespace ProjectBudgetManagerAPI.Profiles
{
    public class ProjectProfile : Profile
    {
        public ProjectProfile()
        {
            CreateMap<Project, ProjectDTO>();
            CreateMap<ProjectDTO, Project>();
        }
    }
}
