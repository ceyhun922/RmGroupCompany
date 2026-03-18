using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFServiceItemRepository : GenericRepository<ServiceItem>, IServiceItemRepository
{
    private readonly RmContext _context;

    public EFServiceItemRepository(RmContext context) : base(context)
    {
        _context = context;
    }
}
