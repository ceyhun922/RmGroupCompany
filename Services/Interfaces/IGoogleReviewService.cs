using RmWebApi.DTOs.GoogleReviewDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface IGoogleReviewService : IGenericService<ResultGoogleReviewDto, CreateGoogleReviewDto, UpdateGoogleReviewDto, GoogleReview>
{
    Task SyncFromApifyAsync();
    Task<object> GetReviewsAsync();
}