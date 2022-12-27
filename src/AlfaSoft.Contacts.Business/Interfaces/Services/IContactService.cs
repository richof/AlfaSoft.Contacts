using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaSoft.Contacts.Business.Interfaces.Services
{
    public interface IContactService
    {
        Task<Contact> CreateAsync(Contact contact);
        Task<Contact> UpdateAsync(Contact contact);
    }
}
