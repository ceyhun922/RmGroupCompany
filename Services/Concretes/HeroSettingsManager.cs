using AutoMapper;
using RmWebApi.DTOs.HeroSettingsDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class HeroSettingsManager : IHeroSettingsService
{
    private readonly IHeroSettingsRepository _heroSettingsRepository;
    private readonly IMapper _mapper;

    public HeroSettingsManager(IHeroSettingsRepository heroSettingsRepository, IMapper mapper)
    {
        _heroSettingsRepository = heroSettingsRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultHeroSettingsDto>> GetAllAsync()
    {
        var entities = await _heroSettingsRepository.GetAllAsync();
        return _mapper.Map<List<ResultHeroSettingsDto>>(entities);
    }

    public async Task<ResultHeroSettingsDto> GetByIdAsync(int id)
    {
        var entity = await _heroSettingsRepository.GetByIdAsync(id);
        return _mapper.Map<ResultHeroSettingsDto>(entity);
    }

    public async Task CreateAsync(CreateHeroSettingsDto dto)
    {
        var entity = _mapper.Map<HeroSettings>(dto);
        await _heroSettingsRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateHeroSettingsDto dto)
    {
        var entity = _mapper.Map<HeroSettings>(dto);
        await _heroSettingsRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _heroSettingsRepository.GetByIdAsync(id);
        await _heroSettingsRepository.DeleteAsync(entity);
    }
}
