using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RmWebApi.DTOs.ServiceItemDTOs;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServiceItemController : ControllerBase
{
    private readonly IServiceItemService _serviceItemService;

    public ServiceItemController(IServiceItemService serviceItemService)
    {
        _serviceItemService = serviceItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _serviceItemService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _serviceItemService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateServiceItemDto dto)
    {
        await _serviceItemService.CreateAsync(dto);
        return Ok(new { message = "Başarıyla oluşturuldu." });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateServiceItemDto dto)
    {
        await _serviceItemService.UpdateAsync(dto);
        return Ok(new { message = "Başarıyla güncellendi." });
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _serviceItemService.DeleteAsync(id);
        return Ok(new { message = "Başarıyla silindi." });
    }
}
