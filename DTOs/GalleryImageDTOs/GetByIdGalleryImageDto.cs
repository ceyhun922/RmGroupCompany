namespace RmWebApi.DTOs.GalleryImageDTOs;

public class GetByIdGalleryImageDto
{
    public int Id { get; set; }
    public string ImageUrl { get; set; }
    public string AltText { get; set; }
    public string Category { get; set; }
}
