using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class GoogleReviewRepository : GenericRepository<GoogleReview>, IGoogleReviewRepository
{
    public GoogleReviewRepository(RmContext context) : base(context)
    {
    }
}
