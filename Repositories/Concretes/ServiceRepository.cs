using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class ServiceRepository : GenericRepository<Service>, IServiceRepository
{
    public ServiceRepository(RmContext context) : base(context)
    {
    }
}
