using RmWebApi.DTOs.ProjectCategoryDTOs;
using RmWebApi.DTOs.ProjectDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface IProjectCategoryService : IGenericService<ResultProjectCategoryDto, CreateProjectCategoryDto, UpdateProjectCategoryDto, ProjectCategory>
{
}
