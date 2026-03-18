using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFContactFormSubmissionRepository : GenericRepository<ContactFormSubmission>, IContactFormSubmissionRepository
{
    private readonly RmContext _context;

    public EFContactFormSubmissionRepository(RmContext context) : base(context)
    {
        _context = context;
    }
}
