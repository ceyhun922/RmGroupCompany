using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class FaqItemRepository : GenericRepository<FaqItem>, IFaqItemRepository
{
    public FaqItemRepository(RmContext context) : base(context)
    {
    }
}
