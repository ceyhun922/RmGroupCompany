using RmWebApi.DTOs.ContentPageDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface IContentPageService : IGenericService<ResultContentPageDto, CreateContentPageDto, UpdateContentPageDto, ContentPage>
{
}
