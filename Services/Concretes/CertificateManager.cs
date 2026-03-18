using AutoMapper;
using RmWebApi.DTOs.CertificateDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class CertificateManager : ICertificateService
{
    private readonly ICertificateRepository _certificateRepository;
    private readonly IMapper _mapper;

    public CertificateManager(ICertificateRepository certificateRepository, IMapper mapper)
    {
        _certificateRepository = certificateRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultCertificateDto>> GetAllAsync()
    {
        var entities = await _certificateRepository.GetAllAsync();
        return _mapper.Map<List<ResultCertificateDto>>(entities);
    }

    public async Task<ResultCertificateDto> GetByIdAsync(int id)
    {
        var entity = await _certificateRepository.GetByIdAsync(id);
        return _mapper.Map<ResultCertificateDto>(entity);
    }

    public async Task CreateAsync(CreateCertificateDto dto)
    {
        var entity = _mapper.Map<Certificate>(dto);
        await _certificateRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateCertificateDto dto)
    {
        var entity = _mapper.Map<Certificate>(dto);
        await _certificateRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _certificateRepository.GetByIdAsync(id);
        await _certificateRepository.DeleteAsync(entity);
    }
}
