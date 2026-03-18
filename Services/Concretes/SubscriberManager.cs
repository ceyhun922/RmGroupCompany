using AutoMapper;
using RmWebApi.DTOs.SubscriberDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class SubscriberManager : ISubscriberService
{
    private readonly ISubscriberRepository _subscriberRepository;
    private readonly IMapper _mapper;

    public SubscriberManager(ISubscriberRepository subscriberRepository, IMapper mapper)
    {
        _subscriberRepository = subscriberRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultSubscriberDto>> GetAllAsync()
    {
        var entities = await _subscriberRepository.GetAllAsync();
        return _mapper.Map<List<ResultSubscriberDto>>(entities);
    }

    public async Task<ResultSubscriberDto> GetByIdAsync(int id)
    {
        var entity = await _subscriberRepository.GetByIdAsync(id);
        return _mapper.Map<ResultSubscriberDto>(entity);
    }

    public async Task CreateAsync(CreateSubscriberDto dto)
    {
        var entity = _mapper.Map<Subscriber>(dto);
        await _subscriberRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateSubscriberDto dto)
    {
        var entity = _mapper.Map<Subscriber>(dto);
        await _subscriberRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _subscriberRepository.GetByIdAsync(id);
        await _subscriberRepository.DeleteAsync(entity);
    }
}
