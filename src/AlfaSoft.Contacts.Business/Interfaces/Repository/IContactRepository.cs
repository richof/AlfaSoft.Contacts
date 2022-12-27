namespace AlfaSoft.Contacts.Business
{
    public interface IContactRepository
    {
        Task<Contact> CreateAsync(Contact contact);
        Task<bool> EmailIsInUseAsync(Guid id, string email);
        Task<IEnumerable<Contact>> GetAllAsync();
        Task<Contact> GetAsync(Guid id);
    }
}