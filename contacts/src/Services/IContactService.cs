using contacts.Domain;

namespace contacts.Services;

public interface IContactService
{
    void SaveContact(Contact contact);
    Task<Contact> GetContactById(int id);
    Task<List<Contact>> GetContacts();
    Task<Contact> UpdateContact(Contact contact);
    Task DeleteContact(int id);
}