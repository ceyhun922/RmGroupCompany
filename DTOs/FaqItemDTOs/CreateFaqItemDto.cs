namespace RmWebApi.DTOs.FaqItemDTOs;

public class CreateFaqItemDto
{
    public string Question { get; set; }
    public string Answer { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsPublished { get; set; }
}
