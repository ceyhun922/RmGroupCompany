using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class LegalPageRepository : GenericRepository<LegalPage>, ILegalPageRepository
{
    public LegalPageRepository(RmContext context) : base(context)
    {
    }
}
