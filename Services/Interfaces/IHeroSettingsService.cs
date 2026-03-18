using RmWebApi.DTOs.HeroSettingsDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface IHeroSettingsService : IGenericService<ResultHeroSettingsDto, CreateHeroSettingsDto, UpdateHeroSettingsDto, HeroSettings>
{
}
