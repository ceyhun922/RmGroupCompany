using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class StatFactRepository : GenericRepository<StatFact>, IStatFactRepository
{
    public StatFactRepository(RmContext context) : base(context)
    {
    }
}
