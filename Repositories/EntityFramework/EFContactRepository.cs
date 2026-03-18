using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFContactRepository : GenericRepository<Contact>, IContactRepository
{
    private readonly RmContext _context;

    public EFContactRepository(RmContext context) : base(context)
    {
        _context = context;
    }
}
