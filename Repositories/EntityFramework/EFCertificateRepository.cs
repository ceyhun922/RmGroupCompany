using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFCertificateRepository : GenericRepository<Certificate>, ICertificateRepository
{
    private readonly RmContext _context;

    public EFCertificateRepository(RmContext context) : base(context)
    {
        _context = context;
    }
}
