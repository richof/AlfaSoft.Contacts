using AlfaSoft.Contacts.Business.Interfaces.Services;

namespace AlfaSoft.Contacts.Business
{
    
    public class ContactService: IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Contact> CreateAsync(Contact contact)
        {
            if (!contact.IsValid()) return contact;
            return await _contactRepository.CreateAsync(contact);
        }
    }
}