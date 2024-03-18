using AssesementWebAPI.Domain.Models;

namespace AssesementWebAPI.Services
{
    public interface IContactQuery
    {
        Task<List<Contact>> GetAllContact();
        Task<Contact> GetContactById(int id);

    }
}
