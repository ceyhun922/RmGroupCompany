namespace RmWebApi.DTOs.LegalPageDTOs;

public class ResultLegalPageDto
{
    public int Id { get; set; }
    public string PageTitle { get; set; }
    public string Content { get; set; }
    public DateTime LastUpdated { get; set; }
}
