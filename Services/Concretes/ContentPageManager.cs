using AutoMapper;
using RmWebApi.DTOs.ContentPageDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class ContentPageManager : IContentPageService
{
    private readonly IContentPageRepository _contentPageRepository;
    private readonly IMapper _mapper;

    public ContentPageManager(IContentPageRepository contentPageRepository, IMapper mapper)
    {
        _contentPageRepository = contentPageRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultContentPageDto>> GetAllAsync()
    {
        var entities = await _contentPageRepository.GetAllAsync();
        return _mapper.Map<List<ResultContentPageDto>>(entities);
    }

    public async Task<ResultContentPageDto> GetByIdAsync(int id)
    {
        var entity = await _contentPageRepository.GetByIdAsync(id);
        return _mapper.Map<ResultContentPageDto>(entity);
    }

    public async Task CreateAsync(CreateContentPageDto dto)
    {
        var entity = _mapper.Map<ContentPage>(dto);
        await _contentPageRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateContentPageDto dto)
    {
        var entity = _mapper.Map<ContentPage>(dto);
        await _contentPageRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _contentPageRepository.GetByIdAsync(id);
        await _contentPageRepository.DeleteAsync(entity);
    }
}
