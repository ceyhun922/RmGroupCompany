namespace RmWebApi.Entities;

public class FaqItem
{
    public int Id { get; set; }
    public string Question { get; set; }
    public string Answer { get; set; }
    public int DisplayOrder { get; set; }
    public bool IsPublished { get; set; }
}
