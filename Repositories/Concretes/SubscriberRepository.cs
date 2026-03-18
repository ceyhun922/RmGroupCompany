using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class SubscriberRepository : GenericRepository<Subscriber>, ISubscriberRepository
{
    public SubscriberRepository(RmContext context) : base(context)
    {
    }
}
