using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Concretes;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.EntityFramework;

public class EFGoogleReviewRepository : GenericRepository<GoogleReview>, IGoogleReviewRepository
{
    private readonly RmContext _context;

    public EFGoogleReviewRepository(RmContext context) : base(context)
    {
        _context = context;
    }
}
