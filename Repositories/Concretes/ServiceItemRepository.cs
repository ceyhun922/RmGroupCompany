using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class ServiceItemRepository : GenericRepository<ServiceItem>, IServiceItemRepository
{
    public ServiceItemRepository(RmContext context) : base(context)
    {
    }
}
