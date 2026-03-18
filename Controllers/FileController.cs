using Microsoft.AspNetCore.Mvc;

namespace RmWebApi.Controllers;

public class ImageUploadRequest
{
    public IFormFile File { get; set; }
}

public class VideoUploadRequest
{
    public IFormFile File { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class FileController : ControllerBase
{
    private readonly IWebHostEnvironment _env;

    private readonly List<string> _allowedImageExtensions = new() { ".jpg", ".jpeg", ".png", ".webp" };
    private readonly List<string> _allowedVideoExtensions = new() { ".mp4", ".webm", ".mov" };
    private const long MaxImageSize = 10 * 1024 * 1024;
    private const long MaxVideoSize = 100 * 1024 * 1024;

    public FileController(IWebHostEnvironment env)
    {
        _env = env;
    }

    [HttpPost("upload-image")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadImage([FromForm] ImageUploadRequest request)
    {
        var file = request.File;

        if (file == null || file.Length == 0)
            return BadRequest(new { message = "Dosya seçilmedi." });

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

        if (!_allowedImageExtensions.Contains(extension))
            return BadRequest(new { message = "Geçersiz dosya türü. İzin verilenler: jpg, jpeg, png, webp" });

        if (file.Length > MaxImageSize)
            return BadRequest(new { message = "Dosya boyutu 10MB'dan büyük olamaz." });

        var url = await SaveFileAsync(file, "images");
        return Ok(new { url });
    }

    [HttpPost("upload-video")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UploadVideo([FromForm] VideoUploadRequest request)
    {
        var file = request.File;

        if (file == null || file.Length == 0)
            return BadRequest(new { message = "Dosya seçilmedi." });

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

        if (!_allowedVideoExtensions.Contains(extension))
            return BadRequest(new { message = "Geçersiz dosya türü. İzin verilenler: mp4, webm, mov" });

        if (file.Length > MaxVideoSize)
            return BadRequest(new { message = "Dosya boyutu 100MB'dan büyük olamaz." });

        var url = await SaveFileAsync(file, "videos");
        return Ok(new { url });
    }

    
    [HttpDelete("delete")]
    public IActionResult DeleteFile([FromQuery] string fileUrl)
    {
        if (string.IsNullOrEmpty(fileUrl))
            return BadRequest(new { message = "Dosya URL'i boş olamaz." });

        var relativePath = fileUrl.Replace($"{Request.Scheme}://{Request.Host}", "").TrimStart('/');
        var fullPath = Path.Combine(_env.WebRootPath, relativePath.Replace("/", Path.DirectorySeparatorChar.ToString()));

        if (!System.IO.File.Exists(fullPath))
            return NotFound(new { message = "Dosya bulunamadı." });

        System.IO.File.Delete(fullPath);
        return Ok(new { message = "Dosya silindi." });
    }

    private async Task<string> SaveFileAsync(IFormFile file, string folder)
    {
        var uploadsPath = Path.Combine(_env.WebRootPath, "uploads", folder);

        if (!Directory.Exists(uploadsPath))
            Directory.CreateDirectory(uploadsPath);

        var uniqueFileName = $"{Guid.NewGuid()}{Path.GetExtension(file.FileName).ToLowerInvariant()}";
        var filePath = Path.Combine(uploadsPath, uniqueFileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        return $"{Request.Scheme}://{Request.Host}/uploads/{folder}/{uniqueFileName}";
    }
}