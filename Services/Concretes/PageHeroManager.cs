using AutoMapper;
using RmWebApi.DTOs.PageHeroDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class PageHeroManager : IPageHeroService
{
    private readonly IPageHeroRepository _pageHeroRepository;
    private readonly IMapper _mapper;

    public PageHeroManager(IPageHeroRepository pageHeroRepository, IMapper mapper)
    {
        _pageHeroRepository = pageHeroRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultPageHeroDto>> GetAllAsync()
    {
        var entities = await _pageHeroRepository.GetAllAsync();
        return _mapper.Map<List<ResultPageHeroDto>>(entities);
    }

    public async Task<ResultPageHeroDto> GetByIdAsync(int id)
    {
        var entity = await _pageHeroRepository.GetByIdAsync(id);
        return _mapper.Map<ResultPageHeroDto>(entity);
    }

    public async Task CreateAsync(CreatePageHeroDto dto)
    {
        var entity = _mapper.Map<PageHero>(dto);
        await _pageHeroRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdatePageHeroDto dto)
    {
        var entity = _mapper.Map<PageHero>(dto);
        await _pageHeroRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _pageHeroRepository.GetByIdAsync(id);
        await _pageHeroRepository.DeleteAsync(entity);
    }

    public async Task<ResultPageHeroDto?> GetByPageKeyAsync(string pageKey)
    {
        var entities = await _pageHeroRepository.GetAllAsync();
        var entity = entities.FirstOrDefault(e => e.PageKey == pageKey);
        return entity == null ? null : _mapper.Map<ResultPageHeroDto>(entity);
    }
}
