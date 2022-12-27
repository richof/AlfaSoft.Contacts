
using System.ComponentModel.DataAnnotations;

namespace AlfaSoft.Contacts.UI.Models
{
    public class ContactViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required(ErrorMessage="Name is required")]
        [MinLength(5,ErrorMessage ="Name must have at least 5 digits")]
        public string Name { get; set; }
        [StringLength(9,ErrorMessage ="Contact Phone must have 9 digits")]
        [Required(ErrorMessage = "Contact Phone is required")]
        public string ContactPhone { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }
        public FluentValidation.Results.ValidationResult ValidationResult { get; set; }
    }
}
