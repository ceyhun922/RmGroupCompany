using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RmWebApi.DTOs.GalleryImageDTOs;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GalleryImageController : ControllerBase
{
    private readonly IGalleryImageService _galleryImageService;

    public GalleryImageController(IGalleryImageService galleryImageService)
    {
        _galleryImageService = galleryImageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _galleryImageService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _galleryImageService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateGalleryImageDto dto)
    {
        await _galleryImageService.CreateAsync(dto);
        return Ok(new { message = "Başarıyla oluşturuldu." });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateGalleryImageDto dto)
    {
        await _galleryImageService.UpdateAsync(dto);
        return Ok(new { message = "Başarıyla güncellendi." });
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _galleryImageService.DeleteAsync(id);
        return Ok(new { message = "Başarıyla silindi." });
    }
}
