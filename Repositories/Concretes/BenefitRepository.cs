using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class BenefitRepository : GenericRepository<Benefit>, IBenefitRepository
{
    public BenefitRepository(RmContext context) : base(context)
    {
    }
}
