using RmWebApi.DTOs.ProjectDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface IProjectService : IGenericService<ResultProjectDto, CreateProjectDto, UpdateProjectDto, Project>
{
}
