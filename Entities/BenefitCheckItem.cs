namespace RmWebApi.Entities
{
    public class BenefitCheckItem
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int BenefitId { get; set; }
        public Benefit Benefit { get; set; }
    }

}