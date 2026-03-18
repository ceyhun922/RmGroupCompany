using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RmWebApi.DTOs.PageHeroDTOs;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PageHeroController : ControllerBase
{
    private readonly IPageHeroService _pageHeroService;

    public PageHeroController(IPageHeroService pageHeroService)
    {
        _pageHeroService = pageHeroService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _pageHeroService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _pageHeroService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [HttpGet("bykey/{pageKey}")]
    public async Task<IActionResult> GetByPageKey(string pageKey)
    {
        var result = await _pageHeroService.GetByPageKeyAsync(pageKey);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreatePageHeroDto dto)
    {
        await _pageHeroService.CreateAsync(dto);
        return Ok(new { message = "Başarıyla oluşturuldu." });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdatePageHeroDto dto)
    {
        await _pageHeroService.UpdateAsync(dto);
        return Ok(new { message = "Başarıyla güncellendi." });
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _pageHeroService.DeleteAsync(id);
        return Ok(new { message = "Başarıyla silindi." });
    }
}
