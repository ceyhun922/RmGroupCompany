using RmWebApi.DTOs.PageHeroDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface IPageHeroService : IGenericService<ResultPageHeroDto, CreatePageHeroDto, UpdatePageHeroDto, PageHero>
{
    Task<ResultPageHeroDto?> GetByPageKeyAsync(string pageKey);
}
