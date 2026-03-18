
using RmWebApi.Entities;

public class Benefit
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> ImageUrls { get; set; }
    public List<BenefitCheckItem> BenefitCheckItems { get; set; }
}

