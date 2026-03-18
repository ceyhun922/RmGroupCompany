using RmWebApi.DTOs.BenefitCheckItemDTOs;

namespace RmWebApi.DTOs.BenefitDTOs;

public class CreateBenefitDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public List<string> ImageUrls { get; set; }
}
