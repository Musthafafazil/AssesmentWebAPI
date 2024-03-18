using AssesementWebAPI.Domain.Models;
using AssesementWebAPI.InfraStructure.Repository;

namespace AssesementWebAPI.Services
{
    public interface IContactCommand 
    {
        public Task<Contact> AddContact(Contact contact);

        public Task<Contact> UpdateContact(int id,Contact request);

    }
}
