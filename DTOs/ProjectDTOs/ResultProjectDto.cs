namespace RmWebApi.DTOs.ProjectDTOs;

public class ResultProjectDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Location { get; set; }
    public string MainImageUrl { get; set; }
    public int ProjectCategoryId { get; set; }
    public string CategoryName { get; set; }
    public List<string> Tags { get; set; }
    public DateTime CompletionDate { get; set; }
}
