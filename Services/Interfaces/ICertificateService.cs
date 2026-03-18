using RmWebApi.DTOs.CertificateDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface ICertificateService : IGenericService<ResultCertificateDto, CreateCertificateDto, UpdateCertificateDto, Certificate>
{
}
