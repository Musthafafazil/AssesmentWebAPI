using AssesementWebAPI.Domain.Models;
using AssesementWebAPI.Services;
using Microsoft.IdentityModel.Tokens;

namespace AssesementWebAPI.InfraStructure.Repository
{
    public class ContactCommand : IContactCommand
    {
        private readonly DataContext _context;
        public ContactCommand(DataContext context)
        {
            _context = context;
        }
        public async Task<Contact> AddContact(Contact contact)
        {
            _context.Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<Contact> UpdateContact(int id, Contact request)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                contact.FirstName = request.FirstName;
                contact.LastName = request.LastName;
                contact.PhoneNumber = request.PhoneNumber;
                contact.Email = request.Email;
                contact.Address = request.Address;
                contact.City = request.City;
                contact.State = request.State;
                contact.Country = request.Country;
                contact.PostalCode = request.PostalCode;
                contact.IsDeleted = request.IsDeleted;

                await _context.SaveChangesAsync();

                return contact;
            }
            else
            {
                return null;
            }
        }
    }
}
