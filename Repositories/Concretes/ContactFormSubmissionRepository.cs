using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class ContactFormSubmissionRepository : GenericRepository<ContactFormSubmission>, IContactFormSubmissionRepository
{
    public ContactFormSubmissionRepository(RmContext context) : base(context)
    {
    }
}
