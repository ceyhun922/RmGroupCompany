using AutoMapper;
using RmWebApi.DTOs.StatFactDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class StatFactManager : IStatFactService
{
    private readonly IStatFactRepository _statFactRepository;
    private readonly IMapper _mapper;

    public StatFactManager(IStatFactRepository statFactRepository, IMapper mapper)
    {
        _statFactRepository = statFactRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultStatFactDto>> GetAllAsync()
    {
        var entities = await _statFactRepository.GetAllAsync();
        return _mapper.Map<List<ResultStatFactDto>>(entities);
    }

    public async Task<ResultStatFactDto> GetByIdAsync(int id)
    {
        var entity = await _statFactRepository.GetByIdAsync(id);
        return _mapper.Map<ResultStatFactDto>(entity);
    }

    public async Task CreateAsync(CreateStatFactDto dto)
    {
        var entity = _mapper.Map<StatFact>(dto);
        await _statFactRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateStatFactDto dto)
    {
        var entity = _mapper.Map<StatFact>(dto);
        await _statFactRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _statFactRepository.GetByIdAsync(id);
        await _statFactRepository.DeleteAsync(entity);
    }
}
