using RmWebApi.DTOs.LegalPageDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface ILegalPageService : IGenericService<ResultLegalPageDto, CreateLegalPageDto, UpdateLegalPageDto, LegalPage>
{
}
