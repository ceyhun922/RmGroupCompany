namespace RmWebApi.Entities;

public class HeroSettings
{
    public int Id { get; set; }
    public string Title { get; set; }
    public BackgroundType Type { get; set; }
    public string MediaUrl { get; set; }
    public string PrimaryButtonText { get; set; }
    public string PrimaryButtonLink { get; set; }
    public string SecondaryButtonText { get; set; }
    public string SecondaryButtonLink { get; set; }
}

public enum BackgroundType
{
    Image = 0,
    Video = 1
}
