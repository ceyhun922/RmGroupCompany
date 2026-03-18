using AutoMapper;
using RmWebApi.DTOs.ServiceItemDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class ServiceItemManager : IServiceItemService
{
    private readonly IServiceItemRepository _serviceItemRepository;
    private readonly IMapper _mapper;

    public ServiceItemManager(IServiceItemRepository serviceItemRepository, IMapper mapper)
    {
        _serviceItemRepository = serviceItemRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultServiceItemDto>> GetAllAsync()
    {
        var entities = await _serviceItemRepository.GetAllAsync();
        return _mapper.Map<List<ResultServiceItemDto>>(entities);
    }

    public async Task<ResultServiceItemDto> GetByIdAsync(int id)
    {
        var entity = await _serviceItemRepository.GetByIdAsync(id);
        return _mapper.Map<ResultServiceItemDto>(entity);
    }

    public async Task CreateAsync(CreateServiceItemDto dto)
    {
        var entity = _mapper.Map<ServiceItem>(dto);
        await _serviceItemRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateServiceItemDto dto)
    {
        var entity = _mapper.Map<ServiceItem>(dto);
        await _serviceItemRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _serviceItemRepository.GetByIdAsync(id);
        await _serviceItemRepository.DeleteAsync(entity);
    }
}
