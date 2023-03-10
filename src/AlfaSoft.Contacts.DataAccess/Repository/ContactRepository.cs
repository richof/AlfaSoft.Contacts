using AlfaSoft.Contacts.Business;
using AlfaSoft.Contacts.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace AlfaSoft.Contacts.DataAccess
{
    public class ContactRepository:IContactRepository
    {
        private MariaDbContext _context;

        public ContactRepository(MariaDbContext context)
        {
            _context = context;
        }

        public async Task<Contact> CreateAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<bool> EmailIsInUseAsync(Guid id, string email)
        {
            var result = await _context.Contacts.AnyAsync(c => c.Id != id && c.Email == email && !c.IsDeleted);
            return result;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            var result = await _context.Contacts.Where(x=> !x.IsDeleted).OrderBy(x=>x.Name).ToListAsync();
            return result;
        }

        public async Task<Contact> GetAsync(Guid id)
        {
            var result = await _context.Contacts.Where(x => x.Id==id && !x.IsDeleted).FirstOrDefaultAsync();
            return result;
        }

        public async Task<Contact> UpdateAsync(Contact contact)
        {
            _context.Contacts.Update(contact);
            await _context.SaveChangesAsync();
            return contact;
        }
    }
}