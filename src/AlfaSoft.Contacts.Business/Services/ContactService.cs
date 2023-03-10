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
        public async Task<Contact> DeleteAsync(Guid Id)
        {
            Contact contact = await _contactRepository.GetAsync(Id);
            
            if(contact == null) {
                contact.ValidationResult.Errors.Add(new FluentValidation.Results.ValidationFailure("", "Contact doesn't exists or it was deleted"));
                return contact;
            };
            contact.IsDeleted = true;
            var result=await _contactRepository.UpdateAsync(contact);

            return result;
        }
    }
}