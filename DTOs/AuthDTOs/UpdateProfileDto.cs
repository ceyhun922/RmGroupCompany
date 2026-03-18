namespace RmWebApi.DTOs.AuthDTOs;

public class UpdateProfileDto
{
    public string? FullName { get; set; }
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? CurrentPassword { get; set; }
    public string? NewPassword { get; set; }
}