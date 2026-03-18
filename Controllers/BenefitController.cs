using Microsoft.AspNetCore.Mvc;
using RmWebApi.DTOs.BenefitDTOs;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BenefitController : ControllerBase
{
    private readonly IBenefitService _benefitService;

    public BenefitController(IBenefitService benefitService)
    {
        _benefitService = benefitService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _benefitService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _benefitService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBenefitDto dto)
    {
        await _benefitService.CreateAsync(dto);
        return Ok(new { message = "Başarıyla oluşturuldu." });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBenefitDto dto)
    {
        await _benefitService.UpdateAsync(dto);
        return Ok(new { message = "Başarıyla güncellendi." });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _benefitService.DeleteAsync(id);
        return Ok(new { message = "Başarıyla silindi." });
    }
}