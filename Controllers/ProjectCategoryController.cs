using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RmWebApi.DTOs.ProjectDTOs;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProjectCategoryController : ControllerBase
{
    private readonly IProjectCategoryService _projectCategoryService;

    public ProjectCategoryController(IProjectCategoryService projectCategoryService)
    {
        _projectCategoryService = projectCategoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var result = await _projectCategoryService.GetAllAsync();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _projectCategoryService.GetByIdAsync(id);
        if (result == null)
            return NotFound(new { message = "Kayıt bulunamadı." });
        return Ok(result);
    }

    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateProjectCategoryDto dto)
    {
        await _projectCategoryService.CreateAsync(dto);
        return Ok(new { message = "Başarıyla oluşturuldu." });
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProjectCategoryDto dto)
    {
        await _projectCategoryService.UpdateAsync(dto);
        return Ok(new { message = "Başarıyla güncellendi." });
    }

    [Authorize]
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _projectCategoryService.DeleteAsync(id);
        return Ok(new { message = "Başarıyla silindi." });
    }
}
