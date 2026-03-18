using RmWebApi.DTOs.StatFactDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface IStatFactService : IGenericService<ResultStatFactDto, CreateStatFactDto, UpdateStatFactDto, StatFact>
{
}
