namespace RmWebApi.DTOs.HeroSettingsDTOs;

public class ResultHeroSettingsDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Type { get; set; }
    public string MediaUrl { get; set; }
    public string PrimaryButtonText { get; set; }
    public string PrimaryButtonLink { get; set; }
    public string SecondaryButtonText { get; set; }
    public string SecondaryButtonLink { get; set; }
}
