using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFFaqItemRepository : GenericRepository<FaqItem>, IFaqItemRepository
{
    private readonly RmContext _context;

    public EFFaqItemRepository(RmContext context) : base(context)
    {
        _context = context;
    }
}
