using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class HeroSettingsRepository : GenericRepository<HeroSettings>, IHeroSettingsRepository
{
    public HeroSettingsRepository(RmContext context) : base(context)
    {
    }
}
