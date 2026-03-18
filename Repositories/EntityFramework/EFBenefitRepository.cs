using Microsoft.EntityFrameworkCore;
using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFBenefitRepository : GenericRepository<Benefit>, IBenefitRepository
{
    private readonly RmContext _context;

    public EFBenefitRepository(RmContext context) : base(context)
    {
        _context = context;
    }

    public new async Task<List<Benefit>> GetAllAsync()
    {
        return await _context.Benefits.Include(b => b.BenefitCheckItems).ToListAsync();
    }

    public new async Task<Benefit> GetByIdAsync(int id)
    {
        return await _context.Benefits.Include(b => b.BenefitCheckItems).FirstOrDefaultAsync(b => b.Id == id);
    }
}
