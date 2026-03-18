using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RmWebApi.DTOs.AuthDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Controllers;

public class PhotoUploadRequest
{
    public IFormFile File { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<AppUser> _userManager;
    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _env;

    private readonly List<string> _allowedImageExtensions = new() { ".jpg", ".jpeg", ".png", ".webp" };
    private const long MaxImageSize = 10 * 1024 * 1024;

    public AuthController(UserManager<AppUser> userManager, IConfiguration configuration, IWebHostEnvironment env)
    {
        _userManager = userManager;
        _configuration = configuration;
        _env = env;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
            return Unauthorized(new { message = "Email veya şifre hatalı." });

        var isPasswordValid = await _userManager.CheckPasswordAsync(user, dto.Password);
        if (!isPasswordValid)
            return Unauthorized(new { message = "Email veya şifre hatalı." });

        var token = GenerateJwtToken(user);
        return Ok(token);
    }

    [HttpPost("seed-admin")]
    public async Task<IActionResult> SeedAdmin()
    {
        var existingUser = await _userManager.FindByEmailAsync("admin@rm.com");
        if (existingUser != null)
            return BadRequest(new { message = "Admin kullanıcısı zaten mevcut." });

        var admin = new AppUser
        {
            FullName = "Admin",
            UserName = "admin",
            Email = "admin@rm.com",
            EmailConfirmed = true,
            ProfilePhotoUrl = ""
        };

        var result = await _userManager.CreateAsync(admin, "Admin@123456");
        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(new { message = "Admin başarıyla oluşturuldu.", email = admin.Email, password = "Admin@123456" });
    }

    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                     ?? User.FindFirstValue(JwtRegisteredClaimNames.Sub);

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return NotFound(new { message = "Kullanıcı bulunamadı." });

        return Ok(new
        {
            user.Id,
            user.FullName,
            user.Email,
            user.UserName,
            user.ProfilePhotoUrl
        });
    }

    [HttpPut("update-photo")]
    [Consumes("multipart/form-data")]
    public async Task<IActionResult> UpdatePhoto([FromForm] PhotoUploadRequest request)
    {
        var file = request.File;

        if (file == null || file.Length == 0)
            return BadRequest(new { message = "Dosya seçilmedi." });

        var extension = Path.GetExtension(file.FileName).ToLowerInvariant();

        if (!_allowedImageExtensions.Contains(extension))
            return BadRequest(new { message = "Geçersiz dosya türü. İzin verilenler: jpg, jpeg, png, webp" });

        if (file.Length > MaxImageSize)
            return BadRequest(new { message = "Dosya boyutu 10MB'dan büyük olamaz." });

        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                     ?? User.FindFirstValue(JwtRegisteredClaimNames.Sub);

        var user = await _userManager.FindByIdAsync(userId);
        if (user == null)
            return NotFound(new { message = "Kullanıcı bulunamadı." });

        if (!string.IsNullOrEmpty(user.ProfilePhotoUrl))
        {
            var oldRelativePath = user.ProfilePhotoUrl
                .Replace($"{Request.Scheme}://{Request.Host}", "")
                .TrimStart('/');
            var oldFullPath = Path.Combine(_env.WebRootPath, oldRelativePath.Replace("/", Path.DirectorySeparatorChar.ToString()));
            if (System.IO.File.Exists(oldFullPath))
                System.IO.File.Delete(oldFullPath);
        }

        var uploadsPath = Path.Combine(_env.WebRootPath, "uploads", "images");
        if (!Directory.Exists(uploadsPath))
            Directory.CreateDirectory(uploadsPath);

        var uniqueFileName = $"{Guid.NewGuid()}{extension}";
        var filePath = Path.Combine(uploadsPath, uniqueFileName);

        using var stream = new FileStream(filePath, FileMode.Create);
        await file.CopyToAsync(stream);

        var photoUrl = $"{Request.Scheme}://{Request.Host}/uploads/images/{uniqueFileName}";

        user.ProfilePhotoUrl = photoUrl;
        var result = await _userManager.UpdateAsync(user);

        if (!result.Succeeded)
            return BadRequest(result.Errors);

        return Ok(new { message = "Fotoğraf güncellendi.", profilePhotoUrl = photoUrl });
    }

[HttpPut("update-profile")]
public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto dto)
{
    var userId = User.FindFirstValue(ClaimTypes.NameIdentifier)
                 ?? User.FindFirstValue(JwtRegisteredClaimNames.Sub);

    var user = await _userManager.FindByIdAsync(userId);
    if (user == null)
        return NotFound(new { message = "Kullanıcı bulunamadı." });

    if (!string.IsNullOrEmpty(dto.FullName))
        user.FullName = dto.FullName;

    if (!string.IsNullOrEmpty(dto.UserName))
        user.UserName = dto.UserName;

    if (!string.IsNullOrEmpty(dto.Email))
        user.Email = dto.Email;

    var updateResult = await _userManager.UpdateAsync(user);
    if (!updateResult.Succeeded)
        return BadRequest(updateResult.Errors);

    if (!string.IsNullOrEmpty(dto.CurrentPassword) && !string.IsNullOrEmpty(dto.NewPassword))
    {
        var passwordResult = await _userManager.ChangePasswordAsync(user, dto.CurrentPassword, dto.NewPassword);
        if (!passwordResult.Succeeded)
            return BadRequest(passwordResult.Errors);
    }

    return Ok(new
    {
        message = "Profil güncellendi.",
        user.FullName,
        user.UserName,
        user.Email
    });
}

    private TokenResponseDto GenerateJwtToken(AppUser user)
    {
        var jwtSettings = _configuration.GetSection("JwtSettings");
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiration = DateTime.UtcNow.AddHours(Convert.ToDouble(jwtSettings["ExpirationHours"]));

        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.Id),
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim("FullName", user.FullName ?? ""),
            new Claim("ProfilePhotoUrl", user.ProfilePhotoUrl ?? "")
        };

        var token = new JwtSecurityToken(
            issuer: jwtSettings["Issuer"],
            audience: jwtSettings["Audience"],
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

        return new TokenResponseDto
        {
            Token = new JwtSecurityTokenHandler().WriteToken(token),
            Expiration = expiration
        };
    }
}