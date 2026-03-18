using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RmWebApi.DTOs.ContactFormSubmissionDto;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ContactFormSubmissionController : ControllerBase
{
    private readonly IContactFormSubmissionService _contactFormSubmissionService;

    public ContactFormSubmissionController(IContactFormSubmissionService contactFormSubmissionService)
    {
        _contactFormSubmissionService = contactFormSubmissionService;
    }

    [Authorize]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _contactFormSubmissionService.GetAllAsync();
        return Ok(result);
    }

    [Authorize]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _contactFormSubmissionService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateContactFormSubmissionDto dto)
    {
        await _contactFormSubmissionService.CreateAsync(dto);
        return Ok(new { message = "Mesajınız başarıyla gönderildi." });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateContactFormSubmissionDto dto)
    {
        await _contactFormSubmissionService.UpdateAsync(dto);
        return Ok(new { message = "Başarıyla güncellendi." });
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _contactFormSubmissionService.DeleteAsync(id);
        return Ok(new { message = "Başarıyla silindi." });
    }
}
