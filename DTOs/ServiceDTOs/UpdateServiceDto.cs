namespace RmWebApi.DTOs.ServiceDTOs;

public class UpdateServiceDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string IconName { get; set; }
    public string? ImageUrl { get; set; }
    public int DisplayOrder { get; set; }
    public List<ServiceItemInputDto> Items { get; set; } = new();
}
