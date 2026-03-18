using AutoMapper;
using RmWebApi.DTOs.GalleryImageDTOs;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;
using RmWebApi.Services.Interfaces;

namespace RmWebApi.Services.Concretes;

public class GalleryImageManager : IGalleryImageService
{
    private readonly IGalleryImageRepository _galleryImageRepository;
    private readonly IMapper _mapper;

    public GalleryImageManager(IGalleryImageRepository galleryImageRepository, IMapper mapper)
    {
        _galleryImageRepository = galleryImageRepository;
        _mapper = mapper;
    }

    public async Task<List<ResultGalleryImageDto>> GetAllAsync()
    {
        var entities = await _galleryImageRepository.GetAllAsync();
        return _mapper.Map<List<ResultGalleryImageDto>>(entities);
    }

    public async Task<ResultGalleryImageDto> GetByIdAsync(int id)
    {
        var entity = await _galleryImageRepository.GetByIdAsync(id);
        return _mapper.Map<ResultGalleryImageDto>(entity);
    }

    public async Task CreateAsync(CreateGalleryImageDto dto)
    {
        var entity = _mapper.Map<GalleryImage>(dto);
        await _galleryImageRepository.CreateAsync(entity);
    }

    public async Task UpdateAsync(UpdateGalleryImageDto dto)
    {
        var entity = _mapper.Map<GalleryImage>(dto);
        await _galleryImageRepository.UpdateAsync(entity);
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await _galleryImageRepository.GetByIdAsync(id);
        await _galleryImageRepository.DeleteAsync(entity);
    }
}
