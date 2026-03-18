using AutoMapper;
using RmWebApi.DTOs.ContactDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class ContactManager : IContactService
{
    private readonly IContactRepository _contactRepository;
    private readonly IMapper _mapper;

    public ContactManager(IContactRepository contactRepository, IMapper mapper)
    {
        _contactRepository = contactRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultContactDto>> GetAllAsync()
    {
        var entities = await _contactRepository.GetAllAsync();
        return _mapper.Map<List<ResultContactDto>>(entities);
    }

    public async Task<ResultContactDto> GetByIdAsync(int id)
    {
        var entity = await _contactRepository.GetByIdAsync(id);
        return _mapper.Map<ResultContactDto>(entity);
    }

    public async Task CreateAsync(CreateContactDto dto)
    {
        var entity = _mapper.Map<Contact>(dto);
        await _contactRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateContactDto dto)
    {
        var entity = _mapper.Map<Contact>(dto);
        await _contactRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _contactRepository.GetByIdAsync(id);
        await _contactRepository.DeleteAsync(entity);
    }
}
