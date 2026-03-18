using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFHeroSettingsRepository : GenericRepository<HeroSettings>, IHeroSettingsRepository
{
    private readonly RmContext _context;

    public EFHeroSettingsRepository(RmContext context) : base(context)
    {
        _context = context;
    }
}
