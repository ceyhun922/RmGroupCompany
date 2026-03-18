using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RmWebApi.DTOs.ServiceDTOs;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceController : ControllerBase
{
    private readonly IServiceService _serviceService;

    public ServiceController(IServiceService serviceService)
    {
        _serviceService = serviceService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _serviceService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _serviceService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateServiceDto dto)
    {
        await _serviceService.CreateAsync(dto);
        return Ok(new { message = "Başarıyla oluşturuldu." });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateServiceDto dto)
    {
        await _serviceService.UpdateAsync(dto);
        return Ok(new { message = "Başarıyla güncellendi." });
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _serviceService.DeleteAsync(id);
        return Ok(new { message = "Başarıyla silindi." });
    }
}
