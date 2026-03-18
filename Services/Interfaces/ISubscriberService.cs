using RmWebApi.DTOs.SubscriberDTOs;
using RmWebApi.Entities;

namespace RmWebApi.Services.Interfaces;

public interface ISubscriberService : IGenericService<ResultSubscriberDto, CreateSubscriberDto, UpdateSubscriberDto, Subscriber>
{
}
