using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFContentPageRepository : GenericRepository<ContentPage>, IContentPageRepository
{
    private readonly RmContext _context;

    public EFContentPageRepository(RmContext context) : base(context)
    {
        _context = context;
    }
}
