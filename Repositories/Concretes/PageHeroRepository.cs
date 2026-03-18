using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class PageHeroRepository : GenericRepository<PageHero>, IPageHeroRepository
{
    public PageHeroRepository(RmContext context) : base(context)
    {
    }
}
