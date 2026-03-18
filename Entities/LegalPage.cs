namespace RmWebApi.Entities;

public class LegalPage
{
    public int Id { get; set; }
    public string PageTitle { get; set; }
    public string Content { get; set; }
    public DateTime LastUpdated { get; set; }
}
