using RmWebApi.DTOs.BenefitCheckItemDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface IBenefitCheckItemService : IGenericService<ResultBenefitCheckItemDto, CreateBenefitCheckItemDto, UpdateBenefitCheckItemDto, BenefitCheckItem>
{
}
