using AutoMapper;
using RmWebApi.DTOs.BenefitCheckItemDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class BenefitCheckItemManager : IBenefitCheckItemService
{
    private readonly IBenefitCheckItemRepository _benefitCheckItemRepository;
    private readonly IMapper _mapper;

    public BenefitCheckItemManager(IBenefitCheckItemRepository benefitCheckItemRepository, IMapper mapper)
    {
        _benefitCheckItemRepository = benefitCheckItemRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultBenefitCheckItemDto>> GetAllAsync()
    {
        var entities = await _benefitCheckItemRepository.GetAllAsync();
        return _mapper.Map<List<ResultBenefitCheckItemDto>>(entities);
    }

    public async Task<ResultBenefitCheckItemDto> GetByIdAsync(int id)
    {
        var entity = await _benefitCheckItemRepository.GetByIdAsync(id);
        return _mapper.Map<ResultBenefitCheckItemDto>(entity);
    }

    public async Task CreateAsync(CreateBenefitCheckItemDto dto)
    {
        var entity = _mapper.Map<BenefitCheckItem>(dto);
        await _benefitCheckItemRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateBenefitCheckItemDto dto)
    {
        var entity = _mapper.Map<BenefitCheckItem>(dto);
        await _benefitCheckItemRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _benefitCheckItemRepository.GetByIdAsync(id);
        await _benefitCheckItemRepository.DeleteAsync(entity);
    }
}
