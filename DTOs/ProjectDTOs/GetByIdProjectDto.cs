namespace RmWebApi.DTOs.ProjectDTOs;

public class GetByIdProjectDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string MainImageUrl { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string CategoryColorCode { get; set; }
    public List<string> Tags { get; set; }
    public DateTime CompletionDate { get; set; }
}
