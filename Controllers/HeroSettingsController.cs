using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RmWebApi.DTOs.HeroSettingsDTOs;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HeroSettingsController : ControllerBase
{
    private readonly IHeroSettingsService _heroSettingsService;

    public HeroSettingsController(IHeroSettingsService heroSettingsService)
    {
        _heroSettingsService = heroSettingsService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _heroSettingsService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _heroSettingsService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateHeroSettingsDto dto)
    {
        await _heroSettingsService.CreateAsync(dto);
        return Ok(new { message = "Başarıyla oluşturuldu." });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateHeroSettingsDto dto)
    {
        await _heroSettingsService.UpdateAsync(dto);
        return Ok(new { message = "Başarıyla güncellendi." });
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _heroSettingsService.DeleteAsync(id);
        return Ok(new { message = "Başarıyla silindi." });
    }
}
