namespace RmWebApi.Entities;

public class PageHero
{
    public int Id { get; set; }
    public string PageKey { get; set; }
    public string Title { get; set; }
    public string Subtitle { get; set; }
    public BackgroundType  GetBackgroundType { get; set; }
    public string MediaUrl { get; set; }
}
