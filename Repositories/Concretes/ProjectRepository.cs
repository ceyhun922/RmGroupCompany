using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class ProjectRepository : GenericRepository<Project>, IProjectRepository
{
    public ProjectRepository(RmContext context) : base(context)
    {
    }
}
