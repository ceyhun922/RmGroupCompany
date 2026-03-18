using RmWebApi.DTOs.BenefitDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface IBenefitService : IGenericService<ResultBenefitDto, CreateBenefitDto, UpdateBenefitDto, Benefit>
{
}
