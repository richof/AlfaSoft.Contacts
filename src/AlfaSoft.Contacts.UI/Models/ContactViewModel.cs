using FluentValidation.Results;

namespace AlfaSoft.Contacts.UI.Models
{
    public class ContactViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ContactPhone { get; set; }
        public string Email { get; set; }
        public ValidationResult ValidationResult { get; set; }
    }
}
