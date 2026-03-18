namespace RmWebApi.Entities
{
    public class ServiceItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string ImageUrl { get; set; }
    public int DisplayOrder { get; set; }
    public int ServiceId { get; set; }
    public Service Service { get; set; }
}
}