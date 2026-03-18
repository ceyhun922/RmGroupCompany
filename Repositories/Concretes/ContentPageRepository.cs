using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class ContentPageRepository : GenericRepository<ContentPage>, IContentPageRepository
{
    public ContentPageRepository(RmContext context) : base(context)
    {
    }
}
