namespace RmWebApi.DTOs.ProjectDTOs;

public class CreateProjectDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string MainImageUrl { get; set; }
    public int ProjectCategoryId { get; set; }
    public List<string> Tags { get; set; }
    public DateTime CompletionDate { get; set; }
}
