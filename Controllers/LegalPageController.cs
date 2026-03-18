using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RmWebApi.DTOs.LegalPageDTOs;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LegalPageController : ControllerBase
{
    private readonly ILegalPageService _legalPageService;

    public LegalPageController(ILegalPageService legalPageService)
    {
        _legalPageService = legalPageService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _legalPageService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _legalPageService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateLegalPageDto dto)
    {
        await _legalPageService.CreateAsync(dto);
        return Ok(new { message = "Başarıyla oluşturuldu." });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateLegalPageDto dto)
    {
        await _legalPageService.UpdateAsync(dto);
        return Ok(new { message = "Başarıyla güncellendi." });
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _legalPageService.DeleteAsync(id);
        return Ok(new { message = "Başarıyla silindi." });
    }
}
