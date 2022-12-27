using FluentValidation.Results;

namespace AlfaSoft.Contacts.Business
{
    public class Contact
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}