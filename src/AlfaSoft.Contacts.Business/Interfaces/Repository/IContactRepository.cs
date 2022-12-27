namespace AlfaSoft.Contacts.Business
{
    public interface IContactRepository
    {
        Task<Contact> CreateAsync(Contact contact);
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetAsync(Guid id);
    }
}