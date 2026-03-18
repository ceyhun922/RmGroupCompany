using System.Text.Json;
using AutoMapper;
using RmWebApi.Context;
using RmWebApi.DTOs.GoogleReviewDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace RmWebApi.Services.Concretes;

public class GoogleReviewManager : IGoogleReviewService
{
    private readonly IGoogleReviewRepository _googleReviewRepository;
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly HttpClient _httpClient;
    private readonly RmContext _context;

    public GoogleReviewManager(IGoogleReviewRepository googleReviewRepository, IMapper mapper, IConfiguration configuration, HttpClient httpClient, RmContext context)
    {
        _googleReviewRepository = googleReviewRepository;
        _mapper = mapper;
        _configuration = configuration;
        _httpClient = httpClient;
        _context = context;
    }

    public async Task<List<ResultGoogleReviewDto>> GetAllAsync()
    {
        var entities = await _googleReviewRepository.GetAllAsync();
        return _mapper.Map<List<ResultGoogleReviewDto>>(entities);
    }

    public async Task<ResultGoogleReviewDto> GetByIdAsync(int id)
    {
        var entity = await _googleReviewRepository.GetByIdAsync(id);
        return _mapper.Map<ResultGoogleReviewDto>(entity);
    }

    public async Task CreateAsync(CreateGoogleReviewDto dto)
    {
        var entity = _mapper.Map<GoogleReview>(dto);
        await _googleReviewRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateGoogleReviewDto dto)
    {
        var entity = _mapper.Map<GoogleReview>(dto);
        await _googleReviewRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _googleReviewRepository.GetByIdAsync(id);
        await _googleReviewRepository.DeleteAsync(entity);
    }

    public async Task SyncFromApifyAsync()
    {
        var token = _configuration["Apify:Token"];
        var url = $"https://api.apify.com/v2/acts/Xb8osYTtOjlsgI6k9/runs/last/dataset/items?token={token}&format=json";

        var response = await _httpClient.GetStringAsync(url);
        var items = JsonDocument.Parse(response).RootElement.EnumerateArray();

        await _context.GoogleReviews.ExecuteDeleteAsync();

        foreach (var item in items)
        {
            var name = item.GetProperty("name").GetString() ?? "";
            var publishedAt = item.GetProperty("publishedAtDate").GetString() ?? "";
            var date = DateTime.TryParse(publishedAt, out var dt)
                ? dt.ToString("dd.MM.yyyy")
                : publishedAt;

            await _context.GoogleReviews.AddAsync(new GoogleReview
            {
                Name = name,
                Date = date,
                Text = item.GetProperty("text").GetString() ?? "",
                Rating = item.GetProperty("stars").GetInt32(),
                Avatar = item.TryGetProperty("reviewerPhotoUrl", out var avatar) ? avatar.GetString() : null,
                Initial = name.Length > 0 ? name[0].ToString().ToUpper() : "?",
                CreatedAt = DateTime.UtcNow
            });
        }

        await _context.SaveChangesAsync();
    }

    public async Task<object> GetReviewsAsync()
    {
        var reviews = await _context.GoogleReviews.ToListAsync();

        var result = reviews.Select(r => new
        {
            id = r.Id,
            name = r.Name,
            date = r.Date,
            text = r.Text,
            rating = r.Rating,
            avatar = r.Avatar,
            initial = r.Initial
        }).ToList();

        var rating = reviews.Any() ? reviews.Average(r => r.Rating) : 0;

        return new
        {
            reviews = result,
            rating = Math.Round(rating, 1),
            totalReviews = reviews.Count,
            businessName = "MR Bauunternehmen"
        };
    }
}