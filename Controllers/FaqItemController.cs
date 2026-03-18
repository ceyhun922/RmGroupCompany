using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RmWebApi.DTOs.FaqItemDTOs;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FaqItemController : ControllerBase
{
    private readonly IFaqItemService _faqItemService;

    public FaqItemController(IFaqItemService faqItemService)
    {
        _faqItemService = faqItemService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _faqItemService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _faqItemService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateFaqItemDto dto)
    {
        await _faqItemService.CreateAsync(dto);
        return Ok(new { message = "Başarıyla oluşturuldu." });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateFaqItemDto dto)
    {
        await _faqItemService.UpdateAsync(dto);
        return Ok(new { message = "Başarıyla güncellendi." });
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _faqItemService.DeleteAsync(id);
        return Ok(new { message = "Başarıyla silindi." });
    }
}
