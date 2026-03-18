using AutoMapper;
using RmWebApi.DTOs.LegalPageDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class LegalPageManager : ILegalPageService
{
    private readonly ILegalPageRepository _legalPageRepository;
    private readonly IMapper _mapper;

    public LegalPageManager(ILegalPageRepository legalPageRepository, IMapper mapper)
    {
        _legalPageRepository = legalPageRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultLegalPageDto>> GetAllAsync()
    {
        var entities = await _legalPageRepository.GetAllAsync();
        return _mapper.Map<List<ResultLegalPageDto>>(entities);
    }

    public async Task<ResultLegalPageDto> GetByIdAsync(int id)
    {
        var entity = await _legalPageRepository.GetByIdAsync(id);
        return _mapper.Map<ResultLegalPageDto>(entity);
    }

    public async Task CreateAsync(CreateLegalPageDto dto)
    {
        var entity = _mapper.Map<LegalPage>(dto);
        await _legalPageRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateLegalPageDto dto)
    {
        var entity = _mapper.Map<LegalPage>(dto);
        await _legalPageRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _legalPageRepository.GetByIdAsync(id);
        await _legalPageRepository.DeleteAsync(entity);
    }
}
