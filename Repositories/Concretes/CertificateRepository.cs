using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class CertificateRepository : GenericRepository<Certificate>, ICertificateRepository
{
    public CertificateRepository(RmContext context) : base(context)
    {
    }
}
