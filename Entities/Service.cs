namespace RmWebApi.Entities;

public class Service
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string IconName { get; set; }
    public string? ImageUrl { get; set; }
    public List<string> Images { get; set; } = new();
    public int DisplayOrder { get; set; }
    public List<ServiceItem> Items { get; set; } = new();
}
