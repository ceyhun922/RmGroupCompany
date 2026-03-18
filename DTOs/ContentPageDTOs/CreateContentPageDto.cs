namespace RmWebApi.DTOs.ContentPageDTOs;

public class CreateContentPageDto
{
    public string Title { get; set; }
    public string Slug { get; set; }
    public string HtmlContent { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
}
