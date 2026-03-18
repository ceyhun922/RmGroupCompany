namespace RmWebApi.DTOs.SubscriberDTOs;

public class ResultSubscriberDto
{
    public int Id { get; set; }
    public string Email { get; set; }
    public DateTime SubscribedAt { get; set; }
    public bool IsActive { get; set; }
}
