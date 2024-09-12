using contacts.Application.Context;
using contacts.Domain;
using Microsoft.EntityFrameworkCore;

namespace contacts.Repository.Impl;

public class ContactRepositoryImpl: IContactRepository
{
    private readonly DatabaseContext _context;

    public ContactRepositoryImpl(DatabaseContext context)
    {
        _context = context;
    }
    
    public void SaveContact(Contact contact)
    {
        _context.Contacts.AddAsync(contact).GetAwaiter();
        
        _context.SaveChangesAsync().GetAwaiter(); ;
    }

    public async Task<Contact?> GetContactById(int id)
    {
        return await _context.Contacts.FindAsync(id);
    }

    public async Task<List<Contact>> GetContacts()
    {
        return await _context.Contacts.ToListAsync();
    }

    public async void UpdateContact(Contact contact)
    {
        _context.Contacts.Update(contact);
        
        await _context.SaveChangesAsync();
    }

    public async void DeleteContact(Contact contact)
    {
        _context.Contacts.Remove(contact);
        
        await _context.SaveChangesAsync();
    }
}