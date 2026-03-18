namespace RmWebApi.DTOs.ContactDTOs;

public class CreateContactDto
{
    public string OfficeAddress { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }
    public string GoogleMapsEmbedUrl { get; set; }
}
