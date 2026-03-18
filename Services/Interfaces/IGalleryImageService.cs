using RmWebApi.DTOs.GalleryImageDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface IGalleryImageService : IGenericService<ResultGalleryImageDto, CreateGalleryImageDto, UpdateGalleryImageDto, GalleryImage>
{
}
