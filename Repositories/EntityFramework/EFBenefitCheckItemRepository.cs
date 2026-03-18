using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFBenefitCheckItemRepository : GenericRepository<BenefitCheckItem>, IBenefitCheckItemRepository
{
    private readonly RmContext _context;

    public EFBenefitCheckItemRepository(RmContext context) : base(context)
    {
        _context = context;
    }
}
