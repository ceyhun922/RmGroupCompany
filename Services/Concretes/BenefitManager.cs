using AutoMapper;
using RmWebApi.DTOs.BenefitDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class BenefitManager : IBenefitService
{
    private readonly IBenefitRepository _benefitRepository;
    private readonly IMapper _mapper;

    public BenefitManager(IBenefitRepository benefitRepository, IMapper mapper)
    {
        _benefitRepository = benefitRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultBenefitDto>> GetAllAsync()
    {
        var entities = await _benefitRepository.GetAllAsync();
        return _mapper.Map<List<ResultBenefitDto>>(entities);
    }

    public async Task<ResultBenefitDto> GetByIdAsync(int id)
    {
        var entity = await _benefitRepository.GetByIdAsync(id);
        return _mapper.Map<ResultBenefitDto>(entity);
    }

    public async Task CreateAsync(CreateBenefitDto dto)
    {
        var entity = _mapper.Map<Benefit>(dto);
        await _benefitRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateBenefitDto dto)
    {
        var entity = _mapper.Map<Benefit>(dto);
        await _benefitRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _benefitRepository.GetByIdAsync(id);
        await _benefitRepository.DeleteAsync(entity);
    }
}
