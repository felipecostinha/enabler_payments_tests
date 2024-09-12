using contacts.Application.Exceptions;
using contacts.Domain;
using contacts.Repository;

namespace contacts.Services.Impl;

public class ContactServiceImpl: IContactService
{
    private readonly IContactRepository _repository;

    public ContactServiceImpl(IContactRepository repository)
    {
        _repository = repository;
    }
    
    public void SaveContact(Contact contact)
    {
        _repository.SaveContact(contact);
    }

    public async Task<Contact> GetContactById(int id)
    {
        Contact? contact = await _repository.GetContactById(id);

        if (contact == null)
        {
            throw new NotFoundException("Contact not found");
        }
        
        return contact;
    }

    public async Task<List<Contact>> GetContacts()
    {
        return await _repository.GetContacts();
    }

    public async Task<Contact> UpdateContact(Contact contact)
    {
        Contact persistedContact = await GetContactById(contact.Id);
        
        persistedContact.FirstName = contact.FirstName;
        persistedContact.LastName = contact.LastName;
        persistedContact.Email = contact.Email;
        persistedContact.PhoneNumber = contact.PhoneNumber;
        
        _repository.UpdateContact(persistedContact);
        
        return persistedContact;
    }

    public async Task DeleteContact(int id)
    {
        _repository.DeleteContact(await GetContactById(id));
    }
}