using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class ProjectCategoryRepository : GenericRepository<ProjectCategory>, IProjectCategoryRepository
{
    public ProjectCategoryRepository(RmContext context) : base(context)
    {
    }
}
