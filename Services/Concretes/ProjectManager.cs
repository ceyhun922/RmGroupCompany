using AutoMapper;
using RmWebApi.DTOs.ProjectDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class ProjectManager : IProjectService
{
    private readonly IProjectRepository _projectRepository;
    private readonly IMapper _mapper;

    public ProjectManager(IProjectRepository projectRepository, IMapper mapper)
    {
        _projectRepository = projectRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultProjectDto>> GetAllAsync()
    {
        var entities = await _projectRepository.GetAllAsync();
        return _mapper.Map<List<ResultProjectDto>>(entities);
    }

    public async Task<ResultProjectDto> GetByIdAsync(int id)
    {
        var entity = await _projectRepository.GetByIdAsync(id);
        return _mapper.Map<ResultProjectDto>(entity);
    }

    public async Task CreateAsync(CreateProjectDto dto)
    {
        var entity = _mapper.Map<Project>(dto);
        await _projectRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateProjectDto dto)
    {
        var entity = _mapper.Map<Project>(dto);
        await _projectRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _projectRepository.GetByIdAsync(id);
        await _projectRepository.DeleteAsync(entity);
    }
}
