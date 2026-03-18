using RmWebApi.DTOs.ServiceItemDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface IServiceItemService : IGenericService<ResultServiceItemDto, CreateServiceItemDto, UpdateServiceItemDto, ServiceItem>
{
}
