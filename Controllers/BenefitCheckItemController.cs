using Microsoft.AspNetCore.Mvc;
using RmWebApi.DTOs.BenefitCheckItemDTOs;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BenefitCheckItemController : ControllerBase
{
    private readonly IBenefitCheckItemService _benefitCheckItemService;

    public BenefitCheckItemController(IBenefitCheckItemService benefitCheckItemService)
    {
        _benefitCheckItemService = benefitCheckItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _benefitCheckItemService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _benefitCheckItemService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateBenefitCheckItemDto dto)
    {
        await _benefitCheckItemService.CreateAsync(dto);
        return Ok(new { message = "Başarıyla oluşturuldu." });
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateBenefitCheckItemDto dto)
    {
        await _benefitCheckItemService.UpdateAsync(dto);
        return Ok(new { message = "Başarıyla güncellendi." });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _benefitCheckItemService.DeleteAsync(id);
        return Ok(new { message = "Başarıyla silindi." });
    }
}