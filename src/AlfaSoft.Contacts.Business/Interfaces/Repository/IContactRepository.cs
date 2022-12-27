namespace AlfaSoft.Contacts.Business
{
    public interface IContactRepository
    {
        Task<Contact> CreateAsync(Contact contact);
    }
}