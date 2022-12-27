using AlfaSoft.Contacts.Business;
using AlfaSoft.Contacts.DataAccess.Context;
using Microsoft.EntityFrameworkCore;

namespace AlfaSoft.Contacts.DataAccess
{
    public class ContactRepository
    {
        private MariaDbContext _context;

        public ContactRepository(MariaDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Contact>> GetAllAsync()
        {
            var result = await _context.Contacts.OrderBy(x=>x.Name).ToListAsync();
            return result;
        }
    }
}