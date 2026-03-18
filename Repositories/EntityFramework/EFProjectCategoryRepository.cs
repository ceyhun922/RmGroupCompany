using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFProjectCategoryRepository : GenericRepository<ProjectCategory>, IProjectCategoryRepository
{
    private readonly RmContext _context;

    public EFProjectCategoryRepository(RmContext context) : base(context)
    {
        _context = context;
    }
}
