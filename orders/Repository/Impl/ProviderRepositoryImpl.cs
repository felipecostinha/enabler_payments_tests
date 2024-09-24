using Microsoft.EntityFrameworkCore;
using orders.Domain;

namespace orders.Repository.Impl;

public class ProviderRepositoryImpl : IProviderRepository
{
    private readonly DatabaseContext _context;

    public ProviderRepositoryImpl(DatabaseContext context)
    {
        _context = context;
    }

    public void SaveProvider(Provider provider)
    {
        _context.Providers.AddAsync(provider).GetAwaiter();

        _context.SaveChangesAsync().GetAwaiter(); ;
    }

    public async Task<Payment?> GetProviderById(string id)
    {
        return await _context.Providers.FindAsync(id);
    }

    public async Task<List<Payment>> GetProviders()
    {
        return await _context.Providers.ToListAsync();
    }

    public async void UpdateProvider(Provider provider)
    {
        _context.Providers.Update(provider);

        await _context.SaveChangesAsync();
    }
}