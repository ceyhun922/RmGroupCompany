using RmWebApi.DTOs.FaqItemDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface IFaqItemService : IGenericService<ResultFaqItemDto, CreateFaqItemDto, UpdateFaqItemDto, FaqItem>
{
}
