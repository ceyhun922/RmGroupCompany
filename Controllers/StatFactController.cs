using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RmWebApi.DTOs.StatFactDTOs;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StatFactController : ControllerBase
{
    private readonly IStatFactService _statFactService;

    public StatFactController(IStatFactService statFactService)
    {
        _statFactService = statFactService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _statFactService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _statFactService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateStatFactDto dto)
    {
        await _statFactService.CreateAsync(dto);
        return Ok(new { message = "Başarıyla oluşturuldu." });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStatFactDto dto)
    {
        await _statFactService.UpdateAsync(dto);
        return Ok(new { message = "Başarıyla güncellendi." });
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _statFactService.DeleteAsync(id);
        return Ok(new { message = "Başarıyla silindi." });
    }
}
