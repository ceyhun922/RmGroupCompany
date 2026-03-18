using AutoMapper;
using RmWebApi.DTOs.ProjectCategoryDTOs;
using RmWebApi.DTOs.ProjectDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class ProjectCategoryManager : IProjectCategoryService
{
    private readonly IProjectCategoryRepository _projectCategoryRepository;
    private readonly IMapper _mapper;

    public ProjectCategoryManager(IProjectCategoryRepository projectCategoryRepository, IMapper mapper)
    {
        _projectCategoryRepository = projectCategoryRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultProjectCategoryDto>> GetAllAsync()
    {
        var entities = await _projectCategoryRepository.GetAllAsync();
        return _mapper.Map<List<ResultProjectCategoryDto>>(entities);
    }

    public async Task<ResultProjectCategoryDto> GetByIdAsync(int id)
    {
        var entity = await _projectCategoryRepository.GetByIdAsync(id);
        return _mapper.Map<ResultProjectCategoryDto>(entity);
    }

    public async Task CreateAsync(CreateProjectCategoryDto dto)
    {
        var entity = _mapper.Map<ProjectCategory>(dto);
        await _projectCategoryRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateProjectCategoryDto dto)
    {
        var entity = _mapper.Map<ProjectCategory>(dto);
        await _projectCategoryRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _projectCategoryRepository.GetByIdAsync(id);
        await _projectCategoryRepository.DeleteAsync(entity);
    }
}
