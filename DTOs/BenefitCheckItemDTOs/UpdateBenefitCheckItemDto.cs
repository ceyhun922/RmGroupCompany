namespace RmWebApi.DTOs.BenefitCheckItemDTOs
{
    public class UpdateBenefitCheckItemDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int BenefitId { get; set; }
    }
}