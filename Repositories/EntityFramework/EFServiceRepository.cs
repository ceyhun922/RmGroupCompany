using Microsoft.EntityFrameworkCore;
using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFServiceRepository : GenericRepository<Service>, IServiceRepository
{
    private readonly RmContext _context;

    public EFServiceRepository(RmContext context) : base(context)
    {
        _context = context;
    }

    public new async Task<List<Service>> GetAllAsync()
    {
        return await _context.Services
            .Include(s => s.Items)
            .OrderBy(s => s.DisplayOrder)
            .ToListAsync();
    }

    public new async Task<Service> GetByIdAsync(int id)
    {
        return await _context.Services
            .Include(s => s.Items)
            .FirstOrDefaultAsync(s => s.Id == id);
    }
}
