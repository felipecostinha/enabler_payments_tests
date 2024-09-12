using contacts.Domain;

namespace contacts.Repository;

public interface IContactRepository
{
    void SaveContact(Contact contact);
    Task<Contact?> GetContactById(int id);
    Task<List<Contact>> GetContacts();
    void UpdateContact(Contact contact);
    void DeleteContact(Contact contact);
}