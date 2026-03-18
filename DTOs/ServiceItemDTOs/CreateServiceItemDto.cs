namespace RmWebApi.DTOs.ServiceItemDTOs
{
    public class CreateServiceItemDto
    {
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int DisplayOrder { get; set; }
    public int ServiceId { get; set; }
    }
}