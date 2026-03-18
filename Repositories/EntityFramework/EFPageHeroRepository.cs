using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFPageHeroRepository : GenericRepository<PageHero>, IPageHeroRepository
{
    private readonly RmContext _context;

    public EFPageHeroRepository(RmContext context) : base(context)
    {
        _context = context;
    }
}
