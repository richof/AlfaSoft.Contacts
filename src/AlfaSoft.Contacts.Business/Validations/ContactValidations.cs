using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlfaSoft.Contacts.Business.Validations
{
    public class ContactValidations :AbstractValidator<Contact>
    {
        private readonly IContactRepository _contactRepository;

        public ContactValidations(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            RuleFor(c => c.Email).MustAsync((contact, email, CancellationToken) => EmailIsAvailable(contact))
                .WithMessage("This Email is already in use");           

        }
        private async Task<bool> EmailIsAvailable(Contact contact)
        {
            bool isInUse = await _contactRepository.EmailIsInUseAsync(contact.Id, contact.Email);
            return !isInUse;
        }
    }
}
