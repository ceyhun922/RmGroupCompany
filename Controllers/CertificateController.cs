using Microsoft.AspNetCore.Mvc;
using RmWebApi.DTOs.CertificateDTOs;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CertificateController : ControllerBase
{
    private readonly ICertificateService _certificateService;

    public CertificateController(ICertificateService certificateService)
    {
        _certificateService = certificateService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _certificateService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _certificateService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCertificateDto dto)
    {
        await _certificateService.CreateAsync(dto);
        return Ok(new { message = "Başarıyla oluşturuldu." });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCertificateDto dto)
    {
        await _certificateService.UpdateAsync(dto);
        return Ok(new { message = "Başarıyla güncellendi." });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _certificateService.DeleteAsync(id);
        return Ok(new { message = "Başarıyla silindi." });
    }
}