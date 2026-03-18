using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFStatFactRepository : GenericRepository<StatFact>, IStatFactRepository
{
    private readonly RmContext _context;

    public EFStatFactRepository(RmContext context) : base(context)
    {
        _context = context;
    }
}
