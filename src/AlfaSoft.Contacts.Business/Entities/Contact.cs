using FluentValidation;
using FluentValidation.Results;

namespace AlfaSoft.Contacts.Business
{
    public class Contact: AbstractValidator<Contact>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public ValidationResult ValidationResult { get; set; }
        public Contact()
        {
            Id = Guid.NewGuid();
        }

        public bool IsValid()
        {
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("Name length must be grater than 5");
            RuleFor(x => x.ContactPhone).Length(9).WithMessage("Contact Phone must have a length of 9");
            RuleFor(x => Email).EmailAddress(FluentValidation.Validators.EmailValidationMode.Net4xRegex).WithMessage("Email format is invalid");
            ValidationResult = Validate(this);
            return ValidationResult.IsValid;
        }
    }
}