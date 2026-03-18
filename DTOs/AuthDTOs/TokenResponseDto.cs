namespace RmWebApi.DTOs.AuthDTOs;

public class TokenResponseDto
{
    public string Token { get; set; }
    public DateTime Expiration { get; set; }
}
