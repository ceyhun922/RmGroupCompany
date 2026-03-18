using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RmWebApi.DTOs.GoogleReviewDTOs;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GoogleReviewController : ControllerBase
{
    private readonly IGoogleReviewService _googleReviewService;

    public GoogleReviewController(IGoogleReviewService googleReviewService)
    {
        _googleReviewService = googleReviewService;
    }

    [HttpPost("sync")]
    public async Task<IActionResult> Sync()
    {
        await _googleReviewService.SyncFromApifyAsync();
        return Ok(new { message = "Sync tamamlandı." });
    }

    [HttpGet("reviews")]
    public async Task<IActionResult> GetReviews()
    {
        var result = await _googleReviewService.GetReviewsAsync();
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _googleReviewService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _googleReviewService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGoogleReviewDto dto)
    {
        await _googleReviewService.CreateAsync(dto);
        return Ok(new { message = "Başarıyla oluşturuldu." });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGoogleReviewDto dto)
    {
        await _googleReviewService.UpdateAsync(dto);
        return Ok(new { message = "Başarıyla güncellendi." });
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _googleReviewService.DeleteAsync(id);
        return Ok(new { message = "Başarıyla silindi." });
    }
}