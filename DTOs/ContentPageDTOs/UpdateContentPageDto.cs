namespace RmWebApi.DTOs.ContentPageDTOs;

public class UpdateContentPageDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string HtmlContent { get; set; }
    public string MetaTitle { get; set; }
    public string MetaDescription { get; set; }
}
