using AlfaSoft.Contacts.Business.Interfaces.Services;
using AlfaSoft.Contacts.Business.Validations;

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
            contact.ValidationResult = await new ContactValidations(_contactRepository).ValidateAsync(contact);
            if (!contact.ValidationResult.IsValid) return contact;
            return await _contactRepository.CreateAsync(contact);
        }
        public async Task<Contact> UpdateAsync(Contact contact)
        {
            if (!contact.IsValid()) return contact;
            contact.ValidationResult = await new ContactValidations(_contactRepository).ValidateAsync(contact);
            if (!contact.ValidationResult.IsValid) return contact;
            return await _contactRepository.UpdateAsync(contact);
        }
    }
}