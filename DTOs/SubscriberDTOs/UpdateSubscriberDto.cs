namespace RmWebApi.DTOs.SubscriberDTOs;

public class UpdateSubscriberDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public bool IsActive { get; set; }
}
