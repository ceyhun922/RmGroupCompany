namespace RmWebApi.DTOs.ServiceDTOs;

public class GetByIdServiceDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public List<ServiceItemDto> Items { get; set; }
}

public class ServiceItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int DisplayOrder { get; set; }
}
