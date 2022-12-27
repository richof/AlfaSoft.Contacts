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

        public Task<Contact> CreateAsync(Contact contact)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            var result = await _context.Contacts.OrderBy(x=>x.Name).ToListAsync();
            return result;
        }

        public async Task<Contact> GetAsync(Guid id)
        {
            var result = await _context.Contacts.Where(x => x.Id==id).FirstOrDefaultAsync();
            return result;
        }
    }
}