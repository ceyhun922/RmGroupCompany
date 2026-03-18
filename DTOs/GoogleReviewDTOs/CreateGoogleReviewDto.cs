namespace RmWebApi.DTOs.GoogleReviewDTOs;

public class CreateGoogleReviewDto
{
    public string Name { get; set; }
    public string Date { get; set; }
    public string Text { get; set; }
    public int Rating { get; set; }
    public string? Avatar { get; set; }
    public string Initial { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
