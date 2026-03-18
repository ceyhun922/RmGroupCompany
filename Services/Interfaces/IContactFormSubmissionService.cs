using RmWebApi.DTOs.ContactFormSubmissionDto;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface IContactFormSubmissionService : IGenericService<ResultContactFormSubmissionDto, CreateContactFormSubmissionDto, UpdateContactFormSubmissionDto, ContactFormSubmission>
{
}
