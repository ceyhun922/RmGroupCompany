using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RmWebApi.DTOs.ContentPageDTOs;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContentPageController : ControllerBase
{
    private readonly IContentPageService _contentPageService;

    public ContentPageController(IContentPageService contentPageService)
    {
        _contentPageService = contentPageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _contentPageService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _contentPageService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateContentPageDto dto)
    {
        await _contentPageService.CreateAsync(dto);
        return Ok(new { message = "Başarıyla oluşturuldu." });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateContentPageDto dto)
    {
        await _contentPageService.UpdateAsync(dto);
        return Ok(new { message = "Başarıyla güncellendi." });
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _contentPageService.DeleteAsync(id);
        return Ok(new { message = "Başarıyla silindi." });
    }
}
