using Microsoft.EntityFrameworkCore;
using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFProjectRepository : GenericRepository<Project>, IProjectRepository
{
    private readonly RmContext _context;

    public EFProjectRepository(RmContext context) : base(context)
    {
        _context = context;
    }

    public new async Task<List<Project>> GetAllAsync()
    {
        return await _context.Projects.Include(p => p.ProjectCategory).ToListAsync();
    }

    public new async Task<Project> GetByIdAsync(int id)
    {
        return await _context.Projects.Include(p => p.ProjectCategory).FirstOrDefaultAsync(p => p.Id == id);
    }
}
