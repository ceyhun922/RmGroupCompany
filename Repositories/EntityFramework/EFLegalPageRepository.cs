using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFLegalPageRepository : GenericRepository<LegalPage>, ILegalPageRepository
{
    private readonly RmContext _context;

    public EFLegalPageRepository(RmContext context) : base(context)
    {
        _context = context;
    }
}
