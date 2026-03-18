using AutoMapper;
using RmWebApi.DTOs.ContactFormSubmissionDto;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class ContactFormSubmissionManager : IContactFormSubmissionService
{
    private readonly IContactFormSubmissionRepository _contactFormSubmissionRepository;
    private readonly IMapper _mapper;

    public ContactFormSubmissionManager(IContactFormSubmissionRepository contactFormSubmissionRepository, IMapper mapper)
    {
        _contactFormSubmissionRepository = contactFormSubmissionRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultContactFormSubmissionDto>> GetAllAsync()
    {
        var entities = await _contactFormSubmissionRepository.GetAllAsync();
        return _mapper.Map<List<ResultContactFormSubmissionDto>>(entities);
    }

    public async Task<ResultContactFormSubmissionDto> GetByIdAsync(int id)
    {
        var entity = await _contactFormSubmissionRepository.GetByIdAsync(id);
        return _mapper.Map<ResultContactFormSubmissionDto>(entity);
    }

    public async Task CreateAsync(CreateContactFormSubmissionDto dto)
    {
        var entity = _mapper.Map<ContactFormSubmission>(dto);
        await _contactFormSubmissionRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateContactFormSubmissionDto dto)
    {
        var entity = _mapper.Map<ContactFormSubmission>(dto);
        await _contactFormSubmissionRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _contactFormSubmissionRepository.GetByIdAsync(id);
        await _contactFormSubmissionRepository.DeleteAsync(entity);
    }
}
