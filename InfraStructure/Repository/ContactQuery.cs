using AssesementWebAPI.Domain.Models;
using AssesementWebAPI.Services;
using Microsoft.EntityFrameworkCore;

namespace AssesementWebAPI.InfraStructure.Repository
{
    public class ContactQuery : IContactQuery
    {
        private readonly DataContext _context;
        public ContactQuery(DataContext context) 
        {
            _context = context; 
        }
        public async Task<List<Contact>> GetAllContact()
        {
           var contacts = await _context.Contacts.Where(contact => !contact.IsDeleted).ToListAsync();
           return contacts;
        }

        public async Task<Contact> GetContactById(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            return contact;
        }
    }
}
