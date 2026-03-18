using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFSubscriberRepository : GenericRepository<Subscriber>, ISubscriberRepository
{
    private readonly RmContext _context;

    public EFSubscriberRepository(RmContext context) : base(context)
    {
        _context = context;
    }
}
