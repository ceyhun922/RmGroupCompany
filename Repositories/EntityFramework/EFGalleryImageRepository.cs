using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFGalleryImageRepository : GenericRepository<GalleryImage>, IGalleryImageRepository
{
    private readonly RmContext _context;

    public EFGalleryImageRepository(RmContext context) : base(context)
    {
        _context = context;
    }
}
