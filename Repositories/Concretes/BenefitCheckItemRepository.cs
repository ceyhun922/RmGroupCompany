using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class BenefitCheckItemRepository : GenericRepository<BenefitCheckItem>, IBenefitCheckItemRepository
{
    public BenefitCheckItemRepository(RmContext context) : base(context)
    {
    }
}
