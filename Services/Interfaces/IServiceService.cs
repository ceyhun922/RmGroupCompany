using RmWebApi.DTOs.ServiceDTOs;

namespace RmWebApi.Services.Interfaces;

public interface IServiceService : IGenericService<ResultServiceDto, CreateServiceDto, UpdateServiceDto, RmWebApi.Entities.Service>
{
}
