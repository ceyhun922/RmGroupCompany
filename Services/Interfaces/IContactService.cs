using RmWebApi.DTOs.ContactDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface IContactService : IGenericService<ResultContactDto, CreateContactDto, UpdateContactDto, Contact>
{
}
