using AutoMapper;
using RmWebApi.DTOs.FaqItemDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class FaqItemManager : IFaqItemService
{
    private readonly IFaqItemRepository _faqItemRepository;
    private readonly IMapper _mapper;

    public FaqItemManager(IFaqItemRepository faqItemRepository, IMapper mapper)
    {
        _faqItemRepository = faqItemRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultFaqItemDto>> GetAllAsync()
    {
        var entities = await _faqItemRepository.GetAllAsync();
        return _mapper.Map<List<ResultFaqItemDto>>(entities);
    }

    public async Task<ResultFaqItemDto> GetByIdAsync(int id)
    {
        var entity = await _faqItemRepository.GetByIdAsync(id);
        return _mapper.Map<ResultFaqItemDto>(entity);
    }

    public async Task CreateAsync(CreateFaqItemDto dto)
    {
        var entity = _mapper.Map<FaqItem>(dto);
        await _faqItemRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateFaqItemDto dto)
    {
        var entity = _mapper.Map<FaqItem>(dto);
        await _faqItemRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _faqItemRepository.GetByIdAsync(id);
        await _faqItemRepository.DeleteAsync(entity);
    }
}
