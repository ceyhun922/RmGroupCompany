namespace RmWebApi.DTOs.CertificateDTOs;

public class GetByIdCertificateDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public int DisplayOrder { get; set; }
}
