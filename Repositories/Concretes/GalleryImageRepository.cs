using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class GalleryImageRepository : GenericRepository<GalleryImage>, IGalleryImageRepository
{
    public GalleryImageRepository(RmContext context) : base(context)
    {
    }
}
