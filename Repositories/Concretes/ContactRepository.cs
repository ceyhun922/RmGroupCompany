using RmWebApi.Context;
using RmWebApi.Entities;
using RmWebApi.Repositories.Interfaces;

namespace RmWebApi.Repositories.Concretes;

public class ContactRepository : GenericRepository<Contact>, IContactRepository
{
    public ContactRepository(RmContext context) : base(context)
    {
    }
}
