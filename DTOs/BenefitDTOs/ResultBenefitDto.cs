namespace RmWebApi.DTOs.BenefitDTOs;

public class ResultBenefitDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> ImageUrls { get; set; }
    public List<string> CheckItems { get; set; }
}
